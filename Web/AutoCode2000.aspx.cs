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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Web
{
    public partial class AutoCode2000 : Com.Web.WebUI
    {

        Microsoft.Practices.EnterpriseLibrary.Data.Database Dbo = Com.Data.DatabaseOperater.DataBaseOwner;
        private void Page_Load(object sender, System.EventArgs e)
        {
            //			this.PageBegin(10);
            if (Page.IsPostBack)
                return;


            DataTable oDt = new DataTable("JoinTableList");
            oDt.Columns.Add("JoinDataBase", typeof(string));//数据库
            oDt.Columns.Add("JoinTableName", typeof(string));//表名
            oDt.Columns.Add("JoinTableAs", typeof(string));//表别名
            oDt.Columns.Add("JoinColumnName", typeof(string));//列名
            oDt.Columns.Add("ColumnName", typeof(string));//列名
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
			DataTable oDt=(DataTable)ViewState["JoinTableList"];
			Com.AutoCode.EntityCoder Coder=new Com.AutoCode.EntityCoder();
			Coder.TABLENAME=this.TABLE1.Text;
			this.CODES.Text=Coder.GetAutoCode(this.NAMESPACE.Text,this.DATABASE1.Text.ToUpper(),this.TABLE1.Text.ToUpper(),this.TABLECOMMENT.Text,this.COLUMNS.Text,this.PRIMARYKEYS.Text,this.XTYPE.Text,this.LENGTH.Text,this.ISNULLABLE.Text,this.DEFAULT.Text,this.DESCRIPTION.Text,this.IDENTITY.Text,oDt);
		}

		protected void DATABASE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (DATABASE.SelectedItem.Value.Trim() == "")
            {
                return;
            }
			this.DATABASE1.Text=this.DATABASE.SelectedItem.Text;
			Com.Data.SqlServer.Entity.SYSOBJECTS SYSOBJECTS=new Com.Data.SqlServer.Entity.SYSOBJECTS();
			SYSOBJECTS.DataBase=this.DATABASE.SelectedItem.Value;
//						SYSOBJECTS.WhereSql=" (XTYPE='U' OR XTYPE='S') ";
            SYSOBJECTS.WhereSql = " (XTYPE='U' OR XTYPE='S') ";
			SYSOBJECTS.SelectColumns=new string[]{"NAME","ID"};
			DataTable oDt=SYSOBJECTS.Select();
			this.TABLE.DataSource=oDt;
			this.TABLE.DataTextField="NAME";
			this.TABLE.DataValueField="ID";
			this.TABLE.DataBind();
		}
		protected void GetProperty(ListItem oItem)
		{
			this.XTYPE.Text="";
			this.LENGTH.Text="";
			this.COLUMNS.Text="";
			this.DESCRIPTION.Text="";
			this.ISNULLABLE.Text="";
			this.DEFAULT.Text="";
			this.IDENTITY.Text="";
			Com.Data.SqlServer.Entity.SYSCOLUMNS SYSCOLUMNS=new Com.Data.SqlServer.Entity.SYSCOLUMNS();
			SYSCOLUMNS.DataBase=this.DATABASE.SelectedItem.Value;
			SYSCOLUMNS.ID=int.Parse(oItem.Value);
			SYSCOLUMNS.OrderBy=" COLID ";
			SYSCOLUMNS.Distinct=false;
			SYSCOLUMNS.SelectColumns=new string[]{"ID","NAME","XTYPE","LENGTH","COLID","ISNULLABLE","CDEFAULT"};
			DataTable oDt=SYSCOLUMNS.Select();
			string Columns="";
			string Xtypes="";
			string Lengths="";
			string Descriptions="";
			string Isnullables="";
			string Defaults="";
			foreach(DataRow oDr in oDt.Rows)
			{
				Columns+=oDr["NAME"].ToString().ToUpper()+",";
				Com.Data.SqlServer.Entity.SYSTYPES SYSTYPES=new Com.Data.SqlServer.Entity.SYSTYPES();
				SYSTYPES.DataBase=this.DATABASE.SelectedItem.Value;
				SYSTYPES.XTYPE=byte.Parse(oDr["XTYPE"].ToString().ToUpper());
				SYSTYPES.SelectColumns=new string[]{"NAME"};
				SYSTYPES.SelectTop1();
				Xtypes+=SYSTYPES.NAME.ToUpper()+",";
				Lengths+=oDr["LENGTH"].ToString()+",";

				Com.Data.SqlServer.Entity.SYSPROPERTIES SYSPROPERTIES=new Com.Data.SqlServer.Entity.SYSPROPERTIES();
				SYSPROPERTIES.DataBase=this.DATABASE.SelectedItem.Value;
				SYSPROPERTIES.ID=int.Parse(oDr["ID"].ToString());
				SYSPROPERTIES.SMALLID=int.Parse(oDr["COLID"].ToString());
				SYSPROPERTIES.SelectTop1();
				Descriptions+=(SYSPROPERTIES.VALUE==""?" ":SYSPROPERTIES.VALUE.Replace(",",""))+",";
				Isnullables+=oDr["ISNULLABLE"].ToString()+",";

				Com.Data.SqlServer.Entity.SYSCOMMENTS SYSCOMMENTS=new Com.Data.SqlServer.Entity.SYSCOMMENTS();
				SYSCOMMENTS.DataBase=this.DATABASE.SelectedItem.Value;
				SYSCOMMENTS.ID=int.Parse(oDr["CDEFAULT"].ToString());
				SYSCOMMENTS.SelectColumns=new string[]{"TEXT"};
				SYSCOMMENTS.SelectTop1();
				string a=SYSCOMMENTS.TEXT;
				if(SYSCOMMENTS.TEXT.Trim()=="")
					a=" ";
				else if(SYSCOMMENTS.TEXT.IndexOf("'")==-1)
					a=SYSCOMMENTS.TEXT.Replace(")","").Replace("(","");
				else 
					a=SYSCOMMENTS.TEXT.Substring(SYSCOMMENTS.TEXT.IndexOf("'")+1,SYSCOMMENTS.TEXT.LastIndexOf("'")-SYSCOMMENTS.TEXT.IndexOf("'")-1);
				Defaults+=a+",";
				if(this.IDENTITY.Text.Trim()=="")
				{
                    //System.Data.SqlClient.SqlConnection oCon=new System.Data.SqlClient.SqlConnection(Com.Config.SystemConfig.DefaultConnectionString.ToUpper().Replace("DATABASE="+this.PubDB.ToUpper()+"","DATABASE="+this.DATABASE.SelectedItem.Text.ToUpper()+""));
                    //System.Data.SqlClient.SqlCommand oComm=new System.Data.SqlClient.SqlCommand("SELECT COLUMNPROPERTY(  OBJECT_ID('"+oItem.Text+"'),'"+oDr["NAME"].ToString()+"','IsIdentity')",oCon);
					string Identity="0";
					try
					{
						//oCon.Open();
                        //Identity = Convert.ToString(this.Dbo.ExecuteScalar("SELECT COLUMNPROPERTY(OBJECT_ID('" + oItem.Text + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')", CommandType.Text));
                        DBCommandWrapper cmd0 = this.Dbo.GetSqlStringCommandWrapper("SELECT COLUMNPROPERTY(OBJECT_ID('" + oItem.Text + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')");
                        Identity =  Convert.ToString(this.Dbo.ExecuteScalar(cmd0));

					}
					catch(Exception err)
					{
						string aa=err.ToString();
					}
					finally
					{
						//oCon.Close();
					}
					if(Identity=="1")
						this.IDENTITY.Text=oDr["NAME"].ToString().ToUpper();
				}
			}
			this.XTYPE.Text=Xtypes.TrimEnd(',');
			this.LENGTH.Text=Lengths.TrimEnd(',');
			this.COLUMNS.Text=Columns.TrimEnd(',');
			this.DESCRIPTION.Text=Descriptions.TrimEnd(',');
			this.ISNULLABLE.Text=Isnullables.TrimEnd(',');
			this.DEFAULT.Text=Defaults.TrimEnd(',');

            string spName = "sp_pkeys";
            DBCommandWrapper cmd = this.Dbo.GetStoredProcCommandWrapper(spName);
            cmd.AddParameter("@table_name", DbType.String, 30, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, oItem.Text);
            DataTable oDt1 = this.Dbo.ExecuteDataSet(cmd).Tables[0];
            //DataTable oDt1 = this.Dbo.ExecuteDataSet("EXEC [" + this.DATABASE.SelectedItem.Text + "]..[sp_pkeys] @table_name='" + oItem.Text + "'", CommandType.StoredProcedure).Tables[0];
			string Keys="";
			foreach(DataRow oDr in oDt1.Rows)
			{
				Keys+=oDr["COLUMN_NAME"].ToString().ToUpper()+",";
			}
			this.PRIMARYKEYS.Text=Keys.TrimEnd(',');
			Com.Data.SqlServer.Entity.SYSPROPERTIES SYSPROPERTIES1=new Com.Data.SqlServer.Entity.SYSPROPERTIES();
			SYSPROPERTIES1.DataBase=this.DATABASE.SelectedItem.Value;
			SYSPROPERTIES1.JoinSql=" INNER JOIN "+this.DATABASE.SelectedItem.Value+"..sysobjects sysobjects ON sysproperties.id = sysobjects.id ";
			SYSPROPERTIES1.WhereSql=" (sysproperties.smallid = 0) and sysobjects.name='"+oItem.Text+"' ";
			SYSPROPERTIES1.SelectColumns=new string[]{SYSPROPERTIES1._VALUE};
			SYSPROPERTIES1.SelectTop1();
			this.TABLECOMMENT.Text=SYSPROPERTIES1.VALUE;
		}
		protected void TABLE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.TABLE1.Text=this.TABLE.SelectedItem.Text;
			this.GetProperty(this.TABLE.SelectedItem);
			this.CREATE_Click(this,null);
		}

		protected void CREATES_Click(object sender, System.EventArgs e)
		{
			string FilePath=this.Path.Text;
			foreach(ListItem oItem in this.TABLE.Items)
			{
				try
				{
					this.TABLE1.Text=oItem.Text;
					this.GetProperty(oItem);
					this.CREATE_Click(this,null);
					if(Com.File.FileUtil.FileExists(FilePath.TrimEnd('\\')+"\\"+oItem.Text.ToUpper()+".cs"))
					{
						string FileContent=Com.File.FileUtil.GetFileContent(FilePath.TrimEnd('\\')+"\\"+oItem.Text.ToUpper()+".cs");
						int StartIndex1=this.CODES.Text.IndexOf("#region 系统代码，请不要动");
						int EndIndex1=this.CODES.Text.IndexOf("#endregion 系统代码，请不要动")+20;
						string NewCodes=this.CODES.Text.Substring(StartIndex1,EndIndex1-StartIndex1);

						int StartIndex=FileContent.IndexOf("#region 系统代码，请不要动");
						int EndIndex=FileContent.IndexOf("#endregion 系统代码，请不要动")+20;
						string OldCodes=FileContent.Substring(StartIndex,EndIndex-StartIndex);
											FileContent=FileContent.Replace(OldCodes,NewCodes);
						Com.File.FileUtil.WriteFileContent(FilePath.TrimEnd('\\')+"\\"+oItem.Text.ToUpper()+".cs",FileContent,"GB2312",false);
					}
					else
					{
						Com.File.FileUtil.FileCreate(FilePath.TrimEnd('\\')+"\\"+oItem.Text.ToUpper()+".cs",0);
						Com.File.FileUtil.AppendFileContent(FilePath.TrimEnd('\\')+"\\"+oItem.Text.ToUpper()+".cs",this.CODES.Text);
					}
				}
				catch
				{
				}
			}
		}

		protected void CREATESP_Click(object sender, System.EventArgs e)
		{
			Com.AutoCode.SPCoder SPCoder=new Com.AutoCode.SPCoder();
			SPCoder.NAMESPACE=this.NAMESPACE.Text.ToUpper();
			SPCoder.DATABASE=this.DATABASE1.Text.ToUpper();
			SPCoder.TABLENAME=this.TABLE1.Text.ToUpper();
			SPCoder.COLUMNS=this.COLUMNS.Text;
			SPCoder.PRIMARYKEYS=this.PRIMARYKEYS.Text;
			SPCoder.DATATYPES=this.XTYPE.Text;
			SPCoder.LENGTHS=this.LENGTH.Text;
			SPCoder.ISNULLABLES=this.ISNULLABLE.Text;
			SPCoder.DEFAULTS=this.DEFAULT.Text;
			SPCoder.DESCRIPTIONS=this.DESCRIPTION.Text;
			SPCoder.IDENTITY=this.IDENTITY.Text;
			this.CODES.Text=SPCoder.GET_SP_OBJ_INSERT()+"\r\n\r\n\r\n"+SPCoder.GET_SP_OBJ_UPDATE()+"\r\n\r\n\r\n"+SPCoder.GET_SP_OBJ_SELECT()+"\r\n\r\n\r\n"+SPCoder.GET_SP_OBJ_DELETE()+"\r\n\r\n\r\n";
		}

		protected void CREATESSP_Click(object sender, System.EventArgs e)
		{
			string SP="";
			foreach(ListItem oItem in this.TABLE.Items)
			{
				
				this.TABLE1.Text=oItem.Text;
				this.GetProperty(oItem);
				this.CREATESP_Click(this,null);
					
				SP+=this.CODES.Text;
			}
			this.CODES.Text=SP;
		}
		protected void GetDataChanges()
		{
			DataTable	oDt	= (DataTable)ViewState["JoinTableList"];
			foreach(DataGridItem oItem in this.dgJoinTable.Items)
			{
				if(oItem.ItemIndex>=0)
				{
					TextBox JoinDataBase	=(TextBox)oItem.FindControl("JoinDataBase");
					TextBox JoinTableName	=(TextBox)oItem.FindControl("JoinTableName");
					TextBox JoinColumnName	=(TextBox)oItem.FindControl("JoinColumnName");
                    TextBox ColumnName = (TextBox)oItem.FindControl("ColumnName");
                    TextBox JoinColumnName1 = (TextBox)oItem.FindControl("JoinColumnName1");
                    TextBox ColumnName1 = (TextBox)oItem.FindControl("ColumnName1");
					try
					{
						oDt.Rows[oItem.DataSetIndex]["JoinDataBase"]= JoinDataBase.Text;
						oDt.Rows[oItem.DataSetIndex]["JoinTableName"]= JoinTableName.Text;
						oDt.Rows[oItem.DataSetIndex]["JoinColumnName"]= JoinColumnName.Text;
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
			if(e.Item.ItemIndex!=-1)
			{
				DataRow oDr=((DataTable)this.dgJoinTable.DataSource).Rows[e.Item.DataSetIndex];
				TextBox JoinDataBase	=(TextBox)e.Item.FindControl("JoinDataBase");
				TextBox JoinTableName	=(TextBox)e.Item.FindControl("JoinTableName");
				TextBox JoinColumnName	=(TextBox)e.Item.FindControl("JoinColumnName");
                TextBox ColumnName = (TextBox)e.Item.FindControl("ColumnName");
                TextBox JoinColumnName1 = (TextBox)e.Item.FindControl("JoinColumnName1");
                TextBox ColumnName1 = (TextBox)e.Item.FindControl("ColumnName1");
				try
				{
					JoinDataBase.Text=oDr["JoinDataBase"].ToString();
					JoinTableName.Text=oDr["JoinTableName"].ToString();
					JoinColumnName.Text=oDr["JoinColumnName"].ToString();
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
			Business.Common.AddDataItem(this.dgJoinTable,(DataTable)ViewState["JoinTableList"]);
			
		}

		protected void DeleteJoinTable_Click(object sender, System.EventArgs e)
		{
			this.GetDataChanges();
            Business.Common.DeleteDataItem(this.dgJoinTable, (DataTable)ViewState["JoinTableList"]);
		}

		protected void UpdateMetaData_Click(object sender, System.EventArgs e)
		{
		
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
	}
}
