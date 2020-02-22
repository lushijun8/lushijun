using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_Ignore_List_All : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string P_orderby = "";
        public string P_My = "0";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_Ignore_List_All.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "duration_avg";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            this.P_My = this.QueryString("My");
            if (string.IsNullOrEmpty(this.P_My))
            {
                this.P_My = "0";
            }
            if (!Page.IsPostBack)
            {
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
            website_my_pageurl_ignore.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            //website_my_pageurl_ignore.PAGEURL = "%" + this.txtKeyword.Text + "%";
            website_my_pageurl_ignore.Distinct = true;
            website_my_pageurl_ignore.LEFT_JOIN_WEBSITE_PAGEURL = true;
            website_my_pageurl_ignore.JoinSql = "LEFT JOIN DATABASE_SQL_CONNECT_STATS ON " + website_my_pageurl_ignore.TableName + "." + website_my_pageurl_ignore._PAGEURL + "=DATABASE_SQL_CONNECT_STATS.PAGEURL AND STATS_DATE = '" + this.P_Today + "'";
            website_my_pageurl_ignore.SelectColumns = new string[] { 
                "" + website_my_pageurl_ignore.TableName + "." + website_my_pageurl_ignore._PAGEURL,
                website_my_pageurl_ignore.TableName + "." + website_my_pageurl_ignore._WEBMANAGER_NAME + " AS " + website_my_pageurl_ignore._WEBMANAGER_NAME,
                "website_pageurl.ErrorInfo",
                "website_pageurl.ErrorTime",
                "website_pageurl.Depend_PageUrl",
                "website_pageurl.Depend_PageUrl_Out",
                "website_pageurl.form_Phone_Encrypt",
                "website_pageurl.querystring_Phone_Encrypt",
                "website_pageurl.querystring",
                "website_pageurl.form",
                "website_pageurl.webmanager_realname_depend",
                "website_pageurl.webmanager_realname_like",
                "website_pageurl.webmanager_realname as WebManager_RealName_Charge",
                "website_pageurl.webmanager_name as WebManager_Name_Charge",
                "ADMIN_WEBMANAGER.WebManager_RealName",
                "request_count",
                "connect_times_min",
                "connect_times_max",
                "connect_times_avg",
                "duration_min",
                "duration_max",
                "duration_avg",
                "lastconnecttime"
                };

            DataTable oDt_website_my_pageurl_ignore = website_my_pageurl_ignore.Select();
            //--------------------------------------------------------- 
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("IsMy_Charge", typeof(int)));
            oDt_website_my_pageurl_ignore.Columns.Add(new DataColumn("IsMy_Ignore", typeof(int)));

            foreach (DataRow oDr_website_my_pageurl_ignore in oDt_website_my_pageurl_ignore.Rows)
            {

                int IsMy_Charge = 0;
                if (oDr_website_my_pageurl_ignore["WebManager_Name_Charge"].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                {
                    IsMy_Charge = 1;
                }
                oDr_website_my_pageurl_ignore["IsMy_Charge"] = IsMy_Charge;
                if (oDr_website_my_pageurl_ignore[website_my_pageurl_ignore._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                {
                    oDr_website_my_pageurl_ignore["IsMy_Ignore"] = 1;
                }
            }

            //--------------------------------------------------------------
            DataView oDv = oDt_website_my_pageurl_ignore.DefaultView;
            oDv.Sort = this.P_orderby + " DESC";
            oDv.RowFilter = " 1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                oDv.RowFilter += " AND (PAGEURL LIKE '%" + this.txtKeyword.Text + "%' OR WebManager_RealName like '%" + this.txtKeyword.Text + "%') ";
            }
            if (this.P_My == "1")
            {
                oDv.RowFilter += " AND IsMy_Ignore = 1 ";
            }
            this.LogCount = oDv.Count;
            this.rptLog.DataSource = oDv;
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
