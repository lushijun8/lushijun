using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_List_All : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_List_All.aspx");
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "duration_avg";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
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

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            string wheresql = " 1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " AND (" + website_my_pageurl.TableName + "." + website_my_pageurl._PAGEURL + " LIKE '%" + this.txtKeyword.Text + "%' OR " + website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME + " LIKE '%" + this.txtKeyword.Text + "%') ";
            }
            website_my_pageurl.WhereSql = wheresql;
            website_my_pageurl.Distinct = true;
            website_my_pageurl.JoinSql = "LEFT JOIN DATABASE_SQL_CONNECT_STATS ON " + website_my_pageurl.TableName + "." + website_my_pageurl._PAGEURL + "=DATABASE_SQL_CONNECT_STATS.PAGEURL AND STATS_DATE = '" + this.P_Today + "'";
            website_my_pageurl.SelectColumns = new string[] { 
                "" + website_my_pageurl.TableName + "." + website_my_pageurl._PAGEURL, 
                "MAX(" + website_my_pageurl.TableName  + "." + website_my_pageurl._QUERYSTRING_PHONE_ENCRYPT+") AS " + website_my_pageurl._QUERYSTRING_PHONE_ENCRYPT+"", 
                "MAX(" + website_my_pageurl.TableName  + "." + website_my_pageurl._FORM_PHONE_ENCRYPT+") AS " + website_my_pageurl._FORM_PHONE_ENCRYPT+"", 
                "MAX(" + website_my_pageurl.TableName  + "." + website_my_pageurl._FORM+") AS " + website_my_pageurl._FORM+"", 
                "MAX(" + website_my_pageurl.TableName  + "." + website_my_pageurl._QUERYSTRING+") AS " + website_my_pageurl._QUERYSTRING+"", 
                "request_count",
                "connect_times_min",
                "connect_times_max",
                "connect_times_avg",
                "duration_min",
                "duration_max",
                "duration_avg",
                "lastconnecttime"
            };
            website_my_pageurl.GroupBy = "" + website_my_pageurl.TableName + ".pageurl,request_count,connect_times_min,connect_times_max,connect_times_avg,duration_min,duration_max,duration_avg,lastconnecttime";
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            //--------------------------------------------------------- 
            oDt_website_my_pageurl.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn("IsMy", typeof(int)));

            foreach (DataRow oDr_website_my_pageurl in oDt_website_my_pageurl.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl._PAGEURL + "='" + oDr_website_my_pageurl[website_my_pageurl._PAGEURL].ToString() + "'");
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
                    oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_website_my_pageurl["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_website_my_pageurl["IsMy"] = IsMy;
                }
            }

            this.get_Error(oDt_website_my_pageurl);
            //Web.Manager.Welcome.get_Depend(oDt_website_my_pageurl);//外部依赖
            //--------------------------------------------------------------
            DataView oDv = oDt_website_my_pageurl.DefaultView;
            oDv.Sort = this.P_orderby + " DESC";

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

        public void get_Error(DataTable dt_Connect_Log_Stats)
        {
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("Content", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("Error_CreateTime", typeof(DateTime)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("Title", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("IP", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("username", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("classname", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("MethodName", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("loglevel", typeof(int)));

            Entity.TEAMTOOL.LOG_STATS log_stats_today_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_today_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            log_stats_today_all.CacheTime = 10;
            DataTable dt_log_stats_today_all = log_stats_today_all.Select();

            Entity.TEAMTOOL.LOG_STATS log_stats_yestoday_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_yestoday_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
            log_stats_yestoday_all.CacheTime = 10;
            DataTable dt_log_stats_yestoday_all = log_stats_yestoday_all.Select();

            foreach (DataRow oDr_Connect_Log_Stats in dt_Connect_Log_Stats.Rows)
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
