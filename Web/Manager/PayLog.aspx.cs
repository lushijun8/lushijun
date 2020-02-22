using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web.Manager
{
    public partial class PayLog : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int MallLogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/PayLog.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                    this.P_page = int.Parse(QueryString("page"));

                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.MallLogCount = 0;


            Entity.TEAMTOOL.ADMIN_LOG malllog = new Entity.TEAMTOOL.ADMIN_LOG();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (UserName like '%" + this.txtKeyword.Text + "%' or RealName like '%" + this.txtKeyword.Text + "%'  or Description like '%" + this.txtKeyword.Text + "%'  or Ip like '%" + this.txtKeyword.Text + "%' ) ";
            }
            malllog.WhereSql = wheresql;
            malllog.OrderBy = malllog._MALLLOGID + " DESC ";
            DataTable dtLog = malllog.SelectByPaging(_PageSize, this.P_page-1, out this.MallLogCount);//malllog.GetList(_PageSize, this.P_page, wheresql, "order by malllogid desc").Tables[0];
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.MallLogCount;
            page.Url =Business.Config.HostUrl + "/Manager/Paylog.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);
           
            if (this.MallLogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================

            this.rptMallLog.DataSource = dtLog;
            this.rptMallLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
           Entity.TEAMTOOL.ADMIN_LOG pay_log = new  Entity.TEAMTOOL.ADMIN_LOG();
           if (pay_log.TruncateTable())
           {
               this.AlertScript("清空成功！");
           }
           else
           {
               this.AlertScript("清空失败！");
           }
        }
    }
}
