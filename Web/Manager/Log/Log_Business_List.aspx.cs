using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Log
{
    public partial class Log_Business_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Log/Log_Business_List.aspx");
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
            this.LogCount = 0;

            Entity.TEAMTOOL.LOG_BUSINESS log_business = new Entity.TEAMTOOL.LOG_BUSINESS();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" +
                    log_business.TableName + "." + log_business._USERNAME + " = '" + this.txtKeyword.Text + "' or " +
                    log_business.TableName + "." + log_business._PAGEURL + " = '" + this.txtKeyword.Text + "' or " +
                    log_business.TableName + "." + log_business._TITLE + " = '" + this.txtKeyword.Text + "') ";
            }
            log_business.LEFT_JOIN_WEBSITE_PAGEURL = true;
            log_business.SelectColumns = new string[] {
                log_business.TableName+".*",
                "website_pageurl.ErrorInfo",
                "website_pageurl.ErrorTime",
                "website_pageurl.Depend_PageUrl",
                "website_pageurl.Depend_PageUrl_Out",
                "website_pageurl.form_Phone_Encrypt",
                "website_pageurl.querystring_Phone_Encrypt",
                "website_pageurl.querystring",
                "website_pageurl.form",
                "website_pageurl.webmanager_realname_depend",
                "website_pageurl.webmanager_realname_like",
                "website_pageurl.webmanager_realname",
                "website_pageurl.webmanager_name"
            };
            log_business.WhereSql = wheresql;
            log_business.OrderBy = log_business._ID + " DESC ";
            log_business.CacheTime = 10;
            DataTable dtLog = log_business.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //--------------------------------------------------------
            dtLog.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dtLog.Rows)
            {
                int IsMy = 0;
                if (oDr_Connect_Log_Stats["WebManager_Name"].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                {
                    IsMy = 1;
                }
                oDr_Connect_Log_Stats["IsMy"] = IsMy;
            }
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Log/Log_Business_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            //Web.Manager.Welcome.get_Depend(dtLog);//外部依赖
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
