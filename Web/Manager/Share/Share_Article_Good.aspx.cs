using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_Good : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_Good.aspx");
            if (!Page.IsPostBack)
            {
                string P_Article_Id = this.QueryString("Article_Id");
                if (!string.IsNullOrEmpty(P_Article_Id))
                {
                    Entity.TEAMTOOL.SHARE_ARTICLE_GOOD share_article = new Entity.TEAMTOOL.SHARE_ARTICLE_GOOD();
                    share_article.ARTICLE_ID = int.Parse(P_Article_Id);
                    share_article.WEBMANAGER_NAME = this.CurrentWebManagerName;
                    share_article.CREATETIME = DateTime.Now;
                    share_article.Insert();
                }
            }
            this.RedirectConfirm("点赞成功！", Business.Config.HostUrl + "/Manager/Share/Share_Article_List.aspx");
        }
    }
}