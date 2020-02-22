using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace TeamToolTask
{
    public class SqlController
    {
        private static DataTable hostlist = null;
        private delegate void MyDelegate(string FromDB);
        public static void Delete_DataBase_Sql(string FromDB)
        {
            Entity.TEAMTOOL.DATABASE_SQL database_sql = new Entity.TEAMTOOL.DATABASE_SQL();
            string Sql = @"DELETE FROM [124.251.46.19]." + FromDB + @".dbo.[" + database_sql.TableName + @"] WHERE LAST_EXECUTION_TIME <=Dateadd(day,-3,getdate()) ";
            database_sql.Database_Writer.ExecuteDataSet(CommandType.Text, Sql);
        }
        public static void DataBase_Sql(string FromDB, string DataBaseNames)
        {

            DataTable oDt_database_table = null;
            DataTable oDt_database = null;
            DataTable oDt_database_sql_today = null;
            string Table_Names = "";

            string today = DateTime.Now.ToShortDateString();
            string tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
            string yestoday = DateTime.Now.AddDays(-1).ToShortDateString();
            Entity.TEAMTOOL.DATABASE_SQL database_sql = new Entity.TEAMTOOL.DATABASE_SQL();

            if (string.IsNullOrEmpty(Table_Names))
            {
                Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
                database_table.Distinct = true;
                database_table.CacheTime = 120;
                database_table.SelectColumns = new string[] { database_table._TABLE_NAME, database_table._DATABASE_NAME };
                //database_table.COUNTDATE = DateTime.Parse(yestoday);
                database_table.WhereSql = database_table._DATABASE_NAME + " IN (" + DataBaseNames + ") AND " + database_table._TABLE_NAME + " NOT IN ('INSERT','SELECT','DELETE','UPDATE','GROUP','ORDER','LIKE','WHERE','FROM')";
                oDt_database_table = database_table.Select();

                foreach (DataRow oDr_database_table in oDt_database_table.Rows)
                {
                    if (oDr_database_table[database_table._TABLE_NAME].ToString().Trim().Length > 3)
                    {
                        Table_Names += oDr_database_table[database_table._TABLE_NAME].ToString() + "|";
                    }
                }
                //----------------------------------------------------------
                //----------------------------------------------------------
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.Distinct = true;
                database_owner.CacheTime = 120;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_NAME };
                oDt_database = database_owner.Select();
                //----------------------------------------------------------
                //----------------------------------------------------------
                Entity.TEAMTOOL.DATABASE_SQL database_sql_today = new Entity.TEAMTOOL.DATABASE_SQL();
                database_sql_today.Distinct = true;
                database_sql_today.SelectColumns = new string[] { 
                    database_sql_today._ID,
                    database_sql_today._SQL_MD5,
                    database_sql_today._DATABASE_IP,
                    database_sql_today._DATABASE_USER,
                    database_sql_today._TEXT,
                    database_sql_today._CREATION_TIME,
                    database_sql_today._LAST_EXECUTION_TIME,
                    database_sql_today._EXECUTION_COUNT,
                    database_sql_today._TOTAL_WORKER_TIME,
                    database_sql_today._LAST_WORKER_TIME,
                    database_sql_today._MIN_WORKER_TIME,
                    database_sql_today._MAX_WORKER_TIME,
                    database_sql_today._TOTAL_PHYSICAL_READS,
                    database_sql_today._LAST_PHYSICAL_READS,
                    database_sql_today._MIN_PHYSICAL_READS,
                    database_sql_today._MAX_PHYSICAL_READS,
                    database_sql_today._TOTAL_LOGICAL_WRITES,
                    database_sql_today._LAST_LOGICAL_WRITES,
                    database_sql_today._MIN_LOGICAL_WRITES,
                    database_sql_today._MAX_LOGICAL_WRITES,
                    database_sql_today._TOTAL_LOGICAL_READS,
                    database_sql_today._LAST_LOGICAL_READS,
                    database_sql_today._MIN_LOGICAL_READS,
                    database_sql_today._MAX_LOGICAL_READS,
                    database_sql_today._TOTAL_ELAPSED_TIME,
                    database_sql_today._LAST_ELAPSED_TIME,
                    database_sql_today._MIN_ELAPSED_TIME,
                    database_sql_today._MAX_ELAPSED_TIME,
                    database_sql_today._TOTAL_ROWS,
                    database_sql_today._LAST_ROWS,
                    database_sql_today._MIN_ROWS,
                    database_sql_today._MAX_ROWS
                };
                database_sql_today.WhereSql = "(" + database_sql._LAST_EXECUTION_TIME + ">'" + yestoday + "' AND " + database_sql._LAST_EXECUTION_TIME + "<'" + tomorrow + "')";
                oDt_database_sql_today = database_sql_today.Select();
            }

            //同步数据
            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "开始同步[" + database_sql.TableName + @"]数据");

            string Sql = @"select top 500 max(id) as id,
	                        '' AS sql_handle,
	                        max(database_ip) as database_ip,
	                        max(database_user) as database_user,
	                        min(database_name) as database_name,
	                        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx' AS Table_Name,
	                        '' AS statement_text,
	                        sql_md5,
	                        max([text]) as [text],
	                        max(creation_time) as creation_time,
	                        max(last_execution_time) as last_execution_time,
	                        sum(execution_count) as execution_count,
	                        sum(total_worker_time) as total_worker_time,
	                        max(last_worker_time) as last_worker_time,
	                        min(min_worker_time) as min_worker_time,
	                        max(max_worker_time) as max_worker_time,
	                        sum(total_physical_reads) as total_physical_reads,
	                        max(last_physical_reads) last_physical_reads,
	                        min(min_physical_reads) as min_physical_reads,
	                        max(max_physical_reads) as max_physical_reads,
	                        sum(total_logical_writes) as total_logical_writes,
	                        max(last_logical_writes) as last_logical_writes,
	                        min(min_logical_writes) as min_logical_writes,
	                        max(max_logical_writes) as max_logical_writes,
	                        sum(total_logical_reads) as total_logical_reads,
	                        max(last_logical_reads) as last_logical_reads,
	                        min(min_logical_reads) as min_logical_reads,
	                        max(max_logical_reads) as max_logical_reads,
	                        sum(total_elapsed_time) as total_elapsed_time,
	                        max(last_elapsed_time) as last_elapsed_time,
	                        min(min_elapsed_time) as min_elapsed_time,
	                        max(max_elapsed_time) as max_elapsed_time,
	                        sum(total_rows) as total_rows,
	                        max(last_rows) as last_rows,
	                        min(min_rows) as min_rows,
	                        max(max_rows) as max_rows--,count(1) as counts
	                    from [124.251.46.19]." + FromDB + @".dbo.[" + database_sql.TableName + @"] with(nolock)
                        where sql_md5 is not null and sql_md5<>''
                        group by sql_md5";

            //                    @"where ((" + database_sql._DATABASE_NAME + " is null or " + database_sql._DATABASE_NAME + "='' ) AND " + database_sql._LAST_EXECUTION_TIME + ">'" + today + "' AND " + database_sql._LAST_EXECUTION_TIME + "<'" + tomorrow + @"') 
            //                    OR (" + database_sql._DATABASE_NAME + " is not null and " + database_sql._DATABASE_NAME + "<>'' and " + database_sql._LAST_EXECUTION_TIME + " >'" + yestoday + "' AND " + database_sql._LAST_EXECUTION_TIME + @" <'" + today + @"')  
            //                    ORDER BY " + database_sql._LAST_EXECUTION_TIME + " asc";
            DataTable oDt_DataBase_sql = database_sql.Database_Reader.ExecuteDataSet(CommandType.Text, Sql).Tables[0];

            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "开始匹配[" + database_sql.TableName + @"]数据共" + oDt_DataBase_sql.Rows.Count + "条");
            int RowCount = oDt_DataBase_sql.Rows.Count;
            int RowIndex = 0;
            foreach (DataRow oDr_DataBase_sql in oDt_DataBase_sql.Rows)
            {
                string text = oDr_DataBase_sql[database_sql._TEXT].ToString();
                string DataBase_User = oDr_DataBase_sql[database_sql._DATABASE_USER].ToString();
                if (string.IsNullOrEmpty(DataBase_User))
                {
                    string ConnectionString = Business.Sql.SqlAnalysis.GetConnectionString(text);
                    DataBase_User = Business.Sql.SqlAnalysis.GetConnectionStringDataBaseUserId(ConnectionString);
                }
                string SessionId = Business.Sql.SqlAnalysis.GetSessionId(text);
                if (!string.IsNullOrEmpty(SessionId))
                {
                    #region 收集机器名
                    string ServerInfo = Business.Sql.SqlAnalysis.GetServerInfo(text);
                    string[] serverinfos = ServerInfo.Split(';');
                    string hostip = "";
                    string hostname = serverinfos[0];
                    foreach (string info in serverinfos)
                    {
                        if (info.StartsWith("192.168.") == true)
                        {
                            hostip = info;
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(hostip) && !string.IsNullOrEmpty(hostname))
                    {
                        if (hostlist == null)
                        {
                            hostlist = new DataTable("hostlist");
                            hostlist.Columns.Add(new DataColumn("hostip", typeof(string)));
                            hostlist.Columns.Add(new DataColumn("hostname", typeof(string)));
                            hostlist.Columns.Add(new DataColumn("hosttime", typeof(string)));
                        }
                        string hosttime=System.DateTime.Now.ToString("yyyyMMdd");
                        DataRow[] oDrs_hostlist = hostlist.Select("hostip='" + hostip + "' and hosttime='" + hosttime + "'");
                        if (oDrs_hostlist == null || oDrs_hostlist.Length == 0)
                        {
                            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                            admin_webmanager.PrimaryKey = new string[] { admin_webmanager._WEBMANAGER_IP };
                            admin_webmanager.WEBMANAGER_IP = hostip;
                            admin_webmanager.WEBMANAGER_REMARK = hostname;
                            admin_webmanager.Update();
                            DataRow oDr_new = hostlist.NewRow();
                            oDr_new["hostip"] = hostip;
                            oDr_new["hostname"] = hostname;
                            oDr_new["hosttime"] = hosttime;
                            hostlist.Rows.Add(oDr_new);
                        }
                    }
                    #endregion
                }
                bool bOurs = false;
                string database_name = oDr_DataBase_sql[database_sql._DATABASE_NAME].ToString();
                string sql_md5 = oDr_DataBase_sql[database_sql._SQL_MD5].ToString();//Com.Common.EncDec.PasswordEncrypto(Business.Sql.SqlAnalysis.FormatSql(oDr_DataBase_sql[database_sql._TEXT].ToString())).ToLower();

                string Table_Name = "";
                if (!string.IsNullOrEmpty(database_name))
                {
                    foreach (DataRow oDr_database in oDt_database.Rows)
                    {
                        if (database_name.ToLower().IndexOf(oDr_database["database_name"].ToString()) > -1)
                        {
                            bOurs = true;
                            break;
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Table_Names))
                {
                    Regex reg_table = new Regex(@"(\s|\.|\[)(" + Table_Names.TrimEnd('|') + @")(\s|\])", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    MatchCollection matchs_ptable = reg_table.Matches(oDr_DataBase_sql["text"].ToString(), 0);
                    if (matchs_ptable.Count > 0)
                    {
                        Table_Name = matchs_ptable[0].Value.Trim().Replace(".", "").Replace("[", "").Replace("]", "");
                        database_name = oDt_database_table.Select("TABLE_NAME='" + Table_Name + "'")[0][database_sql._DATABASE_NAME].ToString();
                        bOurs = true;
                    }
                }
                RowIndex++;
                DateTime last_execution_time = DateTime.Parse(oDr_DataBase_sql[database_sql._LAST_EXECUTION_TIME].ToString());
                if (bOurs == true)
                {
                    Entity.TEAMTOOL.DATABASE_SQL database_sql_new = new Entity.TEAMTOOL.DATABASE_SQL();
                    #region 赋值
                    database_sql_new.SQL_MD5 = sql_md5;
                    database_sql_new.DATABASE_IP = oDr_DataBase_sql[database_sql._DATABASE_IP].ToString();
                    database_sql_new.DATABASE_USER = DataBase_User;
                    database_sql_new.DATABASE_NAME = database_name;
                    database_sql_new.TABLE_NAME = Table_Name;
                    database_sql_new.STATEMENT_TEXT = oDr_DataBase_sql[database_sql_new._STATEMENT_TEXT].ToString();
                    database_sql_new.TEXT = text;
                    database_sql_new.CREATION_TIME = DateTime.Parse(oDr_DataBase_sql[database_sql_new._CREATION_TIME].ToString());
                    database_sql_new.LAST_EXECUTION_TIME = last_execution_time;
                    database_sql_new.EXECUTION_COUNT = long.Parse(oDr_DataBase_sql[database_sql_new._EXECUTION_COUNT].ToString());
                    database_sql_new.TOTAL_WORKER_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_WORKER_TIME].ToString());
                    database_sql_new.LAST_WORKER_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_WORKER_TIME].ToString());
                    database_sql_new.MIN_WORKER_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_WORKER_TIME].ToString());
                    database_sql_new.MAX_WORKER_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_WORKER_TIME].ToString());
                    database_sql_new.TOTAL_PHYSICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_PHYSICAL_READS].ToString());
                    database_sql_new.LAST_PHYSICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_PHYSICAL_READS].ToString());
                    database_sql_new.MIN_PHYSICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_PHYSICAL_READS].ToString());
                    database_sql_new.MAX_PHYSICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_PHYSICAL_READS].ToString());
                    database_sql_new.TOTAL_LOGICAL_WRITES = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_LOGICAL_WRITES].ToString());
                    database_sql_new.LAST_LOGICAL_WRITES = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_LOGICAL_WRITES].ToString());
                    database_sql_new.MIN_LOGICAL_WRITES = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_LOGICAL_WRITES].ToString());
                    database_sql_new.MAX_LOGICAL_WRITES = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_LOGICAL_WRITES].ToString());
                    database_sql_new.TOTAL_LOGICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_LOGICAL_READS].ToString());
                    database_sql_new.LAST_LOGICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_LOGICAL_READS].ToString());
                    database_sql_new.MIN_LOGICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_LOGICAL_READS].ToString());
                    database_sql_new.MAX_LOGICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_LOGICAL_READS].ToString());
                    database_sql_new.TOTAL_ELAPSED_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_ELAPSED_TIME].ToString());
                    database_sql_new.LAST_ELAPSED_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_ELAPSED_TIME].ToString());
                    database_sql_new.MIN_ELAPSED_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_ELAPSED_TIME].ToString());
                    database_sql_new.MAX_ELAPSED_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_ELAPSED_TIME].ToString());
                    database_sql_new.TOTAL_ROWS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_ROWS].ToString());
                    database_sql_new.LAST_ROWS = long.Parse(oDr_DataBase_sql[database_sql_new._LAST_ROWS].ToString());
                    database_sql_new.MIN_ROWS = long.Parse(oDr_DataBase_sql[database_sql_new._MIN_ROWS].ToString());
                    database_sql_new.MAX_ROWS = long.Parse(oDr_DataBase_sql[database_sql_new._MAX_ROWS].ToString());
                    database_sql_new.CREATETIME = DateTime.Now;

                    //判断昨天和今天是否已经更新过此sql 
                    DataRow[] oDrs_database_sql_SqlMd5 = oDt_database_sql_today.Select(
                        database_sql._LAST_EXECUTION_TIME + ">'" + last_execution_time.ToShortDateString() +
                        "' AND " + database_sql._LAST_EXECUTION_TIME + "<'" + last_execution_time.AddDays(1).ToShortDateString() +
                        "'  AND " + database_sql._SQL_MD5 + "='" + sql_md5 + "'");
                    //string SqlSelect = "SELECT TOP 1 " + database_sql._ID + " FROM " + database_sql.TableName + " WITH(NOLOCK) WHERE " + database_sql._LAST_EXECUTION_TIME + ">'" + yestoday + "' AND " + database_sql._LAST_EXECUTION_TIME + "<'" + tomorrow + "'  AND " + database_sql._SQL_MD5 + "='" + sql_md5 + "'";

                    //DataTable oDt_database_sql_SqlMd5 = null;
                    //try
                    //{
                    //    oDt_database_sql_SqlMd5 = database_sql.Database_Reader.ExecuteDataSet(CommandType.Text, SqlSelect).Tables[0];
                    //}
                    //catch (Exception err)
                    //{
                    // Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + err.Message);
                    //}
                    #endregion
                    string error = "，第" + RowIndex + "/" + RowCount + "个,\r\nSQL执行时间 " + last_execution_time.ToString() + "," + database_name;
                    if (oDrs_database_sql_SqlMd5 != null && oDrs_database_sql_SqlMd5.Length > 0)
                    {
                        #region update
                        DataRow oDr_today = oDrs_database_sql_SqlMd5[0];

                        if (oDr_today[database_sql_new._DATABASE_IP].ToString().Length > oDr_DataBase_sql[database_sql_new._DATABASE_IP].ToString().Length)
                        {
                            database_sql_new.DATABASE_IP = oDr_today[database_sql_new._DATABASE_IP].ToString();
                        }
                        if (oDr_today[database_sql_new._DATABASE_USER].ToString().Length > oDr_DataBase_sql[database_sql_new._DATABASE_USER].ToString().Length)
                        {
                            database_sql_new.DATABASE_USER = oDr_today[database_sql_new._DATABASE_USER].ToString();
                        }

                        if (oDr_today[database_sql_new._TEXT].ToString().Length > oDr_DataBase_sql[database_sql_new._TEXT].ToString().Length)
                        {
                            database_sql_new.TEXT = oDr_today[database_sql_new._TEXT].ToString();
                        }
                        database_sql_new.CREATION_TIME = DateTime.Parse(oDr_DataBase_sql[database_sql_new._CREATION_TIME].ToString());
                        if (DateTime.Parse(oDr_today[database_sql_new._LAST_EXECUTION_TIME].ToString()) > last_execution_time)
                        {
                            database_sql_new.LAST_EXECUTION_TIME = DateTime.Parse(oDr_today[database_sql_new._LAST_EXECUTION_TIME].ToString());
                            database_sql_new.LAST_WORKER_TIME = long.Parse(oDr_today[database_sql_new._LAST_WORKER_TIME].ToString());
                            database_sql_new.LAST_PHYSICAL_READS = long.Parse(oDr_today[database_sql_new._LAST_PHYSICAL_READS].ToString());
                            database_sql_new.LAST_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_new._LAST_LOGICAL_WRITES].ToString());
                            database_sql_new.LAST_LOGICAL_READS = long.Parse(oDr_today[database_sql_new._LAST_LOGICAL_READS].ToString());
                            database_sql_new.LAST_ELAPSED_TIME = long.Parse(oDr_today[database_sql_new._LAST_ELAPSED_TIME].ToString());
                            database_sql_new.LAST_ROWS = long.Parse(oDr_today[database_sql_new._LAST_ROWS].ToString());
                        }
                        database_sql_new.EXECUTION_COUNT = long.Parse(oDr_DataBase_sql[database_sql_new._EXECUTION_COUNT].ToString()) + long.Parse(oDr_today[database_sql_new._EXECUTION_COUNT].ToString());
                        database_sql_new.TOTAL_WORKER_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_WORKER_TIME].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_WORKER_TIME].ToString()); ;
                        if (long.Parse(oDr_today[database_sql_new._MIN_WORKER_TIME].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_WORKER_TIME].ToString()))
                        {
                            database_sql_new.MIN_WORKER_TIME = long.Parse(oDr_today[database_sql_new._MIN_WORKER_TIME].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_WORKER_TIME].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_WORKER_TIME].ToString()))
                        {
                            database_sql_new.MAX_WORKER_TIME = long.Parse(oDr_today[database_sql_new._MAX_WORKER_TIME].ToString());
                        }
                        database_sql_new.TOTAL_PHYSICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_PHYSICAL_READS].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_PHYSICAL_READS].ToString());
                        if (long.Parse(oDr_today[database_sql_new._MIN_PHYSICAL_READS].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_PHYSICAL_READS].ToString()))
                        {
                            database_sql_new.MIN_PHYSICAL_READS = long.Parse(oDr_today[database_sql_new._MIN_PHYSICAL_READS].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_PHYSICAL_READS].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_PHYSICAL_READS].ToString()))
                        {
                            database_sql_new.MAX_PHYSICAL_READS = long.Parse(oDr_today[database_sql_new._MAX_PHYSICAL_READS].ToString());
                        }

                        database_sql_new.TOTAL_LOGICAL_WRITES = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_LOGICAL_WRITES].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_LOGICAL_WRITES].ToString());
                        if (long.Parse(oDr_today[database_sql_new._MIN_LOGICAL_WRITES].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_LOGICAL_WRITES].ToString()))
                        {
                            database_sql_new.MIN_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_new._MIN_LOGICAL_WRITES].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_LOGICAL_WRITES].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_LOGICAL_WRITES].ToString()))
                        {
                            database_sql_new.MAX_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_new._MAX_LOGICAL_WRITES].ToString());
                        }

                        database_sql_new.TOTAL_LOGICAL_READS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_LOGICAL_READS].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_LOGICAL_READS].ToString());
                        if (long.Parse(oDr_today[database_sql_new._MIN_LOGICAL_READS].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_LOGICAL_READS].ToString()))
                        {
                            database_sql_new.MIN_LOGICAL_READS = long.Parse(oDr_today[database_sql_new._MIN_LOGICAL_READS].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_LOGICAL_READS].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_LOGICAL_READS].ToString()))
                        {
                            database_sql_new.MAX_LOGICAL_READS = long.Parse(oDr_today[database_sql_new._MAX_LOGICAL_READS].ToString());
                        }
                        database_sql_new.TOTAL_ELAPSED_TIME = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_ELAPSED_TIME].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_ELAPSED_TIME].ToString());
                        if (long.Parse(oDr_today[database_sql_new._MIN_ELAPSED_TIME].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_ELAPSED_TIME].ToString()))
                        {
                            database_sql_new.MIN_ELAPSED_TIME = long.Parse(oDr_today[database_sql_new._MIN_ELAPSED_TIME].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_ELAPSED_TIME].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_ELAPSED_TIME].ToString()))
                        {
                            database_sql_new.MAX_ELAPSED_TIME = long.Parse(oDr_today[database_sql_new._MAX_ELAPSED_TIME].ToString());
                        }

                        database_sql_new.TOTAL_ROWS = long.Parse(oDr_DataBase_sql[database_sql_new._TOTAL_ROWS].ToString()) + long.Parse(oDr_today[database_sql_new._TOTAL_ROWS].ToString());
                        if (long.Parse(oDr_today[database_sql_new._MIN_ROWS].ToString()) < long.Parse(oDr_DataBase_sql[database_sql_new._MIN_ROWS].ToString()))
                        {
                            database_sql_new.MIN_ROWS = long.Parse(oDr_today[database_sql_new._MIN_ROWS].ToString());
                        }
                        if (long.Parse(oDr_today[database_sql_new._MAX_ROWS].ToString()) > long.Parse(oDr_DataBase_sql[database_sql_new._MAX_ROWS].ToString()))
                        {
                            database_sql_new.MAX_ROWS = long.Parse(oDr_today[database_sql_new._MAX_ROWS].ToString());
                        }
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "今日已经存在此sqlmd5:" + sql_md5);
                        int id = int.Parse(oDr_today[database_sql_new._ID].ToString());
                        database_sql_new.ID = id;
                        if (database_sql_new.Update() == true)
                        {
                            oDr_today[database_sql_new._DATABASE_IP] = database_sql_new[database_sql_new._DATABASE_IP];
                            oDr_today[database_sql_new._DATABASE_USER] = database_sql_new[database_sql_new._DATABASE_USER];
                            oDr_today[database_sql_new._TEXT] = database_sql_new[database_sql_new._TEXT];
                            oDr_today[database_sql_new._CREATION_TIME] = database_sql_new[database_sql_new._CREATION_TIME];
                            oDr_today[database_sql_new._LAST_EXECUTION_TIME] = database_sql_new[database_sql_new._LAST_EXECUTION_TIME];
                            oDr_today[database_sql_new._EXECUTION_COUNT] = database_sql_new[database_sql_new._EXECUTION_COUNT];
                            oDr_today[database_sql_new._TOTAL_WORKER_TIME] = database_sql_new[database_sql_new._TOTAL_WORKER_TIME];
                            oDr_today[database_sql_new._LAST_WORKER_TIME] = database_sql_new[database_sql_new._LAST_WORKER_TIME];
                            oDr_today[database_sql_new._MIN_WORKER_TIME] = database_sql_new[database_sql_new._MIN_WORKER_TIME];
                            oDr_today[database_sql_new._MAX_WORKER_TIME] = database_sql_new[database_sql_new._MAX_WORKER_TIME];
                            oDr_today[database_sql_new._TOTAL_PHYSICAL_READS] = database_sql_new[database_sql_new._TOTAL_PHYSICAL_READS];
                            oDr_today[database_sql_new._LAST_PHYSICAL_READS] = database_sql_new[database_sql_new._LAST_PHYSICAL_READS];
                            oDr_today[database_sql_new._MIN_PHYSICAL_READS] = database_sql_new[database_sql_new._MIN_PHYSICAL_READS];
                            oDr_today[database_sql_new._MAX_PHYSICAL_READS] = database_sql_new[database_sql_new._MAX_PHYSICAL_READS];
                            oDr_today[database_sql_new._TOTAL_LOGICAL_WRITES] = database_sql_new[database_sql_new._TOTAL_LOGICAL_WRITES];
                            oDr_today[database_sql_new._LAST_LOGICAL_WRITES] = database_sql_new[database_sql_new._LAST_LOGICAL_WRITES];
                            oDr_today[database_sql_new._MIN_LOGICAL_WRITES] = database_sql_new[database_sql_new._MIN_LOGICAL_WRITES];
                            oDr_today[database_sql_new._MAX_LOGICAL_WRITES] = database_sql_new[database_sql_new._MAX_LOGICAL_WRITES];
                            oDr_today[database_sql_new._TOTAL_LOGICAL_READS] = database_sql_new[database_sql_new._TOTAL_LOGICAL_READS];
                            oDr_today[database_sql_new._LAST_LOGICAL_READS] = database_sql_new[database_sql_new._LAST_LOGICAL_READS];
                            oDr_today[database_sql_new._MIN_LOGICAL_READS] = database_sql_new[database_sql_new._MIN_LOGICAL_READS];
                            oDr_today[database_sql_new._MAX_LOGICAL_READS] = database_sql_new[database_sql_new._MAX_LOGICAL_READS];
                            oDr_today[database_sql_new._TOTAL_ELAPSED_TIME] = database_sql_new[database_sql_new._TOTAL_ELAPSED_TIME];
                            oDr_today[database_sql_new._LAST_ELAPSED_TIME] = database_sql_new[database_sql_new._LAST_ELAPSED_TIME];
                            oDr_today[database_sql_new._MIN_ELAPSED_TIME] = database_sql_new[database_sql_new._MIN_ELAPSED_TIME];
                            oDr_today[database_sql_new._MAX_ELAPSED_TIME] = database_sql_new[database_sql_new._MAX_ELAPSED_TIME];
                            oDr_today[database_sql_new._TOTAL_ROWS] = database_sql_new[database_sql_new._TOTAL_ROWS];
                            oDr_today[database_sql_new._LAST_ROWS] = database_sql_new[database_sql_new._LAST_ROWS];
                            oDr_today[database_sql_new._MIN_ROWS] = database_sql_new[database_sql_new._MIN_ROWS];
                            oDr_today[database_sql_new._MAX_ROWS] = database_sql_new[database_sql_new._MAX_ROWS];

                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "成功Update[DataBase_sql].id=" + id + error);
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "Update[DataBase_sql].id=" + id + "失败！" + error);
                        }
                        #endregion
                    }
                    else
                    {
                        #region insert
                        int id = int.Parse(oDr_DataBase_sql[database_sql_new._ID].ToString());
                        database_sql_new.ID = id;
                        if (database_sql_new.Insert() == true)
                        {
                            DataRow oDr_today = oDt_database_sql_today.NewRow();
                            oDr_today[database_sql_new._ID] = id;
                            oDr_today[database_sql_new._SQL_MD5] = sql_md5;
                            oDr_today[database_sql_new._DATABASE_IP] = database_sql_new[database_sql_new._DATABASE_IP];
                            oDr_today[database_sql_new._DATABASE_USER] = database_sql_new[database_sql_new._DATABASE_USER];
                            oDr_today[database_sql_new._TEXT] = database_sql_new[database_sql_new._TEXT];
                            oDr_today[database_sql_new._CREATION_TIME] = database_sql_new[database_sql_new._CREATION_TIME];
                            oDr_today[database_sql_new._LAST_EXECUTION_TIME] = database_sql_new[database_sql_new._LAST_EXECUTION_TIME];
                            oDr_today[database_sql_new._EXECUTION_COUNT] = database_sql_new[database_sql_new._EXECUTION_COUNT];
                            oDr_today[database_sql_new._TOTAL_WORKER_TIME] = database_sql_new[database_sql_new._TOTAL_WORKER_TIME];
                            oDr_today[database_sql_new._LAST_WORKER_TIME] = database_sql_new[database_sql_new._LAST_WORKER_TIME];
                            oDr_today[database_sql_new._MIN_WORKER_TIME] = database_sql_new[database_sql_new._MIN_WORKER_TIME];
                            oDr_today[database_sql_new._MAX_WORKER_TIME] = database_sql_new[database_sql_new._MAX_WORKER_TIME];
                            oDr_today[database_sql_new._TOTAL_PHYSICAL_READS] = database_sql_new[database_sql_new._TOTAL_PHYSICAL_READS];
                            oDr_today[database_sql_new._LAST_PHYSICAL_READS] = database_sql_new[database_sql_new._LAST_PHYSICAL_READS];
                            oDr_today[database_sql_new._MIN_PHYSICAL_READS] = database_sql_new[database_sql_new._MIN_PHYSICAL_READS];
                            oDr_today[database_sql_new._MAX_PHYSICAL_READS] = database_sql_new[database_sql_new._MAX_PHYSICAL_READS];
                            oDr_today[database_sql_new._TOTAL_LOGICAL_WRITES] = database_sql_new[database_sql_new._TOTAL_LOGICAL_WRITES];
                            oDr_today[database_sql_new._LAST_LOGICAL_WRITES] = database_sql_new[database_sql_new._LAST_LOGICAL_WRITES];
                            oDr_today[database_sql_new._MIN_LOGICAL_WRITES] = database_sql_new[database_sql_new._MIN_LOGICAL_WRITES];
                            oDr_today[database_sql_new._MAX_LOGICAL_WRITES] = database_sql_new[database_sql_new._MAX_LOGICAL_WRITES];
                            oDr_today[database_sql_new._TOTAL_LOGICAL_READS] = database_sql_new[database_sql_new._TOTAL_LOGICAL_READS];
                            oDr_today[database_sql_new._LAST_LOGICAL_READS] = database_sql_new[database_sql_new._LAST_LOGICAL_READS];
                            oDr_today[database_sql_new._MIN_LOGICAL_READS] = database_sql_new[database_sql_new._MIN_LOGICAL_READS];
                            oDr_today[database_sql_new._MAX_LOGICAL_READS] = database_sql_new[database_sql_new._MAX_LOGICAL_READS];
                            oDr_today[database_sql_new._TOTAL_ELAPSED_TIME] = database_sql_new[database_sql_new._TOTAL_ELAPSED_TIME];
                            oDr_today[database_sql_new._LAST_ELAPSED_TIME] = database_sql_new[database_sql_new._LAST_ELAPSED_TIME];
                            oDr_today[database_sql_new._MIN_ELAPSED_TIME] = database_sql_new[database_sql_new._MIN_ELAPSED_TIME];
                            oDr_today[database_sql_new._MAX_ELAPSED_TIME] = database_sql_new[database_sql_new._MAX_ELAPSED_TIME];
                            oDr_today[database_sql_new._TOTAL_ROWS] = database_sql_new[database_sql_new._TOTAL_ROWS];
                            oDr_today[database_sql_new._LAST_ROWS] = database_sql_new[database_sql_new._LAST_ROWS];
                            oDr_today[database_sql_new._MIN_ROWS] = database_sql_new[database_sql_new._MIN_ROWS];
                            oDr_today[database_sql_new._MAX_ROWS] = database_sql_new[database_sql_new._MAX_ROWS];
                            oDt_database_sql_today.Rows.Add(oDr_today);
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "成功insert[" + database_sql.TableName + @"].id=" + id + error);
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "insert[" + database_sql.TableName + @"].id=" + id + "失败！" + error);
                        }
                        #endregion
                    }
                }
                Sql = @"delete from [124.251.46.19]." + FromDB + @".dbo.[" + database_sql.TableName + @"] WHERE SQL_MD5='" + sql_md5 + @"' AND LAST_EXECUTION_TIME<='" + last_execution_time.AddSeconds(1).ToString() + "'";
                int iDelete = database_sql.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);
                if (iDelete == 0)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "删除原始数据失败[DataBase_sql].Sql_Md5='" + sql_md5 + "'");
                }
            }
            //开始删除[DataBase_sql]三天前的数据
            MyDelegate caller = new MyDelegate(Delete_DataBase_Sql);
            caller.BeginInvoke(FromDB, null, caller);

            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "同步DataBase_sql]数据完成。");

        }
        public static void DataBase_Sql_Stats(string today, string maxtime)
        {
            Entity.TEAMTOOL.DATABASE_SQL database_sql = new Entity.TEAMTOOL.DATABASE_SQL();
            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "准备更新[DataBase_Sql_Stats]");
            //更新DataBase_Sql_Stats表
            string Sql = @"SELECT sql_md5,
	                '" + today + @"' AS Stats_Date,
	                max(database_ip) as database_ip,
	                max(database_user) as database_user,
	                database_name,
	                Table_Name,
	                MAX([text]) AS [text],
	                MAX(creation_time) AS creation_time,
	                MAX(last_execution_time) AS last_execution_time,
	                SUM(execution_count) AS execution_count,
	                SUM(total_worker_time) AS total_worker_time,
	                MAX(last_worker_time) AS last_worker_time,
	                MIN(min_worker_time) AS min_worker_time,
	                MAX(max_worker_time) AS max_worker_time,
	                SUM(total_physical_reads) AS total_physical_reads,
	                MAX(last_physical_reads) last_physical_reads,
	                MIN(min_physical_reads) AS min_physical_reads,
	                MAX(max_physical_reads) AS max_physical_reads,
	                SUM(total_logical_writes) AS total_logical_writes,
	                MAX(last_logical_writes) AS last_logical_writes,
	                MIN(min_logical_writes) AS min_logical_writes,
	                MAX(max_logical_writes) AS max_logical_writes,
	                SUM(total_logical_reads) AS total_logical_reads,
	                MAX(last_logical_reads) AS last_logical_reads,
	                MIN(min_logical_reads) AS min_logical_reads,
	                MAX(max_logical_reads) AS max_logical_reads,
	                SUM(total_elapsed_time) AS total_elapsed_time,
	                MAX(last_elapsed_time) AS last_elapsed_time,
	                MIN(min_elapsed_time) AS min_elapsed_time,
	                MAX(max_elapsed_time) AS max_elapsed_time,
	                SUM(total_rows) AS total_rows,
	                MAX(last_rows) AS last_rows,
	                MIN(min_rows) AS min_rows,
	                MAX(max_rows) AS max_rows,
	                MAX(createtime) AS createtime,
	                COUNT(1) AS counts

                    FROM [DataBase_sql] WITH(NOLOCK)
                    WHERE last_execution_time >='" + today + @"' AND last_execution_time<'" + maxtime + @"'
					AND createtime>(select isnull(max(createtime),'1900-1-1') from [DataBase_sql_Stats] WITH(NOLOCK) 
                                    where last_execution_time >='" + today + @"' AND  last_execution_time<'" + maxtime + @"') 
                    GROUP BY sql_md5,database_name,Table_Name";
            DataTable oDt_DataBase_Sql_Stats = database_sql.Database_Reader.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "统计出新的sql:" + oDt_DataBase_Sql_Stats.Rows.Count.ToString() + "条,开始重新根据出处计算sql_md5。");

            foreach (DataRow oDr_DataBase_Sql_Stats in oDt_DataBase_Sql_Stats.Rows)
            {

                string source_md5 = Business.Sql.SqlAnalysis.GetSourceMd5(oDr_DataBase_Sql_Stats["text"].ToString());
                if (string.IsNullOrEmpty(source_md5))
                {
                    source_md5 = oDr_DataBase_Sql_Stats["sql_md5"].ToString();
                }
                string WebManager_Name = "";
                string WebManager_RealName = ""; 
                SqlMatchController.FindSeemLikeWebmanager(oDr_DataBase_Sql_Stats[database_sql._TEXT].ToString(), source_md5, out  WebManager_Name, out  WebManager_RealName);//找出疑似负责人

                Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_today = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                database_sql_stats_today.SQL_MD5 = oDr_DataBase_Sql_Stats[database_sql_stats_today._SQL_MD5].ToString();
                database_sql_stats_today.STATS_DATE = DateTime.Parse(today);
                DataRow oDr_today = database_sql_stats_today.SelectTop1();
                if (oDr_today != null)
                {
                    #region 今日已经存在此Sql_Md5
                    Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                    database_sql_stats.SEEMLIKE_WEBMANAGER_NAME = WebManager_Name;
                    database_sql_stats.SEEMLIKE_WEBMANAGER_REALNAME = WebManager_RealName;
                    database_sql_stats.SOURCE_MD5 = source_md5;
                    database_sql_stats.SQL_MD5 = oDr_DataBase_Sql_Stats[database_sql_stats._SQL_MD5].ToString();
                    database_sql_stats.STATS_DATE = DateTime.Parse(today);
                    database_sql_stats.DATABASE_NAME = oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_NAME].ToString();
                    database_sql_stats.TABLE_NAME = oDr_DataBase_Sql_Stats[database_sql_stats._TABLE_NAME].ToString();
                    database_sql_stats.STATEMENT_TEXT = "";

                    if (oDr_today[database_sql_stats._DATABASE_IP].ToString().Length > oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_IP].ToString().Length)
                    {
                        database_sql_stats.DATABASE_IP = oDr_today[database_sql_stats._DATABASE_IP].ToString();
                    }
                    if (oDr_today[database_sql_stats._DATABASE_USER].ToString().Length > oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_USER].ToString().Length)
                    {
                        database_sql_stats.DATABASE_USER = oDr_today[database_sql_stats._DATABASE_USER].ToString();
                    }


                    if (oDr_today[database_sql_stats._TEXT].ToString().Length > oDr_DataBase_Sql_Stats[database_sql_stats._TEXT].ToString().Length)
                    {
                        database_sql_stats.TEXT = oDr_today[database_sql_stats._TEXT].ToString();
                    }
                    database_sql_stats.CREATION_TIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATION_TIME].ToString());
                    if (DateTime.Parse(oDr_today[database_sql_stats._LAST_EXECUTION_TIME].ToString()) > DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_EXECUTION_TIME].ToString()))
                    {
                        database_sql_stats.LAST_EXECUTION_TIME = DateTime.Parse(oDr_today[database_sql_stats._LAST_EXECUTION_TIME].ToString());
                        database_sql_stats.LAST_WORKER_TIME = long.Parse(oDr_today[database_sql_stats._LAST_WORKER_TIME].ToString());
                        database_sql_stats.LAST_PHYSICAL_READS = long.Parse(oDr_today[database_sql_stats._LAST_PHYSICAL_READS].ToString());
                        database_sql_stats.LAST_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_stats._LAST_LOGICAL_WRITES].ToString());
                        database_sql_stats.LAST_LOGICAL_READS = long.Parse(oDr_today[database_sql_stats._LAST_LOGICAL_READS].ToString());
                        database_sql_stats.LAST_ELAPSED_TIME = long.Parse(oDr_today[database_sql_stats._LAST_ELAPSED_TIME].ToString());
                        database_sql_stats.LAST_ROWS = long.Parse(oDr_today[database_sql_stats._LAST_ROWS].ToString());
                    }
                    database_sql_stats.EXECUTION_COUNT = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._EXECUTION_COUNT].ToString()) + long.Parse(oDr_today[database_sql_stats._EXECUTION_COUNT].ToString());
                    database_sql_stats.TOTAL_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_WORKER_TIME].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_WORKER_TIME].ToString()); ;
                    if (long.Parse(oDr_today[database_sql_stats._MIN_WORKER_TIME].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_WORKER_TIME].ToString()))
                    {
                        database_sql_stats.MIN_WORKER_TIME = long.Parse(oDr_today[database_sql_stats._MIN_WORKER_TIME].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_WORKER_TIME].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_WORKER_TIME].ToString()))
                    {
                        database_sql_stats.MAX_WORKER_TIME = long.Parse(oDr_today[database_sql_stats._MAX_WORKER_TIME].ToString());
                    }
                    database_sql_stats.TOTAL_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_PHYSICAL_READS].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_PHYSICAL_READS].ToString());
                    if (long.Parse(oDr_today[database_sql_stats._MIN_PHYSICAL_READS].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_PHYSICAL_READS].ToString()))
                    {
                        database_sql_stats.MIN_PHYSICAL_READS = long.Parse(oDr_today[database_sql_stats._MIN_PHYSICAL_READS].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_PHYSICAL_READS].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_PHYSICAL_READS].ToString()))
                    {
                        database_sql_stats.MAX_PHYSICAL_READS = long.Parse(oDr_today[database_sql_stats._MAX_PHYSICAL_READS].ToString());
                    }

                    database_sql_stats.TOTAL_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_WRITES].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_LOGICAL_WRITES].ToString());
                    if (long.Parse(oDr_today[database_sql_stats._MIN_LOGICAL_WRITES].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_WRITES].ToString()))
                    {
                        database_sql_stats.MIN_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_stats._MIN_LOGICAL_WRITES].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_LOGICAL_WRITES].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_WRITES].ToString()))
                    {
                        database_sql_stats.MAX_LOGICAL_WRITES = long.Parse(oDr_today[database_sql_stats._MAX_LOGICAL_WRITES].ToString());
                    }

                    database_sql_stats.TOTAL_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_READS].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_LOGICAL_READS].ToString());
                    if (long.Parse(oDr_today[database_sql_stats._MIN_LOGICAL_READS].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_READS].ToString()))
                    {
                        database_sql_stats.MIN_LOGICAL_READS = long.Parse(oDr_today[database_sql_stats._MIN_LOGICAL_READS].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_LOGICAL_READS].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_READS].ToString()))
                    {
                        database_sql_stats.MAX_LOGICAL_READS = long.Parse(oDr_today[database_sql_stats._MAX_LOGICAL_READS].ToString());
                    }
                    database_sql_stats.TOTAL_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ELAPSED_TIME].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_ELAPSED_TIME].ToString());
                    if (long.Parse(oDr_today[database_sql_stats._MIN_ELAPSED_TIME].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ELAPSED_TIME].ToString()))
                    {
                        database_sql_stats.MIN_ELAPSED_TIME = long.Parse(oDr_today[database_sql_stats._MIN_ELAPSED_TIME].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_ELAPSED_TIME].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ELAPSED_TIME].ToString()))
                    {
                        database_sql_stats.MAX_ELAPSED_TIME = long.Parse(oDr_today[database_sql_stats._MAX_ELAPSED_TIME].ToString());
                    }

                    database_sql_stats.TOTAL_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ROWS].ToString()) + long.Parse(oDr_today[database_sql_stats._TOTAL_ROWS].ToString());
                    if (long.Parse(oDr_today[database_sql_stats._MIN_ROWS].ToString()) < long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ROWS].ToString()))
                    {
                        database_sql_stats.MIN_ROWS = long.Parse(oDr_today[database_sql_stats._MIN_ROWS].ToString());
                    }
                    if (long.Parse(oDr_today[database_sql_stats._MAX_ROWS].ToString()) > long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ROWS].ToString()))
                    {
                        database_sql_stats.MAX_ROWS = long.Parse(oDr_today[database_sql_stats._MAX_ROWS].ToString());
                    }
                    database_sql_stats.CREATETIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATETIME].ToString());

                    /*
                    database_sql_stats.TEXT = oDr_DataBase_Sql_Stats[database_sql_stats._TEXT].ToString();
                    database_sql_stats.CREATION_TIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATION_TIME].ToString());
                    database_sql_stats.LAST_EXECUTION_TIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_EXECUTION_TIME].ToString());
                    database_sql_stats.EXECUTION_COUNT = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._EXECUTION_COUNT].ToString());
                    database_sql_stats.TOTAL_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_WORKER_TIME].ToString());
                    database_sql_stats.LAST_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_WORKER_TIME].ToString());
                    database_sql_stats.MIN_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_WORKER_TIME].ToString());
                    database_sql_stats.MAX_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_WORKER_TIME].ToString());
                    database_sql_stats.TOTAL_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_PHYSICAL_READS].ToString());
                    database_sql_stats.LAST_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_PHYSICAL_READS].ToString());
                    
                    database_sql_stats.MIN_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_PHYSICAL_READS].ToString());
                    database_sql_stats.MAX_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_PHYSICAL_READS].ToString());
                    database_sql_stats.TOTAL_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_WRITES].ToString());
                    database_sql_stats.LAST_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_LOGICAL_WRITES].ToString());
                    database_sql_stats.MIN_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_WRITES].ToString());
                    database_sql_stats.MAX_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_WRITES].ToString());
                    database_sql_stats.TOTAL_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_READS].ToString());
                    database_sql_stats.LAST_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_LOGICAL_READS].ToString());
                    database_sql_stats.MIN_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_READS].ToString());
                    database_sql_stats.MAX_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_READS].ToString());

                    database_sql_stats.TOTAL_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ELAPSED_TIME].ToString());
                    database_sql_stats.LAST_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_ELAPSED_TIME].ToString());
                    database_sql_stats.MIN_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ELAPSED_TIME].ToString());
                    database_sql_stats.MAX_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ELAPSED_TIME].ToString());
                    database_sql_stats.TOTAL_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ROWS].ToString());
                    database_sql_stats.LAST_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_ROWS].ToString());
                    database_sql_stats.MIN_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ROWS].ToString());
                    database_sql_stats.MAX_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ROWS].ToString());
                    database_sql_stats.CREATETIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATETIME].ToString());
                    */

                    database_sql_stats.ANALYSIS = 0;
                    #endregion

                    string error = "\r\nSQL执行时间 " + oDr_DataBase_Sql_Stats[database_sql_stats._LAST_EXECUTION_TIME].ToString() + "," + oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_NAME].ToString();
                    if (database_sql_stats.Update() == true)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "成功Update记录[DataBase_sql_Stats].sql_md5=" + oDr_DataBase_Sql_Stats["sql_md5"].ToString());
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "Update记录[DataBase_sql_Stats].sql_md5=" + oDr_DataBase_Sql_Stats["sql_md5"].ToString() + "失败！");
                    }
                }
                else
                {
                    #region 更新[DataBase_sql_Stats]记录

                    Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();

                    database_sql_stats.SEEMLIKE_WEBMANAGER_NAME = WebManager_Name;
                    database_sql_stats.SEEMLIKE_WEBMANAGER_REALNAME = WebManager_RealName;
                    database_sql_stats.SOURCE_MD5 = source_md5;
                    database_sql_stats.SQL_MD5 = oDr_DataBase_Sql_Stats[database_sql_stats._SQL_MD5].ToString();
                    database_sql_stats.STATS_DATE = DateTime.Parse(today);
                    database_sql_stats.DATABASE_IP = oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_IP].ToString();
                    database_sql_stats.DATABASE_USER = oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_USER].ToString();
                    database_sql_stats.DATABASE_NAME = oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_NAME].ToString();
                    database_sql_stats.TABLE_NAME = oDr_DataBase_Sql_Stats[database_sql_stats._TABLE_NAME].ToString();
                    database_sql_stats.STATEMENT_TEXT = "";
                    database_sql_stats.TEXT = oDr_DataBase_Sql_Stats[database_sql_stats._TEXT].ToString();
                    database_sql_stats.CREATION_TIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATION_TIME].ToString());
                    database_sql_stats.LAST_EXECUTION_TIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_EXECUTION_TIME].ToString());
                    database_sql_stats.EXECUTION_COUNT = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._EXECUTION_COUNT].ToString());
                    database_sql_stats.TOTAL_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_WORKER_TIME].ToString());
                    database_sql_stats.LAST_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_WORKER_TIME].ToString());
                    database_sql_stats.MIN_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_WORKER_TIME].ToString());
                    database_sql_stats.MAX_WORKER_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_WORKER_TIME].ToString());
                    database_sql_stats.TOTAL_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_PHYSICAL_READS].ToString());
                    database_sql_stats.LAST_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_PHYSICAL_READS].ToString());
                    database_sql_stats.MIN_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_PHYSICAL_READS].ToString());
                    database_sql_stats.MAX_PHYSICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_PHYSICAL_READS].ToString());
                    database_sql_stats.TOTAL_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_WRITES].ToString());
                    database_sql_stats.LAST_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_LOGICAL_WRITES].ToString());
                    database_sql_stats.MIN_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_WRITES].ToString());
                    database_sql_stats.MAX_LOGICAL_WRITES = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_WRITES].ToString());
                    database_sql_stats.TOTAL_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_LOGICAL_READS].ToString());
                    database_sql_stats.LAST_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_LOGICAL_READS].ToString());
                    database_sql_stats.MIN_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_LOGICAL_READS].ToString());
                    database_sql_stats.MAX_LOGICAL_READS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_LOGICAL_READS].ToString());
                    database_sql_stats.TOTAL_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ELAPSED_TIME].ToString());
                    database_sql_stats.LAST_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_ELAPSED_TIME].ToString());
                    database_sql_stats.MIN_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ELAPSED_TIME].ToString());
                    database_sql_stats.MAX_ELAPSED_TIME = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ELAPSED_TIME].ToString());
                    database_sql_stats.TOTAL_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._TOTAL_ROWS].ToString());
                    database_sql_stats.LAST_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._LAST_ROWS].ToString());
                    database_sql_stats.MIN_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MIN_ROWS].ToString());
                    database_sql_stats.MAX_ROWS = long.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._MAX_ROWS].ToString());
                    database_sql_stats.CREATETIME = DateTime.Parse(oDr_DataBase_Sql_Stats[database_sql_stats._CREATETIME].ToString());
                    database_sql_stats.ANALYSIS = 0;
                    string error = "\r\nSQL执行时间 " + oDr_DataBase_Sql_Stats[database_sql_stats._LAST_EXECUTION_TIME].ToString() + "," + oDr_DataBase_Sql_Stats[database_sql_stats._DATABASE_NAME].ToString();
                    if (database_sql_stats.Insert() == true)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "成功Insert记录[DataBase_sql_Stats].sql_md5=" + oDr_DataBase_Sql_Stats["sql_md5"].ToString());
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "Insert记录[DataBase_sql_Stats].sql_md5=" + oDr_DataBase_Sql_Stats["sql_md5"].ToString() + "失败！");
                    }
                    #endregion
                }

                #region 更新[DataBase_Sql_My]记录
                //Entity.TEAMTOOL.DATABASE_SQL_MY dataBase_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
                //dataBase_sql_my.SQL_MD5 = oDr_DataBase_Sql_Stats["sql_md5"].ToString();

                #endregion

            }
            //开始删除[DataBase_sql]三天前的数据
            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "开始删除[DataBase_sql]三天前的数据。");
            Sql = @"DELETE FROM [DataBase_sql] where createtime<=Dateadd(day,-3,getdate());
                    DELETE FROM [DataBase_Sql_Connect_Stats] where createtime<=Dateadd(day,-3,getdate());
                    DELETE FROM [DataBase_Sql_Stats] where createtime<=Dateadd(day,-3,getdate());
                    DELETE FROM [DataBase_Sql_Connect_Log] where createtime<=Dateadd(day,-3,getdate()); ";
            database_sql.Database_Writer.ExecuteDataSet(CommandType.Text, Sql);

        }
        public static void DataBase_Sql_Analysis()
        {
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats.ANALYSIS = 0;
            DataTable oDt = database_sql_stats.Select();

            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.SelectColumns = new string[] { database_table._TABLE_NAME };
            database_table.COUNTDATE = System.DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            database_table.Distinct = true;
            database_table.CacheTime = 120;
            DataTable oDt_database_table = database_table.Select();


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
                    if (update_database_sql_stats.Update() == false)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "update_database_sql_stats.Update()失败！SQL_MD5=" + oDr[database_sql_stats._SQL_MD5].ToString());
                    }

                }
            }
        }
    }
}
