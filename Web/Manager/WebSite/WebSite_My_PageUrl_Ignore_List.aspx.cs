using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_Ignore_List : Business.ManageWeb
    {
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_Ignore_List.aspx");
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "connectionstring_today_min";
            }
            if (!Page.IsPostBack)
            {
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
            website_my_pageurl_ignore.WEBMANAGER_NAME = this.CurrentWebManagerName;
            website_my_pageurl_ignore.PAGEURL = "%" + this.txtKeyword.Text + "%";
            DataTable oDt_website_my_pageurl_ignore = website_my_pageurl_ignore.Select();

            //---------------------------------------------------------
            string Sql = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + System.DateTime.Now.ToShortDateString() + "','2000' ,'','connectionstring_today_min'";
            string cacheName = Com.Common.EncDec.PasswordEncrypto(Sql);
            DataTable dt_Connect_Log_Stats = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName, 20);
            if (dt_Connect_Log_Stats == null)
            {
                Entity.TEAMTOOL.DATABASE_CONNECT_LOG_STATS dataBase_connect_log_stats = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG_STATS();
                dt_Connect_Log_Stats = dataBase_connect_log_stats.Database_Owner.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName, dt_Connect_Log_Stats, 20);
            }
            //--------------------------------------------------------- 
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("request_count_today", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("request_count_yestoday", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("connectionstring_today_min", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("connectionstring_yestoday_min", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("connectionstring_today_max", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("connectionstring_yestoday_max", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_today", typeof(string)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_yestoday", typeof(string)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_today_min", typeof(float)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_yestoday_min", typeof(float)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_today_max", typeof(float)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("duration_yestoday_max", typeof(float)));

            foreach (DataRow oDr_website_my_pageurl in oDt_website_my_pageurl_ignore.Rows)
            {
                DataRow[] oDr_Connect_Log_Stats = dt_Connect_Log_Stats.Select(website_my_pageurl_ignore._PAGEURL + "='" + oDr_website_my_pageurl[website_my_pageurl_ignore._PAGEURL].ToString() + "'");
                if (oDr_Connect_Log_Stats != null && oDr_Connect_Log_Stats.Length > 0)
                {
                    oDr_website_my_pageurl["request_count_today"] = oDr_Connect_Log_Stats[0]["request_count_today"].ToString();
                    oDr_website_my_pageurl["request_count_yestoday"] = oDr_Connect_Log_Stats[0]["request_count_yestoday"].ToString();
                    oDr_website_my_pageurl["connectionstring_today_min"] = oDr_Connect_Log_Stats[0]["connectionstring_today_min"].ToString();
                    oDr_website_my_pageurl["connectionstring_yestoday_min"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_min"].ToString();
                    oDr_website_my_pageurl["connectionstring_today_max"] = oDr_Connect_Log_Stats[0]["connectionstring_today_max"].ToString();
                    oDr_website_my_pageurl["connectionstring_yestoday_max"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_max"].ToString();
                    oDr_website_my_pageurl["duration_today"] = oDr_Connect_Log_Stats[0]["duration_today"].ToString();
                    oDr_website_my_pageurl["duration_yestoday"] = oDr_Connect_Log_Stats[0]["duration_yestoday"].ToString();
                    oDr_website_my_pageurl["duration_today_min"] = oDr_Connect_Log_Stats[0]["duration_today_min"].ToString();
                    oDr_website_my_pageurl["duration_yestoday_min"] = oDr_Connect_Log_Stats[0]["duration_yestoday_min"].ToString();
                    oDr_website_my_pageurl["duration_today_max"] = oDr_Connect_Log_Stats[0]["duration_today_max"].ToString();
                    oDr_website_my_pageurl["duration_yestoday_max"] = oDr_Connect_Log_Stats[0]["duration_yestoday_max"].ToString();
                }
                string WebManager_Name = "";
                string WebManager_RealName = "";
                DataRow[] oDrs_website_my_pageurl_ignore = oDt_website_my_pageurl_all.Select(website_my_pageurl_ignore._PAGEURL + "='" + oDr_website_my_pageurl[website_my_pageurl_ignore._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl_ignore != null && oDrs_website_my_pageurl_ignore.Length > 0)
                {
                    foreach (DataRow oDr in oDrs_website_my_pageurl_ignore)
                    {
                        WebManager_Name += oDr[website_my_pageurl_ignore._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                    }
                }
                oDr_website_my_pageurl[website_my_pageurl_ignore._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                oDr_website_my_pageurl["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
            }
            //Web.Manager.Welcome.get_Depend(oDt_website_my_pageurl_ignore);//外部依赖
            //--------------------------------------------------------------
            DataView oDv = oDt_website_my_pageurl_ignore.DefaultView;
            oDv.Sort = this.P_orderby + " DESC";
            this.LogCount = oDv.Count;
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
