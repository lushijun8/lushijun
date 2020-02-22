using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class DeleteUser : Business.ManageWeb
    {
        int P_WebManager_id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/DeleteUser.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("wid") != "")
                {
                    this.P_WebManager_id = int.Parse(Com.Common.EncDec.Base64Decrypt(QueryString("wid")));
                }
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_ID = this.P_WebManager_id;
                if (admin_webmanager.Delete())
                {
                    this.RedirectConfirm("删除成功！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                else
                {
                    this.RedirectConfirm("删除失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                } 
            }

        }
    }
}