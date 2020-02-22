using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_BadSql_Rank : Business.ManageWeb
    {
        public string P_orderby = "";
        public string P_CreateTime0 = "";
        public string P_CreateTime1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_BadSql_Rank.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "Lack_With_NoLock_Count DESC";
            }
            if (!Page.IsPostBack)
            {
                this.P_CreateTime0 = this.QueryString("createtime0");
                if (string.IsNullOrEmpty(this.P_CreateTime0))
                {
                    this.P_CreateTime0 = System.DateTime.Now.AddDays(-7).ToShortDateString();
                }
                this.P_CreateTime1 = this.QueryString("createtime1");
                if (string.IsNullOrEmpty(this.P_CreateTime1))
                {
                    this.P_CreateTime1 = System.DateTime.Now.ToShortDateString();
                }
                this.txtCreateTime0.Text = this.P_CreateTime0;
                this.txtCreateTime1.Text = this.P_CreateTime1;

                this.BindData();
            }
        }
        private void BindData()
        {
            DataView oDv = Get_BadSql_Rank(this.txtCreateTime0.Text.Trim(), this.txtCreateTime1.Text.Trim());
            oDv.Sort = this.P_orderby;
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
        }
        public static DataView Get_BadSql_Rank(string starttime, string endtime)
        {
            string CacheName = "DataBase_BadSql_Rank_" + starttime.Replace(" ", "") + "_" + endtime.Replace(" ", "");
            DataTable oDt_database_sql_stats = null;
            if (System.Web.HttpContext.Current.Cache[CacheName] != null)
            {
                oDt_database_sql_stats = ((DataTable)System.Web.HttpContext.Current.Cache[CacheName]).Copy();
            }
            else
            {
                Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                database_sql_stats.SelectColumns = new string[] {
                database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME,
                database_sql_stats._SEEMLIKE_WEBMANAGER_NAME,
                "ISNULL(SUM("+database_sql_stats._LACK_WITH_NOLOCK_COUNT+"), 0) AS "+database_sql_stats._LACK_WITH_NOLOCK_COUNT,
                "ISNULL(SUM("+database_sql_stats._SELECT_ALL_COUNT+"), 0) AS "+database_sql_stats._SELECT_ALL_COUNT,
                "ISNULL(SUM("+database_sql_stats._LIKE_COUNT+"), 0) AS "+database_sql_stats._LIKE_COUNT,
                "ISNULL(SUM("+database_sql_stats._LACK_PARAMETER_COUNT+"), 0) AS "+database_sql_stats._LACK_PARAMETER_COUNT,
                "ISNULL(SUM("+database_sql_stats._COUNT_ALL+"), 0) AS "+database_sql_stats._COUNT_ALL,
                "ISNULL(SUM("+database_sql_stats._LACK_WITH_NOLOCK_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats._SELECT_ALL_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats._LIKE_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats._LACK_PARAMETER_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats._COUNT_ALL+"), 0) as count_sum",
                "SUM("+database_sql_stats._TOTAL_WORKER_TIME+") AS "+database_sql_stats._TOTAL_WORKER_TIME,
                "SUM("+database_sql_stats._EXECUTION_COUNT+") AS "+database_sql_stats._EXECUTION_COUNT,
                "COUNT(1) AS COUNTS",
                "0.01 AS BadRate",
                "0.001 AS WORKER_TIME"
            };
                string WhereSql = "1=1";
                if (!string.IsNullOrEmpty(starttime))
                {
                    WhereSql += " AND  " + database_sql_stats._STATS_DATE + ">='" + starttime + "' ";
                }
                if (!string.IsNullOrEmpty(endtime))
                {
                    WhereSql += " AND  " + database_sql_stats._STATS_DATE + "<='" + endtime + " 23:59:59'";
                }
                WhereSql += " AND (" + database_sql_stats._SQL_MD5 + " NOT IN (select distinct Sql_Md5 from DataBase_Sql_My WITH(NOLOCK)))";
                WhereSql += " AND (" + database_sql_stats._SQL_MD5 + " NOT IN (select distinct Sql_Md5 from DataBase_Sql_My_Ignore WITH(NOLOCK) where WebManager_name=" + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME + "))";

                database_sql_stats.CacheTime = 120;
                database_sql_stats.WhereSql = WhereSql;
                database_sql_stats.GroupBy = database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME + "," + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME;

                oDt_database_sql_stats = database_sql_stats.Select();
                DataRow[] oDrs_database_sql_stats = oDt_database_sql_stats.Select(database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME + " LIKE '%,%'");
                if (oDrs_database_sql_stats != null && oDrs_database_sql_stats.Length > 0)
                {
                    foreach (DataRow oDr_database_sql_stats in oDrs_database_sql_stats)
                    {
                        #region 变量
                        string[] realnames = oDr_database_sql_stats[database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME].ToString().Split(',');
                        string[] names = oDr_database_sql_stats[database_sql_stats._SEEMLIKE_WEBMANAGER_NAME].ToString().Split(',');
                        int Lack_With_NoLock_Count = int.Parse(oDr_database_sql_stats[database_sql_stats._LACK_WITH_NOLOCK_COUNT].ToString());
                        int Select_All_Count = int.Parse(oDr_database_sql_stats[database_sql_stats._SELECT_ALL_COUNT].ToString());
                        int Like_Count = int.Parse(oDr_database_sql_stats[database_sql_stats._LIKE_COUNT].ToString());
                        int Lack_Parameter_Count = int.Parse(oDr_database_sql_stats[database_sql_stats._LACK_PARAMETER_COUNT].ToString());
                        int count_all = int.Parse(oDr_database_sql_stats[database_sql_stats._COUNT_ALL].ToString());
                        int count_sum = int.Parse(oDr_database_sql_stats["count_sum"].ToString());
                        int counts = int.Parse(oDr_database_sql_stats["counts"].ToString());
                        long total_worker_time = long.Parse(oDr_database_sql_stats["total_worker_time"].ToString());
                        long execution_count = long.Parse(oDr_database_sql_stats["execution_count"].ToString());
                        #endregion
                        int k = 0;
                        foreach (string realname in realnames)
                        {
                            DataRow[] oDrs_realname = oDt_database_sql_stats.Select(database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME + " ='" + realname + "'");
                            if (oDrs_realname != null && oDrs_realname.Length > 0)
                            {
                                #region 更新
                                oDrs_realname[0][database_sql_stats._LACK_WITH_NOLOCK_COUNT] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._LACK_WITH_NOLOCK_COUNT].ToString()) +
                                    Lack_With_NoLock_Count;

                                oDrs_realname[0][database_sql_stats._SELECT_ALL_COUNT] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._SELECT_ALL_COUNT].ToString()) +
                                    Select_All_Count;

                                oDrs_realname[0][database_sql_stats._LIKE_COUNT] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._LIKE_COUNT].ToString()) +
                                    Like_Count;

                                oDrs_realname[0][database_sql_stats._LACK_PARAMETER_COUNT] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._LACK_PARAMETER_COUNT].ToString()) +
                                    Lack_Parameter_Count;

                                oDrs_realname[0][database_sql_stats._COUNT_ALL] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._COUNT_ALL].ToString()) +
                                    count_all;

                                oDrs_realname[0][database_sql_stats._TOTAL_WORKER_TIME] =
                                    long.Parse(oDrs_realname[0][database_sql_stats._TOTAL_WORKER_TIME].ToString()) +
                                    total_worker_time;

                                oDrs_realname[0][database_sql_stats._EXECUTION_COUNT] =
                                    int.Parse(oDrs_realname[0][database_sql_stats._EXECUTION_COUNT].ToString()) +
                                    execution_count;

                                oDrs_realname[0]["count_sum"] =
                                    int.Parse(oDrs_realname[0]["count_sum"].ToString()) +
                                    count_sum;

                                oDrs_realname[0]["counts"] =
                                    int.Parse(oDrs_realname[0]["counts"].ToString()) +
                                    counts;
                                #endregion
                            }
                            else
                            {
                                #region 新增一条记录
                                DataRow oDr_New = oDt_database_sql_stats.NewRow();
                                oDr_New[database_sql_stats._SEEMLIKE_WEBMANAGER_REALNAME] = realname;
                                oDr_New[database_sql_stats._SEEMLIKE_WEBMANAGER_NAME] = names[k];
                                oDr_New[database_sql_stats._LACK_WITH_NOLOCK_COUNT] = Lack_With_NoLock_Count;
                                oDr_New[database_sql_stats._SELECT_ALL_COUNT] = Select_All_Count;
                                oDr_New[database_sql_stats._LIKE_COUNT] = Like_Count;
                                oDr_New[database_sql_stats._LACK_PARAMETER_COUNT] = Lack_Parameter_Count;
                                oDr_New[database_sql_stats._COUNT_ALL] = count_all;
                                oDr_New[database_sql_stats._TOTAL_WORKER_TIME] = total_worker_time;
                                oDr_New[database_sql_stats._EXECUTION_COUNT] = execution_count;
                                oDr_New["count_sum"] = count_sum;
                                oDr_New["counts"] = counts;
                                oDt_database_sql_stats.Rows.Add(oDr_New);
                                #endregion
                            }
                        }
                        #region 删除原始DataRow
                        oDt_database_sql_stats.Rows.Remove(oDr_database_sql_stats);
                        #endregion
                        k++;
                    }
                }
                foreach (DataRow oDr_database_sql_stats in oDt_database_sql_stats.Rows)
                {
                    decimal count_sum = decimal.Parse(oDr_database_sql_stats["count_sum"].ToString());
                    decimal counts = decimal.Parse(oDr_database_sql_stats["counts"].ToString());
                    long total_worker_time = long.Parse(oDr_database_sql_stats[database_sql_stats._TOTAL_WORKER_TIME].ToString());
                    long execution_count = long.Parse(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString());
                    oDr_database_sql_stats["BadRate"] = oDr_database_sql_stats["counts"].ToString() == "0" ? "0" : (count_sum * 100 / counts).ToString("f2").Replace(".00", "");
                    oDr_database_sql_stats["WORKER_TIME"] = total_worker_time / execution_count;
                }
                System.Web.HttpContext.Current.Cache.Add(CacheName, oDt_database_sql_stats.Copy(), null, System.DateTime.Now.Add(new TimeSpan(2, 0, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }

            DataView oDv = oDt_database_sql_stats.DefaultView;
            return oDv;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
