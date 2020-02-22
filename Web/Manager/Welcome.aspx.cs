using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Web.Manager
{
    public partial class Welcome : Business.ManageWeb
    {
        //    public string today = System.DateTime.Now.ToString("yyyy-MM-dd");
        //    public string ConnectString_Date_min = "";
        //    public string ConnectString_Date_max = "";
        public string CurrentWebManagerName_v = "";
        //private string P_CurrentWebManagerProductName = "";
        //    public DataTable oDt_database_table = null;
        //    int CacheTime = 30;
        //    private int Top = 50;
        public int BadSql_Rank = -1;
        public int BadSql_Rank_My = -1;
        public int Worker_Time_Rank = -1;
        public int Worker_Time_Rank_My = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentWebManagerName_v = Com.Common.EncDec.Decrypt(this.QueryString("WebManager_Name"), this.Encrypt_key);
            if (string.IsNullOrEmpty(this.CurrentWebManagerName_v))
            {
                this.AdminCheck("Manager/Welcome.aspx");
                this.CurrentWebManagerName_v = this.CurrentWebManagerName;
                //this.P_CurrentWebManagerProductName = this.CurrentWebManagerProductName;
            }
            else
            {

                #region 模拟登录
                string strError = "";
                this.CheckIn(this.CurrentWebManagerName_v, out strError);
                this.AdminCheck("Manager/Welcome.aspx");
                #endregion
            }
            this.BindData();
        }
        private void BindData()
        {
            #region 绑定后台用户列表
            //if (this.CurrentIsAdmin == true)
            //{
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME, admin_webmanager._WEBMANAGER_REALNAME };
                admin_webmanager.CacheTime = 60;
                DataTable oDt_admin_webmanager = admin_webmanager.Select();
                this.rtp_Admin_Webmanager.DataSource = oDt_admin_webmanager;
                this.rtp_Admin_Webmanager.DataBind();
            //}
            #endregion
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

            if (oDt_database_sql_stats_sum_0 == null)
            {
                oDt_database_sql_stats_sum_0 = oDv_BadSql_Rank.Table.Clone();
                DataRow oDr_New = oDt_database_sql_stats_sum_0.NewRow();
                oDr_New["BadRate"] = 0;
                oDr_New["COUNTS"] = 0;
                oDt_database_sql_stats_sum_0.Rows.Add(oDr_New);
            }
            this.rpt_database_sql_stats_sum_0.DataSource = oDt_database_sql_stats_sum_0;
            this.rpt_database_sql_stats_sum_0.DataBind();
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

            if (oDt_database_sql_stats_sum_1 == null)
            {
                oDt_database_sql_stats_sum_1 = oDv_BadSql_Rank_My.Table.Clone();
                DataRow oDr_New = oDt_database_sql_stats_sum_1.NewRow();
                oDr_New["counts"] = 0;
                oDr_New["BadRate"] = 0;
                oDr_New["WORKER_TIME"] = 0;
                oDr_New["WORKER_TIME_MAX"] = 0;
                oDt_database_sql_stats_sum_1.Rows.Add(oDr_New);
            }
            this.rpt_database_sql_stats_sum_1.DataSource = oDt_database_sql_stats_sum_1;
            this.rpt_database_sql_stats_sum_1.DataBind();
            #endregion

            #region 疑似我的页面
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.SelectColumns = new string[] { "COUNT(DISTINCT " + website_my_pageurl_all._PAGEURL + ") AS ALLCOUNT" };
            website_my_pageurl_all.CacheTime = 60;
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();
            //--------------------------------------------------------
            Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl_like = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
            website_pageurl_like.SelectColumns = new string[] { "COUNT(DISTINCT " + website_pageurl_like._PAGEURL + ") AS MYCOUNT" };
            website_pageurl_like.WEBMANAGER_NAME_LIKE = "%" + this.CurrentWebManagerName_v + "%";
            website_pageurl_like.CacheTime = 60;
            DataTable oDt_website_pageurl_like = website_pageurl_like.Select();
            if (oDt_website_pageurl_like.Rows.Count > 0)
            {
                oDt_website_pageurl_like.Columns.Add(new DataColumn("ALLCOUNT", typeof(string)));
                if (oDt_website_my_pageurl_all != null && oDt_website_my_pageurl_all.Rows.Count > 0)
                {
                    oDt_website_pageurl_like.Rows[0]["ALLCOUNT"] = oDt_website_my_pageurl_all.Rows[0]["ALLCOUNT"];
                }
                DataView oDv = oDt_website_pageurl_like.DefaultView;
                this.rpt_My_PageUrl_Like.DataSource = oDv;
                this.rpt_My_PageUrl_Like.DataBind();
            }
            #endregion

            #region 我认领的页面
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl.SelectColumns = new string[] { website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME, website_pageurl_like._WEBMANAGER_REALNAME, "COUNT(1) as MYCOUNT" };
            website_my_pageurl.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME + "," + website_pageurl_like._WEBMANAGER_REALNAME + "";
            //website_my_pageurl.OrderBy = "MYCOUNT desc";
            website_my_pageurl.CacheTime = 60;
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            //---------------------------------------------------------
            Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS database_sql_connect_stats = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS();
            database_sql_connect_stats.SelectColumns = new string[]{            
	        website_my_pageurl.TableName+ "."+website_my_pageurl._WEBMANAGER_NAME,
	        "ISNULL(AVG("+database_sql_connect_stats._REQUEST_COUNT+"),0) AS "+database_sql_connect_stats._REQUEST_COUNT+"",
	        "ISNULL(AVG("+database_sql_connect_stats._DURATION_AVG+"),0) AS "+database_sql_connect_stats._DURATION_AVG+"",
	        "ISNULL(AVG("+database_sql_connect_stats._CONNECT_TIMES_AVG+"),0) AS "+database_sql_connect_stats._CONNECT_TIMES_AVG+"", 
	        "ISNULL(MAX("+database_sql_connect_stats._REQUEST_COUNT+"),0) AS "+database_sql_connect_stats._REQUEST_COUNT+"_Max",
	        "ISNULL(MAX("+database_sql_connect_stats._DURATION_AVG+"),0) AS "+database_sql_connect_stats._DURATION_AVG+"_Max",
	        "ISNULL(MAX("+database_sql_connect_stats._CONNECT_TIMES_AVG+"),0) AS "+database_sql_connect_stats._CONNECT_TIMES_AVG+"_Max"
             };
            database_sql_connect_stats.RIGHT_JOIN_WEBSITE_MY_PAGEURL = true;
            database_sql_connect_stats.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            database_sql_connect_stats.CacheTime = 60;
            DataTable oDt_database_sql_connect_stats = database_sql_connect_stats.Select();
            //---------------------------------------------------------------------
            oDt_website_my_pageurl.Columns.Add(new DataColumn("ALLCOUNT", typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._REQUEST_COUNT, typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._DURATION_AVG, typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._CONNECT_TIMES_AVG, typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._REQUEST_COUNT + "_Max", typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._DURATION_AVG + "_Max", typeof(string)));
            oDt_website_my_pageurl.Columns.Add(new DataColumn(database_sql_connect_stats._CONNECT_TIMES_AVG + "_Max", typeof(string)));

            DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'");
            if (oDrs_website_my_pageurl == null || oDrs_website_my_pageurl.Length == 0)
            {
                DataRow oDr_New = oDt_website_my_pageurl.NewRow();
                oDr_New[website_my_pageurl._WEBMANAGER_NAME] = this.CurrentWebManagerName_v;
                oDr_New["MYCOUNT"] = 0;
                oDr_New[database_sql_connect_stats._REQUEST_COUNT] = "?";
                oDr_New[database_sql_connect_stats._DURATION_AVG] = "?";
                oDr_New[database_sql_connect_stats._CONNECT_TIMES_AVG] = "?";
                oDr_New[database_sql_connect_stats._REQUEST_COUNT + "_Max"] = "?";
                oDr_New[database_sql_connect_stats._DURATION_AVG + "_Max"] = "?";
                oDr_New[database_sql_connect_stats._CONNECT_TIMES_AVG + "_Max"] = "?";
                oDt_website_my_pageurl.Rows.Add(oDr_New);

            }

            DataRow oDr_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'")[0];
            if (oDt_website_my_pageurl_all != null && oDt_website_my_pageurl_all.Rows.Count > 0)
            {
                oDr_website_my_pageurl["ALLCOUNT"] = oDt_website_my_pageurl_all.Rows[0]["ALLCOUNT"];
            }
            DataRow[] oDrs_database_sql_connect_stats = oDt_database_sql_connect_stats.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString() + "'");
            if (oDrs_database_sql_connect_stats != null && oDrs_database_sql_connect_stats.Length > 0)
            {
                oDr_website_my_pageurl[database_sql_connect_stats._REQUEST_COUNT] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._REQUEST_COUNT];
                oDr_website_my_pageurl[database_sql_connect_stats._DURATION_AVG] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._DURATION_AVG];
                oDr_website_my_pageurl[database_sql_connect_stats._CONNECT_TIMES_AVG] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._CONNECT_TIMES_AVG];
                oDr_website_my_pageurl[database_sql_connect_stats._REQUEST_COUNT + "_Max"] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._REQUEST_COUNT + "_Max"];
                oDr_website_my_pageurl[database_sql_connect_stats._DURATION_AVG + "_Max"] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._DURATION_AVG + "_Max"];
                oDr_website_my_pageurl[database_sql_connect_stats._CONNECT_TIMES_AVG + "_Max"] = oDrs_database_sql_connect_stats[0][database_sql_connect_stats._CONNECT_TIMES_AVG + "_Max"];
            }
            if (oDt_website_my_pageurl.Rows.Count > 0)
            {
                DataView oDv = oDt_website_my_pageurl.DefaultView;
                oDv.RowFilter = website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'";
                this.rpt_My_PageUrl.DataSource = oDv;
                this.rpt_My_PageUrl.DataBind();
            }
            #endregion

            #region 我依赖的接口
            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.SelectColumns = new string[]{
                website_my_pageurl.TableName+"."+website_my_pageurl._WEBMANAGER_NAME,
	            "COUNT(DISTINCT "+website_depend.TableName+"."+website_depend._DEPEND_PAGEURL+") as MYCOUNT", 
	            "AVG("+website_depend._DEPEND_COUNT+") as "+website_depend._DEPEND_COUNT+"",
	            "AVG("+website_depend._DEPEND_TIMESPAN_AVERAGE+") as "+website_depend._DEPEND_TIMESPAN_AVERAGE+"",
	            "AVG("+website_depend._DEPEND_COUNT_ERROR+") as "+website_depend._DEPEND_COUNT_ERROR+"",
	            "AVG("+website_depend._DEPEND_COUNT_TIMEOUT+") as "+website_depend._DEPEND_COUNT_TIMEOUT+"",

                //"AVG("+website_depend._DEPEND_ERROR_RATE+") as "+website_depend._DEPEND_ERROR_RATE+"",
                //"AVG("+website_depend._DEPEND_TIMEOUT_RATE+") as "+website_depend._DEPEND_TIMEOUT_RATE+"",

                "ROUND(SUM(("+website_depend._DEPEND_COUNT_ERROR+"+"+website_depend._DEPEND_COUNT_TIMEOUT+")*1.0000)*100.0000/SUM("+website_depend._DEPEND_COUNT+"*1.0000),4) AS "+website_depend._DEPEND_ERROR_RATE+"",
                //"ROUND(SUM("+website_depend._DEPEND_COUNT_TIMEOUT+"*1.0000)*100.0000/SUM("+website_depend._DEPEND_COUNT+"*1.0000),4) AS "+website_depend._DEPEND_TIMEOUT_RATE+"",


	            "MAX("+website_depend._DEPEND_TIMESPAN_AVERAGE+") as  "+website_depend._DEPEND_TIMESPAN_AVERAGE+"_max",
	            "MAX("+website_depend._DEPEND_COUNT_ERROR+") as  "+website_depend._DEPEND_COUNT_ERROR+"_max",
	            "MAX("+website_depend._DEPEND_COUNT_TIMEOUT+") as  "+website_depend._DEPEND_COUNT_TIMEOUT+"_max"
            };
            website_depend.INNER_JOIN_WEBSITE_MY_PAGEURL = true;
            website_depend.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            website_depend.CacheTime = 60;
            DataTable oDt_website_depend = website_depend.Select();

            DataRow[] oDrs_website_depend = oDt_website_depend.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'");
            if (oDrs_website_depend == null || oDrs_website_depend.Length == 0)
            {
                DataRow oDr_New = oDt_website_depend.NewRow();
                oDr_New[website_my_pageurl._WEBMANAGER_NAME] = this.CurrentWebManagerName_v;
                oDr_New["MYCOUNT"] = 0;
                oDr_New[website_depend._DEPEND_COUNT] = 0;
                oDr_New[website_depend._DEPEND_TIMESPAN_AVERAGE] = 0;
                oDr_New[website_depend._DEPEND_COUNT_ERROR] = 0;
                oDr_New[website_depend._DEPEND_COUNT_TIMEOUT] = 0;
                oDr_New[website_depend._DEPEND_ERROR_RATE] = 0;
                // oDr_New[website_depend._DEPEND_TIMEOUT_RATE] = 0;
                oDr_New[website_depend._DEPEND_TIMESPAN_AVERAGE + "_max"] = 0;
                oDr_New[website_depend._DEPEND_COUNT_ERROR + "_max"] = 0;
                oDr_New[website_depend._DEPEND_COUNT_TIMEOUT + "_max"] = 0;

                oDt_website_depend.Rows.Add(oDr_New);

            }
            if (oDt_website_depend.Rows.Count > 0)
            {
                DataView oDv = oDt_website_depend.DefaultView;
                oDv.RowFilter = website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'";
                this.rpt_My_PageUrl_Depend.DataSource = oDv;
                this.rpt_My_PageUrl_Depend.DataBind();
            }
            #endregion

            #region 我的MemCached缓存
            Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits = new Entity.TEAMTOOL.MEMCACHE_HITS();
            memcache_hits.RIGHT_JOIN_WEBSITE_MY_PAGEURL = true;
            memcache_hits.SelectColumns = new string[]{
                website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME,               
                 "ISNULL(avg("+memcache_hits._GET_HITS_COUNT+"),0)  as "+memcache_hits._GET_HITS_COUNT+"",      
                 "ISNULL(avg("+memcache_hits._GET_COUNT+"),0)  as "+memcache_hits._GET_COUNT+"",   
                 "ISNULL(avg("+memcache_hits._SET_COUNT+"),0)  as "+memcache_hits._SET_COUNT+"",
                 "ISNULL(avg("+memcache_hits._SET_HITS_COUNT+"),0)  as "+memcache_hits._SET_HITS_COUNT+"",
                 "ISNULL(sum("+memcache_hits._GET_HITS_COUNT+"),0)*100.0000/(ISNULL(sum("+memcache_hits._GET_COUNT+"),1)+0.0001) AS hits_rate",  
                 "ISNULL(sum("+memcache_hits._GET_HITS_COUNT+"),0)*1.0000/(ISNULL(sum("+memcache_hits._SET_COUNT+"),1)+0.0001) AS avail_rate",  
                 "'XXXXXXXXX' AS avail_remark",   
                 "ISNULL(max("+memcache_hits._GET_HITS_COUNT+"),0)  as "+memcache_hits._GET_HITS_COUNT+"_max",
                 "ISNULL(max("+memcache_hits._GET_COUNT+"),0)  as "+memcache_hits._GET_COUNT+"_max",
                 "ISNULL(max("+memcache_hits._SET_HITS_COUNT+"),0)  as "+memcache_hits._SET_HITS_COUNT+"_max",
                 "ISNULL(max("+memcache_hits._SET_COUNT+"),0)  as "+memcache_hits._SET_COUNT+"_max"
 
            };
            memcache_hits.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            memcache_hits.CacheTime = 60;
            DataTable oDt_memcache_hits = memcache_hits.Select();
            DataRow[] oDrs_memcache_hits = oDt_memcache_hits.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'");
            if (oDrs_memcache_hits == null || oDrs_memcache_hits.Length == 0)
            {
                DataRow oDr_New = oDt_memcache_hits.NewRow();

                oDr_New[website_my_pageurl._WEBMANAGER_NAME] = this.CurrentWebManagerName_v;

                oDr_New[memcache_hits._GET_HITS_COUNT] = 0;
                oDr_New[memcache_hits._GET_COUNT] = 0;
                oDr_New[memcache_hits._SET_HITS_COUNT] = 0;
                oDr_New[memcache_hits._SET_COUNT] = 0;
                oDr_New["hits_rate"] = 0;
                oDr_New["avail_rate"] = 0;
                oDr_New[memcache_hits._GET_HITS_COUNT + "_max"] = 0;
                oDr_New[memcache_hits._GET_COUNT + "_max"] = 0;
                oDr_New[memcache_hits._SET_HITS_COUNT + "_max"] = 0;
                oDr_New[memcache_hits._SET_COUNT + "_max"] = 0;

                oDt_memcache_hits.Rows.Add(oDr_New);

            }
            foreach (DataRow oDr_memcache_hits in oDt_memcache_hits.Rows)
            {
                decimal avail_rate = (decimal)oDr_memcache_hits["avail_rate"];
                if (avail_rate <= 0)
                {
                    oDr_memcache_hits["avail_remark"] = "";
                }
                else if (avail_rate < 1)
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略超级差,请优化";
                }
                else if (avail_rate < 10)
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略很差,请优化";
                }
                else if (avail_rate < 100)
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略好";
                }
                else if (avail_rate < 500)
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略较好";
                }
                else if (avail_rate < 1000)
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略很好";
                }
                else
                {
                    oDr_memcache_hits["avail_remark"] = "缓存策略超级好";
                }

            }
            if (oDt_memcache_hits.Rows.Count > 0)
            {
                DataView oDv = oDt_memcache_hits.DefaultView;
                oDv.RowFilter = website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'";
                this.rpt_My_Memcache.DataSource = oDv;
                this.rpt_My_Memcache.DataBind();
            }
            #endregion
            #region 我的报错

            Entity.TEAMTOOL.LOG_STATS log_stats = new Entity.TEAMTOOL.LOG_STATS();
            log_stats.Distinct = true;
            log_stats.SelectColumns = new string[]{
               website_my_pageurl.TableName+ "."+website_my_pageurl._WEBMANAGER_NAME,
                "ISNULL(SUM("+log_stats._LOG_COUNT+"),0) AS "+log_stats._LOG_COUNT+"",
                "ISNULL(AVG("+log_stats._LOG_COUNT+"),0) AS "+log_stats._LOG_COUNT+"_AVG", 
                "ISNULL(MAX("+log_stats._LOG_COUNT+"),0) AS "+log_stats._LOG_COUNT+"_MAX",
                "ISNULL(COUNT(DISTINCT "+log_stats._LOG_DATE+"),0) as "+log_stats._LOG_DATE+"_COUNT",
                "ISNULL(COUNT(DISTINCT "+log_stats.TableName+"."+log_stats._PAGEURL+"),0) as "+log_stats._PAGEURL+"_count",
                
                "0 AS "+log_stats._LOG_COUNT+"0",
                "0 AS "+log_stats._LOG_COUNT+"_AVG0", 
                "0 AS "+log_stats._LOG_COUNT+"_MAX0",
                "0 as "+log_stats._LOG_DATE+"_COUNT0",
                "0 as "+log_stats._PAGEURL+"_COUNT0",
                
                "0 AS "+log_stats._LOG_COUNT+"1",
                "0 AS "+log_stats._LOG_COUNT+"_AVG1", 
                "0 AS "+log_stats._LOG_COUNT+"_MAX1",
                "0 as "+log_stats._LOG_DATE+"_COUNT1",
                "0 as "+log_stats._PAGEURL+"_COUNT1"
            };
            log_stats.WhereSql = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME + " IS NOT NULL";
            log_stats.LEFT_JOIN_WEBSITE_MY_PAGEURL = true;
            log_stats.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            log_stats.CacheTime = 60;
            DataTable oDt_log_stats = log_stats.Select();
            //-----------------------------------------------------------------------------

            Entity.TEAMTOOL.LOG_STATS log_stats0 = new Entity.TEAMTOOL.LOG_STATS();
            log_stats0.Distinct = true;
            log_stats0.SelectColumns = new string[]{
               website_my_pageurl.TableName+ "."+website_my_pageurl._WEBMANAGER_NAME,
                "ISNULL(SUM("+log_stats0._LOG_COUNT+"),0) AS "+log_stats0._LOG_COUNT+"0",
                "ISNULL(AVG("+log_stats0._LOG_COUNT+"),0) AS "+log_stats0._LOG_COUNT+"_AVG0", 
                "ISNULL(MAX("+log_stats0._LOG_COUNT+"),0) AS "+log_stats0._LOG_COUNT+"_MAX0",
                "ISNULL(COUNT(DISTINCT "+log_stats0._LOG_DATE+"),0) as "+log_stats0._LOG_DATE+"_COUNT0",
                "ISNULL(COUNT(DISTINCT "+log_stats0.TableName+"."+log_stats0._PAGEURL+"),0) as "+log_stats0._PAGEURL+"_COUNT0"
            };
            log_stats0.WhereSql = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME + " IS NOT NULL";
            log_stats0.LEFT_JOIN_WEBSITE_MY_PAGEURL = true;
            log_stats0.LOG_TYPE = 0;
            log_stats0.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            log_stats0.CacheTime = 60;
            DataTable oDt_log_stats0 = log_stats0.Select();
            //-----------------------------------------------------------------------------

            Entity.TEAMTOOL.LOG_STATS log_stats1 = new Entity.TEAMTOOL.LOG_STATS();
            log_stats1.Distinct = true;
            log_stats1.SelectColumns = new string[]{
               website_my_pageurl.TableName+ "."+website_my_pageurl._WEBMANAGER_NAME,
	            "ISNULL(SUM("+log_stats1._LOG_COUNT+"),0) AS "+log_stats1._LOG_COUNT+"1",
	            "ISNULL(AVG("+log_stats1._LOG_COUNT+"),0) AS "+log_stats1._LOG_COUNT+"_AVG1", 
	            "ISNULL(MAX("+log_stats1._LOG_COUNT+"),0) AS "+log_stats1._LOG_COUNT+"_MAX1",
	            "ISNULL(COUNT(DISTINCT "+log_stats1._LOG_DATE+"),0) as "+log_stats1._LOG_DATE+"_COUNT1",
                "ISNULL(COUNT(DISTINCT "+log_stats1.TableName+"."+log_stats1._PAGEURL+"),0) as "+log_stats1._PAGEURL+"_COUNT1"
            };
            log_stats1.WhereSql = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME + " IS NOT NULL";
            log_stats1.LEFT_JOIN_WEBSITE_MY_PAGEURL = true;
            log_stats1.LOG_TYPE = 1;
            log_stats1.GroupBy = website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME;
            log_stats1.CacheTime = 60;
            DataTable oDt_log_stats1 = log_stats1.Select();
            //-----------------------------------------------------------------------------
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "0", typeof(int)));
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "_AVG0", typeof(int)));
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "_MAX0", typeof(int)));
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_DATE + "_COUNT0", typeof(int)));
            ////-------------------------
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "1", typeof(int)));
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "_AVG1", typeof(int)));
            //oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "_MAX1", typeof(int)));
            oDt_log_stats.Columns.Add(new DataColumn(log_stats._LOG_COUNT + "_ALL0", typeof(int)));
            int LOG_COUNT_ALL0 = 0;
            foreach (DataRow oDr_log_stats0 in oDt_log_stats0.Rows)
            {
                LOG_COUNT_ALL0 += (int)oDr_log_stats0[log_stats._LOG_COUNT + "0"];
                //if (!string.IsNullOrEmpty(oDr_log_stats0[website_my_pageurl._WEBMANAGER_NAME].ToString()))
                {
                    DataRow[] oDrs_log_stats = oDt_log_stats.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + oDr_log_stats0[website_my_pageurl._WEBMANAGER_NAME].ToString() + "'");
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "0"] = oDr_log_stats0[log_stats._LOG_COUNT + "0"];
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "_AVG0"] = oDr_log_stats0[log_stats._LOG_COUNT + "_AVG0"];
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "_MAX0"] = oDr_log_stats0[log_stats._LOG_COUNT + "_MAX0"];
                    oDrs_log_stats[0][log_stats._LOG_DATE + "_COUNT0"] = oDr_log_stats0[log_stats._LOG_DATE + "_COUNT0"];
                    oDrs_log_stats[0][log_stats._PAGEURL + "_COUNT0"] = oDr_log_stats0[log_stats._PAGEURL + "_COUNT0"];
                }
            }
            foreach (DataRow oDr_log_stats1 in oDt_log_stats1.Rows)
            {
                //if (!string.IsNullOrEmpty(oDr_log_stats1[website_my_pageurl._WEBMANAGER_NAME].ToString()))
                {
                    DataRow[] oDrs_log_stats = oDt_log_stats.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + oDr_log_stats1[website_my_pageurl._WEBMANAGER_NAME].ToString() + "'");
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "1"] = oDr_log_stats1[log_stats._LOG_COUNT + "1"];
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "_AVG1"] = oDr_log_stats1[log_stats._LOG_COUNT + "_AVG1"];
                    oDrs_log_stats[0][log_stats._LOG_COUNT + "_MAX1"] = oDr_log_stats1[log_stats._LOG_COUNT + "_MAX1"];
                    oDrs_log_stats[0][log_stats._LOG_DATE + "_COUNT1"] = oDr_log_stats1[log_stats._LOG_DATE + "_COUNT1"];
                    oDrs_log_stats[0][log_stats._PAGEURL + "_COUNT1"] = oDr_log_stats1[log_stats._PAGEURL + "_COUNT1"];
                }
            }
            DataRow[] oDrs_log_stats0 = oDt_log_stats.Select(website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'");
            if (oDrs_log_stats0 == null || oDrs_log_stats0.Length == 0)
            {
                DataRow oDr_New = oDt_log_stats.NewRow();

                oDr_New[website_my_pageurl._WEBMANAGER_NAME] = this.CurrentWebManagerName_v;
                oDr_New[log_stats._LOG_COUNT] = 0;
                oDr_New[log_stats._LOG_COUNT + "_AVG"] = 0;
                oDr_New[log_stats._LOG_COUNT + "_MAX"] = 0;
                oDr_New[log_stats._LOG_DATE + "_COUNT"] = 0;
                oDr_New[log_stats._PAGEURL + "_COUNT"] = 0;

                oDr_New[log_stats._LOG_COUNT + "0"] = 0;
                oDr_New[log_stats._LOG_COUNT + "_AVG0"] = 0;
                oDr_New[log_stats._LOG_COUNT + "_MAX0"] = 0;
                oDr_New[log_stats._LOG_DATE + "_COUNT0"] = 0;
                oDr_New[log_stats._PAGEURL + "_COUNT0"] = 0;

                oDr_New[log_stats._LOG_COUNT + "1"] = 0;
                oDr_New[log_stats._LOG_COUNT + "_AVG1"] = 0;
                oDr_New[log_stats._LOG_COUNT + "_MAX1"] = 0;
                oDr_New[log_stats._LOG_DATE + "_COUNT1"] = 0;
                oDr_New[log_stats._PAGEURL + "_COUNT1"] = 0;

                oDt_log_stats.Rows.Add(oDr_New);

            }

            if (oDt_log_stats.Rows.Count > 0)
            {
                DataView oDv = oDt_log_stats.DefaultView;
                oDv.RowFilter = website_my_pageurl._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName_v + "'";
                //if (oDv.Count > 0)
                {
                    oDv[0][log_stats._LOG_COUNT + "_ALL0"] = LOG_COUNT_ALL0;
                }
                this.rpt_My_Log.DataSource = oDv;
                this.rpt_My_Log.DataBind();
            }
            #endregion

            #region 我的报错

            #endregion


        }
    }
}
