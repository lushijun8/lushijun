using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager
{
    public partial class logout : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           this.setCookies("CurrentWebManagerId", "",System.DateTime.Now.AddSeconds(2));
            //清楚权限的缓存
            Cache.Remove("GroupFunctionIds_" + this.CurrentWebManagerGroupId);
            Cache.Remove("GroupFunctionUrls_" + this.CurrentWebManagerGroupId);
            Cache.Remove("Manage_Index_Menu_" + this.CurrentWebManagerGroupId);
            Cache.Remove("ADMIN_WEBMANAGER_" + this.CurrentWebManagerId);
            Cache.Remove("ADMIN_FUNCTION_ALL");

            Response.Redirect(Business.Config.HostUrl + "/Manager/login.aspx");

        }
    }
}
