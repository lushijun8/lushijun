
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_TABLE_INDEX"
    /// Columns="DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME,COLID,LIKE_WEBMANAGER_NAME,LIKE_WEBMANAGER_REALNAME,WEBMANAGER_NAME,WEBMANAGER_REALNAME,CREATETIME"
    /// PrimaryKeys="DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME"
    /// </summary>
    public sealed class DATABASE_TABLE_INDEX : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/12/26 15:34:08
        #region 属性
        /// <summary>
        /// 数据库名称  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME
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
        /// 表名  VARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME
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
        /// 索引名  VARCHAR(200)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME
        /// </summary>
        public string INDEX_NAME
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
        /// 字段名  VARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,INDEX_NAME,COLUMN_NAME
        /// </summary>
        public string COLUMN_NAME
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLID_ToString 更加准确
        /// </summary>
        public int COLID
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLID
        /// </summary>
        public string COLID_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 疑似领用人  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_NAME
        {
            get
            {
                return ColumnValues[5];
            }
            set
            {
                ColumnValues[5] = value; UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 疑似领用人姓名  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_REALNAME
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
        /// <summary>
        /// 领用人  NVARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_NAME
        {
            get
            {
                return ColumnValues[7];
            }
            set
            {
                ColumnValues[7] = value; UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 领用人姓名  NVARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
        {
            get
            {
                return ColumnValues[8];
            }
            set
            {
                ColumnValues[8] = value; UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[9] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[9];
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
        /// 索引名 返回 "INDEX_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INDEX_NAME = "INDEX_NAME";
        /// <summary>
        /// 字段名 返回 "COLUMN_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_NAME = "COLUMN_NAME";
        /// <summary>
        ///   返回 "COLID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLID = "COLID";
        /// <summary>
        /// 疑似领用人 返回 "LIKE_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIKE_WEBMANAGER_NAME = "LIKE_WEBMANAGER_NAME";
        /// <summary>
        /// 疑似领用人姓名 返回 "LIKE_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIKE_WEBMANAGER_REALNAME = "LIKE_WEBMANAGER_REALNAME";
        /// <summary>
        /// 领用人 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 领用人姓名 返回 "WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME = "WEBMANAGER_REALNAME";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_TABLE_INDEX的构造函数
        /// </summary>
        public DATABASE_TABLE_INDEX()
        {
            this.TableName = "DATABASE_TABLE_INDEX";
            this.PrimaryKey = new string[] { _DATABASE_NAME, _TABLE_NAME, _INDEX_NAME, _COLUMN_NAME };

            this.columns = new string[] { _DATABASE_NAME, _TABLE_NAME, _INDEX_NAME, _COLUMN_NAME, _COLID, _LIKE_WEBMANAGER_NAME, _LIKE_WEBMANAGER_REALNAME, _WEBMANAGER_NAME, _WEBMANAGER_REALNAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_TABLE_INDEX的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 50, 100, 200, 100, 4, 1000, 1000, 1000, 1000, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { "数据库名称", "表名", "索引名", "字段名", " ", "疑似领用人", "疑似领用人姓名", "领用人", "领用人姓名", "创建时间 " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_NAME">数据库名称</param>
        /// <param name="TABLE_NAME">表名</param>
        /// <param name="INDEX_NAME">索引名</param>
        /// <param name="COLUMN_NAME">字段名</param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_NAME,string P_TABLE_NAME,string P_INDEX_NAME,string P_COLUMN_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_NAME;
        this.ColumnValues[1]=P_TABLE_NAME;
        this.ColumnValues[2]=P_INDEX_NAME;
        this.ColumnValues[3]=P_COLUMN_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_TABLE_INDEX（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_TABLE_INDEX Copy()
                {
                    DATABASE_TABLE_INDEX new_obj=new DATABASE_TABLE_INDEX();
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
                 				
                CREATE TABLE [dbo].[DATABASE_TABLE_INDEX](
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [TABLE_NAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [INDEX_NAME] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COLUMN_NAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COLID] [INT]  NULL ,
                 [LIKE_WEBMANAGER_NAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LIKE_WEBMANAGER_REALNAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_REALNAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_TABLE_INDEX_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_DATABASE_TABLE_INDEX] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_NAME] ASC,[TABLE_NAME] ASC,[INDEX_NAME] ASC,[COLUMN_NAME] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'TABLE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'索引名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'INDEX_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'COLUMN_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_INDEX', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}