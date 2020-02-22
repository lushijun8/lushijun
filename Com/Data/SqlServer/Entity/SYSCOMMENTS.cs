using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSCOMMENTS"
    /// Columns="ID,NUMBER,COLID,STATUS,CTEXT,TEXTTYPE,LANGUAGE,ENCRYPTED,COMPRESSED,TEXT"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSCOMMENTS : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:10:07
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
        ///	只写属性，如果非要读取该字段的字符串,建议使用 NUMBER_ToString 更加准确
        /// </summary>
        public int NUMBER
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 NUMBER
        /// </summary>
        public string NUMBER_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLID_ToString 更加准确
        /// </summary>
        public int COLID
        {
            set
            {
                this.ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 COLID
        /// </summary>
        public string COLID_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public int STATUS
        {
            set
            {
                this.ColumnValues[3] = value.ToString(); this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return this.ColumnValues[3];
            }
        }
        /// <summary>
        ///    VARBINARY(8000)  NOT NULL
        /// </summary>
        public string CTEXT
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
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TEXTTYPE_ToString 更加准确
        /// </summary>
        public int TEXTTYPE
        {
            set
            {
                this.ColumnValues[5] = value.ToString(); this.UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TEXTTYPE
        /// </summary>
        public string TEXTTYPE_ToString
        {
            get
            {
                return this.ColumnValues[5];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LANGUAGE_ToString 更加准确
        /// </summary>
        public int LANGUAGE
        {
            set
            {
                this.ColumnValues[6] = value.ToString(); this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LANGUAGE
        /// </summary>
        public string LANGUAGE_ToString
        {
            get
            {
                return this.ColumnValues[6];
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ENCRYPTED_ToString 更加准确
        /// </summary>
        public bool ENCRYPTED
        {
            set
            {
                this.ColumnValues[7] = (value == true ? "1" : "0");
                this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ENCRYPTED
        /// </summary>
        public string ENCRYPTED_ToString
        {
            get
            {
                return this.ColumnValues[7];
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COMPRESSED_ToString 更加准确
        /// </summary>
        public bool COMPRESSED
        {
            set
            {
                this.ColumnValues[8] = (value == true ? "1" : "0");
                this.UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COMPRESSED
        /// </summary>
        public string COMPRESSED_ToString
        {
            get
            {
                return this.ColumnValues[8];
            }
        }
        /// <summary>
        ///   NVARCHAR(8000)  NULL
        /// </summary>
        public string TEXT
        {
            get
            {
                return this.ColumnValues[9];
            }
            set
            {
                this.ColumnValues[9] = value; this.UpdateStatus[9] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "NUMBER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NUMBER = "NUMBER";
        /// <summary>
        ///   返回 "COLID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLID = "COLID";
        /// <summary>
        ///   返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   返回 "CTEXT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CTEXT = "CTEXT";
        /// <summary>
        ///   返回 "TEXTTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEXTTYPE = "TEXTTYPE";
        /// <summary>
        ///   返回 "LANGUAGE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LANGUAGE = "LANGUAGE";
        /// <summary>
        ///   返回 "ENCRYPTED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ENCRYPTED = "ENCRYPTED";
        /// <summary>
        ///   返回 "COMPRESSED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COMPRESSED = "COMPRESSED";
        /// <summary>
        ///  返回 "TEXT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEXT = "TEXT";

        #endregion
        #region 函数

        /// <summary>
        /// SYSCOMMENTS的构造函数
        /// </summary>
        public SYSCOMMENTS()
        {
            this.TableName = "SYSCOMMENTS";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._ID, this._NUMBER, this._COLID, this._STATUS, this._CTEXT, this._TEXTTYPE, this._LANGUAGE, this._ENCRYPTED, this._COMPRESSED, this._TEXT };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSCOMMENTS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, SMALLINT, SMALLINT, SMALLINT, VARBINARY, SMALLINT, SMALLINT, BIT, BIT, NVARCHAR};
                this.Lengths = new int[] { 4, 2, 2, 2, 8000, 2, 2, 1, 1, 8000 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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