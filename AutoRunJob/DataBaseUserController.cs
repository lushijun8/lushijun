using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class DataBaseUserController
    {
        public static void Monitor()
        {
            #region 获取数据库列表
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.DATABASE_IS_MAIN = 1;
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
            database_owner.Select();
            #endregion

            Entity.TEAMTOOL.DATABASE_USER database_user_truncate = new Entity.TEAMTOOL.DATABASE_USER();
            if (database_user_truncate.TruncateTable() == true)
            {

                while (database_owner.Next())
                {
                    try
                    {
                        #region 获取数据库用户列表
                        Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                        DataTable oDt_User = Database_Owner.ExecuteDataSet(CommandType.Text, @"select 
                                                                                                    cast(100000000 as int ) as id,'" + database_owner.DATABASE_IP_ROMOTE + @"' as DataBase_IP_Romote,'" + database_owner.DATABASE_NAME + @"' as DataBase_Name,
                                                                                                    a.name as uName,a.status as uStatus,
                                                                                                      b.uid as rId,b.status as rStatus,b.name as rName,getdate() as CreateTime
                                                                                                    from sysusers a left join sysmembers m on m.memberuid = a.uid 
                                                                                                        left join sysusers b on b.gid = m.groupuid").Tables[0];

                        #endregion
                        Entity.TEAMTOOL.DATABASE_USER database_user = new Entity.TEAMTOOL.DATABASE_USER();
                        database_user.WhereSql = "1<>1";
                        database_user.SelectColumns = new string[] { "*" };
                        DataTable oDt_database_user = database_user.Select(1);

                        foreach (DataRow oDr_User in oDt_User.Rows)
                        {
                            #region
                            DataRow oDr_database_user = oDt_database_user.NewRow();
                            oDr_database_user.ItemArray = oDr_User.ItemArray;
                            oDt_database_user.Rows.Add(oDr_database_user);

                            #endregion
                        }
                        if (database_user.BulkCopy(oDt_database_user) == true)
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户成功!");
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户失败!");
                        }
                    }
                    catch
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户失败!");
                    }
                }
            }

            Entity.TEAMTOOL.DATABASE_USER_AUTHORITY database_user_authority_truncate = new Entity.TEAMTOOL.DATABASE_USER_AUTHORITY();
            if (database_user_authority_truncate.TruncateTable() == true)
            {
                database_owner.Clear(); database_owner.DATABASE_IS_MAIN = 1;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
                database_owner.Select();
                while (database_owner.Next())
                {
                    try
                    {
                        #region 获取数据库用户列表
                        Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                        DataTable oDt_User_Authority = Database_Owner.ExecuteDataSet(CommandType.Text, @"SELECT
	                                                                                        cast(100000000 as int ) as ID,
                                                                                        '" + database_owner.DATABASE_IP_ROMOTE + @"' as DataBase_IP_Romote,
                                                                                        '" + database_owner.DATABASE_NAME + @"' as DataBase_Name,
	                                                                                        c.name AS uName,
	                                                                                        b.name AS tName,
	                                                                                        b.type as tType,
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 26 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√																					 
		                                                                                        WHEN a.ACTION = 26 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√	
		                                                                                        ELSE '0'
	                                                                                        END AS 'tReferences',
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 195 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√																							 
		                                                                                        WHEN a.ACTION = 195 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√	
		                                                                                        ELSE '0'
	                                                                                        END AS 'tInsert',
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 193 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√
																								WHEN a.ACTION = 193 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√
		                                                                                        ELSE '0'
	                                                                                        END AS 'tSelect',
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 197 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√
																								WHEN a.ACTION = 197 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√
		                                                                                        ELSE '0'
	                                                                                        END AS 'tUpdate',
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 196 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√
																								WHEN a.ACTION = 196 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√
		                                                                                        ELSE '0'
	                                                                                        END AS 'tDelete',
	                                                                                        CASE
		                                                                                        WHEN a.ACTION = 224 AND
			                                                                                        a.PROTECTTYPE = 205 THEN '1'--√
																								WHEN a.ACTION = 224 AND
			                                                                                        a.PROTECTTYPE = 206 THEN '-1'--√
		                                                                                        ELSE '0'
	                                                                                        END AS 'tExecute',
	                                                                                        CASE a.PROTECTTYPE
		                                                                                        WHEN 204 THEN 'GRANT_W_GRANT '
		                                                                                        WHEN 205 THEN '授予'
		                                                                                        WHEN 206 THEN '拒绝'
		                                                                                        ELSE 'OTHER'  --当有other出现的时候，需要将其他的PROTECTTYPE添加进去。
	                                                                                        END AS ProtectType,
	                                                                                        CASE a.PROTECTTYPE
                                                                                            WHEN 204 THEN 'GRANT_W_GRANT '
                                                                                            WHEN 205 THEN 'GRANT '
                                                                                            WHEN 206 THEN 'DENY '
                                                                                             ELSE 'OTHER ' end   +  CASE a.ACTION
		                                                                                        WHEN 26 THEN 'REFERENCES'
		                                                                                        WHEN 193 THEN 'SELECT'
		                                                                                        WHEN 195 THEN 'INSERT'
		                                                                                        WHEN 196 THEN 'DELETE'
		                                                                                        WHEN 197 THEN 'UPDATE'
		                                                                                        WHEN 224 THEN 'EXECUTE'
		                                                                                        ELSE 'OTHER' --当有other出现的时候，需要将其他的ACTION类型添加进去。 
	                                                                                        END + ' ON ' + b.name + ' TO ' + c.name as ProtectTypeSql,
                                                                                        getdate() as CreateTime
                                                                                        FROM sysprotects a
                                                                                        INNER JOIN sysobjects b
	                                                                                        ON a.id = b.id
                                                                                        INNER JOIN sysusers c
	                                                                                        ON a.uid = c.uid
                                                                                         ORDER BY uname ").Tables[0];

                        #endregion
                        Entity.TEAMTOOL.DATABASE_USER_AUTHORITY database_user_authority = new Entity.TEAMTOOL.DATABASE_USER_AUTHORITY();
                        database_user_authority.WhereSql = "1<>1";
                        database_user_authority.SelectColumns = new string[] { "*" };
                        DataTable oDt_database_user_authority = database_user_authority.Select(1);

                        foreach (DataRow oDr_User_Authority in oDt_User_Authority.Rows)
                        {
                            #region
                            DataRow oDr_database_user_authority = oDt_database_user_authority.NewRow();
                            oDr_database_user_authority.ItemArray = oDr_User_Authority.ItemArray;
                            oDt_database_user_authority.Rows.Add(oDr_database_user_authority);

                            #endregion
                        }
                        if (database_user_authority.BulkCopy(oDt_database_user_authority) == true)
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户权限成功!");
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户权限失败!");
                        }
                    }
                    catch
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "数据库用户权限失败!");
                    }
                }

            }

        }

    }
}
