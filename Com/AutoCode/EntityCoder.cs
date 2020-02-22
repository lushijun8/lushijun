using System;
using System.Data;
namespace Com.AutoCode
{
    /// <summary>
    /// Coder 的摘要说明。
    /// </summary>
    public class EntityCoder
    {
        #region 私有变量
        private string namespaces = "";
        private string database = "";
        private string tablename = "";
        private string tablecomment = "";
        private string columns = "";
        private string primarykeys = "";
        private string datatypes = "";
        private string lengths = "";
        private string isnullables = "";
        private string defaults = "";
        private string descriptions = "";
        private string identity = "";

        #endregion
        #region 属性
        /// <summary>
        /// NAMESPACE  NAMESPACE(NAMESPACE)  NOT NULL
        ///默认值:NAMESPACE
        /// </summary>
        public string NAMESPACE
        {
            get
            {
                return this.namespaces;
            }
            set
            {
                this.namespaces = value;
            }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DATABASE
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }
        public string TABLENAME
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
        public string TABLECOMMENT
        {
            get
            {
                return this.tablecomment;
            }
            set
            {
                this.tablecomment = value;
            }
        }
        public string COLUMNS
        {
            get
            {
                return this.columns;
            }
            set
            {
                this.columns = value;
            }
        }
        public string PRIMARYKEYS
        {
            get
            {
                return this.primarykeys;
            }
            set
            {
                this.primarykeys = value;
            }
        }
        public string DATATYPES
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
        public string LENGTHS
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
        public string ISNULLABLES
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
        public string DEFAULTS
        {
            get
            {
                return this.defaults;
            }
            set
            {
                this.defaults = value;
            }
        }
        public string DESCRIPTIONS
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
        public string IDENTITY
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }
        }

        #endregion
        public EntityCoder()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region AutoCode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        private string GetPropertys(int Type)
        {
            #region  arrPRIMARYKEYS arrCOLUMNS arrDATATYPES...
            string Value = "";
            string[] arrPRIMARYKEYS = PRIMARYKEYS.Trim().Split(',');
            string[] arrCOLUMNS = COLUMNS.Trim().Split(',');
            string[] arrDATATYPES = DATATYPES.Trim().Split(',');
            string[] arrLENGTHS = LENGTHS.Trim().Split(',');
            string[] arrISNULLABLES = ISNULLABLES.Trim().Split(',');
            string[] arrDEFAULTS = DEFAULTS.Trim().Split(',');
            string[] arrDESCRIPTIONS = DESCRIPTIONS.Trim().Split(',');
            #endregion

            for (int i = 0; i < arrCOLUMNS.Length; i++)
            {
                #region 	主健之一，其他主健还有：
                string Keys = "";
                for (int k = 0; k < arrPRIMARYKEYS.Length; k++)
                {
                    if (arrCOLUMNS[i] == arrPRIMARYKEYS[k])
                    {
                        if (arrPRIMARYKEYS.Length == 1)
                            Keys = "\r\n///	唯一主键";
                        else
                            Keys = "\r\n///	主健之一，其他主健还有：" + PRIMARYKEYS;
                        break;
                    }
                }
                #endregion
                switch (Type)
                {
                    #region case 0:....
                    case 1:
                        Value += "_" + arrCOLUMNS[i].ToUpper() + ",";
                        break;
                    case 6://属性
                        string DataType = Com.Data.SqlServer.SqlCore.TypeOf(arrDATATYPES[i]);
                        string Default = "throw new Exception(\"将空值转换成" + DataType + "类型时出错\");";
                        switch (DataType)
                        {

                            case "int": Default = "return -999999999;"; break;
                            //case "bool":Default="return false;";break;
                            case "DateTime": Default = "return new DateTime(1900,1,1,0,0,0,0);"; break;
                            case "decimal": Default = "return 9999999999999999999;"; break;
                            case "float": Default = "return 9999999999999999999;"; break;
                            case "double": Default = "return 999999999999999999.999999999999999999;"; break;
                            case "byte": Default = "return 99;"; break;
                            default: break;
                        }
                        Value += "/// <summary>\r\n/// ";
                        Value += arrDESCRIPTIONS[i].Replace("\r\n", "\r\n///") + "  " + arrDATATYPES[i] + "(" + arrLENGTHS[i] + ") ";
                        Value += (IDENTITY.ToUpper() == arrCOLUMNS[i].ToUpper() ? "自增列" : "") + " ";
                        Value += (arrISNULLABLES[i] == "1" ? "NULL" : "NOT NULL") +
                            (DataType == "string" ? "" : ("\r\n///	只写属性，如果非要读取该字段的字符串,建议使用 " + arrCOLUMNS[i].ToUpper() + "_ToString 更加准确"));
                        Value += (arrDEFAULTS[i].Trim() == "" ? "" : ("\r\n///	默认值:" + arrDEFAULTS[i].Trim()));
                        Value += Keys + "\r\n/// </summary>\r\n";
                        if (DataType == "string")
                        {
                            Value += "public " + DataType + " " + arrCOLUMNS[i].ToUpper() + "\r\n{\r\nget\r\n{\r\n return ColumnValues[" + i.ToString() + "];\r\n}\r\n";
                        }
                        else
                        {
                            Value += "public " + DataType + " " + arrCOLUMNS[i].ToUpper() + "\r\n{\r\n";
                        }

                        if (DataType == "bool")
                        {
                            Value += "set\r\n{\r\n ColumnValues[" + i.ToString() + "]=(value==true?\"1\":\"0\");\r\nUpdateStatus[" + i.ToString() + "]=1;\r\n}\r\n}\r\n";
                        }
                        else if (DataType == "DateTime")
                        {
                            Value += "set\r\n{\r\n  ColumnValues[" + i.ToString() + "]=value" + (DataType == "string" ? "" : ".ToString(\"yyyy-MM-dd HH:mm:ss.fff\")") + ";UpdateStatus[" + i.ToString() + "]=1;\r\n}\r\n}\r\n";
                        }
                        else
                        {
                            Value += "set\r\n{\r\n  ColumnValues[" + i.ToString() + "]=value" + (DataType == "string" ? "" : ".ToString()") + ";UpdateStatus[" + i.ToString() + "]=1;\r\n}\r\n}\r\n";
                        }

                        if (DataType != "string")
                        {
                            Value += "/// <summary>\r\n/// ";
                            Value += arrDESCRIPTIONS[i].Replace("\r\n", "\r\n///") + "  " + arrDATATYPES[i] + "(" + arrLENGTHS[i] + ") ";
                            Value += (IDENTITY.ToUpper() == arrCOLUMNS[i].ToUpper() ? "自增列" : "") + " ";
                            Value += (arrISNULLABLES[i] == "1" ? "NULL" : "NOT NULL") +
                                (DataType == "string" ? "" : ("\r\n///	只读属性，如果非要写入该字段，请使用 " + arrCOLUMNS[i].ToUpper() + ""));
                            Value += (arrDEFAULTS[i].Trim() == "" ? "" : ("\r\n///	默认值:" + arrDEFAULTS[i].Trim()));
                            Value += Keys + "\r\n/// </summary>\r\n";
                            Value += "public string " + arrCOLUMNS[i].ToUpper() + "_ToString\r\n{\r\nget\r\n{\r\n return ColumnValues[" + i.ToString() + "];\r\n}\r\n}\r\n";

                        }
                        break;
                    case 8:
                        Value += "/// <summary>" + "\r\n" + "/// " + arrDESCRIPTIONS[i].Replace("\r\n", "\r\n///") + " 返回 \"" + arrCOLUMNS[i].ToUpper() + "\"" + "," + " 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量" + "\r\n" + "/// </summary>" + "\r\n" + "public readonly string _" + arrCOLUMNS[i].ToUpper() + "= \"" + arrCOLUMNS[i].ToUpper() + "\";" + " \r\n";
                        break;
                    #endregion
                }
            }
            return Value.TrimEnd(',').Replace("\r\n\r\n", "\r\n");
        }

        private string GetPrimaryKeys(int Type)
        {
            #region GetPrimaryKeys
            string Value = "";
            string[] arrPRIMARYKEYS = PRIMARYKEYS.Trim().Split(',');
            string[] arrCOLUMNS = COLUMNS.Trim().Split(',');
            string[] arrDATATYPES = DATATYPES.Trim().Split(',');
            string[] arrDESCRIPTIONS = DESCRIPTIONS.Trim().Split(',');
            for (int i = 0; i < arrPRIMARYKEYS.Length; i++)
            {
                int k = 0;
                for (k = 0; k < arrCOLUMNS.Length; k++)
                {
                    if (arrCOLUMNS[k].ToUpper() == arrPRIMARYKEYS[i].ToUpper())
                    {
                        break;
                    }
                }
                string DataType = Com.Data.SqlServer.SqlCore.TypeOf(arrDATATYPES[i]);
                switch (Type)
                {
                    case 0:
                        Value += "_" + arrPRIMARYKEYS[i].ToUpper() + ",";
                        break;
                    case 1:

                        Value += DataType + " P_" + arrPRIMARYKEYS[i].ToUpper() + ",";
                        break;
                    case 2:
                        Value += "this.ColumnValues[" + k.ToString() + "]=P_" + arrPRIMARYKEYS[i].ToUpper() + (DataType == "string" ? "" : ".ToString()") + ";";
                        if (i != arrPRIMARYKEYS.Length - 1)
                            Value += "\r\n";
                        break;
                    case 3:
                        Value += "/// <param name=" + "\"" + arrPRIMARYKEYS[i].ToUpper() + "\"" + ">" + arrDESCRIPTIONS[i].Replace("\r\n", "\r\n///") + "</param>";
                        if (i != arrPRIMARYKEYS.Length - 1)
                            Value += "\r\n";
                        break;
                }
            }
            return Value.TrimEnd(',');
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="JoinTable">包含列：JoinDataBase,JoinTableName,JoinColumnName,ColumnName</param>
        /// <param name="Type"></param>
        /// <returns></returns>
        private string GetJoinPropertys(string TABLENAME, DataTable JOINTABLE, int Type)
        {
            #region GetJoinPropertys
            string Value = "";
            if (JOINTABLE == null)
                return "";
            foreach (DataRow oDr in JOINTABLE.Rows)
            {
                string JoinTableAsLower = "", JoinTableAsUpper = "", JoinTableAs = oDr["JoinTableName"].ToString().ToUpper();

                if (oDr["JoinTableAs"].ToString() != "" && oDr["JoinTableAs"].ToString() != oDr["JoinTableName"].ToString())
                {
                    JoinTableAs = oDr["JoinTableAs"].ToString().ToUpper();
                    JoinTableAsLower = "_" + oDr["JoinTableAs"].ToString().ToLower();
                    JoinTableAsUpper = "_" + oDr["JoinTableAs"].ToString().ToUpper();
                }
                if (JoinTableAs.ToUpper() == TABLENAME.ToUpper())
                {
                    JoinTableAs = JoinTableAs + "1";
                }
                string JoinCode = "";
                string JoinCode1 = "";
                switch (Type)
                {
                    case 0:
                        Value += "private bool inner_join_" + oDr["JoinTableName"].ToString().ToLower() + JoinTableAsLower + "=false;\r\n" +
                            "private bool left_join_" + oDr["JoinTableName"].ToString().ToLower() + JoinTableAsLower + "=false;\r\n"+
                            "private bool right_join_" + oDr["JoinTableName"].ToString().ToLower() + JoinTableAsLower + "=false;\r\n";
                        break;
                    case 1:
                        JoinCode1 = "";
                        if (oDr["JoinColumnName1"].ToString().Trim() != "" && oDr["ColumnName1"].ToString().Trim() != "")//多键关联的情况
                        {
                            JoinCode1 = " AND " + JoinTableAs + "." + oDr["ColumnName1"].ToString().ToUpper() +
                            "=" + TABLENAME + "." + oDr["JoinColumnName1"].ToString().ToUpper();
                        }

                        JoinCode = "/// <summary>" + "\r\n" + "/// {0} " + oDr["JoinTableName"].ToString().ToUpper() + " " + JoinTableAs + " " +
                            " ON " + JoinTableAs + "." + oDr["ColumnName"].ToString().ToUpper() +
                            "=" + TABLENAME + "." + oDr["JoinColumnName"].ToString().ToUpper() + JoinCode1 + "\r\n" +
                            "/// </summary>" + "\r\n" + "public bool {1}_" + oDr["JoinTableName"].ToString().ToUpper() + JoinTableAsUpper +
                            "\r\n" + "{" + "\r\n" + "set" + "\r\n" + "{" + "\r\n" + "this.{2}_" + oDr["JoinTableName"].ToString().ToLower() + JoinTableAsLower +
                            "=value;" + "\r\n" + "}" + "\r\n" + "}" + "\r\n";
                        Value += JoinCode.Replace("{0}", "INNER JOIN").Replace("{1}", "INNER_JOIN").Replace("{2}", "inner_join");//string.Format(JoinCode, "INNER JOIN", "INNER_JOIN", "inner_join");
                        Value += JoinCode.Replace("{0}", "LEFT OUTER JOIN").Replace("{1}", "LEFT_JOIN").Replace("{2}", "left_join");
                        Value += JoinCode.Replace("{0}", "RIGHT OUTER JOIN").Replace("{1}", "RIGHT_JOIN").Replace("{2}", "right_join"); 
                        break;
                    case 2:
                        Value += "\r\n/// INNER_JOIN_" + oDr["JoinTableName"].ToString().ToUpper() + JoinTableAsUpper + "\r\n" +
                            "/// LEFT_JOIN_" + oDr["JoinTableName"].ToString().ToUpper() + JoinTableAsUpper + "\r\n" +
                            "/// RIGHT_JOIN_" + oDr["JoinTableName"].ToString().ToUpper() + JoinTableAsUpper + "";
                        break;
                    case 3:
                        JoinCode1 = "";
                        if (oDr["JoinColumnName1"].ToString().Trim() != "" && oDr["ColumnName1"].ToString().Trim() != "")//多键关联的情况
                        {
                            JoinCode1 = ",\"" + oDr["JoinColumnName1"].ToString().ToUpper() + "\",\"" + oDr["ColumnName1"].ToString().ToUpper() + "\"";
                        }
                        JoinCode = "if(this.{0}_join_" + oDr["JoinTableName"].ToString().ToLower() + JoinTableAsLower + "==true)" +
                            "\r\n" + "{" + "\r\n" + "this.NewJoin(\"" + oDr["JoinDataBase"].ToString().ToUpper() + "\",\"{1}\",\"" + oDr["JoinTableName"].ToString().ToUpper() + "\",\"" + JoinTableAs + "\",\"" + oDr["JoinColumnName"].ToString().ToUpper() + "\",\"" + oDr["ColumnName"].ToString().ToUpper() + "\"" +
                            JoinCode1 + ");" + "\r\n" + "}" + "\r\n";
                        Value += JoinCode.Replace("{0}", "inner").Replace("{1}", "INNER");//string.Format(JoinCode, "inner", "INNER");
                        Value += JoinCode.Replace("{0}", "left").Replace("{1}", "LEFT OUTER"); //string.Format(JoinCode, "left", "LEFT OUTER");
                        Value += JoinCode.Replace("{0}", "right").Replace("{1}", "RIGHT OUTER"); 
                        break;
                }
            }
            return Value.TrimEnd(',').Replace("\r\n\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n");
            #endregion
        }
        public string GetAutoCode(string NAMESPACE, string DATABASE, string TABLENAME, string TABLECOMMENT, string COLUMNS, string PRIMARYKEYS, string DATATYPES, string LENGTHS, string ISNULLABLES, string DEFAULTS, string DESCRIPTIONS, string IDENTITY, DataTable JOINTABLE)
        {
            #region this.namespaces this.database ...
            this.namespaces = NAMESPACE;
            this.database = DATABASE;
            this.tablename = TABLENAME;
            this.tablecomment = TABLECOMMENT;
            this.columns = COLUMNS;
            this.primarykeys = PRIMARYKEYS;
            this.datatypes = DATATYPES;
            this.lengths = LENGTHS;
            this.isnullables = ISNULLABLES;
            this.defaults = DEFAULTS;
            this.descriptions = DESCRIPTIONS;
            this.identity = IDENTITY;
            #endregion

            string Value;
            string Identitys = "";
            string Identitys1 = "";
            string IdentityColumn = "";
            string Finds = "";
            if (PRIMARYKEYS.Trim() != "")
            {
                Finds = @"
/*
		/// <summary>
		/// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
		/// </summary>
		" + GetPrimaryKeys(3) + @"
		/// <returns>bool</returns>
		public bool Find(" + GetPrimaryKeys(1) + @")
		{
			bool Value=false;
			" + GetPrimaryKeys(2) + @"
			if(this.SelectTop1()!=null)
				Value=true;
			return Value;
		}
*/
";
            }
            if (IDENTITY.Trim() != "")
            {
                Identitys = @"this.SetValues();
            if (!this.CheckObj())
            { return false; }
			bool bInsert=false;
			if(Com.Config.SystemConfig.DBOType==Com.Config.DboType.Sql)
			{
				string Sql=this.GetInsertSql()+" + "\"" + " " + "\"" + "+" + "\"" + "SELECT TOP 1 @@identity FROM " + "\"" + "+this.DataBase+" + "\"" + ".\"" + "+this.TableOwner+" + "\"" + "." + "\"" + @"+this.TableName;
				 DataTable oDt = this.Database_Reader.ExecuteDataSet(Sql).Tables[0];
				if(oDt.Rows.Count>0 &&oDt.Rows[0][0].ToString()!=" + "\"" + "NULL" + "\"" + @"  &&oDt.Rows[0][0].ToString().Trim()!=" + "\"\"" + @")
				{
					this." + IDENTITY.ToLower() + @"=oDt.Rows[0][0].ToString();
					bInsert=true;
				}
			}
            else if (Com.Config.SystemConfig.DBOType == Com.Config.DboType.Parameter)
            {
                if (Com.Data.SqlServer.DBParamOperator.InsertObjIdentity(this,out this." + IDENTITY.ToLower() + @"))
                {
                    bInsert = true;
                }
            }
			else if(Com.Config.SystemConfig.DBOType==Com.Config.DboType.Procedure)
			{
				if(Com.Data.SqlServer.DBProcOperator.InsertObj(this,out this." + IDENTITY.ToLower() + @"))
				{
					bInsert=true;
				}
			}
			return bInsert;";
                Identitys1 = ",并且返回自增列" + IDENTITY + "的值";
                IdentityColumn = "this.IdentityColumn=this._" + IDENTITY.ToUpper() + ";";
            }
            else
            {
                Identitys = @"this.SetValues();
			return base.Insert();";
            }
            Value = @"
using System;
namespace " + NAMESPACE + ".Business." + DATABASE + @"
{
	/// <summary>
	/// " + TABLECOMMENT + @"本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase=" + "\"" + DATABASE + "\"" + @" 
	/// Table=" + "\"" + TABLENAME + "\"" + @"
	/// Columns=" + "\"" + COLUMNS + "\"" + @"
	/// PrimaryKeys=" + "\"" + PRIMARYKEYS + "\"" + @"
	/// </summary>
	public sealed class " + TABLENAME + @" :" + NAMESPACE + ".Business." + DATABASE + @".Entity
	{
				#region 系统生成代码，请不要动 生成日期:" + System.DateTime.Now.ToString() + @"
				#region 属性
		" + GetPropertys(6) + @"
				#endregion
				#region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
		" + GetPropertys(8) + @"
				#endregion
#region 函数";
            string[] arrcolumns = this.columns.Split(',');
            string[] arrprimarykeys = this.primarykeys.Split(',');
            string[] arrdatatypes = this.datatypes.Split(',');

            string isprimarykeys = "";
            string intPrimarykeyColumn = "";
            int j = 0;
            foreach (string arrcolumn in arrcolumns)
            {
                bool bPrimary = false;
                foreach (string arrprimarykey in arrprimarykeys)
                {
                    if (arrprimarykey == arrcolumn)
                    {
                        bPrimary = true;
                        break;
                    }
                }
                if (bPrimary)
                {
                    isprimarykeys += "1,";
                    //如果是主键之一，则判断是否是int类型的,而且不能是自增字段
                    if (intPrimarykeyColumn == "" && arrdatatypes[j].ToUpper() == "INT" && this.identity.ToUpper() != arrcolumn.ToUpper())
                    {
                        intPrimarykeyColumn = arrcolumn;
                    }
                }
                else
                {
                    isprimarykeys += "0,";
                }
                j++;
            }

            Value += @"
        /// <summary>
		/// " + TABLENAME + @"的构造函数
		/// </summary>
		public " + TABLENAME + @"()
		{
			this.TableName=" + "\"" + TABLENAME + "\"" + @";
			this.PrimaryKey=new string[]{" + GetPrimaryKeys(0) + @"};
            " + IdentityColumn + @"
			this.columns=new string[]{" + GetPropertys(1) + @"};
			this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = " + "\"\"" + @"; };
		}
        /// <summary>
        /// 初始化表" + TABLENAME + @"的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { " + isprimarykeys.TrimEnd(',') + @"};
                this.DataTypes = new string[] { " + this.DATATYPES + @" };
                this.Lengths = new int[] { " + this.LENGTHS + @" };
                this.IsNullables = new int[] { " + this.ISNULLABLES + @" };
                this.DefaultValues = new string[]  { " + "\"" + this.DEFAULTS.Replace(",", "\",\"") + "\"" + @" };
                this.Descriptions = new string[] { " + "\"" + this.DESCRIPTIONS.Replace(",", "\",\"").Replace("\r\n", ",") + "\"" + @" };
            }
        }			
		" + Finds + @"
/*		
		/// <summary>
		/// 深度拷贝" + TABLENAME + @"（新开辟了内存空间）
		/// </summary>
		/// <returns></returns>
		public " + TABLENAME + @" Copy()
		{
			" + TABLENAME + @" new_obj=new " + TABLENAME + @"();
			base.CopyObj(new_obj);
            int columnindex=0;
            foreach (string column in this.Columns)
            {
                new_obj.SetColumnValue(column, this[column],columnindex);
                columnindex++;
            }
			return new_obj;
		}
*/
                #endregion
				#region 实现关联Join方法和属性
";
            if (JOINTABLE != null && JOINTABLE.Rows.Count > 0)//添加关联属性
            {
                Value += @"
				" + GetJoinPropertys(TABLENAME, JOINTABLE, 0) + @"
				" + GetJoinPropertys(TABLENAME, JOINTABLE, 1) + @"
				/// <summary>
				/// 根据关联设置" + GetJoinPropertys(TABLENAME, JOINTABLE, 2) + @"
				/// 为基类查询语句设置关联表JoinTableList
				/// </summary>
				protected override void SetJoinValues()
				{
                    this.JoinTableListOnInit();
					this.JoinTableList.Rows.Clear();
					" + GetJoinPropertys(TABLENAME, JOINTABLE, 3) + @"
					this.JoinTableList.AcceptChanges();
				}
";
            }

            Value += @"
				#endregion
				#endregion 系统生成代码，请不要动

				#region 数据库表生成SQL
                /*
                 " + CreateTableCoder.CetSql(TABLENAME, this.columns, this.datatypes, this.lengths, this.isnullables, this.defaults, this.descriptions, this.primarykeys,this.identity) + @"
";
            Value += @"
                */
				#endregion
				
				#region 在此处添加用户自己的业务逻辑代码";

            //判断主键里有没有int的字段，如果有则根据此字段分表
            if (intPrimarykeyColumn.Trim() != "")
            {
                Value += @"
   /*
        /// <summary>
        /// 此处根据" + intPrimarykeyColumn.ToUpper() + @"每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this." + intPrimarykeyColumn.ToUpper() + @"_ToString.Trim() !=  " + "\"\"" + @")
            {
                int length = 10;
                int mod = 500000;
                int " + intPrimarykeyColumn.ToLower() + @" = int.Parse(this." + intPrimarykeyColumn.ToUpper() + @"_ToString);

                int baseId = ((" + intPrimarykeyColumn.ToLower() + @" - 1) / mod) * mod;
                int startId = baseId + 1;
                int endId = baseId + mod;  

                string[] tablenames = Com.Net.HtmlUtil.GetRegexGroupFromString(" + "\"" + "(.*)_\\\\d{" + "\"" + " + length +  " + "\"" + "}_\\\\d{" + "\"" + " + length +  " + "\"" + "}" + "\"" + @", TableName, System.Text.RegularExpressions.RegexOptions.None);
                string tablename_Suffix =  " + "\"" + "_" + "\"" + " + startId.ToString().PadLeft(length, '0') +  " + "\"" + "_" + "\"" + @" + endId.ToString().PadLeft(length, '0');
                string tablename_Prefix = this.TableName;
                if (tablenames != null && tablenames.Length > 0)
                {
                    tablename_Prefix = tablenames[0];
                }
                this.TableName = tablename_Prefix + tablename_Suffix;
            } 
        }
        */
";
            }
            else
            {
                Value += @"
//在此处添加用户自己的业务逻辑代码
";
            }

            Value += @"#endregion
	}
}";
            return Value;
        }
                #endregion
    }
}
