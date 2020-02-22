using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Manager.Sql
{
    public partial class DataBase_Sql_List_LikeMine : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_orderby = "";
        public string P_Sql_Error = "";
        /// <summary>
        /// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
        /// </summary>
        public string P_Bug_Type = "";
        public int LogCount = 0;
        public int P_PageSize = 20;
        public string CurrentWebManagerName_v = "";
        public int BadSql_Rank = -1;
        public int Worker_Time_Rank = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_Sql_List_LikeMine.aspx");
            this.CurrentWebManagerName_v = this.CurrentWebManagerName;
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                CurrentWebManagerName_v = this.QueryString("v");
            }
            this.P_Bug_Type = this.QueryString("Bug_Type");
            this.P_orderby = this.QueryString("orderby").Replace("ｅ", "e");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "last_execution_time DESC";
            }

            this.P_Sql_Error = this.QueryString("Sql_Error");
            if (string.IsNullOrEmpty(this.P_Sql_Error))
            {
                this.P_Sql_Error = "0";
            }
            if (!string.IsNullOrEmpty(this.QueryString("PageSize")))
            {
                this.P_PageSize = int.Parse(this.QueryString("PageSize"));
            }

            if (!Page.IsPostBack)
            {
                if (this.QueryString("page") != "")
                {
                    this.P_page = int.Parse(this.QueryString("page"));
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 疑似我的SQL书写规范排名
            DataView oDv_BadSql_Rank = Sql.DataBase_BadSql_Rank.Get_BadSql_Rank(System.DateTime.Now.AddDays(-7).ToShortDateString(), System.DateTime.Now.ToShortDateString());
            DataTable oDt_database_sql_stats_sum = null;
            oDv_BadSql_Rank.Sort = "BadRate ASC";
            for (int i = 0; i < oDv_BadSql_Rank.Count; i++)
            {
                if (oDv_BadSql_Rank[i]["SEEMLIKE_WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.BadSql_Rank = i + 1;
                    oDt_database_sql_stats_sum = oDv_BadSql_Rank.Table.Clone();
                    DataRow oDr_New = oDt_database_sql_stats_sum.NewRow();
                    oDr_New.ItemArray = oDv_BadSql_Rank[i].Row.ItemArray;
                    oDt_database_sql_stats_sum.Rows.Add(oDr_New);
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
            this.rpt_database_sql_stats_sum.DataSource = oDt_database_sql_stats_sum;
            this.rpt_database_sql_stats_sum.DataBind();
            #endregion
            #region 绑定列表
            this.LogCount = 0;
            DataTable dtLog = null;
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            string wheresql = "1=1 ";
            wheresql += " AND (" + database_sql_stats._STATS_DATE + ">'" + DateTime.Now.AddDays(-2).ToShortDateString() + "')";
            wheresql += " AND " + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME + " = '" + this.CurrentWebManagerName_v + "' ";
            //wheresql += " AND " + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME + " LIKE '%" + this.CurrentWebManagerName_v + "%' ";
            //wheresql += " AND (" + database_sql_stats._SQL_MD5 + " NOT IN (select distinct Sql_Md5 from DataBase_Sql_My WITH(NOLOCK)))";
            //wheresql += " AND (" + database_sql_stats._SQL_MD5 + " NOT IN (select distinct Sql_Md5 from DataBase_Sql_My_Ignore WITH(NOLOCK) where WebManager_name='" + this.CurrentWebManagerName_v + "'))";
            if (this.P_Bug_Type == "0")// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
            {
                wheresql += " AND " + database_sql_stats._LACK_WITH_NOLOCK_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "1")
            {
                wheresql += " AND " + database_sql_stats._SELECT_ALL_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "2")
            {
                wheresql += " AND " + database_sql_stats._LIKE_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "3")
            {
                wheresql += " AND " + database_sql_stats._LACK_PARAMETER_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "4")
            {
                wheresql += " AND " + database_sql_stats._COUNT_ALL + ">0 ";
            }
            else if (this.P_Bug_Type == "5")
            {
                wheresql += " AND " + database_sql_stats._ISWRONGDATABASEUSER + ">0  AND  " + database_sql_stats._ISRUNTIMESQL + ">0 ";
            }
            database_sql_stats.WhereSql = wheresql;
            database_sql_stats.OrderBy = this.P_orderby;
            dtLog = database_sql_stats.SelectByPaging(this.P_PageSize, this.P_page - 1, out this.LogCount);
            //--------------------------------------------------------- 
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            website_my_pageurl_all.CacheName = "Welcome_" + this.CurrentWebManagerName + "_21";
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();
            //-------------------------------------------------------
            dtLog.Columns.Add(new DataColumn("IsMySql", typeof(int)));
            dtLog.Columns.Add(new DataColumn("IsMyUrl", typeof(int)));
            dtLog.Columns.Add(new DataColumn("PageUrl", typeof(string)));
            foreach (DataRow oDr_Sql_Stats in dtLog.Rows)
            {
                string PageUrl = Business.Sql.SqlAnalysis.GetRequestPageUrl(oDr_Sql_Stats[database_sql_stats._TEXT].ToString());
                oDr_Sql_Stats["PageUrl"] = PageUrl;
                // ------------------------------------------------------------------------------------------------
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_Sql_Stats[website_my_pageurl_all._PAGEURL].ToString() + "' AND " + website_my_pageurl_all._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    oDr_Sql_Stats["IsMyUrl"] = 1;
                }
                else
                {
                    oDr_Sql_Stats["IsMyUrl"] = 0;
                }
            }
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = this.P_PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Sql/DataBase_Sql_List_LikeMine.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_orderby) + "&Bug_Type=" + this.P_Bug_Type;

            if (this.LogCount < this.P_PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================


            //WithNoLock_Select(dtLog);
            //this.rptLog.DataSource = dtLog;
            //this.rptLog.DataBind();
            #endregion

        }
        private DataTable WithNoLock_Select(DataTable oDt)
        {
            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.SelectColumns = new string[] { database_table._TABLE_NAME };
            database_table.COUNTDATE = System.DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            database_table.Distinct = true;
            database_table.CacheTime = 120;
            DataTable oDt_database_table = database_table.Select();

            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            //oDt.Columns.Add(new DataColumn("WITHNOLOCK_SELECT", typeof(string)));
            string update_sql = "";
            foreach (DataRow oDr in oDt.Rows)
            {
                if (oDr[database_sql_stats._ANALYSIS].ToString() == "0")
                {
                    string Sql_Analysis = "";
                    int[] Counts;
                    string Sql_Error = Business.Sql.SqlAnalysis.GelSqlError(oDr[database_sql_stats._TEXT].ToString(), oDt_database_table, oDr[database_sql_stats._DATABASE_USER].ToString(), out Sql_Analysis, out Counts);

                    Entity.TEAMTOOL.DATABASE_SQL_STATS update_database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                    update_database_sql_stats.STATS_DATE = DateTime.Parse(oDr[database_sql_stats._STATS_DATE].ToString());
                    update_database_sql_stats.SQL_MD5 = oDr[database_sql_stats._SQL_MD5].ToString();
                    update_database_sql_stats.SQL_ERROR = Sql_Error;
                    update_database_sql_stats.TEXT_ANALYSIS = Sql_Analysis;
                    update_database_sql_stats.ANALYSIS = 1;
                    update_database_sql_stats.LACK_WITH_NOLOCK_COUNT = Counts[0];
                    update_database_sql_stats.SELECT_ALL_COUNT = Counts[1];
                    update_database_sql_stats.LACK_PARAMETER_COUNT = Counts[2];
                    update_database_sql_stats.LIKE_COUNT = Counts[3];
                    update_database_sql_stats.COUNT_ALL = Counts[4];
                    update_database_sql_stats.ISWRITESQL = Counts[5];
                    update_database_sql_stats.ISRUNTIMESQL = Counts[6];
                    update_database_sql_stats.ISWRONGDATABASEUSER = Counts[7];
                    update_sql += update_database_sql_stats.GetUpdateSql() + ";";
                }
            }
            if (!string.IsNullOrEmpty(update_sql))
            {
                try
                {
                    int iResult = database_sql_stats.Database_Reader.ExecuteNonQuery(CommandType.Text, update_sql);
                }
                catch { }
            }
            return oDt;
        }
    }
}
