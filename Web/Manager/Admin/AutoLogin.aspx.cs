using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class AutoLogin : Business.ManageWeb
    {
        DateTime ExpireTime = DateTime.Now.AddMinutes(20);
        int WebManager_id = -1;
        string P_v = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AdminCheck("Manager/Admin/AutoLogin.aspx");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(QueryString("v")))
                {
                    this.P_v = Com.Common.EncDec.Base64Decrypt(this.QueryString("v"));
                    string[] vs = this.P_v.Split(',');
                    this.WebManager_id = int.Parse(vs[0]);
                    if (vs.Length >= 2)
                    {
                        this.ExpireTime = DateTime.Parse(vs[1]);
                    }
                }
                if (DateTime.Compare(this.ExpireTime, System.DateTime.Now) < 0) //判断日期大小
                {

                    this.setCookies("CurrentWebManagerId", "", System.DateTime.Now.AddSeconds(-1));
                    //清楚权限的缓存
                    Cache.Remove("GroupFunctionIds_" + this.CurrentWebManagerGroupId);
                    Cache.Remove("GroupFunctionUrls_" + this.CurrentWebManagerGroupId);
                    Cache.Remove("Manage_Index_Menu_" + this.CurrentWebManagerGroupId);
                    Cache.Remove("ADMIN_WEBMANAGER_" + this.CurrentWebManagerId);
                    Cache.Remove("ADMIN_FUNCTION_ALL");

                    this.RedirectConfirm("连接已失效！", Business.Config.HostUrl + "/Manager/Login.aspx");
                    return;
                }
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_ID = this.WebManager_id;
                DataRow oDr = admin_webmanager.SelectTop1();
                if (oDr == null)
                {
                    this.RedirectConfirm("不存在此用户！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                else
                {
                    string strError = "";
                    if (CheckIn(admin_webmanager.WEBMANAGER_NAME, out strError) == true)
                    {
                        this.RedirectConfirm("登录成功！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                    }
                    else
                    {
                        this.RedirectConfirm("登录失败！", Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                    }
                }
            }

        }
    }
}