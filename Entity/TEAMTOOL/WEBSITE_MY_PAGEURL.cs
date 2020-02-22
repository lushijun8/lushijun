
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WEBSITE_MY_PAGEURL"
    /// Columns="WEBMANAGER_NAME,PAGEURL,QUERYSTRING,FORM,PAGEURL_REGEX,CREATETIME,ENCRYPT_REQUEST,ENCRYPT_REQUEST_AUDIT,QUERYSTRING_PHONE_ENCRYPT,FORM_PHONE_ENCRYPT"
    /// PrimaryKeys="WEBMANAGER_NAME,PAGEURL"
    /// </summary>
    public sealed class WEBSITE_MY_PAGEURL : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/10/9 12:16:22
        #region 属性
        /// <summary>
        ///   VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,PAGEURL
        /// </summary>
        public string WEBMANAGER_NAME
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
        ///    VARCHAR(500)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,PAGEURL
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
        /// 请求参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string QUERYSTRING
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
        /// 请求Form参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string FORM
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
        ///    VARCHAR(500)  NULL
        /// </summary>
        public string PAGEURL_REGEX
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
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[5] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 请求参数是否已加密  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ENCRYPT_REQUEST_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ENCRYPT_REQUEST
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 请求参数是否已加密  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ENCRYPT_REQUEST
        ///	默认值:0
        /// </summary>
        public string ENCRYPT_REQUEST_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 请求参数已加密，审核  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ENCRYPT_REQUEST_AUDIT_ToString 更加准确
        /// </summary>
        public int ENCRYPT_REQUEST_AUDIT
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 请求参数已加密，审核  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ENCRYPT_REQUEST_AUDIT
        /// </summary>
        public string ENCRYPT_REQUEST_AUDIT_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 QUERYSTRING_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int QUERYSTRING_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 QUERYSTRING_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string QUERYSTRING_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FORM_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int FORM_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FORM_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string FORM_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        ///   返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 请求参数 返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        ///   返回 "PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_REGEX = "PAGEURL_REGEX";
        /// <summary>
        ///   返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 请求参数是否已加密 返回 "ENCRYPT_REQUEST", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ENCRYPT_REQUEST = "ENCRYPT_REQUEST";
        /// <summary>
        /// 请求参数已加密，审核 返回 "ENCRYPT_REQUEST_AUDIT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ENCRYPT_REQUEST_AUDIT = "ENCRYPT_REQUEST_AUDIT";
        /// <summary>
        ///   返回 "QUERYSTRING_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING_PHONE_ENCRYPT = "QUERYSTRING_PHONE_ENCRYPT";
        /// <summary>
        ///  返回 "FORM_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM_PHONE_ENCRYPT = "FORM_PHONE_ENCRYPT";

        #endregion
        #region 函数
        /// <summary>
        /// WEBSITE_MY_PAGEURL的构造函数
        /// </summary>
        public WEBSITE_MY_PAGEURL()
        {
            this.TableName = "WEBSITE_MY_PAGEURL";
            this.PrimaryKey = new string[] { _WEBMANAGER_NAME, _PAGEURL };

            this.columns = new string[] { _WEBMANAGER_NAME, _PAGEURL, _QUERYSTRING, _FORM, _PAGEURL_REGEX, _CREATETIME, _ENCRYPT_REQUEST, _ENCRYPT_REQUEST_AUDIT, _QUERYSTRING_PHONE_ENCRYPT, _FORM_PHONE_ENCRYPT };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WEBSITE_MY_PAGEURL的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, NVARCHAR, NVARCHAR, VARCHAR, DATETIME, INT, INT, INT, INT };
                this.Lengths = new int[] { 50, 500, 8000, 8000, 500, 8, 4, 4, 4, 4 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", "0", " ", "1", "1" };
                this.Descriptions = new string[] { " ", " ", "请求参数", "请求Form参数", " ", " ", "请求参数是否已加密", "请求参数已加密，审核", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="WEBMANAGER_NAME"></param>
        /// <param name="PAGEURL"> </param>
                /// <returns>bool</returns>
                public bool Find(string P_WEBMANAGER_NAME,string P_PAGEURL)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_PAGEURL;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝WEBSITE_MY_PAGEURL（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WEBSITE_MY_PAGEURL Copy()
                {
                    WEBSITE_MY_PAGEURL new_obj=new WEBSITE_MY_PAGEURL();
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
        private bool inner_join_database_sql_connect_stats = false;
        private bool left_join_database_sql_connect_stats = false;

        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=WEBSITE_MY_PAGEURL.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=WEBSITE_MY_PAGEURL.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
            }
        }

        /// <summary>
        /// INNER JOIN DATABASE_SQL_CONNECT_STATS DATABASE_SQL_CONNECT_STATS  ON DATABASE_SQL_CONNECT_STATS.PAGEURL=WEBSITE_MY_PAGEURL.PAGEURL
        /// </summary>
        public bool INNER_JOIN_DATABASE_SQL_CONNECT_STATS
        {
            set
            {
                this.inner_join_database_sql_connect_stats = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN DATABASE_SQL_CONNECT_STATS DATABASE_SQL_CONNECT_STATS  ON DATABASE_SQL_CONNECT_STATS.PAGEURL=WEBSITE_MY_PAGEURL.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_DATABASE_SQL_CONNECT_STATS
        {
            set
            {
                this.left_join_database_sql_connect_stats = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_WEBMANAGER
        /// LEFT_JOIN_ADMIN_WEBMANAGER
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
            if (this.inner_join_database_sql_connect_stats == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "DATABASE_SQL_CONNECT_STATS", "DATABASE_SQL_CONNECT_STATS", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_database_sql_connect_stats == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "DATABASE_SQL_CONNECT_STATS", "DATABASE_SQL_CONNECT_STATS", "PAGEURL", "PAGEURL");
            }
            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}