using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="SYSPROPERTIES"
    /// Columns="ID,SMALLID,TYPE,NAME,VALUE"
    /// PrimaryKeys=""
    /// </summary>
    public class SYSPROPERTIES : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:08:58 
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
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� SMALLID_ToString ����׼ȷ
        /// </summary>
        public int SMALLID
        {
            set
            {
                this.ColumnValues[1] = value.ToString(); this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    SMALLINT(2)  NOT NULL
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� SMALLID
        /// </summary>
        public string SMALLID_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� TYPE_ToString ����׼ȷ
        /// </summary>
        public byte TYPE
        {
            set
            {
                this.ColumnValues[2] = value.ToString(); this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NOT NULL
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� TYPE
        /// </summary>
        public string TYPE_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    NVARCHAR(256)  NOT NULL
        /// </summary>
        public string NAME
        {
            get
            {
                return this.ColumnValues[3];
            }
            set
            {
                this.ColumnValues[3] = value; this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///   SQL_VARIANT(8016)  NULL
        /// </summary>
        public string VALUE
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

        #endregion
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "ID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   ���� "SMALLID", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _SMALLID = "SMALLID";
        /// <summary>
        ///   ���� "TYPE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TYPE = "TYPE";
        /// <summary>
        ///   ���� "NAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///  ���� "VALUE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _VALUE = "VALUE";

        #endregion
        #region ����
        /// <summary>
        /// SYSPROPERTIES�Ĺ��캯��
        /// </summary>
        public SYSPROPERTIES()
        {
            this.TableName = "SYSPROPERTIES";
            this.PrimaryKey = new string[] { "" };

            this.columns = new string[] { this._ID, this._SMALLID, this._TYPE, this._NAME, this._VALUE };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// ��ʼ����SYSPROPERTIES�ĸ������ֵ
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, SMALLINT, TINYINT, NVARCHAR, SQL_VARIANT};
                this.Lengths = new int[] { 4, 2, 1, 256, 8016 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " " };
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