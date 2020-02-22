using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSCOLUMNS"
    /// Columns="NAME,ID,XTYPE,TYPESTAT,XUSERTYPE,LENGTH,XPREC,XSCALE,COLID,XOFFSET,BITPOS,RESERVED,COLSTAT,CDEFAULT,DOMAIN,NUMBER,COLORDER,AUTOVAL,OFFSET,COLLATIONID,LANGUAGE,STATUS,TYPE,USERTYPE,PRINTFMT,PREC,SCALE,ISCOMPUTED,ISOUTPARAM,ISNULLABLE,COLLATION,TDSCOLLATION"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSCOLUMNS : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:10:36
        #region 属性
        /// <summary>
        ///   NVARCHAR(256)  NOT NULL
        /// </summary>
        public string NAME
        {
            get
            {
                return ColumnValues[0];
            }
            set
            {
                this.ColumnValues[0] = value; this.UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        /// </summary>
        public int ID
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ID
        /// </summary>
        public string ID_ToString
        {
            get
            {
                return ColumnValues[1];
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
                ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
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
                return ColumnValues[2];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TYPESTAT_ToString 更加准确
        /// </summary>
        public byte TYPESTAT
        {
            set
            {
                ColumnValues[3] = value.ToString(); this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 TYPESTAT
        /// </summary>
        public string TYPESTAT_ToString
        {
            get
            {
                return ColumnValues[3];
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
                ColumnValues[4] = value.ToString(); this.UpdateStatus[4] = 1;
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
                return ColumnValues[4];
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
                ColumnValues[5] = value.ToString(); this.UpdateStatus[5] = 1;
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
                return ColumnValues[5];
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
                ColumnValues[6] = value.ToString(); this.UpdateStatus[6] = 1;
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
                return ColumnValues[6];
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
                ColumnValues[7] = value.ToString(); this.UpdateStatus[7] = 1;
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
                return ColumnValues[7];
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
                ColumnValues[8] = value.ToString(); this.UpdateStatus[8] = 1;
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
                return ColumnValues[8];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XOFFSET_ToString 更加准确
        /// </summary>
        public int XOFFSET
        {
            set
            {
                ColumnValues[9] = value.ToString(); this.UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XOFFSET
        /// </summary>
        public string XOFFSET_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BITPOS_ToString 更加准确
        /// </summary>
        public byte BITPOS
        {
            set
            {
                ColumnValues[10] = value.ToString(); this.UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 BITPOS
        /// </summary>
        public string BITPOS_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED_ToString 更加准确
        /// </summary>
        public byte RESERVED
        {
            set
            {
                this.ColumnValues[11] = value.ToString(); this.UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED
        /// </summary>
        public string RESERVED_ToString
        {
            get
            {
                return this.ColumnValues[11];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLSTAT_ToString 更加准确
        /// </summary>
        public int COLSTAT
        {
            set
            {
                this.ColumnValues[12] = value.ToString(); this.UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 COLSTAT
        /// </summary>
        public string COLSTAT_ToString
        {
            get
            {
                return this.ColumnValues[12];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CDEFAULT_ToString 更加准确
        /// </summary>
        public int CDEFAULT
        {
            set
            {
                this.ColumnValues[13] = value.ToString(); this.UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CDEFAULT
        /// </summary>
        public string CDEFAULT_ToString
        {
            get
            {
                return this.ColumnValues[13];
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
                this.ColumnValues[14] = value.ToString(); this.UpdateStatus[14] = 1;
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
                return this.ColumnValues[14];
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
                this.ColumnValues[15] = value.ToString(); this.UpdateStatus[15] = 1;
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
                return this.ColumnValues[15];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLORDER_ToString 更加准确
        /// </summary>
        public int COLORDER
        {
            set
            {
                this.ColumnValues[16] = value.ToString(); this.UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 COLORDER
        /// </summary>
        public string COLORDER_ToString
        {
            get
            {
                return this.ColumnValues[16];
            }
        }
        /// <summary>
        ///    VARBINARY(8000)  NULL
        /// </summary>
        public string AUTOVAL
        {
            get
            {
                return this.ColumnValues[17];
            }
            set
            {
                this.ColumnValues[17] = value; this.UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 OFFSET_ToString 更加准确
        /// </summary>
        public int OFFSET
        {
            set
            {
                this.ColumnValues[18] = value.ToString(); this.UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 OFFSET
        /// </summary>
        public string OFFSET_ToString
        {
            get
            {
                return this.ColumnValues[18];
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
                this.ColumnValues[19] = value.ToString(); this.UpdateStatus[19] = 1;
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
                return this.ColumnValues[19];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LANGUAGE_ToString 更加准确
        /// </summary>
        public int LANGUAGE
        {
            set
            {
                this.ColumnValues[20] = value.ToString(); this.UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 LANGUAGE
        /// </summary>
        public string LANGUAGE_ToString
        {
            get
            {
                return this.ColumnValues[20];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public byte STATUS
        {
            set
            {
                this.ColumnValues[21] = value.ToString(); this.UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return this.ColumnValues[21];
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
                this.ColumnValues[22] = value.ToString(); this.UpdateStatus[22] = 1;
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
                return this.ColumnValues[22];
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
                this.ColumnValues[23] = value.ToString(); this.UpdateStatus[23] = 1;
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
                return this.ColumnValues[23];
            }
        }
        /// <summary>
        ///    VARCHAR(255)  NULL
        /// </summary>
        public string PRINTFMT
        {
            get
            {
                return this.ColumnValues[24];
            }
            set
            {
                this.ColumnValues[24] = value; this.UpdateStatus[24] = 1;
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
                this.ColumnValues[25] = value.ToString(); this.UpdateStatus[25] = 1;
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
                return this.ColumnValues[25];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SCALE_ToString 更加准确
        /// </summary>
        public int SCALE
        {
            set
            {
                this.ColumnValues[26] = value.ToString(); this.UpdateStatus[26] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SCALE
        /// </summary>
        public string SCALE_ToString
        {
            get
            {
                return this.ColumnValues[26];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ISCOMPUTED_ToString 更加准确
        /// </summary>
        public int ISCOMPUTED
        {
            set
            {
                this.ColumnValues[27] = value.ToString(); this.UpdateStatus[27] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ISCOMPUTED
        /// </summary>
        public string ISCOMPUTED_ToString
        {
            get
            {
                return this.ColumnValues[27];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ISOUTPARAM_ToString 更加准确
        /// </summary>
        public int ISOUTPARAM
        {
            set
            {
                this.ColumnValues[28] = value.ToString(); this.UpdateStatus[28] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ISOUTPARAM
        /// </summary>
        public string ISOUTPARAM_ToString
        {
            get
            {
                return this.ColumnValues[28];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ISNULLABLE_ToString 更加准确
        /// </summary>
        public int ISNULLABLE
        {
            set
            {
                this.ColumnValues[29] = value.ToString(); this.UpdateStatus[29] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ISNULLABLE
        /// </summary>
        public string ISNULLABLE_ToString
        {
            get
            {
                return this.ColumnValues[29];
            }
        }
        /// <summary>
        ///    NVARCHAR(256)  NULL
        /// </summary>
        public string COLLATION
        {
            get
            {
                return this.ColumnValues[30];
            }
            set
            {
                this.ColumnValues[30] = value; this.UpdateStatus[30] = 1;
            }
        }
        /// <summary>
        ///   BINARY(5)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TDSCOLLATION_ToString 更加准确
        /// </summary>
        public int TDSCOLLATION
        {
            set
            {
                this.ColumnValues[31] = value.ToString(); this.UpdateStatus[31] = 1;
            }
        }
        /// <summary>
        ///   BINARY(5)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TDSCOLLATION
        /// </summary>
        public string TDSCOLLATION_ToString
        {
            get
            {
                return this.ColumnValues[31];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "XTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XTYPE = "XTYPE";
        /// <summary>
        ///   返回 "TYPESTAT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TYPESTAT = "TYPESTAT";
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
        ///   返回 "COLID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLID = "COLID";
        /// <summary>
        ///   返回 "XOFFSET", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XOFFSET = "XOFFSET";
        /// <summary>
        ///   返回 "BITPOS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BITPOS = "BITPOS";
        /// <summary>
        ///   返回 "RESERVED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   返回 "COLSTAT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLSTAT = "COLSTAT";
        /// <summary>
        ///   返回 "CDEFAULT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CDEFAULT = "CDEFAULT";
        /// <summary>
        ///   返回 "DOMAIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DOMAIN = "DOMAIN";
        /// <summary>
        ///   返回 "NUMBER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NUMBER = "NUMBER";
        /// <summary>
        ///   返回 "COLORDER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLORDER = "COLORDER";
        /// <summary>
        ///   返回 "AUTOVAL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AUTOVAL = "AUTOVAL";
        /// <summary>
        ///   返回 "OFFSET", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _OFFSET = "OFFSET";
        /// <summary>
        ///   返回 "COLLATIONID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLLATIONID = "COLLATIONID";
        /// <summary>
        ///   返回 "LANGUAGE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LANGUAGE = "LANGUAGE";
        /// <summary>
        ///   返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   返回 "TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   返回 "USERTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERTYPE = "USERTYPE";
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
        ///   返回 "ISCOMPUTED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISCOMPUTED = "ISCOMPUTED";
        /// <summary>
        ///   返回 "ISOUTPARAM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISOUTPARAM = "ISOUTPARAM";
        /// <summary>
        ///   返回 "ISNULLABLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISNULLABLE = "ISNULLABLE";
        /// <summary>
        ///   返回 "COLLATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLLATION = "COLLATION";
        /// <summary>
        ///  返回 "TDSCOLLATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TDSCOLLATION = "TDSCOLLATION";

        #endregion
        #region 函数
        /// <summary>
        /// SYSCOLUMNS的构造函数
        /// </summary>
        public SYSCOLUMNS()
        {
            this.TableName = "SYSCOLUMNS";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._NAME, this._ID, this._XTYPE, this._TYPESTAT, this._XUSERTYPE, this._LENGTH, this._XPREC, this._XSCALE, this._COLID, this._XOFFSET, this._BITPOS, this._RESERVED, this._COLSTAT, this._CDEFAULT, this._DOMAIN, this._NUMBER, this._COLORDER, this._AUTOVAL, this._OFFSET, this._COLLATIONID, this._LANGUAGE, this._STATUS, this._TYPE, this._USERTYPE, this._PRINTFMT, this._PREC, this._SCALE, this._ISCOMPUTED, this._ISOUTPARAM, this._ISNULLABLE, this._COLLATION, this._TDSCOLLATION };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSCOLUMNS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, INT, TINYINT, TINYINT, SMALLINT, SMALLINT, TINYINT, TINYINT, SMALLINT, SMALLINT, TINYINT, TINYINT, SMALLINT, INT, INT, SMALLINT, SMALLINT, VARBINARY, SMALLINT, INT, INT, TINYINT, TINYINT, SMALLINT, VARCHAR, SMALLINT, INT, INT, INT, INT, NVARCHAR, BINARY };
                this.Lengths = new int[] { 256, 4, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 4, 4, 2, 2, 8000, 2, 4, 4, 1, 1, 2, 255, 2, 4, 4, 4, 4, 256, 5 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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