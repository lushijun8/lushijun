using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="LOG_BUSINESS"
    /// Columns="ID,CREATETIME,TITLE,LOGLEVEL,CONTENT,IP,USERNAME,REMARKS,CLASSNAME,METHODNAME,PAGEURL,TEAMNAME,SERVERNAME,PAGEURL_REGEX,SEND_EMAIL,SEND_WEBMANAGER_NAME,SEND_EMAIL_TIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class LOG_BUSINESS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/11/25 14:53:18
        #region 属性
        /// <summary>
        /// 日志ID   INT(4) 自增列 NOT NULL
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
        /// 日志ID   INT(4) 自增列 NOT NULL
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
        /// 创建时间   DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 日志标题   NVARCHAR(1000)  NOT NULL
        /// </summary>
        public string TITLE
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
        /// 日志级别   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOGLEVEL_ToString 更加准确
        /// </summary>
        public int LOGLEVEL
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 日志级别   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 LOGLEVEL
        /// </summary>
        public string LOGLEVEL_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 日志内容   NVARCHAR(-1)  NOT NULL
        /// </summary>
        public string CONTENT
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
        /// 客户端IP   NVARCHAR(200)  NULL
        /// </summary>
        public string IP
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
        /// 登录用户名   NVARCHAR(100)  NULL
        /// </summary>
        public string USERNAME
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
        /// 备注   NVARCHAR(-1)  NULL
        /// </summary>
        public string REMARKS
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
        /// 程序所在类名   NVARCHAR(100)  NULL
        /// </summary>
        public string CLASSNAME
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
        /// 程序所在方法名   NVARCHAR(100)  NULL
        /// </summary>
        public string METHODNAME
        {
            get
            {
                return ColumnValues[9];
            }
            set
            {
                ColumnValues[9] = value; UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 网页URL    VARCHAR(500)  NULL
        /// </summary>
        public string PAGEURL
        {
            get
            {
                return ColumnValues[10];
            }
            set
            {
                ColumnValues[10] = value; UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 所属团队名称   VARCHAR(50)  NULL
        /// </summary>
        public string TEAMNAME
        {
            get
            {
                return ColumnValues[11];
            }
            set
            {
                ColumnValues[11] = value; UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 服务器名称   VARCHAR(100)  NULL
        /// </summary>
        public string SERVERNAME
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
        /// 网页URL正则表达式，用于模糊匹配负责人   VARCHAR(500)  NULL
        /// </summary>
        public string PAGEURL_REGEX
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
        /// 邮件发送到的Email地址   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SEND_EMAIL_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int SEND_EMAIL
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 邮件发送到的Email地址   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SEND_EMAIL
        ///	默认值:0
        /// </summary>
        public string SEND_EMAIL_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 邮件发送给的负责人   NVARCHAR(400)  NULL
        /// </summary>
        public string SEND_WEBMANAGER_NAME
        {
            get
            {
                return ColumnValues[15];
            }
            set
            {
                ColumnValues[15] = value; UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 邮件发送时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SEND_EMAIL_TIME_ToString 更加准确
        /// </summary>
        public DateTime SEND_EMAIL_TIME
        {
            set
            {
                ColumnValues[16] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 邮件发送时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SEND_EMAIL_TIME
        /// </summary>
        public string SEND_EMAIL_TIME_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 日志ID  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 创建时间  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 日志标题  返回 "TITLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TITLE = "TITLE";
        /// <summary>
        /// 日志级别  返回 "LOGLEVEL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGLEVEL = "LOGLEVEL";
        /// <summary>
        /// 日志内容  返回 "CONTENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONTENT = "CONTENT";
        /// <summary>
        /// 客户端IP  返回 "IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IP = "IP";
        /// <summary>
        /// 登录用户名  返回 "USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERNAME = "USERNAME";
        /// <summary>
        /// 备注  返回 "REMARKS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REMARKS = "REMARKS";
        /// <summary>
        /// 程序所在类名  返回 "CLASSNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CLASSNAME = "CLASSNAME";
        /// <summary>
        /// 程序所在方法名  返回 "METHODNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _METHODNAME = "METHODNAME";
        /// <summary>
        /// 网页URL   返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 所属团队名称  返回 "TEAMNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEAMNAME = "TEAMNAME";
        /// <summary>
        /// 服务器名称  返回 "SERVERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERNAME = "SERVERNAME";
        /// <summary>
        /// 网页URL正则表达式，用于模糊匹配负责人  返回 "PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_REGEX = "PAGEURL_REGEX";
        /// <summary>
        /// 邮件发送到的Email地址  返回 "SEND_EMAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SEND_EMAIL = "SEND_EMAIL";
        /// <summary>
        /// 邮件发送给的负责人  返回 "SEND_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SEND_WEBMANAGER_NAME = "SEND_WEBMANAGER_NAME";
        /// <summary>
        /// 邮件发送时间 返回 "SEND_EMAIL_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SEND_EMAIL_TIME = "SEND_EMAIL_TIME";

        #endregion
        #region 函数
        /// <summary>
        /// LOG_BUSINESS的构造函数
        /// </summary>
        public LOG_BUSINESS()
        {
            this.TableName = "LOG_BUSINESS";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _CREATETIME, _TITLE, _LOGLEVEL, _CONTENT, _IP, _USERNAME, _REMARKS, _CLASSNAME, _METHODNAME, _PAGEURL, _TEAMNAME, _SERVERNAME, _PAGEURL_REGEX, _SEND_EMAIL, _SEND_WEBMANAGER_NAME, _SEND_EMAIL_TIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表LOG_BUSINESS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, DATETIME, NVARCHAR, INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 4, 8, 1000, 4, -1, 200, 100, -1, 100, 100, 500, 50, 100, 500, 4, 400, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", "getdate", " ", " ", "", " ", " ", "", " ", " ", " ", " ", " ", " ", "0", " ", " " };
                this.Descriptions = new string[] { "日志ID ", "创建时间 ", "日志标题 ", "日志级别 ", "日志内容 ", "客户端IP ", "登录用户名 ", "备注 ", "程序所在类名 ", "程序所在方法名 ", "网页URL  ", "所属团队名称 ", "服务器名称 ", "网页URL正则表达式，用于模糊匹配负责人 ", "邮件发送到的Email地址 ", "邮件发送给的负责人 ", "邮件发送时间 " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">日志ID </param>
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
                /// 深度拷贝LOG_BUSINESS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public LOG_BUSINESS Copy()
                {
                    LOG_BUSINESS new_obj=new LOG_BUSINESS();
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

        private bool inner_join_website_pageurl = false;
        private bool left_join_website_pageurl = false;

        /// <summary>
        /// INNER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=LOG_ERROR.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_PAGEURL
        {
            set
            {
                this.inner_join_website_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=LOG_ERROR.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_PAGEURL
        {
            set
            {
                this.left_join_website_pageurl = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_WEBSITE_PAGEURL
        /// LEFT_JOIN_WEBSITE_PAGEURL

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_website_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[LOG_BUSINESS](
                 [ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [CREATETIME] [DATETIME]  NOT NULL  CONSTRAINT [DF_LOG_BUSINESS_CREATETIME] DEFAULT ('getdate') ,
                 [TITLE] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [LOGLEVEL] [INT]  NOT NULL ,
                 [CONTENT] [NVARCHAR]  (-1)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [IP] [NVARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [USERNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [REMARKS] [NVARCHAR]  (-1)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CLASSNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [METHODNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PAGEURL] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [TEAMNAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SERVERNAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PAGEURL_REGEX] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SEND_EMAIL] [INT]  NULL  CONSTRAINT [DF_LOG_BUSINESS_SEND_EMAIL] DEFAULT ('0') ,
                 [SEND_WEBMANAGER_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SEND_EMAIL_TIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_LOG_BUSINESS] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}