
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_SQL_SYNC"
    /// Columns="DATABASE_REMOTE_IP,SYNC_DATE,SYNC_COUNT"
    /// PrimaryKeys="DATABASE_REMOTE_IP,SYNC_DATE"
    /// </summary>
    public sealed class DATABASE_SQL_SYNC : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/4/25 18:03:31
        #region 属性
        /// <summary>
        /// 数据库IP  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_REMOTE_IP,SYNC_DATE
        /// </summary>
        public string DATABASE_REMOTE_IP
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
        /// 同步日期（ｓｑｌ执行的日期）  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SYNC_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：DATABASE_REMOTE_IP,SYNC_DATE
        /// </summary>
        public DateTime SYNC_DATE
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 同步日期（ｓｑｌ执行的日期）  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 SYNC_DATE
        ///	主健之一，其他主健还有：DATABASE_REMOTE_IP,SYNC_DATE
        /// </summary>
        public string SYNC_DATE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 同步记录数  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SYNC_COUNT_ToString 更加准确
        /// </summary>
        public int SYNC_COUNT
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 同步记录数  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SYNC_COUNT
        /// </summary>
        public string SYNC_COUNT_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 数据库IP 返回 "DATABASE_REMOTE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_REMOTE_IP = "DATABASE_REMOTE_IP";
        /// <summary>
        /// 同步日期（ｓｑｌ执行的日期） 返回 "SYNC_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SYNC_DATE = "SYNC_DATE";
        /// <summary>
        /// 同步记录数 返回 "SYNC_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SYNC_COUNT = "SYNC_COUNT";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_SQL_SYNC的构造函数
        /// </summary>
        public DATABASE_SQL_SYNC()
        {
            this.TableName = "DATABASE_SQL_SYNC";
            this.PrimaryKey = new string[] { _DATABASE_REMOTE_IP, _SYNC_DATE };

            this.columns = new string[] { _DATABASE_REMOTE_IP, _SYNC_DATE, _SYNC_COUNT };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_SQL_SYNC的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0 };
                this.DataTypes = new string[] { VARCHAR, DATETIME, INT };
                this.Lengths = new int[] { 50, 8, 4 };
                this.IsNullables = new int[] { 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " " };
                this.Descriptions = new string[] { "数据库IP", "同步日期（ｓｑｌ执行的日期）", "同步记录数" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_REMOTE_IP">数据库IP</param>
        /// <param name="SYNC_DATE">同步日期（ｓｑｌ执行的日期）</param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_REMOTE_IP,DateTime P_SYNC_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_REMOTE_IP;
        this.ColumnValues[1]=P_SYNC_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_SQL_SYNC（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_SQL_SYNC Copy()
                {
                    DATABASE_SQL_SYNC new_obj=new DATABASE_SQL_SYNC();
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
                 				
                CREATE TABLE [dbo].[DATABASE_SQL_SYNC](
                 [DATABASE_REMOTE_IP] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [SYNC_DATE] [DATETIME]  NOT NULL ,
                 [SYNC_COUNT] [INT]  NULL ,
                
                CONSTRAINT [PK_DATABASE_SQL_SYNC] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_REMOTE_IP] ASC,[SYNC_DATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_SYNC', @level2type=N'COLUMN',@level2name=N'DATABASE_REMOTE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步日期（ｓｑｌ执行的日期）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_SYNC', @level2type=N'COLUMN',@level2name=N'SYNC_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步记录数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_SYNC', @level2type=N'COLUMN',@level2name=N'SYNC_COUNT'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}