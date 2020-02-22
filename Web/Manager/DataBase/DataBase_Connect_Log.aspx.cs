using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Connect_Log : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Connect_Log.aspx");
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

            Entity.TEAMTOOL.DATABASE_CONNECTSTRING database_connectstring = new Entity.TEAMTOOL.DATABASE_CONNECTSTRING();
            database_connectstring.CacheTime = 120;
            DataTable dt_database_connectstring = database_connectstring.Select();

            Entity.TEAMTOOL.DATABASE_CONNECT_LOG database_connect_log = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG();
            //database_connect_log.SelectColumns = new string[] { "DATABASE_CONNECT_LOG.*", database_connectstring._DATABASE_IP_ROMOTE, database_connectstring._DATABASE_NAME, database_connectstring._DATABASE_REMARK, database_connectstring._DATABASE_CONNECT_TIMES, database_connectstring._DATABASE_CONNECT_TIMES_TODAY };
            string wheresql = "1=1 ";//
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " and (" + database_connect_log._PAGEURL + " = '" + this.txtKeyword.Text + "' OR " + database_connect_log._SESSIONID + " = '" + this.txtKeyword.Text + "') ";
            }
            //database_connect_log.LEFT_JOIN_DATABASE_CONNECTSTRING = true;
            database_connect_log.WhereSql = wheresql;
            database_connect_log.OrderBy = database_connect_log._ID + " DESC ";
            database_connect_log.CacheTime = 10;
            DataTable dtLog = database_connect_log.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);


            dtLog.Columns.Add(new DataColumn(database_connectstring._DATABASE_IP_ROMOTE, typeof(string)));
            dtLog.Columns.Add(new DataColumn(database_connectstring._DATABASE_NAME, typeof(string)));
            dtLog.Columns.Add(new DataColumn(database_connectstring._DATABASE_REMARK, typeof(string)));
            dtLog.Columns.Add(new DataColumn(database_connectstring._DATABASE_CONNECT_TIMES, typeof(string)));
            dtLog.Columns.Add(new DataColumn(database_connectstring._DATABASE_CONNECT_TIMES_TODAY, typeof(string)));
            foreach (DataRow oDr_Log in dtLog.Rows)
            {
                DataRow[] oDrs = dt_database_connectstring.Select(database_connectstring._DATABASE_CONNECTSTRING_NAME + " = '" + oDr_Log[database_connect_log._CONNECTNAME].ToString() + "'");
                if (oDrs != null && oDrs.Length > 0)
                {

                    oDr_Log[database_connectstring._DATABASE_IP_ROMOTE] = oDrs[0][database_connectstring._DATABASE_IP_ROMOTE].ToString();
                    oDr_Log[database_connectstring._DATABASE_NAME] = oDrs[0][database_connectstring._DATABASE_NAME].ToString();
                    oDr_Log[database_connectstring._DATABASE_REMARK] = oDrs[0][database_connectstring._DATABASE_REMARK].ToString();
                    oDr_Log[database_connectstring._DATABASE_CONNECT_TIMES] = oDrs[0][database_connectstring._DATABASE_CONNECT_TIMES].ToString();
                    oDr_Log[database_connectstring._DATABASE_CONNECT_TIMES_TODAY] = oDrs[0][database_connectstring._DATABASE_CONNECT_TIMES_TODAY].ToString();
                }
            }
            dtLog.AcceptChanges();
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Connect_Log.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            //--------------------------------------------------------
            string PageUrl = "xxxx";
            foreach (DataRow oDr in dtLog.Rows)
            {
                PageUrl += "|" + oDr["pageurl"].ToString();
            }

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            website_my_pageurl.Split_Or_And = true;
            website_my_pageurl.PAGEURL = PageUrl;
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            //---------------------------------------------------------
            dtLog.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dtLog.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dtLog.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log in dtLog.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_Connect_Log["IsMy"] = IsMy;
                }
            }
            //--------------------------------------------------------------
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
