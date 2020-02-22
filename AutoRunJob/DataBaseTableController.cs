using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class DataBaseTableController
    {
        static string GetDataBaseTableDate = "";
        public static void Monitor()
        {
            if (GetDataBaseTableDate.IndexOf(DateTime.Now.ToShortDateString()) == -1)
            {
                GetDataBaseTableDate += DateTime.Now.ToShortDateString() + ";";

                string CountDate = System.DateTime.Now.ToShortDateString();
                #region 获取数据库列表
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.DATABASE_IS_MAIN = 1;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
                database_owner.Select();
                #endregion
                while (database_owner.Next())
                {
                    string DATABASE_IP_ROMOTE = database_owner.DATABASE_IP_ROMOTE;
                    if (database_owner.DATABASE_NAME.ToLower() == "teamtool")
                    {
                        DATABASE_IP_ROMOTE = "127.0.0.1";
                    }
                    string Yestoday = System.DateTime.Now.AddDays(-1).ToShortDateString();
                    string LastWeek = System.DateTime.Now.AddDays(-7).ToShortDateString();
                    string LastMonth = System.DateTime.Now.AddMonths(-1).ToShortDateString();
                    string LastYear = System.DateTime.Now.AddYears(-1).ToShortDateString();

                    string Sql = "";
                    #region 初始化表记录数据
                    Sql += @"
DELETE FROM DataBase_Table where DataBase_Name='" + database_owner.DATABASE_NAME + "' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate='" + CountDate + @"'
                                        INSERT INTO DataBase_Table(DataBase_Name, Table_Name, CountDate, DataBase_IP_Romote, RowCounts, RowCounts_Increasing, RowCounts_Increasing_Rate, ColumnCounts)
                                        SELECT DISTINCT 
                                        '" + database_owner.DATABASE_NAME + @"' as DataBase_Name,
                                        [NAME] as Table_Name,
                                        '" + CountDate + @"' as CountDate,
                                        '" + DATABASE_IP_ROMOTE + @"' as DataBase_IP_Romote,
                                        0 as RowCounts,
                                        0 as RowCounts_Increasing,
                                        0 as RowCounts_Increasing_Rate,
                                        0 as ColumnCounts 
                                        FROM [" + DATABASE_IP_ROMOTE + "].[" + database_owner.DATABASE_NAME + @"].[dbo].[SYSOBJECTS] WITH(NOLOCK)
                                        WHERE (XTYPE='U') ;
DECLARE @RC_new bigint , @RC_yestoday bigint, @RC_lastweek bigint, @RC_lastmonth bigint, @RC_lastyear bigint,
@Increasing_new bigint,@Increasing_Rate_new float,	 
@Increasing_Week_new bigint,@Increasing_Week_Rate_new float,
@Increasing_Month_new bigint,@Increasing_Month_Rate_new float,
@Increasing_Year_new bigint,@Increasing_Year_Rate_new float, @ColumnCounts_new bigint;
";
                    #endregion

                    #region 获取此数据库所有的表信息
                    Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                    DataTable oDt_Table = Database_Owner.ExecuteDataSet(CommandType.Text, @"
set nocount on
exec [sp_MSForEachTable]
@precommand=N'
create table ##(
id int identity,
DataBase_Name varchar(200),
表名 sysname,
CountDate datetime,
字段数 int,
记录数 int,
保留空间 Nvarchar(20),
使用空间 varchar(20),
索引使用空间 varchar(20),
未用空间 varchar(20))',
@command1=N'insert ##(表名,记录数,保留空间,使用空间,索引使用空间,未用空间) exec sp_spaceused ''?''
update ## set 字段数=(select count(1) from syscolumns where id=object_id(''?'')) where id=scope_identity()',
@postcommand=N'select 
id,
''" + database_owner.DATABASE_NAME + @"'' as  DataBase_Name,
表名 as Table_Name,
''" + CountDate + @"'' as CountDate,
字段数 as ColumnCounts,
记录数 as RowCounts,
(Convert(bigint,rtrim(Replace(保留空间,''KB'','''')))/1) Space_Allocation,
(Convert(bigint,rtrim(Replace(使用空间,''KB'','''')))/1) Space_Used,
(Convert(bigint,rtrim(Replace(索引使用空间,''KB'','''')))/1) Space_Index_Used,
(Convert(bigint,rtrim(Replace(未用空间,''KB'','''')))/1) Space_Available
from ## a order by [Space_Used] desc;
drop table ##'
set nocount off
").Tables[0];
                    #endregion
                    foreach (DataRow oDr_Table in oDt_Table.Rows)
                    {
                        #region 更新ColumnCounts、RowCounts、Space_Allocation、Space_Used、Space_Index_Used、Space_Available；更新增长率等
                        string Table_Name = oDr_Table["Table_Name"].ToString();
                        string RowCounts = oDr_Table["RowCounts"].ToString();
                        string ColumnCounts = oDr_Table["ColumnCounts"].ToString();
                        Sql += @"
UPDATE DataBase_Table SET RowCounts=" + RowCounts +
                            ",ColumnCounts=" + ColumnCounts +
                            ",Space_Allocation=" + oDr_Table["Space_Allocation"].ToString() +
                            ",Space_Used=" + oDr_Table["Space_Used"].ToString() +
                            ",Space_Index_Used=" + oDr_Table["Space_Index_Used"].ToString() +
                            ",Space_Available=" + oDr_Table["Space_Available"].ToString() +
                            " WHERE DataBase_Name='" + database_owner.DATABASE_NAME + "' AND Table_Name='" + Table_Name + "' AND CountDate='" + CountDate + "';";

                        Sql += @"

	select @RC_new=" + RowCounts + @";
	select @ColumnCounts_new=" + ColumnCounts + @";

	if(@RC_new=0)
	begin
		set @RC_new=1
	end 
	--------------------------本日增长情况---------------
	select @RC_yestoday=RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='" + database_owner.DATABASE_NAME + @"' and Table_Name='" + Table_Name + @"' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate='" + Yestoday + @"'
	if(@RC_yestoday is null)
	begin
		set @RC_yestoday=@RC_new
	end 
	set @Increasing_new=@RC_new-@RC_yestoday
	set @Increasing_Rate_new =(@Increasing_new*100*1.00)/(case @RC_yestoday when 0 then @RC_new else @RC_yestoday end )*1.00
	-----------------------------------------------------
	--------------------------本周增长情况---------------
	select @RC_lastweek=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='" + database_owner.DATABASE_NAME + @"' and Table_Name='" + Table_Name + @"' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate>='" + LastWeek + @"' and CountDate!='" + CountDate + @"' order by CountDate asc)
	if(@RC_lastweek is null)
	begin
		set @RC_lastweek=@RC_new
	end 
	set @Increasing_Week_new=@RC_new-@RC_lastweek
	set @Increasing_Week_Rate_new =(@Increasing_Week_new*100*1.00)/(case @RC_lastweek when 0 then @RC_new else @RC_lastweek end )*1.00
	-----------------------------------------------------
	--------------------------本月增长情况---------------
	select @RC_lastmonth=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='" + database_owner.DATABASE_NAME + @"' and Table_Name='" + Table_Name + @"' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate>='" + LastMonth + @"' and CountDate!='" + CountDate + @"' order by CountDate asc)
	if(@RC_lastmonth is null)
	begin
		set @RC_lastmonth=@RC_new
	end 
	set @Increasing_Month_new=@RC_new-@RC_lastmonth
	set @Increasing_Month_Rate_new =(@Increasing_Month_new*100*1.00)/(case @RC_lastmonth when 0 then @RC_new else @RC_lastmonth end )*1.00
	-----------------------------------------------------
	--------------------------本年增长情况---------------
	select @RC_lastyear=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='" + database_owner.DATABASE_NAME + @"' and Table_Name='" + Table_Name + @"' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate>='" + LastYear + @"' and CountDate!='" + CountDate + @"' order by CountDate asc)
	if(@RC_lastyear is null)
	begin
		set @RC_lastyear=@RC_new
	end 
	set @Increasing_Year_new=@RC_new-@RC_lastyear
	set @Increasing_Year_Rate_new =(@Increasing_Year_new*100*1.00)/(case @RC_lastyear when 0 then @RC_new else @RC_lastyear end )*1.00
	-----------------------------------------------------
	update DataBase_Table SET 
	RowCounts=@RC_new,
	ColumnCounts=@ColumnCounts_new,

	RowCounts_Increasing=isnull(@Increasing_new,0),
	RowCounts_Increasing_Rate=isnull(@Increasing_Rate_new,0),	
	
	RowCounts_Increasing_week=isnull(@Increasing_week_new,0),
	RowCounts_Increasing_week_Rate=isnull(@Increasing_week_Rate_new,0),
	
	RowCounts_Increasing_month=isnull(@Increasing_month_new,0),
	RowCounts_Increasing_month_Rate=isnull(@Increasing_month_Rate_new,0),
		
	RowCounts_Increasing_year=isnull(@Increasing_year_new,0),
	RowCounts_Increasing_year_Rate=isnull(@Increasing_year_Rate_new,0)

	where DataBase_Name='" + database_owner.DATABASE_NAME + @"' and Table_Name='" + Table_Name + @"' and DataBase_IP_Romote='" + DATABASE_IP_ROMOTE + @"' and CountDate='" + CountDate + @"' 
;";

                        #endregion
                    }
                    int i = database_owner.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " TeamTool..DataBase_Table成功更新" + DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + " 的数据,共个" + oDt_Table.Rows.Count + "表;");
                }
                string Sql1 = @"UPDATE DataBase_Owner
SET DataBase_Owner.Space_Used = DataBase_Table.Space_Used
FROM (SELECT
	DataBase_Name,
	SUM(Space_Used + Space_Index_Used) AS Space_Used
FROM DataBase_Table WITH(NOLOCK)
WHERE countDate = '" + CountDate + @"'
GROUP BY DataBase_Name) AS DataBase_Table
WHERE DataBase_Owner.database_Name = DataBase_Table.DataBase_Name
";
                int k = database_owner.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql1);
                if(k==0)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " TeamTool..DataBase_Owner更新数据库已使用空间 失败！");
                }
            }
        }
    }
}
