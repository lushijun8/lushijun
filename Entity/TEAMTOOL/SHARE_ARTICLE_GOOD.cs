using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
	/// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="SHARE_ARTICLE_GOOD"
	/// Columns="ARTICLE_ID,WEBMANAGER_NAME,CREATETIME"
	/// PrimaryKeys="ARTICLE_ID,WEBMANAGER_NAME"
	/// </summary>
    public sealed class SHARE_ARTICLE_GOOD   : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/11/17 11:59:18
        #region 属性
        /// <summary>
        ///   BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ARTICLE_ID_ToString 更加准确
        ///	主健之一，其他主健还有：ARTICLE_ID,WEBMANAGER_NAME
        /// </summary>
        public long ARTICLE_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ARTICLE_ID
        ///	主健之一，其他主健还有：ARTICLE_ID,WEBMANAGER_NAME
        /// </summary>
        public string ARTICLE_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：ARTICLE_ID,WEBMANAGER_NAME
        /// </summary>
        public string WEBMANAGER_NAME
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
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
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
                return ColumnValues[2];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ARTICLE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ARTICLE_ID = "ARTICLE_ID";
        /// <summary>
        ///   返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// SHARE_ARTICLE_GOOD的构造函数
        /// </summary>
        public SHARE_ARTICLE_GOOD()
        {
            this.TableName = "SHARE_ARTICLE_GOOD";
            this.PrimaryKey = new string[] { _ARTICLE_ID, _WEBMANAGER_NAME };

            this.columns = new string[] { _ARTICLE_ID, _WEBMANAGER_NAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SHARE_ARTICLE_GOOD的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0 };
                this.DataTypes = new string[] { BIGINT, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 8, 100, 8 };
                this.IsNullables = new int[] { 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ARTICLE_ID"></param>
        /// <param name="WEBMANAGER_NAME"> </param>
                /// <returns>bool</returns>
                public bool Find(long P_ARTICLE_ID,string P_WEBMANAGER_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_ARTICLE_ID.ToString();
        this.ColumnValues[1]=P_WEBMANAGER_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SHARE_ARTICLE_GOOD（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SHARE_ARTICLE_GOOD Copy()
                {
                    SHARE_ARTICLE_GOOD new_obj=new SHARE_ARTICLE_GOOD();
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
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=SHARE_ARTICLE_GOOD.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=SHARE_ARTICLE_GOOD.WEBMANAGER_NAME
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
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
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