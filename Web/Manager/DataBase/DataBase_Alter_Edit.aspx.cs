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
    public partial class DataBase_Alter_Edit : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Alter_Edit.aspx");

            if (!Page.IsPostBack)
            {
                this.P_BackUrl = this.QueryString("BackUrl");
                if (string.IsNullOrEmpty(this.P_BackUrl))
                {
                    if (Request.UrlReferrer != null)
                    {
                        if (Request.UrlReferrer != null)
                        {
                            this.P_BackUrl = Request.UrlReferrer.ToString();
                        }
                        else
                        {
                            this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                        }
                    }
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                    }

                }
                if (this.QueryString("ID") != "")
                {
                    this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
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
                #region 存在
                bool bSuccess = true;
                string Result = "";
                string Error = "";
                int RowCount = 0;

                string[] IPs = database_alter.DATABASE_IP.Split(';');
                foreach (string ip in IPs)
                {
                    if (!string.IsNullOrEmpty(ip))
                    {
                        Database Database_Owner = DatabaseFactory.CreateDatabase(ip + "_" + database_alter.DATABASE_NAME + "_DataBaseInstance");
                        //注： 在cmd.ExecuteNonQuery()是不允许语句中有GO出现的， 有则出错。
                        string connectionString = Database_Owner.GetConnection().ConnectionString;
                        string error = "";
                        int rowcount = 0;
                        if (ExecuteSqlWithGoUseTran(connectionString, database_alter.ALTER_SQL, out rowcount, out error) == false)
                        {
                            bSuccess = false;
                        }
                        Error += ";" + error;
                        RowCount += rowcount;
                    }
                }

                Entity.TEAMTOOL.DATABASE_ALTER database_alter_update = new Entity.TEAMTOOL.DATABASE_ALTER();
                database_alter_update.ID = int.Parse(this.P_ID);
                if (bSuccess == true)
                {
                    Result = "执行成功，";
                    database_alter_update.ALTER_STATUS = 1;
                    database_alter_update.ALTER_TIME = System.DateTime.Now;
                    database_alter_update.ALTER_PROBLEM = database_alter.ALTER_PROBLEM + ";" + System.DateTime.Now.ToString() + " 执行结果:执行成功！(" + RowCount.ToString() + " 行受影响)";
                }
                else
                {
                    Result = "执行失败，";
                    database_alter_update.ALTER_STATUS = 0;
                    database_alter_update.ALTER_PROBLEM = database_alter.ALTER_PROBLEM + ";" + System.DateTime.Now.ToString() + " 执行结果:" + Error;
                }
                if (database_alter_update.Update() == true)
                {
                    this.RedirectConfirm(Result + "database_alter_update.Update()成功！(" + RowCount.ToString() + " 行受影响)", this.P_BackUrl);
                    if (bSuccess == true)
                    {
                        #region 发邮件
                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                        mail.MailUserList = database_alter.WEBMANAGER_NAME + "@fang.com";
                        mail.CopyToMailUserList = "lushijun@fang.com";
                        mail.MailTitle = "你提交数据库" + database_alter.DATABASE_IP + ".." + database_alter.DATABASE_NAME + "的修改需求已审核通过,并已执行成功~[系统邮件请勿回复]";
                        mail.MailContent = "Hi!!&nbsp;&nbsp;<br/><br/>" +
                            "&nbsp;&nbsp;你提交的数据库" + database_alter.DATABASE_IP + ".." + database_alter.DATABASE_NAME + "的修改需求已执行成功(" + RowCount.ToString() + " 行受影响)，请 <a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/DataBase_Alter_List.aspx\" target=\"_blank\">点击这里</a> 查看！<p><font color=green>/**" + database_alter.ALTER_REMARK + "**/</font></p><p><font color=blue>" + database_alter.ALTER_SQL.Replace("\r\n", "<br>") + "</font></p>";
                        if (!mail.SendOneMailByHTML())
                        {
                            Business.MallLog.Create(0, "Share", "TeamTool发送:提交的数据库的修改需求已执行成功~邮件失败", "发送失败", Request.UserHostAddress);
                        }
                        #endregion
                    }
                }
                else
                {
                    this.RedirectConfirm(Result + "database_alter_update.Update()失败！", this.P_BackUrl);
                }
                #endregion
            }
            else
            {
                this.RedirectConfirm("执行失败！不存在此记录！", this.P_BackUrl);
            }
        }

        private bool ExecuteSqlWithGoUseTran(string connectionString, string sql, out int RowCount, out string Error)
        {
            Error = "";
            RowCount = 0;
            bool bResult = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    //注： 此处以 换行_后面带0到多个空格_再后面是go 来分割字符串
                    String[] sqlArr = Regex.Split(sql.Trim(), "\r\n\\s*go", RegexOptions.IgnoreCase);
                    foreach (string strsql in sqlArr)
                    {
                        if (strsql.Trim().Length > 1 && strsql.Trim() != "\r\n")
                        {
                            cmd.CommandText = strsql;
                            int i = cmd.ExecuteNonQuery();
                            RowCount += i;
                        }
                    }
                    tx.Commit();
                    bResult = true;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    bResult = false;
                    RowCount = 0;
                    Error = E.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            return bResult;
        }

    }
}