using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_My_Sql_Ignore_List_All : Business.ManageWeb
    {
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        public int P_PageSize = 20;
        protected string outPage = "";
        public int P_page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "last_execution_time desc";
            }
            if (!string.IsNullOrEmpty(this.QueryString("PageSize")))
            {
                this.P_PageSize = int.Parse(this.QueryString("PageSize"));
            }
            if (!Page.IsPostBack)
            {
                if (this.QueryString("page") != "")
                {
                    this.P_page = int.Parse(this.QueryString("page"));
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

            Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my_all = new Entity.TEAMTOOL.DATABASE_SQL_MY();
            database_sql_my_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            database_sql_my_all.SelectColumns = new string[] { "DATABASE_SQL_MY.*", "WebManager_RealName" };
            DataTable oDt_database_sql_my_all = database_sql_my_all.Select();

            string wheresql = " 1=1 ";
            Entity.TEAMTOOL.DATABASE_SQL_MY_IGNORE database_sql_my_ignore = new Entity.TEAMTOOL.DATABASE_SQL_MY_IGNORE();
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " AND (" + database_sql_my_ignore._TEXT_ANALYSIS + " LIKE '%" + this.txtKeyword.Text + "%' OR " + database_sql_my_ignore._DATABASE_IP + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_my_ignore._DATABASE_USER + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_my_ignore._DATABASE_NAME + " = '" + this.txtKeyword.Text + "') ";
            }
            database_sql_my_ignore.WhereSql = wheresql;
            database_sql_my_ignore.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            database_sql_my_ignore.SelectColumns = new string[] { "DATABASE_SQL_MY_IGNORE.*", "WebManager_RealName" };
            //database_sql_my_ignore.WEBMANAGER_NAME = (this.QueryString("v") == "" ? this.CurrentWebManagerName : this.QueryString("v"));
            database_sql_my_ignore.OrderBy = database_sql_my_ignore.TableName + "." + this.P_orderby;
            DataTable oDt_database_sql_my_ignore = database_sql_my_ignore.SelectByPaging(this.P_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = this.P_PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&orderby=" + Server.UrlEncode(this.P_orderby);

            if (this.LogCount < this.P_PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            website_my_pageurl_all.CacheName = "Welcome_" + this.CurrentWebManagerName + "_21";
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();
            //------------------------------------------------------ 
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("WebManager_Name_Charge", typeof(string)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("WebManager_RealName_Charge", typeof(string)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("IsMy_Charge", typeof(int)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("IsMy_Ignore", typeof(int)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("IsMyUrl", typeof(int)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("PageUrl", typeof(string)));

            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_worker_time/execution_count", typeof(decimal)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_elapsed_time/execution_count", typeof(decimal)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_physical_reads/execution_count", typeof(decimal)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_logical_reads/execution_count", typeof(decimal)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_logical_writes/execution_count", typeof(decimal)));
            oDt_database_sql_my_ignore.Columns.Add(new DataColumn("total_rows/execution_count", typeof(decimal)));


            foreach (DataRow oDr_database_sql_my in oDt_database_sql_my_ignore.Rows)
            {

                if (!string.IsNullOrEmpty(oDr_database_sql_my["execution_count"].ToString()))
                {

                    oDr_database_sql_my["total_worker_time/execution_count"] = decimal.Parse(oDr_database_sql_my["total_worker_time"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                    oDr_database_sql_my["total_elapsed_time/execution_count"] = decimal.Parse(oDr_database_sql_my["total_elapsed_time"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                    oDr_database_sql_my["total_physical_reads/execution_count"] = decimal.Parse(oDr_database_sql_my["total_physical_reads"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                    oDr_database_sql_my["total_logical_reads/execution_count"] = decimal.Parse(oDr_database_sql_my["total_logical_reads"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                    oDr_database_sql_my["total_logical_writes/execution_count"] = decimal.Parse(oDr_database_sql_my["total_logical_writes"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                    oDr_database_sql_my["total_rows/execution_count"] = decimal.Parse(oDr_database_sql_my["total_rows"].ToString()) / decimal.Parse(oDr_database_sql_my["execution_count"].ToString());
                }
                else
                {
                    oDr_database_sql_my["total_worker_time/execution_count"] = 0;
                    oDr_database_sql_my["total_elapsed_time/execution_count"] = 0;
                    oDr_database_sql_my["total_physical_reads/execution_count"] = 0;
                    oDr_database_sql_my["total_logical_reads/execution_count"] = 0;
                    oDr_database_sql_my["total_logical_writes/execution_count"] = 0;
                    oDr_database_sql_my["total_rows/execution_count"] = 0;

                }

                DataRow[] oDrs_database_sql_my = oDt_database_sql_my_all.Select(database_sql_my_ignore._SQL_MD5 + "='" + oDr_database_sql_my[database_sql_my_ignore._SQL_MD5].ToString() + "'");
                if (oDrs_database_sql_my != null && oDrs_database_sql_my.Length > 0)
                {
                    string WebManager_Name_Charge = "";
                    string WebManager_RealName_Charge = "";
                    int IsMy_Charge = 0;
                    foreach (DataRow oDr in oDrs_database_sql_my)
                    {
                        WebManager_Name_Charge += oDr[database_sql_my_ignore._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName_Charge += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[database_sql_my_ignore._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy_Charge = 1;
                        }
                    }
                    oDr_database_sql_my["WebManager_Name_Charge"] = WebManager_Name_Charge.TrimEnd(',');
                    oDr_database_sql_my["WebManager_RealName_Charge"] = WebManager_RealName_Charge.TrimEnd(',');
                    oDr_database_sql_my["IsMy_Charge"] = IsMy_Charge;
                }
                if (oDr_database_sql_my[database_sql_my_ignore._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                {
                    oDr_database_sql_my["IsMy_Ignore"] = 1;
                }
                // ------------------------------------------------------------------------------------------------
                string PageUrl = Business.Sql.SqlAnalysis.GetRequestPageUrl(oDr_database_sql_my[database_sql_my_ignore._TEXT_ANALYSIS].ToString());
                oDr_database_sql_my["PageUrl"] = PageUrl;
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_database_sql_my[website_my_pageurl_all._PAGEURL].ToString() + "' AND " + website_my_pageurl_all._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    oDr_database_sql_my["IsMyUrl"] = 1;
                }
                else
                {
                    oDr_database_sql_my["IsMyUrl"] = 0;
                }
            }

            //--------------------------------------------------------------
            this.rptLog.DataSource = oDt_database_sql_my_ignore;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
