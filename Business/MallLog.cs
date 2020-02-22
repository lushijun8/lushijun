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
        /// ��¼��־
        /// </summary>
        /// <param name="userType"> �û����ͣ�1�̳ǹ���Ա��2�̳ǵ��̼ң�3�̳ǵ�ע������</param>
        /// <param name="userID">�����1�̳ǹ���Ա���򱣴�Ϊ����ԱID MallManagerID
        ///						 �����2�̼��û����򱣴�Ϊ�̼�ID MallDealers.MallDealerID
        ///						 �����3ע�����ѣ��򱣴�Ϊ���ѵ��û���MallUsers.MallUserID</param>
        /// <param name="userName">�����1�̳ǹ���Ա���򱣴�Ϊ����Ա�û���MallManagerName
        ///						   �����2�̼��û����򱣴�Ϊ�̼��û���MallDealers.UserName�����̼ҵ�ͨ��֤�û�����
        ///						   �����ע�����ѣ��򱣴�Ϊ���ѵ��û���MallUsers.UserName�������ѵ�ͨ��֤�û�����</param>
        /// <param name="realName"> �����1�̳ǹ���Ա���򱣴�Ϊ����Ա����ʵ����RealName
        ///					        �����2�̼��û����򱣴�Ϊ�̼�����MallDealers.DealerName
        ///                         �����ע�����ѣ��򱣴�Ϊ���ѵ���ʵ����MallUsers.RealName</param>
        /// <param name="product">-1�����ֲ�Ʒ��6���Ҿ��̳� 7���ⷿ�� 8�������Ź�9���·���������</param>	
        /// <param name="itemID">����ID������Ա��MallManagerID��
        ///						 �̼ҵ�MallDealerID�����ѵ�MallUserID��������MallMarketID��
        ///						 ��ƷĿ¼��MallCatalogID�����۲�Ʒ��MallCatalogProductID��������OrderID����������Ҫ�����ݿ��Լ�¼�Է���ID��Ϊ0��</param>
        /// <param name="description">��ע</param>
        /// <param name="ip">�û���IP</param>
        /// <returns></returns>
        public static bool Create(int Product, string ServiceName, string Title, string Description, string IP)
        {
            int logid = -1;
            return Create(Product, ServiceName, Title, Description, IP, out logid);
        }
        /// <summary>
        /// ��¼��־
        /// </summary>
        /// <param name="Product"></param>
        /// <param name="Title">����</param>
        /// <param name="description">��������</param>
        /// <param name="ip">�û���IP</param>
        /// <param name="ip">���ݿ��¼��־��id</param>
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
                    #region ƴ��URL
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
            //���ʼ�֪ͨ
            try
            { 
                if (oDtEmailControl == null)
                {
                    oDtEmailControl = new DataTable("EmailControl");
                    oDtEmailControl.Columns.Add("Title", typeof(string));
                    oDtEmailControl.Columns.Add("SendTime", typeof(DateTime));
                    oDtEmailControl.AcceptChanges();
                }
                else if (oDtEmailControl.Rows.Count >= 200)//����200����ʱ�����������
                {
                    oDtEmailControl.Rows.Clear();
                    oDtEmailControl.AcceptChanges();
                }
                DataRow[] oDrs = oDtEmailControl.Select("Title='" + Title.Replace("'", "") + "'");
                if (oDrs != null && oDrs.Length > 0)
                {

                    DateTime SendTime = (DateTime)oDrs[0]["SendTime"];
                    if (SendTime.AddMinutes(6) < DateTime.Now)//����ñ��ⷢ��ʱ�䳬��6����
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
                else//û�����ñ�����ʼ�
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
