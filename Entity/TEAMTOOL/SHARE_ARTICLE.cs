using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="SHARE_ARTICLE"
    /// Columns="ARTICLE_ID,ARTICLE_TYPE,ARTICLE_SHARE_WEBMANAGER_NAME,ARTICLE_TITLE,ARTICLE_TEXT,ARTICLE_CREATETIME,ARTICLE_GOOD,ARTICLE_VIEWCOUNT,ARTICLE_DELETED"
    /// PrimaryKeys="ARTICLE_ID"
    /// </summary>
    public sealed class SHARE_ARTICLE  : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/12/1 13:59:11
        #region 属性
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public long ARTICLE_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_ID
        ///	唯一主键
        /// </summary>
        public string ARTICLE_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 0一句话道理，1分享文章  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_TYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ARTICLE_TYPE
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 0一句话道理，1分享文章  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_TYPE
        ///	默认值:0
        /// </summary>
        public string ARTICLE_TYPE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///    NVARCHAR(100)  NULL
        ///	默认值:lushijun
        /// </summary>
        public string ARTICLE_SHARE_WEBMANAGER_NAME
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
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string ARTICLE_TITLE
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
        ///    NTEXT(16)  NULL
        /// </summary>
        public string ARTICLE_TEXT
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
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime ARTICLE_CREATETIME
        {
            set
            {
                ColumnValues[5] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string ARTICLE_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_GOOD_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ARTICLE_GOOD
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_GOOD
        ///	默认值:0
        /// </summary>
        public string ARTICLE_GOOD_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_VIEWCOUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ARTICLE_VIEWCOUNT
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_VIEWCOUNT
        ///	默认值:0
        /// </summary>
        public string ARTICLE_VIEWCOUNT_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 是否删除  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_DELETED_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ARTICLE_DELETED
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 是否删除  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_DELETED
        ///	默认值:0
        /// </summary>
        public string ARTICLE_DELETED_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ARTICLE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_ID = "ARTICLE_ID";
        /// <summary>
        /// 0一句话道理，1分享文章 返回 "ARTICLE_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_TYPE = "ARTICLE_TYPE";
        /// <summary>
        ///   返回 "ARTICLE_SHARE_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_SHARE_WEBMANAGER_NAME = "ARTICLE_SHARE_WEBMANAGER_NAME";
        /// <summary>
        ///   返回 "ARTICLE_TITLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_TITLE = "ARTICLE_TITLE";
        /// <summary>
        ///   返回 "ARTICLE_TEXT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_TEXT = "ARTICLE_TEXT";
        /// <summary>
        ///   返回 "ARTICLE_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_CREATETIME = "ARTICLE_CREATETIME";
        /// <summary>
        ///   返回 "ARTICLE_GOOD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_GOOD = "ARTICLE_GOOD";
        /// <summary>
        ///   返回 "ARTICLE_VIEWCOUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_VIEWCOUNT = "ARTICLE_VIEWCOUNT";
        /// <summary>
        /// 是否删除 返回 "ARTICLE_DELETED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_DELETED = "ARTICLE_DELETED";

        #endregion
        #region 函数
        /// <summary>
        /// SHARE_ARTICLE的构造函数
        /// </summary>
        public SHARE_ARTICLE()
        {
            this.TableName = "SHARE_ARTICLE";
            this.PrimaryKey = new string[] { _ARTICLE_ID };
            this.IdentityColumn = this._ARTICLE_ID;
            this.columns = new string[] { _ARTICLE_ID, _ARTICLE_TYPE, _ARTICLE_SHARE_WEBMANAGER_NAME, _ARTICLE_TITLE, _ARTICLE_TEXT, _ARTICLE_CREATETIME, _ARTICLE_GOOD, _ARTICLE_VIEWCOUNT, _ARTICLE_DELETED };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SHARE_ARTICLE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, INT, NVARCHAR, NVARCHAR, NTEXT, DATETIME, INT, INT, INT };
                this.Lengths = new int[] { 8, 4, 100, 100, 16, 8, 4, 4, 4 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", "0", "lushijun", " ", " ", "getdate", "0", "0", "0" };
                this.Descriptions = new string[] { " ", "0一句话道理，1分享文章", " ", " ", " ", " ", " ", " ", "是否删除" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ARTICLE_ID"></param>
                /// <returns>bool</returns>
                public bool Find(long P_ARTICLE_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_ARTICLE_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SHARE_ARTICLE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SHARE_ARTICLE Copy()
                {
                    SHARE_ARTICLE new_obj=new SHARE_ARTICLE();
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

        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.ARTICLE_SHARE_WEBMANAGER_NAME=SHARE_ARTICLE.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.ARTICLE_SHARE_WEBMANAGER_NAME=SHARE_ARTICLE.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
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
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "ARTICLE_SHARE_WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "ARTICLE_SHARE_WEBMANAGER_NAME");
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