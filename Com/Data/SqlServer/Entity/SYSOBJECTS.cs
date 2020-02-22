using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSOBJECTS"
    /// Columns="NAME,ID,XTYPE,UID,INFO,STATUS,BASE_SCHEMA_VER,REPLINFO,PARENT_OBJ,CRDATE,FTCATID,SCHEMA_VER,STATS_SCHEMA_VER,TYPE,USERSTAT,SYSSTAT,INDEXDEL,REFDATE,VERSION,DELTRIG,INSTRIG,UPDTRIG,SELTRIG,CATEGORY,CACHE"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSOBJECTS : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:07:04 
        #region ����
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� UID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� UID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� INFO_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� INFO
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATUS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATUS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� BASE_SCHEMA_VER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� BASE_SCHEMA_VER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� REPLINFO_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� REPLINFO
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� PARENT_OBJ_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� PARENT_OBJ
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� CRDATE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� CRDATE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� FTCATID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� FTCATID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SCHEMA_VER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SCHEMA_VER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATS_SCHEMA_VER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATS_SCHEMA_VER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� USERSTAT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� USERSTAT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SYSSTAT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SYSSTAT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� INDEXDEL_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� INDEXDEL
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� REFDATE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� REFDATE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� VERSION_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� VERSION
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� DELTRIG_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� DELTRIG
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� INSTRIG_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� INSTRIG
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� UPDTRIG_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� UPDTRIG
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SELTRIG_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SELTRIG
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� CATEGORY_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� CATEGORY
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� CACHE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� CACHE
        /// </summary>
        public string CACHE_ToString
        {
            get
            {
                return this.ColumnValues[24];
            }
        }

        #endregion
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "NAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   ���� "ID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   ���� "XTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XTYPE = "XTYPE";
        /// <summary>
        ///   ���� "UID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _UID = "UID";
        /// <summary>
        ///   ���� "INFO", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _INFO = "INFO";
        /// <summary>
        ///   ���� "STATUS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   ���� "BASE_SCHEMA_VER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _BASE_SCHEMA_VER = "BASE_SCHEMA_VER";
        /// <summary>
        ///   ���� "REPLINFO", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _REPLINFO = "REPLINFO";
        /// <summary>
        ///   ���� "PARENT_OBJ", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _PARENT_OBJ = "PARENT_OBJ";
        /// <summary>
        ///   ���� "CRDATE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CRDATE = "CRDATE";
        /// <summary>
        ///   ���� "FTCATID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _FTCATID = "FTCATID";
        /// <summary>
        ///   ���� "SCHEMA_VER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _SCHEMA_VER = "SCHEMA_VER";
        /// <summary>
        ///   ���� "STATS_SCHEMA_VER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATS_SCHEMA_VER = "STATS_SCHEMA_VER";
        /// <summary>
        ///   ���� "TYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   ���� "USERSTAT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _USERSTAT = "USERSTAT";
        /// <summary>
        ///   ���� "SYSSTAT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _SYSSTAT = "SYSSTAT";
        /// <summary>
        ///   ���� "INDEXDEL", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _INDEXDEL = "INDEXDEL";
        /// <summary>
        ///   ���� "REFDATE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _REFDATE = "REFDATE";
        /// <summary>
        ///   ���� "VERSION", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _VERSION = "VERSION";
        /// <summary>
        ///   ���� "DELTRIG", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DELTRIG = "DELTRIG";
        /// <summary>
        ///   ���� "INSTRIG", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _INSTRIG = "INSTRIG";
        /// <summary>
        ///   ���� "UPDTRIG", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _UPDTRIG = "UPDTRIG";
        /// <summary>
        ///   ���� "SELTRIG", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _SELTRIG = "SELTRIG";
        /// <summary>
        ///   ���� "CATEGORY", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CATEGORY = "CATEGORY";
        /// <summary>
        ///  ���� "CACHE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CACHE = "CACHE";

        #endregion
        #region ����        
        /// <summary>
        /// SYSOBJECTS�Ĺ��캯��
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
        /// ��ʼ����SYSOBJECTS�ĸ������ֵ
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
        #region ʵ�ֹ���Join����������

        #endregion
        #endregion ϵͳ���룬�벻Ҫ��

        #region �ڴ˴�����û��Լ���ҵ���߼�����
        //�ڴ˴�����û��Լ���ҵ���߼�����
        #endregion
    }
}