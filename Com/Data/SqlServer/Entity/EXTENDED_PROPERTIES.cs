using System;
using System.Data;
using Com.Data;

namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   �����е�(ϵͳ���벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="HOMEDEPOT" 
    /// Table="EXTENDED_PROPERTIES"
    /// Columns="MAJOR_ID,MINOR_ID,CLASS,CLASS_DESC,NAME,VALUE"
    /// PrimaryKeys="MAJOR_ID,MINOR_ID"
    /// </summary>
    public sealed class EXTENDED_PROPERTIES : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2010-8-23 11:15:12
  
        #region ����
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� MAJOR_ID_ToString ����׼ȷ
        ///	����֮һ�������������У�MAJOR_ID,MINOR_ID
        /// </summary>
        public int MAJOR_ID
        {
            set
            {
                this.ColumnValues[0] = value.ToString();
                this.UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� MAJOR_ID
        ///	����֮һ�������������У�MAJOR_ID,MINOR_ID
        /// </summary>
        public string MAJOR_ID_ToString
        {
            get
            {
                return this.ColumnValues[0];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� MINOR_ID_ToString ����׼ȷ
        ///	����֮һ�������������У�MAJOR_ID,MINOR_ID
        /// </summary>
        public int MINOR_ID
        {
            set
            {
                this.ColumnValues[1] = value.ToString();
                this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� MINOR_ID
        ///	����֮һ�������������У�MAJOR_ID,MINOR_ID
        /// </summary>
        public string MINOR_ID_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� CLASS_ToString ����׼ȷ
        /// </summary>
        public int CLASS
        {
            set
            {
                this.ColumnValues[2] = value.ToString();
                this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� CLASS
        /// </summary>
        public string CLASS_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string CLASS_DESC
        {
            get
            {
                return this.ColumnValues[3];
            }
            set
            {
                this.ColumnValues[3] = value;
                this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string NAME
        {
            get
            {
                return this.ColumnValues[4];
            }
            set
            {
                this.ColumnValues[4] = value;
                this.UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///   NVARCHAR(200)  NULL
        /// </summary>
        public string VALUE
        {
            get
            {
                return this.ColumnValues[5];
            }
            set
            {
                this.ColumnValues[5] = value;
                this.UpdateStatus[5] = 1;
            }
        }

        #endregion
        #region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
        /// <summary>
        ///  ���� "MAJOR_ID"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _MAJOR_ID = "MAJOR_ID";
        /// <summary>
        ///   ���� "MINOR_ID"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _MINOR_ID = "MINOR_ID";
        /// <summary>
        ///   ���� "CLASS"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CLASS = "CLASS";
        /// <summary>
        ///   ���� "CLASS_DESC"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _CLASS_DESC = "CLASS_DESC";
        /// <summary>
        ///   ���� "NAME"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///  ���� "VALUE"
        /// Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _VALUE = "VALUE";

        #endregion
        #region ����
        /// <summary>
        /// PAY�Ĺ��캯��
        /// </summary>
        public EXTENDED_PROPERTIES()
        {
            this.TableName = "EXTENDED_PROPERTIES";
            this.PrimaryKey = new string[] { this._MAJOR_ID, this._MINOR_ID };

            this.columns = new string[] { _MAJOR_ID, _MINOR_ID, _CLASS, _CLASS_DESC, _NAME, _VALUE };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// ��ʼ����PAY�ĸ������ֵ
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, INT, INT, VARCHAR, VARCHAR, NVARCHAR };
                this.Lengths = new int[] { 4, 4, 4, 50, 50, 200 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { "", "", "", "", "", "" };
                this.Descriptions = new string[] { "", "", "", "", "", "" };
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