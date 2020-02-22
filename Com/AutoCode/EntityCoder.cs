using System;
using System.Data;
namespace Com.AutoCode
{
    /// <summary>
    /// Coder ��ժҪ˵����
    /// </summary>
    public class EntityCoder
    {
        #region ˽�б���
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
        #region ����
        /// <summary>
        /// NAMESPACE  NAMESPACE(NAMESPACE)  NOT NULL
        ///Ĭ��ֵ:NAMESPACE
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
        /// ���ݿ�����
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
            // TODO: �ڴ˴���ӹ��캯���߼�
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
                #region 	����֮һ�������������У�
                string Keys = "";
                for (int k = 0; k < arrPRIMARYKEYS.Length; k++)
                {
                    if (arrCOLUMNS[i] == arrPRIMARYKEYS[k])
                    {
                        if (arrPRIMARYKEYS.Length == 1)
                            Keys = "\r\n///	Ψһ����";
                        else
                            Keys = "\r\n///	����֮һ�������������У�" + PRIMARYKEYS;
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
                    case 6://����
                        string DataType = Com.Data.SqlServer.SqlCore.TypeOf(arrDATATYPES[i]);
                        string Default = "throw new Exception(\"����ֵת����" + DataType + "����ʱ����\");";
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
                        Value += (IDENTITY.ToUpper() == arrCOLUMNS[i].ToUpper() ? "������" : "") + " ";
                        Value += (arrISNULLABLES[i] == "1" ? "NULL" : "NOT NULL") +
                            (DataType == "string" ? "" : ("\r\n///	ֻд���ԣ������Ҫ��ȡ���ֶε��ַ���,����ʹ�� " + arrCOLUMNS[i].ToUpper() + "_ToString ����׼ȷ"));
                        Value += (arrDEFAULTS[i].Trim() == "" ? "" : ("\r\n///	Ĭ��ֵ:" + arrDEFAULTS[i].Trim()));
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
                            Value += (IDENTITY.ToUpper() == arrCOLUMNS[i].ToUpper() ? "������" : "") + " ";
                            Value += (arrISNULLABLES[i] == "1" ? "NULL" : "NOT NULL") +
                                (DataType == "string" ? "" : ("\r\n///	ֻ�����ԣ������Ҫд����ֶΣ���ʹ�� " + arrCOLUMNS[i].ToUpper() + ""));
                            Value += (arrDEFAULTS[i].Trim() == "" ? "" : ("\r\n///	Ĭ��ֵ:" + arrDEFAULTS[i].Trim()));
                            Value += Keys + "\r\n/// </summary>\r\n";
                            Value += "public string " + arrCOLUMNS[i].ToUpper() + "_ToString\r\n{\r\nget\r\n{\r\n return ColumnValues[" + i.ToString() + "];\r\n}\r\n}\r\n";

                        }
                        break;
                    case 8:
                        Value += "/// <summary>" + "\r\n" + "/// " + arrDESCRIPTIONS[i].Replace("\r\n", "\r\n///") + " ���� \"" + arrCOLUMNS[i].ToUpper() + "\"" + "," + " Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ��ͬ���б���" + "\r\n" + "/// </summary>" + "\r\n" + "public readonly string _" + arrCOLUMNS[i].ToUpper() + "= \"" + arrCOLUMNS[i].ToUpper() + "\";" + " \r\n";
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
        /// <param name="JoinTable">�����У�JoinDataBase,JoinTableName,JoinColumnName,ColumnName</param>
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
                        if (oDr["JoinColumnName1"].ToString().Trim() != "" && oDr["ColumnName1"].ToString().Trim() != "")//������������
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
                        if (oDr["JoinColumnName1"].ToString().Trim() != "" && oDr["ColumnName1"].ToString().Trim() != "")//������������
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
		/// �������õ����������ʵ��ı����,���Ҹ��������Ը�ֵ��ע�⣺WhereSql,JoinSql�Ը÷�������
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
                Identitys1 = ",���ҷ���������" + IDENTITY + "��ֵ";
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
	/// " + TABLECOMMENT + @"�����е�(ϵͳ���ɴ��벿��)�ɴ����������Զ�����,������ݿ��ṹ�����Ķ��뼰ʱ����
	/// DataBase=" + "\"" + DATABASE + "\"" + @" 
	/// Table=" + "\"" + TABLENAME + "\"" + @"
	/// Columns=" + "\"" + COLUMNS + "\"" + @"
	/// PrimaryKeys=" + "\"" + PRIMARYKEYS + "\"" + @"
	/// </summary>
	public sealed class " + TABLENAME + @" :" + NAMESPACE + ".Business." + DATABASE + @".Entity
	{
				#region ϵͳ���ɴ��룬�벻Ҫ�� ��������:" + System.DateTime.Now.ToString() + @"
				#region ����
		" + GetPropertys(6) + @"
				#endregion
				#region  ͬ���б��� Ϊ�������ݿ�ͬ������������д������õ�����������뾡��ʹ������ͬ���б���
		" + GetPropertys(8) + @"
				#endregion
#region ����";
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
                    //���������֮һ�����ж��Ƿ���int���͵�,���Ҳ����������ֶ�
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
		/// " + TABLENAME + @"�Ĺ��캯��
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
        /// ��ʼ����" + TABLENAME + @"�ĸ������ֵ
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
		/// ��ȿ���" + TABLENAME + @"���¿������ڴ�ռ䣩
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
				#region ʵ�ֹ���Join����������
";
            if (JOINTABLE != null && JOINTABLE.Rows.Count > 0)//��ӹ�������
            {
                Value += @"
				" + GetJoinPropertys(TABLENAME, JOINTABLE, 0) + @"
				" + GetJoinPropertys(TABLENAME, JOINTABLE, 1) + @"
				/// <summary>
				/// ���ݹ�������" + GetJoinPropertys(TABLENAME, JOINTABLE, 2) + @"
				/// Ϊ�����ѯ������ù�����JoinTableList
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
				#endregion ϵͳ���ɴ��룬�벻Ҫ��

				#region ���ݿ������SQL
                /*
                 " + CreateTableCoder.CetSql(TABLENAME, this.columns, this.datatypes, this.lengths, this.isnullables, this.defaults, this.descriptions, this.primarykeys,this.identity) + @"
";
            Value += @"
                */
				#endregion
				
				#region �ڴ˴�����û��Լ���ҵ���߼�����";

            //�ж���������û��int���ֶΣ����������ݴ��ֶηֱ�
            if (intPrimarykeyColumn.Trim() != "")
            {
                Value += @"
   /*
        /// <summary>
        /// �˴�����" + intPrimarykeyColumn.ToUpper() + @"ÿ500000����һ����
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
//�ڴ˴�����û��Լ���ҵ���߼�����
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
