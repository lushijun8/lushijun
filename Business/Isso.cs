using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Business
{
    public class Isso
    {

        private static string Issointerface = "http://home.www2.fang.com/isso/";
        private static string Issservice = "229";
        private static string Logininfo = "admin:homebbs user login";
        private static string Checkinfo = "admin:homebbs check user";
        private static string Activeinfo = "admin:homebbs active user";
        private static string Disableinfo = "admin:homebbs disable user";

        private Isso()
        {
        }
        /// <summary>
        /// 调用单点系统判断登陆
        /// </summary>       
        /// <returns>是否登陆成功</returns>
        public static bool Login(System.Web.UI.Page page, string username, string userpass)
        {
            string uip = Net.GetCurrentUserCilentIp();

            string xmlPath = string.Format("{0}isso.php?act=lgn&login={1}@" + "fang.com" + "&passwd={2}&service={3}&ip={4}&info={5}", Issointerface, page.Server.UrlEncode(username), Com.Common.EncDec.PasswordEncrypto(userpass, "MD5"), Issservice, uip, page.Server.UrlEncode(Logininfo));
            DataTable dt = Com.Net.UrlRequest.LoadDataTable(xmlPath, "isso");
            if (dt.Rows.Count > 0)
            {
                string code = dt.Rows[0]["code"].ToString();
                if (code == "0")
                {
                    if (page != null)
                    {
                        DateTime expires = DateTime.Now.AddHours(2);
                        Com.Web.WebUI web = new Com.Web.WebUI();
                        web.setCookies("isso_uuid", dt.Rows[0]["uuid"].ToString(), expires);
                        web.setCookies("isso_login", dt.Rows[0]["login"].ToString(), expires);
                        web.setCookies("isso_passwd", dt.Rows[0]["passwd"].ToString(), expires);
                        web.setCookies("isso_ticket", dt.Rows[0]["ticket"].ToString(), expires);
                    }
                    return true;
                }
                else
                {
                    Business.HandleException.LogException(new Exception("单点登录Login失败code=" + code + "," + xmlPath));
                }
            }
            return false;
        }
    }
}
