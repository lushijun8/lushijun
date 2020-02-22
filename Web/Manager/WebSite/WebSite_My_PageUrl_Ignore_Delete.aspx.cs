using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_Ignore_Delete : Business.ManageWeb
    {
        protected string P_PageUrl = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_Ignore_Delete.aspx");

            if (!Page.IsPostBack)
            {
                this.P_BackUrl = this.QueryString("BackUrl");
                if (string.IsNullOrEmpty(this.P_BackUrl))
                {
                    if (Request.UrlReferrer != null)
                    {
                        this.P_BackUrl = Request.UrlReferrer.ToString();
                    }
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                    }
                }
                if (this.QueryString("PageUrl") != "")
                {
                    this.P_PageUrl = Com.Common.EncDec.Decrypt(this.QueryString("PageUrl"), this.Encrypt_key);
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("删除失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
            website_my_pageurl_ignore.WEBMANAGER_NAME = this.CurrentWebManagerName;
            website_my_pageurl_ignore.PAGEURL = this.P_PageUrl;

            if (website_my_pageurl_ignore.Delete() == true)
            {
                this.RedirectConfirm("删除成功！", this.P_BackUrl);
                #region 更新表WebSite_PageUrl
                Business.PageUrlAnalysis.Match(this.P_PageUrl);
                #endregion
            }
            else
            {
                this.RedirectConfirm("删除失败,可能您已删除此连接！", this.P_BackUrl);

            }
        }
    }
}