using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Connect_log_Stats : Business.ManageWeb
    {
        private string P_Today = "";
        private string P_Keyword = "";
        public string P_OrderBy = "";
        public string P_TeamName = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Connect_log_Stats.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "connectionstring_today_min";
            }
            if (!Page.IsPostBack)
            {
                this.P_Today = this.QueryString("today");
                this.P_Keyword = this.QueryString("keyword");
                this.P_TeamName = this.QueryString("teamname");
               
                if (string.IsNullOrEmpty(this.P_Today))
                {
                    this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                this.txtToday.Text = this.P_Today;
                this.txtKeyword.Text = this.P_Keyword;

                Entity.TEAMTOOL.ADMIN_PRODUCT admin_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                admin_product.CacheTime = 120;
                DataTable oDt=admin_product.Select();
                this.ddl_TeamName.DataTextField = admin_product._PRODUCTNAME;
                this.ddl_TeamName.DataValueField = admin_product._PRODUCTNAME;
                this.ddl_TeamName.DataSource = oDt;
                this.ddl_TeamName.DataBind();
                this.ddl_TeamName.Items.Add(new ListItem("-请选择-", ""));
                this.ddl_TeamName.SelectedValue = this.P_TeamName;

                if(!string.IsNullOrEmpty(this.P_TeamName))
                {
                    this.ddl_TeamName.SelectedValue = this.P_TeamName;
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            string Sql = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + this.txtToday.Text + "','2000' ,'','connectionstring_channelsales_read_today_min'";
            string cacheName = Com.Common.EncDec.PasswordEncrypto(Sql);
            DataTable dt_Connect_Log_Stats = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName, 20);
            if (dt_Connect_Log_Stats == null)
            {
                Entity.TEAMTOOL.DATABASE_CONNECT_LOG_STATS dataBase_connect_log_stats = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG_STATS();
                dt_Connect_Log_Stats = dataBase_connect_log_stats.Database_Owner.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
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
                        pageurl_regex=pageurl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
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
                //Web.Manager.Welcome.get_Depend(dt_Connect_Log_Stats);//外部依赖
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName, dt_Connect_Log_Stats, 20);

            }
            //--------------------------------------------------------
            string PageUrl = "xxxx";
            foreach (DataRow oDr in dt_Connect_Log_Stats.Rows)
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
            dt_Connect_Log_Stats.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_Connect_Log_Stats.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
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
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }
            }
            string RowFilter = website_my_pageurl._PAGEURL+" LIKE '%"+this.txtKeyword.Text+"%'";
            if (!string.IsNullOrEmpty(this.ddl_TeamName.SelectedValue))
            {
                RowFilter += " and teamname='"+this.ddl_TeamName.SelectedValue+"' ";
            }
            DataView dv_Connect_Log_Stats = dt_Connect_Log_Stats.DefaultView;
            dv_Connect_Log_Stats.Sort = this.P_OrderBy + " DESC";
            dv_Connect_Log_Stats.RowFilter = RowFilter;

            this.LogCount = dv_Connect_Log_Stats.Count;
            this.rptLog.DataSource = dv_Connect_Log_Stats;
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
                if (System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.txtToday.Text).ToShortDateString())
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }         
    }
}
