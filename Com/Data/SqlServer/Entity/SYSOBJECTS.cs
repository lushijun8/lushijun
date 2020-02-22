using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSOBJECTS"
    /// Columns="NAME,ID,XTYPE,UID,INFO,STATUS,BASE_SCHEMA_VER,REPLINFO,PARENT_OBJ,CRDATE,FTCATID,SCHEMA_VER,STATS_SCHEMA_VER,TYPE,USERSTAT,SYSSTAT,INDEXDEL,REFDATE,VERSION,DELTRIG,INSTRIG,UPDTRIG,SELTRIG,CATEGORY,CACHE"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSOBJECTS : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2011-3-1 15:07:04 
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
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    CHAR(2)  NOT NULL
        /// </summary>
        public string XTYPE
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
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 UID_ToString 更加准确
        /// </summary>
        public int UID
        {
            set
            {
                this.ColumnValues[3] = value.ToString(); this.UpdateStatus[3] = 1;
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
                return this.ColumnValues[3];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INFO_ToString 更加准确
        /// </summary>
        public int INFO
        {
            set
            {
                this.ColumnValues[4] = value.ToString(); this.UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 INFO
        /// </summary>
        public string INFO_ToString
        {
            get
            {
                return this.ColumnValues[4];
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
                this.ColumnValues[5] = value.ToString(); this.UpdateStatus[5] = 1;
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
                return this.ColumnValues[5];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BASE_SCHEMA_VER_ToString 更加准确
        /// </summary>
        public int BASE_SCHEMA_VER
        {
            set
            {
                this.ColumnValues[6] = value.ToString(); this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 BASE_SCHEMA_VER
        /// </summary>
        public string BASE_SCHEMA_VER_ToString
        {
            get
            {
                return this.ColumnValues[6];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 REPLINFO_ToString 更加准确
        /// </summary>
        public int REPLINFO
        {
            set
            {
                this.ColumnValues[7] = value.ToString(); this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 REPLINFO
        /// </summary>
        public string REPLINFO_ToString
        {
            get
            {
                return this.ColumnValues[7];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PARENT_OBJ_ToString 更加准确
        /// </summary>
        public int PARENT_OBJ
        {
            set
            {
                this.ColumnValues[8] = value.ToString(); this.UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 PARENT_OBJ
        /// </summary>
        public string PARENT_OBJ_ToString
        {
            get
            {
                return this.ColumnValues[8];
            }
        }
        /// <summary>
        ///    DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CRDATE_ToString 更加准确
        /// </summary>
        public DateTime CRDATE
        {
            set
            {
                this.ColumnValues[9] = value.ToString(); this.UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CRDATE
        /// </summary>
        public string CRDATE_ToString
        {
            get
            {
                return this.ColumnValues[9];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FTCATID_ToString 更加准确
        /// </summary>
        public int FTCATID
        {
            set
            {
                this.ColumnValues[10] = value.ToString(); this.UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 FTCATID
        /// </summary>
        public string FTCATID_ToString
        {
            get
            {
                return this.ColumnValues[10];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SCHEMA_VER_ToString 更加准确
        /// </summary>
        public int SCHEMA_VER
        {
            set
            {
                this.ColumnValues[11] = value.ToString(); this.UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 SCHEMA_VER
        /// </summary>
        public string SCHEMA_VER_ToString
        {
            get
            {
                return this.ColumnValues[11];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_SCHEMA_VER_ToString 更加准确
        /// </summary>
        public int STATS_SCHEMA_VER
        {
            set
            {
                this.ColumnValues[12] = value.ToString(); this.UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATS_SCHEMA_VER
        /// </summary>
        public string STATS_SCHEMA_VER_ToString
        {
            get
            {
                return this.ColumnValues[12];
            }
        }
        /// <summary>
        ///    CHAR(2)  NULL
        /// </summary>
        public string TYPE
        {
            get
            {
                return this.ColumnValues[13];
            }
            set
            {
                this.ColumnValues[13] = value; this.UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USERSTAT_ToString 更加准确
        /// </summary>
        public int USERSTAT
        {
            set
            {
                this.ColumnValues[14] = value.ToString(); this.UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USERSTAT
        /// </summary>
        public string USERSTAT_ToString
        {
            get
            {
                return this.ColumnValues[14];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SYSSTAT_ToString 更加准确
        /// </summary>
        public int SYSSTAT
        {
            set
            {
                this.ColumnValues[15] = value.ToString(); this.UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SYSSTAT
        /// </summary>
        public string SYSSTAT_ToString
        {
            get
            {
                return this.ColumnValues[15];
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INDEXDEL_ToString 更加准确
        /// </summary>
        public int INDEXDEL
        {
            set
            {
                this.ColumnValues[16] = value.ToString(); this.UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 INDEXDEL
        /// </summary>
        public string INDEXDEL_ToString
        {
            get
            {
                return this.ColumnValues[16];
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 REFDATE_ToString 更加准确
        /// </summary>
        public DateTime REFDATE
        {
            set
            {
                this.ColumnValues[17] = value.ToString(); this.UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 REFDATE
        /// </summary>
        public string REFDATE_ToString
        {
            get
            {
                return this.ColumnValues[17];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 VERSION_ToString 更加准确
        /// </summary>
        public int VERSION
        {
            set
            {
                this.ColumnValues[18] = value.ToString(); this.UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 VERSION
        /// </summary>
        public string VERSION_ToString
        {
            get
            {
                return this.ColumnValues[18];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DELTRIG_ToString 更加准确
        /// </summary>
        public int DELTRIG
        {
            set
            {
                this.ColumnValues[19] = value.ToString(); this.UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DELTRIG
        /// </summary>
        public string DELTRIG_ToString
        {
            get
            {
                return this.ColumnValues[19];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INSTRIG_ToString 更加准确
        /// </summary>
        public int INSTRIG
        {
            set
            {
                this.ColumnValues[20] = value.ToString(); this.UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 INSTRIG
        /// </summary>
        public string INSTRIG_ToString
        {
            get
            {
                return this.ColumnValues[20];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 UPDTRIG_ToString 更加准确
        /// </summary>
        public int UPDTRIG
        {
            set
            {
                this.ColumnValues[21] = value.ToString(); this.UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 UPDTRIG
        /// </summary>
        public string UPDTRIG_ToString
        {
            get
            {
                return this.ColumnValues[21];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SELTRIG_ToString 更加准确
        /// </summary>
        public int SELTRIG
        {
            set
            {
                this.ColumnValues[22] = value.ToString(); this.UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SELTRIG
        /// </summary>
        public string SELTRIG_ToString
        {
            get
            {
                return this.ColumnValues[22];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CATEGORY_ToString 更加准确
        /// </summary>
        public int CATEGORY
        {
            set
            {
                this.ColumnValues[23] = value.ToString(); this.UpdateStatus[23] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CATEGORY
        /// </summary>
        public string CATEGORY_ToString
        {
            get
            {
                return this.ColumnValues[23];
            }
        }
        /// <summary>
        ///   SMALLINT(2)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CACHE_ToString 更加准确
        /// </summary>
        public int CACHE
        {
            set
            {
                this.ColumnValues[24] = value.ToString(); this.UpdateStatus[24] = 1;
            }
        }
        /// <summary>
        ///   SMALLINT(2)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CACHE
        /// </summary>
        public string CACHE_ToString
        {
            get
            {
                return this.ColumnValues[24];
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
        ///   返回 "UID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UID = "UID";
        /// <summary>
        ///   返回 "INFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INFO = "INFO";
        /// <summary>
        ///   返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   返回 "BASE_SCHEMA_VER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BASE_SCHEMA_VER = "BASE_SCHEMA_VER";
        /// <summary>
        ///   返回 "REPLINFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REPLINFO = "REPLINFO";
        /// <summary>
        ///   返回 "PARENT_OBJ", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PARENT_OBJ = "PARENT_OBJ";
        /// <summary>
        ///   返回 "CRDATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CRDATE = "CRDATE";
        /// <summary>
        ///   返回 "FTCATID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FTCATID = "FTCATID";
        /// <summary>
        ///   返回 "SCHEMA_VER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SCHEMA_VER = "SCHEMA_VER";
        /// <summary>
        ///   返回 "STATS_SCHEMA_VER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_SCHEMA_VER = "STATS_SCHEMA_VER";
        /// <summary>
        ///   返回 "TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   返回 "USERSTAT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERSTAT = "USERSTAT";
        /// <summary>
        ///   返回 "SYSSTAT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SYSSTAT = "SYSSTAT";
        /// <summary>
        ///   返回 "INDEXDEL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INDEXDEL = "INDEXDEL";
        /// <summary>
        ///   返回 "REFDATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REFDATE = "REFDATE";
        /// <summary>
        ///   返回 "VERSION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VERSION = "VERSION";
        /// <summary>
        ///   返回 "DELTRIG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DELTRIG = "DELTRIG";
        /// <summary>
        ///   返回 "INSTRIG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INSTRIG = "INSTRIG";
        /// <summary>
        ///   返回 "UPDTRIG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UPDTRIG = "UPDTRIG";
        /// <summary>
        ///   返回 "SELTRIG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SELTRIG = "SELTRIG";
        /// <summary>
        ///   返回 "CATEGORY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CATEGORY = "CATEGORY";
        /// <summary>
        ///  返回 "CACHE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CACHE = "CACHE";

        #endregion
        #region 函数        
        /// <summary>
        /// SYSOBJECTS的构造函数
        /// </summary>
        public SYSOBJECTS()
        {
            this.TableName = "SYSOBJECTS";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._NAME, this._ID, this._XTYPE, this._UID, this._INFO, this._STATUS, this._BASE_SCHEMA_VER, this._REPLINFO, this._PARENT_OBJ, this._CRDATE, this._FTCATID, this._SCHEMA_VER, this._STATS_SCHEMA_VER, this._TYPE, this._USERSTAT, this._SYSSTAT, this._INDEXDEL, this._REFDATE, this._VERSION, this._DELTRIG, this._INSTRIG, this._UPDTRIG, this._SELTRIG, this._CATEGORY, this._CACHE };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SYSOBJECTS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, INT, CHAR, SMALLINT, SMALLINT, INT, INT, INT, INT, DATETIME, SMALLINT, INT, INT, CHAR, SMALLINT, SMALLINT, SMALLINT, DATETIME, INT, INT, INT, INT, INT, INT, SMALLINT};
                this.Lengths = new int[] { 256, 4, 2, 2, 2, 4, 4, 4, 4, 8, 2, 4, 4, 2, 2, 2, 2, 8, 4, 4, 4, 4, 4, 4, 2 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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