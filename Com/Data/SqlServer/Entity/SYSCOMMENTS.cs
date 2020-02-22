using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSCOMMENTS"
    /// Columns="ID,NUMBER,COLID,STATUS,CTEXT,TEXTTYPE,LANGUAGE,ENCRYPTED,COMPRESSED,TEXT"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSCOMMENTS : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:10:07
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
        ///    SMALLINT(2)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� NUMBER_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� NUMBER
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COLID_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COLID
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� STATUS_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� STATUS
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TEXTTYPE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TEXTTYPE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� LANGUAGE_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� LANGUAGE
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� ENCRYPTED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� ENCRYPTED
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� COMPRESSED_ToString ����׼ȷ
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
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� COMPRESSED
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
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "ID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   ���� "NUMBER", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NUMBER = "NUMBER";
        /// <summary>
        ///   ���� "COLID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLID = "COLID";
        /// <summary>
        ///   ���� "STATUS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        ///   ���� "CTEXT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CTEXT = "CTEXT";
        /// <summary>
        ///   ���� "TEXTTYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TEXTTYPE = "TEXTTYPE";
        /// <summary>
        ///   ���� "LANGUAGE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _LANGUAGE = "LANGUAGE";
        /// <summary>
        ///   ���� "ENCRYPTED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ENCRYPTED = "ENCRYPTED";
        /// <summary>
        ///   ���� "COMPRESSED", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COMPRESSED = "COMPRESSED";
        /// <summary>
        ///  ���� "TEXT", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TEXT = "TEXT";

        #endregion
        #region ����

        /// <summary>
        /// SYSCOMMENTS�Ĺ��캯��
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
        /// ��ʼ����SYSCOMMENTS�ĸ������ֵ
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
        #region ʵ�ֹ���Join����������

        #endregion
        #endregion ϵͳ���룬�벻Ҫ��

        #region �ڴ˴�����û��Լ���ҵ���߼�����
        //�ڴ˴�����û��Լ���ҵ���߼�����
        #endregion
    }
}