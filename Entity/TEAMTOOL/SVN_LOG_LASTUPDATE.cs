using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="SVN_LOG_LASTUPDATE"
    /// Columns="COMMIT_FILE,REVISION,WEBMANAGER_NAME,COMMIT_SERVER,COMMIT_TYPE,COMMIT_FILE_MD5,COMMIT_TIME,COMMIT_MESSAGE,CREATETIME"
    /// PrimaryKeys="COMMIT_FILE"
    /// </summary>
    public sealed class SVN_LOG_LASTUPDATE : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/12/5 13:59:38
        #region 属性
        /// <summary>
        /// 提交的文件  NVARCHAR(800)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string COMMIT_FILE
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
        /// 提交版本号  BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 REVISION_ToString 更加准确
        /// </summary>
        public long REVISION
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 提交版本号  BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 REVISION
        /// </summary>
        public string REVISION_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 提交人  NVARCHAR(100)  NOT NULL
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
        /// 服务器  VARCHAR(50)  NOT NULL
        ///	默认值:svn://192.168.5.215:2002
        /// </summary>
        public string COMMIT_SERVER
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
        /// 提交类型：0Added，1Modified，2Deleted，3replacing  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COMMIT_TYPE_ToString 更加准确
        /// </summary>
        public int COMMIT_TYPE
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 提交类型：0Added，1Modified，2Deleted，3replacing  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 COMMIT_TYPE
        /// </summary>
        public string COMMIT_TYPE_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 提交文件的MD5码  NVARCHAR(200)  NOT NULL
        /// </summary>
        public string COMMIT_FILE_MD5
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
        /// 提交时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COMMIT_TIME_ToString 更加准确
        /// </summary>
        public DateTime COMMIT_TIME
        {
            set
            {
                ColumnValues[6] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 提交时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COMMIT_TIME
        /// </summary>
        public string COMMIT_TIME_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(-1)  NULL
        /// </summary>
        public string COMMIT_MESSAGE
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
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[8] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[8] = 1;
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
                return ColumnValues[8];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 提交的文件 返回 "COMMIT_FILE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_FILE = "COMMIT_FILE";
        /// <summary>
        /// 提交版本号 返回 "REVISION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REVISION = "REVISION";
        /// <summary>
        /// 提交人 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 服务器 返回 "COMMIT_SERVER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_SERVER = "COMMIT_SERVER";
        /// <summary>
        /// 提交类型：0Added，1Modified，2Deleted，3replacing 返回 "COMMIT_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_TYPE = "COMMIT_TYPE";
        /// <summary>
        /// 提交文件的MD5码 返回 "COMMIT_FILE_MD5", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_FILE_MD5 = "COMMIT_FILE_MD5";
        /// <summary>
        /// 提交时间 返回 "COMMIT_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_TIME = "COMMIT_TIME";
        /// <summary>
        /// 备注 返回 "COMMIT_MESSAGE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMMIT_MESSAGE = "COMMIT_MESSAGE";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// SVN_LOG_LASTUPDATE的构造函数
        /// </summary>
        public SVN_LOG_LASTUPDATE()
        {
            this.TableName = "SVN_LOG_LASTUPDATE";
            this.PrimaryKey = new string[] { _COMMIT_FILE };

            this.columns = new string[] { _COMMIT_FILE, _REVISION, _WEBMANAGER_NAME, _COMMIT_SERVER, _COMMIT_TYPE, _COMMIT_FILE_MD5, _COMMIT_TIME, _COMMIT_MESSAGE, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SVN_LOG_LASTUPDATE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, BIGINT, NVARCHAR, VARCHAR, INT, NVARCHAR, DATETIME, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 800, 8, 100, 50, 4, 200, 8, -1, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", "svn://192.168.5.215:2002", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { "提交的文件", "提交版本号", "提交人", "服务器", "提交类型：0Added，1Modified，2Deleted，3replacing", "提交文件的MD5码", "提交时间", "备注", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="COMMIT_FILE">提交的文件</param>
                /// <returns>bool</returns>
                public bool Find(string P_COMMIT_FILE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_COMMIT_FILE;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SVN_LOG_LASTUPDATE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SVN_LOG_LASTUPDATE Copy()
                {
                    SVN_LOG_LASTUPDATE new_obj=new SVN_LOG_LASTUPDATE();
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
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=SVN_LOG_LASTUPDATE.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=SVN_LOG_LASTUPDATE.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=SVN_LOG_LASTUPDATE.WEBMANAGER_NAME
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
                 				
                CREATE TABLE [dbo].[SVN_LOG_LASTUPDATE](
                 [COMMIT_FILE] [NVARCHAR]  (400)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [REVISION] [BIGINT]  NOT NULL ,
                 [WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COMMIT_SERVER] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL  CONSTRAINT [DF_SVN_LOG_LASTUPDATE_COMMIT_SERVER] DEFAULT ('svn://192.168.5.215:2002') ,
                 [COMMIT_TYPE] [INT]  NOT NULL ,
                 [COMMIT_FILE_MD5] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COMMIT_TIME] [DATETIME]  NULL ,
                 [COMMIT_MESSAGE] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_SVN_LOG_LASTUPDATE_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_SVN_LOG_LASTUPDATE] PRIMARY KEY CLUSTERED 
                (
	             [COMMIT_FILE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交的文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_FILE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交版本号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'REVISION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_SERVER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交类型：0Added，1Modified，2Deleted，3replacing' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_TYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交文件的MD5码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_FILE_MD5'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'COMMIT_MESSAGE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_LOG_LASTUPDATE', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}