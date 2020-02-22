using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    /// SYSMETADATA  �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="CZHOMEBBS" 
    /// Table="SYSMETADATA"
    /// Columns="TABLENAME,COLUMNS,PRIMARYKEYS,DATATYPES,LENGTHS,ISNULLABLE,DEFAULTS,DESCRIPTIONS,IDENTITYS"
    /// PrimaryKeys="TABLENAME"
    /// </summary>
    public sealed class SYSMETADATA : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:52:07
        #region ����
        /// <summary>
        ///   VARCHAR(100)  NOT NULL
        ///	Ψһ����
        /// </summary>
        public string TABLENAME
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string COLUMNS
        {
            get
            {
                return this.ColumnValues[1];
            }
            set
            {
                this.ColumnValues[1] = value; this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string PRIMARYKEYS
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DATATYPES
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string LENGTHS
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
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string ISNULLABLE
        {
            get
            {
                return this.ColumnValues[5];
            }
            set
            {
                this.ColumnValues[5] = value; this.UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DEFAULTS
        {
            get
            {
                return this.ColumnValues[6];
            }
            set
            {
                this.ColumnValues[6] = value; this.UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(4000)  NULL
        /// </summary>
        public string DESCRIPTIONS
        {
            get
            {
                return this.ColumnValues[7];
            }
            set
            {
                this.ColumnValues[7] = value; this.UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///   VARCHAR(100)  NULL
        /// </summary>
        public string IDENTITYS
        {
            get
            {
                return this.ColumnValues[8];
            }
            set
            {
                this.ColumnValues[8] = value; this.UpdateStatus[8] = 1;
            }
        }

        #endregion
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "TABLENAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TABLENAME = "TABLENAME";
        /// <summary>
        ///   ���� "COLUMNS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLUMNS = "COLUMNS";
        /// <summary>
        ///   ���� "PRIMARYKEYS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _PRIMARYKEYS = "PRIMARYKEYS";
        /// <summary>
        ///   ���� "DATATYPES", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DATATYPES = "DATATYPES";
        /// <summary>
        ///   ���� "LENGTHS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _LENGTHS = "LENGTHS";
        /// <summary>
        ///   ���� "ISNULLABLE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _ISNULLABLE = "ISNULLABLE";
        /// <summary>
        ///   ���� "DEFAULTS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DEFAULTS = "DEFAULTS";
        /// <summary>
        ///   ���� "DESCRIPTIONS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _DESCRIPTIONS = "DESCRIPTIONS";
        /// <summary>
        ///  ���� "IDENTITYS", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _IDENTITYS = "IDENTITYS";

        #endregion
        #region ����       
        /// <summary>
        /// SYSMETADATA�Ĺ��캯��
        /// </summary>
        public SYSMETADATA()
        {
            this.TableName = "SYSMETADATA";
            this.PrimaryKey = new string[] { this._TABLENAME };

            base.columns = new string[] { this._TABLENAME, this._COLUMNS, this._PRIMARYKEYS, this._DATATYPES, this._LENGTHS, this._ISNULLABLE, this._DEFAULTS, this._DESCRIPTIONS, this._IDENTITYS };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// ��ʼ����SYSMETADATA�ĸ������ֵ
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR};
                this.Lengths = new int[] { 100, 4000, 4000, 4000, 4000, 4000, 4000, 4000, 100 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
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