using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="SHARE_VIEW"
    /// Columns="VIEW_WEBMANAGER_NAME,VIEW_TIME,VIEW_ARTICLE_ID,VIEW_BG_NO,CREATETIME"
    /// PrimaryKeys="VIEW_WEBMANAGER_NAME,VIEW_TIME"
    /// </summary>
    public sealed class SHARE_VIEW : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/12/3 10:11:29
        #region 属性
        /// <summary>
        ///   NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：VIEW_WEBMANAGER_NAME,VIEW_TIME
        /// </summary>
        public string VIEW_WEBMANAGER_NAME
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
        ///    DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 VIEW_TIME_ToString 更加准确
        ///	主健之一，其他主健还有：VIEW_WEBMANAGER_NAME,VIEW_TIME
        /// </summary>
        public DateTime VIEW_TIME
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 VIEW_TIME
        ///	主健之一，其他主健还有：VIEW_WEBMANAGER_NAME,VIEW_TIME
        /// </summary>
        public string VIEW_TIME_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 VIEW_ARTICLE_ID_ToString 更加准确
        /// </summary>
        public long VIEW_ARTICLE_ID
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 VIEW_ARTICLE_ID
        /// </summary>
        public string VIEW_ARTICLE_ID_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 北京图片ID  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 VIEW_BG_NO_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int VIEW_BG_NO
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 北京图片ID  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 VIEW_BG_NO
        ///	默认值:1
        /// </summary>
        public string VIEW_BG_NO_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[4] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "VIEW_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VIEW_WEBMANAGER_NAME = "VIEW_WEBMANAGER_NAME";
        /// <summary>
        ///   返回 "VIEW_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VIEW_TIME = "VIEW_TIME";
        /// <summary>
        ///   返回 "VIEW_ARTICLE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VIEW_ARTICLE_ID = "VIEW_ARTICLE_ID";
        /// <summary>
        /// 北京图片ID 返回 "VIEW_BG_NO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VIEW_BG_NO = "VIEW_BG_NO";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// SHARE_VIEW的构造函数
        /// </summary>
        public SHARE_VIEW()
        {
            this.TableName = "SHARE_VIEW";
            this.PrimaryKey = new string[] { _VIEW_WEBMANAGER_NAME, _VIEW_TIME };

            this.columns = new string[] { _VIEW_WEBMANAGER_NAME, _VIEW_TIME, _VIEW_ARTICLE_ID, _VIEW_BG_NO, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SHARE_VIEW的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, DATETIME, BIGINT, INT, DATETIME };
                this.Lengths = new int[] { 100, 8, 8, 4, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", "1", "getdate" };
                this.Descriptions = new string[] { " ", " ", " ", "北京图片ID", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="VIEW_WEBMANAGER_NAME"></param>
        /// <param name="VIEW_TIME"> </param>
                /// <returns>bool</returns>
                public bool Find(string P_VIEW_WEBMANAGER_NAME,DateTime P_VIEW_TIME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_VIEW_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_VIEW_TIME.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SHARE_VIEW（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SHARE_VIEW Copy()
                {
                    SHARE_VIEW new_obj=new SHARE_VIEW();
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
        private bool inner_join_share_article = false;
        private bool left_join_share_article = false;
        private bool inner_join_admin_webmanager = false;
        private bool left_join_admin_webmanager = false;

       
        /// <summary>
        /// INNER JOIN SHARE_ARTICLE SHARE_ARTICLE  ON SHARE_ARTICLE.VIEW_ARTICLE_ID=SHARE_VIEW.ARTICLE_ID
        /// </summary>
        public bool INNER_JOIN_SHARE_ARTICLE
        {
            set
            {
                this.inner_join_share_article = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN SHARE_ARTICLE SHARE_ARTICLE  ON SHARE_ARTICLE.VIEW_ARTICLE_ID=SHARE_VIEW.ARTICLE_ID
        /// </summary>
        public bool LEFT_JOIN_SHARE_ARTICLE
        {
            set
            {
                this.left_join_share_article = value;
            }
        }
        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.VIEW_WEBMANAGER_NAME=SHARE_VIEW.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.VIEW_WEBMANAGER_NAME=SHARE_VIEW.WEBMANAGER_NAME
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
        /// INNER_JOIN_SHARE_ARTICLE
        /// LEFT_JOIN_SHARE_ARTICLE

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_share_article == true)
            {
                this.NewJoin("", "INNER", "SHARE_ARTICLE", "SHARE_ARTICLE", "ARTICLE_ID", "VIEW_ARTICLE_ID");
            }
            if (this.left_join_share_article == true)
            {
                this.NewJoin("", "LEFT OUTER", "SHARE_ARTICLE", "SHARE_ARTICLE", "ARTICLE_ID", "VIEW_ARTICLE_ID");
            }
            if (this.inner_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "VIEW_WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "VIEW_WEBMANAGER_NAME");
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

