using System;
namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    /// �����е�(ϵͳ����)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
    /// DataBase="" 
    /// Table="SYSMETAJOIN"
    /// Columns="TABLENAME,COLUMNNAME,JOIN_DATABASE,JOIN_TABLENAME,JOIN_COLUMNNAME"
    /// PrimaryKeys="TABLENAME,COLUMNNAME"
    /// </summary>
    public sealed class SYSMETAJOIN : Com.Common.Entity
    {
        #region ϵͳ���룬�벻Ҫ��   ��������:2011-3-1 15:56:12 
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string COLUMNNAME
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_DATABASE
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_TABLENAME
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
        ///   VARCHAR(100)  NULL
        /// </summary>
        public string JOIN_COLUMNNAME
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
        ///  ���� "TABLENAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _TABLENAME = "TABLENAME";
        /// <summary>
        ///   ���� "COLUMNNAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _COLUMNNAME = "COLUMNNAME";
        /// <summary>
        ///   ���� "JOIN_DATABASE", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _JOIN_DATABASE = "JOIN_DATABASE";
        /// <summary>
        ///   ���� "JOIN_TABLENAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _JOIN_TABLENAME = "JOIN_TABLENAME";
        /// <summary>
        ///  ���� "JOIN_COLUMNNAME", Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���
        /// </summary>
        public readonly string _JOIN_COLUMNNAME = "JOIN_COLUMNNAME";

        #endregion
        #region ���� 
        /// <summary>
        /// SYSMETAJOIN�Ĺ��캯��
        /// </summary>
        public SYSMETAJOIN()
        {
            this.TableName = "SYSMETAJOIN";
            this.PrimaryKey = new string[] { this._TABLENAME };

            this.columns = new string[] { this._TABLENAME, this._COLUMNNAME, this._JOIN_DATABASE, this._JOIN_TABLENAME, this._JOIN_COLUMNNAME };
            this.SelectColumns = this.Columns;this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// ��ʼ����SYSMETAJOIN�ĸ������ֵ
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR};
                this.Lengths = new int[] { 100, 100, 100, 100, 100 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1 };
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