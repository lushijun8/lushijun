using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class UpdateUserStatus : Business.ManageWeb
    {
        int P_WebManager_id = -1;
        int P_WebManager_Status = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AdminCheck("Manager/Admin/DeleteUser.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("v") != "")
                {
                    string[] Params = Com.Common.EncDec.Base64Decrypt(QueryString("v")).Split(',');
                    this.P_WebManager_id = int.Parse(Params[0]);
                    this.P_WebManager_Status = int.Parse(Params[1]);
                    if(Params[2]!=System.DateTime.Now.ToString("yyyyMMdd"))
                    {
                        this.RedirectConfirm("更新失败！此链接已经过期", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                    }
                } 
                if (this.P_WebManager_id == -1 || this.P_WebManager_Status == -1)
                {
                    this.RedirectConfirm("更新失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                string Password = Com.Common.RandomUtil.GetRandomCode(8);
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_update = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager_update.WEBMANAGER_ID = this.P_WebManager_id;
                admin_webmanager_update.WEBMANAGER_STATUS = this.P_WebManager_Status;
                admin_webmanager_update.WEBMANAGER_PASSWORD = Com.Common.EncDec.PasswordEncrypto(Password);
                if (admin_webmanager_update.Update())
                {
                    this.RedirectConfirm("更新成功！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                    if (this.P_WebManager_Status == 100)//下发邮件
                    {
                        Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_select = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                        admin_webmanager_select.WEBMANAGER_ID = this.P_WebManager_id;
                        if (admin_webmanager_select.SelectTop1() != null)
                        {
                            //bool bSuccess = Business.SMS.Send(admin_webmanager_select.WEBMANAGER_MOBILE, "后台地址：" + Business.Config.HostUrl + "/Manager/Login.aspx ,用户名：" + admin_webmanager_select.WEBMANAGER_NAME + ",密码：" + Password, true);

                            string body = "用户名：" + admin_webmanager_select.WEBMANAGER_NAME + ",密码：" + Password + ";请登录后台及时修改临时密码 " + Business.Config.HostUrl + "/Manager/Login.aspx , 如果已经登录成功请忽略此邮件";
                            Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                            mail.MailUserList = admin_webmanager_select.WEBMANAGER_EMAIL;
                            mail.MailTitle =  "恭喜您成功开通" + this.CurrentWebTitle + "权限";
                            mail.MailContent = body;
                            bool bSuccess = mail.SendOneMailByHTML();                             
                        }
                    }
                }
                else
                {
                    this.RedirectConfirm("更新失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
            }

        }
    }
}