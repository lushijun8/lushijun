using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_SendEamil : Business.ManageWeb
    {
        public string Article_Text = "";
        public string WebManagerName = "";
        public string Article_Title = "";
        private int P_Article_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_SendEamil.aspx");
            if (!string.IsNullOrEmpty(this.QueryString("Article_Id")))
            {
                this.P_Article_Id = int.Parse(Com.Common.EncDec.Decrypt(this.QueryString("Article_Id"), this.Encrypt_key));
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.SHARE_ARTICLE share_article = new Entity.TEAMTOOL.SHARE_ARTICLE();
            share_article.ARTICLE_ID = this.P_Article_Id;
            //share_article.CacheTime = 2880;
            if (share_article.SelectTop1() != null)
            {   //发邮件
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_STATUS = 100;
                admin_webmanager.Select();
                string MailUserList = "";
                while (admin_webmanager.Next())
                {
                    MailUserList += admin_webmanager.WEBMANAGER_NAME + "@fang.com,";
                }
                //MailUserList = "lushijun@fang.com,sogogo1@126.com";
                if (!string.IsNullOrEmpty(MailUserList))
                {
                    string Image_PageUrl = Business.Config.HostUrl + "/Manager/Share/Share_Article_View_1.aspx?Article_Id=" + this.QueryString("Article_Id");
                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailUserList = MailUserList.TrimEnd(',');
                    mail.MailTitle = this.CurrentWebManagerRealName + " 转发" + share_article.ARTICLE_SHARE_WEBMANAGER_NAME + "分享的：" + share_article.ARTICLE_TITLE;
                    mail.MailContent =
                        "<p><b>如果你觉得 " + share_article.ARTICLE_SHARE_WEBMANAGER_NAME + " 分享的内容很棒，立刻给TA <a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_Good.aspx?Article_Id=" + int.Parse(share_article.ARTICLE_ID_ToString) + "\">点赞</a> 吧！</b><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View.aspx?Article_Id=" + Com.Common.EncDec.Encrypt(share_article.ARTICLE_ID_ToString, this.Encrypt_key) + "\">查看原文</a></p>" +
                        "<img src=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View_Image.aspx?pageurl=" + Com.Common.EncDec.Encrypt(Image_PageUrl, this.Encrypt_key) + "\" width=\"860\"/>" +
                        "<p><b>如果你觉得 " + share_article.ARTICLE_SHARE_WEBMANAGER_NAME + " 分享的内容很棒，立刻给TA <a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_Good.aspx?Article_Id=" + int.Parse(share_article.ARTICLE_ID_ToString) + "\">点赞</a> 吧！</b><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View.aspx?Article_Id=" + Com.Common.EncDec.Encrypt(share_article.ARTICLE_ID_ToString, this.Encrypt_key) + "\">查看原文</a></p>";
                    if (!mail.SendOneMailByHTML())
                    {
                        Business.MallLog.Create(0, "Web.Report", share_article.ARTICLE_SHARE_WEBMANAGER_NAME + "在TeamTool分享文章失败", "发送给" + MailUserList + "失败", Request.UserHostAddress);
                        this.RedirectConfirm("再分享发邮件失败！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                    }
                    else
                    {
                        this.RedirectConfirm("分享成功！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                        //随机给奖品
                    }
                }

            }
        }
    }
}