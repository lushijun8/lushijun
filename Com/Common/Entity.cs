using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using Com.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Com.Common
{

    /// <summary>
    /// Entity ��ժҪ˵����
    /// </summary>
    public class Entity
    {
        #region SQLSERVER���ݿ��ֶ�����
        protected static readonly string BIGINT = "BIGINT";
        protected static readonly string BINARY = "BINARY";
        protected static readonly string BIT = "BIT";
        protected static readonly string CHAR = "CHAR";
        protected static readonly string DATETIME = "DATETIME";
        protected static readonly string DECIMAL = "DECIMAL";
        protected static readonly string FLOAT = "FLOAT";
        protected static readonly string IMAGE = "IMAGE";
        protected static readonly string INT = "INT";
        protected static readonly string TIME = "TIME";
        protected static readonly string MONEY = "MONEY";
        protected static readonly string NCHAR = "NCHAR";
        protected static readonly string NTEXT = "NTEXT";
        protected static readonly string NUMERIC = "NUMERIC";
        protected static readonly string NVARCHAR = "NVARCHAR";
        protected static readonly string REAL = "REAL";
        protected static readonly string SMALLDATETIME = "SMALLDATETIME";
        protected static readonly string SMALLINT = "SMALLINT";
        protected static readonly string SMALLMONEY = "SMALLMONEY";
        protected static readonly string SQL_VARIANT = "SQL_VARIANT";
        protected static readonly string SYSNAME = "SYSNAME";
        protected static readonly string TEXT = "TEXT";
        protected static readonly string TIMESTAMP = "TIMESTAMP";
        protected static readonly string TINYINT = "TINYINT";
        protected static readonly string UNIQUEIDENTIFIER = "UNIQUEIDENTIFIER";
        protected static readonly string VARBINARY = "VARBINARY";
        protected static readonly string VARCHAR = "VARCHAR";
        #endregion

        #region ����
        //private string servername = "";
        private string database = "";
        private string tableowner = "";
        private string[] primarykey;
        private string tablename = "";
        private string[] selectcolumns;
        private string[] updatecolumns;
        private int[] updatestatus;
        private string[] columnvalues;
        private string identitycolumn = "";
        private string errors = "";
        private string joinsql = "";
        private string wheresql = "";
        private string updatewheresql = "";
        private string deletewheresql = "";
        private string groupby = "";
        private string orderby = "";
        private bool distinct = true;
        private string cachename = "";
        private bool forxml = true;
        private bool split_or_and = false;
        private int cachetime = 0;
        private int rowcount = -1;
        private SqlParameter[] sqlparameters = null; //wheresql����������Լ����Ӳ�����
        private DataRowCollection items;
        private int index = -1;
        private Database database_reader;
        private Database database_writer;
        private Database database_owner;
        private static object lockObject = new object();
        protected string[] columns;
        /// <summary>
        /// �ֶ��Ƿ�����
        /// </summary>
        private int[] isprimarykeys;
        /// <summary>
        /// �ֶ���������
        /// </summary>
        private string[] datatypes;
        /// <summary>
        /// �ֶ����ݳ���
        /// </summary>
        private int[] lengths;
        /// <summary>
        /// �ֶ��Ƿ������ֵ
        /// </summary>
        private int[] isnullables;
        /// <summary>
        /// �ֶ�Ĭ��ֵ
        /// </summary>
        private string[] defaultvalues;
        /// <summary>
        /// �ֶ�����
        /// </summary>
        private string[] descriptions;
        #endregion
        #region ����
        ///// <summary>
        ///// ����������
        ///// </summary>
        //protected string ServerName
        //{
        //    get
        //    {
        //        return this.servername;
        //    }
        //    set
        //    {
        //        this.servername = value;
        //    }
        //}
        /// <summary>
        /// ���ݿ�
        /// </summary>
        public string DataBase
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }/// <summary>
        /// �������,�����ݿ��������dbo��ʱ���޸Ĵ��ֶ�
        /// </summary>
        public string TableOwner
        {
            get
            {
                return this.tableowner;
            }
            set
            {
                this.tableowner = value;
            }
        }
        /// <summary>
        /// ����,�ɸ�
        /// </summary>
        public string[] PrimaryKey
        {
            get
            {
                return this.primarykey;
            }
            set
            {
                this.primarykey = value;
            }
        }
        /// <summary>
        /// ����,�ɸ�,���зֱ��߼���ʱ���޸Ĵ��ֶ�
        /// </summary>
        public string TableName
        {
            get
            {
                return this.tablename;
            }
            set
            {
                this.tablename = value;
            }
        }
        /// <summary>
        /// ֻ������,���ֶ���
        /// </summary>
        public string[] Columns
        {
            get
            {
                return this.columns;
            }
        }
        /// <summary>
        /// ��Ҫ��ѯ�ı��ֶΣ�Ĭ�ϵ���Columns
        /// </summary>
        public string[] SelectColumns
        {
            get
            {
                return this.selectcolumns;
            }
            set
            {
                this.selectcolumns = value;
            }
        }
        /// <summary>
        /// �����Ը���״̬,���UpdateColumnsΪNull�����жϴ�״̬��Ϊ1ʱ���´���
        /// </summary>
        protected int[] UpdateStatus
        {
            get
            {
                return this.updatestatus;
            }
            set
            {
                this.updatestatus = value;
            }
        }
        /// <summary>
        /// �ֶ�ֵ����
        /// </summary>
        protected string[] ColumnValues
        {
            get
            {
                return this.columnvalues;
            }
            set
            {
                this.columnvalues = value;
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string IdentityColumn
        {
            get
            {
                return this.identitycolumn;
            }
            set
            {
                this.identitycolumn = value;
            }
        }
        /// <summary>
        /// ��Ҫ���µ��ֶ�(�������,����Ϊ�յ��ֶν������и���
        /// </summary>
        internal string[] UpdateColumns
        {
            get
            {
                return this.updatecolumns;
            }
            set
            {
                this.updatecolumns = value;
            }
        }
        /// <summary>
        /// ���ݿ��������,���ص�Sql���ߴ�����Ϣ
        /// </summary>
        public string Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                this.errors = value;
            }
        }
        /// <summary>
        /// �������(��Ҫ����Ա����,��:"INNER JOIN TABLE1 TABLE1 ON TABLE1.COLUMN=YOURTABLE.COLUMN")
        /// </summary>
        public string JoinSql
        {
            get
            {
                return this.joinsql;
            }
            set
            {
                this.joinsql = value;
            }
        }
        /// <summary>
        /// ����������������,������Delete(),SelectTop1(),Select(),SelectByPaging()������,��Update()��������
        /// </summary>
        public string WhereSql
        {
            get
            {
                return this.wheresql;
            }
            set
            {
                this.wheresql = value;
            }
        }
        /// <summary>
        /// ��������ĸ����������,�벻Ҫ����ʹ��,�����ֻ��Update()������,��Delete(),SelectTop1(),Select(),SelectByPaging()��������
        /// </summary>
        public string UpdateWhereSql
        {
            get
            {
                return this.updatewheresql;
            }
            set
            {
                this.updatewheresql = value;
            }
        }
        /// <summary>
        /// ���������ɾ���������,�벻Ҫ����ʹ��,�����ֻ��Delete()������,��Update(),SelectTop1(),Select(),SelectByPaging()��������
        /// </summary>
        public string DeleteWhereSql
        {
            get
            {
                return this.deletewheresql;
            }
            set
            {
                this.deletewheresql = value;
            }
        }
        /// <summary>
        /// ����,ֻ��ʹ��SUM(),AVG()�Ⱥ�������ʱ����Ч,ʹ��SelectObjByPagingProcedure��ҳʱ��������Ч
        /// </summary>
        public string GroupBy
        {
            get
            {
                return this.groupby;
            }
            set
            {
                this.groupby = value;
            }
        }
        /// <summary>
        /// ����,��: "COLUMN DESC"
        /// </summary>
        public string OrderBy
        {
            get
            {
                string value = "";
                string[] values = this.orderby.Split(' ');
                foreach (string val in values)
                {
                    if (!string.IsNullOrEmpty(val))
                    {
                        value += val + " ";
                    }
                }
                return value.TrimEnd(' ');
            }
            set
            {
                this.orderby = value;
            }
        }
        /// <summary>
        /// �Ƿ�DISTINCT,Ĭ��ΪTrue�����SelectColumns�к���Text/nText/Image���͵��ֶΣ���ǿ�н�DISTINCT��ΪFalse
        /// </summary>
        public bool Distinct
        {
            get
            {
                return this.distinct;
            }
            set
            {
                this.distinct = value;
            }
        }
        /// <summary>
        /// ���ò�ѯ���ݿ��ʱ��ʹ�������ļ�����ʱ��(����)���뾡��������30��������
        /// </summary>
        public int CacheTime
        {
            set
            {
                this.cachetime = value;
            }
        }
        /// <summary>
        /// ִ��SelectTop1()����Select()֮ǰ���ñ��β�ѯ��CacheName,���������CacheName��ִ�к�CacheName����Ϊ���ܺ��ֵ��ֻ��CacheTime>0ʱ��Ч��
        /// </summary>
        public string CacheName
        {
            get
            {
                return this.cachename;
            }
            set
            {
                this.cachename = value;
            }
        }
        /// <summary>
        /// �Ƿ� FOR XML AUTO,ELEMENTS
        /// </summary>
        private bool ForXml
        {
            get
            {
                return this.forxml;
            }
        }

        /// <summary>
        /// �Ƿ��ѯ��ʱ��ƥ�����������
        /// ���Ϊtrue:��ѯ�ֶ�ֵ����'|'ʱ���ֳ�'OR'��������,
        /// ��ѯ�ֶ�ֵ����'&'ʱ���ֳ�'AND'��������;
        /// ����Ϊfalse���������ַ�������
        /// </summary>
        public bool Split_Or_And
        {
            get
            {
                return this.split_or_and;
            }
            set
            {
                this.split_or_and = value;
            }
        }

        /// <summary>
        /// ֻ�����ԣ���ȡ�û�ͨ��AddInParameter()�����Լ���ӵĲ�ѯ�������˷������õĲ�����SelectObjByPagingProcedure()��Ч
        /// </summary>
        public SqlParameter[] SqlParameters
        {
            get
            {
                return this.sqlparameters;
            }
        }
        /// <summary>
        /// ���ݿ����Ӱ����������
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.rowcount;
            }
            set
            {
                this.rowcount = value;
            }
        }
        /// <summary>
        /// ��ȡ�����м�¼,����Select(),����SelectTop1(),�Ż����Rows
        /// </summary>
        public DataRowCollection Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }
        /// <summary>
        /// ���������
        /// </summary>
        protected int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
        /// <summary>
        /// �ֶ��Ƿ�����
        /// </summary>
        protected int[] IsPrimaryKeys
        {
            get
            {
                return this.isprimarykeys;
            }
            set
            {
                this.isprimarykeys = value;
            }
        }
        /// <summary>
        /// �ֶ���������
        /// </summary>
        protected string[] DataTypes
        {
            get
            {
                return this.datatypes;
            }
            set
            {
                this.datatypes = value;
            }
        }
        /// <summary>
        /// �ֶ����ݳ���
        /// </summary>
        protected int[] Lengths
        {
            get
            {
                return this.lengths;
            }
            set
            {
                this.lengths = value;
            }
        }
        /// <summary>
        /// �ֶ��Ƿ������ֵ
        /// </summary>
        protected int[] IsNullables
        {
            get
            {
                return this.isnullables;
            }
            set
            {
                this.isnullables = value;
            }
        }
        /// <summary>
        /// �ֶ�Ĭ��ֵ
        /// </summary>
        protected string[] DefaultValues
        {
            get
            {
                return this.defaultvalues;
            }
            set
            {
                this.defaultvalues = value;
            }
        }
        /// <summary>
        /// �ֶ�����
        /// </summary>
        protected string[] Descriptions
        {
            get
            {
                return this.descriptions;
            }
            set
            {
                this.descriptions = value;
            }
        }

        /// <summary>
        /// ���ݴ�����ֶ����ƻ�ȡ�ֶε�ֵ
        /// </summary>
        public string this[string ColumnName]
        {
            get
            {
                string columnName = ColumnName.ToUpper();
                bool bshoot = false;
                for (int i = 0; i < this.columns.Length; i++)
                {
                    if (columnName == this.columns[i].ToUpper())
                    {
                        bshoot = true;
                        return this.columnvalues[i];
                    }
                }
                if (bshoot == false)
                {
                    if (this.Items != null && this.Items.Count > 0 && this.Items[0].Table.Columns.Contains(ColumnName))
                    { return this.Items[0][ColumnName].ToString(); }
                    else
                    { throw new Exception("��" + this.TableName + "��������:" + ColumnName); }
                }
                return null;

            }
            set
            {
                string columnName = ColumnName.ToUpper();
                bool bshoot = false;
                for (int i = 0; i < this.columns.Length; i++)
                {
                    if (columnName == this.columns[i].ToUpper())
                    {
                        this.columnvalues[i] = value;
                        this.updatestatus[i] = 1;
                        bshoot = true;
                        break;
                    }
                }
                if (bshoot == false)
                {
                    throw new Exception("��" + this.TableName + "��������:" + ColumnName);
                }

            }
        }

        /// <summary>
        /// ��������" DESC "
        /// </summary>
        public string DESC
        {
            get
            {
                return " DESC ";
            }
        }
        /// <summary>
        /// ��������" ASC "
        /// </summary>
        public string ASC
        {
            get
            {
                return " ASC ";
            }
        }
        /// <summary>
        /// " AS "
        /// </summary>
        public string AS
        {
            get
            {
                return " AS ";
            }
        }
        /// <summary>
        /// ���ݿ�ֻ���û�
        /// </summary>
        public Database Database_Reader
        {
            get
            {
                if (this.database_reader == null)
                    lock (lockObject)
                    {
                        if (this.database_reader == null)
                        {
                            this.database_reader = DatabaseFactory.CreateDatabase("DataBaseInstanceReader");
                        }
                    }
                return this.database_reader;
            }
            set
            {
                this.database_reader = value;
            }
        }
        /// <summary>
        /// ���ݿ��д�û�
        /// </summary>
        public Database Database_Writer
        {
            get
            {
                if (this.database_writer == null)
                    lock (lockObject)
                    {
                        if (this.database_writer == null)
                        {
                            this.database_writer = DatabaseFactory.CreateDatabase("DataBaseInstanceWriter");
                        }
                    }
                return this.database_writer;
            }
            set
            {
                this.database_writer = value;
            }
        }
        /// <summary>
        /// ���ݿ��д�û�
        /// </summary>
        public Database Database_Owner
        {
            get
            {
                if (this.database_owner == null)
                    lock (lockObject)
                    {
                        if (this.database_owner == null)
                        {
                            this.database_owner = DatabaseFactory.CreateDatabase("DataBaseInstanceOwner");
                        }
                    }
                return this.database_owner;
            }
            set
            {
                this.database_owner = value;
            }
        }
        #endregion

        /// <summary>
        /// ʵ���(����:����,ֵ,�Ƿ�����,��������,����,�Ƿ��ܿ�,Ĭ��ֵ,����,У����ʽ)
        /// </summary>
        protected internal DataTable ValuesList;
        /// <summary>
        /// �������б�(����:�������ݿ�,�������� INNER,LEFT,��������,��������,����) 
        /// </summary>
        protected internal DataTable JoinTableList;
        /// <summary>
        /// 
        /// </summary>
        public Entity()
        {
        }
        protected void ValuesListOnInit()
        {
            if (this.ValuesList == null || this.ValuesList.Columns.Count == 0)
            {
                this.ValuesList = new DataTable("ValuesList");
                //�ֶ�ֵ�б���ӵ���˳���ܱ�
                this.ValuesList.Columns.Add("ColumnName", typeof(string));//����
                this.ValuesList.Columns.Add("ColumnValue", typeof(string));//ֵ
                this.ValuesList.Columns.Add("IsPrimaryKey", typeof(int)); //1:����;0:������
                this.ValuesList.Columns.Add("DataType", typeof(string));//�������� 
                this.ValuesList.Columns.Add("Length", typeof(string));//����,����
                this.ValuesList.Columns.Add("IsNullable", typeof(int));//1:��Ϊ��;0:����Ϊ��
                this.ValuesList.Columns.Add("Default", typeof(string));//Ĭ��ֵ
                this.ValuesList.Columns.Add("Description", typeof(string));//����
                this.ValuesList.Columns.Add("Regular", typeof(string));//У���������ʽ(.net)
                this.ValuesList.Columns.Add("Updated", typeof(int));//�������Ƿ񸳹�ֵ��Ϊ����ʹ�ã����������Ϊ1������Ĭ��Ϊ0�����µ�ʱ�����ȿ���UpdateColumns�Ƿ�ΪNull�������ΪNull����UpdateColumns���£����򰴴˱�־����
                this.ValuesList.PrimaryKey = new DataColumn[] { this.ValuesList.Columns["ColumnName"] };
            }
        }
        protected void JoinTableListOnInit()
        {
            if (this.JoinTableList == null || this.JoinTableList.Columns.Count == 0)
            {
                this.JoinTableList = new DataTable("JoinTableList");
                //�������б���ӵ���˳���ܱ�
                this.JoinTableList.Columns.Add("JoinDataBase", typeof(string));//���ݿ�
                this.JoinTableList.Columns.Add("JoinType", typeof(string));//�������� INNER,LEFT
                this.JoinTableList.Columns.Add("JoinTableName", typeof(string));//����
                this.JoinTableList.Columns.Add("JoinTableAs", typeof(string));//�����
                this.JoinTableList.Columns.Add("JoinColumnName", typeof(string));//�ؼ�������
                this.JoinTableList.Columns.Add("ColumnName", typeof(string));//��������
                this.JoinTableList.Columns.Add("JoinColumnName1", typeof(string));//�ؼ�������1,�еı���˫������
                this.JoinTableList.Columns.Add("ColumnName1", typeof(string));//��������1,�еı���˫������
                this.JoinTableList.Columns.Add("JoinColumnName2", typeof(string));//�ؼ�������2,�еı�����������
                this.JoinTableList.Columns.Add("ColumnName2", typeof(string));//��������2,�еı�����������
            }
        }
        /// <summary>
        /// �����ֶε�ֵ,������������������дʵ��
        /// </summary>
        /// <param name="columnname">�ֶ���</param>
        /// <param name="columnvalue">�ֶ�ֵ</param>
        /// <param name="columnindex">�ֶ�����λ��</param>
        /// <returns></returns>
        protected bool SetColumnValue(string columnname, string columnvalue, int columnindex)
        {
            bool Value = true;
            int updatestatus = this.UpdateStatus[columnindex];//ԭʼ�ĸ���״̬
            this[columnname] = columnvalue;
            this.UpdateStatus[columnindex] = updatestatus;//��ԭԭʼ�ĸ���״̬,��Ϊ����this[columnname] = columnvalue;�����״̬
            return Value;
        }
        /// <summary>
        /// ��ȡ�ֶε�ֵ,������������������дʵ��
        /// </summary>
        /// <param name="columnname">�ֶ���</param>
        /// <returns></returns>
        private string GetColumnValue(string columnname)
        {
            return this[columnname];
        }
        /// <summary>
        /// ��ʼ��this.isprimarykeys;this.datatypes;this.lengths;this.isnullables;this.defaultvalues;this.descriptions;
        /// </summary>
        protected virtual void SetValuesOnInit()
        {
        }
        /// <summary>
        /// �������õ��ֶ�ֵ,����Entity��������ݱ�ValuesList��������������������дʵ��
        /// NewCell(ColumnName,ColumnValue,IsPrimaryKey,DataType,Length,IsNullable,Default,Description,Regular);
        /// </summary>
        private void SetValues()
        {
            this.ValuesListOnInit();
            this.SetValuesOnInit();
            this.ValuesList.Rows.Clear();
            int i = 0;
            foreach (string column in this.columns)
            {
                NewCell(column, GetColumnValue(column), this.isprimarykeys[i], this.datatypes[i], this.lengths[i], this.isnullables[i], this.defaultvalues[i], this.descriptions[i], "", this.updatestatus[i]);
                i++;
            }
            this.ValuesList.AcceptChanges();
        }
        /// <summary>
        /// ���ݹ������ã�����й������Ծ�����������������дʵ��
        /// Ϊ�����ѯ������ù�����JoinTableList
        /// </summary>
        protected virtual void SetJoinValues()
        {
            this.JoinTableListOnInit();
        }
        /// <summary>
        /// �ֱ��߼������������ʱ����Ҫ�ֱ����������
        /// </summary>
        protected virtual void TableNameLogic()
        {
        }
        /// <summary>
        /// ���ʵ���:ValuesList,WhereSql,JoinSql,Errors�������ֶε�ֵ
        /// </summary>
        public void Clear()
        {
            int columnindex = 0;
            foreach (string column in this.Columns)
            {
                this.SetColumnValue(column, "", columnindex);
                columnindex++;
            }
            for (int i = 0; i < this.UpdateStatus.Length; i++)
            {
                this.UpdateStatus[i] = 0;
                this.columnvalues[i] = "";
            }
            this.ValuesList.Clear();
            this.errors = "";
            this.rowcount = -1;
            this.wheresql = "";
            this.index = -1;
            this.items = null;
            this.joinsql = "";
            this.split_or_and = false;
            this.cachetime = 0;
            this.cachename = "";
            this.tableowner = "";
            this.sqlparameters = null;
            this.groupby = "";
            this.orderby = "";
        }
        /// <summary>
        /// ִ��Sql,����Ӱ������RowCount,�ʹ����Errors=Sql
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        private bool Operate(string Sql, Database p_dbo)
        {
            bool Value = false;
            if (Sql.Length <= 6)
            {
                this.errors = Sql;
                return false;
            }
            else
            {
                this.rowcount = -1;
                this.errors = "";
                this.rowcount = p_dbo.ExecuteNonQuery(CommandType.Text, Sql);
                if (this.rowcount > 0)
                {
                    Value = true;
                }
                if (Value == false)
                {
                    this.errors = Sql;
                }
            }
            return Value;
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql��ò�ѯ���
        /// </summary>
        /// <returns></returns>
        protected string GetSelectSql()
        {
            //this.SetValues();
            return this.GetSelectSql(0);
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql��ò�ѯ���
        /// </summary>
        /// <param name="Top">����ǰTop����¼</param>
        /// <returns></returns>
        public string GetSelectSql(int Top)
        {
            this.TableNameLogic();
            this.SetValues();
            this.SetJoinValues();
            return Com.Data.SqlServer.SqlCore.GetSelectObjSql(Top, this);
        }
        /// <summary>
        /// ��ò���Sql���,û����Columnsʱʹ��Ĭ��ֵ
        /// </summary>
        /// <returns></returns>
        public string GetInsertSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetInsertObjSql(this);
        }
        /// <summary>
        /// ��ø���Sql���,
        /// ���û����UpdateColumnsֻ���������ݵ���.Ϊ�յ��ֶβ�����;
        /// �������UpdateColumns,�����UpdateColumns�������ֶ�;
        /// ���û�������򲻽��и��²���,����ǰ����������ֵ,����WhereSql�Ըò�������
        /// </summary>
        /// <returns></returns>
        public string GetUpdateSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetUpdateObjSql(this);
        }
        /// <summary>
        /// ��ȡɾ�����ݵ�Sql���,����WhereSql�Ըò�������
        /// </summary>
        /// <returns></returns>
        public string GetDeleteSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetDeleteObjSql(this);
        }
        /// <summary>
        /// ������ݵ���Ч��,����InsertObj()��UpdateObj()����֮��
        /// ����ValueList��飺�����������ͣ����ȣ�Լ�����Ƿ�Ϊ�գ������Ĭ��ֵ����ͨ����
        /// </summary>
        /// <returns></returns>
        protected bool CheckObj()
        {
            bool bResult = true;
            foreach (DataRow oDr in this.ValuesList.Rows)
            {
                string DataType = oDr["DataType"].ToString();
                if (DataType == VARCHAR || DataType == NVARCHAR || DataType == NCHAR || DataType == CHAR)
                {
                    string ColumnValue = oDr["ColumnValue"].ToString();
                    if (ColumnValue != "")
                    {
                        int Length = int.Parse(oDr["Length"].ToString());
                        if (Length > 0)
                        {
                            //if (DataType == NVARCHAR || DataType == NCHAR)//NVARCHARÿ���ַ��������ֽ�
                            //{
                            //    Length = Length / 2;
                            //}
                            byte[] columnValues = System.Text.Encoding.Default.GetBytes(ColumnValue);
                            int ColumnValueLength = columnValues.Length;
                            if (ColumnValueLength > Length)
                            {
                                string ColumnName = oDr["ColumnName"].ToString();
                                this.errors += "�ֶ�" + this.tablename + "." + ColumnName + "(" + ColumnValueLength + ")�ѳ�����󳤶�" + DataType + "(" + Length + ");";
                                Com.File.FileLog.WriteLog("Com.Common.Entity.CheckObj()", this.errors);
                                bResult = false;
                                break;
                            }
                        }
                    }
                }
            }
            return bResult;
        }

        /// <summary>
        /// ��ձ���������ݣ������ʹ�ô˷������ᵼ���������ݶ�ʧ��
        /// </summary>
        /// <returns></returns>
        public bool TruncateTable()
        {
            this.Operate("TRUNCATE TABLE [" + this.DataBase + "]." + this.TableOwner + ".[" + this.TableName + "]", this.Database_Owner);
            return true;
        }
        public bool BulkCopy(DataTable dt)
        {
            return BulkCopy(dt, SqlBulkCopyOptions.UseInternalTransaction);
        }
        /// <summary>
        /// �����������ݵ����ݿ⣬�����ʹ��
        /// </summary>
        /// <param name="dt">ԭʼ���ݣ�������Ҫ�����ݿ��ֶ���һ��</param>
        /// <returns></returns>
        public bool BulkCopy(DataTable dt, SqlBulkCopyOptions bulkcopyoptions)
        {
            bool bResult = true;
            SqlBulkCopy bulkCopy = new SqlBulkCopy(this.database_writer.GetConnection().ConnectionString, bulkcopyoptions);//������������
            bulkCopy.BatchSize = 1000;
            bulkCopy.DestinationTableName = this.tablename;
            bulkCopy.BulkCopyTimeout = 60;
            foreach (DataColumn sourcecol in dt.Columns)
            {
                foreach (string descol in this.columns)
                {
                    if (descol.ToLower() == sourcecol.ColumnName.ToLower())
                    {
                        bulkCopy.ColumnMappings.Add(sourcecol.ColumnName, sourcecol.ColumnName);
                    }
                }
            }
            try
            {
                bulkCopy.WriteToServer(dt);
            }
            catch
            {
                bResult = false;
            }
            finally
            {
                bulkCopy.Close();
            }
            return bResult;
        }
        /// <summary>
        /// ����ʵ��,û�������ݵ���ʹ��Ĭ��ֵ,���ҷ��������е�ֵ,�ɹ����������������ֱ�Ӹ����ֶθ�ֵ
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            this.TableNameLogic();
            this.SetValues();
            if (!this.CheckObj())
            {
                return false;
            }
            bool Value = false;
            string newIdentity = "";
            if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Sql)
            {
                if (this.IdentityColumn.Trim() != "")
                {
                    string Sql = this.GetInsertSql() + " " + "SELECT TOP 1 @@identity FROM [" + this.DataBase + "]." + this.TableOwner + ".[" + this.TableName + "]";
                    DataTable oDt = this.Database_Reader.ExecuteDataSet(Sql).Tables[0];
                    if (oDt.Rows.Count > 0 && oDt.Rows[0][0].ToString() != "NULL" && oDt.Rows[0][0].ToString().Trim() != "")
                    {
                        newIdentity = oDt.Rows[0][0].ToString();
                        Value = true;
                    }
                }
                else
                {
                    Value = this.Operate(this.GetInsertSql(), this.Database_Writer);
                }
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
            {
                if (this.IdentityColumn.Trim() != "")
                {
                    Value = Com.Data.SqlServer.SqlParameterCore.InsertObjIdentity(this, out newIdentity);

                }
                else
                {
                    Value = Com.Data.SqlServer.SqlParameterCore.InsertObj(this);
                }
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Procedure)
            {
                if (this.IdentityColumn.Trim() != "")
                {
                    Value = Com.Data.SqlServer.SqlProcCore.InsertObj(this, out newIdentity);
                }
                else
                {
                    Value = Com.Data.SqlServer.SqlProcCore.InsertObj(this);
                }
            }
            if (this.IdentityColumn.Trim() != "")//����������
            {
                int columnindex = 0;
                bool bFind = false;
                foreach (string column in this.Columns)
                {
                    if (this.IdentityColumn.ToUpper() == column.ToUpper())
                    {
                        bFind = true;
                        break;
                    }
                    columnindex++;
                }
                if (bFind)
                {
                    this.SetColumnValue(this.IdentityColumn.Trim(), newIdentity, columnindex);
                }
            }
            return Value;
        }
        /// <summary>
        /// ����Ƿ�������������������Update();Delete();,���û����������this.PrimaryKey[]����Ϊ��
        /// </summary>
        private void CheckPrimaryKey()
        {
            #region �������û�и�ֵ����������ɾ��/����
            string[] primarykeys = new string[] { "" };
            ArrayList arrPrimaryKeys = new ArrayList();
            for (int i = 0; i < this.PrimaryKey.Length; i++)
            {
                if (this.PrimaryKey[i].Trim() != "")
                {
                    string columnValue = this.ValuesList.Select("ColumnName='" + this.PrimaryKey[i] + "'")[0]["ColumnValue"].ToString();
                    if (columnValue.Trim() != "")//����������
                    {
                        arrPrimaryKeys.Add(this.PrimaryKey[i]);
                    }
                }
            }
            if (arrPrimaryKeys.Count > 0)
            {
                primarykeys = new string[arrPrimaryKeys.Count];
                for (int i = 0; i < arrPrimaryKeys.Count; i++)
                {
                    primarykeys[i] = arrPrimaryKeys[i].ToString();
                }
            }
            this.PrimaryKey = primarykeys;
            #endregion
        }
        /// <summary>
        /// ɾ��ʵ��,����DeleteWhereSql��WhereSql�Ըò������ã��������������������Ҳ��Ч
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            this.TableNameLogic();
            this.SetValues();
            bool Value = false;
            this.CheckPrimaryKey();
            if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Sql)
            {
                Value = this.Operate(this.GetDeleteSql(), this.Database_Writer);
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
            {
                Value = Com.Data.SqlServer.SqlParameterCore.DeleteObj(this);
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Procedure)
            {
                Value = Com.Data.SqlServer.SqlProcCore.DeleteObj(this);
            }
            return Value;
        }
        /// <summary>
        /// ������������ʵ��,����UpdateWhereSql�Ըò������ã�����WhereSql���ã��������������������Ҳ��Ч
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            this.TableNameLogic();
            this.SetValues();
            if (!this.CheckObj())
            {
                return false;
            }
            bool Value = false;
            this.CheckPrimaryKey();
            if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Sql)
            {
                Value = this.Operate(this.GetUpdateSql(), this.Database_Writer);
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
            {
                Value = Com.Data.SqlServer.SqlParameterCore.UpdateObj(this);
            }
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Procedure)
            {
                Value = Com.Data.SqlServer.SqlProcCore.UpdateObj(this);
            }
            return Value;
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���һ��ʵ��,���Ҹ��������Ը�ֵ
        /// </summary>
        /// <returns>����DataRow,ͬʱ����ʵ��������ֶ�,���ú����ֱ��ʹ�ø����ֶ�ֵ</returns>
        public DataRow SelectTop1()
        {
            //this.TableNameLogic();
            //this.SetValues();
            //this.SetJoinValues();
            DataRow Value;
            DataTable oDt = this.Select(1);
            this.items = oDt.Rows;
            if (oDt.Rows.Count > 0)
            {
                Value = oDt.Rows[0];
            }
            else
            {
                Value = null;
            }
            if (Value != null)
            {
                int columnindex = 0;
                foreach (string column in this.Columns)
                {
                    if (Value.Table.Columns.Contains(column))
                    {
                        this.SetColumnValue(column, Value[column].ToString(), columnindex);
                    }
                    columnindex++;
                }
            }
            return Value;
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���ʵ��ı����
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            //this.TableNameLogic();
            return this.Select(0);
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���ָ��������ʵ���б�
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable Select(int Top)
        {
            //this.TableNameLogic();
            this.SetValues();
            this.SetJoinValues();
            DataTable Value = null;
            string sql = this.GetSelectSql(Top);
            string m_cachename = Com.Common.EncDec.PasswordEncrypto(sql);
            //��ȡ�����ļ�
            Value = this.GetCache(m_cachename);
            if (Value == null || Value.Rows.Count == 0)
            {
                if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Sql)
                {
                    Value = this.Database_Reader.ExecuteDataSet(sql).Tables[0];
                }
                else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
                {
                    Value = Com.Data.SqlServer.SqlParameterCore.SelectObj(this, Top);
                }
                //д�뻺���ļ�
                this.SetCache(Value, m_cachename);
            }
            this.rowcount = Value.Rows.Count;
            this.items = Value.Rows;
            return Value;
        }
        public DataTable SelectByPaging(int PageSize, int PageIndex)
        {
            int AllCount = 0;
            return SelectByPaging(PageSize, PageIndex, false, out AllCount);
        }
        public DataTable SelectByPaging(int PageSize, int PageIndex, out int AllCount)
        {
            return SelectByPaging(PageSize, PageIndex, true, out AllCount);
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql��÷�ҳ��ʵ���б�,��AspNetPager����ʹ��,�ﵽ��ҳ��ѯ���Ż�
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">ҳ��(��1��ʼ)</param>
        /// <param name="AllCount">�ܼ�¼��</param>
        /// <returns>���ݱ�</returns>
        public DataTable SelectByPaging(int PageSize, int PageIndex, bool bCount, out int AllCount)
        {
            this.TableNameLogic();
            this.SetValues();
            this.SetJoinValues();
            AllCount = 0;
            DataTable Value = null;
            DataTable Value_AllCount = null;
            string sql = Com.Data.SqlServer.SqlCore.GetSelectObjSqlByProcedure(PageSize, PageIndex, bCount, this);
            string m_cachename = Com.Common.EncDec.PasswordEncrypto(sql);
            //��ȡ�����ļ�
            Value = this.GetCache(m_cachename);
            if (this.cachetime > 0)
            {
                Value_AllCount = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, m_cachename + "_AllCount", this.cachetime);
            }
            Value_AllCount = this.GetCache(m_cachename + "_AllCount");
            if (Value == null || Value.Rows.Count == 0)
            {
                if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Sql)
                {
                    Value = Com.Data.SqlServer.SqlCore.SelectObjByPagingProcedure(PageSize, PageIndex, bCount, out AllCount, this);
                }
                else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
                {
                    Value = Com.Data.SqlServer.SqlParameterCore.SelectObjByPagingProcedure(PageSize, PageIndex, bCount, out AllCount, this);
                }
                Value_AllCount = new DataTable(m_cachename + "_AllCount");
                Value_AllCount.Columns.Add(new DataColumn("AllCount", typeof(string)));
                DataRow oDr_New = Value_AllCount.NewRow();
                oDr_New["AllCount"] = AllCount;
                Value_AllCount.Rows.Add(oDr_New);
                //д�뻺���ļ�
                this.SetCache(Value, m_cachename);
                if (this.cachetime > 0)
                {
                    Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, m_cachename + "_AllCount", Value_AllCount, this.cachetime);
                }
            }
            else
            {
                //��ȡ��¼��
                AllCount = int.Parse(Value_AllCount.Rows[0][0].ToString());
            }
            this.rowcount = Value.Rows.Count;
            this.items = Value.Rows;
            return Value;
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���ʵ��ı���ڵ���һ��ʵ�壬����ʹ��Select()����ʹ�ñ����������ƶ�,�˷�������Select()���ص���
        /// </summary>
        /// <returns></returns>
        public bool Next()
        {
            bool Value = false;
            this.Index++;
            if (this.Items != null && this.Items.Count > this.Index)
            {
                int columnindex = 0;
                foreach (string column in this.Columns)
                {
                    if (this.Items[this.Index].Table.Columns.Contains(column))
                    {
                        this.SetColumnValue(column, this.Items[this.Index][column].ToString(), columnindex);
                    }
                    columnindex++;
                }
                Value = true;
            }
            return Value;
        }
        private void SetCache(DataTable Value, string m_cachename)
        {
            if (this.cachetime > 0)//�����¼������100,���߳���512K,�����ļ�����ʱ�����0,���û����ļ�
            {
                string cacheName = m_cachename;
                if (this.cachename.Trim() != "")
                {
                    cacheName = this.cachename;
                }
                else
                {
                    this.cachename = m_cachename;
                }
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName, Value, this.cachetime);
            }
        }

        private DataTable GetCache(string m_cachename)
        {
            DataTable Value = null;
            if (this.cachetime > 0)
            {
                string cacheName = m_cachename;
                if (this.cachename.Trim() != "")
                {
                    cacheName = this.cachename;
                }
                Value = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName, this.cachetime);
            }
            return Value;
        }

        /// <summary>
        /// ��ȡ�����ı��б� JoinTableList
        /// </summary>
        /// <param name="JoinDataBase"></param>
        /// <param name="JoinType"></param>
        /// <param name="JoinTableName"></param>
        /// <param name="JoinColumnName"></param>
        /// <param name="ColumnName"></param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinColumnName, string ColumnName)
        {
            this.NewJoin(JoinDataBase, JoinType, JoinTableName, JoinTableName, JoinColumnName, ColumnName);
        }
        /// <summary>
        /// ��ȡ�����ı��б� JoinTableList
        /// </summary>
        /// <param name="JoinDataBase">���������ݿ�</param>
        /// <param name="JoinType">�������LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">�����ı���</param>
        /// <param name="JoinTableAs">�����ı����</param>
        /// <param name="JoinColumnName">��������</param>
        /// <param name="ColumnName">�������</param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinTableAs, string JoinColumnName, string ColumnName)
        {
            this.NewJoin(JoinDataBase, JoinType, JoinTableName, JoinTableAs, JoinColumnName, ColumnName, "", "");
        }
        /// <summary>
        /// ��ȡ�����ı��б� JoinTableListc
        /// </summary>
        /// <param name="JoinDataBase">���������ݿ�</param>
        /// <param name="JoinType">�������LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">�����ı���</param>
        /// <param name="JoinTableAs">�����ı����</param>
        /// <param name="JoinColumnName">��������</param>
        /// <param name="ColumnName">�������</param>
        /// <param name="JoinColumnName1">��������1,�еı���˫������</param>
        /// <param name="ColumnName1">�������1,�еı���˫������</param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinTableAs, string JoinColumnName, string ColumnName, string JoinColumnName1, string ColumnName1)
        {

            this.NewJoin(JoinDataBase, JoinType, JoinTableName, JoinTableAs, JoinColumnName, ColumnName, JoinColumnName1,ColumnName1,"", "");
        }
        /// <summary>
        /// ��ȡ�����ı��б� JoinTableListc
        /// </summary>
        /// <param name="JoinDataBase">���������ݿ�</param>
        /// <param name="JoinType">�������LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">�����ı���</param>
        /// <param name="JoinTableAs">�����ı����</param>
        /// <param name="JoinColumnName">��������</param>
        /// <param name="ColumnName">�������</param>
        /// <param name="JoinColumnName1">��������1,�еı���˫������</param>
        /// <param name="ColumnName1">�������1,�еı���˫������</param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinTableAs, string JoinColumnName, string ColumnName, string JoinColumnName1, string ColumnName1, string JoinColumnName2, string ColumnName2)
        {

            DataRow New = this.JoinTableList.NewRow();
            New["JoinDataBase"] = JoinDataBase;
            New["JoinType"] = JoinType;
            New["JoinTableName"] = JoinTableName;
            New["JoinTableAs"] = JoinTableAs;
            New["JoinColumnName"] = JoinColumnName;
            New["ColumnName"] = ColumnName;
            New["JoinColumnName1"] = JoinColumnName1;
            New["ColumnName1"] = ColumnName1;
            New["JoinColumnName2"] = JoinColumnName2;
            New["ColumnName2"] = ColumnName2;
            this.JoinTableList.Rows.Add(New);
        }
        /// <summary>
        /// ��ȡ�����ݱ�ֵ�� ValuesList
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="ColumnValue"></param>
        /// <param name="IsPrimaryKey"></param>
        /// <param name="DataType"></param>
        /// <param name="Length"></param>
        /// <param name="IsNullable"></param>
        /// <param name="Default"></param>
        /// <param name="Description"></param>
        /// <param name="Regular"></param>
        protected void NewCell(string ColumnName, string ColumnValue, int IsPrimaryKey, string DataType, int Length, int IsNullable, string Default, string Description, string Regular)
        {
            this.NewCell(ColumnName, ColumnValue, IsPrimaryKey, DataType, Length, IsNullable, Default, Description, Regular, 0);
        }
        /// <summary>
        /// ��ȡ�����ݱ�ֵ�� ValuesList
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="ColumnValue"></param>
        /// <param name="IsPrimaryKey"></param>
        /// <param name="DataType"></param>
        /// <param name="Length"></param>
        /// <param name="IsNullable"></param>
        /// <param name="Default"></param>
        /// <param name="Description"></param>
        /// <param name="Regular"></param>
        /// <param name="Updated"></param>
        protected void NewCell(string ColumnName, string ColumnValue, int IsPrimaryKey, string DataType, int Length, int IsNullable, string Default, string Description, string Regular, int Updated)
        {
            DataRow New = this.ValuesList.NewRow();
            New["ColumnName"] = ColumnName;
            New["ColumnValue"] = ColumnValue;
            New["IsPrimaryKey"] = IsPrimaryKey;
            New["DataType"] = DataType;
            New["Length"] = Length;
            New["IsNullable"] = IsNullable;
            New["Default"] = Default;
            New["Description"] = Description;
            New["Updated"] = Updated;
            this.ValuesList.Rows.Add(New);
        }
        /// <summary>
        /// ������ɱ��Sql���,������
        /// </summary>
        /// <returns></returns>
        protected string GetCreateObjSql()
        {
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetCreateObjSql(this);
        }
        #region XML���
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���һ��ʵ��XML FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <returns></returns>
        protected string GetOneObjForXml()
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���ʵ��ı�XML��� FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <returns></returns>
        protected string SelectObjForXml()
        {
            return this.SelectObjForXml(0);
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql���ָ��������ʵ���б� FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <param name="Top">��¼��</param>
        /// <returns></returns>
        protected string SelectObjForXml(int Top)
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        /// <summary>
        /// �������õ��ֶ�,WhereSql,JoinSql��÷�ҳ��ʵ���б�,��AspNetPager����ʹ��,�ﵽ��ҳ��ѯ���Ż� FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="PageIndex">ҳ��:��1��ʼ</param>
        /// <param name="bCount">�Ƿ񷵻��ܼ�¼��</param>
        /// <returns>����XML</returns>
        protected string SelectObjByPagingProcedureForXml(int PageSize, int PageIndex, bool bCount)
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        #endregion

        #region ʵ�����ݿ�Ļ����������磺COUNT(*),SUM(),GETDATE()��
        /// <summary>
        /// �����ݿ��ȡ��¼�� COUNT ( { [ ALL | DISTINCT ] expression ] | * } )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string COUNT(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.COUNT(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ�ܺ��� SUM ( [ ALL | DISTINCT ] expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string SUM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.SUM(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡĳ�ֶ����ֵ������wheresql,���ֶζԸ÷�����Ч,Ĭ�Ϸ���-1
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string MAX(string columnName, string defaultValue)
        {
            return Com.Data.SqlServer.SqlParameterCore.Eval(this, columnName, defaultValue, "MAX");
        }
        /// <summary>
        /// �����ݿ��ȡ��Сֵ
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public string MIN(string columnName, string defaultValue)
        {
            return Com.Data.SqlServer.SqlParameterCore.Eval(this, columnName, defaultValue, "MIN");
        }
        /// <summary>
        /// �����ݿ��ȡ�ֶε��Ӵ� SUBSTRING ( expression , start , length ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="Start"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        protected string SUBSTRING(string Expression, int Start, int Length)
        {
            return Com.Data.SqlServer.SqlCore.SUBSTRING(Expression, Start, Length);
        }
        /// <summary>
        /// �����ݿ��ȡ���ݿ⵱ǰ����
        /// </summary>
        /// <returns></returns>
        protected string GETDATE()
        {
            return Com.Data.SqlServer.SqlCore.GETDATE();
        }
        /// <summary>
        /// �����ݿ��ȡ���ʽ��ƽ��ֵ AVG ( [ ALL | DISTINCT ] expression )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string AVG(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.AVG(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ����ֵ����
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string SIN(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.SIN(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ����ֵ����
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string COS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.COS(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ��ֵ�ľ���ֵ ABS ( numeric_expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ABS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.ABS(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ������ɵ���NEWID
        /// </summary>
        /// <returns></returns>
        protected string NEWID()
        {
            return Com.Data.SqlServer.SqlCore.NEWID();
        }
        /// <summary>
        /// �����ݿ��ȡ�����
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string RAND(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.RAND(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ������ֵ
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ACOS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.ACOS(Expression);
        }
        /// <summary>
        /// �����ݿ��ȡ�ַ���ASCIIֵ
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ASCII(char Expression)
        {
            return Com.Data.SqlServer.SqlCore.ASCII(Expression);
        }
        /// <summary>
        /// ��ȥ��߿ظ�
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string LTRIM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.LTRIM(Expression);
        }
        /// <summary>
        /// ��ȥ�ұ߿ظ�
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string RTRIM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.RTRIM(Expression);
        }
        /// <summary>
        /// �ж� IS NULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ISNULL(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.ISNULL(Expression);

        }
        /// <summary>
        /// �ж� IS NOT NULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ISNOTNULL(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.ISNOTNULL(Expression);

        }
        #endregion

        #region �������͵���ȿ���
        /// <summary>
        /// �������͵���ȿ����Ļ��࿽���������¿�����һ���洢�ռ�
        /// </summary>
        /// <param name="Obj"></param>
        protected void CopyObj(Entity Obj)
        {
            // Obj.servername = this.servername;
            Obj.cachename = this.cachename;
            Obj.tableowner = this.tableowner;
            Obj.database = this.database;
            Obj.tablename = this.tablename;
            Obj.errors = this.errors;
            Obj.joinsql = this.joinsql;
            Obj.wheresql = this.wheresql;
            Obj.updatewheresql = this.updatewheresql;
            Obj.groupby = this.groupby;
            Obj.orderby = this.orderby;
            Obj.distinct = this.distinct;
            Obj.forxml = this.forxml;
            Obj.split_or_and = this.split_or_and;
            Obj.cachetime = this.cachetime;
            Obj.rowcount = this.rowcount;
            Obj.index = this.index;
            Obj.database_reader = this.database_reader;
            Obj.database_writer = this.database_writer;
            Obj.sqlparameters = this.sqlparameters;

            string[] new_primarykey = new string[this.primarykey.Length];
            for (int i = 0; i < this.primarykey.Length; i++)
            {
                new_primarykey[i] = this.primarykey[i];
            }
            Obj.primarykey = new_primarykey;


            if (this.selectcolumns != null)
            {
                string[] new_selectcolumns = new string[this.selectcolumns.Length];
                for (int i = 0; i < this.selectcolumns.Length; i++)
                {
                    new_selectcolumns[i] = this.selectcolumns[i];
                }
                Obj.selectcolumns = new_selectcolumns;
            }

            if (this.updatecolumns != null)
            {
                string[] new_updatecolumns = new string[this.updatecolumns.Length];
                for (int i = 0; i < this.updatecolumns.Length; i++)
                {
                    new_updatecolumns[i] = this.updatecolumns[i];
                }
                Obj.updatecolumns = new_updatecolumns;
            }
            if (this.columnvalues != null)
            {
                string[] new_columnvalues = new string[this.columnvalues.Length];
                for (int i = 0; i < this.columnvalues.Length; i++)
                {
                    new_columnvalues[i] = this.columnvalues[i];
                }
                Obj.columnvalues = new_columnvalues;
            }
            if (this.items != null)
            {
                DataRowCollection new_items = null;
                for (int i = 0; i < this.items.Count; i++)
                {
                    DataRow oDr = this.items[i].Table.NewRow();
                    oDr.ItemArray = this.items[i].ItemArray;
                    new_items.Add(oDr);
                }
                Obj.items = new_items;
            }

        }
        #endregion

        /// <summary>
        /// �û��Լ���Ӳ�ѯ�������˷������õĲ�����SelectObjByPagingProcedure()��Ч
        /// ���������벻Ҫ���ֶ�����һ������Ϊ�ᵼ�³�ͻ
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="ParamValue"></param>
        /// <returns>�����Ӳ����ĺϷ��ԣ�����ж�һ��</returns>
        public bool AddInParameter(string ParameterName, SqlDbType dbType, object ParamValue)
        {
            bool bResult = true;
            foreach (string column in this.columns)
            {
                if (column.ToLower() == ParameterName.ToLower().Replace("@", ""))
                {
                    this.errors = "�û���ӵĲ���" + ParameterName + "���Ϸ������ܺ��ֶγ�ͻ��";
                    return false;
                }
            }
            SqlParameter sqlParameter = new SqlParameter(ParameterName, ParamValue);
            sqlParameter.SqlDbType = dbType;

            if (this.sqlparameters == null)
            {
                this.sqlparameters = new SqlParameter[1];
                this.sqlparameters[0] = sqlParameter;
            }
            else
            {
                SqlParameter[] newsqlparameters = new SqlParameter[this.sqlparameters.Length + 1];
                int i = 0;
                foreach (SqlParameter newsqlparameter in this.sqlparameters)
                {
                    newsqlparameters[i] = newsqlparameter;
                    i++;
                }
                newsqlparameters[i] = sqlParameter;
                this.sqlparameters = newsqlparameters;
            }
            return bResult;
        }

        #region ��ҳ�洢����
        /*	
Create procedure [dbo].[SP_CommonPaging]
(@pagesize int,--ÿҳ�ж��ټ�¼
@pageindex int,--��ǰҪ��ҳ��,��0��ʼ
@selectColumn varchar(1000),--Ҫ��ѯ����
@JoinSql varchar(1000),--���������
@table varchar(1000),--Ҫ��ѯ�ı�
@PrimaryKey varchar(1000),--�����У��Ż��ٶȣ��������û�����������Ƕ��������ÿ�''
@condition varchar(8000),--��ѯ����
@Order varchar(1000),--���򷽷�
@docount bit,--�Ƿ�ȡ��¼����1 ��ʾ ȡ�ܼ�¼����2(����) ��ʾȡ��¼
@bDistinct bit--�Ƿ�Distinct
)
as
set nocount on
if(@docount=1)
  begin
	exec('select count(1) from '+@table+' '+@JoinSql+' where 1=1 '+@condition)
  end
if(1=1)
  begin
	 declare @pagesizes varchar(10)
	 declare @TempKEYID varchar(10)
	 declare @Top varchar(10)
	 declare @OrderByStr varchar(100)
	 declare @OrderByColumn varchar(100)
	 declare @OrderByColumns varchar(100)
	 declare @DistinctStr varchar(100)
	 declare @temp varchar(100)
	 declare @bMultiKey bit--�Ƿ����϶�����
	 declare @bIdentityKey bit--�����Ƿ�������
	 declare @OrderColumn varchar(100)--�������
	 declare @OrderType varchar(100)--����ʽ
	 declare @AddColumn varchar(100)--Ϊ������ӵ�������
	 declare @CastPrimaryKey varchar(100)--��Ҫת������������

	 set @pagesizes = Cast(@pagesize as varchar(10))
	 set @TempKEYID = Cast(@pageindex*@pagesize as varchar(10))
	 set @Top = Cast((@pageindex+1)*@pagesize as varchar(10))
	 set @OrderByStr =''
	 set @OrderByColumn=''
	 set @OrderByColumns=''
	 set @DistinctStr =''
	 set @temp=(SELECT right(cast(RAND () as varchar),2)+right(cast(RAND () as varchar),2))
	 if(@PrimaryKey like '%,%')
	   set @bMultiKey=1
	 else
	   set @bMultiKey=0
	 set @bIdentityKey=(SELECT COLUMNPROPERTY(  OBJECT_ID(@table),@PrimaryKey,'IsIdentity'))
	 set @OrderColumn=Replace(Replace(@Order,' ASC',''),' DESC','')--�������
	 set @OrderType=Replace(@Order,@OrderColumn,'')--����ʽ
         if(@selectColumn not like '%'+@OrderColumn+'%')
	   set @AddColumn=','+@OrderColumn
         else
	   set @AddColumn=''
         set  @CastPrimaryKey=@PrimaryKey
	if(@bIdentityKey=1)
	  set  @CastPrimaryKey=' CAST('+@PrimaryKey+' AS INT) AS '+@PrimaryKey+' '
	else
	  set  @CastPrimaryKey=@PrimaryKey
---------------------------------------------------------------------------
	 if(@Order<>'')
	   begin
		 set @OrderByStr=' order by '+@Order
		 set @OrderByColumn=','+@OrderColumn+' AS ORDERCOLUMN '
		 set @OrderByColumns=' ORDER BY ORDERCOLUMN '+@OrderType+' '

		 if(@bIdentityKey=1)--����������������Ұ���������������Ҫת������
                   begin
		    if(rtrim(ltrim(@Order))=rtrim(ltrim(@PrimaryKey)))
                     begin
  		      set @OrderByColumn=',CAST('+@OrderColumn+' AS INT) AS ORDERCOLUMN '
		     end
                    end
		 if(@bMultiKey=1)--��������϶�����
		   begin
  		     set @OrderByColumn=','+@OrderColumn+' '
  		     set @OrderByColumns=' ORDER BY '+@OrderColumn+' '+@OrderType+' '
		   end
		
	   end
---------------------------------------------------------------------------
	 if(@bDistinct=1)
	   set @DistinctStr=' distinct '
---------------------------------------------------------------------------
	 if(@Order='')
		begin
		  if(@PrimaryKey='')
			 exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@selectColumn+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  * from #temp'+@temp+'  where KEYID>'+@TempKEYID+' Drop Table #temp'+@temp+' '
				  )
		  else
                      begin
----------------------------------------------------
                          if(@bMultiKey=1)--��������϶�����??????
			     exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  '+@PrimaryKey+' into #temp'+@temp+'1 from #temp'+@temp+'  where KEYID>'+@TempKEYID+'
				   set rowcount 0
				   select '+@DistinctStr+' '+@selectColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'1) Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1 '
				  )
-----------------------------------------------------
                         else--������������
			      exec('set  rowcount '+@Top+' select '+@DistinctStr+@CastPrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  '+@PrimaryKey+' into #temp'+@temp+'1 from #temp'+@temp+'  where KEYID>'+@TempKEYID+'
				   set rowcount 0
				   select '+@DistinctStr+' '+@selectColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'1) Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1 '
				  )
-----------------------------------------------------
		     end
		end
---------------------------------------------------------------------------
	 else
---------------------------------------------------------------------------
		begin
		   if(@PrimaryKey='')
			  exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@selectColumn+@OrderByColumn+' into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					select *,IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					set rowcount '+@pagesizes+'
					select  * from #temp'+@temp+'1  where KEYID>'+@TempKEYID+' Drop Table #temp'+@temp+'  Drop Table #temp'+@temp+'1 '
					)
		   else
                      begin
----------------------------------------------------
                          if(@bMultiKey=1)--��������϶�����????
			      exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+@OrderByColumn+'   into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					 select '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					 set rowcount '+@pagesizes+'
					 select  '+@PrimaryKey+' into #temp'+@temp+'2 from #temp'+@temp+'1  where KEYID>'+@TempKEYID+'
					 set rowcount 0
					 select '+@DistinctStr+' '+@selectColumn+@AddColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'2) '+@OrderByStr+' Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1  Drop Table #temp'+@temp+'2 '
					 )
-----------------------------------------------------
                         else--������������
			       exec('set  rowcount '+@Top+' select '+@DistinctStr+@CastPrimaryKey+@OrderByColumn+'   into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					 select '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					 set rowcount '+@pagesizes+'
					 select  '+@PrimaryKey+' into #temp'+@temp+'2 from #temp'+@temp+'1  where KEYID>'+@TempKEYID+'
					 set rowcount 0
					 select '+@DistinctStr+' '+@selectColumn+@AddColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'2) '+@OrderByStr+' Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1  Drop Table #temp'+@temp+'2 '
					 )
-----------------------------------------------------
		      end
		end
---------------------------------------------------------------------------

  end
set nocount off
GO

*/
        #endregion
    }
}
