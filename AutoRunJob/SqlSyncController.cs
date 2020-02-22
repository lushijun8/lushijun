using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class SqlSyncController
    {
        public static void OnLineSqlSync()
        {
            string IP_Prefix = "124.251.44";
            string[] TableFixs = new string[] { "59", "155", "197", "220", "251", "253", "254" };
            //string[] TableFixs = new string[] { "59" };
            string Today = System.DateTime.Now.ToShortDateString();
            string YesToday = System.DateTime.Now.AddDays(-1).ToShortDateString();

            Database Database_Reader = DatabaseFactory.CreateDatabase(IP_Prefix + ".233_xfds_monitor_DataBaseInstance");
            Entity.CHANNELSALES_TEST.DATABASE_SQL database_sql = new Entity.CHANNELSALES_TEST.DATABASE_SQL();
            foreach (string TableFix in TableFixs)
            {
                #region 先判断有没有同步过昨天的数据
                Entity.TEAMTOOL.DATABASE_SQL_SYNC database_sql_sync_select = new Entity.TEAMTOOL.DATABASE_SQL_SYNC();
                database_sql_sync_select.DATABASE_REMOTE_IP = IP_Prefix + "." + TableFix;
                database_sql_sync_select.SYNC_DATE = DateTime.Parse(YesToday);
                if (database_sql_sync_select.SelectTop1() != null)
                {
                    Log.WriteLog("\r\n" + DateTime.Now.ToString() + "已经同步过" + IP_Prefix + "." + TableFix + "," + YesToday + "的数据！");
                    continue;
                }
                else
                {
                    #region 先判断有没有同步过
                    Entity.CHANNELSALES_TEST.DATABASE_SQL database_sql_select = new Entity.CHANNELSALES_TEST.DATABASE_SQL();
                    database_sql_select.DATABASE_NAME = IP_Prefix + "." + TableFix + ".%";
                    if (database_sql_select.SelectTop1() != null)
                    {
                        continue;
                    }
                    #endregion
                }
                #endregion
                #region 统一同步每个数据库监控到的sql到channelsales_test
                #region Sql
                string Sql = @"select top 1000000 null as sql_handle ,
                            '124.251.44." + TableFix + @"' as database_ip,
		                      LoginName as database_user,
		                      databasename as database_name,
		                      null as statement_text,
		                      cast(textData as varchar(max)) as text,
		                      StartTime as creation_time,
		                      StartTime as last_execution_time,
		                      1 as execution_count,
		                      isnull(duration,0)*1000 as total_worker_time,
		                      isnull(duration,0)*1000 as last_worker_time,
		                      isnull(duration,0)*1000 as min_worker_time,
		                      isnull(duration,0)*1000 as max_worker_time,
		                      isnull(reads,0) as total_physical_reads,
		                      isnull(reads,0) as last_physical_reads,
		                      isnull(reads,0) as min_physical_reads,
		                      isnull(reads,0) as max_physical_reads,
		                      isnull(writes,0) as total_logical_writes,
		                      isnull(writes,0) as last_logical_writes,
		                      isnull(writes,0) as min_logical_writes,
		                      isnull(writes,0) as max_logical_writes,
		                      isnull(reads,0) as total_logical_reads,
		                      isnull(reads,0) as last_logical_reads,
		                      isnull(reads,0) as min_logical_reads,
		                      isnull(reads,0) as max_logical_reads,
		                      isnull(cpu,0)*1000000 as total_elapsed_time,
		                      isnull(cpu,0)*1000000 as last_elapsed_time,
		                      isnull(cpu,0)*1000000 as min_elapsed_time,
		                      isnull(cpu,0)*1000000 as max_elapsed_time,
		                      isnull(rowcounts,0) as total_rows, 
		                      isnull(rowcounts,0) as last_rows, 
		                      isnull(rowcounts,0) as min_rows, 
		                      isnull(rowcounts,0) as max_rows 
		                      FROM [xfds_monitor].[dbo].[profile_44_" + TableFix + @"] where StartTime>'" + YesToday + "' AND StartTime<'" + Today + @"' AND DatabaseName in('tuan','channelsales','tuan_test','channelsales_test')";
                #endregion
                DataTable oDt_DataBase_Sql = Database_Reader.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
                bool bResult = database_sql.BulkCopy(oDt_DataBase_Sql, System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction | System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers);
                if (bResult == true)
                {

                    Entity.TEAMTOOL.DATABASE_SQL_SYNC database_sql_sync_insert = new Entity.TEAMTOOL.DATABASE_SQL_SYNC();
                    database_sql_sync_insert.DATABASE_REMOTE_IP = IP_Prefix + "." + TableFix;
                    database_sql_sync_insert.SYNC_DATE = DateTime.Parse(YesToday);
                    database_sql_sync_insert.SYNC_COUNT = oDt_DataBase_Sql.Rows.Count;

                    if (database_sql_sync_insert.Insert() == true)
                    {
                        Log.WriteLog("\r\n" + DateTime.Now.ToString() + "记录同步过" + IP_Prefix + "." + TableFix + "," + YesToday + "的数据成功！");
                    }
                    else
                    {

                        Log.WriteLog("\r\n" + DateTime.Now.ToString() + "记录同步过" + IP_Prefix + "." + TableFix + "," + YesToday + "的数据失败！");
                    }

                    Log.WriteLog("\r\n" + DateTime.Now.ToString() + "database_sql.BulkCopy(oDt_DataBase_Sql);" + IP_Prefix + "." + TableFix + "成功！");
                }
                else
                {
                    Log.WriteLog("\r\n" + DateTime.Now.ToString() + "database_sql.BulkCopy(oDt_DataBase_Sql);" + IP_Prefix + "." + TableFix + "失败！");
                }
                #endregion
            }
            #region update [database_sql] set sql_md5=?
            int i = database_sql.Database_Writer.ExecuteNonQuery(CommandType.Text, "update [database_sql] set sql_md5=dbo.MD5(dbo.formatSQL([text])) where sql_md5 is null or sql_md5=''");
            if (i > 0)
            {
                Log.WriteLog("\r\n" + DateTime.Now.ToString() + "update [database_sql] set sql_md5=?成功！");
            }
            else
            {
                Log.WriteLog("\r\n" + DateTime.Now.ToString() + "update [database_sql] set sql_md5=?失败！");
            }
            #endregion
        }
    }
}
