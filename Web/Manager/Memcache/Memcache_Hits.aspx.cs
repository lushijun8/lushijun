using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Memcache
{
    public partial class Memcache_Hits : Business.ManageWeb
    {
        public string P_Today = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        public int _PageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Memcache/Memcache_Hits.aspx");
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "CREATETIME";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }

                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;

            Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits = new Entity.TEAMTOOL.MEMCACHE_HITS();
            string wheresql = " 1=1 ";//
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                wheresql += " AND (" +
                    memcache_hits.TableName+"."+memcache_hits._PAGEURL + " like '%" + this.txtKeyword.Text + "%' OR " +
                    memcache_hits._FUNCTIONNAME + " like '%" + this.txtKeyword.Text + "%' OR  "+
                    "WebManager_Name like '%" + this.txtKeyword.Text + "%') ";

                memcache_hits.LEFT_JOIN_WEBSITE_MY_PAGEURL = true;

            }
            memcache_hits.WhereSql = wheresql;
            memcache_hits.STATS_DATE = DateTime.Parse(this.P_Today);
            memcache_hits.OrderBy = memcache_hits.TableName + "." + this.P_orderby + " DESC";
            memcache_hits.INNER_JOIN_MEMCACHE_SERVER = true;
            memcache_hits.SelectColumns = new string[] { memcache_hits.TableName + ".*", "Status" };
            DataTable dtLog = memcache_hits.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

            //--------------------------------------------------------- 
            dtLog.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            dtLog.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dtLog.Columns.Add(new DataColumn("IsMy", typeof(int)));

            foreach (DataRow oDr_PageUrl in dtLog.Rows)
            {

                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_PageUrl[website_my_pageurl_all._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_PageUrl[website_my_pageurl_all._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_PageUrl["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_PageUrl["IsMy"] = IsMy;
                }
            }

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Memcache/Memcache_Hits.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_orderby) + "&today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion

            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 9; i >= 0; i--)
            {
                DataRow oDr_New = oDt_Date.NewRow();
                oDr_New["Date"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyy-MM-dd");
                if (System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.P_Today).ToShortDateString())
                {
                    oDr_New["isCurrentDate"] = 1;
                }
                else
                {
                    oDr_New["isCurrentDate"] = 0;
                }
                oDt_Date.Rows.Add(oDr_New);
            }
            this.rpt_Date.DataSource = oDt_Date;
            this.rpt_Date.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
