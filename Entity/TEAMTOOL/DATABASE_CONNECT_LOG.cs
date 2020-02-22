
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_CONNECT_LOG"
    /// Columns="ID,SESSIONID,USERNAME,PAGEURL,QUERYSTRING,FORM,CONNECTNAME,CONNECTIME,CREATETIME,TEAMNAME,SERVERNAME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_CONNECT_LOG : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/9/21 10:16:16
        #region 属性
        /// <summary>
        /// 调用数据库连接串日志  BIGINT(8) 自增列 NOT NULL
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
        /// 调用数据库连接串日志  BIGINT(8) 自增列 NOT NULL
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
        /// 用户SessionID  VARCHAR(500)  NULL
        /// </summary>
        public string SESSIONID
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
        /// 用户名  VARCHAR(1000)  NULL
        /// </summary>
        public string USERNAME
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
        /// 原始url  VARCHAR(4000)  NULL
        /// </summary>
        public string PAGEURL
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
        /// 请求参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string QUERYSTRING
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
        /// 请求Form参数  NVARCHAR(8000)  NULL
        /// </summary>
        public string FORM
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
        /// 数据库连接串名称  VARCHAR(500)  NULL
        /// </summary>
        public string CONNECTNAME
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
        /// 连接时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIME_ToString 更加准确
        /// </summary>
        public DateTime CONNECTIME
        {
            set
            {
                ColumnValues[7] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 连接时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIME
        /// </summary>
        public string CONNECTIME_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 添加时间  DATETIME(8)  NULL
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
        /// 添加时间  DATETIME(8)  NULL
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
        /// <summary>
        /// 团队名称  VARCHAR(50)  NULL
        /// </summary>
        public string TEAMNAME
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
        ///   VARCHAR(50)  NULL
        /// </summary>
        public string SERVERNAME
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 调用数据库连接串日志 返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 用户SessionID 返回 "SESSIONID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SESSIONID = "SESSIONID";
        /// <summary>
        /// 用户名 返回 "USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERNAME = "USERNAME";
        /// <summary>
        /// 原始url 返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
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
        /// 数据库连接串名称 返回 "CONNECTNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTNAME = "CONNECTNAME";
        /// <summary>
        /// 连接时间 返回 "CONNECTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIME = "CONNECTIME";
        /// <summary>
        /// 添加时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 团队名称 返回 "TEAMNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEAMNAME = "TEAMNAME";
        /// <summary>
        ///  返回 "SERVERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERNAME = "SERVERNAME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_CONNECT_LOG的构造函数
        /// </summary>
        public DATABASE_CONNECT_LOG()
        {
            this.TableName = "DATABASE_CONNECT_LOG";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _SESSIONID, _USERNAME, _PAGEURL, _QUERYSTRING, _FORM, _CONNECTNAME, _CONNECTIME, _CREATETIME, _TEAMNAME, _SERVERNAME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_CONNECT_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, VARCHAR, NVARCHAR, NVARCHAR, VARCHAR, DATETIME, DATETIME, VARCHAR, VARCHAR };
                this.Lengths = new int[] { 8, 500, 1000, 4000, 8000, 8000, 500, 8, 8, 50, 50 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", "getdate", " ", " " };
                this.Descriptions = new string[] { "调用数据库连接串日志", "用户SessionID", "用户名", "原始url", "请求参数", "请求Form参数", "数据库连接串名称", "连接时间", "添加时间", "团队名称", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">调用数据库连接串日志</param>
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
                /// 深度拷贝DATABASE_CONNECT_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_CONNECT_LOG Copy()
                {
                    DATABASE_CONNECT_LOG new_obj=new DATABASE_CONNECT_LOG();
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

        private bool inner_join_database_connectstring = false;
        private bool left_join_database_connectstring = false;

        /// <summary>
        /// INNER JOIN DATABASE_CONNECTSTRING DATABASE_CONNECTSTRING  ON DATABASE_CONNECTSTRING.CONNECTNAME=DATABASE_CONNECT_LOG.DATABASE_CONNECTSTRING_NAME
        /// </summary>
        public bool INNER_JOIN_DATABASE_CONNECTSTRING
        {
            set
            {
                this.inner_join_database_connectstring = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN DATABASE_CONNECTSTRING DATABASE_CONNECTSTRING  ON DATABASE_CONNECTSTRING.CONNECTNAME=DATABASE_CONNECT_LOG.DATABASE_CONNECTSTRING_NAME
        /// </summary>
        public bool LEFT_JOIN_DATABASE_CONNECTSTRING
        {
            set
            {
                this.left_join_database_connectstring = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_DATABASE_CONNECTSTRING
        /// LEFT_JOIN_DATABASE_CONNECTSTRING

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_database_connectstring == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING_NAME", "CONNECTNAME");
            }
            if (this.left_join_database_connectstring == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING_NAME", "CONNECTNAME");
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