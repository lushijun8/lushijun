using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSINDEXES"
    /// Columns="ID,STATUS,FIRST,INDID,ROOT,MINLEN,KEYCNT,GROUPID,DPAGES,RESERVED,USED,ROWCNT,ROWMODCTR,RESERVED3,RESERVED4,XMAXLEN,MAXIROW,ORIGFILLFACTOR,STATVERSION,RESERVED2,FIRSTIAM,IMPID,LOCKFLAGS,PGMODCTR,KEYS,NAME,STATBLOB,MAXLEN,ROWS"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSINDEXES : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:09:31        
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
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public int STATUS
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FIRST_ToString 更加准确
        /// </summary>
        public int FIRST
        {
            set
            {
                this.ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 FIRST
        /// </summary>
        public string FIRST_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INDID_ToString 更加准确
        /// </summary>
        public int INDID
        {
            set
            {
                this.ColumnValues[3] = value.ToString(); this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 INDID
        /// </summary>
        public string INDID_ToString
        {
            get
            {
                return this.ColumnValues[3];
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROOT_ToString 更加准确
        /// </summary>
        public int ROOT
        {
            set
            {
                this.ColumnValues[4] = value.ToString(); this.UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ROOT
        /// </summary>
        public string ROOT_ToString
        {
            get
            {
                return this.ColumnValues[4];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MINLEN_ToString 更加准确
        /// </summary>
        public int MINLEN
        {
            set
            {
                this.ColumnValues[5] = value.ToString(); this.UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MINLEN
        /// </summary>
        public string MINLEN_ToString
        {
            get
            {
                return this.ColumnValues[5];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 KEYCNT_ToString 更加准确
        /// </summary>
        public int KEYCNT
        {
            set
            {
                this.ColumnValues[6] = value.ToString(); this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 KEYCNT
        /// </summary>
        public string KEYCNT_ToString
        {
            get
            {
                return this.ColumnValues[6];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GROUPID_ToString 更加准确
        /// </summary>
        public int GROUPID
        {
            set
            {
                this.ColumnValues[7] = value.ToString(); this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 GROUPID
        /// </summary>
        public string GROUPID_ToString
        {
            get
            {
                return this.ColumnValues[7];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DPAGES_ToString 更加准确
        /// </summary>
        public int DPAGES
        {
            set
            {
                this.ColumnValues[8] = value.ToString(); this.UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 DPAGES
        /// </summary>
        public string DPAGES_ToString
        {
            get
            {
                return this.ColumnValues[8];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED_ToString 更加准确
        /// </summary>
        public int RESERVED
        {
            set
            {
                this.ColumnValues[9] = value.ToString(); this.UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED
        /// </summary>
        public string RESERVED_ToString
        {
            get
            {
                return this.ColumnValues[9];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USED_ToString 更加准确
        /// </summary>
        public int USED
        {
            set
            {
                this.ColumnValues[10] = value.ToString(); this.UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 USED
        /// </summary>
        public string USED_ToString
        {
            get
            {
                return this.ColumnValues[10];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCNT_ToString 更加准确
        /// </summary>
        public int ROWCNT
        {
            set
            {
                this.ColumnValues[11] = value.ToString(); this.UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCNT
        /// </summary>
        public string ROWCNT_ToString
        {
            get
            {
                return this.ColumnValues[11];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWMODCTR_ToString 更加准确
        /// </summary>
        public int ROWMODCTR
        {
            set
            {
                this.ColumnValues[12] = value.ToString(); this.UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWMODCTR
        /// </summary>
        public string ROWMODCTR_ToString
        {
            get
            {
                return this.ColumnValues[12];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED3_ToString 更加准确
        /// </summary>
        public byte RESERVED3
        {
            set
            {
                this.ColumnValues[13] = value.ToString(); this.UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED3
        /// </summary>
        public string RESERVED3_ToString
        {
            get
            {
                return this.ColumnValues[13];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED4_ToString 更加准确
        /// </summary>
        public byte RESERVED4
        {
            set
            {
                this.ColumnValues[14] = value.ToString(); this.UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED4
        /// </summary>
        public string RESERVED4_ToString
        {
            get
            {
                return this.ColumnValues[14];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 XMAXLEN_ToString 更加准确
        /// </summary>
        public int XMAXLEN
        {
            set
            {
                this.ColumnValues[15] = value.ToString(); this.UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 XMAXLEN
        /// </summary>
        public string XMAXLEN_ToString
        {
            get
            {
                return this.ColumnValues[15];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MAXIROW_ToString 更加准确
        /// </summary>
        public int MAXIROW
        {
            set
            {
                this.ColumnValues[16] = value.ToString(); this.UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MAXIROW
        /// </summary>
        public string MAXIROW_ToString
        {
            get
            {
                return this.ColumnValues[16];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ORIGFILLFACTOR_ToString 更加准确
        /// </summary>
        public byte ORIGFILLFACTOR
        {
            set
            {
                this.ColumnValues[17] = value.ToString(); this.UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ORIGFILLFACTOR
        /// </summary>
        public string ORIGFILLFACTOR_ToString
        {
            get
            {
                return this.ColumnValues[17];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATVERSION_ToString 更加准确
        /// </summary>
        public byte STATVERSION
        {
            set
            {
                this.ColumnValues[18] = value.ToString(); this.UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATVERSION
        /// </summary>
        public string STATVERSION_ToString
        {
            get
            {
                return this.ColumnValues[18];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED2_ToString 更加准确
        /// </summary>
        public int RESERVED2
        {
            set
            {
                this.ColumnValues[19] = value.ToString(); this.UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED2
        /// </summary>
        public string RESERVED2_ToString
        {
            get
            {
                return this.ColumnValues[19];
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FIRSTIAM_ToString 更加准确
        /// </summary>
        public int FIRSTIAM
        {
            set
            {
                this.ColumnValues[20] = value.ToString(); this.UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        ///    BINARY(6)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 FIRSTIAM
        /// </summary>
        public string FIRSTIAM_ToString
        {
            get
            {
                return this.ColumnValues[20];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 IMPID_ToString 更加准确
        /// </summary>
        public int IMPID
        {
            set
            {
                this.ColumnValues[21] = value.ToString(); this.UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 IMPID
        /// </summary>
        public string IMPID_ToString
        {
            get
            {
                return this.ColumnValues[21];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOCKFLAGS_ToString 更加准确
        /// </summary>
        public int LOCKFLAGS
        {
            set
            {
                this.ColumnValues[22] = value.ToString(); this.UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 LOCKFLAGS
        /// </summary>
        public string LOCKFLAGS_ToString
        {
            get
            {
                return this.ColumnValues[22];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PGMODCTR_ToString 更加准确
        /// </summary>
        public int PGMODCTR
        {
            set
            {
                this.ColumnValues[23] = value.ToString(); this.UpdateStatus[23] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 PGMODCTR
        /// </summary>
        public string PGMODCTR_ToString
        {
            get
            {
                return this.ColumnValues[23];
            }
        }
        /// <summary>
        ///    VARBINARY(1088)  NULL
        /// </summary>
        public string KEYS
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
        ///    NVARCHAR(256)  NOT NULL
        /// </summary>
        public string NAME
        {
            get
            {
                return this.ColumnValues[25];
            }
            set
            {
                this.ColumnValues[25] = value; this.UpdateStatus[25] = 1;
            }
        }
        /// <summary>
        ///    IMAGE(16)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATBLOB_ToString 更加准确
        /// </summary>
        public byte[] STATBLOB
        {
            set
            {
                this.ColumnValues[26] = value.ToString(); this.UpdateStatus[26] = 1;
            }
        }
        /// <summary>
        ///    IMAGE(16)  NULL
        ///	只读属性，如果非要写入该字段，请使用 STATBLOB
        /// </summary>
        public string STATBLOB_ToString
        {
            get
            {
                return this.ColumnValues[26];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MAXLEN_ToString 更加准确
        /// </summary>
        public int MAXLEN
        {
            set
            {
                this.ColumnValues[27] = value.ToString(); this.UpdateStatus[27] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MAXLEN
        /// </summary>
        public string MAXLEN_ToString
        {
            get
            {
                return this.ColumnValues[27];
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWS_ToString 更加准确
        /// </summary>
        public int ROWS
        {
            set
            {
                this.ColumnValues[28] = value.ToString(); this.UpdateStatus[28] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWS
        /// </summary>
        public string ROWS_ToString
        {
            get
            {
                return this.ColumnValues[28];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   返回 "FIRST", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FIRST = "FIRST";
        /// <summary>
        ///   返回 "INDID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INDID = "INDID";
        /// <summary>
        ///   返回 "ROOT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROOT = "ROOT";
        /// <summary>
        ///   返回 "MINLEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MINLEN = "MINLEN";
        /// <summary>
        ///   返回 "KEYCNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _KEYCNT = "KEYCNT";
        /// <summary>
        ///   返回 "GROUPID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GROUPID = "GROUPID";
        /// <summary>
        ///   返回 "DPAGES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DPAGES = "DPAGES";
        /// <summary>
        ///   返回 "RESERVED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   返回 "USED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USED = "USED";
        /// <summary>
        ///   返回 "ROWCNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCNT = "ROWCNT";
        /// <summary>
        ///   返回 "ROWMODCTR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWMODCTR = "ROWMODCTR";
        /// <summary>
        ///   返回 "RESERVED3", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED3 = "RESERVED3";
        /// <summary>
        ///   返回 "RESERVED4", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED4 = "RESERVED4";
        /// <summary>
        ///   返回 "XMAXLEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XMAXLEN = "XMAXLEN";
        /// <summary>
        ///   返回 "MAXIROW", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MAXIROW = "MAXIROW";
        /// <summary>
        ///   返回 "ORIGFILLFACTOR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ORIGFILLFACTOR = "ORIGFILLFACTOR";
        /// <summary>
        ///   返回 "STATVERSION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATVERSION = "STATVERSION";
        /// <summary>
        ///   返回 "RESERVED2", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED2 = "RESERVED2";
        /// <summary>
        ///   返回 "FIRSTIAM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FIRSTIAM = "FIRSTIAM";
        /// <summary>
        ///   返回 "IMPID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IMPID = "IMPID";
        /// <summary>
        ///   返回 "LOCKFLAGS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOCKFLAGS = "LOCKFLAGS";
        /// <summary>
        ///   返回 "PGMODCTR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PGMODCTR = "PGMODCTR";
        /// <summary>
        ///   返回 "KEYS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _KEYS = "KEYS";
        /// <summary>
        ///   返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   返回 "STATBLOB", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATBLOB = "STATBLOB";
        /// <summary>
        ///   返回 "MAXLEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MAXLEN = "MAXLEN";
        /// <summary>
        ///  返回 "ROWS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWS = "ROWS";

        #endregion
        #region 函数
        /// <summary>
        /// SYSINDEXES的构造函数
        /// </summary>
        public SYSINDEXES()
        {
            this.TableName = "SYSINDEXES";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._ID, this._STATUS, this._FIRST, this._INDID, this._ROOT, this._MINLEN, this._KEYCNT, this._GROUPID, this._DPAGES, this._RESERVED, this._USED, this._ROWCNT, this._ROWMODCTR, this._RESERVED3, this._RESERVED4, this._XMAXLEN, this._MAXIROW, this._ORIGFILLFACTOR, this._STATVERSION, this._RESERVED2, this._FIRSTIAM, this._IMPID, this._LOCKFLAGS, this._PGMODCTR, this._KEYS, this._NAME, this._STATBLOB, this._MAXLEN, this._ROWS };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSINDEXES的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, INT, BINARY, SMALLINT, BINARY, SMALLINT, SMALLINT, SMALLINT, INT, INT, INT, BIGINT, INT, TINYINT, TINYINT, SMALLINT, SMALLINT, TINYINT, TINYINT, INT, BINARY, SMALLINT, SMALLINT, INT, VARBINARY, NVARCHAR, IMAGE, INT, INT };
                this.Lengths = new int[] { 4, 4, 6, 2, 6, 2, 2, 2, 4, 4, 4, 8, 4, 1, 1, 2, 2, 1, 1, 4, 6, 2, 2, 4, 1088, 256, 16, 4, 4 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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