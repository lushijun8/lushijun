using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
             
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_manager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            //admin_manager.WEBMANAGER_IP = Request.UserHostAddress;
            //admin_manager.SelectTop1();
            //Business.MallLog.Create(0, "BeginRequest", admin_manager.WEBMANAGER_NAME, "‰Ø¿¿:" + Request.Url.AbsoluteUri, Request.UserHostAddress);
        }
        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    //Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(300);
        //}
    }
}