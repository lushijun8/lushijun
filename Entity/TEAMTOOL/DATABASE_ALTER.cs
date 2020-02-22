using System;
namespace Entity.TEAMTOOL
{

    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_ALTER"
    /// Columns="ID,DATABASE_IP,DATABASE_NAME,WEBMANAGER_NAME,ALTER_SQL,ALTER_STATUS,ALTER_REMARK,ALTER_PROBLEM,ALTER_TIME,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_ALTER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/9/29 10:01:51
        #region 属性
        /// <summary>
        /// 主键  BIGINT(8) 自增列 NOT NULL
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
        /// 主键  BIGINT(8) 自增列 NOT NULL
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
        public string DATABASE_IP
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
        /// 创建人用户名  NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_NAME
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
        /// 执行的SQL  VARCHAR(-1)  NULL
        /// </summary>
        public string ALTER_SQL
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
        /// 状态：0新建，1已执行  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ALTER_STATUS_ToString 更加准确
        /// </summary>
        public int ALTER_STATUS
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 状态：0新建，1已执行  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ALTER_STATUS
        /// </summary>
        public string ALTER_STATUS_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(2000)  NULL
        /// </summary>
        public string ALTER_REMARK
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
        /// SQL存在的问题或者执行结果  VARCHAR(-1)  NULL
        /// </summary>
        public string ALTER_PROBLEM
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
        /// 执行时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ALTER_TIME_ToString 更加准确
        /// </summary>
        public DateTime ALTER_TIME
        {
            set
            {
                ColumnValues[8] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 执行时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ALTER_TIME
        /// </summary>
        public string ALTER_TIME_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
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
        /// 主键 返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 数据库IP 返回 "DATABASE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP = "DATABASE_IP";
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 创建人用户名 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 执行的SQL 返回 "ALTER_SQL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALTER_SQL = "ALTER_SQL";
        /// <summary>
        /// 状态：0新建，1已执行 返回 "ALTER_STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALTER_STATUS = "ALTER_STATUS";
        /// <summary>
        /// 备注 返回 "ALTER_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALTER_REMARK = "ALTER_REMARK";
        /// <summary>
        /// SQL存在的问题或者执行结果 返回 "ALTER_PROBLEM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALTER_PROBLEM = "ALTER_PROBLEM";
        /// <summary>
        /// 执行时间 返回 "ALTER_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALTER_TIME = "ALTER_TIME";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_ALTER的构造函数
        /// </summary>
        public DATABASE_ALTER()
        {
            this.TableName = "DATABASE_ALTER";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _DATABASE_IP, _DATABASE_NAME, _WEBMANAGER_NAME, _ALTER_SQL, _ALTER_STATUS, _ALTER_REMARK, _ALTER_PROBLEM, _ALTER_TIME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_ALTER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, NVARCHAR, VARCHAR, INT, NVARCHAR, VARCHAR, DATETIME, DATETIME };
                this.Lengths = new int[] { 8, 50, 50, 100, -1, 4, 2000, -1, 8, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "主键", "数据库IP", "数据库名称", "创建人用户名", "执行的SQL", "状态：0新建，1已执行", "备注", "SQL存在的问题或者执行结果", "执行时间", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">主键</param>
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
                /// 深度拷贝DATABASE_ALTER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_ALTER Copy()
                {
                    DATABASE_ALTER new_obj=new DATABASE_ALTER();
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

        private bool inner_join_admin_webmanager = false;
        private bool left_join_admin_webmanager = false;
        private bool right_join_admin_webmanager = false;

        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=DATABASE_ALTER.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=DATABASE_ALTER.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=DATABASE_ALTER.WEBMANAGER_NAME
        /// </summary>
        public bool RIGHT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.right_join_admin_webmanager = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_WEBMANAGER
        /// LEFT_JOIN_ADMIN_WEBMANAGER
        /// RIGHT_JOIN_ADMIN_WEBMANAGER
        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }
            if (this.right_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "RIGHT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[DATABASE_ALTER](
                 [ID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [DATABASE_IP] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ALTER_SQL] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ALTER_STATUS] [INT]  NULL ,
                 [ALTER_REMARK] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ALTER_PROBLEM] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ALTER_TIME] [DATETIME]  NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_DATABASE_ALTER] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行的SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ALTER_SQL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：0新建，1已执行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ALTER_STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ALTER_REMARK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL存在的问题或者执行结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ALTER_PROBLEM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'ALTER_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_ALTER', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}