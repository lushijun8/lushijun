using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_BadSql_Rank_My : Business.ManageWeb
    {
        public string P_orderby = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_BadSql_Rank_My.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "Lack_With_NoLock_Count DESC";
            }
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            DataView oDv = Get_BadSql_Rank_My();
            oDv.Sort = this.P_orderby;
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
        }

        public static DataView Get_BadSql_Rank_My()
        {
            string CacheName = "DataBase_BadSql_Rank_My";
            DataTable oDt_database_sql_my = null;
            if (System.Web.HttpContext.Current.Cache[CacheName] != null)
            {
                oDt_database_sql_my = ((DataTable)System.Web.HttpContext.Current.Cache[CacheName]).Copy();
            }
            else
            {
                Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
                database_sql_my.SelectColumns = new string[] {
                "WEBMANAGER_REALNAME",
                database_sql_my.TableName+"."+database_sql_my._WEBMANAGER_NAME+" AS "+database_sql_my._WEBMANAGER_NAME,
                "ISNULL(SUM("+database_sql_my._LACK_WITH_NOLOCK_COUNT+"), 0) AS "+database_sql_my._LACK_WITH_NOLOCK_COUNT,
                "ISNULL(SUM("+database_sql_my._SELECT_ALL_COUNT+"), 0) AS "+database_sql_my._SELECT_ALL_COUNT,
                "ISNULL(SUM("+database_sql_my._LIKE_COUNT+"), 0) AS "+database_sql_my._LIKE_COUNT,
                "ISNULL(SUM("+database_sql_my._LACK_PARAMETER_COUNT+"), 0) AS "+database_sql_my._LACK_PARAMETER_COUNT,
                "ISNULL(SUM("+database_sql_my._COUNT_ALL+"), 0) AS "+database_sql_my._COUNT_ALL,
                "ISNULL(SUM("+database_sql_my._LACK_WITH_NOLOCK_COUNT+"), 0)+ISNULL(SUM("+database_sql_my._SELECT_ALL_COUNT+"), 0)+ISNULL(SUM("+database_sql_my._LIKE_COUNT+"), 0)+ISNULL(SUM("+database_sql_my._LACK_PARAMETER_COUNT+"), 0)+ISNULL(SUM("+database_sql_my._COUNT_ALL+"), 0) as count_sum",
                "ISNULL(SUM("+database_sql_my._TOTAL_WORKER_TIME+"),0) AS "+database_sql_my._TOTAL_WORKER_TIME,
                "ISNULL(MAX("+database_sql_my._TOTAL_WORKER_TIME+"/"+database_sql_my._EXECUTION_COUNT+"),0) AS WORKER_TIME_MAX",
                "ISNULL(SUM("+database_sql_my._EXECUTION_COUNT+"),0) AS "+database_sql_my._EXECUTION_COUNT,
                "count(1) AS counts",
                "0.01 AS BadRate",
                "0.001 AS WORKER_TIME"
            };
                database_sql_my.INNER_JOIN_ADMIN_WEBMANAGER = true;
                database_sql_my.CacheTime = 120;
                database_sql_my.GroupBy = "WEBMANAGER_REALNAME," + database_sql_my.TableName + "." + database_sql_my._WEBMANAGER_NAME;
                oDt_database_sql_my = database_sql_my.Select();
                foreach (DataRow oDr_database_sql_my in oDt_database_sql_my.Rows)
                {
                    decimal count_sum = decimal.Parse(oDr_database_sql_my["count_sum"].ToString());
                    decimal counts = decimal.Parse(oDr_database_sql_my["counts"].ToString());
                    long total_worker_time = long.Parse(oDr_database_sql_my[database_sql_my._TOTAL_WORKER_TIME].ToString());
                    long execution_count = long.Parse(oDr_database_sql_my[database_sql_my._EXECUTION_COUNT].ToString());
                    oDr_database_sql_my["BadRate"] = oDr_database_sql_my["counts"].ToString() == "0" ? "0" : (count_sum * 100 / counts).ToString("f2").Replace(".00", "");
                    oDr_database_sql_my["WORKER_TIME"] = total_worker_time / execution_count;
                }
                System.Web.HttpContext.Current.Cache.Add(CacheName, oDt_database_sql_my.Copy(), null, System.DateTime.Now.Add(new TimeSpan(2, 0, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            DataView oDv = oDt_database_sql_my.DefaultView;
            return oDv;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
