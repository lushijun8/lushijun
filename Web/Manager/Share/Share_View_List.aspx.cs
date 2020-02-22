using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_View_List : Business.ManageWeb
    {
        protected string outPage = "";
        protected string P_keyword = "";
        public int P_page = 1;
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_View_List.aspx");

            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;
            Entity.TEAMTOOL.SHARE_VIEW share_view = new Entity.TEAMTOOL.SHARE_VIEW();
            share_view.LEFT_JOIN_SHARE_ARTICLE = true;
            share_view.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            share_view.Distinct = false;
            share_view.SelectColumns = new string[] { share_view._CREATETIME, share_view._VIEW_WEBMANAGER_NAME, "Article_text", share_view._VIEW_BG_NO, "WebManager_RealName" };
            share_view.OrderBy = share_view._CREATETIME+" DESC";
            if (this.txtKeyword.Text.Trim() != null)
            {
                share_view.WhereSql = share_view._VIEW_WEBMANAGER_NAME + " like '%" + this.txtKeyword.Text + "%'";
            }
            DataTable dt_share_view = share_view.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Share/Share_View_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================

            this.rptLog.DataSource = dt_share_view;
            this.rptLog.DataBind();
            #endregion

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
