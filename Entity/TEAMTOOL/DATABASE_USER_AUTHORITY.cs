
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_USER_AUTHORITY"
    /// Columns="ID,DATABASE_IP_ROMOTE,DATABASE_NAME,UNAME,TNAME,TTYPE,TREFERENCES,TINSERT,TSELECT,TUPDATE,TDELETE,TEXECUTE,PROTECTTYPE,PROTECTTYPESQL,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_USER_AUTHORITY : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/11/8 17:47:25
        #region 属性
        /// <summary>
        ///   INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4) 自增列 NOT NULL
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
        /// 数据库IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_ROMOTE
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
        /// 数据库名称  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_NAME
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
        /// 数据库用户名  VARCHAR(100)  NULL
        /// </summary>
        public string UNAME
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
        /// 表名或者视图和存储过程名  VARCHAR(100)  NULL
        /// </summary>
        public string TNAME
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
        /// 类型  VARCHAR(50)  NULL
        /// </summary>
        public string TTYPE
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
        /// 是否允许Reference  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TREFERENCES_ToString 更加准确
        /// </summary>
        public int TREFERENCES
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 是否允许Reference  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TREFERENCES
        /// </summary>
        public string TREFERENCES_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 是否允许Insert  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TINSERT_ToString 更加准确
        /// </summary>
        public int TINSERT
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 是否允许Insert  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TINSERT
        /// </summary>
        public string TINSERT_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 是否允许Select  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TSELECT_ToString 更加准确
        /// </summary>
        public int TSELECT
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 是否允许Select  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TSELECT
        /// </summary>
        public string TSELECT_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 是否允许Update  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUPDATE_ToString 更加准确
        /// </summary>
        public int TUPDATE
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 是否允许Update  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUPDATE
        /// </summary>
        public string TUPDATE_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 是否允许Delete  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TDELETE_ToString 更加准确
        /// </summary>
        public int TDELETE
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 是否允许Delete  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TDELETE
        /// </summary>
        public string TDELETE_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 是否允许Execute  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TEXECUTE_ToString 更加准确
        /// </summary>
        public int TEXECUTE
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 是否允许Execute  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TEXECUTE
        /// </summary>
        public string TEXECUTE_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 保护类型：拒绝Deny，授予GRANT  VARCHAR(50)  NULL
        /// </summary>
        public string PROTECTTYPE
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
        /// 具体执行的SQL  VARCHAR(1000)  NULL
        /// </summary>
        public string PROTECTTYPESQL
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
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[14] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[14] = 1;
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
                return ColumnValues[14];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 数据库IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 数据库用户名 返回 "UNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UNAME = "UNAME";
        /// <summary>
        /// 表名或者视图和存储过程名 返回 "TNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TNAME = "TNAME";
        /// <summary>
        /// 类型 返回 "TTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TTYPE = "TTYPE";
        /// <summary>
        /// 是否允许Reference 返回 "TREFERENCES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TREFERENCES = "TREFERENCES";
        /// <summary>
        /// 是否允许Insert 返回 "TINSERT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TINSERT = "TINSERT";
        /// <summary>
        /// 是否允许Select 返回 "TSELECT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TSELECT = "TSELECT";
        /// <summary>
        /// 是否允许Update 返回 "TUPDATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUPDATE = "TUPDATE";
        /// <summary>
        /// 是否允许Delete 返回 "TDELETE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TDELETE = "TDELETE";
        /// <summary>
        /// 是否允许Execute 返回 "TEXECUTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEXECUTE = "TEXECUTE";
        /// <summary>
        /// 保护类型：拒绝Deny，授予GRANT 返回 "PROTECTTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PROTECTTYPE = "PROTECTTYPE";
        /// <summary>
        /// 具体执行的SQL 返回 "PROTECTTYPESQL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PROTECTTYPESQL = "PROTECTTYPESQL";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_USER_AUTHORITY的构造函数
        /// </summary>
        public DATABASE_USER_AUTHORITY()
        {
            this.TableName = "DATABASE_USER_AUTHORITY";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _DATABASE_IP_ROMOTE, _DATABASE_NAME, _UNAME, _TNAME, _TTYPE, _TREFERENCES, _TINSERT, _TSELECT, _TUPDATE, _TDELETE, _TEXECUTE, _PROTECTTYPE, _PROTECTTYPESQL, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_USER_AUTHORITY的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, INT, INT, INT, INT, INT, VARCHAR, VARCHAR, DATETIME };
                this.Lengths = new int[] { 4, 50, 50, 100, 100, 50, 4, 4, 4, 4, 4, 4, 50, 1000, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { " ", "数据库IP", "数据库名称", "数据库用户名", "表名或者视图和存储过程名", "类型", "是否允许Reference", "是否允许Insert", "是否允许Select", "是否允许Update", "是否允许Delete", "是否允许Execute", "保护类型：拒绝Deny，授予GRANT", "具体执行的SQL", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID"></param>
                /// <returns>bool</returns>
                public bool Find(int P_ID)
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
                /// 深度拷贝DATABASE_USER_AUTHORITY（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_USER_AUTHORITY Copy()
                {
                    DATABASE_USER_AUTHORITY new_obj=new DATABASE_USER_AUTHORITY();
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
                 				
                CREATE TABLE [dbo].[DATABASE_USER_AUTHORITY](
                 [ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [UNAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [TNAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [TTYPE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [TREFERENCES] [INT]  NULL ,
                 [TINSERT] [INT]  NULL ,
                 [TSELECT] [INT]  NULL ,
                 [TUPDATE] [INT]  NULL ,
                 [TDELETE] [INT]  NULL ,
                 [TEXECUTE] [INT]  NULL ,
                 [PROTECTTYPE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PROTECTTYPESQL] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_USER_AUTHORITY_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_DATABASE_USER_AUTHORITY] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'UNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名或者视图和存储过程名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TTYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Reference' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TREFERENCES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Insert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TINSERT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Select' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TSELECT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Update' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TUPDATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Delete' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TDELETE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许Execute' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TEXECUTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保护类型：拒绝Deny，授予GRANT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'PROTECTTYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'具体执行的SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'PROTECTTYPESQL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER_AUTHORITY', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}