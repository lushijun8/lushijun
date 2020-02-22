using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_List : Business.ManageWeb
    {
        public string P_OrderBy = "";
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "Article_id desc";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;
            Entity.TEAMTOOL.SHARE_ARTICLE share_article = new Entity.TEAMTOOL.SHARE_ARTICLE();
            share_article.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            share_article.SelectColumns = new string[] { "SHARE_ARTICLE.*", "WebManager_RealName" };
            share_article.ARTICLE_DELETED = 0;
            share_article.ARTICLE_TYPE = 1;
            share_article.Distinct = false;
            share_article.OrderBy = this.P_OrderBy;
            DataTable dt_share_article = share_article.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //==============================================================================
            Entity.TEAMTOOL.SHARE_ARTICLE_GOOD share_article_good = new Entity.TEAMTOOL.SHARE_ARTICLE_GOOD();
            share_article_good.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            share_article_good.SelectColumns = new string[] { share_article_good._ARTICLE_ID, "WebManager_RealName" };
            share_article_good.CacheTime = 60;
            share_article_good.OrderBy = share_article_good._CREATETIME + " ASC";
            DataTable dt_share_article_good = share_article_good.Select();

            dt_share_article.Columns.Add(new DataColumn("Article_good_WebManager_RealName", typeof(string)));
            foreach (DataRow oDr_share_article in dt_share_article.Rows)
            {
                string Article_good_WebManager_RealName = "";
                DataRow[] oDrs_share_article_good = dt_share_article_good.Select(share_article_good._ARTICLE_ID + "=" + oDr_share_article[share_article._ARTICLE_ID].ToString());
                if (oDrs_share_article_good != null && oDrs_share_article_good.Length > 0)
                {
                    foreach (DataRow oDr_dt_share_article_good in oDrs_share_article_good)
                    {

                        Article_good_WebManager_RealName += oDr_dt_share_article_good["WebManager_RealName"].ToString() + " , ";
                    }
                }
                oDr_share_article["Article_good_WebManager_RealName"] = Article_good_WebManager_RealName.TrimEnd(',');
            }
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Share/Share_Article_List.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_OrderBy);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================


            //this.LogCount = dt_share_article.Rows.Count;
            this.rptLog.DataSource = dt_share_article;
            this.rptLog.DataBind();
            #endregion

        }
    }
}
