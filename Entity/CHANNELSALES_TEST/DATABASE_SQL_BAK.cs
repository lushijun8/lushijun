
using System;
namespace Entity.CHANNELSALES_TEST
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="CHANNELSALES_TEST" 
    /// Table="DATABASE_SQL_BAK"
    /// Columns="ID,SQL_MD5,DATABASE_IP,DATABASE_USER,LAST_EXECUTION_TIME,DURATION,TEXT"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_SQL_BAK : Entity.CHANNELSALES_TEST.EntityBase
	{
        #region 系统生成代码，请不要动 生成日期:2016/7/15 16:28:20
        #region 属性
        /// <summary>
        ///   BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public long ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ID
        ///	唯一主键
        /// </summary>
        public string ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string SQL_MD5
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
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_USER
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
        /// 上次开始执行计划的时间。  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_EXECUTION_TIME_ToString 更加准确
        /// </summary>
        public DateTime LAST_EXECUTION_TIME
        {
            set
            {
                ColumnValues[4] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 上次开始执行计划的时间。  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_EXECUTION_TIME
        /// </summary>
        public string LAST_EXECUTION_TIME_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// SQL执行总耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long DURATION
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// SQL执行总耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION
        ///	默认值:0
        /// </summary>
        public string DURATION_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///   VARCHAR(-1)  NULL
        /// </summary>
        public string TEXT
        {
            get
            {
                return ColumnValues[6];
            }
            set
            {
                ColumnValues[6] = value; UpdateStatus[6] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "SQL_MD5", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SQL_MD5 = "SQL_MD5";
        /// <summary>
        ///   返回 "DATABASE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP = "DATABASE_IP";
        /// <summary>
        ///   返回 "DATABASE_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_USER = "DATABASE_USER";
        /// <summary>
        /// 上次开始执行计划的时间。 返回 "LAST_EXECUTION_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_EXECUTION_TIME = "LAST_EXECUTION_TIME";
        /// <summary>
        /// SQL执行总耗时(毫秒) 返回 "DURATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION = "DURATION";
        /// <summary>
        ///  返回 "TEXT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEXT = "TEXT";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_SQL_BAK的构造函数
        /// </summary>
        public DATABASE_SQL_BAK()
        {
            this.TableName = "DATABASE_SQL_BAK";
            this.PrimaryKey = new string[] { _ID };

            this.columns = new string[] { _ID, _SQL_MD5, _DATABASE_IP, _DATABASE_USER, _LAST_EXECUTION_TIME, _DURATION, _TEXT };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_SQL_BAK的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, VARCHAR, DATETIME, BIGINT, VARCHAR };
                this.Lengths = new int[] { 8, 50, 50, 100, 8, 8, -1 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", "0", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", "上次开始执行计划的时间。", "SQL执行总耗时(毫秒)", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID"></param>
                /// <returns>bool</returns>
                public bool Find(long P_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_SQL_BAK（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_SQL_BAK Copy()
                {
                    DATABASE_SQL_BAK new_obj=new DATABASE_SQL_BAK();
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
                 				
                CREATE TABLE [dbo].[DATABASE_SQL_BAK](
                 [ID] [BIGINT]  NOT NULL ,
                 [SQL_MD5] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_USER] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LAST_EXECUTION_TIME] [DATETIME]  NULL ,
                 [DURATION] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_SQL_BAK_DURATION] DEFAULT ('0') ,
                 [TEXT] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_DATABASE_SQL_BAK] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次开始执行计划的时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_BAK', @level2type=N'COLUMN',@level2name=N'LAST_EXECUTION_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL执行总耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_BAK', @level2type=N'COLUMN',@level2name=N'DURATION'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}