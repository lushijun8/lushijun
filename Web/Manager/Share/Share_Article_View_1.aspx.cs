using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_View_1 : Business.ManageWeb
    {
        public string Article_Text = ""; 
        public string Article_Title = "";
        private int P_Article_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AdminCheck("Manager/Share/Share_Article_View.aspx");
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
            share_article.SelectTop1();
            this.Article_Title = share_article.ARTICLE_TITLE;
            this.Article_Text = share_article.ARTICLE_TEXT; 
        }
    }
}