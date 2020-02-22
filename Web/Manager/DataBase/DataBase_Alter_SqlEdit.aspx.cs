using System;
using System.Collections.Generic;

using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Alter_SqlEdit : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Alter_SqlEdit.aspx");
            if (this.QueryString("ID") != "")
            {
                this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
            }
            this.P_BackUrl = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Alter_List.aspx";
            
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.P_ID))
                {
                    Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                    database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_IP_ROMOTE + "+'..'+" + database_owner._DATABASE_NAME + " AS " + database_owner._DATABASE_NAME };
                    database_owner.CacheTime = 60;
                    database_owner.DATABASE_IS_MAIN = 1;
                    database_owner.WhereSql = database_owner._DATABASE_NAME + " IN ('tuan','channelsales')";
                    DataTable oDt_database_owner = database_owner.Select();

                    this.ddl_Database_Name.DataTextField = database_owner._DATABASE_NAME;
                    this.ddl_Database_Name.DataValueField = database_owner._DATABASE_IP_ROMOTE;

                    this.ddl_Database_Name.DataSource = oDt_database_owner;
                    this.ddl_Database_Name.DataBind();

                    foreach (ListItem item in this.ddl_Database_Name.Items)//增加仿真库
                    {
                        string[] itemtexts = item.Text.Split('.');
                        Entity.TEAMTOOL.DATABASE_OWNER database_owner_fangzhen = new Entity.TEAMTOOL.DATABASE_OWNER();
                        database_owner_fangzhen.SelectColumns = new string[] { database_owner_fangzhen._DATABASE_IP_ROMOTE, database_owner_fangzhen._DATABASE_IP_ROMOTE + "+'..'+" + database_owner_fangzhen._DATABASE_NAME + " AS " + database_owner_fangzhen._DATABASE_NAME };
                        database_owner_fangzhen.CacheTime = 60;
                        database_owner_fangzhen.DATABASE_IS_MAIN = 2;
                        database_owner_fangzhen.DATABASE_NAME = itemtexts[itemtexts.Length - 1];
                        DataTable oDt_database_owner_fangzhen = database_owner_fangzhen.Select();
                        if (oDt_database_owner_fangzhen != null && oDt_database_owner_fangzhen.Rows.Count > 0)
                        {
                            item.Value = item.Value + ";" + oDt_database_owner_fangzhen.Rows[0][database_owner_fangzhen._DATABASE_IP_ROMOTE].ToString();
                        }
                    }

                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("执行失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_ALTER database_alter = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter.ID = int.Parse(this.P_ID);
            if (database_alter.SelectTop1() != null)
            {
                if (database_alter.ALTER_STATUS_ToString == "0")
                {
                    foreach (ListItem item in this.ddl_Database_Name.Items)
                    {
                        if (item.Value == database_alter.DATABASE_IP)
                        {
                            item.Selected = true;
                            break;
                        }
                    }

                    this.txt_Alter_Sql.Text = database_alter.ALTER_SQL;
                    this.txt_Alter_Remark.Text = database_alter.ALTER_REMARK;

                }
                else
                {
                    this.RedirectConfirm("此sql已经执行过！", this.P_BackUrl);
                }

            }
            else
            {
                this.RedirectConfirm("执行失败！不存在此记录！", this.P_BackUrl);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.TEAMTOOL.DATABASE_ALTER database_alter = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter.ID = int.Parse(this.P_ID);
            if (database_alter.SelectTop1() != null)
            {
                if (database_alter.ALTER_STATUS_ToString == "0")
                {
                    string[] itemtexts = this.ddl_Database_Name.SelectedItem.Text.Split('.');
                    string Database_Name = itemtexts[itemtexts.Length - 1];

                    Entity.TEAMTOOL.DATABASE_ALTER database_alter_update = new Entity.TEAMTOOL.DATABASE_ALTER();
                    database_alter_update.ID = int.Parse(this.P_ID);
                    database_alter_update.DATABASE_IP = this.ddl_Database_Name.SelectedItem.Value;
                    database_alter_update.DATABASE_NAME = Database_Name; 
                    database_alter_update.ALTER_SQL = this.txt_Alter_Sql.Text;
                    database_alter_update.ALTER_REMARK = this.txt_Alter_Remark.Text;
                    if (database_alter_update.Update() == false)
                    {
                        string msg = "提交失败！";
                        this.AlertScript(msg);
                        this.ltrMsg.Text = msg;
                        return;
                    }
                    else
                    {
                        string msg = "提交成功！";
                        this.RedirectConfirm(msg, this.P_BackUrl);
                    }
                }
                else
                {
                    this.RedirectConfirm("此sql已经执行过！", this.P_BackUrl);
                }

            }
            else
            {
                this.RedirectConfirm("执行失败！不存在此记录！", this.P_BackUrl);
            }
        }
    }
}