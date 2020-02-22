using System;
using CDO;
using ADODB;
using Com.File;
using System.Net.Mail;

namespace Com.Mail
{
    /// <summary>
    /// SendMail 的摘要说明。
    /// </summary>
    public class SendMail
    {
        public SendMail()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="MailUserList">接收邮箱列表用逗号隔开</param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSimpleMail(string MailUserList, string title, string message)
        {
            if (string.IsNullOrEmpty(MailUserList))
            {
                return false;
            }
            bool flag1 = false;
            try
            {
                SmtpClient client = new SmtpClient("mail.fang.com");
                MailMessage mail = new MailMessage("noname.js@fang.com", MailUserList);
                mail.From = new MailAddress("noname.js@fang.com", "TeamTool");//加上自定义的发件人显示名称
                mail.Subject = title;
                mail.Body = message;
                //mail.IsBodyHtml = true;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("[登录名]", "[密码]");//如果是匿名发送则不需要这一句
                client.Send(mail);
                flag1 = true;
            }
            catch (Exception exception1)
            {
                FileLog.WriteLog("发送邮件错误", exception1.Message);
                flag1 = false;
            }
            return flag1;

        }

        public static bool SendOneMail(string sSmtpServer, string sUserName, string sPassword, string sFrom, string sTo, string sCCTo, string sBCCTo, string sSubject, string sContent, string[] sAttachmentUrlArray)
        {
            bool flag1 = false;
            Message message1 = new MessageClass();

            message1.From = (sFrom);
            message1.To = sTo;
            message1.CC = sCCTo;
            message1.BCC = sBCCTo;
            message1.Subject = sSubject;
            message1.TextBody = sContent;
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


    }
}
