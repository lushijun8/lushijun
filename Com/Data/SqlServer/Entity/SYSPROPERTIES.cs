using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSPROPERTIES"
    /// Columns="ID,SMALLID,TYPE,NAME,VALUE"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSPROPERTIES : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:08:58 
        #region 属性
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        /// </summary>
        public int ID
        {
            set
            {
                this.ColumnValues[0] = value.ToString(); this.UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ID
        /// </summary>
        public string ID_ToString
        {
            get
            {
                return this.ColumnValues[0];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SMALLID_ToString 更加准确
        /// </summary>
        public int SMALLID
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 SMALLID
        /// </summary>
        public string SMALLID_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TYPE_ToString 更加准确
        /// </summary>
        public byte TYPE
        {
            set
            {
                this.ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 TYPE
        /// </summary>
        public string TYPE_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    NVARCHAR(256)  NOT NULL
        /// </summary>
        public string NAME
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
        ///   SQL_VARIANT(8016)  NULL
        /// </summary>
        public string VALUE
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
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "SMALLID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SMALLID = "SMALLID";
        /// <summary>
        ///   返回 "TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///  返回 "VALUE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VALUE = "VALUE";

        #endregion
        #region 函数
        /// <summary>
        /// SYSPROPERTIES的构造函数
        /// </summary>
        public SYSPROPERTIES()
        {
            this.TableName = "SYSPROPERTIES";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._ID, this._SMALLID, this._TYPE, this._NAME, this._VALUE };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSPROPERTIES的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, SMALLINT, TINYINT, NVARCHAR, SQL_VARIANT};
                this.Lengths = new int[] { 4, 2, 1, 256, 8016 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 1 };
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