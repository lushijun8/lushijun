
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WEBSITE_MY_PAGEURL_IGNORE"
    /// Columns="WEBMANAGER_NAME,PAGEURL,PAGEURL_REGEX,CREATETIME"
    /// PrimaryKeys="WEBMANAGER_NAME,PAGEURL"
    /// </summary>
    public sealed class WEBSITE_MY_PAGEURL_IGNORE : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/9/16 10:48:50
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
        ///    VARCHAR(500)  NULL
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
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[3] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[3];
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
        ///   返回 "PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_REGEX = "PAGEURL_REGEX";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// WEBSITE_MY_PAGEURL_IGNORE的构造函数
        /// </summary>
        public WEBSITE_MY_PAGEURL_IGNORE()
        {
            this.TableName = "WEBSITE_MY_PAGEURL_IGNORE";
            this.PrimaryKey = new string[] { _WEBMANAGER_NAME, _PAGEURL };

            this.columns = new string[] { _WEBMANAGER_NAME, _PAGEURL, _PAGEURL_REGEX, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WEBSITE_MY_PAGEURL_IGNORE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, DATETIME };
                this.Lengths = new int[] { 50, 500, 500, 8 };
                this.IsNullables = new int[] { 0, 0, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " " };
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
                /// 深度拷贝WEBSITE_MY_PAGEURL_IGNORE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WEBSITE_MY_PAGEURL_IGNORE Copy()
                {
                    WEBSITE_MY_PAGEURL_IGNORE new_obj=new WEBSITE_MY_PAGEURL_IGNORE();
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
        private bool inner_join_website_pageurl = false;
        private bool left_join_website_pageurl = false;
        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=WEBSITE_MY_PAGEURL_IGNORE.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=WEBSITE_MY_PAGEURL_IGNORE.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
            }
        }

        /// <summary>
        /// INNER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_MY_PAGEURL_IGNORE.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_PAGEURL
        {
            set
            {
                this.inner_join_website_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_MY_PAGEURL_IGNORE.PAGEURL
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
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}