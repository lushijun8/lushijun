using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSCOLUMNS"
    /// Columns="NAME,ID,XTYPE,TYPESTAT,XUSERTYPE,LENGTH,XPREC,XSCALE,COLID,XOFFSET,BITPOS,RESERVED,COLSTAT,CDEFAULT,DOMAIN,NUMBER,COLORDER,AUTOVAL,OFFSET,COLLATIONID,LANGUAGE,STATUS,TYPE,USERTYPE,PRINTFMT,PREC,SCALE,ISCOMPUTED,ISOUTPARAM,ISNULLABLE,COLLATION,TDSCOLLATION"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSCOLUMNS : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:10:36
        #region ����
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
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TYPESTAT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TYPESTAT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XUSERTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XUSERTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� LENGTH_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� LENGTH
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XPREC_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XPREC
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XSCALE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XSCALE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XOFFSET_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XOFFSET
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� BITPOS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� BITPOS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLSTAT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLSTAT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� CDEFAULT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� CDEFAULT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� DOMAIN_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� DOMAIN
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� NUMBER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� NUMBER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLORDER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLORDER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� OFFSET_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� OFFSET
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLLATIONID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLLATIONID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� LANGUAGE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� LANGUAGE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATUS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATUS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� USERTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� USERTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� PREC_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� PREC
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SCALE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SCALE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ISCOMPUTED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ISCOMPUTED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ISOUTPARAM_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ISOUTPARAM
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ISNULLABLE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ISNULLABLE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TDSCOLLATION_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TDSCOLLATION
        /// </summary>
        public string TDSCOLLATION_ToString
        {
            get
            {
                return this.ColumnValues[31];
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
        ///   ���� "TYPESTAT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TYPESTAT = "TYPESTAT";
        /// <summary>
        ///   ���� "XUSERTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XUSERTYPE = "XUSERTYPE";
        /// <summary>
        ///   ���� "LENGTH", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _LENGTH = "LENGTH";
        /// <summary>
        ///   ���� "XPREC", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XPREC = "XPREC";
        /// <summary>
        ///   ���� "XSCALE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XSCALE = "XSCALE";
        /// <summary>
        ///   ���� "COLID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLID = "COLID";
        /// <summary>
        ///   ���� "XOFFSET", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XOFFSET = "XOFFSET";
        /// <summary>
        ///   ���� "BITPOS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _BITPOS = "BITPOS";
        /// <summary>
        ///   ���� "RESERVED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   ���� "COLSTAT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLSTAT = "COLSTAT";
        /// <summary>
        ///   ���� "CDEFAULT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CDEFAULT = "CDEFAULT";
        /// <summary>
        ///   ���� "DOMAIN", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DOMAIN = "DOMAIN";
        /// <summary>
        ///   ���� "NUMBER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NUMBER = "NUMBER";
        /// <summary>
        ///   ���� "COLORDER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLORDER = "COLORDER";
        /// <summary>
        ///   ���� "AUTOVAL", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _AUTOVAL = "AUTOVAL";
        /// <summary>
        ///   ���� "OFFSET", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _OFFSET = "OFFSET";
        /// <summary>
        ///   ���� "COLLATIONID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLLATIONID = "COLLATIONID";
        /// <summary>
        ///   ���� "LANGUAGE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _LANGUAGE = "LANGUAGE";
        /// <summary>
        ///   ���� "STATUS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   ���� "TYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   ���� "USERTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _USERTYPE = "USERTYPE";
        /// <summary>
        ///   ���� "PRINTFMT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _PRINTFMT = "PRINTFMT";
        /// <summary>
        ///   ���� "PREC", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _PREC = "PREC";
        /// <summary>
        ///   ���� "SCALE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _SCALE = "SCALE";
        /// <summary>
        ///   ���� "ISCOMPUTED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ISCOMPUTED = "ISCOMPUTED";
        /// <summary>
        ///   ���� "ISOUTPARAM", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ISOUTPARAM = "ISOUTPARAM";
        /// <summary>
        ///   ���� "ISNULLABLE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ISNULLABLE = "ISNULLABLE";
        /// <summary>
        ///   ���� "COLLATION", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLLATION = "COLLATION";
        /// <summary>
        ///  ���� "TDSCOLLATION", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TDSCOLLATION = "TDSCOLLATION";

        #endregion
        #region ����
        /// <summary>
        /// SYSCOLUMNS�Ĺ��캯��
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
        /// ��ʼ����SYSCOLUMNS�ĸ������ֵ
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
        #region ʵ�ֹ���Join����������

        #endregion
        #endregion ϵͳ���룬�벻Ҫ��

        #region �ڴ˴�����û��Լ���ҵ���߼�����
        //�ڴ˴�����û��Լ���ҵ���߼�����
        #endregion
    }
}