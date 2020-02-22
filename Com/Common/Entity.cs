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
    /// Entity 的摘要说明。
    /// </summary>
    public class Entity
    {
        #region SQLSERVER数据库字段类型
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

        #region 变量
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
        private SqlParameter[] sqlparameters = null; //wheresql参数里可以自己增加参数。
        private DataRowCollection items;
        private int index = -1;
        private Database database_reader;
        private Database database_writer;
        private Database database_owner;
        private static object lockObject = new object();
        protected string[] columns;
        /// <summary>
        /// 字段是否主键
        /// </summary>
        private int[] isprimarykeys;
        /// <summary>
        /// 字段数据类型
        /// </summary>
        private string[] datatypes;
        /// <summary>
        /// 字段数据长度
        /// </summary>
        private int[] lengths;
        /// <summary>
        /// 字段是否允许空值
        /// </summary>
        private int[] isnullables;
        /// <summary>
        /// 字段默认值
        /// </summary>
        private string[] defaultvalues;
        /// <summary>
        /// 字段描述
        /// </summary>
        private string[] descriptions;
        #endregion
        #region 属性
        ///// <summary>
        ///// 服务器名称
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
        /// 数据库
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
        /// 表归属者,当数据库操作不是dbo的时候修改此字段
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
        /// 主键,可改
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
        /// 表名,可改,当有分表逻辑的时候修改此字段
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
        /// 只读属性,表字段名
        /// </summary>
        public string[] Columns
        {
            get
            {
                return this.columns;
            }
        }
        /// <summary>
        /// 需要查询的表字段，默认等于Columns
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
        /// 表属性更新状态,如果UpdateColumns为Null，则判断此状态，为1时更新此列
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
        /// 字段值数组
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
        /// 自增列
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
        /// 需要更新的字段(最好设置,否则为空的字段将不进行更新
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
        /// 数据库操作错误,返回的Sql或者错误信息
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
        /// 关联语句(需要程序员设置,如:"INNER JOIN TABLE1 TABLE1 ON TABLE1.COLUMN=YOURTABLE.COLUMN")
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
        /// 设置特殊的条件语句,该语句对Delete(),SelectTop1(),Select(),SelectByPaging()起作用,对Update()不起作用
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
        /// 设置特殊的更新条件语句,请不要轻易使用,该语句只对Update()起作用,对Delete(),SelectTop1(),Select(),SelectByPaging()不起作用
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
        /// 设置特殊的删除条件语句,请不要轻易使用,该语句只对Delete()起作用,对Update(),SelectTop1(),Select(),SelectByPaging()不起作用
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
        /// 分组,只有使用SUM(),AVG()等函数计算时才有效,使用SelectObjByPagingProcedure分页时该属性无效
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
        /// 排序,如: "COLUMN DESC"
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
        /// 是否DISTINCT,默认为True，如果SelectColumns中含有Text/nText/Image类型的字段，则强行将DISTINCT设为False
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
        /// 设置查询数据库的时候使用数据文件缓存时间(分钟)，请尽量控制在30分钟以内
        /// </summary>
        public int CacheTime
        {
            set
            {
                this.cachetime = value;
            }
        }
        /// <summary>
        /// 执行SelectTop1()或者Select()之前设置本次查询的CacheName,如果不设置CacheName则执行后将CacheName设置为加密后的值，只有CacheTime>0时起效。
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
        /// 是否 FOR XML AUTO,ELEMENTS
        /// </summary>
        private bool ForXml
        {
            get
            {
                return this.forxml;
            }
        }

        /// <summary>
        /// 是否查询的时候匹配多条件输入
        /// 如果为true:查询字段值含有'|'时将分成'OR'条件输入,
        /// 查询字段值含有'&'时将分成'AND'条件输入;
        /// 否则为false当作完整字符串处理
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
        /// 只读属性，获取用户通过AddInParameter()方法自己添加的查询参数，此方法设置的参数对SelectObjByPagingProcedure()无效
        /// </summary>
        public SqlParameter[] SqlParameters
        {
            get
            {
                return this.sqlparameters;
            }
        }
        /// <summary>
        /// 数据库操作影响数据行数
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
        /// 获取表所有记录,调用Select(),或者SelectTop1(),才会产生Rows
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
        /// 行入口索引
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
        /// 字段是否主键
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
        /// 字段数据类型
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
        /// 字段数据长度
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
        /// 字段是否允许空值
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
        /// 字段默认值
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
        /// 字段描述
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
        /// 根据传入的字段名称获取字段的值
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
                    { throw new Exception("表" + this.TableName + "不存在列:" + ColumnName); }
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
                    throw new Exception("表" + this.TableName + "不存在列:" + ColumnName);
                }

            }
        }

        /// <summary>
        /// 降序排序" DESC "
        /// </summary>
        public string DESC
        {
            get
            {
                return " DESC ";
            }
        }
        /// <summary>
        /// 升序排序" ASC "
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
        /// 数据库只读用户
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
        /// 数据库读写用户
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
        /// 数据库读写用户
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
        /// 实体表(包含:列名,值,是否主键,数据类型,长度,是否能空,默认值,描述,校验表达式)
        /// </summary>
        protected internal DataTable ValuesList;
        /// <summary>
        /// 关联表列表(包含:关联数据库,关联类型 INNER,LEFT,关联表名,关联列名,列名) 
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
                //字段值列表，添加的列顺序不能变
                this.ValuesList.Columns.Add("ColumnName", typeof(string));//列名
                this.ValuesList.Columns.Add("ColumnValue", typeof(string));//值
                this.ValuesList.Columns.Add("IsPrimaryKey", typeof(int)); //1:主键;0:非主键
                this.ValuesList.Columns.Add("DataType", typeof(string));//数据类型 
                this.ValuesList.Columns.Add("Length", typeof(string));//长度,精度
                this.ValuesList.Columns.Add("IsNullable", typeof(int));//1:能为空;0:不能为空
                this.ValuesList.Columns.Add("Default", typeof(string));//默认值
                this.ValuesList.Columns.Add("Description", typeof(string));//描述
                this.ValuesList.Columns.Add("Regular", typeof(string));//校验的正则表达式(.net)
                this.ValuesList.Columns.Add("Updated", typeof(int));//该属性是否赋过值，为更新使用，如果赋过则为1，否则默认为0。更新的时候优先考虑UpdateColumns是否为Null，如果不为Null，则按UpdateColumns更新，否则按此标志更新
                this.ValuesList.PrimaryKey = new DataColumn[] { this.ValuesList.Columns["ColumnName"] };
            }
        }
        protected void JoinTableListOnInit()
        {
            if (this.JoinTableList == null || this.JoinTableList.Columns.Count == 0)
            {
                this.JoinTableList = new DataTable("JoinTableList");
                //关联表列表，添加的列顺序不能变
                this.JoinTableList.Columns.Add("JoinDataBase", typeof(string));//数据库
                this.JoinTableList.Columns.Add("JoinType", typeof(string));//关联类型 INNER,LEFT
                this.JoinTableList.Columns.Add("JoinTableName", typeof(string));//表名
                this.JoinTableList.Columns.Add("JoinTableAs", typeof(string));//表别名
                this.JoinTableList.Columns.Add("JoinColumnName", typeof(string));//关键的列名
                this.JoinTableList.Columns.Add("ColumnName", typeof(string));//本表列名
                this.JoinTableList.Columns.Add("JoinColumnName1", typeof(string));//关键的列名1,有的表是双键关联
                this.JoinTableList.Columns.Add("ColumnName1", typeof(string));//本表列名1,有的表是双键关联
                this.JoinTableList.Columns.Add("JoinColumnName2", typeof(string));//关键的列名2,有的表是三键关联
                this.JoinTableList.Columns.Add("ColumnName2", typeof(string));//本表列名2,有的表是三键关联
            }
        }
        /// <summary>
        /// 设置字段的值,具体是在派生类中重写实现
        /// </summary>
        /// <param name="columnname">字段名</param>
        /// <param name="columnvalue">字段值</param>
        /// <param name="columnindex">字段所在位置</param>
        /// <returns></returns>
        protected bool SetColumnValue(string columnname, string columnvalue, int columnindex)
        {
            bool Value = true;
            int updatestatus = this.UpdateStatus[columnindex];//原始的更新状态
            this[columnname] = columnvalue;
            this.UpdateStatus[columnindex] = updatestatus;//还原原始的更新状态,因为调用this[columnname] = columnvalue;会更改状态
            return Value;
        }
        /// <summary>
        /// 获取字段的值,具体是在派生类中重写实现
        /// </summary>
        /// <param name="columnname">字段名</param>
        /// <returns></returns>
        private string GetColumnValue(string columnname)
        {
            return this[columnname];
        }
        /// <summary>
        /// 初始化this.isprimarykeys;this.datatypes;this.lengths;this.isnullables;this.defaultvalues;this.descriptions;
        /// </summary>
        protected virtual void SetValuesOnInit()
        {
        }
        /// <summary>
        /// 根据设置的字段值,设置Entity基类的数据表ValuesList，具体是在派生类中重写实现
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
        /// 根据关联设置，如果有关联属性具体是在派生类中重写实现
        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected virtual void SetJoinValues()
        {
            this.JoinTableListOnInit();
        }
        /// <summary>
        /// 分表逻辑，数据量大的时候需要分表，以提高性能
        /// </summary>
        protected virtual void TableNameLogic()
        {
        }
        /// <summary>
        /// 清除实体的:ValuesList,WhereSql,JoinSql,Errors和所有字段的值
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
        /// 执行Sql,返回影响行数RowCount,和错误的Errors=Sql
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
        /// 根据设置的字段,WhereSql,JoinSql获得查询语句
        /// </summary>
        /// <returns></returns>
        protected string GetSelectSql()
        {
            //this.SetValues();
            return this.GetSelectSql(0);
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得查询语句
        /// </summary>
        /// <param name="Top">返回前Top条记录</param>
        /// <returns></returns>
        public string GetSelectSql(int Top)
        {
            this.TableNameLogic();
            this.SetValues();
            this.SetJoinValues();
            return Com.Data.SqlServer.SqlCore.GetSelectObjSql(Top, this);
        }
        /// <summary>
        /// 获得插入Sql语句,没设置Columns时使用默认值
        /// </summary>
        /// <returns></returns>
        public string GetInsertSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetInsertObjSql(this);
        }
        /// <summary>
        /// 获得更新Sql语句,
        /// 如果没设置UpdateColumns只更新有数据的列.为空的字段不更新;
        /// 如果设置UpdateColumns,则更新UpdateColumns里所有字段;
        /// 如果没有主键则不进行更新操作,更新前请设置主键值,设置WhereSql对该操作无用
        /// </summary>
        /// <returns></returns>
        public string GetUpdateSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetUpdateObjSql(this);
        }
        /// <summary>
        /// 获取删除数据的Sql语句,设置WhereSql对该操作有用
        /// </summary>
        /// <returns></returns>
        public string GetDeleteSql()
        {
            this.TableNameLogic();
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetDeleteObjSql(this);
        }
        /// <summary>
        /// 检查数据的有效性,用于InsertObj()和UpdateObj()操作之中
        /// 根据ValueList检查：包括数据类型，长度，约束，是否为空（如果有默认值可以通过）
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
                            //if (DataType == NVARCHAR || DataType == NCHAR)//NVARCHAR每个字符顶两个字节
                            //{
                            //    Length = Length / 2;
                            //}
                            byte[] columnValues = System.Text.Encoding.Default.GetBytes(ColumnValue);
                            int ColumnValueLength = columnValues.Length;
                            if (ColumnValueLength > Length)
                            {
                                string ColumnName = oDr["ColumnName"].ToString();
                                this.errors += "字段" + this.tablename + "." + ColumnName + "(" + ColumnValueLength + ")已超过最大长度" + DataType + "(" + Length + ");";
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
        /// 清空表的所有数据，请谨慎使用此方法，会导致所有数据丢失。
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
        /// 批量复制数据到数据库，请谨慎使用
        /// </summary>
        /// <param name="dt">原始数据，列名需要跟数据库字段名一致</param>
        /// <returns></returns>
        public bool BulkCopy(DataTable dt, SqlBulkCopyOptions bulkcopyoptions)
        {
            bool bResult = true;
            SqlBulkCopy bulkCopy = new SqlBulkCopy(this.database_writer.GetConnection().ConnectionString, bulkcopyoptions);//在事务中运行
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
        /// 插入实体,没设置数据的列使用默认值,并且返回自增列的值,成功后如果有自增列则直接给此字段赋值
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
            if (this.IdentityColumn.Trim() != "")//有自增主键
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
        /// 检查是否设置了主键，适用于Update();Delete();,如果没设置主键则将this.PrimaryKey[]设置为空
        /// </summary>
        private void CheckPrimaryKey()
        {
            #region 如果主键没有赋值则不设置主键删除/更新
            string[] primarykeys = new string[] { "" };
            ArrayList arrPrimaryKeys = new ArrayList();
            for (int i = 0; i < this.PrimaryKey.Length; i++)
            {
                if (this.PrimaryKey[i].Trim() != "")
                {
                    string columnValue = this.ValuesList.Select("ColumnName='" + this.PrimaryKey[i] + "'")[0]["ColumnValue"].ToString();
                    if (columnValue.Trim() != "")//有设置主键
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
        /// 删除实体,设置DeleteWhereSql和WhereSql对该操作有用，如果有主键则设置主键也有效
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
        /// 根据主键更新实体,设置UpdateWhereSql对该操作有用，设置WhereSql无用，如果有主键则设置主键也有效
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
        /// 根据设置的字段,WhereSql,JoinSql获得一个实体,并且给各个属性赋值
        /// </summary>
        /// <returns>返回DataRow,同时设置实体的所有字段,调用后可以直接使用各个字段值</returns>
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
        /// 根据设置的字段,WhereSql,JoinSql获得实体的表入口
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            //this.TableNameLogic();
            return this.Select(0);
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得指定数量的实体列表
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
            //读取缓存文件
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
                //写入缓存文件
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
        /// 根据设置的字段,WhereSql,JoinSql获得分页的实体列表,跟AspNetPager联合使用,达到分页查询的优化
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页码(从1开始)</param>
        /// <param name="AllCount">总记录数</param>
        /// <returns>数据表</returns>
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
            //读取缓存文件
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
                //写入缓存文件
                this.SetCache(Value, m_cachename);
                if (this.cachetime > 0)
                {
                    Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, m_cachename + "_AllCount", Value_AllCount, this.cachetime);
                }
            }
            else
            {
                //读取记录数
                AllCount = int.Parse(Value_AllCount.Rows[0][0].ToString());
            }
            this.rowcount = Value.Rows.Count;
            this.items = Value.Rows;
            return Value;
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得实体的表入口的下一个实体，请先使用Select()，再使用本方法进行移动,此方法遍历Select()返回的行
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
            if (this.cachetime > 0)//如果记录数超过100,或者超过512K,或者文件缓存时间等于0,则不用缓存文件
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
        /// 获取关联的表列表 JoinTableList
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
        /// 获取关联的表列表 JoinTableList
        /// </summary>
        /// <param name="JoinDataBase">关联的数据库</param>
        /// <param name="JoinType">关联类别：LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">关联的表名</param>
        /// <param name="JoinTableAs">关联的表别名</param>
        /// <param name="JoinColumnName">关联的列</param>
        /// <param name="ColumnName">本表的列</param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinTableAs, string JoinColumnName, string ColumnName)
        {
            this.NewJoin(JoinDataBase, JoinType, JoinTableName, JoinTableAs, JoinColumnName, ColumnName, "", "");
        }
        /// <summary>
        /// 获取关联的表列表 JoinTableListc
        /// </summary>
        /// <param name="JoinDataBase">关联的数据库</param>
        /// <param name="JoinType">关联类别：LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">关联的表名</param>
        /// <param name="JoinTableAs">关联的表别名</param>
        /// <param name="JoinColumnName">关联的列</param>
        /// <param name="ColumnName">本表的列</param>
        /// <param name="JoinColumnName1">关联的列1,有的表是双键关联</param>
        /// <param name="ColumnName1">本表的列1,有的表是双键关联</param>
        protected void NewJoin(string JoinDataBase, string JoinType, string JoinTableName, string JoinTableAs, string JoinColumnName, string ColumnName, string JoinColumnName1, string ColumnName1)
        {

            this.NewJoin(JoinDataBase, JoinType, JoinTableName, JoinTableAs, JoinColumnName, ColumnName, JoinColumnName1,ColumnName1,"", "");
        }
        /// <summary>
        /// 获取关联的表列表 JoinTableListc
        /// </summary>
        /// <param name="JoinDataBase">关联的数据库</param>
        /// <param name="JoinType">关联类别：LEFT JOIN ; INNER JOIN</param>
        /// <param name="JoinTableName">关联的表名</param>
        /// <param name="JoinTableAs">关联的表别名</param>
        /// <param name="JoinColumnName">关联的列</param>
        /// <param name="ColumnName">本表的列</param>
        /// <param name="JoinColumnName1">关联的列1,有的表是双键关联</param>
        /// <param name="ColumnName1">本表的列1,有的表是双键关联</param>
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
        /// 获取表数据表值表 ValuesList
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
        /// 获取表数据表值表 ValuesList
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
        /// 获得生成表的Sql语句,请慎用
        /// </summary>
        /// <returns></returns>
        protected string GetCreateObjSql()
        {
            this.SetValues();
            return Com.Data.SqlServer.SqlCore.GetCreateObjSql(this);
        }
        #region XML入口
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得一个实体XML FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <returns></returns>
        protected string GetOneObjForXml()
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得实体的表XML入口 FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <returns></returns>
        protected string SelectObjForXml()
        {
            return this.SelectObjForXml(0);
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得指定数量的实体列表 FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <param name="Top">记录数</param>
        /// <returns></returns>
        protected string SelectObjForXml(int Top)
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        /// <summary>
        /// 根据设置的字段,WhereSql,JoinSql获得分页的实体列表,跟AspNetPager联合使用,达到分页查询的优化 FOR XML AUTO,ELEMENTS
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页码:从1开始</param>
        /// <param name="bCount">是否返回总记录数</param>
        /// <returns>返回XML</returns>
        protected string SelectObjByPagingProcedureForXml(int PageSize, int PageIndex, bool bCount)
        {
            this.SetValues();
            this.SetJoinValues();
            return "";
        }
        #endregion

        #region 实现数据库的基本函数，如：COUNT(*),SUM(),GETDATE()等
        /// <summary>
        /// 从数据库获取记录数 COUNT ( { [ ALL | DISTINCT ] expression ] | * } )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string COUNT(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.COUNT(Expression);
        }
        /// <summary>
        /// 从数据库获取总和数 SUM ( [ ALL | DISTINCT ] expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string SUM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.SUM(Expression);
        }
        /// <summary>
        /// 从数据库获取某字段最大值，设置wheresql,和字段对该方法有效,默认返回-1
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string MAX(string columnName, string defaultValue)
        {
            return Com.Data.SqlServer.SqlParameterCore.Eval(this, columnName, defaultValue, "MAX");
        }
        /// <summary>
        /// 从数据库获取最小值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public string MIN(string columnName, string defaultValue)
        {
            return Com.Data.SqlServer.SqlParameterCore.Eval(this, columnName, defaultValue, "MIN");
        }
        /// <summary>
        /// 从数据库获取字段的子串 SUBSTRING ( expression , start , length ) 
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
        /// 从数据库获取数据库当前日期
        /// </summary>
        /// <returns></returns>
        protected string GETDATE()
        {
            return Com.Data.SqlServer.SqlCore.GETDATE();
        }
        /// <summary>
        /// 从数据库获取表达式的平均值 AVG ( [ ALL | DISTINCT ] expression )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string AVG(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.AVG(Expression);
        }
        /// <summary>
        /// 从数据库获取正弦值函数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string SIN(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.SIN(Expression);
        }
        /// <summary>
        /// 从数据库获取余弦值函数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string COS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.COS(Expression);
        }
        /// <summary>
        /// 从数据库获取数值的绝对值 ABS ( numeric_expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ABS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.ABS(Expression);
        }
        /// <summary>
        /// 从数据库获取随机生成的新NEWID
        /// </summary>
        /// <returns></returns>
        protected string NEWID()
        {
            return Com.Data.SqlServer.SqlCore.NEWID();
        }
        /// <summary>
        /// 从数据库获取随机数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string RAND(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.RAND(Expression);
        }
        /// <summary>
        /// 从数据库获取反余弦值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ACOS(float Expression)
        {
            return Com.Data.SqlServer.SqlCore.ACOS(Expression);
        }
        /// <summary>
        /// 从数据库获取字符的ASCII值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ASCII(char Expression)
        {
            return Com.Data.SqlServer.SqlCore.ASCII(Expression);
        }
        /// <summary>
        /// 除去左边控格
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string LTRIM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.LTRIM(Expression);
        }
        /// <summary>
        /// 除去右边控格
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string RTRIM(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.RTRIM(Expression);
        }
        /// <summary>
        /// 判断 IS NULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ISNULL(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.ISNULL(Expression);

        }
        /// <summary>
        /// 判断 IS NOT NULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        protected string ISNOTNULL(string Expression)
        {
            return Com.Data.SqlServer.SqlCore.ISNOTNULL(Expression);

        }
        #endregion

        #region 引用类型的深度拷贝
        /// <summary>
        /// 引用类型的深度拷贝的基类拷贝方法，新开辟了一个存储空间
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
        /// 用户自己添加查询参数，此方法设置的参数对SelectObjByPagingProcedure()无效
        /// 参数名称请不要和字段名称一样，因为会导致冲突
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="ParamValue"></param>
        /// <returns>检查添加参数的合法性，最好判断一下</returns>
        public bool AddInParameter(string ParameterName, SqlDbType dbType, object ParamValue)
        {
            bool bResult = true;
            foreach (string column in this.columns)
            {
                if (column.ToLower() == ParameterName.ToLower().Replace("@", ""))
                {
                    this.errors = "用户添加的参数" + ParameterName + "不合法，不能和字段冲突！";
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

        #region 分页存储过程
        /*	
Create procedure [dbo].[SP_CommonPaging]
(@pagesize int,--每页有多少记录
@pageindex int,--当前要的页数,从0开始
@selectColumn varchar(1000),--要查询的列
@JoinSql varchar(1000),--关联表语句
@table varchar(1000),--要查询的表
@PrimaryKey varchar(1000),--主键列（优化速度）：如果是没有主键或者是多主键请置空''
@condition varchar(8000),--查询条件
@Order varchar(1000),--排序方法
@docount bit,--是否取记录数：1 表示 取总记录数；2(其他) 表示取记录
@bDistinct bit--是否Distinct
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
	 declare @bMultiKey bit--是否联合多主键
	 declare @bIdentityKey bit--主键是否自增列
	 declare @OrderColumn varchar(100)--排序的列
	 declare @OrderType varchar(100)--排序方式
	 declare @AddColumn varchar(100)--为排序添加的排序列
	 declare @CastPrimaryKey varchar(100)--需要转换的自增主键

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
	 set @OrderColumn=Replace(Replace(@Order,' ASC',''),' DESC','')--排序的列
	 set @OrderType=Replace(@Order,@OrderColumn,'')--排序方式
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

		 if(@bIdentityKey=1)--如果是自增主键并且安自增列排序则需要转换类型
                   begin
		    if(rtrim(ltrim(@Order))=rtrim(ltrim(@PrimaryKey)))
                     begin
  		      set @OrderByColumn=',CAST('+@OrderColumn+' AS INT) AS ORDERCOLUMN '
		     end
                    end
		 if(@bMultiKey=1)--如果是联合多主键
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
                          if(@bMultiKey=1)--如果是联合多主键??????
			     exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  '+@PrimaryKey+' into #temp'+@temp+'1 from #temp'+@temp+'  where KEYID>'+@TempKEYID+'
				   set rowcount 0
				   select '+@DistinctStr+' '+@selectColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'1) Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1 '
				  )
-----------------------------------------------------
                         else--不是联合主键
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
                          if(@bMultiKey=1)--如果是联合多主键????
			      exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+@OrderByColumn+'   into #temp'+@temp+' from  '+@table+' '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					 select '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					 set rowcount '+@pagesizes+'
					 select  '+@PrimaryKey+' into #temp'+@temp+'2 from #temp'+@temp+'1  where KEYID>'+@TempKEYID+'
					 set rowcount 0
					 select '+@DistinctStr+' '+@selectColumn+@AddColumn+' from  '+@table+' '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'2) '+@OrderByStr+' Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1  Drop Table #temp'+@temp+'2 '
					 )
-----------------------------------------------------
                         else--不是联合主键
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
