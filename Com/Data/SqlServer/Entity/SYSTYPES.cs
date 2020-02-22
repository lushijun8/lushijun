using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSTYPES"
    /// Columns="NAME,XTYPE,STATUS,XUSERTYPE,LENGTH,XPREC,XSCALE,TDEFAULT,DOMAIN,UID,RESERVED,COLLATIONID,USERTYPE,VARIABLE,ALLOWNULLS,TYPE,PRINTFMT,PREC,SCALE,COLLATION"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSTYPES : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:07:51 
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
        ///    TINYINT(1)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATUS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATUS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XUSERTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XUSERTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� LENGTH_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� LENGTH
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XPREC_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XPREC
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� XSCALE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� XSCALE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TDEFAULT_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TDEFAULT
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� DOMAIN_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� DOMAIN
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� UID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� UID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� RESERVED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� RESERVED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLLATIONID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLLATIONID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� USERTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� USERTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� VARIABLE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� VARIABLE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ALLOWNULLS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ALLOWNULLS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� PREC_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� PREC
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SCALE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SCALE
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
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "NAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   ���� "XTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _XTYPE = "XTYPE";
        /// <summary>
        ///   ���� "STATUS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATUS = "STATUS";
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
        ///   ���� "TDEFAULT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TDEFAULT = "TDEFAULT";
        /// <summary>
        ///   ���� "DOMAIN", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DOMAIN = "DOMAIN";
        /// <summary>
        ///   ���� "UID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _UID = "UID";
        /// <summary>
        ///   ���� "RESERVED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _RESERVED = "RESERVED";
        /// <summary>
        ///   ���� "COLLATIONID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLLATIONID = "COLLATIONID";
        /// <summary>
        ///   ���� "USERTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _USERTYPE = "USERTYPE";
        /// <summary>
        ///   ���� "VARIABLE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _VARIABLE = "VARIABLE";
        /// <summary>
        ///   ���� "ALLOWNULLS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ALLOWNULLS = "ALLOWNULLS";
        /// <summary>
        ///   ���� "TYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TYPE = "TYPE";
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
        ///  ���� "COLLATION", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLLATION = "COLLATION";

        #endregion
        #region ����
        /// <summary>
        /// SYSTYPES�Ĺ��캯��
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
        /// ��ʼ����SYSTYPES�ĸ������ֵ
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
        #region ʵ�ֹ���Join����������

        #endregion
        #endregion ϵͳ���룬�벻Ҫ��

        #region �ڴ˴�����û��Լ���ҵ���߼�����
        //�ڴ˴�����û��Լ���ҵ���߼�����
        #endregion
    }
}