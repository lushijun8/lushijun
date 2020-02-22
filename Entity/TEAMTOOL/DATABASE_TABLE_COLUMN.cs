
using System;
namespace Entity.TEAMTOOL
{
   /// <summary>
	/// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="DATABASE_TABLE_COLUMN"
	/// Columns="DATABASE_NAME,TABLE_NAME,COLUMN_NAME,LIKE_WEBMANAGER_NAME,LIKE_WEBMANAGER_REALNAME,WEBMANAGER_NAME,WEBMANAGER_REALNAME,COLUMN_TYPE,COLUMN_LENGTH,COLUMN_IS_PRIMARYKEY,COLUMN_NULL,COLUMN_IDENTITY,COLUMN_DEFAULTVALUE,COLUMN_DESCRIPTION"
	/// PrimaryKeys="DATABASE_NAME,TABLE_NAME,COLUMN_NAME"
	/// </summary>
    public sealed class DATABASE_TABLE_COLUMN : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/5/19 16:41:15
        #region 属性
        /// <summary>
        /// 数据库名称  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COLUMN_NAME
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
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COLUMN_NAME
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
        /// 字段名  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COLUMN_NAME
        /// </summary>
        public string COLUMN_NAME
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
        /// 疑似领用人  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_NAME
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
        /// 疑似领用人姓名  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_REALNAME
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
        /// 领用人  NVARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_NAME
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
        /// 领用人姓名  NVARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
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
        /// 字段类型  VARCHAR(50)  NULL
        /// </summary>
        public string COLUMN_TYPE
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
        /// 字段长度  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMN_LENGTH_ToString 更加准确
        /// </summary>
        public int COLUMN_LENGTH
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 字段长度  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMN_LENGTH
        /// </summary>
        public string COLUMN_LENGTH_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 是否主键  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMN_IS_PRIMARYKEY_ToString 更加准确
        /// </summary>
        public int COLUMN_IS_PRIMARYKEY
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 是否主键  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMN_IS_PRIMARYKEY
        /// </summary>
        public string COLUMN_IS_PRIMARYKEY_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 是否允许空  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMN_NULL_ToString 更加准确
        /// </summary>
        public int COLUMN_NULL
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 是否允许空  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMN_NULL
        /// </summary>
        public string COLUMN_NULL_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 是否自增字段  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMN_IDENTITY_ToString 更加准确
        /// </summary>
        public int COLUMN_IDENTITY
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 是否自增字段  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMN_IDENTITY
        /// </summary>
        public string COLUMN_IDENTITY_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 默认值  VARCHAR(50)  NULL
        /// </summary>
        public string COLUMN_DEFAULTVALUE
        {
            get
            {
                return ColumnValues[12];
            }
            set
            {
                ColumnValues[12] = value; UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 字段描述  VARCHAR(-1)  NULL
        /// </summary>
        public string COLUMN_DESCRIPTION
        {
            get
            {
                return ColumnValues[13];
            }
            set
            {
                ColumnValues[13] = value; UpdateStatus[13] = 1;
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
        /// 字段名 返回 "COLUMN_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_NAME = "COLUMN_NAME";
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
        /// 字段类型 返回 "COLUMN_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_TYPE = "COLUMN_TYPE";
        /// <summary>
        /// 字段长度 返回 "COLUMN_LENGTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_LENGTH = "COLUMN_LENGTH";
        /// <summary>
        /// 是否主键 返回 "COLUMN_IS_PRIMARYKEY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_IS_PRIMARYKEY = "COLUMN_IS_PRIMARYKEY";
        /// <summary>
        /// 是否允许空 返回 "COLUMN_NULL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_NULL = "COLUMN_NULL";
        /// <summary>
        /// 是否自增字段 返回 "COLUMN_IDENTITY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_IDENTITY = "COLUMN_IDENTITY";
        /// <summary>
        /// 默认值 返回 "COLUMN_DEFAULTVALUE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_DEFAULTVALUE = "COLUMN_DEFAULTVALUE";
        /// <summary>
        /// 字段描述 返回 "COLUMN_DESCRIPTION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMN_DESCRIPTION = "COLUMN_DESCRIPTION";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_TABLE_COLUMN的构造函数
        /// </summary>
        public DATABASE_TABLE_COLUMN()
        {
            this.TableName = "DATABASE_TABLE_COLUMN";
            this.PrimaryKey = new string[] { _DATABASE_NAME, _TABLE_NAME, _COLUMN_NAME };

            this.columns = new string[] { _DATABASE_NAME, _TABLE_NAME, _COLUMN_NAME, _LIKE_WEBMANAGER_NAME, _LIKE_WEBMANAGER_REALNAME, _WEBMANAGER_NAME, _WEBMANAGER_REALNAME, _COLUMN_TYPE, _COLUMN_LENGTH, _COLUMN_IS_PRIMARYKEY, _COLUMN_NULL, _COLUMN_IDENTITY, _COLUMN_DEFAULTVALUE, _COLUMN_DESCRIPTION };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_TABLE_COLUMN的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, VARCHAR, INT, INT, INT, INT, VARCHAR, VARCHAR };
                this.Lengths = new int[] { 50, 50, 50, 1000, 1000, 1000, 1000, 50, 4, 4, 4, 4, 50, -1 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "数据库名称", "表名", "字段名", "疑似领用人", "疑似领用人姓名", "领用人", "领用人姓名", "字段类型", "字段长度", "是否主键", "是否允许空", "是否自增字段", "默认值", "字段描述" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_NAME">数据库名称</param>
        /// <param name="TABLE_NAME">表名</param>
        /// <param name="COLUMN_NAME">字段名</param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_NAME,string P_TABLE_NAME,string P_COLUMN_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_NAME;
        this.ColumnValues[1]=P_TABLE_NAME;
        this.ColumnValues[2]=P_COLUMN_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_TABLE_COLUMN（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_TABLE_COLUMN Copy()
                {
                    DATABASE_TABLE_COLUMN new_obj=new DATABASE_TABLE_COLUMN();
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
                 				
                CREATE TABLE [dbo].[DATABASE_TABLE_COLUMN](
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [TABLE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COLUMN_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [LIKE_WEBMANAGER_NAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LIKE_WEBMANAGER_REALNAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_REALNAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [COLUMN_TYPE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [COLUMN_LENGTH] [INT]  NULL ,
                 [COLUMN_IS_PRIMARYKEY] [INT]  NULL ,
                 [COLUMN_NULL] [INT]  NULL ,
                 [COLUMN_IDENTITY] [INT]  NULL ,
                 [COLUMN_DEFAULTVALUE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [COLUMN_DESCRIPTION] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_DATABASE_TABLE_COLUMN] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_NAME] ASC,[TABLE_NAME] ASC,[COLUMN_NAME] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'TABLE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_TYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_LENGTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_IS_PRIMARYKEY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_NULL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否自增字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_IDENTITY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_DEFAULTVALUE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE_COLUMN', @level2type=N'COLUMN',@level2name=N'COLUMN_DESCRIPTION'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}