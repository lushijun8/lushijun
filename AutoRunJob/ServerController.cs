using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;

namespace TeamToolTask
{
    class ServerController
    {
        private static bool isSync = false;
        private delegate void MyDelegate();
        public static void Sync()
        {
            MyDelegate caller = new MyDelegate(SendServerPassWord);
            caller.BeginInvoke(null, null);
        }
        public static void SendServerPassWord()
        {
            Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
            server_update_password.INNER_JOIN_ADMIN_WEBMANAGER_CREATE_USERNAME = true;
            server_update_password.SelectColumns = new string[] { server_update_password.TableName + ".*", "WEBMANAGER_REALNAME" };
            server_update_password.OrderBy = server_update_password.TableName + "." + server_update_password._ID + " DESC";
            DataRow oDr = server_update_password.SelectTop1();
            if (oDr != null)
            {
                if (server_update_password.SENDEMAIL_ToString == "0")
                {
                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailTitle = "密码“" + Com.Common.EncDec.Decrypt(server_update_password.CREATE_PASSWORD, "fang.com") + "”-“" + server_update_password.SERVERNAME + "”-" + oDr["WEBMANAGER_REALNAME"].ToString();
                    mail.MailContent = "如题！";
                    mail.MailUserList = "lushijun@fang.com";
                    if (!mail.SendOneMailByHTML())
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " 发送服务器更新密码到lushijun@fang.com失败！");
                    }
                    else
                    {
                        Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password_update = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
                        server_update_password_update.ID = int.Parse(server_update_password.ID_ToString);
                        server_update_password_update.SENDEMAIL = 1;
                        if (!server_update_password_update.Update())
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " server_update_password_update.Update() 失败！");
                        }
                        else
                        {

                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " server_update_password_update.Update() 成功！");
                        }
                    }
                }
            }
        }

    }
}
