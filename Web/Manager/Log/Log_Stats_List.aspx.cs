using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Log
{
    public partial class Log_Stats_List : Business.ManageWeb
    {
        private string P_Today = "";
        private string P_Keyword = "";
        public string P_OrderBy = "";
        public string P_TeamName = "";
        public int LogCount = 0;
        public string P_My = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Log/Log_Stats_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "log_type asc,log_count desc";
            }
            this.P_My = this.QueryString("My");
            if (string.IsNullOrEmpty(this.P_My))
            {
                this.P_My = "0";
            }
            if (!Page.IsPostBack)
            {
                this.P_Today = this.QueryString("today");
                this.P_Keyword = this.QueryString("keyword");
                this.P_TeamName = this.QueryString("teamname");

                //if (string.IsNullOrEmpty(this.P_Today))
                //{
                //    this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
                //}
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
            Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();

            Entity.TEAMTOOL.LOG_STATS log_stats = new Entity.TEAMTOOL.LOG_STATS();
            if (!string.IsNullOrEmpty(this.txtToday.Text))
            {
                log_stats.LOG_DATE = DateTime.Parse(this.txtToday.Text);
            }
            log_stats.CacheTime = 10;

            log_stats.LEFT_JOIN_WEBSITE_PAGEURL = true;
            log_stats.SelectColumns = new string[] {
                log_stats.TableName+"."+log_stats._PAGEURL,
                log_stats.TableName+"."+log_stats._LOG_TYPE,
                "MAX("+website_pageurl.TableName+"."+website_pageurl._ERRORINFO+") AS "+website_pageurl._ERRORINFO+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._ERRORTIME+") AS "+website_pageurl._ERRORTIME+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._DEPEND_PAGEURL+") AS "+website_pageurl._DEPEND_PAGEURL+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._DEPEND_PAGEURL_OUT+") AS "+website_pageurl._DEPEND_PAGEURL_OUT+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._FORM_PHONE_ENCRYPT+") AS "+website_pageurl._FORM_PHONE_ENCRYPT+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._QUERYSTRING_PHONE_ENCRYPT+") AS "+website_pageurl._QUERYSTRING_PHONE_ENCRYPT+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._QUERYSTRING+") AS "+website_pageurl._QUERYSTRING+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._FORM+") AS "+website_pageurl._FORM+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._WEBMANAGER_REALNAME_DEPEND+") AS "+website_pageurl._WEBMANAGER_REALNAME_DEPEND+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._WEBMANAGER_REALNAME_LIKE+") AS "+website_pageurl._WEBMANAGER_REALNAME_LIKE+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._WEBMANAGER_REALNAME+") AS "+website_pageurl._WEBMANAGER_REALNAME+"",
                "MAX("+website_pageurl.TableName+"."+website_pageurl._WEBMANAGER_NAME+") AS "+website_pageurl._WEBMANAGER_NAME+"",
                "SUM("+log_stats._LOG_COUNT+") AS "+log_stats._LOG_COUNT+""
            };
            log_stats.GroupBy = log_stats.TableName + "." + log_stats._PAGEURL + "," + log_stats.TableName + "." + log_stats._LOG_TYPE;

            DataTable dt_log_stats = log_stats.Select();

            //---------------------------------------------------------
            dt_log_stats.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_log_stats.Rows)
            {
                int IsMy = 0;
                if (oDr_Connect_Log_Stats["WebManager_Name"].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                {
                    IsMy = 1;
                }
                oDr_Connect_Log_Stats["IsMy"] = IsMy;
            }
            string RowFilter = log_stats._PAGEURL + " LIKE '%" + this.txtKeyword.Text + "%'";
            if (!string.IsNullOrEmpty(this.ddl_TeamName.SelectedValue))
            {
                RowFilter += " and teamname='" + this.ddl_TeamName.SelectedValue + "' ";
            }
              
            if (this.P_My == "1")
            {
                RowFilter += " AND WebManager_Name LIKE '%" + this.CurrentWebManagerName + "%' ";
            }


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
                if (!string.IsNullOrEmpty(this.txtToday.Text) && System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.txtToday.Text).ToShortDateString())
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
