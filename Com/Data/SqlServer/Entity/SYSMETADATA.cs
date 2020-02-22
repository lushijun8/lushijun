using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    /// SYSMETADATA  本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="CZHOMEBBS" 
    /// Table="SYSMETADATA"
    /// Columns="TABLENAME,COLUMNS,PRIMARYKEYS,DATATYPES,LENGTHS,ISNULLABLE,DEFAULTS,DESCRIPTIONS,IDENTITYS"
    /// PrimaryKeys="TABLENAME"
    /// </summary>
    public sealed class SYSMETADATA : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:52:07
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string COLUMNS
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string PRIMARYKEYS
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DATATYPES
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string LENGTHS
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
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string ISNULLABLE
        {
            get
            {
                return this.ColumnValues[5];
            }
            set
            {
                this.ColumnValues[5] = value; this.UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DEFAULTS
        {
            get
            {
                return this.ColumnValues[6];
            }
            set
            {
                this.ColumnValues[6] = value; this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DESCRIPTIONS
        {
            get
            {
                return this.ColumnValues[7];
            }
            set
            {
                this.ColumnValues[7] = value; this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///   VARCHAR(100)  NULL
        /// </summary>
        public string IDENTITYS
        {
            get
            {
                return this.ColumnValues[8];
            }
            set
            {
                this.ColumnValues[8] = value; this.UpdateStatus[8] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "TABLENAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLENAME = "TABLENAME";
        /// <summary>
        ///   返回 "COLUMNS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMNS = "COLUMNS";
        /// <summary>
        ///   返回 "PRIMARYKEYS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PRIMARYKEYS = "PRIMARYKEYS";
        /// <summary>
        ///   返回 "DATATYPES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATATYPES = "DATATYPES";
        /// <summary>
        ///   返回 "LENGTHS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LENGTHS = "LENGTHS";
        /// <summary>
        ///   返回 "ISNULLABLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISNULLABLE = "ISNULLABLE";
        /// <summary>
        ///   返回 "DEFAULTS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEFAULTS = "DEFAULTS";
        /// <summary>
        ///   返回 "DESCRIPTIONS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DESCRIPTIONS = "DESCRIPTIONS";
        /// <summary>
        ///  返回 "IDENTITYS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IDENTITYS = "IDENTITYS";

        #endregion
        #region 函数       
        /// <summary>
        /// SYSMETADATA的构造函数
        /// </summary>
        public SYSMETADATA()
        {
            this.TableName = "SYSMETADATA";
            this.PrimaryKey = new string[] { this._TABLENAME };

            base.columns = new string[] { this._TABLENAME, this._COLUMNS, this._PRIMARYKEYS, this._DATATYPES, this._LENGTHS, this._ISNULLABLE, this._DEFAULTS, this._DESCRIPTIONS, this._IDENTITYS };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSMETADATA的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR};
                this.Lengths = new int[] { 100, 4000, 4000, 4000, 4000, 4000, 4000, 4000, 100 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
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