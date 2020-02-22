using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_PageUrl : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string P_orderby = "";
        public string P_My = "0";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_PageUrl.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "lastconnecttime";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            this.P_My = this.QueryString("My");
            if (string.IsNullOrEmpty(this.P_My))
            {
                this.P_My = "0";
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
            //string CacheName = "Welcome_" + this.CurrentWebManagerName + "_17";
            DataTable oDt_PageUrl = null;
            //if (Cache[CacheName] != null)
            //{
            //    oDt_PageUrl = (DataTable)Cache[CacheName];
            //}
            //else
            //{ 

            Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
            //website_pageurl.CacheTime = 10;
            website_pageurl.SelectColumns = new string[] { website_pageurl._PAGEURL };

            website_pageurl.JoinSql = "LEFT JOIN DATABASE_SQL_CONNECT_STATS ON " + website_pageurl.TableName + "." + website_pageurl._PAGEURL + "=DATABASE_SQL_CONNECT_STATS.PAGEURL AND STATS_DATE = '" + this.P_Today + "'";
            website_pageurl.SelectColumns = new string[] { 
                "" + website_pageurl.TableName + ".*", 
                "request_count",
                "connect_times_min",
                "connect_times_max",
                "connect_times_avg",
                "duration_min",
                "duration_max",
                "duration_avg",
                "lastconnecttime"
                };
            //website_pageurl.WhereSql = "" + website_pageurl.TableName + "." + website_pageurl._PAGEURL + " LIKE '%Business/GetMenu.do%' ";
            oDt_PageUrl = website_pageurl.Select();
            //--------------------------------------------------------- 
            oDt_PageUrl.Columns.Add(new DataColumn("IsMy", typeof(int)));

            foreach (DataRow oDr_PageUrl in oDt_PageUrl.Rows)
            {
                int IsMy = 0;
                if (oDr_PageUrl[website_pageurl._WEBMANAGER_NAME].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                {
                    IsMy = 1;
                }
                oDr_PageUrl["IsMy"] = IsMy;
            } 
            //Cache.Add(CacheName, oDt_PageUrl.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, 120 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            //}

            //--------------------------------------------------------------
            DataView oDv = oDt_PageUrl.DefaultView;
            oDv.Sort = this.P_orderby + " DESC";
            oDv.RowFilter = " 1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                oDv.RowFilter += " AND (PAGEURL LIKE '%" + this.txtKeyword.Text + "%' OR WEBMANAGER_NAME like '%" + this.txtKeyword.Text + "%') ";
            }
            if (this.P_My == "1")
            {
                oDv.RowFilter += " AND IsMy = 1 ";
            }
            if (this.P_My == "2")
            {
                oDv.RowFilter += " AND WEBMANAGER_NAME<>'' ";
            }
            if (this.P_My == "3")
            {
                oDv.RowFilter += " AND WEBMANAGER_NAME_LIKE LIKE '%" + this.CurrentWebManagerName + "%' ";
            }
            if (this.P_My == "4")
            {
                oDv.RowFilter += " AND lastconnecttime >='"+P_Today+"' ";
            }
            if (this.P_My == "5")
            {
                oDv.RowFilter += " AND ErrorTime IS NOT NULL ";
            }
            if (this.P_My == "6")
            {
                oDv.RowFilter += " AND (form_Phone_Encrypt=0 OR querystring_Phone_Encrypt=0) ";
            }
            if (this.P_My == "7")
            {
                oDv.RowFilter += " AND WEBMANAGER_REALNAME_DEPEND<>'' ";
            }
            this.LogCount = oDv.Count;
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
            #endregion

            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 9; i >= 0; i--)
            {
                DataRow oDr_New = oDt_Date.NewRow();
                oDr_New["Date"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyy-MM-dd");
                if (System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.P_Today).ToShortDateString())
                {
                    oDr_New["isCurrentDate"] = 1;
                }
                else
                {
                    oDr_New["isCurrentDate"] = 0;
                }
                oDt_Date.Rows.Add(oDr_New);
            }
            this.rpt_Date.DataSource = oDt_Date;
            this.rpt_Date.DataBind();
            #endregion
        }

        public void get_Error(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("Content", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("Error_CreateTime", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("IP", typeof(string)));
            dt.Columns.Add(new DataColumn("username", typeof(string)));
            dt.Columns.Add(new DataColumn("classname", typeof(string)));
            dt.Columns.Add(new DataColumn("MethodName", typeof(string)));
            dt.Columns.Add(new DataColumn("loglevel", typeof(int)));

            Entity.TEAMTOOL.LOG_STATS log_stats_today_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_today_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            log_stats_today_all.CacheTime = 10;
            DataTable dt_log_stats_today_all = log_stats_today_all.Select();

            Entity.TEAMTOOL.LOG_STATS log_stats_yestoday_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_yestoday_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
            log_stats_yestoday_all.CacheTime = 10;
            DataTable dt_log_stats_yestoday_all = log_stats_yestoday_all.Select();

            foreach (DataRow oDr_Connect_Log_Stats in dt.Rows)
            {
                string pageurl = oDr_Connect_Log_Stats[log_stats_today_all._PAGEURL].ToString();
                string pageurl_regex = pageurl;
                string[] pageurls = pageurl.Split('/');
                if (pageurls.Length >= 3)
                {
                    pageurl_regex = pageurl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
                }
                DataRow[] oDrs_log_stats_today_all = dt_log_stats_today_all.Select(log_stats_today_all._PAGEURL_REGEX + "='" + pageurl_regex + "'");
                if (oDrs_log_stats_today_all != null && oDrs_log_stats_today_all.Length > 0)//今天的
                {
                    DataRow oDr_log_stats_today_all = oDrs_log_stats_today_all[0];
                    oDr_Connect_Log_Stats["Content"] = oDr_log_stats_today_all["Content"];
                    oDr_Connect_Log_Stats["Remarks"] = oDr_log_stats_today_all["Remarks"];
                    oDr_Connect_Log_Stats["Error_CreateTime"] = oDr_log_stats_today_all["Error_CreateTime"];
                    oDr_Connect_Log_Stats["Title"] = oDr_log_stats_today_all["Title"];
                    oDr_Connect_Log_Stats["IP"] = oDr_log_stats_today_all["IP"];
                    oDr_Connect_Log_Stats["username"] = oDr_log_stats_today_all["username"];
                    oDr_Connect_Log_Stats["classname"] = oDr_log_stats_today_all["classname"];
                    oDr_Connect_Log_Stats["MethodName"] = oDr_log_stats_today_all["MethodName"];
                    oDr_Connect_Log_Stats["loglevel"] = oDr_log_stats_today_all["loglevel"];

                }
                else//昨天的
                {
                    DataRow[] oDrs_log_stats_yestoday_all = dt_log_stats_yestoday_all.Select(log_stats_yestoday_all._PAGEURL_REGEX + "='" + pageurl_regex + "'");
                    if (oDrs_log_stats_yestoday_all != null && oDrs_log_stats_yestoday_all.Length > 0)//今天的
                    {
                        DataRow oDr_log_stats_yestoday_all = oDrs_log_stats_yestoday_all[0];
                        oDr_Connect_Log_Stats["Content"] = oDr_log_stats_yestoday_all["Content"];
                        oDr_Connect_Log_Stats["Remarks"] = oDr_log_stats_yestoday_all["Remarks"];
                        oDr_Connect_Log_Stats["Error_CreateTime"] = oDr_log_stats_yestoday_all["Error_CreateTime"];
                        oDr_Connect_Log_Stats["Title"] = oDr_log_stats_yestoday_all["Title"];
                        oDr_Connect_Log_Stats["IP"] = oDr_log_stats_yestoday_all["IP"];
                        oDr_Connect_Log_Stats["username"] = oDr_log_stats_yestoday_all["username"];
                        oDr_Connect_Log_Stats["classname"] = oDr_log_stats_yestoday_all["classname"];
                        oDr_Connect_Log_Stats["MethodName"] = oDr_log_stats_yestoday_all["MethodName"];
                        oDr_Connect_Log_Stats["loglevel"] = oDr_log_stats_yestoday_all["loglevel"];
                    }

                }
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
