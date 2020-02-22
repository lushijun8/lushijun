
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_TABLE_MY"
    /// Columns="DATABASE_NAME,TABLE_NAME,WEBMANAGER_NAME,WEBMANAGER_REALNAME,DATABASE_IP_ROMOTE,ROWCOUNTS,ROWCOUNTS_INCREASING,ROWCOUNTS_INCREASING_RATE,ROWCOUNTS_INCREASING_WEEK,ROWCOUNTS_INCREASING_WEEK_RATE,ROWCOUNTS_INCREASING_MONTH,ROWCOUNTS_INCREASING_MONTH_RATE,ROWCOUNTS_INCREASING_YEAR,ROWCOUNTS_INCREASING_YEAR_RATE,COLUMNCOUNTS,CREATETIME"
    /// PrimaryKeys="DATABASE_NAME,TABLE_NAME,WEBMANAGER_NAME"
    /// </summary>
    public sealed class DATABASE_TABLE_MY : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/4/29 15:45:30
        #region 属性
        /// <summary>
        /// 数据库名称  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,WEBMANAGER_NAME
        /// </summary>
        public string DATABASE_NAME
        {
            get
            {
                return ColumnValues[0];
            }
            set
            {
                ColumnValues[0] = value; UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 表名  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,WEBMANAGER_NAME
        /// </summary>
        public string TABLE_NAME
        {
            get
            {
                return ColumnValues[1];
            }
            set
            {
                ColumnValues[1] = value; UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 认领人  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,WEBMANAGER_NAME
        /// </summary>
        public string WEBMANAGER_NAME
        {
            get
            {
                return ColumnValues[2];
            }
            set
            {
                ColumnValues[2] = value; UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 认领人姓名  VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
        {
            get
            {
                return ColumnValues[3];
            }
            set
            {
                ColumnValues[3] = value; UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 数据库IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_ROMOTE
        {
            get
            {
                return ColumnValues[4];
            }
            set
            {
                ColumnValues[4] = value; UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 记录数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 记录数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 今日记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 今日记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 今日记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_RATE
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 今日记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_RATE_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 本周记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_WEEK_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_WEEK
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 本周记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_WEEK
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_WEEK_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 本周记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_WEEK_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_WEEK_RATE
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 本周记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_WEEK_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_WEEK_RATE_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 本月记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_MONTH_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_MONTH
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 本月记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_MONTH
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_MONTH_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 本月记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_MONTH_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_MONTH_RATE
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 本月记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_MONTH_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_MONTH_RATE_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 本年记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_YEAR_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_YEAR
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 本年记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_YEAR
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_YEAR_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 本年记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_YEAR_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_YEAR_RATE
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 本年记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_YEAR_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_YEAR_RATE_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 列数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMNCOUNTS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long COLUMNCOUNTS
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 列数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMNCOUNTS
        ///	默认值:0
        /// </summary>
        public string COLUMNCOUNTS_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 认领时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[15] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 认领时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 表名 返回 "TABLE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLE_NAME = "TABLE_NAME";
        /// <summary>
        /// 认领人 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 认领人姓名 返回 "WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME = "WEBMANAGER_REALNAME";
        /// <summary>
        /// 数据库IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 记录数 返回 "ROWCOUNTS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS = "ROWCOUNTS";
        /// <summary>
        /// 今日记录增长情况 返回 "ROWCOUNTS_INCREASING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING = "ROWCOUNTS_INCREASING";
        /// <summary>
        /// 今日记录增长率 返回 "ROWCOUNTS_INCREASING_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_RATE = "ROWCOUNTS_INCREASING_RATE";
        /// <summary>
        /// 本周记录增长情况 返回 "ROWCOUNTS_INCREASING_WEEK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_WEEK = "ROWCOUNTS_INCREASING_WEEK";
        /// <summary>
        /// 本周记录增长率 返回 "ROWCOUNTS_INCREASING_WEEK_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_WEEK_RATE = "ROWCOUNTS_INCREASING_WEEK_RATE";
        /// <summary>
        /// 本月记录增长情况 返回 "ROWCOUNTS_INCREASING_MONTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_MONTH = "ROWCOUNTS_INCREASING_MONTH";
        /// <summary>
        /// 本月记录增长率 返回 "ROWCOUNTS_INCREASING_MONTH_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_MONTH_RATE = "ROWCOUNTS_INCREASING_MONTH_RATE";
        /// <summary>
        /// 本年记录增长情况 返回 "ROWCOUNTS_INCREASING_YEAR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_YEAR = "ROWCOUNTS_INCREASING_YEAR";
        /// <summary>
        /// 本年记录增长率 返回 "ROWCOUNTS_INCREASING_YEAR_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_YEAR_RATE = "ROWCOUNTS_INCREASING_YEAR_RATE";
        /// <summary>
        /// 列数 返回 "COLUMNCOUNTS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMNCOUNTS = "COLUMNCOUNTS";
        /// <summary>
        /// 认领时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_TABLE_MY的构造函数
        /// </summary>
        public DATABASE_TABLE_MY()
        {
            this.TableName = "DATABASE_TABLE_MY";
            this.PrimaryKey = new string[] { _DATABASE_NAME, _TABLE_NAME, _WEBMANAGER_NAME };

            this.columns = new string[] { _DATABASE_NAME, _TABLE_NAME, _WEBMANAGER_NAME, _WEBMANAGER_REALNAME, _DATABASE_IP_ROMOTE, _ROWCOUNTS, _ROWCOUNTS_INCREASING, _ROWCOUNTS_INCREASING_RATE, _ROWCOUNTS_INCREASING_WEEK, _ROWCOUNTS_INCREASING_WEEK_RATE, _ROWCOUNTS_INCREASING_MONTH, _ROWCOUNTS_INCREASING_MONTH_RATE, _ROWCOUNTS_INCREASING_YEAR, _ROWCOUNTS_INCREASING_YEAR_RATE, _COLUMNCOUNTS, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_TABLE_MY的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, BIGINT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, DATETIME };
                this.Lengths = new int[] { 50, 50, 50, 50, 50, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "getdate" };
                this.Descriptions = new string[] { "数据库名称", "表名", "认领人", "认领人姓名", "数据库IP", "记录数", "今日记录增长情况", "今日记录增长率", "本周记录增长情况", "本周记录增长率", "本月记录增长情况", "本月记录增长率", "本年记录增长情况", "本年记录增长率", "列数", "认领时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_NAME">数据库名称</param>
        /// <param name="TABLE_NAME">表名</param>
        /// <param name="WEBMANAGER_NAME">认领人</param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_NAME,string P_TABLE_NAME,string P_WEBMANAGER_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_NAME;
        this.ColumnValues[1]=P_TABLE_NAME;
        this.ColumnValues[2]=P_WEBMANAGER_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_TABLE_MY（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_TABLE_MY Copy()
                {
                    DATABASE_TABLE_MY new_obj=new DATABASE_TABLE_MY();
                    base.CopyObj(new_obj);
                    int columnindex=0;
                    foreach (string column in this.Columns)
                    {
                        new_obj.SetColumnValue(column, this[column],columnindex);
                        columnindex++;
                    }
                    return new_obj;
                }
        */
        #endregion
        #region 实现关联Join方法和属性

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[DATABASE_TABLE_MY](
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [TABLE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [WEBMANAGER_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [WEBMANAGER_REALNAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ROWCOUNTS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_WEEK] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_WEEK] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_WEEK_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_WEEK_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_MONTH] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_MONTH] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_MONTH_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_MONTH_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_YEAR] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_YEAR] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_YEAR_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_ROWCOUNTS_INCREASING_YEAR_RATE] DEFAULT ('0') ,
                 [COLUMNCOUNTS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_COLUMNCOUNTS] DEFAULT ('0') ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_TABLE_MY_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_DATABASE_TABLE_MY] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_NAME] ASC,[TABLE_NAME] ASC,[WEBMANAGER_NAME] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'TABLE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认领人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认领人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本周记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_WEEK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本周记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_WEEK_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本月记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_MONTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本月记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_MONTH_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本年记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_YEAR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本年记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_YEAR_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'COLUMNCOUNTS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认领时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_MY', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}