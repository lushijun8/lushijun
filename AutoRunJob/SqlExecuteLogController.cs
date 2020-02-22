using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;

namespace TeamToolTask
{
    class SqlExecuteLogController
    {
        private static bool isSync = false;
        private delegate void MyDelegate();
        private delegate void AnalysisDelegate(DataTable oDt_sqlexecutelog, DataRow oDr_sqlexecutelog, int index, int allcountt, out string Ids);
        public static void Sync()
        {
            MyDelegate caller = new MyDelegate(SyncSqlExecuteLog);
            caller.BeginInvoke(null, null);
        }
        public static void SyncSqlExecuteLog()
        {
            Entity.CHANNELSALES_STATS.SQLEXECUTELOG sqlexecutelog_truncate0 = new Entity.CHANNELSALES_STATS.SQLEXECUTELOG();
            sqlexecutelog_truncate0.TruncateTable();
            //sqlexecutelog_truncate0.DeleteWhereSql = " 1=1 ";
            //sqlexecutelog_truncate0.Delete();
            return;


            //if (isSync == false)
            //{
            //    isSync = true;
            //    long loop = 0;
            Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG database_sql_connect_log = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG();
            database_sql_connect_log.WhereSql = " 1<>1 ";
            database_sql_connect_log.SelectColumns = new string[] { "*" };
            DataTable oDt_database_sql_connect_log = database_sql_connect_log.Select();
            oDt_database_sql_connect_log.Columns.Remove(database_sql_connect_log._ID);
            int loop = 20;
            int selectCount = 8000;
            for (int i = 0; i <= loop; i++)
            {
                oDt_database_sql_connect_log.Clear();
                Entity.CHANNELSALES_STATS.SQLEXECUTELOG sqlexecutelog = new Entity.CHANNELSALES_STATS.SQLEXECUTELOG();
                //sqlexecutelog.OrderBy = sqlexecutelog._ID + " ASC";
                sqlexecutelog.SelectColumns = new string[] { 
                sqlexecutelog._ID, 
                sqlexecutelog._PAGEURL, 
                sqlexecutelog._SESSIONID,
                sqlexecutelog._SERVERINFO,
                sqlexecutelog._CONNECTIONSTRING,
                sqlexecutelog._EXECUTIONTIME,                 
                sqlexecutelog._EXECUTIONTIME_END,
                sqlexecutelog._FORM
                };
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " sqlexecutelog.Select(" + selectCount + ");开始");
                DataTable oDt_sqlexecutelog = sqlexecutelog.Select(selectCount);
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " sqlexecutelog.Select(" + selectCount + ");结束");
                int allcount = oDt_sqlexecutelog.Rows.Count;
                if (allcount >= 3000)
                {
                    string Ids = "-1";
                    string Id_Min = oDt_sqlexecutelog.Rows[0][sqlexecutelog._ID].ToString();
                    string Id_Max = oDt_sqlexecutelog.Rows[oDt_sqlexecutelog.Rows.Count - 1][sqlexecutelog._ID].ToString();
                    int index = 0;
                    foreach (DataRow oDr_sqlexecutelog in oDt_sqlexecutelog.Rows)
                    {
                        index++;
                        string id = "";
                        Analysis(oDt_database_sql_connect_log, oDr_sqlexecutelog, index, allcount, out id);
                        Ids += "," + id;
                    }
                    if (database_sql_connect_log.BulkCopy(oDt_database_sql_connect_log) == true)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + ",database_sql_connect_log.BulkCopy() 成功！共insert " + oDt_database_sql_connect_log.Rows.Count + "条记录(第" + i.ToString() + "轮)");
                        #region 删除原始数据
                        Entity.CHANNELSALES_STATS.SQLEXECUTELOG sqlexecutelog_delete = new Entity.CHANNELSALES_STATS.SQLEXECUTELOG();
                        //sqlexecutelog_delete.DeleteWhereSql = sqlexecutelog_delete._ID + " IN(" + Ids + ")";
                        sqlexecutelog_delete.DeleteWhereSql = " " + sqlexecutelog_delete._ID + ">=" + Id_Min + " AND " + sqlexecutelog_delete._ID + "<=" + Id_Max + " ";
                        if (sqlexecutelog_delete.Delete() == false)
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "sqlexecutelog_delete.Delete() 失败！(第" + i.ToString() + "轮)");
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "sqlexecutelog_delete.Delete() 成功！共delete " + oDt_database_sql_connect_log.Rows.Count + "条记录(第" + i.ToString() + "轮)");
                        }
                        #endregion
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_connect_log.BulkCopy() 失败！(第" + i.ToString() + "轮)");
                    }

                    if (long.Parse(Id_Max) > 2140000000)//清除表
                    {
                        Entity.CHANNELSALES_STATS.SQLEXECUTELOG sqlexecutelog_truncate = new Entity.CHANNELSALES_STATS.SQLEXECUTELOG();
                        sqlexecutelog_truncate.TruncateTable();
                    }
                }
                oDt_sqlexecutelog.Dispose();
                if (i == loop)
                {
                    SqlConnectStatController.Stat();//统计sql连接数据库情况
                }
            }
            //}
        }
        private static void Analysis(DataTable oDt_sqlexecutelog, DataRow oDr_sqlexecutelog, int index, int allcount, out string Id)
        {
            Id = "";
            Entity.CHANNELSALES_STATS.SQLEXECUTELOG sqlexecutelog = new Entity.CHANNELSALES_STATS.SQLEXECUTELOG();
            if (oDr_sqlexecutelog[sqlexecutelog._PAGEURL].ToString() != "")
            {
                #region 分析sql执行记录
                string PageUrl = (oDr_sqlexecutelog[sqlexecutelog._PAGEURL].ToString() + "?").Split('?')[0];
                string QueryString = oDr_sqlexecutelog[sqlexecutelog._PAGEURL].ToString();
                string Form = oDr_sqlexecutelog[sqlexecutelog._FORM].ToString();

                string SessionId = oDr_sqlexecutelog[sqlexecutelog._SESSIONID].ToString();
                DateTime ExecutionTime = (DateTime)oDr_sqlexecutelog[sqlexecutelog._EXECUTIONTIME];
                DateTime ExecutionTime_End = (DateTime)oDr_sqlexecutelog[sqlexecutelog._EXECUTIONTIME_END];
                string ConnectionString = Com.Common.EncDec.Decrypt(oDr_sqlexecutelog[sqlexecutelog._CONNECTIONSTRING].ToString(), "fang.com");

                string DataBase_Ip = Business.Sql.SqlAnalysis.GetConnectionStringDataBaseIp(ConnectionString);
                string DataBase_Name = Business.Sql.SqlAnalysis.GetConnectionStringDataBaseName(ConnectionString);
                string DataBase_User = Business.Sql.SqlAnalysis.GetConnectionStringDataBaseUserId(ConnectionString);
                //求两个时间差
                System.TimeSpan ts = ExecutionTime_End - ExecutionTime;
                long Duration = Convert.ToInt64(ts.TotalMilliseconds);

                Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG database_sql_connect_log = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG();
                DataRow oDr_New = oDt_sqlexecutelog.NewRow();
                oDr_New[database_sql_connect_log._PAGEURLORFUNCTION] = PageUrl;
                oDr_New[database_sql_connect_log._PAGEURLORFUNCTION] = PageUrl;
                oDr_New[database_sql_connect_log._FORM] = Form;
                oDr_New[database_sql_connect_log._QUERYSTRING] = QueryString;
                oDr_New[database_sql_connect_log._SESSIONID] = SessionId;
                oDr_New[database_sql_connect_log._SQL_MD5] = "";
                oDr_New[database_sql_connect_log._DATABASE_IP] = DataBase_Ip;
                oDr_New[database_sql_connect_log._DATABASE_NAME] = DataBase_Name;
                oDr_New[database_sql_connect_log._DATABASE_USER] = DataBase_User;
                oDr_New[database_sql_connect_log._SERVERINFO] = oDr_sqlexecutelog[sqlexecutelog._SERVERINFO].ToString();
                oDr_New[database_sql_connect_log._EXECUTIONTIME] = ExecutionTime;
                oDr_New[database_sql_connect_log._EXECUTIONTIME_END] = ExecutionTime_End;
                oDr_New[database_sql_connect_log._DURATION] = Duration;
                oDr_New[database_sql_connect_log._CREATETIME] = DateTime.Now;
                oDt_sqlexecutelog.Rows.Add(oDr_New);
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + ",SqlExecuteLogController.Analysis()已处理第" + index.ToString() + "/" + allcount.ToString() + "条数据");

                #endregion
            }
            Id = oDr_sqlexecutelog[sqlexecutelog._ID].ToString();

        }
    }
}
