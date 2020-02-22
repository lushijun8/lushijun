using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class Update_Recieve_AlertEmail : Business.ManageWeb
    {
        int P_WebManager_id = -1;
        int P_WebManager_Recieve_AlertEmail = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AdminCheck("Manager/Admin/DeleteUser.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("v") != "")
                {
                    string[] Params = Com.Common.EncDec.Base64Decrypt(QueryString("v")).Split(',');
                    this.P_WebManager_id = int.Parse(Params[0]);
                    this.P_WebManager_Recieve_AlertEmail = int.Parse(Params[1]);
                    if (Params[2] != System.DateTime.Now.ToString("yyyyMMdd"))
                    {
                        this.RedirectConfirm("更新失败！此链接已经过期", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                    }
                }
                if (this.P_WebManager_id == -1 || this.P_WebManager_Recieve_AlertEmail == -1)
                {
                    this.RedirectConfirm("更新失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_ID = this.P_WebManager_id;
                admin_webmanager.WEBMANAGER_RECIEVE_ALERTEMAIL = this.P_WebManager_Recieve_AlertEmail;
                if (admin_webmanager.Update())
                {
                    this.RedirectConfirm("更新成功！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                else
                {
                    this.RedirectConfirm("更新失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
            }

        }
    }
}