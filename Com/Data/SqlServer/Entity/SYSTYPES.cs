using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSTYPES"
    /// Columns="NAME,XTYPE,STATUS,XUSERTYPE,LENGTH,XPREC,XSCALE,TDEFAULT,DOMAIN,UID,RESERVED,COLLATIONID,USERTYPE,VARIABLE,ALLOWNULLS,TYPE,PRINTFMT,PREC,SCALE,COLLATION"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSTYPES : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:07:51 
        #region 属性
        /// <summary>
        ///   NVARCHAR(256)  NOT NULL
        /// </summary>
        public string NAME
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
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XTYPE_ToString 更加准确
        /// </summary>
        public byte XTYPE
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XTYPE
        /// </summary>
        public string XTYPE_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public byte STATUS
        {
            set
            {
                this.ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XUSERTYPE_ToString 更加准确
        /// </summary>
        public int XUSERTYPE
        {
            set
            {
                this.ColumnValues[3] = value.ToString(); this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XUSERTYPE
        /// </summary>
        public string XUSERTYPE_ToString
        {
            get
            {
                return this.ColumnValues[3];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LENGTH_ToString 更加准确
        /// </summary>
        public int LENGTH
        {
            set
            {
                this.ColumnValues[4] = value.ToString(); this.UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 LENGTH
        /// </summary>
        public string LENGTH_ToString
        {
            get
            {
                return this.ColumnValues[4];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XPREC_ToString 更加准确
        /// </summary>
        public byte XPREC
        {
            set
            {
                this.ColumnValues[5] = value.ToString(); this.UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XPREC
        /// </summary>
        public string XPREC_ToString
        {
            get
            {
                return this.ColumnValues[5];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XSCALE_ToString 更加准确
        /// </summary>
        public byte XSCALE
        {
            set
            {
                this.ColumnValues[6] = value.ToString(); this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XSCALE
        /// </summary>
        public string XSCALE_ToString
        {
            get
            {
                return this.ColumnValues[6];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TDEFAULT_ToString 更加准确
        /// </summary>
        public int TDEFAULT
        {
            set
            {
                this.ColumnValues[7] = value.ToString(); this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 TDEFAULT
        /// </summary>
        public string TDEFAULT_ToString
        {
            get
            {
                return this.ColumnValues[7];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DOMAIN_ToString 更加准确
        /// </summary>
        public int DOMAIN
        {
            set
            {
                this.ColumnValues[8] = value.ToString(); this.UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 DOMAIN
        /// </summary>
        public string DOMAIN_ToString
        {
            get
            {
                return this.ColumnValues[8];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 UID_ToString 更加准确
        /// </summary>
        public int UID
        {
            set
            {
                this.ColumnValues[9] = value.ToString(); this.UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 UID
        /// </summary>
        public string UID_ToString
        {
            get
            {
                return this.ColumnValues[9];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED_ToString 更加准确
        /// </summary>
        public int RESERVED
        {
            set
            {
                this.ColumnValues[10] = value.ToString(); this.UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED
        /// </summary>
        public string RESERVED_ToString
        {
            get
            {
                return this.ColumnValues[10];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLLATIONID_ToString 更加准确
        /// </summary>
        public int COLLATIONID
        {
            set
            {
                this.ColumnValues[11] = value.ToString(); this.UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLLATIONID
        /// </summary>
        public string COLLATIONID_ToString
        {
            get
            {
                return this.ColumnValues[11];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USERTYPE_ToString 更加准确
        /// </summary>
        public int USERTYPE
        {
            set
            {
                this.ColumnValues[12] = value.ToString(); this.UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USERTYPE
        /// </summary>
        public string USERTYPE_ToString
        {
            get
            {
                return this.ColumnValues[12];
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 VARIABLE_ToString 更加准确
        /// </summary>
        public bool VARIABLE
        {
            set
            {
                this.ColumnValues[13] = (value == true ? "1" : "0");
                this.UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 VARIABLE
        /// </summary>
        public string VARIABLE_ToString
        {
            get
            {
                return this.ColumnValues[13];
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ALLOWNULLS_ToString 更加准确
        /// </summary>
        public bool ALLOWNULLS
        {
            set
            {
                this.ColumnValues[14] = (value == true ? "1" : "0");
                this.UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ALLOWNULLS
        /// </summary>
        public string ALLOWNULLS_ToString
        {
            get
            {
                return this.ColumnValues[14];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TYPE_ToString 更加准确
        /// </summary>
        public byte TYPE
        {
            set
            {
                this.ColumnValues[15] = value.ToString(); this.UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TYPE
        /// </summary>
        public string TYPE_ToString
        {
            get
            {
                return this.ColumnValues[15];
            }
        }
        /// <summary>
        ///    VARCHAR(255)  NULL
        /// </summary>
        public string PRINTFMT
        {
            get
            {
                return this.ColumnValues[16];
            }
            set
            {
                this.ColumnValues[16] = value; this.UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PREC_ToString 更加准确
        /// </summary>
        public int PREC
        {
            set
            {
                this.ColumnValues[17] = value.ToString(); this.UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 PREC
        /// </summary>
        public string PREC_ToString
        {
            get
            {
                return this.ColumnValues[17];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SCALE_ToString 更加准确
        /// </summary>
        public byte SCALE
        {
            set
            {
                this.ColumnValues[19] = value.ToString(); this.UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SCALE
        /// </summary>
        public string SCALE_ToString
        {
            get
            {
                return this.ColumnValues[19];
            }
        }
        /// <summary>
        ///   NVARCHAR(256)  NULL
        /// </summary>
        public string COLLATION
        {
            get
            {
                return this.ColumnValues[20];
            }
            set
            {
                this.ColumnValues[20] = value; this.UpdateStatus[19] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   返回 "XTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XTYPE = "XTYPE";
        /// <summary>
        ///   返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   返回 "XUSERTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XUSERTYPE = "XUSERTYPE";
        /// <summary>
        ///   返回 "LENGTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LENGTH = "LENGTH";
        /// <summary>
        ///   返回 "XPREC", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XPREC = "XPREC";
        /// <summary>
        ///   返回 "XSCALE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XSCALE = "XSCALE";
        /// <summary>
        ///   返回 "TDEFAULT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TDEFAULT = "TDEFAULT";
        /// <summary>
        ///   返回 "DOMAIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DOMAIN = "DOMAIN";
        /// <summary>
        ///   返回 "UID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UID = "UID";
        /// <summary>
        ///   返回 "RESERVED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   返回 "COLLATIONID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLLATIONID = "COLLATIONID";
        /// <summary>
        ///   返回 "USERTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERTYPE = "USERTYPE";
        /// <summary>
        ///   返回 "VARIABLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VARIABLE = "VARIABLE";
        /// <summary>
        ///   返回 "ALLOWNULLS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ALLOWNULLS = "ALLOWNULLS";
        /// <summary>
        ///   返回 "TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   返回 "PRINTFMT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PRINTFMT = "PRINTFMT";
        /// <summary>
        ///   返回 "PREC", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PREC = "PREC";
        /// <summary>
        ///   返回 "SCALE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SCALE = "SCALE";
        /// <summary>
        ///  返回 "COLLATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLLATION = "COLLATION";

        #endregion
        #region 函数
        /// <summary>
        /// SYSTYPES的构造函数
        /// </summary>
        public SYSTYPES()
        {
            this.TableName = "SYSTYPES";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._NAME, this._XTYPE, this._STATUS, this._XUSERTYPE, this._LENGTH, this._XPREC, this._XSCALE, this._TDEFAULT, this._DOMAIN, this._UID, this._RESERVED, this._COLLATIONID, this._USERTYPE, this._VARIABLE, this._ALLOWNULLS, this._TYPE, this._PRINTFMT, this._PREC, this._SCALE, this._COLLATION };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSTYPES的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, TINYINT, TINYINT, SMALLINT, SMALLINT, TINYINT, TINYINT, INT, INT, SMALLINT, SMALLINT, INT, SMALLINT, BIT, BIT, TINYINT, VARCHAR, SMALLINT, TINYINT, NVARCHAR};
                this.Lengths = new int[] { 256, 1, 1, 2, 2, 1, 1, 4, 4, 2, 2, 4, 2, 1, 1, 1, 255, 2, 1, 256 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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