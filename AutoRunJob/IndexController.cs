using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace TeamToolTask
{
    public class IndexController
    {
        private static DataTable oDt_Update = null;
        public static void Monitor()
        {
            if (oDt_Update == null)
            {
                oDt_Update = new DataTable();
                oDt_Update.Columns.Add(new DataColumn("Date",typeof(string)));
            }
            DataRow[] oDrs=oDt_Update.Select("Date='"+DateTime.Now.ToShortDateString()+"'");
            if (oDrs != null && oDrs.Length > 0)
            {
                return;
            }
            else
            {
                #region 获取数据库列表
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.DATABASE_IS_MAIN = 1;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
                database_owner.Select();
                #endregion
                while (database_owner.Next())
                {

                    try
                    {
                        #region 获取index列表
                        Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                        DataTable oDt_Index = Database_Owner.ExecuteDataSet(CommandType.Text, @"
                                                                                            SELECT DISTINCT
                                                                                                '" + database_owner.DATABASE_NAME + @"' AS DataBase_Name,
	                                                                                            c.name AS Table_Name,
	                                                                                            a.name AS Index_Name,
	                                                                                            d.name AS Column_Name,
	                                                                                            d.Colid AS Colid,
                                                                                                null AS Like_WebManager_name,
                                                                                                null AS Like_WebManager_realname,
                                                                                                null AS WebManager_name,
                                                                                                null AS WebManager_realname,
                                                                                                getdate() AS CreateTime
                                                                                            FROM sysindexes a
                                                                                            JOIN sysindexkeys b
	                                                                                            ON a.id = b.id
	                                                                                            AND a.indid = b.indid
                                                                                            JOIN sysobjects c
	                                                                                            ON b.id = c.id
                                                                                            JOIN syscolumns d
	                                                                                            ON b.id = d.id
	                                                                                            AND b.colid = d.colid
                                                                                            WHERE a.indid NOT IN (0, 255)
                                                                                            AND c.xtype = 'U'
                                                                                            --AND c.name = 'UserAndProjMainTable' --查指定表  
                                                                                            ORDER BY c.name, a.name").Tables[0];
                        #endregion
                        if (oDt_Index != null && oDt_Index.Rows.Count > 0)
                        {

                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "远程抓取" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库索引完成,准备导入本地库!");
                            Entity.TEAMTOOL.DATABASE_TABLE_INDEX database_table_index = new Entity.TEAMTOOL.DATABASE_TABLE_INDEX();
                            database_table_index.DATABASE_NAME = database_owner.DATABASE_NAME;
                            if (database_table_index.Delete() == true)
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "删除" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "所有本地索引记录完成,准备Insert!");
                                #region 更新本地记录
                                if (database_table_index.BulkCopy(oDt_Index) == true)
                                {
                                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "BulkCopy更新" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "所有索引到本地数据库成功!");
                                }
                                else
                                {
                                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "BulkCopy更新" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "所有索引到本地数据库失败!启动逐条更新");
                                    foreach (DataRow oDr_Index in oDt_Index.Rows)
                                    {
                                        if (Insert(database_owner.DATABASE_NAME, oDr_Index) == true)
                                        {
                                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "插入" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "." + oDr_Index[database_table_index._TABLE_NAME].ToString() + "." + oDr_Index[database_table_index._INDEX_NAME].ToString() + "到本地数据库成功!");
                                        }
                                        else
                                        {
                                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "插入" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "." + oDr_Index[database_table_index._TABLE_NAME].ToString() + "." + oDr_Index[database_table_index._INDEX_NAME].ToString() + "到本地数据库失败!");
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "删除" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "所有本地索引记录失败!");
                            }
                        }
                    }
                    catch
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "远程抓取" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库索引失败!");
                    }
                }
                DataRow oDr_New = oDt_Update.NewRow();
                oDr_New["Date"] = DateTime.Now.ToShortDateString();
                oDt_Update.Rows.Add(oDr_New);
            }

        }
        private static bool Insert(string DATABASE_NAME, DataRow oDr)
        {
            #region 插入本地数据库
            Entity.TEAMTOOL.DATABASE_TABLE_INDEX database_table_index = new Entity.TEAMTOOL.DATABASE_TABLE_INDEX();
            database_table_index.DATABASE_NAME = DATABASE_NAME;
            database_table_index.TABLE_NAME = oDr[database_table_index._TABLE_NAME].ToString();
            database_table_index.INDEX_NAME = oDr[database_table_index._INDEX_NAME].ToString();
            database_table_index.COLUMN_NAME = oDr[database_table_index._COLUMN_NAME].ToString();
            database_table_index.COLID = int.Parse(oDr[database_table_index._COLID].ToString());
            database_table_index.LIKE_WEBMANAGER_NAME = oDr[database_table_index._LIKE_WEBMANAGER_NAME].ToString();
            database_table_index.LIKE_WEBMANAGER_REALNAME = oDr[database_table_index._LIKE_WEBMANAGER_REALNAME].ToString();
            database_table_index.WEBMANAGER_NAME = oDr[database_table_index._WEBMANAGER_NAME].ToString();
            database_table_index.WEBMANAGER_REALNAME = oDr[database_table_index._WEBMANAGER_REALNAME].ToString();
            database_table_index.CREATETIME = System.DateTime.Now;
            bool bResult = database_table_index.Insert();
            return bResult;
            #endregion
        }
    }
}
