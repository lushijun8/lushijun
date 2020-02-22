using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSINDEXES"
    /// Columns="ID,STATUS,FIRST,INDID,ROOT,MINLEN,KEYCNT,GROUPID,DPAGES,RESERVED,USED,ROWCNT,ROWMODCTR,RESERVED3,RESERVED4,XMAXLEN,MAXIROW,ORIGFILLFACTOR,STATVERSION,RESERVED2,FIRSTIAM,IMPID,LOCKFLAGS,PGMODCTR,KEYS,NAME,STATBLOB,MAXLEN,ROWS"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSINDEXES : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:09:31        
        #region ����
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATUS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATUS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� FIRST_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� FIRST
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� INDID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� INDID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ROOT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ROOT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� MINLEN_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� MINLEN
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� KEYCNT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� KEYCNT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� GROUPID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� GROUPID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� DPAGES_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� DPAGES
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� USED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� USED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ROWCNT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ROWCNT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ROWMODCTR_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ROWMODCTR
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED3_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED3
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED4_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED4
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XMAXLEN_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XMAXLEN
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� MAXIROW_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� MAXIROW
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ORIGFILLFACTOR_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ORIGFILLFACTOR
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATVERSION_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATVERSION
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED2_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED2
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� FIRSTIAM_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� FIRSTIAM
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� IMPID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� IMPID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� LOCKFLAGS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� LOCKFLAGS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� PGMODCTR_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� PGMODCTR
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATBLOB_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATBLOB
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� MAXLEN_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� MAXLEN
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ROWS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ROWS
        /// </summary>
        public string ROWS_ToString
        {
            get
            {
                return this.ColumnValues[28];
            }
        }

        #endregion
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "ID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   ���� "STATUS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   ���� "FIRST", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _FIRST = "FIRST";
        /// <summary>
        ///   ���� "INDID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _INDID = "INDID";
        /// <summary>
        ///   ���� "ROOT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ROOT = "ROOT";
        /// <summary>
        ///   ���� "MINLEN", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _MINLEN = "MINLEN";
        /// <summary>
        ///   ���� "KEYCNT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _KEYCNT = "KEYCNT";
        /// <summary>
        ///   ���� "GROUPID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _GROUPID = "GROUPID";
        /// <summary>
        ///   ���� "DPAGES", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DPAGES = "DPAGES";
        /// <summary>
        ///   ���� "RESERVED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   ���� "USED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _USED = "USED";
        /// <summary>
        ///   ���� "ROWCNT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ROWCNT = "ROWCNT";
        /// <summary>
        ///   ���� "ROWMODCTR", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ROWMODCTR = "ROWMODCTR";
        /// <summary>
        ///   ���� "RESERVED3", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED3 = "RESERVED3";
        /// <summary>
        ///   ���� "RESERVED4", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED4 = "RESERVED4";
        /// <summary>
        ///   ���� "XMAXLEN", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XMAXLEN = "XMAXLEN";
        /// <summary>
        ///   ���� "MAXIROW", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _MAXIROW = "MAXIROW";
        /// <summary>
        ///   ���� "ORIGFILLFACTOR", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ORIGFILLFACTOR = "ORIGFILLFACTOR";
        /// <summary>
        ///   ���� "STATVERSION", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATVERSION = "STATVERSION";
        /// <summary>
        ///   ���� "RESERVED2", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED2 = "RESERVED2";
        /// <summary>
        ///   ���� "FIRSTIAM", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _FIRSTIAM = "FIRSTIAM";
        /// <summary>
        ///   ���� "IMPID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _IMPID = "IMPID";
        /// <summary>
        ///   ���� "LOCKFLAGS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _LOCKFLAGS = "LOCKFLAGS";
        /// <summary>
        ///   ���� "PGMODCTR", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _PGMODCTR = "PGMODCTR";
        /// <summary>
        ///   ���� "KEYS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _KEYS = "KEYS";
        /// <summary>
        ///   ���� "NAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   ���� "STATBLOB", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATBLOB = "STATBLOB";
        /// <summary>
        ///   ���� "MAXLEN", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _MAXLEN = "MAXLEN";
        /// <summary>
        ///  ���� "ROWS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ROWS = "ROWS";

        #endregion
        #region ����
        /// <summary>
        /// SYSINDEXES�Ĺ��캯��
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
        /// ��ʼ����SYSINDEXES�ĸ������ֵ
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
        #region ʵ�ֹ���Join����������

        #endregion
        #endregion ϵͳ���룬�벻Ҫ��

        #region �ڴ˴�����û��Լ���ҵ���߼�����
        //�ڴ˴�����û��Լ���ҵ���߼�����
        #endregion
    }
}