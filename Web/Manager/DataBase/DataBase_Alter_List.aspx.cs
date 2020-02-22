using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Alter_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        public int _PageSize = 10;
        private string P_DataBase_IP_Romote = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Alter_List.aspx");
            if (this.QueryString("page") != "")
            {
                this.P_page = int.Parse(this.QueryString("page"));
            }
            if (this.QueryString("DataBase_IP_Romote") != "")
            {
                this.P_DataBase_IP_Romote = Com.Common.EncDec.Decrypt(this.QueryString("DataBase_IP_Romote"), this.Encrypt_key).Split(',')[0];
            }
            if (!Page.IsPostBack)
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
                foreach (ListItem item in this.ddl_Database_Name.Items)
                {
                    if (item.Value == this.P_DataBase_IP_Romote)
                    {
                        item.Selected = true;
                        break;
                    }
                }
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
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_ALTER database_alter = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            database_alter.SelectColumns = new string[] { database_alter.TableName + ".*", "ISNULL(WebManager_realname,DATABASE_ALTER.WebManager_name) as WebManager_realname" };
            database_alter.OrderBy = database_alter._ALTER_STATUS + " ASC," + database_alter._ID + " DESC";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                database_alter.ALTER_SQL = "%" + this.txtKeyword.Text + "%";
            }
            DataTable oDt_database_alter = database_alter.SelectByPaging(this._PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Alter_List.aspx?page={page}";

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================


            this.rptLog.DataSource = oDt_database_alter;
            this.rptLog.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] itemtexts = this.ddl_Database_Name.SelectedItem.Text.Split('.');
            string Database_Name = itemtexts[itemtexts.Length - 1];

            Entity.TEAMTOOL.DATABASE_ALTER database_alter_select = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter_select.WEBMANAGER_NAME = this.CurrentWebManagerName;
            database_alter_select.DATABASE_IP = this.ddl_Database_Name.SelectedItem.Value;
            database_alter_select.DATABASE_NAME = Database_Name;
            database_alter_select.WhereSql = "(" + database_alter_select._CREATETIME + ">'" + System.DateTime.Now.ToShortDateString() + "')";
            if (database_alter_select.SelectTop1() != null && CurrentIsAdmin == false)
            {
                string msg = "您今天已经提交过一次“" + this.ddl_Database_Name.SelectedItem.Text + "”的修改请求，如果着急，请找别人帮忙提交！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
            if (this.txt_Alter_Remark.Text.Trim() == "" || this.txt_Alter_Sql.Text.Trim() == "")
            {
                string msg = "请填写完毕！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
            //检查sql语法是否正确
            string Sql = @"DECLARE @sql NVARCHAR(MAX)
                        SET @sql = '" + this.txt_Alter_Sql.Text.Replace("'", "''") + @"'
                        DECLARE @testsql NVARCHAR(MAX), @result INT
                        SET @testsql = N'SET PARSEONLY ON; ' + @sql+'' --非常关键，不能去掉，起到只检查不执行的作用
                        EXEC @result = sp_executesql @testsql
                        IF( @result=0) 
	                        BEGIN
		                        select 0 --正确的sql语法
	                        END 
                        ELSE 
	                        BEGIN
		                        select -1 --错误的sql语法
	                        END";
            Database Database_Owner = DatabaseFactory.CreateDatabase(this.ddl_Database_Name.SelectedItem.Value.Split(';')[0] + "_" + Database_Name + "_DataBaseInstance");
            DataTable ExecResult = null;
            string error = "";
            try
            {
                ExecResult = Database_Owner.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            //if (ExecResult == null || ExecResult.Rows[0][0].ToString() == "-1")
            //{
            //    string msg = "错误的SQL语法，" + error + "请检查后再提交！";
            //    this.AlertScript(msg);
            //    this.ltrMsg.Text = msg;
            //    this.BindData();
            //    return;
            //}

            Entity.TEAMTOOL.DATABASE_ALTER database_alter = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter.DATABASE_IP = this.ddl_Database_Name.SelectedItem.Value;
            database_alter.DATABASE_NAME = Database_Name;
            database_alter.WEBMANAGER_NAME = this.CurrentWebManagerName;
            database_alter.ALTER_SQL = this.txt_Alter_Sql.Text;
            database_alter.ALTER_STATUS = 0;
            database_alter.ALTER_REMARK = this.txt_Alter_Remark.Text;
            database_alter.ALTER_PROBLEM = error;
            //database_alter.ALTER_TIME = System.DateTime.Now;
            database_alter.CREATETIME = System.DateTime.Now;

            if (database_alter.Insert() == false)
            {
                string msg = "提交失败！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
            else
            {
                string msg = "提交成功！";
                #region 发邮件
                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailUserList = "lushijun@fang.com";
                mail.CopyToMailUserList = this.CurrentWebManagerName + "@fang.com";
                mail.MailTitle = this.CurrentWebManagerRealName + " 提交了数据库 " + this.ddl_Database_Name.SelectedItem.Text + " 的修改需求，请审核~[系统邮件请勿回复]";
                mail.MailContent = "Hi!!&nbsp;&nbsp;<br/><br/>" +
                    "&nbsp;&nbsp;“" + this.CurrentWebManagerRealName + "”提交了数据库 " + this.ddl_Database_Name.SelectedItem.Text + " 的修改需求，请 <a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/DataBase_Alter_List.aspx\" target=\"_blank\">点击这里</a> 审核执行！<p><font color=green>/**" + this.txt_Alter_Remark.Text + "**/</font></p><p><font color=blue>" + this.txt_Alter_Sql.Text.Replace("\r\n", "<br>") + "</font></p>";
                if (!mail.SendOneMailByHTML())
                {
                    Business.MallLog.Create(0, "Share", "TeamTool发送:提交了数据库的修改需求~邮件失败", "发送失败", Request.UserHostAddress);
                }
                #endregion
                this.ddl_Database_Name.Enabled = false;
                this.txt_Alter_Sql.Enabled = false;
                this.txt_Alter_Remark.Enabled = false;
                this.btnSubmit.Enabled = false;
                this.btnSubmit.BackColor = System.Drawing.Color.Gray;
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}