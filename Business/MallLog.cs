using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Business
{
    public class ServiceType
    {

    };

    public class MallLog
    {
        private static DataTable oDtService = null;
        private static DataTable oDtEmailControl = null;

        private static string thisyear = System.DateTime.Now.Year.ToString().Substring(2, 2);
        private static string lastyear = (System.DateTime.Now.Year - 1).ToString().Substring(2, 2);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="userType"> 用户类型，1商城管理员，2商城的商家，3商城的注册网友</param>
        /// <param name="userID">如果是1商城管理员，则保存为管理员ID MallManagerID
        ///						 如果是2商家用户，则保存为商家ID MallDealers.MallDealerID
        ///						 如果是3注册网友，则保存为网友的用户名MallUsers.MallUserID</param>
        /// <param name="userName">如果是1商城管理员，则保存为管理员用户名MallManagerName
        ///						   如果是2商家用户，则保存为商家用户名MallDealers.UserName（即商家的通行证用户名）
        ///						   如果是注册网友，则保存为网友的用户名MallUsers.UserName（即网友的通行证用户名）</param>
        /// <param name="realName"> 如果是1商城管理员，则保存为管理员的真实姓名RealName
        ///					        如果是2商家用户，则保存为商家名称MallDealers.DealerName
        ///                         如果是注册网友，则保存为网友的真实姓名MallUsers.RealName</param>
        /// <param name="product">-1：不分产品；6：家居商城 7：租房团 8：生活团购9：新房购房订金</param>	
        /// <param name="itemID">数据ID，管理员的MallManagerID，
        ///						 商家的MallDealerID，网友的MallUserID，卖场的MallMarketID，
        ///						 产品目录的MallCatalogID，报价产品的MallCatalogProductID，订单的OrderID，其它不重要的数据可以记录对方的ID或为0。</param>
        /// <param name="description">备注</param>
        /// <param name="ip">用户的IP</param>
        /// <returns></returns>
        public static bool Create(int Product, string ServiceName, string Title, string Description, string IP)
        {
            int logid = -1;
            return Create(Product, ServiceName, Title, Description, IP, out logid);
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="Product"></param>
        /// <param name="Title">标题</param>
        /// <param name="description">具体描述</param>
        /// <param name="ip">用户的IP</param>
        /// <param name="ip">数据库记录日志的id</param>
        /// <returns></returns>
        public static bool Create(int Product, string ServiceName, string Title, string Description, string IP, out int logid)
        {
            string Service ="";
            string url = "";
            string viewpage = "";
            logid = -1;
            try
            {
                System.Web.HttpContext http = System.Web.HttpContext.Current;
                if (http.Request != null)
                {
                    string hosturl = Config.HostUrl.ToLower().Replace("soufun", "*").Replace("http://pay", "http://***");
                    #region 拼接URL
                    url = "\r\n;<br>WebSite:" + hosturl;
                    if (http.Request.RawUrl != null)
                    {
                        url += "\r\n;<br>RawUrl:" + http.Request.RawUrl.ToString();
                    }
                    if (http.Request.Form != null)
                    {
                        url += "\r\n;<br>Request.Form:" + System.Web.HttpUtility.UrlDecode(http.Request.Form.ToString());
                    }
                    if (http.Request.QueryString != null)
                    {
                        url += "\r\n;<br>Request.QueryString:" + System.Web.HttpUtility.UrlDecode(http.Request.QueryString.ToString());
                    }
                    if (http.Request.UrlReferrer != null)
                    {
                        url += "\r\n;<br>UrlReferrer:" + http.Request.UrlReferrer.ToString().ToLower().Replace("soufun", "*").Replace("http://pay", "http://***");
                    }
                    url += "\r\n;<br>HTTP_X_FORWARDED_FOR:" + http.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    url += "\r\n;<br>REMOTE_ADDR:" + http.Request.ServerVariables["REMOTE_ADDR"];
                    #endregion

                }
            }
            catch { }
            bool result = false;

            string MailUserList = "lushijun@fang.com";
            try
            {
                Entity.TEAMTOOL.ADMIN_LOG pay_log = new Entity.TEAMTOOL.ADMIN_LOG();
                pay_log.USERTYPE = 0;
                pay_log.USERID = 0;
                pay_log.USERNAME = Title;
                pay_log.REALNAME = MailUserList;
                pay_log.ITEMTYPE = 0;
                pay_log.ITEMID = 0;
                pay_log.DESCRIPTION = Com.Common.StringUtil.GetLenContent(Description + url + viewpage, 4000);
                pay_log.IP = IP;
                pay_log.ADDEDTIME = System.DateTime.Now;
                if (pay_log.Insert())
                {
                    logid = int.Parse(pay_log.MALLLOGID_ToString);
                    result = true;
                }
                //Com.File.FileLog.WriteLog("", Description + url + viewpage);
            }
            catch { }
            //发邮件通知
            try
            { 
                if (oDtEmailControl == null)
                {
                    oDtEmailControl = new DataTable("EmailControl");
                    oDtEmailControl.Columns.Add("Title", typeof(string));
                    oDtEmailControl.Columns.Add("SendTime", typeof(DateTime));
                    oDtEmailControl.AcceptChanges();
                }
                else if (oDtEmailControl.Rows.Count >= 200)//多于200条的时候清空重新来
                {
                    oDtEmailControl.Rows.Clear();
                    oDtEmailControl.AcceptChanges();
                }
                DataRow[] oDrs = oDtEmailControl.Select("Title='" + Title.Replace("'", "") + "'");
                if (oDrs != null && oDrs.Length > 0)
                {

                    DateTime SendTime = (DateTime)oDrs[0]["SendTime"];
                    if (SendTime.AddMinutes(6) < DateTime.Now)//如果该标题发送时间超过6分钟
                    {
                        string body =Description + url + viewpage;
                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                        mail.MailUserList = MailUserList;
                        mail.MailTitle = Title;
                        mail.MailContent = body;
                        //bool bSuccess = mail.SendOneMailByHTML(); 

                        oDrs[0]["SendTime"] = DateTime.Now;
                        oDrs[0].AcceptChanges();
                    }

                }
                else//没发过该标题的邮件
                {
                    string body = Description + url + viewpage;
                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailUserList = MailUserList;
                    mail.MailTitle = Title;
                    mail.MailContent = body;
                    //bool bSuccess = mail.SendOneMailByHTML(); 
                     
                    DataRow oDr = oDtEmailControl.NewRow();
                    oDr["Title"] = Title.Replace("'", "");
                    oDr["SendTime"] = DateTime.Now;
                    oDtEmailControl.Rows.Add(oDr);
                    oDtEmailControl.AcceptChanges();
                }

            }
            catch { }
            return result;
        }
    }
}
