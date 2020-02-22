using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_My_Sql_List : Business.ManageWeb
    {
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        public int P_PageSize = 20;
        protected string outPage = "";
        public int P_page = 1;
        public string CurrentWebManagerName_v = "";
        public int BadSql_Rank_My = -1;
        public int Worker_Time_Rank_My = -1;
        /// <summary>
        /// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
        /// </summary>
        public string P_Bug_Type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_My_Sql_List.aspx");
            this.CurrentWebManagerName_v = this.CurrentWebManagerName;
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                CurrentWebManagerName_v = this.QueryString("v");
            }
            this.P_Bug_Type = this.QueryString("Bug_Type");
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "LAST_EXECUTION_TIME DESC";
            }
            //this.P_Today = this.QueryString("today");
            //if (string.IsNullOrEmpty(this.P_Today))
            //{
            //    this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            //}
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

            Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
            string wheresql = " 1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " AND (" + database_sql_my._TEXT_ANALYSIS + " LIKE '%" + this.txtKeyword.Text + "%' OR " + database_sql_my._DATABASE_IP + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_my._DATABASE_USER + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_my._DATABASE_NAME + " = '" + this.txtKeyword.Text + "') ";
            }
            database_sql_my.WEBMANAGER_NAME = this.CurrentWebManagerName_v;
            database_sql_my.OrderBy = this.P_orderby.Replace("ｅ", "e");
            if (this.P_Bug_Type == "0")// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
            {
                wheresql += " AND " + database_sql_my._LACK_WITH_NOLOCK_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "1")
            {
                wheresql += " AND " + database_sql_my._SELECT_ALL_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "2")
            {
                wheresql += " AND " + database_sql_my._LIKE_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "3")
            {
                wheresql += " AND " + database_sql_my._LACK_PARAMETER_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "4")
            {
                wheresql += " AND " + database_sql_my._COUNT_ALL + ">0 ";
            }
            else if (this.P_Bug_Type == "5")
            {
                wheresql += " AND " + database_sql_my._ISWRONGDATABASEUSER + ">0  AND  " + database_sql_my._ISRUNTIMESQL + ">0 ";
            }
            database_sql_my.WhereSql = wheresql;

            DataTable oDt_database_sql_my = database_sql_my.SelectByPaging(this.P_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = this.P_PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&orderby=" + Server.UrlEncode(this.P_orderby) + "&Bug_Type=" + this.P_Bug_Type;

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
            oDt_database_sql_my.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            oDt_database_sql_my.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            oDt_database_sql_my.Columns.Add(new DataColumn("IsMySql", typeof(int)));
            oDt_database_sql_my.Columns.Add(new DataColumn("IsMyUrl", typeof(int)));
            oDt_database_sql_my.Columns.Add(new DataColumn("PageUrl", typeof(string)));

            oDt_database_sql_my.Columns.Add(new DataColumn("total_worker_time/execution_count", typeof(decimal)));
            oDt_database_sql_my.Columns.Add(new DataColumn("total_elapsed_time/execution_count", typeof(decimal)));
            oDt_database_sql_my.Columns.Add(new DataColumn("total_physical_reads/execution_count", typeof(decimal)));
            oDt_database_sql_my.Columns.Add(new DataColumn("total_logical_reads/execution_count", typeof(decimal)));
            oDt_database_sql_my.Columns.Add(new DataColumn("total_logical_writes/execution_count", typeof(decimal)));
            oDt_database_sql_my.Columns.Add(new DataColumn("total_rows/execution_count", typeof(decimal)));


            foreach (DataRow oDr_database_sql_my in oDt_database_sql_my.Rows)
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

                DataRow[] oDrs_database_sql_my = oDt_database_sql_my_all.Select(database_sql_my._SQL_MD5 + "='" + oDr_database_sql_my[database_sql_my._SQL_MD5].ToString() + "'");
                if (oDrs_database_sql_my != null && oDrs_database_sql_my.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMySql = 0;
                    foreach (DataRow oDr in oDrs_database_sql_my)
                    {
                        WebManager_Name += oDr[database_sql_my._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[database_sql_my._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName_v)
                        {
                            IsMySql = 1;
                        }
                    }
                    oDr_database_sql_my[database_sql_my._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_database_sql_my["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_database_sql_my["IsMySql"] = IsMySql;
                }
                // ------------------------------------------------------------------------------------------------
                string PageUrl = Business.Sql.SqlAnalysis.GetRequestPageUrl(oDr_database_sql_my[database_sql_my._TEXT_ANALYSIS].ToString());
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
            this.rptLog.DataSource = oDt_database_sql_my;
            this.rptLog.DataBind();
            #endregion
            #region 统计漏洞与问题的数量
            //DataView oDv = DataBase_BadSql_Rank_My.Get_BadSql_Rank_My();
            //oDv.RowFilter = "WEBMANAGER_NAME='"+this.CurrentWebManagerName_v+"'"; 
            //this.rpt_database_sql_stats_sum.DataSource = oDv;
            //this.rpt_database_sql_stats_sum.DataBind();


            DataView oDv_BadSql_Rank_My = Sql.DataBase_BadSql_Rank_My.Get_BadSql_Rank_My();
            DataTable oDt_database_sql_stats_sum = null;
            oDv_BadSql_Rank_My.Sort = "BadRate ASC";
            for (int i = 0; i < oDv_BadSql_Rank_My.Count; i++)
            {
                if (oDv_BadSql_Rank_My[i]["WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.BadSql_Rank_My = i + 1;
                    oDt_database_sql_stats_sum = oDv_BadSql_Rank_My.Table.Clone();
                    DataRow oDr_New = oDt_database_sql_stats_sum.NewRow();
                    oDr_New.ItemArray = oDv_BadSql_Rank_My[i].Row.ItemArray;
                    oDt_database_sql_stats_sum.Rows.Add(oDr_New);
                    break;
                }
            }

            oDv_BadSql_Rank_My.Sort = "Worker_Time ASC";
            for (int i = 0; i < oDv_BadSql_Rank_My.Count; i++)
            {
                if (oDv_BadSql_Rank_My[i]["WEBMANAGER_NAME"].ToString() == this.CurrentWebManagerName_v)
                {
                    this.Worker_Time_Rank_My = i + 1;
                    break;
                }
            }

            if (oDt_database_sql_stats_sum != null)
            {
                this.rpt_database_sql_stats_sum.DataSource = oDt_database_sql_stats_sum;
                this.rpt_database_sql_stats_sum.DataBind();
            }
            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
