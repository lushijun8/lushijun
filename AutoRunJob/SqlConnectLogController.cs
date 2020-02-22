using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace TeamToolTask
{
    class SqlConnectLogController
    {
        /*
        private static bool isSync = false;
        private delegate void MyDelegate();
        public static void Sync()
        {
            MyDelegate caller = new MyDelegate(SyncConnectLog);
            caller.BeginInvoke(null, caller);
        }
        public static void SyncConnectLog()
        {
            if (isSync == false)
            {
                isSync = true;
                while (1 == 1)
                {
                    Entity.CHANNELSALES_TEST.DATABASE_SQL_BAK database_sql_bak = new Entity.CHANNELSALES_TEST.DATABASE_SQL_BAK();
                    database_sql_bak.SelectColumns = new string[] { 
                        database_sql_bak._ID,
                        "dbo.MD5(dbo.formatSQL([" + database_sql_bak._TEXT + "])) as " + database_sql_bak._SQL_MD5,
                        database_sql_bak._DATABASE_IP, 
                        database_sql_bak._DATABASE_USER, 
                        database_sql_bak._LAST_EXECUTION_TIME,
                        database_sql_bak._DURATION,
                        database_sql_bak._TEXT 
                    };
                    //database_sql_bak.WhereSql = " " + database_sql_bak._SQL_MD5 + " is not null and " + database_sql_bak._SQL_MD5 + "!=''";
                    database_sql_bak.OrderBy = database_sql_bak._ID + " ASC";
                    DataTable oDt_DataBase_sql = database_sql_bak.Select(3000);

                    int allcount = oDt_DataBase_sql.Rows.Count;
                    int i = 0;
                    foreach (DataRow oDr_DataBase_sql in oDt_DataBase_sql.Rows)
                    {
                        i++;
                        #region 分析每天sql
                        string text = oDr_DataBase_sql[database_sql_bak._TEXT].ToString();

                        string PageUrlOrFunction = Business.SqlAnalysis.GetRequestPageUrl(text);
                        if (string.IsNullOrEmpty(PageUrlOrFunction))
                        {
                            string Namespace = Business.SqlAnalysis.GetNamespace(text);
                            string Function = Business.SqlAnalysis.GetFunction(text);
                            PageUrlOrFunction = Namespace + "." + Function;
                        }
                        string DataBase_User = oDr_DataBase_sql[database_sql_bak._DATABASE_USER].ToString();
                        if (string.IsNullOrEmpty(DataBase_User))
                        {
                            string ConnectionString = Business.SqlAnalysis.GetConnectionString(text);
                            DataBase_User = Business.SqlAnalysis.GetConnectionStringDataBaseUserId(ConnectionString);
                        }
                        string SessionId = Business.SqlAnalysis.GetSessionId(text);
                        if (!string.IsNullOrEmpty(SessionId))
                        {
                            string ServerInfo = Business.SqlAnalysis.GetServerInfo(text);
                            DateTime Time = (DateTime)oDr_DataBase_sql[database_sql_bak._LAST_EXECUTION_TIME];//Business.SqlAnalysis.GetDateTime(text);
                            string ConnectionString = Business.SqlAnalysis.GetConnectionString(text);
                            string DataBase_Ip = oDr_DataBase_sql[database_sql_bak._DATABASE_IP].ToString();
                            if (string.IsNullOrEmpty(DataBase_Ip))
                            {
                                DataBase_Ip = Business.SqlAnalysis.GetConnectionStringDataBaseIp(ConnectionString);
                            }
                            string DataBase_Name = Business.SqlAnalysis.GetConnectionStringDataBaseName(ConnectionString);

                            long Duration = long.Parse(oDr_DataBase_sql[database_sql_bak._DURATION].ToString());
                            Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG database_sql_log = new Entity.TEAMTOOL.DATABASE_SQL_CONNECT_LOG();
                            database_sql_log.PAGEURLORFUNCTION = PageUrlOrFunction;
                            database_sql_log.SESSIONID = SessionId;
                            database_sql_log.SQL_MD5 = oDr_DataBase_sql[database_sql_bak._SQL_MD5].ToString();
                            database_sql_log.DATABASE_IP = DataBase_Ip;
                            database_sql_log.DATABASE_NAME = DataBase_Name;
                            database_sql_log.DATABASE_USER = DataBase_User;
                            database_sql_log.SERVERINFO = ServerInfo;
                            database_sql_log.EXECUTIONTIME = Time;
                            database_sql_log.EXECUTIONTIME_END = Time.AddMilliseconds(Duration);
                            database_sql_log.DURATION = Duration;
                            database_sql_log.CREATETIME = DateTime.Now;
                            if (database_sql_log.Insert() == false)
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_log.Insert() 失败！");
                            }
                            else
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_log.Insert() 成功！,已经执行" + i.ToString() + "/" + allcount.ToString() + "条数据");
                            }
                        }
                        Entity.CHANNELSALES_TEST.DATABASE_SQL_BAK database_sql_bak_delete = new Entity.CHANNELSALES_TEST.DATABASE_SQL_BAK();
                        database_sql_bak_delete.ID = long.Parse(oDr_DataBase_sql[database_sql_bak._ID].ToString());
                        if (database_sql_bak_delete.Delete() == false)
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_sql_bak_delete.Delete() 失败！");
                        }
                        #endregion
                    }
                    SqlConnectStatController.Stat();
                }
            }
        }
         * */
    }
}
