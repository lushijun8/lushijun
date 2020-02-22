using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web.UI;
using CDO;
using ADODB;
using Com.Config;
using Com.File;

namespace Com.Mail
{
    /// <summary>
    /// MailUtil 的摘要说明。
    /// </summary>
    public class MailUtil
    {
        /// <summary>
        /// 附件
        /// </summary>
        public string[] AttachArray;
        /// <summary>
        /// 内容
        /// </summary>
        public string MailContent;
        /// <summary>
        /// 标题
        /// </summary>
        public string MailTitle;
        /// <summary>
        /// 发送邮件地址，多个用“;”隔开
        /// </summary>
        public string MailUserList;
        /// <summary>
        /// 抄送邮件地址，多个用“;”隔开
        /// </summary>
        public string CopyToMailUserList;

        private string MailUserName;
        private string MailPassWord;
        private string MailServerIP;
        private string EMail;

        public MailUtil()
        {
            this.MailUserList = "";
            this.CopyToMailUserList = "";
            this.MailTitle = "";
            this.MailContent = "";
            this.AttachArray = new string[0];
            this.MailServerIP = SystemConfig.MailServer;
            this.MailUserName = SystemConfig.MailUser;
            this.MailPassWord = SystemConfig.MailPassWord;
            this.EMail = SystemConfig.MailAddess;
        }

        private bool SendMailByCDO(string sSmtpServer, string sUserName, string sPassword, string sFrom, string sTo, string sCCTo, string sBCCTo, string sSubject, string sContent, string[] sAttachmentUrlArray, string MailFormat)
        {
            bool flag1 = false;
            Message message1 = new MessageClass();
            message1.From = (sFrom);
            message1.To = sTo;
            message1.CC = sCCTo;
            message1.BCC = sBCCTo;
            message1.Subject = sSubject;
            if (MailFormat.ToUpper() == "HTML")
            {
                message1.HTMLBody = sContent;
            }
            else
            {
                message1.TextBody = sContent;
            }
            try
            {
                if (sAttachmentUrlArray.Length > 0)
                {
                    for (int num1 = 0; num1 < sAttachmentUrlArray.Length; num1++)
                    {
                        message1.AddAttachment(sAttachmentUrlArray[num1], sUserName, sPassword);
                    }
                }
                IConfiguration configuration1 = message1.Configuration;
                Fields fields1 = configuration1.Fields;
                fields1["http://schemas.microsoft.com/cdo/configuration/sendusing"].Value = (2);
                fields1["http://schemas.microsoft.com/cdo/configuration/sendemailaddress"].Value = (sFrom);
                fields1["http://schemas.microsoft.com/cdo/configuration/smtpuserreplyemailaddress"].Value = (sFrom);
                fields1["http://schemas.microsoft.com/cdo/configuration/smtpaccountname"].Value = (sUserName);
                fields1["http://schemas.microsoft.com/cdo/configuration/sendusername"].Value = (sUserName);
                fields1["http://schemas.microsoft.com/cdo/configuration/sendpassword"].Value = (sPassword);
                fields1["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"].Value = (1);
                fields1["http://schemas.microsoft.com/cdo/configuration/smtpserver"].Value = (sSmtpServer);
                fields1.Update();
                message1.Send();
                message1 = null;
                flag1 = true;
            }
            catch (Exception exception1)
            {
                FileLog.WriteLog("\u90ae\u4ef6\u53d1\u9001\u5931\u8d25", exception1.Message);
                flag1 = false;
            }
            return flag1;
        }

        public bool SendOneMail()
        {
            return this.SendMailByCDO(this.MailServerIP, this.MailUserName, this.MailPassWord, this.EMail, this.MailUserList, this.CopyToMailUserList, "", this.MailTitle, this.MailContent, this.AttachArray, "Text");
        }

        public bool SendOneMailByHTML()
        {
            return this.SendMailByCDO(this.MailServerIP, this.MailUserName, this.MailPassWord, this.EMail, this.MailUserList, this.CopyToMailUserList, "", this.MailTitle, this.MailContent, this.AttachArray, "HTML");
        }

        public bool SendOnePageFromURL(string SendURL)
        {
            this.MailContent = Net.NetUtil.GetWebResponse(SendURL);
            return this.SendOneMailByHTML();
        }


    }
}
