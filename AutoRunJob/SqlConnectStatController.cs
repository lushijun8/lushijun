using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace TeamToolTask
{
    public class SqlConnectStatController
    {
        public static void Stat()
        {
            Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG database_sql_connect_log = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG();
            DataTable oDt = database_sql_connect_log.Database_Reader.ExecuteDataSet(CommandType.Text, @"SELECT
	        [SessionId]+[ServerInfo]+[PageUrlOrFunction] as SessionId,
	        CONVERT(VARCHAR(100), ExecutionTime, 23) AS Stats_Date0,
	        MAX(PageUrlOrFunction) AS PageUrl,
	        DATEDIFF(ms, MIN(ExecutionTime), MAX(ISNULL(ExecutionTime_End, ExecutionTime))) AS duration,
	        MIN(ExecutionTime) AS ExecutionTime_Start,
	        MAX(ExecutionTime) AS ExecutionTime_End,
	        MAX(Querystring) AS Querystring,
	        MAX(form) AS form,
	        COUNT(1) AS Connect_Times INTO #temp
        FROM DataBase_Sql_Connect_Log
        GROUP BY	[SessionId]+[ServerInfo]+[PageUrlOrFunction],
			        CONVERT(VARCHAR(100), ExecutionTime, 23)
        ORDER BY Connect_Times DESC
        ---------------------------------------------
        TRUNCATE TABLE DataBase_Sql_Connect_Log
        --------------------------------------------
        SELECT
	        pageurl,
	        Stats_Date0 AS Stats_Date,
	        MAX(ExecutionTime_End) AS LastConnectTime,
	        COUNT(DISTINCT SessionId) AS Request_Count,
	        MAX(Querystring) AS Querystring,
	        MAX(form) AS form,
	        SUM(DATEDIFF(ms, ExecutionTime_Start, ExecutionTime_End)) AS Duration_Sum,
	        AVG(DATEDIFF(ms, ExecutionTime_Start, ExecutionTime_End)) AS Duration_Avg,
	        MAX(DATEDIFF(ms, ExecutionTime_Start, ExecutionTime_End)) AS Duration_max,
	        MIN(DATEDIFF(ms, ExecutionTime_Start, ExecutionTime_End)) AS Duration_min,
	        SUM(Connect_Times) AS Connect_Times_Sum,
	        AVG(Connect_Times) AS Connect_Times_Avg,
	        MAX(Connect_Times) AS Connect_Times_max,
	        MIN(Connect_Times) AS Connect_Times_min
        FROM #temp
        GROUP BY	pageurl,
			        Stats_Date0
        ORDER BY Request_Count DESC
        ---------------------------------------
        DROP TABLE #temp").Tables[0];

            int allcount = oDt.Rows.Count;
            int i = 0;
            foreach (DataRow oDr in oDt.Rows)
            {
                i++;
                #region

                Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS database_sql_connect_stats_update = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS();

                DateTime LastConnectTime = DateTime.Parse(oDr[database_sql_connect_stats_update._LASTCONNECTTIME].ToString());
                long Duration_Sum = long.Parse(oDr[database_sql_connect_stats_update._DURATION_SUM].ToString());
                long Duration_Max = long.Parse(oDr[database_sql_connect_stats_update._DURATION_MAX].ToString());
                long Duration_Min = long.Parse(oDr[database_sql_connect_stats_update._DURATION_MIN].ToString());
                long Connect_Times_Sum = long.Parse(oDr[database_sql_connect_stats_update._CONNECT_TIMES_SUM].ToString());
                long Connect_Times_Max = long.Parse(oDr[database_sql_connect_stats_update._CONNECT_TIMES_MAX].ToString());
                long Connect_Times_Min = long.Parse(oDr[database_sql_connect_stats_update._CONNECT_TIMES_MIN].ToString());
                long Request_Count = long.Parse(oDr[database_sql_connect_stats_update._REQUEST_COUNT].ToString());

                database_sql_connect_stats_update.PAGEURL = oDr[database_sql_connect_stats_update._PAGEURL].ToString();
                database_sql_connect_stats_update.QUERYSTRING = oDr[database_sql_connect_stats_update._QUERYSTRING].ToString();
                database_sql_connect_stats_update.FORM = oDr[database_sql_connect_stats_update._FORM].ToString();


                database_sql_connect_stats_update.STATS_DATE = DateTime.Parse(oDr[database_sql_connect_stats_update._STATS_DATE].ToString());
                database_sql_connect_stats_update.CREATETIME = System.DateTime.Now;

                database_sql_connect_stats_update.LASTCONNECTTIME = LastConnectTime;
                database_sql_connect_stats_update.REQUEST_COUNT = Request_Count;

                database_sql_connect_stats_update.DURATION_SUM = Duration_Sum;
                database_sql_connect_stats_update.DURATION_MAX = Duration_Max;
                database_sql_connect_stats_update.DURATION_MIN = Duration_Min;

                database_sql_connect_stats_update.CONNECT_TIMES_SUM = Connect_Times_Sum;
                database_sql_connect_stats_update.CONNECT_TIMES_MAX = Connect_Times_Max;
                database_sql_connect_stats_update.CONNECT_TIMES_MIN = Connect_Times_Min;

                database_sql_connect_stats_update.DURATION_AVG = long.Parse(database_sql_connect_stats_update.DURATION_SUM_ToString) / Request_Count;
                database_sql_connect_stats_update.CONNECT_TIMES_AVG = long.Parse(database_sql_connect_stats_update.CONNECT_TIMES_SUM_ToString) / Request_Count;
                //----------------------------------------------------
                Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS database_sql_connect_stats = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_STATS();
                database_sql_connect_stats.PAGEURL = oDr[database_sql_connect_stats._PAGEURL].ToString();
                database_sql_connect_stats.STATS_DATE = DateTime.Parse(oDr[database_sql_connect_stats._STATS_DATE].ToString());
                if (database_sql_connect_stats.SelectTop1() != null)
                {
                    #region Update

                    database_sql_connect_stats_update.REQUEST_COUNT = Request_Count + long.Parse(database_sql_connect_stats.REQUEST_COUNT_ToString);
                    database_sql_connect_stats_update.DURATION_SUM = Duration_Sum + long.Parse(database_sql_connect_stats.DURATION_SUM_ToString);
                    database_sql_connect_stats_update.CONNECT_TIMES_SUM = Connect_Times_Sum + long.Parse(database_sql_connect_stats.CONNECT_TIMES_SUM_ToString);

                    if (database_sql_connect_stats.QUERYSTRING.Length > database_sql_connect_stats_update.QUERYSTRING.Length)
                    {
                        database_sql_connect_stats_update.QUERYSTRING = database_sql_connect_stats.QUERYSTRING;
                    }
                    if (database_sql_connect_stats.FORM.Length > database_sql_connect_stats_update.FORM.Length)
                    {
                        database_sql_connect_stats_update.FORM = database_sql_connect_stats.FORM;
                    }

                    if (DateTime.Parse(database_sql_connect_stats.LASTCONNECTTIME_ToString) > LastConnectTime)
                    {
                        database_sql_connect_stats_update.LASTCONNECTTIME = DateTime.Parse(database_sql_connect_stats.LASTCONNECTTIME_ToString);
                    }

                    if (long.Parse(database_sql_connect_stats.DURATION_MAX_ToString) > Duration_Max)
                    {
                        database_sql_connect_stats_update.DURATION_MAX = long.Parse(database_sql_connect_stats.DURATION_MAX_ToString);
                    }
                    if (long.Parse(database_sql_connect_stats.DURATION_MIN_ToString) < Duration_Min)
                    {
                        database_sql_connect_stats_update.DURATION_MIN = long.Parse(database_sql_connect_stats.DURATION_MIN_ToString);
                    }

                    if (long.Parse(database_sql_connect_stats.CONNECT_TIMES_MAX_ToString) > Connect_Times_Max)
                    {
                        database_sql_connect_stats_update.CONNECT_TIMES_MAX = long.Parse(database_sql_connect_stats.CONNECT_TIMES_MAX_ToString);
                    }
                    if (long.Parse(database_sql_connect_stats.CONNECT_TIMES_MIN_ToString) < Connect_Times_Min)
                    {
                        database_sql_connect_stats_update.CONNECT_TIMES_MIN = long.Parse(database_sql_connect_stats.CONNECT_TIMES_MIN_ToString);
                    }
                    database_sql_connect_stats_update.DURATION_AVG = long.Parse(database_sql_connect_stats_update.DURATION_SUM_ToString) / long.Parse(database_sql_connect_stats_update.REQUEST_COUNT_ToString);
                    database_sql_connect_stats_update.CONNECT_TIMES_AVG = long.Parse(database_sql_connect_stats_update.CONNECT_TIMES_SUM_ToString) / long.Parse(database_sql_connect_stats_update.REQUEST_COUNT_ToString);

                    if (database_sql_connect_stats_update.Update() == false)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_connect_stats.Update() 失败！");
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_connect_stats.Update() 成功！,已经执行" + i.ToString() + "/" + allcount.ToString() + "条数据");
                    }
                    #endregion
                }
                else
                {
                    #region Insert
                    if (database_sql_connect_stats_update.Insert() == false)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_connect_stats_update.Insert() 失败！");
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_connect_stats_update.Insert() 成功！,已经执行" + i.ToString() + "/" + allcount.ToString() + "条数据");
                    }
                    #endregion
                }
                #endregion
            }
        }
    }
}
