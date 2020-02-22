using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Log
{
    public partial class Log_Stats_List_My : Business.ManageWeb
    {
        private string P_Today = "";
        private string P_Keyword = "";
        public string P_OrderBy = "";
        public string P_TeamName = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Log/Log_Stats_List_My.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "log_type asc,log_count desc";
            }
            if (!Page.IsPostBack)
            {
                this.P_Today = this.QueryString("today");
                this.P_Keyword = this.QueryString("keyword");
                this.P_TeamName = this.QueryString("teamname");

                if (string.IsNullOrEmpty(this.P_Today))
                {
                    this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                this.txtToday.Text = this.P_Today;
                this.txtKeyword.Text = this.P_Keyword;

                Entity.TEAMTOOL.ADMIN_PRODUCT admin_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                admin_product.CacheTime = 120;
                DataTable oDt = admin_product.Select();
                this.ddl_TeamName.DataTextField = admin_product._PRODUCTNAME;
                this.ddl_TeamName.DataValueField = admin_product._PRODUCTNAME;
                this.ddl_TeamName.DataSource = oDt;
                this.ddl_TeamName.DataBind();
                this.ddl_TeamName.Items.Add(new ListItem("-请选择-", ""));
                this.ddl_TeamName.SelectedValue = this.P_TeamName;

                if (!string.IsNullOrEmpty(this.P_TeamName))
                {
                    this.ddl_TeamName.SelectedValue = this.P_TeamName;
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            Entity.TEAMTOOL.LOG_STATS log_stats = new Entity.TEAMTOOL.LOG_STATS();
            log_stats.LOG_DATE = DateTime.Parse(this.txtToday.Text);
            log_stats.CacheTime = 10;
            DataTable dt_log_stats = log_stats.Select();
            //--------------------------------------------------------
            string PageUrl = "xxxx";
            foreach (DataRow oDr in dt_log_stats.Rows)
            {
                PageUrl += "|" + oDr["pageurl"].ToString();
            }

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            website_my_pageurl.Split_Or_And = true;
            website_my_pageurl.PAGEURL = PageUrl;
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            //---------------------------------------------------------
            dt_log_stats.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_log_stats.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dt_log_stats.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_log_stats.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }
            }
            string RowFilter = website_my_pageurl._PAGEURL + " LIKE '%" + this.txtKeyword.Text + "%' and " + website_my_pageurl._WEBMANAGER_NAME+"='"+this.CurrentWebManagerName+"'";
            //if (!string.IsNullOrEmpty(this.ddl_TeamName.SelectedValue))
            //{
            //    RowFilter += " and teamname='" + this.ddl_TeamName.SelectedValue + "' ";
            //}

            DataView dv_Connect_Log_Stats = dt_log_stats.DefaultView;
            dv_Connect_Log_Stats.Sort = this.P_OrderBy + (this.P_OrderBy.IndexOf(" ") == -1 ? " DESC" : "");
            dv_Connect_Log_Stats.RowFilter = RowFilter;

            this.LogCount = dv_Connect_Log_Stats.Count;
            this.rptLog.DataSource = dv_Connect_Log_Stats;
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
                if (System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.txtToday.Text).ToShortDateString())
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
