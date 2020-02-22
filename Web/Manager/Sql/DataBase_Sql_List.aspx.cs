using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_Sql_List : Business.ManageWeb
    {
        public string P_Today = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_orderby = "";
        public string P_Sql_Error = "";
        /// <summary>
        /// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
        /// </summary>
        public string P_Bug_Type = "";
        public int LogCount = 0;
        public int P_PageSize = 20;
        public string P_My = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_Sql_List.aspx");
            this.P_orderby = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "last_execution_time desc";
            }
            this.P_Bug_Type = this.QueryString("Bug_Type");
            this.P_Today = this.QueryString("today");
            //if (string.IsNullOrEmpty(this.P_Today))
            //{
            //    this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            //}
            this.P_Sql_Error = this.QueryString("Sql_Error");
            if (string.IsNullOrEmpty(this.P_Sql_Error))
            {
                this.P_Sql_Error = "0";
            }
            if (!string.IsNullOrEmpty(this.QueryString("PageSize")))
            {
                this.P_PageSize = int.Parse(this.QueryString("PageSize"));
            }
            this.P_My = this.QueryString("My");
            if (string.IsNullOrEmpty(this.P_My))
            {
                this.P_My = "0";
            }

            if (!Page.IsPostBack)
            {
                if (this.QueryString("page") != "")
                {
                    this.P_page = int.Parse(this.QueryString("page"));
                }
                this.P_keyword = this.QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.txtLast_Execution_Time_Begin.Text = this.QueryString("Last_Execution_Time_Begin") == "" ? "00:00:00" : this.QueryString("Last_Execution_Time_Begin");
                this.txtLast_Execution_Time_End.Text = this.QueryString("Last_Execution_Time_End") == "" ? "23:59:59" : this.QueryString("Last_Execution_Time_End");
                this.cb_Sql_Error.Checked = this.P_Sql_Error == "1" ? true : false;


                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定关键词列表
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_database_ip = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats_database_ip.Distinct = true;
            database_sql_stats_database_ip.CacheTime = 60;
            database_sql_stats_database_ip.SelectColumns = new string[] { database_sql_stats_database_ip._DATABASE_IP };
            database_sql_stats_database_ip.WhereSql = database_sql_stats_database_ip._DATABASE_IP + " IS NOT NULL AND " + database_sql_stats_database_ip._DATABASE_IP + "<>''";
            DataTable oDt_database_sql_stats_database_ip = database_sql_stats_database_ip.Select();

            this.rpt_DataBase_Ip.DataSource = oDt_database_sql_stats_database_ip;
            this.rpt_DataBase_Ip.DataBind();


            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_database_user = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats_database_user.Distinct = true;
            database_sql_stats_database_user.CacheTime = 60;
            database_sql_stats_database_user.SelectColumns = new string[] { database_sql_stats_database_user._DATABASE_USER };
            database_sql_stats_database_user.WhereSql = database_sql_stats_database_user._DATABASE_USER + " IS NOT NULL AND " + database_sql_stats_database_user._DATABASE_USER + "<>''";
            DataTable oDt_database_sql_stats_database_user = database_sql_stats_database_user.Select();

            this.rpt_DataBase_User.DataSource = oDt_database_sql_stats_database_user;
            this.rpt_DataBase_User.DataBind();



            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_database_name = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats_database_name.Distinct = true;
            database_sql_stats_database_name.CacheTime = 60;
            database_sql_stats_database_name.SelectColumns = new string[] { database_sql_stats_database_name._DATABASE_NAME };
            database_sql_stats_database_name.WhereSql = database_sql_stats_database_name._DATABASE_NAME + " IS NOT NULL AND " + database_sql_stats_database_name._DATABASE_NAME + "<>''";
            DataTable oDt_database_sql_stats_database_name = database_sql_stats_database_name.Select();

            this.rpt_DataBase_Name.DataSource = oDt_database_sql_stats_database_name;
            this.rpt_DataBase_Name.DataBind();
            #endregion

            #region 绑定列表
            int _PageSize = this.P_PageSize;
            this.LogCount = 0;

            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                bool bKey = true;
                DataRow[] oDrs_DataBase_Ip = oDt_database_sql_stats_database_ip.Select(database_sql_stats_database_ip._DATABASE_IP + "='" + this.txtKeyword.Text.Trim() + "'");
                if (oDrs_DataBase_Ip == null || oDrs_DataBase_Ip.Length == 0)
                {
                    DataRow[] oDrs_DataBase_User = oDt_database_sql_stats_database_user.Select(database_sql_stats_database_ip._DATABASE_USER + "='" + this.txtKeyword.Text.Trim() + "'");
                    if (oDrs_DataBase_User == null || oDrs_DataBase_User.Length == 0)
                    {
                        DataRow[] oDrs_DataBase_Name = oDt_database_sql_stats_database_name.Select(database_sql_stats_database_ip._DATABASE_NAME + "='" + this.txtKeyword.Text.Trim() + "'");
                        if (oDrs_DataBase_Name == null || oDrs_DataBase_Name.Length == 0)
                        {
                            bKey = false;
                        }
                        else
                        {
                            bKey = true;
                        }
                    }
                    else
                    {
                        bKey = true;
                    }
                }
                else
                {
                    bKey = true;
                }
                if (bKey == true)
                {
                    wheresql += " AND (" + database_sql_stats.TableName + "." + database_sql_stats._TEXT + " = '" + this.txtKeyword.Text + "' ";
                }
                else
                {
                    wheresql += " AND( " + database_sql_stats.TableName + "." + database_sql_stats._TEXT + " LIKE '%" + this.txtKeyword.Text + "%' ";
                }
                wheresql += " OR " + database_sql_stats.TableName + "." + database_sql_stats._SOURCE_MD5 + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_stats.TableName + "." + database_sql_stats._SQL_MD5 + " = '" + this.txtKeyword.Text + "' OR " + database_sql_stats.TableName + "." + database_sql_stats._DATABASE_IP + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_stats.TableName + "." + database_sql_stats._DATABASE_USER + " = '" + this.txtKeyword.Text + "'  OR " + database_sql_stats.TableName + "." + database_sql_stats._DATABASE_NAME + " = '" + this.txtKeyword.Text + "') ";
            }
            if (this.txtLast_Execution_Time_Begin.Text.Trim() != "" && this.txtLast_Execution_Time_End.Text.Trim() != "" && !string.IsNullOrEmpty(this.P_Today))
            {
                wheresql += " AND (" + database_sql_stats.TableName + "." + database_sql_stats._LAST_EXECUTION_TIME + ">'" + this.P_Today + " " + this.txtLast_Execution_Time_Begin.Text.Trim() + "' and " + database_sql_stats.TableName + "." + database_sql_stats._LAST_EXECUTION_TIME + "<'" + this.P_Today + " " + this.txtLast_Execution_Time_End.Text.Trim() + "') ";
            }
            if (this.cb_Sql_Error.Checked == true)
            {
                wheresql += " AND (" + database_sql_stats.TableName + "." + database_sql_stats._ANALYSIS + "=1 and " + database_sql_stats.TableName + "." + database_sql_stats._SQL_ERROR + " is not NULL and " + database_sql_stats.TableName + "." + database_sql_stats._SQL_ERROR + "<>'')";
            }
            if (this.P_Bug_Type == "0")// 0 Lack_With_NoLock_Count,1 Select_All_Count,2 Like_Count,3 Lack_Parameter_Count,4 Count_All
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._LACK_WITH_NOLOCK_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "1")
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._SELECT_ALL_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "2")
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._LIKE_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "3")
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._LACK_PARAMETER_COUNT + ">0 ";
            }
            else if (this.P_Bug_Type == "4")
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._COUNT_ALL + ">0 ";
            }
            else if (this.P_Bug_Type == "5")
            {
                wheresql += " AND " + database_sql_stats.TableName + "." + database_sql_stats._ISWRONGDATABASEUSER + ">0  AND  " + database_sql_stats.TableName + "." + database_sql_stats._ISRUNTIMESQL + ">0 ";
            }
            if (this.P_My == "1")//只看我的
            {
                database_sql_stats.INNER_JOIN_DATABASE_SQL_MY = true;
                wheresql += " AND DATABASE_SQL_MY.WebManager_name='" + this.CurrentWebManagerName + "' ";
            }
            else if (this.P_My == "2")//只看疑似我的
            {
                database_sql_stats.SEEMLIKE_WEBMANAGER_NAME = "%" + this.CurrentWebManagerName + "%";
            }
            else if (this.P_My == "3")//只看被认领的
            {
                database_sql_stats.INNER_JOIN_DATABASE_SQL_MY = true;
            }
            //else if (this.P_My == "4")//只看我忽略的
            //{
            //    database_sql_stats.INNER_JOIN_DATABASE_SQL_MY_IGNORE = true;
            //    wheresql += " AND DATABASE_SQL_MY_IGNORE.WebManager_name='" + this.CurrentWebManagerName + "' ";
            //}
            //else if (this.P_My == "5")//只看被忽略的
            //{
            //    database_sql_stats.INNER_JOIN_DATABASE_SQL_MY_IGNORE = true;
            //}
            database_sql_stats.SelectColumns = new string[] { database_sql_stats.TableName + ".*" };
            database_sql_stats.WhereSql = wheresql;
            database_sql_stats.OrderBy = database_sql_stats.TableName + "." + this.P_orderby;
            if (!string.IsNullOrEmpty(this.P_Today))
            {
                database_sql_stats.STATS_DATE = DateTime.Parse(this.P_Today);
            }
            //database_sql_stats.CacheTime = 10;


            DataTable dtLog = database_sql_stats.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Sql/DataBase_Sql_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&today=" + Server.UrlEncode(this.P_Today) + "&orderby=" + Server.UrlEncode(this.P_orderby) + "&Last_Execution_Time_Begin=" + Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) + "&Last_Execution_Time_End=" + Server.UrlEncode(this.txtLast_Execution_Time_End.Text) + "&Sql_Error=" + (this.cb_Sql_Error.Checked == true ? "1" : "0") + "&Bug_Type=" + this.P_Bug_Type + "&My=" + this.P_My;

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
            database_sql_my.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            database_sql_my.SelectColumns = new string[] { "DATABASE_SQL_MY.*", "WebManager_RealName" };
            database_sql_my.CacheTime = 5;
            DataTable oDt_database_sql_my = database_sql_my.Select();
            //---------------------------------------------------------

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            website_my_pageurl_all.CacheName = "Welcome_" + this.CurrentWebManagerName + "_21";
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

            //---------------------------------------------------------
            dtLog.Columns.Add(new DataColumn(database_sql_my._WEBMANAGER_NAME, typeof(string)));
            dtLog.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dtLog.Columns.Add(new DataColumn("IsMySql", typeof(int)));
            dtLog.Columns.Add(new DataColumn("IsMyUrl", typeof(int)));
            dtLog.Columns.Add(new DataColumn("PageUrl", typeof(string)));
            foreach (DataRow oDr_Sql_Stats in dtLog.Rows)
            {
                DataRow[] oDrs_database_sql_my = oDt_database_sql_my.Select(database_sql_my._SQL_MD5 + "='" + oDr_Sql_Stats[database_sql_my._SQL_MD5].ToString() + "'");
                if (oDrs_database_sql_my != null && oDrs_database_sql_my.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMySql = 0;
                    foreach (DataRow oDr in oDrs_database_sql_my)
                    {
                        WebManager_Name += oDr[database_sql_my._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        if (oDr[database_sql_my._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMySql = 1;
                        }
                    }
                    oDr_Sql_Stats[database_sql_my._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    if (!string.IsNullOrEmpty(WebManager_RealName))
                    {
                        oDr_Sql_Stats["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    }
                    oDr_Sql_Stats["IsMySql"] = IsMySql;
                }
                // ------------------------------------------------------------------------------------------------
                string PageUrl = Business.Sql.SqlAnalysis.GetRequestPageUrl(oDr_Sql_Stats[database_sql_stats._TEXT].ToString());
                oDr_Sql_Stats["PageUrl"] = PageUrl;

                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_Sql_Stats[website_my_pageurl_all._PAGEURL].ToString() + "' AND " + website_my_pageurl_all._WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    oDr_Sql_Stats["IsMyUrl"] = 1;
                }
                else
                {
                    oDr_Sql_Stats["IsMyUrl"] = 0;
                }
            }
            //string RowFilter = database_sql_my._SQL_MD5 + " LIKE '%" + this.txtKeyword.Text + "%'";
            //if (!string.IsNullOrEmpty(this.ddl_TeamName.SelectedValue))
            //{
            //    RowFilter += " and teamname='" + this.ddl_TeamName.SelectedValue + "' ";
            //}
            DataView dv_Sql_Stats = dtLog.DefaultView;
            //dv_Sql_Stats.Sort = this.P_OrderBy + " DESC";
            //dv_Sql_Stats.RowFilter = RowFilter;

            //this.LogCount = dv_Sql_Stats.Count;
            this.rptLog.DataSource = dv_Sql_Stats;
            this.rptLog.DataBind();


            //WithNoLock_Select(dtLog);
            //this.rptLog.DataSource = dtLog;
            //this.rptLog.DataBind();
            #endregion

            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 9; i >= 0; i--)
            {
                DataRow oDr_New = oDt_Date.NewRow();
                oDr_New["Date"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(this.P_Today) && System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.P_Today).ToShortDateString())
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


            #region 统计漏洞与问题的数量
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_sum = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats_sum.SelectColumns = new string[]{
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LACK_WITH_NOLOCK_COUNT+"), 0) AS "+database_sql_stats_sum._LACK_WITH_NOLOCK_COUNT,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._SELECT_ALL_COUNT+"), 0) AS "+database_sql_stats_sum._SELECT_ALL_COUNT,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LIKE_COUNT+"), 0) AS "+database_sql_stats_sum._LIKE_COUNT,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LACK_PARAMETER_COUNT+"), 0) AS "+database_sql_stats_sum._LACK_PARAMETER_COUNT,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._COUNT_ALL+"), 0) AS "+database_sql_stats_sum._COUNT_ALL,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LACK_WITH_NOLOCK_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._SELECT_ALL_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LIKE_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._LACK_PARAMETER_COUNT+"), 0)+ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._COUNT_ALL+"), 0) as count_sum",
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._TOTAL_WORKER_TIME+"), 0) AS "+database_sql_stats_sum._TOTAL_WORKER_TIME,
                "ISNULL(SUM("+database_sql_stats_sum.TableName+"."+database_sql_stats_sum._EXECUTION_COUNT+"), 0) AS "+database_sql_stats_sum._EXECUTION_COUNT,
                "COUNT(1) AS COUNTS",
                "0.01 AS BadRate",
                "0.001 AS WORKER_TIME"
            };
            if (!string.IsNullOrEmpty(this.P_Today))
            {
                database_sql_stats_sum.STATS_DATE = DateTime.Parse(this.P_Today);
            }
            database_sql_stats_sum.CacheTime = 60;

            if (this.P_My == "1")//只看我的
            {
                database_sql_stats_sum.INNER_JOIN_DATABASE_SQL_MY = true;
                database_sql_stats_sum.WhereSql= " DATABASE_SQL_MY.WebManager_name='" + this.CurrentWebManagerName + "' ";
            }
            else if (this.P_My == "2")//只看疑似我的
            {
                database_sql_stats_sum.SEEMLIKE_WEBMANAGER_NAME = "%" + this.CurrentWebManagerName + "%";
            }
            else if (this.P_My == "3")//只看被认领的
            {
                database_sql_stats_sum.INNER_JOIN_DATABASE_SQL_MY = true;
            }



            DataTable oDt_database_sql_stats_sum = database_sql_stats_sum.Select();
            foreach (DataRow oDr_database_sql_stats in oDt_database_sql_stats_sum.Rows)
            {
                decimal count_sum = decimal.Parse(oDr_database_sql_stats["count_sum"].ToString());
                decimal counts = decimal.Parse(oDr_database_sql_stats["counts"].ToString());
                long total_worker_time = long.Parse(oDr_database_sql_stats[database_sql_stats_sum._TOTAL_WORKER_TIME].ToString());
                long execution_count = long.Parse(oDr_database_sql_stats[database_sql_stats_sum._EXECUTION_COUNT].ToString());
                oDr_database_sql_stats["BadRate"] = oDr_database_sql_stats["counts"].ToString() == "0" ? "0" : (count_sum * 100 / counts).ToString("f2").Replace(".00", "");
                oDr_database_sql_stats["WORKER_TIME"] = total_worker_time / (execution_count > 0 ? execution_count : 1);
            }
            this.rpt_database_sql_stats_sum.DataSource = oDt_database_sql_stats_sum;
            this.rpt_database_sql_stats_sum.DataBind();
            #endregion
        }
        private DataTable WithNoLock_Select(DataTable oDt)
        {
            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.SelectColumns = new string[] { database_table._TABLE_NAME };
            database_table.COUNTDATE = System.DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            database_table.Distinct = true;
            database_table.CacheTime = 120;
            DataTable oDt_database_table = database_table.Select();

            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            //oDt.Columns.Add(new DataColumn("WITHNOLOCK_SELECT", typeof(string)));
            string update_sql = "";
            foreach (DataRow oDr in oDt.Rows)
            {
                if (oDr[database_sql_stats._ANALYSIS].ToString() == "0")
                {

                    string Sql_Analysis = "";
                    int[] Counts;
                    string Sql_Error = Business.Sql.SqlAnalysis.GelSqlError(oDr[database_sql_stats._TEXT].ToString(), oDt_database_table, oDr[database_sql_stats._DATABASE_USER].ToString(), out Sql_Analysis, out Counts);

                    Entity.TEAMTOOL.DATABASE_SQL_STATS update_database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                    update_database_sql_stats.STATS_DATE = DateTime.Parse(oDr[database_sql_stats._STATS_DATE].ToString());
                    update_database_sql_stats.SQL_MD5 = oDr[database_sql_stats._SQL_MD5].ToString();
                    update_database_sql_stats.SQL_ERROR = Sql_Error;
                    update_database_sql_stats.TEXT_ANALYSIS = Sql_Analysis;
                    update_database_sql_stats.ANALYSIS = 1;
                    update_database_sql_stats.LACK_WITH_NOLOCK_COUNT = Counts[0];
                    update_database_sql_stats.SELECT_ALL_COUNT = Counts[1];
                    update_database_sql_stats.LACK_PARAMETER_COUNT = Counts[2];
                    update_database_sql_stats.LIKE_COUNT = Counts[3];
                    update_database_sql_stats.COUNT_ALL = Counts[4];
                    update_database_sql_stats.ISWRITESQL = Counts[5];
                    update_database_sql_stats.ISRUNTIMESQL = Counts[6];
                    update_database_sql_stats.ISWRONGDATABASEUSER = Counts[7];
                    update_sql += update_database_sql_stats.GetUpdateSql() + ";";

                }
            }
            if (!string.IsNullOrEmpty(update_sql))
            {
                try
                {
                    int iResult = database_sql_stats.Database_Reader.ExecuteNonQuery(CommandType.Text, update_sql);
                }
                catch { }
            }
            return oDt;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
