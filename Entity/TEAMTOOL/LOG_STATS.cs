using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="LOG_STATS"
    /// Columns="ID,PAGEURL,PAGEURL_REGEX,QUERYSTRING,FORM,QUERYSTRING_PHONE_ENCRYPT,FORM_PHONE_ENCRYPT,LOG_TYPE,LOG_DATE,LOG_COUNT,CREATETIME,TEAMNAME,REMARKS,CONTENT,ERROR_CREATETIME,TITLE,IP,USERNAME,CLASSNAME,METHODNAME,LOGLEVEL"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class LOG_STATS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/6/20 11:47:37
        #region 属性
        /// <summary>
        /// ID   BIGINT(8) 自增列 NOT NULL
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
        /// ID   BIGINT(8) 自增列 NOT NULL
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
        /// 网页URL    VARCHAR(4000)  NULL
        /// </summary>
        public string PAGEURL
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
        /// 网页URL正则表达式，用于模糊匹配负责人   VARCHAR(500)  NULL
        /// </summary>
        public string PAGEURL_REGEX
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
        /// 请求参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string QUERYSTRING
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
        /// 请求Form参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string FORM
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
        /// GET参数的手机号是否加密   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 QUERYSTRING_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int QUERYSTRING_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// GET参数的手机号是否加密   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 QUERYSTRING_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string QUERYSTRING_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// POST参数的手机号是否加密    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FORM_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int FORM_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// POST参数的手机号是否加密    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FORM_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string FORM_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 0报错日志，1业务日志  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOG_TYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int LOG_TYPE
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 0报错日志，1业务日志  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOG_TYPE
        ///	默认值:0
        /// </summary>
        public string LOG_TYPE_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 日志统计日期   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOG_DATE_ToString 更加准确
        /// </summary>
        public DateTime LOG_DATE
        {
            set
            {
                ColumnValues[8] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 日志统计日期   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOG_DATE
        /// </summary>
        public string LOG_DATE_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 报错次数   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOG_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int LOG_COUNT
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 报错次数   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOG_COUNT
        ///	默认值:0
        /// </summary>
        public string LOG_COUNT_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[10] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 团队名称  VARCHAR(50)  NULL
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
        /// 备注  NVARCHAR(-1)  NULL
        /// </summary>
        public string REMARKS
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
        /// 日志内容  NVARCHAR(-1)  NULL
        /// </summary>
        public string CONTENT
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
        /// 报错时间   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ERROR_CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime ERROR_CREATETIME
        {
            set
            {
                ColumnValues[14] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 报错时间   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ERROR_CREATETIME
        /// </summary>
        public string ERROR_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 日志标题   NVARCHAR(1000)  NULL
        /// </summary>
        public string TITLE
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
        /// 客户端IP   NVARCHAR(200)  NULL
        /// </summary>
        public string IP
        {
            get
            {
                return ColumnValues[16];
            }
            set
            {
                ColumnValues[16] = value; UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 用户名   NVARCHAR(100)  NULL
        /// </summary>
        public string USERNAME
        {
            get
            {
                return ColumnValues[17];
            }
            set
            {
                ColumnValues[17] = value; UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 程序所在类名  NVARCHAR(100)  NULL
        /// </summary>
        public string CLASSNAME
        {
            get
            {
                return ColumnValues[18];
            }
            set
            {
                ColumnValues[18] = value; UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 程序所在方法名   NVARCHAR(100)  NULL
        /// </summary>
        public string METHODNAME
        {
            get
            {
                return ColumnValues[19];
            }
            set
            {
                ColumnValues[19] = value; UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 日志级别  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOGLEVEL_ToString 更加准确
        /// </summary>
        public int LOGLEVEL
        {
            set
            {
                ColumnValues[20] = value.ToString(); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        /// 日志级别  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOGLEVEL
        /// </summary>
        public string LOGLEVEL_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// ID  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 网页URL   返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 网页URL正则表达式，用于模糊匹配负责人  返回 "PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_REGEX = "PAGEURL_REGEX";
        /// <summary>
        /// 请求参数 返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        /// GET参数的手机号是否加密  返回 "QUERYSTRING_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING_PHONE_ENCRYPT = "QUERYSTRING_PHONE_ENCRYPT";
        /// <summary>
        /// POST参数的手机号是否加密   返回 "FORM_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM_PHONE_ENCRYPT = "FORM_PHONE_ENCRYPT";
        /// <summary>
        /// 0报错日志，1业务日志 返回 "LOG_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOG_TYPE = "LOG_TYPE";
        /// <summary>
        /// 日志统计日期  返回 "LOG_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOG_DATE = "LOG_DATE";
        /// <summary>
        /// 报错次数  返回 "LOG_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOG_COUNT = "LOG_COUNT";
        /// <summary>
        /// 创建时间  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 团队名称 返回 "TEAMNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEAMNAME = "TEAMNAME";
        /// <summary>
        /// 备注 返回 "REMARKS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REMARKS = "REMARKS";
        /// <summary>
        /// 日志内容 返回 "CONTENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONTENT = "CONTENT";
        /// <summary>
        /// 报错时间  返回 "ERROR_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERROR_CREATETIME = "ERROR_CREATETIME";
        /// <summary>
        /// 日志标题  返回 "TITLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TITLE = "TITLE";
        /// <summary>
        /// 客户端IP  返回 "IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IP = "IP";
        /// <summary>
        /// 用户名  返回 "USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERNAME = "USERNAME";
        /// <summary>
        /// 程序所在类名 返回 "CLASSNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CLASSNAME = "CLASSNAME";
        /// <summary>
        /// 程序所在方法名  返回 "METHODNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _METHODNAME = "METHODNAME";
        /// <summary>
        /// 日志级别 返回 "LOGLEVEL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGLEVEL = "LOGLEVEL";

        #endregion
        #region 函数
        /// <summary>
        /// LOG_STATS的构造函数
        /// </summary>
        public LOG_STATS()
        {
            this.TableName = "LOG_STATS";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _PAGEURL, _PAGEURL_REGEX, _QUERYSTRING, _FORM, _QUERYSTRING_PHONE_ENCRYPT, _FORM_PHONE_ENCRYPT, _LOG_TYPE, _LOG_DATE, _LOG_COUNT, _CREATETIME, _TEAMNAME, _REMARKS, _CONTENT, _ERROR_CREATETIME, _TITLE, _IP, _USERNAME, _CLASSNAME, _METHODNAME, _LOGLEVEL };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表LOG_STATS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, NVARCHAR, NVARCHAR, INT, INT, INT, DATETIME, INT, DATETIME, VARCHAR, NVARCHAR, NVARCHAR, DATETIME, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT };
                this.Lengths = new int[] { 8, 4000, 500, 8000, 8000, 4, 4, 4, 8, 4, 8, 50, -1, -1, 8, 1000, 200, 100, 100, 100, 4 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", "1", "1", "0", " ", "0", "getdate", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "ID ", "网页URL  ", "网页URL正则表达式，用于模糊匹配负责人 ", "请求参数", "请求Form参数", "GET参数的手机号是否加密 ", "POST参数的手机号是否加密  ", "0报错日志，1业务日志", "日志统计日期 ", "报错次数 ", "创建时间 ", "团队名称", "备注", "日志内容", "报错时间 ", "日志标题 ", "客户端IP ", "用户名 ", "程序所在类名", "程序所在方法名 ", "日志级别 " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">ID </param>
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
                /// 深度拷贝LOG_STATS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public LOG_STATS Copy()
                {
                    LOG_STATS new_obj=new LOG_STATS();
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
        private bool inner_join_website_my_pageurl = false;
        private bool left_join_website_my_pageurl = false;
        private bool right_join_website_my_pageurl = false;


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
        /// INNER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=LOG_STATS.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.inner_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=LOG_STATS.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.left_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=LOG_STATS.PAGEURL
        /// </summary>
        public bool RIGHT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.right_join_website_my_pageurl = value;
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
            if (this.inner_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.right_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "RIGHT OUTER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[LOG_STATS](
                 [ID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [PAGEURL] [VARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PAGEURL_REGEX] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [QUERYSTRING] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FORM] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [QUERYSTRING_PHONE_ENCRYPT] [INT]  NULL  CONSTRAINT [DF_LOG_STATS_QUERYSTRING_PHONE_ENCRYPT] DEFAULT ('1') ,
                 [FORM_PHONE_ENCRYPT] [INT]  NULL  CONSTRAINT [DF_LOG_STATS_FORM_PHONE_ENCRYPT] DEFAULT ('1') ,
                 [LOG_TYPE] [INT]  NULL  CONSTRAINT [DF_LOG_STATS_LOG_TYPE] DEFAULT ('0') ,
                 [LOG_DATE] [DATETIME]  NULL ,
                 [LOG_COUNT] [INT]  NULL  CONSTRAINT [DF_LOG_STATS_LOG_COUNT] DEFAULT ('0') ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_LOG_STATS_CREATETIME] DEFAULT ('getdate') ,
                 [TEAMNAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [REMARKS] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CONTENT] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ERROR_CREATETIME] [DATETIME]  NULL ,
                 [TITLE] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [IP] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [USERNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CLASSNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [METHODNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LOGLEVEL] [INT]  NULL ,
                
                CONSTRAINT [PK_LOG_STATS] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网页URL  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网页URL正则表达式，用于模糊匹配负责人 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'PAGEURL_REGEX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'QUERYSTRING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求Form参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'FORM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GET参数的手机号是否加密 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'QUERYSTRING_PHONE_ENCRYPT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POST参数的手机号是否加密  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'FORM_PHONE_ENCRYPT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0报错日志，1业务日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'LOG_TYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志统计日期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'LOG_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报错次数 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'LOG_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团队名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'TEAMNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'REMARKS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'CONTENT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报错时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'ERROR_CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志标题 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'TITLE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户端IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'USERNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'程序所在类名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'CLASSNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'程序所在方法名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'METHODNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志级别 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LOG_STATS', @level2type=N'COLUMN',@level2name=N'LOGLEVEL'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}