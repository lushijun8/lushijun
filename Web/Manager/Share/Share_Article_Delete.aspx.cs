using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_Delete : Business.ManageWeb
    {
        public string Article_Text = "";
        public string WebManagerName = "";
        public string Article_Title = "";
        private int P_Article_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_Delete.aspx");
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
            share_article.ARTICLE_DELETED = 1;
            if (share_article.Update() == true)
            {
                this.RedirectConfirm("删除成功！", Business.Config.HostUrl + "/Manager/Share/Share_Article_List_My.aspx");
            }
            else
            {
                this.RedirectConfirm("删除失败！", Business.Config.HostUrl + "/Manager/Share/Share_Article_List_My.aspx");
            }
        }
    }
}