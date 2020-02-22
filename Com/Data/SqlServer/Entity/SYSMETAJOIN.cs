using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    /// 本类中的(系统代码)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="" 
    /// Table="SYSMETAJOIN"
    /// Columns="TABLENAME,COLUMNNAME,JOIN_DATABASE,JOIN_TABLENAME,JOIN_COLUMNNAME"
    /// PrimaryKeys="TABLENAME,COLUMNNAME"
    /// </summary>
    public sealed class SYSMETAJOIN : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:56:12 
        #region 属性
        /// <summary>
        ///   VARCHAR(100)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string TABLENAME
        {
            get
            {
                return this.ColumnValues[0];
            }
            set
            {
                this.ColumnValues[0] = value; this.UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string COLUMNNAME
        {
            get
            {
                return this.ColumnValues[1];
            }
            set
            {
                this.ColumnValues[1] = value; this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_DATABASE
        {
            get
            {
                return this.ColumnValues[2];
            }
            set
            {
                this.ColumnValues[2] = value; this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_TABLENAME
        {
            get
            {
                return this.ColumnValues[3];
            }
            set
            {
                this.ColumnValues[3] = value; this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///   VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_COLUMNNAME
        {
            get
            {
                return this.ColumnValues[4];
            }
            set
            {
                this.ColumnValues[4] = value; this.UpdateStatus[4] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "TABLENAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLENAME = "TABLENAME";
        /// <summary>
        ///   返回 "COLUMNNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMNNAME = "COLUMNNAME";
        /// <summary>
        ///   返回 "JOIN_DATABASE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _JOIN_DATABASE = "JOIN_DATABASE";
        /// <summary>
        ///   返回 "JOIN_TABLENAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _JOIN_TABLENAME = "JOIN_TABLENAME";
        /// <summary>
        ///  返回 "JOIN_COLUMNNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _JOIN_COLUMNNAME = "JOIN_COLUMNNAME";

        #endregion
        #region 函数 
        /// <summary>
        /// SYSMETAJOIN的构造函数
        /// </summary>
        public SYSMETAJOIN()
        {
            this.TableName = "SYSMETAJOIN";
            this.PrimaryKey = new string[] { this._TABLENAME };

            this.columns = new string[] { this._TABLENAME, this._COLUMNNAME, this._JOIN_DATABASE, this._JOIN_TABLENAME, this._JOIN_COLUMNNAME };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSMETAJOIN的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR};
                this.Lengths = new int[] { 100, 100, 100, 100, 100 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " " };
            }
        } 
        #endregion
        #region 实现关联Join方法和属性

        #endregion
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}