using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Business.DataBase
{
    public class DataBase_Table_My
    {
        /// <summary>
        /// 匹配认领人
        /// </summary>
        /// <param name="oDt"></param>
        /// <param name="CurrentWebManagerName"></param>
        public static void MatchMine(DataTable oDt, string CurrentWebManagerName)
        {
            Entity.TEAMTOOL.DATABASE_TABLE_MY database_table_my_all = new Entity.TEAMTOOL.DATABASE_TABLE_MY();
            database_table_my_all.SelectColumns = new string[] { 
                database_table_my_all._DATABASE_NAME, 
                database_table_my_all._TABLE_NAME, 
                database_table_my_all._WEBMANAGER_NAME, 
                database_table_my_all._WEBMANAGER_REALNAME 
            };
            database_table_my_all.CacheTime = 1440;
            database_table_my_all.CacheName = "database_table_my_all";
            DataTable oDt_database_table_my_all = database_table_my_all.Select();
            //---------------------------------
            oDt.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            oDt.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            oDt.Columns.Add(new DataColumn("IsMy", typeof(int)));

            foreach (DataRow oDr in oDt.Rows)
            {
                DataRow[] oDrs = oDt_database_table_my_all.Select(
                    database_table_my_all._DATABASE_NAME + "='" + oDr[database_table_my_all._DATABASE_NAME].ToString() + "' AND " +
                    database_table_my_all._TABLE_NAME + "='" + oDr[database_table_my_all._TABLE_NAME].ToString() + "'");
                if (oDrs != null && oDrs.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr1 in oDrs)
                    {
                        WebManager_Name += oDr1[database_table_my_all._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr1["WebManager_RealName"].ToString() + ",";
                        if (oDr1[database_table_my_all._WEBMANAGER_NAME].ToString() == CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr[database_table_my_all._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr["IsMy"] = IsMy;
                }
            }
        }
    }
}
