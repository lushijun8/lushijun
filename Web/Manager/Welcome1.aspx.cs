using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Web.Manager
{
    public partial class Welcome1 : Business.ManageWeb
    {
        public string today = System.DateTime.Now.ToString("yyyy-MM-dd");
        public string ConnectString_Date_min = "";
        public string ConnectString_Date_max = "";
        private string CurrentWebManagerName_v = "";
        private string P_CurrentWebManagerProductName = "";
        public DataTable oDt_database_table = null;
        int CacheTime = 30;
        private int Top = 50;
        public int BadSql_Rank = -1;
        public int BadSql_Rank_My = -1;
        public int Worker_Time_Rank = -1;
        public int Worker_Time_Rank_My = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentWebManagerName_v = this.QueryString("WebManager_Name");
            if (string.IsNullOrEmpty(this.CurrentWebManagerName_v))
            {
                this.AdminCheck("Manager/Welcome.aspx");
                this.CurrentWebManagerName_v = this.CurrentWebManagerName;
                this.P_CurrentWebManagerProductName = this.CurrentWebManagerProductName;
            }
            else
            {
                this.Top = 6;
                #region 模拟登录
                string strError = "";
                this.CheckIn(this.CurrentWebManagerName_v, out strError);
                this.AdminCheck("Manager/Welcome.aspx");
                string cacheName = "CurrentWebManagerProductName_" + this.CurrentWebManagerName_v;
                if (Cache[cacheName] != null)
                {
                    try
                    {
                        this.P_CurrentWebManagerProductName = (string)Cache[cacheName];
                    }
                    catch (Exception ex)
                    {
                        Business.HandleException.LogException(ex);
                    }
                }
                else
                {
                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    admin_webmanager.WEBMANAGER_NAME = this.CurrentWebManagerName_v;
                    admin_webmanager.CacheTime = 5;
                    admin_webmanager.SelectTop1();
                    //============================================
                    Entity.TEAMTOOL.ADMIN_PRODUCT admin_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                    admin_product.CacheTime = 120;
                    admin_product.Split_Or_And = true;
                    admin_product[admin_product._PRODUCTID] = admin_webmanager.WEBMANAGER_PRODUCT;
                    if (admin_product.Select() != null)
                    {
                        while (admin_product.Next())
                        {
                            this.P_CurrentWebManagerProductName += admin_product.PRODUCTNAME + "|";
                        }
                        Cache.Add(cacheName, this.P_CurrentWebManagerProductName.TrimEnd('|'), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                    }
                }
                #endregion
            }
            this.BindData();
        }
        private void BindData()
        {
            #region 疑似我的SQL书写规范排名
            DataView oDv_BadSql_Rank = Sql.DataBase_BadSql_Rank.Get_BadSql_Rank(System.DateTime.Now.AddDays(-7).ToShortDateString(), System.DateTime.Now.ToShortDateString());
            DataTable oDt_database_sql_stats_sum_0 = null;
            oDv_BadSql_Rank.Sort = "BadRate ASC";
            for (int i = 0; i < oDv_BadSql_Rank.Count; i++)
            {
                if (oDv_BadSql_Rank[i]["SEEMLIKE_WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.BadSql_Rank = i + 1;
                    oDt_database_sql_stats_sum_0 = oDv_BadSql_Rank.Table.Clone();
                    DataRow oDr_New = oDt_database_sql_stats_sum_0.NewRow();
                    oDr_New.ItemArray = oDv_BadSql_Rank[i].Row.ItemArray;
                    oDt_database_sql_stats_sum_0.Rows.Add(oDr_New);
                    break;
                }
            }
            oDv_BadSql_Rank.Sort = "Worker_Time ASC";
            for (int i = 0; i < oDv_BadSql_Rank.Count; i++)
            {
                if (oDv_BadSql_Rank[i]["SEEMLIKE_WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.Worker_Time_Rank = i + 1;
                    break;
                }
            }

            if (oDt_database_sql_stats_sum_0 != null)
            {
                this.rpt_database_sql_stats_sum_0.DataSource = oDt_database_sql_stats_sum_0;
                this.rpt_database_sql_stats_sum_0.DataBind();
            }
            #endregion

            #region 我认领的SQL书写规范排名
            DataView oDv_BadSql_Rank_My = Sql.DataBase_BadSql_Rank_My.Get_BadSql_Rank_My();
            DataTable oDt_database_sql_stats_sum_1 = null;
            oDv_BadSql_Rank_My.Sort = "BadRate ASC";
            for (int i = 0; i < oDv_BadSql_Rank_My.Count; i++)
            {
                if (oDv_BadSql_Rank_My[i]["WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.BadSql_Rank_My = i + 1;
                    oDt_database_sql_stats_sum_1 = oDv_BadSql_Rank_My.Table.Clone();
                    DataRow oDr_New = oDt_database_sql_stats_sum_1.NewRow();
                    oDr_New.ItemArray = oDv_BadSql_Rank_My[i].Row.ItemArray;
                    oDt_database_sql_stats_sum_1.Rows.Add(oDr_New);
                    break;
                }
            }

            oDv_BadSql_Rank_My.Sort = "Worker_Time ASC";
            for (int i = 0; i < oDv_BadSql_Rank_My.Count; i++)
            {
                if (oDv_BadSql_Rank_My[i]["WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.Worker_Time_Rank_My = i + 1;
                    break;
                }
            }

            if (oDt_database_sql_stats_sum_1 != null)
            {
                this.rpt_database_sql_stats_sum_1.DataSource = oDt_database_sql_stats_sum_1;
                this.rpt_database_sql_stats_sum_1.DataBind();
            }
            #endregion

            #region 绑定服务器和数据库列表,统计近一周数据增长最快的表
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_ID, database_owner._DATABASE_IP_LOCAL, database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_VIP_LOCAL, database_owner._DATABASE_VIP_ROMOTE, database_owner._DATABASE_IP_SPECIAL, database_owner._DATABASE_NAME, database_owner._DATABASE_REMARK, database_owner._DATABASE_ADMIN_USER, database_owner._DATABASE_ADMIN_PASSWORD, database_owner._DATABASE_READER_USER, database_owner._DATABASE_READER_PASSWORD, database_owner._DATABASE_WRITER_USER, database_owner._DATABASE_WRITER_PASSWORD };
            database_owner.OrderBy = database_owner._DATABASE_NAME + " ASC";
            database_owner.CacheTime = 1440;
            DataTable dt_database_owner = database_owner.Select(10);
            this.rptDataBase.DataSource = dt_database_owner;
            this.rptDataBase.DataBind();
            //-------------------------------------------
            Entity.TEAMTOOL.DATABASE_CONNECTSTRING database_connectstring = new Entity.TEAMTOOL.DATABASE_CONNECTSTRING();
            database_connectstring.OrderBy = database_connectstring._DATABASE_CONNECT_TIMES + " DESC";
            database_connectstring.CacheTime = 20;
            DataTable dt_database_connectstring = database_connectstring.Select(10);
            dt_database_connectstring.Columns.Add(new DataColumn(database_owner._DATABASE_ID, typeof(int)));
            foreach (DataRow oDr_database_connectstring in dt_database_connectstring.Rows)
            {
                DataRow[] oDrs_database_owner = dt_database_owner.Select(database_connectstring._DATABASE_IP_ROMOTE + "='" + oDr_database_connectstring[database_connectstring._DATABASE_IP_ROMOTE].ToString().Split('/')[0] + "' and " + database_connectstring._DATABASE_NAME + "='" + oDr_database_connectstring[database_connectstring._DATABASE_NAME].ToString() + "'");
                if (oDrs_database_owner != null && oDrs_database_owner.Length > 0)
                {
                    oDr_database_connectstring[database_owner._DATABASE_ID] = oDrs_database_owner[0][database_owner._DATABASE_ID].ToString();
                }
            }
            dt_database_connectstring.AcceptChanges();
            this.rptConnectstring.DataSource = dt_database_connectstring;
            this.rptConnectstring.DataBind();
            //-------------------------------------------
            Entity.TEAMTOOL.DATABASE_CONNECT_LOG database_connect_log_min_date = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG();
            database_connect_log_min_date.SelectColumns = new string[] { "min(" + database_connect_log_min_date._CONNECTIME + ") AS " + database_connect_log_min_date._CONNECTIME };
            database_connect_log_min_date.CacheTime = 15;
            database_connect_log_min_date.SelectTop1();
            this.ConnectString_Date_min = database_connect_log_min_date.CONNECTIME_ToString;

            Entity.TEAMTOOL.DATABASE_CONNECT_LOG database_connect_log_max_date = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG();
            database_connect_log_max_date.SelectColumns = new string[] { "max(" + database_connect_log_max_date._CONNECTIME + ") AS " + database_connect_log_max_date._CONNECTIME };
            database_connect_log_max_date.CacheTime = 15;
            database_connect_log_max_date.SelectTop1();
            this.ConnectString_Date_max = database_connect_log_max_date.CONNECTIME_ToString;
            //-------------------------------------------
            Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
            server_update_log.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            server_update_log.SelectColumns = new string[] { "SERVER_UPDATE_LOG.*", "WebManager_RealName" };
            server_update_log.OrderBy = server_update_log.TableName + "." + server_update_log._ID + " DESC";
            DataTable dt_server_update_log = server_update_log.Select(5);
            this.rptServerUpdateLog.DataSource = dt_server_update_log;
            this.rptServerUpdateLog.DataBind();
            //-------------------------------------------

            Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
            server_update_password.LEFT_JOIN_ADMIN_WEBMANAGER_CREATE_USERNAME = true;
            server_update_password.SelectColumns = new string[] { "SERVER_UPDATE_PASSWORD.*", "WebManager_RealName" };
            server_update_password.OrderBy = server_update_password.TableName + "." + server_update_password._ID + " DESC";
            DataTable dt_server_update_password = server_update_password.Select(5);
            this.rptServerUpdatePassword.DataSource = dt_server_update_password;
            this.rptServerUpdatePassword.DataBind();

            //================================统计近一周数据增长最快的表================================
            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.SelectColumns = new string[] { database_table._DATABASE_IP_ROMOTE, database_table._DATABASE_NAME };
            database_table.COUNTDATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
            database_table.WhereSql = database_table._DATABASE_NAME + @" IN(select " + database_table._DATABASE_NAME + @" from ( 
                                     select top 50 DATABASE_NAME,AVG(RowCounts_Increasing_Week_Rate) as avg_RowCounts_Increasing_Week_Rate from database_table where CountDate='" + System.DateTime.Now.AddDays(-1).ToShortDateString() + @"' 
                                     group by DATABASE_NAME
                                     order by avg_RowCounts_Increasing_Week_Rate desc
                                     ) as a)";
            database_table.Distinct = true;
            database_table.CacheTime = 1440;
            oDt_database_table = database_table.Select(5);
            this.rpt_DataBase_Table_week_th.DataSource = oDt_database_table;
            this.rpt_DataBase_Table_week_th.DataBind();
            this.rpt_DataBase_Table_week_td.DataSource = oDt_database_table;
            this.rpt_DataBase_Table_week_td.DataBind();

            this.rpt_DataBase_Table_month_th.DataSource = oDt_database_table;
            this.rpt_DataBase_Table_month_th.DataBind();
            this.rpt_DataBase_Table_month_td.DataSource = oDt_database_table;
            this.rpt_DataBase_Table_month_td.DataBind();

            #endregion

            //----------------------------------------------------------
            string CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_0";
            DataTable oDt_website_my_pageurl = null;
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl = (DataTable)Cache[CacheName];
            }
            else
            {
                //Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
                website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
                website_my_pageurl.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
                oDt_website_my_pageurl = website_my_pageurl.Select();
                this.get_Error(oDt_website_my_pageurl);//匹配报错信息
                get_Depend(oDt_website_my_pageurl);//外部依赖
                Cache.Add(CacheName, oDt_website_my_pageurl.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            //-------------------------------------------------------
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_1";
            DataTable oDt_website_my_pageurl_ignore = null;
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl_ignore = (DataTable)Cache[CacheName];
            }
            else
            {
                //Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
                oDt_website_my_pageurl_ignore = website_my_pageurl_ignore.Select();
                this.get_Error(oDt_website_my_pageurl_ignore);//匹配报错信息
                get_Depend(oDt_website_my_pageurl_ignore);//外部依赖
                Cache.Add(CacheName, oDt_website_my_pageurl_ignore.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            #region 统计报错最多的页面
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_2";
            DataTable dt_log_stats_today_new = null;
            if (Cache[CacheName] != null)
            {
                dt_log_stats_today_new = (DataTable)Cache[CacheName];
            }
            else
            {
                Entity.TEAMTOOL.LOG_STATS log_stats_today = new Entity.TEAMTOOL.LOG_STATS();
                log_stats_today.OrderBy = log_stats_today._LOG_COUNT + " desc";
                log_stats_today.LOG_TYPE = 0;
                log_stats_today.LOG_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                log_stats_today.CacheTime = 5;
                DataTable dt_log_stats_today = log_stats_today.Select(this.Top);
                dt_log_stats_today_new = dt_log_stats_today.Clone();
                dt_log_stats_today_new = this.isMy(dt_log_stats_today, oDt_website_my_pageurl);
                get_Depend(dt_log_stats_today_new);//外部依赖
                Cache.Add(CacheName, dt_log_stats_today_new.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            this.rpt_log_error_today.DataSource = dt_log_stats_today_new;
            this.rpt_log_error_today.DataBind();
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_3";
            DataTable dt_log_stats_yestoday_new = null;
            if (Cache[CacheName] != null)
            {
                dt_log_stats_yestoday_new = (DataTable)Cache[CacheName];
            }
            else
            {


                //==============================================================
                Entity.TEAMTOOL.LOG_STATS log_stats_yestoday = new Entity.TEAMTOOL.LOG_STATS();
                log_stats_yestoday.OrderBy = log_stats_yestoday._LOG_COUNT + " desc";
                log_stats_yestoday.LOG_TYPE = 0;
                log_stats_yestoday.LOG_DATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
                log_stats_yestoday.CacheTime = 5;
                DataTable dt_log_stats_yestoday = log_stats_yestoday.Select(this.Top);
                dt_log_stats_yestoday_new = dt_log_stats_yestoday.Clone();
                dt_log_stats_yestoday_new = this.isMy(dt_log_stats_yestoday, oDt_website_my_pageurl);
                get_Depend(dt_log_stats_yestoday_new);//外部依赖
                Cache.Add(CacheName, dt_log_stats_yestoday_new.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);

            }
            this.rpt_log_error_yestoday.DataSource = dt_log_stats_yestoday_new;
            this.rpt_log_error_yestoday.DataBind();

            #endregion

            #region 获取pageurl统计数据和已认领数据
            //---------------------------------------------------------
            string Sql_today = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + System.DateTime.Now.ToShortDateString() + "','5000' ,'','connectionstring_today_min'";
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_4";
            DataTable dt_Connect_Log_Stats_today = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, CacheName, this.CacheTime);
            if (dt_Connect_Log_Stats_today == null)
            {
                dt_Connect_Log_Stats_today = server_update_log.Database_Owner.ExecuteDataSet(CommandType.Text, Sql_today).Tables[0];
                this.get_Error(dt_Connect_Log_Stats_today);//匹配报错信息
                get_Depend(dt_Connect_Log_Stats_today);//外部依赖
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, CacheName, dt_Connect_Log_Stats_today, this.CacheTime);
            }
            //---------------------------------------------------------
            string Sql_yestoday = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + System.DateTime.Now.AddDays(-1).ToShortDateString() + "','5000' ,'','connectionstring_today_min'";
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_5";
            DataTable dt_Connect_Log_Stats_yestoday = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, CacheName, this.CacheTime);
            if (dt_Connect_Log_Stats_yestoday == null)
            {
                dt_Connect_Log_Stats_yestoday = server_update_log.Database_Owner.ExecuteDataSet(CommandType.Text, Sql_yestoday).Tables[0];
                this.get_Error(dt_Connect_Log_Stats_yestoday);//匹配报错信息
                get_Depend(dt_Connect_Log_Stats_yestoday);//外部依赖
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, CacheName, dt_Connect_Log_Stats_yestoday, this.CacheTime);
            }
            #endregion

            #region 绑定我认领的页面列表
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_6";
            DataTable oDt_website_my_pageurl_my = null;
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl_my = (DataTable)Cache[CacheName];
            }
            else
            {
                DataRow[] oDrs_website_my_pageurl_my = oDt_website_my_pageurl.Select("WEBMANAGER_NAME='" + this.CurrentWebManagerName_v + "'");
                oDt_website_my_pageurl_my = oDt_website_my_pageurl.Clone();
                foreach (DataRow oDr in oDrs_website_my_pageurl_my)
                {
                    DataRow oNewRow = oDt_website_my_pageurl_my.NewRow();
                    oNewRow.ItemArray = oDr.ItemArray;
                    oDt_website_my_pageurl_my.Rows.Add(oNewRow);
                }

                //--------------------------------------------------------- 
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("request_count", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connect_times_min", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connect_times_max", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connect_times_avg", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("duration_min", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("duration_max", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("duration_avg", typeof(int)));
                oDt_website_my_pageurl_my.Columns.Add(new DataColumn("lastconnecttime", typeof(DateTime)));

                //oDt_website_my_pageurl_my.Columns.Add(new DataColumn("request_count_today", typeof(int)));
                //oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_today_min", typeof(int)));
                //oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_yestoday_min", typeof(int)));
                //oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_today_max", typeof(int)));
                //oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_yestoday_max", typeof(int)));

                foreach (DataRow oDr_website_my_pageurl_my in oDt_website_my_pageurl_my.Rows)
                {
                    DataRow[] oDr_Connect_Log_Stats = dt_Connect_Log_Stats_today.Select(website_my_pageurl._PAGEURL + "='" + oDr_website_my_pageurl_my[website_my_pageurl._PAGEURL].ToString() + "'");
                    if (oDr_Connect_Log_Stats != null && oDr_Connect_Log_Stats.Length > 0)
                    {
                        oDr_website_my_pageurl_my["request_count_today"] = oDr_Connect_Log_Stats[0]["request_count_today"].ToString();
                        oDr_website_my_pageurl_my["connectionstring_today_min"] = oDr_Connect_Log_Stats[0]["connectionstring_today_min"].ToString();
                        oDr_website_my_pageurl_my["connectionstring_yestoday_min"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_min"].ToString();
                        oDr_website_my_pageurl_my["connectionstring_today_max"] = oDr_Connect_Log_Stats[0]["connectionstring_today_max"].ToString();
                        oDr_website_my_pageurl_my["connectionstring_yestoday_max"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_max"].ToString();
                    }
                    DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_website_my_pageurl_my[website_my_pageurl._PAGEURL].ToString() + "'");
                    if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                    {
                        string WebManager_Name = "";
                        foreach (DataRow oDr in oDrs_website_my_pageurl)
                        {
                            WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        }
                        oDr_website_my_pageurl_my[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    }
                }
                Cache.Add(CacheName, oDt_website_my_pageurl_my.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }


            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_7";
            DataTable oDt_website_my_pageurl_my_sort = null;
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl_my_sort = (DataTable)Cache[CacheName];
            }
            else
            {
                int k = 0;
                oDt_website_my_pageurl_my_sort = oDt_website_my_pageurl_my.Clone();
                DataView oDv_website_my_pageurl_my = oDt_website_my_pageurl_my.DefaultView;
                oDv_website_my_pageurl_my.Sort = "connectionstring_today_min DESC";
                foreach (DataRowView oDv in oDv_website_my_pageurl_my)
                {
                    DataRow oNewRow = oDt_website_my_pageurl_my_sort.NewRow();
                    oNewRow.ItemArray = oDv.Row.ItemArray;
                    oDt_website_my_pageurl_my_sort.Rows.Add(oNewRow);
                    k++;
                    if (k >= this.Top)
                    {
                        break;
                    }
                }
                Cache.Add(CacheName, oDt_website_my_pageurl_my_sort.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            this.rpt_website_my_pageurl_my.DataSource = oDt_website_my_pageurl_my_sort;
            this.rpt_website_my_pageurl_my.DataBind();
            #endregion

            #region 绑定疑似我的页面列表
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_8";
            DataTable oDt_website_my_pageurl_my_like = null;
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl_my_like = (DataTable)Cache[CacheName];
            }
            else
            {
                oDt_website_my_pageurl_my_like = dt_Connect_Log_Stats_today.Clone();
                oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_today, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 0);
                oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_yestoday, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 0);
                oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_today, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 1);
                oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_yestoday, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 1);

                //过滤掉已经忽略的
                for (int i = oDt_website_my_pageurl_my_like.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow oDr_website_my_pageurl_my_like = oDt_website_my_pageurl_my_like.Rows[i];
                    DataRow[] oDrs_website_my_pageurl_ignore = oDt_website_my_pageurl_ignore.Select(website_my_pageurl_ignore._PAGEURL + "='" + oDr_website_my_pageurl_my_like[website_my_pageurl_ignore._PAGEURL].ToString() + "'");
                    if (oDrs_website_my_pageurl_ignore != null && oDrs_website_my_pageurl_ignore.Length > 0)
                    {
                        oDt_website_my_pageurl_my_like.Rows[i].Delete();
                    }
                }
                oDt_website_my_pageurl_my_like.AcceptChanges();
                Cache.Add(CacheName, oDt_website_my_pageurl_my_like.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_9";
            DataTable oDt_website_my_pageurl_my_like_sort = null;
            if (Cache[CacheName] != null)
            {
                oDt_website_my_pageurl_my_like_sort = (DataTable)Cache[CacheName];
            }
            else
            {
                DataView oDv_website_my_pageurl_my_like = oDt_website_my_pageurl_my_like.DefaultView;
                oDv_website_my_pageurl_my_like.Sort = "connectionstring_today_min DESC";
                oDt_website_my_pageurl_my_like_sort = oDt_website_my_pageurl_my_like.Clone();
                //删除掉多余的
                int k = 0;
                foreach (DataRowView oDv in oDv_website_my_pageurl_my_like)
                {
                    DataRow oNewRow = oDt_website_my_pageurl_my_like_sort.NewRow();
                    oNewRow.ItemArray = oDv.Row.ItemArray;
                    oDt_website_my_pageurl_my_like_sort.Rows.Add(oNewRow);
                    k++;
                    if (k >= this.Top)
                    {
                        break;
                    }
                }
                Cache.Add(CacheName, oDt_website_my_pageurl_my_like_sort.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            this.rpt_website_my_pageurl_my_like.DataSource = oDt_website_my_pageurl_my_like_sort;
            this.rpt_website_my_pageurl_my_like.DataBind();
            #endregion

            string RowFilter = "";
            string RowFilter_anti = "";
            if (!string.IsNullOrEmpty(this.P_CurrentWebManagerProductName))
            {
                string[] Products = this.P_CurrentWebManagerProductName.Split('|');
                int i = 0;
                foreach (string Product in Products)
                {
                    if (i == 0)
                    {
                        RowFilter += " teamname='" + Product + "' ";
                        RowFilter_anti += " teamname<>'" + Product + "' ";
                    }
                    else
                    {
                        RowFilter += " or teamname='" + Product + "' ";
                        RowFilter_anti += " and teamname<>'" + Product + "' ";
                    }
                    i++;
                }

            }

            #region 绑定性能最差列表


            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_10";
            DataTable dt_connectionstring_today = null;
            if (Cache[CacheName] != null)
            {
                dt_connectionstring_today = (DataTable)Cache[CacheName];
            }
            else
            {
                dt_connectionstring_today = dt_Connect_Log_Stats_today.Clone();
                dt_connectionstring_today = this.getTop(this.Top, dt_connectionstring_today, dt_Connect_Log_Stats_today, RowFilter, "connectionstring_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_connectionstring_today = this.getTop(this.Top, dt_connectionstring_today, dt_Connect_Log_Stats_today, RowFilter_anti, "connectionstring_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_connectionstring_today = this.isMy(dt_connectionstring_today, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_connectionstring_today.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_11";
            DataTable dt_connectionstring_yestoday = null;
            if (Cache[CacheName] != null)
            {
                dt_connectionstring_yestoday = (DataTable)Cache[CacheName];
            }
            else
            {
                dt_connectionstring_yestoday = dt_Connect_Log_Stats_yestoday.Clone();
                dt_connectionstring_yestoday = this.getTop(this.Top, dt_connectionstring_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter, "connectionstring_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_connectionstring_yestoday = this.getTop(this.Top, dt_connectionstring_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter_anti, "connectionstring_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_connectionstring_yestoday = this.isMy(dt_connectionstring_yestoday, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_connectionstring_yestoday.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_12";
            DataTable dt_duration_today = null;
            if (Cache[CacheName] != null)
            {
                dt_duration_today = (DataTable)Cache[CacheName];
            }
            else
            {
                dt_duration_today = dt_Connect_Log_Stats_today.Clone();
                dt_duration_today = this.getTop(this.Top, dt_duration_today, dt_Connect_Log_Stats_today, RowFilter, "duration_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_duration_today = this.getTop(this.Top, dt_duration_today, dt_Connect_Log_Stats_today, RowFilter_anti, "duration_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_duration_today = this.isMy(dt_duration_today, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_duration_today.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_13";
            DataTable dt_duration_yestoday = null;
            if (Cache[CacheName] != null)
            {
                dt_duration_yestoday = (DataTable)Cache[CacheName];
            }
            else
            {
                dt_duration_yestoday = dt_Connect_Log_Stats_yestoday.Clone();
                dt_duration_yestoday = this.getTop(this.Top, dt_duration_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter, "duration_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);

                dt_duration_yestoday = this.getTop(this.Top, dt_duration_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter_anti, "duration_today_min DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_duration_yestoday = this.isMy(dt_duration_yestoday, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_duration_yestoday.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }


            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_14";
            DataTable dt_request_count_today = null;
            if (Cache[CacheName] != null)
            {
                dt_request_count_today = (DataTable)Cache[CacheName];
            }
            else
            {

                dt_request_count_today = dt_Connect_Log_Stats_today.Clone();
                dt_request_count_today = this.getTop(this.Top, dt_request_count_today, dt_Connect_Log_Stats_today, RowFilter, "request_count_today DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_request_count_today = this.getTop(this.Top, dt_request_count_today, dt_Connect_Log_Stats_today, RowFilter_anti, "request_count_today DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_request_count_today = this.isMy(dt_request_count_today, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_request_count_today.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_15";
            DataTable dt_request_count_yestoday = null;
            if (Cache[CacheName] != null)
            {
                dt_request_count_yestoday = (DataTable)Cache[CacheName];
            }
            else
            {
                dt_request_count_yestoday = dt_Connect_Log_Stats_yestoday.Clone();
                dt_request_count_yestoday = this.getTop(this.Top, dt_request_count_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter, "request_count_today DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_request_count_yestoday = this.getTop(this.Top, dt_request_count_yestoday, dt_Connect_Log_Stats_yestoday, RowFilter_anti, "request_count_today DESC", oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like);
                dt_request_count_yestoday = this.isMy(dt_request_count_yestoday, oDt_website_my_pageurl);
                Cache.Add(CacheName, dt_request_count_yestoday.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            //---------------------------------------------------------- 
            this.rpt_connectionstring_today.DataSource = dt_connectionstring_today;
            this.rpt_connectionstring_today.DataBind();

            this.rpt_connectionstring_yestoday.DataSource = dt_connectionstring_yestoday;
            this.rpt_connectionstring_yestoday.DataBind();

            this.rpt_duration_today.DataSource = dt_duration_today;
            this.rpt_duration_today.DataBind();

            this.rpt_duration_yestoday.DataSource = dt_duration_yestoday;
            this.rpt_duration_yestoday.DataBind();


            this.rpt_request_count_today.DataSource = dt_request_count_today;
            this.rpt_request_count_today.DataBind();

            this.rpt_request_count_yestoday.DataSource = dt_request_count_yestoday;
            this.rpt_request_count_yestoday.DataBind();

            if (!string.IsNullOrEmpty(this.QueryString("WebManager_Name")))
            {
                this.BindData_Stats(oDt_website_my_pageurl, dt_Connect_Log_Stats_today);
            }
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
        public static void get_Depend(DataTable dt_Connect_Log_Stats)
        {
            dt_Connect_Log_Stats.Columns.Add(new DataColumn("Depend_PageUrl", typeof(string)));

            Entity.TEAMTOOL.WEBSITE_DEPEND database_missing_index = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            database_missing_index.SelectColumns = new string[] 
            { 
                database_missing_index._PAGEURL, 
                database_missing_index._DEPEND_PAGEURL,
                database_missing_index._DEPEND_PAGEURL_DETAIL, 
                database_missing_index._DEPEND_CONTENTTYPE, 
                database_missing_index._DEPEND_CONTENTLENGTH, 
                database_missing_index._DEPEND_COUNT, 
                database_missing_index._DEPEND_TIMESPAN_SUM, 
                database_missing_index._DEPEND_TIMESPAN_MAX, 
                database_missing_index._DEPEND_TIMESPAN_MIN, 
                database_missing_index._DEPEND_TIMESPAN_NEW, 
                database_missing_index._DEPEND_TIMESPAN_AVERAGE, 
                database_missing_index._DEPEND_CREATETIME 
            };
            database_missing_index.STATS_DATE = DateTime.Parse(DateTime.Now.AddHours(-12).ToShortDateString());//12小时前de那天的
            database_missing_index.CacheTime = 60;
            DataTable dt_database_missing_index = database_missing_index.Select();
            foreach (DataRow oDr_Connect_Log_Stats in dt_Connect_Log_Stats.Rows)
            {
                string pageurl = oDr_Connect_Log_Stats[database_missing_index._PAGEURL].ToString();
                string CacheName = "depend_" + Com.Common.EncDec.PasswordEncrypto(pageurl.ToLower());
                string Depend_PageUrl = "";
                if (System.Web.HttpContext.Current.Cache[CacheName] != null)
                {
                    Depend_PageUrl = (string)System.Web.HttpContext.Current.Cache[CacheName];
                }
                else
                {
                    DataRow[] oDrs_database_missing_index = dt_database_missing_index.Select(database_missing_index._PAGEURL + "='" + pageurl + "'");
                    if (oDrs_database_missing_index != null && oDrs_database_missing_index.Length > 0)
                    {
                        Depend_PageUrl = "<p>此页面调用的外部URL如下：<p/>";
                        int i = 0;
                        foreach (DataRow oDr_database_missing_index in oDrs_database_missing_index)
                        {
                            i++;
                            Depend_PageUrl += i.ToString() + "、<font color=red>" + oDr_database_missing_index[database_missing_index._DEPEND_PAGEURL].ToString();
                            if (oDr_database_missing_index[database_missing_index._DEPEND_PAGEURL_DETAIL].ToString().IndexOf("?") > -1)//有参数
                            {
                                Depend_PageUrl += "?";
                                string[] parameters = oDr_database_missing_index[database_missing_index._DEPEND_PAGEURL_DETAIL].ToString().Split('?')[1].Split('&');
                                foreach (string parameter in parameters)
                                {
                                    Depend_PageUrl += parameter.Split('=')[0] + "=*&";
                                }
                            }
                            Depend_PageUrl = Depend_PageUrl.TrimEnd('&');
                            Depend_PageUrl += "</font><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ContentType:" + oDr_database_missing_index[database_missing_index._DEPEND_CONTENTTYPE].ToString() +
                                "],[ContentLength:" + oDr_database_missing_index[database_missing_index._DEPEND_CONTENTLENGTH].ToString() +
                                "]<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[共调用" + oDr_database_missing_index[database_missing_index._DEPEND_COUNT].ToString() +
                                "次]<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[耗时:" + (Convert.ToDecimal(oDr_database_missing_index[database_missing_index._DEPEND_TIMESPAN_MIN].ToString()) / 1000).ToString("f2").Replace(".00", "") +
                                "~" + (Convert.ToDecimal(oDr_database_missing_index[database_missing_index._DEPEND_TIMESPAN_MAX].ToString()) / 1000).ToString("f2").Replace(".00", "") + "秒,平均" +
                                (Convert.ToDecimal(oDr_database_missing_index[database_missing_index._DEPEND_TIMESPAN_AVERAGE].ToString()) / 1000).ToString("f2").Replace(".00", "") + "秒],[最后调用时间：" +
                                oDr_database_missing_index[database_missing_index._DEPEND_CREATETIME].ToString() + ",时长" +
                                (Convert.ToDecimal(oDr_database_missing_index[database_missing_index._DEPEND_TIMESPAN_NEW].ToString()) / 1000).ToString("f2").Replace(".00", "") + "秒]<br/><br/>";
                        }
                    }
                    System.Web.HttpContext.Current.Cache.Add(CacheName, Depend_PageUrl, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 180 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                oDr_Connect_Log_Stats["Depend_PageUrl"] = Depend_PageUrl;
            }
        }
        public string Get_DataBase_Table_List(string Today, string DataBase_Name, string RateType, int RowCount)
        {
            string Html = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"><tr><td>表名</td><td>增长率</td></tr>";

            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.COUNTDATE = DateTime.Parse(Today);
            database_table.CacheTime = 1440;
            DataTable oDt = database_table.Select();

            DataView oDvs = oDt.DefaultView;
            oDvs.RowFilter = database_table._DATABASE_NAME + "='" + DataBase_Name + "'";
            oDvs.Sort = "ROWCOUNTS_INCREASING" + RateType + "_RATE DESC";

            int k = 0;
            foreach (DataRowView oDv in oDvs)
            {
                Html += "<tr><td><a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/Missing_Index.aspx?keyword=" + oDv.Row[database_table._TABLE_NAME].ToString() + "&Database_Name=" + DataBase_Name + "\">" + oDv.Row[database_table._TABLE_NAME].ToString() + "</a></td><td>" + decimal.Parse(oDv.Row["ROWCOUNTS_INCREASING" + RateType + "_RATE"].ToString()).ToString("f2").Replace(".00", "") + " %</td></tr>";
                k++;
                if (k >= RowCount)
                {
                    break;
                }
            }
            Html += "</table>";
            return Html;
        }
        private void BindData_Stats(DataTable oDt_website_my_pageurl, DataTable dt_Connect_Log_Stats_today)
        {
            #region 绑定列表
            string CacheName = "Welcome_" + this.CurrentWebManagerName_v + "_16";

            DataTable oDt_Connect_Log_Stats = null;
            if (Cache[CacheName] != null)
            {
                oDt_Connect_Log_Stats = (DataTable)Cache[CacheName];
            }
            else
            {
                oDt_Connect_Log_Stats = dt_Connect_Log_Stats_today.Clone();
                Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
                //---------------------------------------------------------
                oDt_Connect_Log_Stats.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
                oDt_Connect_Log_Stats.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
                oDt_Connect_Log_Stats.Columns.Add(new DataColumn("IsMy", typeof(int)));
                //过滤掉我自己的
                int k = 0;
                foreach (DataRow oDr_Connect_Log_Stats in dt_Connect_Log_Stats_today.Rows)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                    if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                    {
                        foreach (DataRow oDr in oDrs_website_my_pageurl)
                        {
                            WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                            WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                            if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName_v)
                            {
                                IsMy = 1;
                            }
                        }

                    }
                    if (IsMy == 0)
                    {
                        DataRow oNewRow = oDt_Connect_Log_Stats.NewRow();
                        oNewRow.ItemArray = oDr_Connect_Log_Stats.ItemArray;
                        oNewRow[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                        oNewRow["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                        oNewRow["IsMy"] = IsMy;

                        oDt_Connect_Log_Stats.Rows.Add(oNewRow);

                        k++;
                        if (k >= 500)
                        {
                            break;
                        }
                    }
                }
                Cache.Add(CacheName, oDt_Connect_Log_Stats.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, this.CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);

            }
            DataView dv_Connect_Log_Stats = oDt_Connect_Log_Stats.DefaultView;
            dv_Connect_Log_Stats.Sort = "connectionstring_today_min DESC";
            dv_Connect_Log_Stats.RowFilter = "WebManager_RealName=''";

            this.rptLog.DataSource = dv_Connect_Log_Stats;
            this.rptLog.DataBind();
            #endregion
        }
        private DataTable getTop(int top, DataTable dt, DataTable dt_Connect_Log_Stats, string RowFilter, string OrderBy, DataTable oDt_website_my_pageurl_my, DataTable oDt_website_my_pageurl_my_like)
        {
            DataTable dt_Result = dt.Copy();
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            DataView oDv = dt_Connect_Log_Stats.DefaultView;
            oDv.RowFilter = RowFilter;
            oDv.Sort = OrderBy;

            foreach (DataRowView oDrv in oDv)
            {
                if (dt_Result.Rows.Count >= top)
                {
                    break;
                }
                string pageurl = oDrv.Row[website_my_pageurl._PAGEURL].ToString();
                //判断是否已经在我认领的和疑似我的列表中
                DataRow[] oDrs_my = oDt_website_my_pageurl_my.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs_my != null && oDrs_my.Length > 0)
                {
                    continue;
                }
                else
                {
                    DataRow[] oDrs_my_like = oDt_website_my_pageurl_my_like.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                    if (oDrs_my_like != null && oDrs_my_like.Length > 0)
                    {
                        continue;
                    }
                }
                DataRow[] oDrs = dt_Result.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs != null && oDrs.Length > 0)
                {
                    continue;
                }
                DataRow oNewRow = dt_Result.NewRow();
                oNewRow.ItemArray = oDrv.Row.ItemArray;
                dt_Result.Rows.Add(oNewRow);
                dt_Result.AcceptChanges();
                if (dt_Result.Rows.Count >= top)
                {
                    break;
                }
            }
            return dt_Result;
        }
        private DataTable isMy(DataTable dt_Connect_Log_Stats, DataTable oDt_website_my_pageurl)
        {
            DataTable dt_Result = dt_Connect_Log_Stats.Copy();
            //for (int i = dt_Result.Rows.Count - 1; i > 0; i--)
            //{
            //    DataRow oDr_Connect_Log_Stats = dt_Result.Rows[i];
            //    if (int.Parse(oDr_Connect_Log_Stats["duration_today_min"].ToString()) <= 1)
            //    {
            //        dt_Result.Rows[i].Delete();
            //    }
            //}
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            dt_Result.AcceptChanges();
            dt_Result.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_Result.Columns.Add(new DataColumn("WEBMANAGER_REALNAME", typeof(string)));
            dt_Result.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_dt_Result in dt_Result.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_dt_Result[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName_v)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_dt_Result[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_dt_Result["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_dt_Result["IsMy"] = IsMy;
                }

            }
            return dt_Result;
        }
        private DataTable get_website_my_pageurl_like(DataTable dt_Connect_Log_Stats, DataTable oDt_website_my_pageurl, DataTable oDt_website_my_pageurl_my, DataTable oDt_website_my_pageurl_my_like, int type)
        {
            foreach (DataRow oDr_website_my_pageurl_my in oDt_website_my_pageurl_my.Rows)
            {
                string pageurl = oDr_website_my_pageurl_my["PAGEURL"].ToString();
                string pageurl_like = oDr_website_my_pageurl_my["PAGEURL_REGEX"].ToString().Replace("http://(www.)?[a-z0-9\\.]+", "");
                string[] path_names = pageurl_like.TrimStart('/').Split('/');
                if (type == 1)
                {
                    pageurl_like = "";
                    if (path_names.Length >= 2)
                    {
                        pageurl_like = "/";
                        for (int i = 0; i < path_names.Length - 1; i++)
                        {
                            pageurl_like += path_names[i] + "/";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(pageurl_like) && path_names.Length >= 2)
                {

                    //页面弱匹配
                    DataRow[] oDr_Connect_Log_Stats_today = dt_Connect_Log_Stats.Select("PAGEURL like '%" + pageurl_like + "%' and PAGEURL <> '" + pageurl + "'");
                    if (oDr_Connect_Log_Stats_today != null && oDr_Connect_Log_Stats_today.Length > 0)
                    {
                        foreach (DataRow oDr in oDr_Connect_Log_Stats_today)
                        {
                            DataRow[] oDrs = oDt_website_my_pageurl.Select("PAGEURL = '" + oDr["PAGEURL"].ToString() + "'");
                            if (oDrs == null || oDrs.Length == 0)
                            {
                                DataRow[] oDrs_like = oDt_website_my_pageurl_my_like.Select("PAGEURL = '" + oDr["PAGEURL"].ToString() + "'");
                                if (oDrs_like == null || oDrs_like.Length == 0)
                                {
                                    DataRow oNewRow = oDt_website_my_pageurl_my_like.NewRow();
                                    oNewRow.ItemArray = oDr.ItemArray;
                                    oDt_website_my_pageurl_my_like.Rows.Add(oNewRow);
                                    oDt_website_my_pageurl_my_like.AcceptChanges();
                                }
                            }
                        }
                    }
                }
            }
            return oDt_website_my_pageurl_my_like;
        }
    }
}
