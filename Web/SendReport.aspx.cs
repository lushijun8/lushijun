using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Web
{
    public partial class SendReport : Business.ManageWeb
    {
        private delegate void AsyncDelegate();
        private delegate void AsyncDelegate1(string url);
        protected void Page_Load(object sender, EventArgs e)
        {

            //每日群发报告邮件
            AsyncDelegate caller = new AsyncDelegate(SendReportEmail);
            caller.BeginInvoke(null, caller);

        }
        private void SendReportEmail()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday && (System.DateTime.Now.Hour == 11 || System.DateTime.Now.Hour == 12 || System.DateTime.Now.Hour == 13))
            {
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                //admin_webmanager.WEBMANAGER_NAME = "lushijun";
                admin_webmanager.WEBMANAGER_STATUS = 100;
                admin_webmanager.Select();
                while (admin_webmanager.Next())
                {
                    string body = Com.Net.UrlRequest.GetResponse(Business.Config.HostUrl + "/Manager/Welcome.aspx?WebManager_Name=" + Com.Common.EncDec.Encrypt(admin_webmanager.WEBMANAGER_NAME,this.Encrypt_key), null, 202000);
                    int menu_startindex = body.IndexOf("<!--删除开始-->");
                    int menu_endindex = body.IndexOf("<!--删除结束-->");
                    if (menu_startindex > -1 && menu_endindex > -1 && menu_endindex > menu_startindex)
                    {
                        string menubody = body.Substring(menu_startindex, menu_endindex - menu_startindex);
                        body = body.Replace(menubody, "<style type=\"text/css\">.Body_PageContent{margin-top:0px !important;}</style>");
                    }
                    string MailUserList = admin_webmanager.WEBMANAGER_NAME + "@fang.com";
                    //MailUserList =Com.Config.SystemConfig.MailUser;

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailUserList = MailUserList;
                    mail.MailTitle = admin_webmanager.WEBMANAGER_REALNAME+"的TeamTool监控周报[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                    mail.MailContent = body;
                    if (!mail.SendOneMailByHTML())
                    {
                        Business.MallLog.Create(0, "Web.Report", "TeamTool监控周报发送失败", "发送给" + admin_webmanager.WEBMANAGER_NAME + "失败", Request.UserHostAddress);
                    }
                }
            }
            if (System.DateTime.Now.Hour == 22 || System.DateTime.Now.Hour == 23)
            {
                //更新表结构说明
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.DATABASE_IS_MAIN = 1;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_ID };
                database_owner.Select();
                while (database_owner.Next())
                {
                    string url = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Owner_Description_Create.aspx?DataBase_Id=" + Com.Common.EncDec.Encrypt(database_owner.DATABASE_ID_ToString + "," + System.DateTime.Now.ToString(), this.Encrypt_key);
                    AsyncDelegate1 caller = new AsyncDelegate1(DataBase_Owner_Description_Create);
                    caller.BeginInvoke(url, null, caller);
                }
            }

        }
        private void DataBase_Owner_Description_Create(string url)
        {
            Com.Net.UrlRequest.GetResponse(url, "");
        }
    }
}