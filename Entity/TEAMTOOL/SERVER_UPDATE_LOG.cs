
using System;
namespace Entity.TEAMTOOL
{
	/// <summary>
	/// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="SERVER_UPDATE_LOG"
	/// Columns="ID,IP,USERNAME,SERVERNAME,CREATETIME"
	/// PrimaryKeys="ID"
	/// </summary>
    public sealed class SERVER_UPDATE_LOG : Entity.TEAMTOOL.EntityBase
	{
        #region 系统代码，请不要动   生成日期:2015/9/9 14:18:26
        #region 属性
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
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
        ///   BIGINT(8) 自增列 NOT NULL
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string IP
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
        ///    VARCHAR(100)  NULL
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string SERVERNAME
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
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IP = "IP";
        /// <summary>
        ///   返回 "USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERNAME = "USERNAME";
        /// <summary>
        ///   返回 "SERVERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERNAME = "SERVERNAME";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// SERVER_UPDATE_LOG的构造函数
        /// </summary>
        public SERVER_UPDATE_LOG()
        {
            this.TableName = "SERVER_UPDATE_LOG";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _IP, _USERNAME, _SERVERNAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SERVER_UPDATE_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, VARCHAR, DATETIME };
                this.Lengths = new int[] { 8, 100, 100, 100, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { " ", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID"></param>
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
                /// 深度拷贝SERVER_UPDATE_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SERVER_UPDATE_LOG Copy()
                {
                    SERVER_UPDATE_LOG new_obj=new SERVER_UPDATE_LOG();
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
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.USERNAME=SERVER_UPDATE_LOG.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.USERNAME=SERVER_UPDATE_LOG.WEBMANAGER_NAME
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
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "USERNAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "USERNAME");
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