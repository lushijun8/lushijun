using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_Ranking : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_Ranking.aspx");
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl.SelectColumns = new string[] { website_my_pageurl.TableName + ".WebManager_name", "WebManager_Realname", "count(1) as counts" };
            website_my_pageurl.GroupBy = website_my_pageurl.TableName + ".WebManager_name,WebManager_Realname";
            website_my_pageurl.OrderBy = "counts desc";
            website_my_pageurl.CacheTime = 1440;
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            this.rptLog.DataSource = oDt_website_my_pageurl;
            this.rptLog.DataBind();
            #endregion
        }
    }
}
