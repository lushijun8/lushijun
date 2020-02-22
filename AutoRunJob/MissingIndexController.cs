using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class MissingIndexController
    {
        static DataTable oDt_DataBase = null;
        public static void Monitor()
        {
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.DATABASE_IS_MAIN = 1;
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
            DataTable oDt_database_owner = database_owner.Select();
            string database_names = "'mynone'";
            foreach (DataRow oDr_database_owner in oDt_database_owner.Rows)
            {
                database_names += ",'" + oDr_database_owner[database_owner._DATABASE_NAME].ToString() + "'";
            }
            while (database_owner.Next())
            {
                try
                {
                    #region 查询出缺失索引
                    Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                    DataTable oDt_Missing_Index = Database_Owner.ExecuteDataSet(CommandType.Text, @"SELECT '" + database_owner.DATABASE_IP_ROMOTE + "' as DATABASE_IP_ROMOTE,'" + database_owner.DATABASE_NAME + @"' as DATABASE_NAME,equality_columns, inequality_columns, included_columns, statement,
group_handle,db_missing_index_details.INDEX_HANDLE,unique_compiles,user_seeks,user_scans,last_user_seek,last_user_scan,avg_total_user_cost,avg_user_impact,system_seeks,system_scans,last_system_seek,last_system_scan,avg_total_system_cost,avg_system_impact
FROM sys.[dm_db_missing_index_details] as db_missing_index_details with(nolock) 
INNER JOIN sys.[dm_db_missing_index_groups] as db_missing_index_groups with(nolock) on db_missing_index_groups.index_handle=db_missing_index_details.index_handle
LEFT JOIN sys.[dm_db_missing_index_group_stats] as db_missing_index_group_stats with(nolock) on db_missing_index_group_stats.group_handle=db_missing_index_groups.index_group_handle
 where statement like '%" + database_owner.DATABASE_NAME + "%' and last_user_seek>'" + System.DateTime.Now.AddDays(-1).ToShortDateString() + "'").Tables[0];
                    #endregion
                    if (oDt_Missing_Index.Rows.Count > 0)
                    {
                        #region 先删除老数据
                        Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index_delete = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                        database_missing_index_delete.DATABASE_IP_ROMOTE = database_owner.DATABASE_IP_ROMOTE;
                        database_missing_index_delete.DATABASE_NAME = database_owner.DATABASE_NAME;
                        database_missing_index_delete.DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                        database_missing_index_delete.PrimaryKey = new string[] { 
                        database_missing_index_delete._DATABASE_IP_ROMOTE,
                        database_missing_index_delete._DATABASE_NAME,
                        database_missing_index_delete._DATE 
                        };
                        bool isDelete = database_missing_index_delete.Delete();
                        #endregion
                        if (isDelete == true)
                        {
                            Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                            database_missing_index.WhereSql = " 1<>1 ";
                            database_missing_index.SelectColumns = new string[] { "*" };
                            DataTable oDt_database_missing_index = database_missing_index.Select();

                            foreach (DataRow oDr in oDt_Missing_Index.Rows)
                            {
                                Insert(oDt_database_missing_index, oDr);
                            }
                            if (database_missing_index.BulkCopy(oDt_database_missing_index) == true)
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + ",database_missing_index.BulkCopy() 成功！共insert " + oDt_database_missing_index.Rows.Count + "条记录");
                            }
                            else
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_missing_index.BulkCopy() 失败！");
                                foreach (DataRow oDr in oDt_Missing_Index.Rows)
                                {
                                    Insert(oDr);
                                }
                            }
                            oDt_database_missing_index.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "缺失索引失败," + ex.Message);
                }
            }
            #region 查询出正式库缺失索引
            Database Database_Reader_xfds_moniter_r = DatabaseFactory.CreateDatabase("124.251.44.233_xfds_monitor_DataBaseInstance");
            if (oDt_DataBase == null)
            {
                oDt_DataBase = Database_Reader_xfds_moniter_r.ExecuteDataSet(CommandType.Text, @"SELECT distinct host_ip as DATABASE_IP_ROMOTE,substring(statement,2,charindex('.',statement)-3) as database_name 
                                FROM [index_monitor_byxf] WITH(NOLOCK)
                                WHERE substring(statement,2,charindex('.',statement)-3) IN (" + database_names + ")").Tables[0];
            }
            #endregion
            DataTable oDt_Indexs = Database_Reader_xfds_moniter_r.ExecuteDataSet(CommandType.Text, @"SELECT host_ip as DATABASE_IP_ROMOTE,substring(statement,2,charindex('.',statement)-3) as database_name,equality_columns, inequality_columns, included_columns, statement,
                                group_handle,INDEX_HANDLE,unique_compiles,
                                user_seeks,user_scans,last_user_seek,last_user_scan,avg_total_user_cost,
                                avg_user_impact,system_seeks,system_scans,last_system_seek,last_system_scan,
                                avg_total_system_cost,avg_system_impact
                                FROM [index_monitor_byxf] WITH(NOLOCK)
                                where substring(statement,2,charindex('.',statement)-3) IN (" + database_names + ")  and last_user_seek>'" + System.DateTime.Now.AddDays(-1).ToShortDateString() + "'").Tables[0];
            if (oDt_Indexs.Rows.Count > 0)
            {
                #region 先删除老数据
                bool isDelete = true;
                foreach (DataRow oDr_DataBase in oDt_DataBase.Rows)
                {
                    Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index_delete = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                    database_missing_index_delete.DATABASE_IP_ROMOTE = oDr_DataBase[database_owner._DATABASE_IP_ROMOTE].ToString();
                    database_missing_index_delete.DATABASE_NAME = oDr_DataBase[database_owner._DATABASE_NAME].ToString();
                    database_missing_index_delete.DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                    database_missing_index_delete.PrimaryKey = new string[] { 
                        database_missing_index_delete._DATABASE_IP_ROMOTE,
                        database_missing_index_delete._DATABASE_NAME,
                        database_missing_index_delete._DATE 
                        };
                    if (database_missing_index_delete.Delete() == false)
                    {
                        isDelete = false;
                    }
                }
                #endregion
                if (isDelete == true)
                {

                    Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                    database_missing_index.WhereSql = " 1<>1 ";
                    database_missing_index.SelectColumns = new string[] { "*" };
                    DataTable oDt_database_missing_index = database_missing_index.Select();

                    foreach (DataRow oDr in oDt_Indexs.Rows)
                    {
                        Insert(oDt_database_missing_index, oDr);
                    }
                    if (database_missing_index.BulkCopy(oDt_database_missing_index) == true)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + ",database_missing_index.BulkCopy() 成功！共insert " + oDt_database_missing_index.Rows.Count + "条记录");
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_missing_index.BulkCopy() 失败！");
                        foreach (DataRow oDr in oDt_Indexs.Rows)
                        {
                            Insert(oDr);
                        }
                    }
                    oDt_database_missing_index.Dispose();                    
                }
            }
            //int i = database_owner.Database_Writer.ExecuteNonQuery(CommandType.Text, @"update DATABASE_MISSING_INDEX set Total_Cost=ROUND(avg_total_user_cost * avg_user_impact * (user_seeks + user_scans),0) WHERE Total_Cost is NULL or Total_Cost=0");
            //if(i==0)
            //{
            //    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "更新可减少总耗时失败！");
            //}

        }
        private static bool Insert(DataRow oDr)
        {
            #region 插入一条
            Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
            database_missing_index.DATABASE_IP_ROMOTE = oDr[database_missing_index._DATABASE_IP_ROMOTE].ToString();
            database_missing_index.DATABASE_NAME = oDr[database_missing_index._DATABASE_NAME].ToString();
            database_missing_index.TABLE_NAME = oDr[database_missing_index._STATEMENT].ToString().Split('.')[2].Replace("[", "").Replace("]", "");
            database_missing_index.DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            database_missing_index.CREATETIME = DateTime.Now;
            if (!string.IsNullOrEmpty(oDr["INDEX_HANDLE"].ToString()))
            {
                database_missing_index.INDEX_HANDLE = long.Parse(oDr["INDEX_HANDLE"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["GROUP_HANDLE"].ToString()))
            {
                database_missing_index.GROUP_HANDLE = long.Parse(oDr["GROUP_HANDLE"].ToString());
            }
            database_missing_index.EQUALITY_COLUMNS = oDr["EQUALITY_COLUMNS"].ToString();
            database_missing_index.INEQUALITY_COLUMNS = oDr["INEQUALITY_COLUMNS"].ToString();
            database_missing_index.INCLUDED_COLUMNS = oDr["INCLUDED_COLUMNS"].ToString();
            database_missing_index.STATEMENT = oDr["STATEMENT"].ToString();
            if (!string.IsNullOrEmpty(oDr["UNIQUE_COMPILES"].ToString()))
            {
                database_missing_index.UNIQUE_COMPILES = long.Parse(oDr["UNIQUE_COMPILES"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["USER_SEEKS"].ToString()))
            {
                database_missing_index.USER_SEEKS = long.Parse(oDr["USER_SEEKS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["USER_SCANS"].ToString()))
            {
                database_missing_index.USER_SCANS = long.Parse(oDr["USER_SCANS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_USER_SEEK"].ToString()))
            {
                database_missing_index.LAST_USER_SEEK = DateTime.Parse(oDr["LAST_USER_SEEK"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_USER_SCAN"].ToString()))
            {
                database_missing_index.LAST_USER_SCAN = DateTime.Parse(oDr["LAST_USER_SCAN"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_TOTAL_USER_COST"].ToString()))
            {
                database_missing_index.AVG_TOTAL_USER_COST = decimal.Parse(oDr["AVG_TOTAL_USER_COST"].ToString());

                database_missing_index.TOTAL_COST = long.Parse(System.Math.Round(
               decimal.Parse(oDr["AVG_TOTAL_USER_COST"].ToString())
               * decimal.Parse(oDr["AVG_USER_IMPACT"].ToString()) *
               (decimal.Parse(oDr["USER_SEEKS"].ToString()) + decimal.Parse(oDr["USER_SCANS"].ToString())),
               0).ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_USER_IMPACT"].ToString()))
            {
                database_missing_index.AVG_USER_IMPACT = decimal.Parse(oDr["AVG_USER_IMPACT"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["SYSTEM_SEEKS"].ToString()))
            {
                database_missing_index.SYSTEM_SEEKS = long.Parse(oDr["SYSTEM_SEEKS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["SYSTEM_SCANS"].ToString()))
            {
                database_missing_index.SYSTEM_SCANS = long.Parse(oDr["SYSTEM_SCANS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_SYSTEM_SEEK"].ToString()))
            {
                database_missing_index.LAST_SYSTEM_SEEK = DateTime.Parse(oDr["LAST_SYSTEM_SEEK"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_SYSTEM_SCAN"].ToString()))
            {
                database_missing_index.LAST_SYSTEM_SCAN = DateTime.Parse(oDr["LAST_SYSTEM_SCAN"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_TOTAL_SYSTEM_COST"].ToString()))
            {
                database_missing_index.AVG_TOTAL_SYSTEM_COST = long.Parse(oDr["AVG_TOTAL_SYSTEM_COST"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_SYSTEM_IMPACT"].ToString()))
            {
                database_missing_index.AVG_SYSTEM_IMPACT = long.Parse(oDr["AVG_SYSTEM_IMPACT"].ToString());
            }
            //database_missing_index.TOTAL_COST =long.Parse(System.Math.Round(
            //    decimal.Parse(oDr["AVG_TOTAL_USER_COST"].ToString()) 
            //    * decimal.Parse(oDr["AVG_USER_IMPACT"].ToString()) * 
            //    (decimal.Parse(oDr["USER_SEEKS"].ToString()) + decimal.Parse(oDr["USER_SCANS"].ToString())),
            //    0).ToString());

            bool isInsert = database_missing_index.Insert();
            if (isInsert == false)
            {
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_missing_index.Insert()失败！");
            }
            else
            {
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "database_missing_index.Insert()成功！");
            }
            return isInsert;
            #endregion
        }
        private static void Insert(DataTable oDt_database_missing_index, DataRow oDr)
        {
            #region 插入一条
            DataRow oDr_New = oDt_database_missing_index.NewRow();
            Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();

            oDr_New[database_missing_index._DATABASE_IP_ROMOTE] = oDr[database_missing_index._DATABASE_IP_ROMOTE].ToString();
            oDr_New[database_missing_index._DATABASE_NAME] = oDr[database_missing_index._DATABASE_NAME].ToString();
            oDr_New[database_missing_index._TABLE_NAME] = oDr[database_missing_index._STATEMENT].ToString().Split('.')[2].Replace("[", "").Replace("]", "");
            oDr_New[database_missing_index._DATE] = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            oDr_New[database_missing_index._CREATETIME] = DateTime.Now;
            if (!string.IsNullOrEmpty(oDr["INDEX_HANDLE"].ToString()))
            {
                oDr_New[database_missing_index._INDEX_HANDLE] = long.Parse(oDr["INDEX_HANDLE"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["GROUP_HANDLE"].ToString()))
            {
                oDr_New[database_missing_index._GROUP_HANDLE] = long.Parse(oDr["GROUP_HANDLE"].ToString());
            }
            oDr_New[database_missing_index._EQUALITY_COLUMNS] = oDr["EQUALITY_COLUMNS"].ToString();
            oDr_New[database_missing_index._INEQUALITY_COLUMNS] = oDr["INEQUALITY_COLUMNS"].ToString();
            oDr_New[database_missing_index._INCLUDED_COLUMNS] = oDr["INCLUDED_COLUMNS"].ToString();
            oDr_New[database_missing_index._STATEMENT] = oDr["STATEMENT"].ToString();
            if (!string.IsNullOrEmpty(oDr["UNIQUE_COMPILES"].ToString()))
            {
                oDr_New[database_missing_index._UNIQUE_COMPILES] = long.Parse(oDr["UNIQUE_COMPILES"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["USER_SEEKS"].ToString()))
            {
                oDr_New[database_missing_index._USER_SEEKS] = long.Parse(oDr["USER_SEEKS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["USER_SCANS"].ToString()))
            {
                oDr_New[database_missing_index._USER_SCANS] = long.Parse(oDr["USER_SCANS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_USER_SEEK"].ToString()))
            {
                oDr_New[database_missing_index._LAST_USER_SEEK] = DateTime.Parse(oDr["LAST_USER_SEEK"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_USER_SCAN"].ToString()))
            {
                oDr_New[database_missing_index._LAST_USER_SCAN] = DateTime.Parse(oDr["LAST_USER_SCAN"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_TOTAL_USER_COST"].ToString()))
            {
                oDr_New[database_missing_index._AVG_TOTAL_USER_COST] = decimal.Parse(oDr["AVG_TOTAL_USER_COST"].ToString());

                oDr_New[database_missing_index._TOTAL_COST] = long.Parse(System.Math.Round(
              decimal.Parse(oDr["AVG_TOTAL_USER_COST"].ToString())
              * decimal.Parse(oDr["AVG_USER_IMPACT"].ToString()) *
              (decimal.Parse(oDr["USER_SEEKS"].ToString()) + decimal.Parse(oDr["USER_SCANS"].ToString())),
              0).ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_USER_IMPACT"].ToString()))
            {
                oDr_New[database_missing_index._AVG_USER_IMPACT] = decimal.Parse(oDr["AVG_USER_IMPACT"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["SYSTEM_SEEKS"].ToString()))
            {
                oDr_New[database_missing_index._SYSTEM_SEEKS] = long.Parse(oDr["SYSTEM_SEEKS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["SYSTEM_SCANS"].ToString()))
            {
                oDr_New[database_missing_index._SYSTEM_SCANS] = long.Parse(oDr["SYSTEM_SCANS"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_SYSTEM_SEEK"].ToString()))
            {
                oDr_New[database_missing_index._LAST_SYSTEM_SEEK] = DateTime.Parse(oDr["LAST_SYSTEM_SEEK"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["LAST_SYSTEM_SCAN"].ToString()))
            {
                oDr_New[database_missing_index._LAST_SYSTEM_SCAN] = DateTime.Parse(oDr["LAST_SYSTEM_SCAN"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_TOTAL_SYSTEM_COST"].ToString()))
            {
                oDr_New[database_missing_index._AVG_TOTAL_SYSTEM_COST] = long.Parse(oDr["AVG_TOTAL_SYSTEM_COST"].ToString());
            }
            if (!string.IsNullOrEmpty(oDr["AVG_SYSTEM_IMPACT"].ToString()))
            {
                oDr_New[database_missing_index._AVG_SYSTEM_IMPACT] = long.Parse(oDr["AVG_SYSTEM_IMPACT"].ToString());
            }
            oDt_database_missing_index.Rows.Add(oDr_New);
            #endregion
        }
    }
}
