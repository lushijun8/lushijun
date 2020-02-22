using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace Web
{
    public partial class AutoCode : Com.Web.WebUI
    {
        Microsoft.Practices.EnterpriseLibrary.Data.Database Dbo = Com.Data.DatabaseOperater.DataBaseOwner;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Page.IsPostBack)
                return;


            DataTable oDt = new DataTable("JoinTableList");
            oDt.Columns.Add("JoinDataBase", typeof(string));//数据库
            oDt.Columns.Add("JoinTableName", typeof(string));//表名
            oDt.Columns.Add("JoinTableAs", typeof(string));//表别名
            oDt.Columns.Add("JoinColumnName", typeof(string));//列名
            oDt.Columns.Add("ColumnName", typeof(string));//本表列名
            oDt.Columns.Add("JoinColumnName1", typeof(string));//列名1
            oDt.Columns.Add("ColumnName1", typeof(string));//本表列名1


            //
            //						DataRow oDr=oDt.NewRow();
            //						oDr["JoinDataBase"]="";
            //						oDr["JoinTableName"]="PRODUCT";
            //						oDr["JoinTableAs"]="PRODUCT_LINK_PD";
            //						oDr["JoinColumnName"]="PD_CODE";
            //						oDr["ColumnName"]="LINK_PD_CODE";
            //						oDt.Rows.Add(oDr);
            //			
            //			DataRow oDr1=oDt.NewRow();
            //			oDr1["JoinDataBase"]="";
            //			oDr1["JoinTableName"]="PRODUCT";
            //			oDr1["JoinTableAs"]="PRODUCT_LINK_OUT_PD";
            //			oDr1["JoinColumnName"]="PD_CODE";
            //			oDr1["ColumnName"]="LINK_OUT_PD_CODE";
            //			oDt.Rows.Add(oDr1);
            //			
            //						DataRow oDr2=oDt.NewRow();
            //						oDr2["JoinDataBase"]="Play";
            //						oDr2["JoinTableName"]="PFS";
            //						oDr2["JoinTableAs"]="BUY_PAYTYPE";
            //						oDr2["JoinColumnName"]="PFS_VALUE";
            //						oDr2["ColumnName"]="BUY_PAYTYPE AND BUY_PAYTYPE.PFS_KEY='BUY_PAYTYPE'";
            //						oDt.Rows.Add(oDr2);
            //			
            //						DataRow oDr3=oDt.NewRow();
            //						oDr3["JoinDataBase"]="Play";
            //						oDr3["JoinTableName"]="PFS";
            //						oDr3["JoinTableAs"]="AGENT_CITY";
            //						oDr3["JoinColumnName"]="PFS_VALUE";
            //						oDr3["ColumnName"]="AGENT_CITY AND AGENT_CITY.PFS_KEY='CITY'";
            //						oDt.Rows.Add(oDr3);
            //			
            //						DataRow oDr4=oDt.NewRow();
            //						oDr4["JoinDataBase"]="Play";
            //						oDr4["JoinTableName"]="PFS";
            //						oDr4["JoinTableAs"]="AGENT_PROVINCE";
            //						oDr4["JoinColumnName"]="PFS_VALUE";
            //						oDr4["ColumnName"]="AGENT_PROVINCE AND AGENT_PROVINCE.PFS_KEY='PROVINCE'";
            //						oDt.Rows.Add(oDr4);
            //			
            //
            oDt.AcceptChanges();


            this.dgJoinTable.DataSource = oDt;
            this.dgJoinTable.DataBind();
            ViewState.Add("JoinTableList", oDt);
            this.DATABASE_SelectedIndexChanged(this, null);
            //this.TABLE_SelectedIndexChanged(this, null);

        }

        protected void CREATE_Click(object sender, System.EventArgs e)
        {
            this.GetDataChanges();
            DataTable oDt = (DataTable)ViewState["JoinTableList"];
            Com.AutoCode.EntityCoder Coder = new Com.AutoCode.EntityCoder();
            Coder.TABLENAME = this.TABLE1.Text;
            this.CODES.Text = Coder.GetAutoCode(this.NAMESPACE.Text, this.DATABASE1.Text.ToUpper(), this.TABLE1.Text.ToUpper(), this.TABLECOMMENT.Text, this.COLUMNS.Text, this.PRIMARYKEYS.Text, this.XTYPE.Text, this.LENGTH.Text, this.ISNULLABLE.Text, this.DEFAULT.Text, this.DESCRIPTION.Text, this.IDENTITY.Text, oDt);
        }

        protected void DATABASE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (DATABASE.SelectedItem.Value.Trim() == "")
            {
                return;
            }
            this.DATABASE1.Text = this.DATABASE.SelectedItem.Text;
            Com.Data.SqlServer.Entity.SYSOBJECTS SYSOBJECTS = new Com.Data.SqlServer.Entity.SYSOBJECTS();
            SYSOBJECTS.Database_Reader = Dbo;
            SYSOBJECTS.DataBase = this.DATABASE.SelectedItem.Value;
            //						SYSOBJECTS.WhereSql=" (XTYPE='U' OR XTYPE='S') ";
            SYSOBJECTS.WhereSql = " (XTYPE='U') ";// " (XTYPE='U' OR XTYPE='S') ";
            SYSOBJECTS.SelectColumns = new string[] { "NAME", "ID" };
            DataTable oDt = SYSOBJECTS.Select();
            DataView oDv = oDt.DefaultView;
            oDv.Sort = "NAME";
            this.TABLE.DataSource = oDv;
            this.TABLE.DataTextField = "NAME";
            this.TABLE.DataValueField = "ID";
            this.TABLE.DataBind();
        }
        protected void GetProperty(ListItem oItem)
        {
            this.XTYPE.Text = "";
            this.LENGTH.Text = "";
            this.COLUMNS.Text = "";
            this.DESCRIPTION.Text = "";
            this.ISNULLABLE.Text = "";
            this.DEFAULT.Text = "";
            this.IDENTITY.Text = "";
            Com.Data.SqlServer.Entity.SYSCOLUMNS SYSCOLUMNS = new Com.Data.SqlServer.Entity.SYSCOLUMNS();
            SYSCOLUMNS.Database_Reader = Dbo;
            SYSCOLUMNS.DataBase = this.DATABASE.SelectedItem.Value;
            SYSCOLUMNS.ID = int.Parse(oItem.Value);
            SYSCOLUMNS.OrderBy = " COLID ";
            SYSCOLUMNS.Distinct = false;
            SYSCOLUMNS.SelectColumns = new string[] { "ID", "NAME", "XTYPE", "LENGTH", "COLID", "ISNULLABLE", "CDEFAULT" };
            DataTable oDt = SYSCOLUMNS.Select();
            string Columns = "";
            string Xtypes = "";
            string Lengths = "";
            string Descriptions = "";
            string Isnullables = "";
            string Defaults = "";
            foreach (DataRow oDr in oDt.Rows)
            {
                Columns += oDr["NAME"].ToString() + ",";
                Com.Data.SqlServer.Entity.SYSTYPES SYSTYPES = new Com.Data.SqlServer.Entity.SYSTYPES();
                SYSTYPES.Database_Reader = Dbo;
                SYSTYPES.DataBase = this.DATABASE.SelectedItem.Value;
                SYSTYPES.XTYPE = byte.Parse(oDr["XTYPE"].ToString().ToUpper());
                SYSTYPES.SelectColumns = new string[] { "NAME" };
                SYSTYPES.SelectTop1();
                Xtypes += SYSTYPES.NAME + ",";
                Lengths += oDr["LENGTH"].ToString() + ",";

                Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
                SYSPROPERTIES.Database_Reader = Dbo;
                SYSPROPERTIES.DataBase = this.DATABASE.SelectedItem.Value;
                SYSPROPERTIES.TableOwner = "sys";
                SYSPROPERTIES.MAJOR_ID = int.Parse(oDr["ID"].ToString());
                SYSPROPERTIES.MINOR_ID = int.Parse(oDr["COLID"].ToString());
                SYSPROPERTIES.SelectTop1();
                Descriptions += (SYSPROPERTIES.VALUE == "" ? " " : SYSPROPERTIES.VALUE.Replace(",", "，")) + ",";
                Isnullables += oDr["ISNULLABLE"].ToString() + ",";

                Com.Data.SqlServer.Entity.SYSCOMMENTS SYSCOMMENTS = new Com.Data.SqlServer.Entity.SYSCOMMENTS();
                SYSCOMMENTS.Database_Reader = Dbo;
                SYSCOMMENTS.DataBase = this.DATABASE.SelectedItem.Value;
                SYSCOMMENTS.ID = int.Parse(oDr["CDEFAULT"].ToString());
                SYSCOMMENTS.SelectColumns = new string[] { "TEXT" };
                SYSCOMMENTS.SelectTop1();
                string defaults = SYSCOMMENTS.TEXT;
                if (SYSCOMMENTS.TEXT.Trim() == "")
                {
                    defaults = " ";
                }
                else if (SYSCOMMENTS.TEXT.IndexOf("'") == -1)
                {
                    defaults = SYSCOMMENTS.TEXT.Replace(")", "").Replace("(", "");
                }
                else
                {
                    defaults = SYSCOMMENTS.TEXT.Substring(SYSCOMMENTS.TEXT.IndexOf("'") + 1, SYSCOMMENTS.TEXT.LastIndexOf("'") - SYSCOMMENTS.TEXT.IndexOf("'") - 1);
                }
                if (string.IsNullOrEmpty(defaults))
                {
                    defaults = " ";
                }
                Defaults += defaults + ",";
                if (this.IDENTITY.Text.Trim() == "")
                {
                    //System.Data.SqlClient.SqlConnection oCon = new System.Data.SqlClient.SqlConnection(Com.Config.SystemConfig.DefaultConnectionString.ToUpper().Replace("DATABASE=" + this.PubDB.ToUpper() + "", "DATABASE=" + this.DATABASE.SelectedItem.Text.ToUpper() + ""));
                    //System.Data.SqlClient.SqlCommand oComm = new System.Data.SqlClient.SqlCommand("SELECT COLUMNPROPERTY(  OBJECT_ID('" + oItem.Text + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')", oCon);
                    string Identity = "0";
                    //try
                    //{
                    //    oCon.Open();
                    //Identity = Convert.ToString(oComm.ExecuteScalar());
                    Identity = Convert.ToString(this.Dbo.ExecuteScalar(CommandType.Text, "SELECT COLUMNPROPERTY(  OBJECT_ID('" + oItem.Text + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')"));
                    //}
                    //catch (Exception err)
                    //{
                    //    string aa = err.ToString();
                    //}
                    //finally
                    //{
                    //    oCon.Close();
                    //}
                    if (Identity == "1")
                        this.IDENTITY.Text = oDr["NAME"].ToString().ToUpper();
                }
            }
            this.XTYPE.Text = Xtypes.ToUpper().TrimEnd(',');
            this.LENGTH.Text = Lengths.TrimEnd(',');
            this.COLUMNS.Text = Columns.ToUpper().TrimEnd(',');
            this.COLUMNS0.Text = Columns.TrimEnd(',');
            this.DESCRIPTION.Text = Descriptions.TrimEnd(',');
            this.ISNULLABLE.Text = Isnullables.TrimEnd(',');
            this.DEFAULT.Text = Defaults.TrimEnd(',');
            DataTable oDt1 = this.Dbo.ExecuteDataSet(CommandType.Text, "EXEC " + this.DATABASE.SelectedItem.Text + "..sp_pkeys @table_name='" + oItem.Text + "'").Tables[0];
            string Keys = "";
            foreach (DataRow oDr in oDt1.Rows)
            {
                Keys += oDr["COLUMN_NAME"].ToString().ToUpper() + ",";
            }
            this.PRIMARYKEYS.Text = Keys.TrimEnd(',');
            Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES1 = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
            SYSPROPERTIES1.Database_Reader = Dbo;
            SYSPROPERTIES1.DataBase = this.DATABASE.SelectedItem.Value;
            SYSPROPERTIES1.TableOwner = "sys";
            SYSPROPERTIES1.JoinSql = " INNER JOIN " + this.DATABASE.SelectedItem.Value + "..sysobjects sysobjects ON MAJOR_ID = sysobjects.id ";
            SYSPROPERTIES1.WhereSql = " (MINOR_ID = 0) and sysobjects.name='" + oItem.Text + "' ";
            SYSPROPERTIES1.SelectColumns = new string[] { SYSPROPERTIES1._VALUE };
            SYSPROPERTIES1.SelectTop1();
            this.TABLECOMMENT.Text = SYSPROPERTIES1.VALUE;
        }
        protected void TABLE_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.TABLE1.Text = this.TABLE.SelectedItem.Text;
            this.GetProperty(this.TABLE.SelectedItem);
            this.CREATE_Click(this, null);
        }

        protected void CREATES_Click(object sender, System.EventArgs e)
        {
            string FilePath = this.Path.Text;
            foreach (ListItem oItem in this.TABLE.Items)
            {
                try
                {
                    this.TABLE1.Text = oItem.Text;
                    this.GetProperty(oItem);
                    this.CREATE_Click(this, null);
                    if (Com.File.FileUtil.FileExists(FilePath.TrimEnd('\\') + "\\" + oItem.Text.ToUpper() + ".cs"))
                    {
                        string FileContent = Com.File.FileUtil.GetFileContent(FilePath.TrimEnd('\\') + "\\" + oItem.Text.ToUpper() + ".cs");
                        int StartIndex1 = this.CODES.Text.IndexOf("#region 系统代码，请不要动");
                        int EndIndex1 = this.CODES.Text.IndexOf("#endregion 系统代码，请不要动") + 20;
                        string NewCodes = this.CODES.Text.Substring(StartIndex1, EndIndex1 - StartIndex1);

                        int StartIndex = FileContent.IndexOf("#region 系统代码，请不要动");
                        int EndIndex = FileContent.IndexOf("#endregion 系统代码，请不要动") + 20;
                        string OldCodes = FileContent.Substring(StartIndex, EndIndex - StartIndex);
                        FileContent = FileContent.Replace(OldCodes, NewCodes);
                        Com.File.FileUtil.WriteFileContent(FilePath.TrimEnd('\\') + "\\" + oItem.Text.ToUpper() + ".cs", FileContent, "utf-8", false);
                    }
                    else
                    {
                        Com.File.FileUtil.FileCreate(FilePath.TrimEnd('\\') + "\\" + oItem.Text.ToUpper() + ".cs", 0);
                        Com.File.FileUtil.AppendFileContent(FilePath.TrimEnd('\\') + "\\" + oItem.Text.ToUpper() + ".cs", this.CODES.Text);
                    }
                }
                catch
                {
                }
            }
        }

        protected void CREATESP_Click(object sender, System.EventArgs e)
        {
            Com.AutoCode.SPCoder SPCoder = new Com.AutoCode.SPCoder();
            SPCoder.NAMESPACE = this.NAMESPACE.Text.ToUpper();
            SPCoder.DATABASE = this.DATABASE1.Text.ToUpper();
            SPCoder.TABLENAME = this.TABLE1.Text.ToUpper();
            SPCoder.COLUMNS = this.COLUMNS.Text;
            SPCoder.PRIMARYKEYS = this.PRIMARYKEYS.Text;
            SPCoder.DATATYPES = this.XTYPE.Text;
            SPCoder.LENGTHS = this.LENGTH.Text;
            SPCoder.ISNULLABLES = this.ISNULLABLE.Text;
            SPCoder.DEFAULTS = this.DEFAULT.Text;
            SPCoder.DESCRIPTIONS = this.DESCRIPTION.Text;
            SPCoder.IDENTITY = this.IDENTITY.Text;
            this.CODES.Text = SPCoder.GET_SP_OBJ_INSERT() + "\r\n\r\n\r\n" + SPCoder.GET_SP_OBJ_UPDATE() + "\r\n\r\n\r\n" + SPCoder.GET_SP_OBJ_SELECT() + "\r\n\r\n\r\n" + SPCoder.GET_SP_OBJ_DELETE() + "\r\n\r\n\r\n";
        }

        protected void CREATESSP_Click(object sender, System.EventArgs e)
        {
            string SP = "";
            foreach (ListItem oItem in this.TABLE.Items)
            {

                this.TABLE1.Text = oItem.Text;
                this.GetProperty(oItem);
                this.CREATESP_Click(this, null);

                SP += this.CODES.Text;
            }
            this.CODES.Text = SP;
        }
        protected void GetDataChanges()
        {
            DataTable oDt = (DataTable)ViewState["JoinTableList"];
            foreach (DataGridItem oItem in this.dgJoinTable.Items)
            {
                if (oItem.ItemIndex >= 0)
                {
                    TextBox JoinDataBase = (TextBox)oItem.FindControl("JoinDataBase");
                    TextBox JoinTableName = (TextBox)oItem.FindControl("JoinTableName");
                    TextBox JoinColumnName = (TextBox)oItem.FindControl("JoinColumnName");
                    TextBox ColumnName = (TextBox)oItem.FindControl("ColumnName");
                    TextBox JoinColumnName1 = (TextBox)oItem.FindControl("JoinColumnName1");
                    TextBox ColumnName1 = (TextBox)oItem.FindControl("ColumnName1");
                    try
                    {
                        oDt.Rows[oItem.DataSetIndex]["JoinDataBase"] = JoinDataBase.Text;
                        oDt.Rows[oItem.DataSetIndex]["JoinTableName"] = JoinTableName.Text;
                        oDt.Rows[oItem.DataSetIndex]["JoinColumnName"] = JoinColumnName.Text;
                        oDt.Rows[oItem.DataSetIndex]["ColumnName"] = ColumnName.Text;
                        oDt.Rows[oItem.DataSetIndex]["JoinColumnName1"] = JoinColumnName1.Text;
                        oDt.Rows[oItem.DataSetIndex]["ColumnName1"] = ColumnName1.Text;
                    }
                    catch
                    {
                    }
                }
            }
            oDt.AcceptChanges();
        }
        protected void dgJoinTable_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex != -1)
            {
                DataRow oDr = ((DataTable)this.dgJoinTable.DataSource).Rows[e.Item.DataSetIndex];
                TextBox JoinDataBase = (TextBox)e.Item.FindControl("JoinDataBase");
                TextBox JoinTableName = (TextBox)e.Item.FindControl("JoinTableName");
                TextBox JoinColumnName = (TextBox)e.Item.FindControl("JoinColumnName");
                TextBox ColumnName = (TextBox)e.Item.FindControl("ColumnName");
                TextBox JoinColumnName1 = (TextBox)e.Item.FindControl("JoinColumnName1");
                TextBox ColumnName1 = (TextBox)e.Item.FindControl("ColumnName1");
                try
                {
                    JoinDataBase.Text = oDr["JoinDataBase"].ToString();
                    JoinTableName.Text = oDr["JoinTableName"].ToString();
                    JoinColumnName.Text = oDr["JoinColumnName"].ToString();
                    ColumnName.Text = oDr["ColumnName"].ToString();
                    JoinColumnName1.Text = oDr["JoinColumnName1"].ToString();
                    ColumnName1.Text = oDr["ColumnName1"].ToString();
                }
                catch
                {
                }

            }
        }

        protected void AddJoinTable_Click(object sender, System.EventArgs e)
        {
            this.GetDataChanges();
            Business.Common.AddDataItem(this.dgJoinTable, (DataTable)ViewState["JoinTableList"]);

        }

        protected void DeleteJoinTable_Click(object sender, System.EventArgs e)
        {
            this.GetDataChanges();
            Business.Common.DeleteDataItem(this.dgJoinTable, (DataTable)ViewState["JoinTableList"]);
        }

        protected void UpdateMetaData_Click(object sender, System.EventArgs e)
        {

        }

        protected void btnCreateAspx_Click(object sender, EventArgs e)
        {
            Com.AutoCode.ASPXCoder Coder = new Com.AutoCode.ASPXCoder();
            this.CODES.Text = Coder.GetAutoCode(this.COLUMNS.Text, this.XTYPE.Text, this.DESCRIPTION.Text, this.LENGTH.Text, this.PRIMARYKEYS.Text, this.IDENTITY.Text);
        }

        protected void btnCreateCS_Click(object sender, EventArgs e)
        {
            Com.AutoCode.CSCoder Coder = new Com.AutoCode.CSCoder();
            Coder.TableName = this.TABLE1.Text;
            this.CODES.Text = Coder.GetAutoCode(this.COLUMNS.Text, this.XTYPE.Text, this.DESCRIPTION.Text, this.LENGTH.Text, this.PRIMARYKEYS.Text, this.IDENTITY.Text);
        }

        protected void btnCreateImportSql_Click(object sender, EventArgs e)
        {
            string[] columns = this.COLUMNS.Text.Split(',');
            string[] datatypes = this.XTYPE.Text.Split(',');
            string Values = "";
            string Columns = "";
            int i = -1;
            foreach (string datatype in datatypes)
            {
                i++;
                if (columns[i] == this.IDENTITY.Text)
                {
                    continue;
                }
                if (datatype == "BIGINT" || datatype == "INT" || datatype == "TINYINT" || datatype == "FLOAT" || datatype == "BIT" || datatype == "DECIMAL" || datatype == "MONEY" || datatype == "NUMERIC")
                {
                    Values += "'+ cast(ISNULL(" + columns[i] + ",0) as varchar(100))+',";
                }
                else if (datatype == "DATETIME" || datatype == "SMALLDATETIME")
                {
                    Values += "'''+ CONVERT(varchar(100),ISNULL(" + columns[i] + ",'1900-1-1 00:00:00') ,120)+''',";
                }
                else
                {
                    Values += "'''+ISNULL(" + columns[i] + ",'NULL000')+''',";
                }
                Columns += columns[i] + ",";
            }
            this.CODES.Text = "SELECT REPLACE('INSERT INTO " + this.TABLE1.Text + "(" + Columns.TrimEnd(',') + ") VALUES(" + Values.TrimEnd(',') + ")','''NULL000''','NULL') FROM " + this.TABLE1.Text + "";

        }


        protected void btn_CreateTableView_Click(object sender, EventArgs e)
        {
            string FilePath = this.Path.Text;
            string FileName = FilePath.TrimEnd('\\') + "\\" + this.DATABASE.SelectedItem.Value + "表结构说明.html";
            Com.File.FileUtil.FileCreate(FileName, 1);
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            string FileContent = Com.AutoCode.TableDescriptionCoder.GetAutoCode(database_owner.Database_Owner,"","");
            Com.File.FileUtil.AppendFileContent(FileName, FileContent, "utf-8");
        
            //CreateTableView0(true);
        }

        protected void btn_CreateOneTableView_Click(object sender, EventArgs e)
        {

            CreateTableView0(false);
        }

        private void CreateTableView(bool All)
        {
            string FilePath = this.Path.Text;

            string FileName = FilePath.TrimEnd('\\') + "\\" + this.DATABASE.SelectedItem.Value + ".." + (All == false ? this.TABLE.SelectedItem.Text : "") + "表结构说明.html";
            Com.File.FileUtil.FileCreate(FileName, 1);

            string FileContent = "<html><head><style>body,table,th,td{font-size:9pt;padding:5px;}table{background-color:#000000;border-width:1px;}td{background-color:#ffffff;}th{background-color:#cccccc;}</style></head><body>";
            foreach (ListItem oItem in this.TABLE.Items)
            {
                if (oItem.Text.ToUpper().StartsWith("SYS"))
                {
                    continue;
                }
                bool bCreate = false;
                if (All == true)
                {
                    bCreate = true;
                }
                else if (oItem.Selected == true)
                {
                    bCreate = true;
                }
                if (bCreate == true)
                {
                    string ItemValue = oItem.Text.ToUpper();
                    this.TABLE1.Text = oItem.Text;
                    try
                    {
                        this.GetProperty(oItem);
                        string[] ColumnNames = this.COLUMNS0.Text.Split(',');
                        string[] XTypes = this.XTYPE.Text.Split(',');
                        string[] Lengths = this.LENGTH.Text.Split(',');
                        string[] IsNullAbles = this.ISNULLABLE.Text.Split(',');
                        string[] Defaults = this.DEFAULT.Text.Split(',');
                        string[] Descriptions = this.DESCRIPTION.Text.Split(',');
                        string[] PrimaryKeys = this.PRIMARYKEYS.Text.Split(',');
                        string Identitys = this.IDENTITY.Text;

                        FileContent += "<H1>" + this.TABLE1.Text + "</H1>说明:" + this.TABLECOMMENT.Text;
                        FileContent += "<table cellpadding=\"0\" cellspacing=\"1\"><tr><td>字段名</td><td>类型长度</td><td>是否主键</td><td>允许空</td><td>自增</td><td>默认值</td><td>说明</td></tr>";
                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            string ColumnName = ColumnNames[i];
                            string Primary = "";
                            foreach (string PrimaryKey in PrimaryKeys)
                            {
                                if (ColumnName == PrimaryKey)
                                {
                                    Primary = "*";
                                    break;
                                }
                            }
                            string XType = XTypes[i];
                            string Length = Lengths[i];
                            string IsNullAble = IsNullAbles[i];
                            string Default = Defaults[i];
                            string Description = Descriptions[i];
                            FileContent += "<tr>";
                            FileContent += "<td>" + ColumnName + "</td><td>" + XType + "(" + Length + ")</td><td>" + Primary + "</td><td>" + (IsNullAble == "0" ? "Not Null" : "") + "</td><td>" + (ColumnName == Identitys ? "自增" : "") + "</td><td>" + Default + "</td><td>" + Description + "</td>";
                            FileContent += "</tr>";
                        }
                        FileContent += "</table>";
                    }
                    catch
                    {
                    }
                }
            }
            FileContent += "</body></html>";
            Com.File.FileUtil.AppendFileContent(FileName, FileContent, "utf-8");
        }

        private void CreateTableView0(bool All)
        {
            string FilePath = this.Path.Text;
            string FileName = FilePath.TrimEnd('\\') + "\\" + this.DATABASE.SelectedItem.Value + (All == false ? ".." + this.TABLE.SelectedItem.Text : "") + "表结构说明.html";
            Com.File.FileUtil.FileCreate(FileName, 1);
            string jquery = Com.Net.UrlRequest.GetResponse(Business.Config.HostUrl + "/js/jquery-1.8.3.min.js", "");
            string FileContent = @"<html><head><style>
ul{margin-left: 0px;padding-left: 0px;}
li{float: left;width:{li_width}px;list-style:none;border:1px solid #cccccc;margin:1px;}
li.A,li.H,li.O,li.V{background-color:#C7E3BE}
li.B,li.I,li.P,li.W{background-color:#c6e7ff}
li.C,li.J,li.Q,li.X{background-color:#F9D82B}
li.D,li.K,li.R,li.Y{background-color:#ffffff}
li.E,li.L,li.S,li.Z{background-color:#95E8D6}
li.F,li.M,li.T{background-color:#f0f0f0}
li.G,li.N,li.U{background-color:#FEB8E9}
a.ds{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"http://newhouse.js.soufunimg.com/xfds/channelsales/Resource/Script/jquery.ui/images/ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 80%;}
a.dt{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"http://newhouse.js.soufunimg.com/xfds/channelsales/Resource/Script/jquery.ui/images/ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 53%;}
div.fixed_div{cursor:pointer;color:red;position:fixed;float:right;right:2px;background-color:#f0f0f0;width:22px;border:#000000 1px solid;text-align:center;padding:3px;}
body,table,th,td{font-size:9pt;padding:5px;}
table{border-spacing: 1px;background-color: black;padding: 0px;margin-bottom: 10px;border: medium none;}
table.Dst{width:100%;}
table.Dtt{display:none;}
td{background-color:#ffffff;}
td.bl{color:blue;}
span.exp{color:red;cursor:pointer;}
span.cl{color:red;cursor:pointer;float:right;}
th,tr.title td{background-color:#cccccc;cursor:pointer;font-weight:bold;}
a{text-decoration:none;color:#000000;}
#bg{z-index:10000;background-color:rgba(128, 128, 128, 0.76);width:100%;height:100%;position:fixed;left:0px;top:0px;margin:0px;padding:0px;display:none;}
</style>
<script type=" + "\"" + @"text/javascript" + "\"" + @">
" + jquery + @"
</script>
<script type=" + "\"" + @"text/javascript" + "\"" + @">
function sDst(id)
{
if(!$(" + "\"" + @"#bg" + "\"" + @").is(" + "\"" + @":hidden" + "\"" + @")){return;}
var obj = $(" + "\"" + @"#" + "\"" + @"+id);
obj.show();
obj.css(" + "\"" + @"zIndex" + "\"" + @", " + "\"" + @"10001" + "\"" + @");
obj.css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
obj.css(" + "\"" + @"top" + "\"" + @", document.body.scrollTop + 20 + " + "\"" + @"px" + "\"" + @");
obj.css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"700px" + "\"" + @");
if (window.innerWidth > 700) { obj.css(" + "\"" + @"left" + "\"" + @",((window.innerWidth - 700) / 2)+" + "\"" + @"px" + "\"" + @"); }
$(" + "\"" + @"#bg" + "\"" + @").show();
$(" + "\"" + @"#CrDst" + "\"" + @").val(id);
}
function cDst(id)
{
$(" + "\"" + @"#" + "\"" + @"+id).hide();
$(" + "\"" + @"#bg" + "\"" + @").hide();
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"700px" + "\"" + @");
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"initial" + "\"" + @");
}

function sDtt(id)
{
if(!$(" + "\"" + @"#bg" + "\"" + @").is(" + "\"" + @":hidden" + "\"" + @")){return;}
var obj = $(" + "\"" + @"#" + "\"" + @"+id);
obj.show();
obj.css(" + "\"" + @"zIndex" + "\"" + @", " + "\"" + @"10001" + "\"" + @");
obj.css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
obj.css(" + "\"" + @"top" + "\"" + @", document.body.scrollTop + 20 + " + "\"" + @"px" + "\"" + @");
$(" + "\"" + @"#bg" + "\"" + @").show();
$(" + "\"" + @"#CrDtt" + "\"" + @").val(id);
}
function cDtt(id)
{
$(" + "\"" + @"#" + "\"" + @"+id).hide();
$(" + "\"" + @"#bg" + "\"" + @").hide();
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"initial" + "\"" + @");
}
function closeAllTable()
{
if($(" + "\"" + @"#CrDst" + "\"" + @").val()!=" + "\"\"" + @")
{
cDst($(" + "\"" + @"#CrDst" + "\"" + @").val());
}
if($(" + "\"" + @"#CrDtt" + "\"" + @").val()!=" + "\"\"" + @")
{
cDtt($(" + "\"" + @"#CrDtt" + "\"" + @").val());
}
}
function showAllDst()
{
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"#ffffff" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"#cc0000" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#CrDst" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @"#CrDtt" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @".Dtt" + "\"" + @").hide();
    $(" + "\"" + @".Dst" + "\"" + @").show();
    $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"100%" + "\"" + @");
}
function showAllDtt()
{
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"#ffffff" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"#cc0000" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#CrDst" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @"#CrDtt" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @".Dst" + "\"" + @").hide();
    $(" + "\"" + @".Dtt" + "\"" + @").show();
    $(" + "\"" + @".Dtt" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @".Dtt" + "\"" + @").css(" + "\"" + @"width" + "\"" + @", " + "\"\"" + @");
}
function sli(classname)
{
    if($(" + "\"" + @"#exp_" + "\"" + @" + classname).text()==" + "\"" + @"-" + "\"" + @")
    {
        $(" + "\"" + @".x_" + "\"" + @"+classname" + @").hide();
        $(" + "\"" + @"#exp_" + "\"" + @" + classname).text(" + "\"" + @"+" + "\"" + @")
    }
    else
    {
        $(" + "\"" + @".x_" + "\"" + @"+classname" + @").show();
        $(" + "\"" + @"#exp_" + "\"" + @" + classname).text(" + "\"" + @"-" + "\"" + @")
    }
}
function expAll()
{
    if($(" + "\"" + @"#expall" + "\"" + @").text()==" + "\"" + @"-" + "\"" + @")
    {
        $(" + "\"" + @"#expall" + "\"" + @").text(" + "\"" + @"+" + "\"" + @")
        $(" + "\"" + @".x_all" + "\"" + @").hide();      
        $(" + "\"" + @".Dst" + "\"" + @").hide();
        $(" + "\"" + @".Dtt" + "\"" + @").hide();
        $(" + "\"" + @".exp_pl" + "\"" + @").text(" + "\"" + @"+" + "\"" + @");
    }
    else
    {
        $(" + "\"" + @"#expall" + "\"" + @").text(" + "\"" + @"-" + "\"" + @")
        $(" + "\"" + @".x_all" + "\"" + @").show();        
        $(" + "\"" + @".Dst" + "\"" + @").show();
        $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
        $(" + "\"" + @".Dtt" + "\"" + @").hide();
        $(" + "\"" + @".exp_pl" + "\"" + @").text(" + "\"" + @"-" + "\"" + @");
    }
}
function seticon()
{
$(" + "\"" + @".ds" + "\"" + @").text(" + "\"" + @"+" + "\"" + @");
$(" + "\"" + @".dt" + "\"" + @").text(" + "\"" + @".." + "\"" + @");
}
$(document).ready(function(){ 
$(" + "\"" + @"body" + "\"" + @").bind(" + "\"" + @"contextmenu" + "\"" + @", function() { return false;});
$(" + "\"" + @"body" + "\"" + @").bind(" + "\"" + @"selectstart" + "\"" + @",function(){return false;});
});
</script></head><body><img height=" + "\"" + @"0" + "\"" + @" width=" + "\"" + @"0" + "\"" + @" src=" + "\"" + @"http://newhouse.js.soufunimg.com/xfds/channelsales/Resource/Script/jquery.ui/images/ui-icons_222222_256x240.png" + "\"" + @" onerror=" + "\"" + @"javascript:seticon()" + "\"" + @"/>
<div class=" + "\"" + @"fixed_div" + "\"" + @" style=" + "\"" + @"right;top:10px;" + "\"" + @">
<a href=" + "\"" + @"#top" + "\"" + @" target=_self>返回顶部</a>
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"designs" + "\"" + @" style=" + "\"" + @"right;top:100px;" + "\"" + @" onclick=" + "\"" + @"javascript:showAllDst()" + "\"" + @">
表 结 构
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"datas" + "\"" + @" style=" + "\"" + @"right;top:170px;" + "\"" + @" onclick=" + "\"" + @"javascript:showAllDtt()" + "\"" + @">
数据样例
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"expall" + "\"" + @" style=" + "\"" + @"right;top:255px;" + "\"" + @" onclick=" + "\"" + @"javascript:expAll()" + "\"" + @">-</div>
<input name=" + "\"" + @"CrDst" + "\"" + @" type=" + "\"" + @"hidden" + "\"" + @" value=" + "\"\"" + @" id=" + "\"" + @"CrDst" + "\"" + @"/>
<input name=" + "\"" + @"CrDtt" + "\"" + @" type=" + "\"" + @"hidden" + "\"" + @" value=" + "\"\"" + @" id=" + "\"" + @"CrDtt" + "\"" + @"/>
<div id=" + "\"" + @"bg" + "\"" + @" onclick=" + "\"" + @"javascript:closeAllTable();" + "\"" + @">&nbsp;</div>
<h1 id=top>数据库" + this.DATABASE.SelectedItem.Value + "表结构说明("+System.DateTime.Now.ToString()+@")</h1><table><tr><td><ul>{TableList}</ul></td></tr></table>";
            string TableList = "";
            string letter = "";
            int tablename_maxlen = 0;
            foreach (ListItem oItem in this.TABLE.Items)
            {
                //if (oItem.Text.ToUpper().StartsWith("SYS"))
                //{
                //    continue;
                //}
                bool bCreate = false;
                if (All == true)
                {
                    bCreate = true;
                }
                else if (oItem.Selected == true)
                {
                    bCreate = true;
                }
                if (bCreate == true)
                {
                    string ItemValue = oItem.Text.ToUpper();
                    this.TABLE1.Text = oItem.Text;
                    if (tablename_maxlen < this.TABLE1.Text.Length)
                    {
                        tablename_maxlen = this.TABLE1.Text.Length;
                    }
                    try
                    {
                        this.GetProperty(oItem);
                        string[] ColumnNames = this.COLUMNS0.Text.Split(',');
                        string[] XTypes = this.XTYPE.Text.Split(',');
                        string[] Lengths = this.LENGTH.Text.Split(',');
                        string[] IsNullAbles = this.ISNULLABLE.Text.Split(',');
                        string[] Defaults = this.DEFAULT.Text.Split(',');
                        string[] Descriptions = this.DESCRIPTION.Text.Split(',');
                        string[] PrimaryKeys = this.PRIMARYKEYS.Text.Split(',');
                        string Identitys = this.IDENTITY.Text;

                        int topCount = 10;
                        string Sql = "SELECT COUNT(1) AS COUNTS FROM " + this.DATABASE.SelectedItem.Value + ".." + this.TABLE1.Text + " WITH(NOLOCK);SELECT TOP " + topCount + " " + this.COLUMNS0.Text + " FROM " + this.DATABASE.SelectedItem.Value + ".." + this.TABLE1.Text + " WITH(NOLOCK) ORDER BY " + this.PRIMARYKEYS.Text + " DESC";
                        DataSet oDs = this.Dbo.ExecuteDataSet(CommandType.Text, Sql);
                        DataTable oDt_Count = oDs.Tables[0];
                        DataTable oDt = oDs.Tables[1];
                        string prefix = "";
                        string ex_classname = "";
                        string ex_all_classname = "";
                        if (letter == this.TABLE1.Text.Substring(0, 1).ToUpper())
                        {
                            prefix = "　 ";
                            ex_classname = " x_" + letter;
                            ex_all_classname = " x_all";
                        }
                        else
                        {
                            letter = this.TABLE1.Text.Substring(0, 1).ToUpper();
                            prefix = "<span class=\"exp exp_pl\" id=\"exp_" + letter + "\" onclick=\"javascript:sli('" + letter + "')\">-</span><span class=\"exp\" onclick=\"javascript:sli('" + letter + "')\"><b>" + letter + "</b></span>&nbsp;";

                        }
                        TableList += "<li class=\"" + letter + ex_classname + ex_all_classname + "\">" + prefix + "<a href=\"#" + this.TABLE1.Text + "\">" + this.TABLE1.Text + "</a><a class=\"ds\" href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDst('design_" + this.TABLE1.Text + "')\"></a><a class=\"dt\" href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDtt('data_" + this.TABLE1.Text + "')\"></a></li>";
                        FileContent += "<a id=\"" + this.TABLE1.Text + "\"></a><table cellpadding=\"0\" cellspacing=\"1\" id=\"data_" + this.TABLE1.Text + "\" class=\"Dtt\"><tr><td colspan=" + ColumnNames.Length + "><a href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDst('design_" + this.TABLE1.Text + "')\"><b>" + this.TABLE1.Text + "</b> (共<font color=red>" + oDt_Count.Rows[0]["COUNTS"].ToString() + "</font>条记录) >>></a><span class=\"cl\" onclick=\"javascript:cDtt('data_" + this.TABLE1.Text + "')\">关闭</span></td></tr>";
                        FileContent += "<tr><td colspan=" + ColumnNames.Length + ">说明：" + this.TABLECOMMENT.Text + "</td></tr>";
                        FileContent += "<tr class=title>";
                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            string Primary = "";
                            string columnname = "{0}";
                            foreach (string PrimaryKey in PrimaryKeys)
                            {
                                if (ColumnNames[i].ToUpper() == PrimaryKey.ToUpper())
                                {
                                    Primary = "主键";
                                    columnname = "<font color=red>{0}</font>";
                                    break;
                                }
                            }
                            //FileContent += "<td title=\"" +
                            //    XTypes[i] + "(" + Lengths[i] + ")" +
                            //    (Identitys.ToUpper() == ColumnNames[i].ToUpper() ? "\r\n自增" : "") +
                            //     (string.IsNullOrEmpty(Primary) == false ? " " + Primary : "") +
                            //    (IsNullAbles[i] == "0" ? "\r\nNot Null" : "") +
                            //    (string.IsNullOrEmpty(Defaults[i].Trim()) == true ? "" : ("\r\nDefaults(" + Defaults[i] + ")")) +
                            //    "\r\n" + Descriptions[i] + "\">" + string.Format(columnname, ColumnNames[i]) + "</td>";
                            FileContent += "<td>" + string.Format(columnname, ColumnNames[i]) + "</td>";
                        }
                        FileContent += "</tr>";
                        foreach (DataRow oDr in oDt.Rows)
                        {
                            FileContent += "<tr>";
                            foreach (DataColumn oDc in oDt.Columns)
                            {
                                FileContent += "<td>" + Server.HtmlEncode(Com.Common.StringUtil.GetLenContent(oDr[oDc.ColumnName].ToString(), 100)) + "</td>";
                            }
                            FileContent += "</tr>";
                        }
                        if (oDt.Rows.Count >= topCount)
                        {
                            FileContent += "<tr>";
                            foreach (DataColumn oDc in oDt.Columns)
                            {
                                FileContent += "<td>...</td>";
                            }
                            FileContent += "</tr>";
                        }

                        if (oDt.Rows.Count == 0)
                        {
                            FileContent += "<tr><td colspan=" + ColumnNames.Length + ">&nbsp;</td></tr>";
                        }
                        FileContent += "</table>";
                        string TableHtml = "<table cellpadding=\"0\" cellspacing=\"1\" id=\"design_" + this.TABLE1.Text + "\" class=\"Dst\">" +
                            "<tr><td colspan=\"7\"><a href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDtt('data_" + this.TABLE1.Text + "')\"><b>" + this.TABLE1.Text + "</b> >>></a><span class=\"cl\" onclick=\"javascript:cDst('design_" + this.TABLE1.Text + "')\">关闭</span></td></tr>" +
                            "<tr class=\"title\"><td>字段名</td><td>类型长度</td><td>是否主键</td><td>允许空</td><td>自增</td><td>默认值</td><td>说明</td></tr>";

                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            string ColumnName = ColumnNames[i];
                            string Primary = "";
                            foreach (string PrimaryKey in PrimaryKeys)
                            {
                                if (ColumnName.ToUpper() == PrimaryKey.ToUpper())
                                {
                                    Primary = "是";
                                    break;
                                }
                            }
                            string XType = XTypes[i];
                            string Length = Lengths[i];
                            string IsNullAble = IsNullAbles[i];
                            string Default = Defaults[i];
                            string Description = Descriptions[i];
                            TableHtml += "<tr>";
                            TableHtml += "<td>" + ColumnName + "</td><td class=\"bl\">" + XType.ToLower() + "(" + (Length == "-1" ? "max" : Length) + ")</td><td>" + Primary + "</td><td>" + (IsNullAble == "0" ? "Not Null" : "") + "</td><td>" + (ColumnName == Identitys ? "自增" : "") + "</td><td>" + Default + "</td><td>" + Description + "</td>";
                            TableHtml += "</tr>";
                        }
                        TableHtml += "</table>";
                        FileContent += TableHtml;
                    }
                    catch
                    {
                    }
                }
            }
            FileContent += "</body></html>";
            Com.File.FileUtil.AppendFileContent(FileName, FileContent.Replace("{TableList}", TableList).Replace("{li_width}", (tablename_maxlen * 6.2 + 52).ToString()), "utf-8");
        }
    }
}
