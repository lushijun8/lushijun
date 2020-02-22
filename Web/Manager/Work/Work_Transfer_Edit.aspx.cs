using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Work
{
    public partial class Work_Transfer_Edit : Business.ManageWeb
    {
        protected string P_Status = "";
        protected string P_ID = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Work/Work_Transfer_Edit.aspx");

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
                if (this.QueryString("Status") != "" && this.QueryString("ID") != "")
                {
                    this.P_Status = Com.Common.EncDec.Decrypt(this.QueryString("Status"), this.Encrypt_key);
                    this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("操作失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.WORK_TRANSFER work_transfer_select = new Entity.TEAMTOOL.WORK_TRANSFER();
            work_transfer_select.ID = int.Parse(this.P_ID);
            if (work_transfer_select.SelectTop1() != null)
            {
                #region 存在

                Entity.TEAMTOOL.WORK_TRANSFER work_transfer = new Entity.TEAMTOOL.WORK_TRANSFER();
                work_transfer.ID = int.Parse(this.P_ID);
                if (this.P_Status == "-1")//删除
                {
                    if (work_transfer.Delete() == true)
                    {
                        #region 发邮件
                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                        mail.MailUserList = work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "@fang.com";
                        mail.CopyToMailUserList = work_transfer_select.WORK_TO_WEBMANAGER_NAME + "@fang.com;lushijun@fang.com;" + this.CurrentWebManagerName + "@fang.com";
                        mail.MailTitle = this.CurrentWebManagerRealName + " 删除了工作交接~[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        mail.MailContent = "Hi!!<br/><br/>" +
                            "&nbsp;&nbsp;“" + this.CurrentWebManagerRealName + "”删除了TeamTool里的工作交接，请 <a href=\"" + Business.Config.HostUrl + "/Manager/Work/Work_Transfer_Add.aspx\" target=\"_blank\">点击这里查看！</a> ";
                        if (!mail.SendOneMailByHTML())
                        {
                            Business.MallLog.Create(0, "Share", "TeamTool发送:删除了工作交接~邮件失败", "发送给" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "失败", Request.UserHostAddress);
                        }
                        #endregion

                        this.RedirectConfirm("删除成功！", this.P_BackUrl);
                    }
                    else
                    {
                        this.RedirectConfirm("删除失败！", this.P_BackUrl);
                    }
                }
                else if (this.P_Status == "1")//已接收待执行
                {
                    work_transfer.STATUS = 1;
                    if (work_transfer.Update() == true)
                    {
                        #region 发邮件
                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                        mail.MailUserList = work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "@fang.com";
                        mail.CopyToMailUserList = work_transfer_select.WORK_TO_WEBMANAGER_NAME + "@fang.com;lushijun@fang.com";
                        mail.MailTitle = this.CurrentWebManagerRealName + " 接收了工作交接~[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        mail.MailContent = "Hi!!<br/><br/>" +
                            "&nbsp;&nbsp;“" + this.CurrentWebManagerRealName + "”接收了TeamTool里的工作交接，请 <a href=\"" + Business.Config.HostUrl + "/Manager/Work/Work_Transfer_Add.aspx\" target=\"_blank\">点击这里查看！</a> ";
                        if (!mail.SendOneMailByHTML())
                        {
                            Business.MallLog.Create(0, "Share", "TeamTool发送:收了工作交接~邮件失败", "发送给" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "失败", Request.UserHostAddress);
                        }
                        #endregion
                        this.RedirectConfirm("接收成功！", this.P_BackUrl);

                    }
                    else
                    {
                        this.RedirectConfirm("接收失败！", this.P_BackUrl);
                    }
                }
                else if (this.P_Status == "2")//执行
                {

                    string Sql = @"update WebSite_My_PageUrl set WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"' where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"' and pageurl NOT in (
                                select pageurl from WebSite_My_PageUrl where WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"'
                                )
                                delete from WebSite_My_PageUrl where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"'
                                --------------------------------------------------------------------------------------------------------------------
                                update DataBase_Table_My set WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"' where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"' and DataBase_Name+Table_Name NOT in (
                                select DataBase_Name+Table_Name from DataBase_Table_My where WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"'
                                )
                                delete from DataBase_Table_My where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"'
                                --------------------------------------------------------------------------------------------------------------------
                                update Job_My set WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"' where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"' and JobName NOT in (
                                select JobName from Job_My where WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"'
                                )
                                delete from Job_My where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"'
                                --------------------------------------------------------------------------------------------------------------------
                                update DataBase_Sql_My set WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"' where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"' and Sql_Md5 NOT in (
                                select Sql_Md5 from DataBase_Sql_My where WebManager_name='" + work_transfer_select.WORK_TO_WEBMANAGER_NAME + @"'
                                )
                                delete from DataBase_Sql_My where WebManager_name ='" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + @"'
                                --------------------------------------------------------------------------------------------------------------------";
                    int i = work_transfer.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);
                    work_transfer.STATUS = 2;
                    if (work_transfer.Update() == true)
                    {
                        #region 发邮件
                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                        mail.MailUserList = work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "@fang.com";
                        mail.CopyToMailUserList = work_transfer_select.WORK_TO_WEBMANAGER_NAME + "@fang.com;" + this.CurrentWebManagerName + "@fang.com";
                        mail.MailTitle = work_transfer_select.WORK_FROM_WEBMANAGER_REALNAME + "交接给" + work_transfer_select.WORK_TO_WEBMANAGER_REALNAME + "的工作执行完成~[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        mail.MailContent = "Hi!!<br/><br/>" +
                            "&nbsp;&nbsp;“" + work_transfer_select.WORK_FROM_WEBMANAGER_REALNAME + "”交接给“" + work_transfer_select.WORK_TO_WEBMANAGER_REALNAME + "”的工作执行完成，请 <a href=\"" + Business.Config.HostUrl + "/Manager/Work/Work_Transfer_Add.aspx\" target=\"_blank\">点击这里查看！</a> ";
                        if (!mail.SendOneMailByHTML())
                        {
                            Business.MallLog.Create(0, "Share", "TeamTool发送:交接的工作执行完成~邮件失败", "发送给" + work_transfer_select.WORK_FROM_WEBMANAGER_NAME + "失败", Request.UserHostAddress);
                        }
                        #endregion
                        this.RedirectConfirm("接收成功！", this.P_BackUrl);
                    }
                    else
                    {
                        this.RedirectConfirm("接收失败！", this.P_BackUrl);
                    }
                }
                #endregion
            }
            else
            {
                this.RedirectConfirm("操作失败！不存在此记录！", this.P_BackUrl);
            }
        }
    }
}