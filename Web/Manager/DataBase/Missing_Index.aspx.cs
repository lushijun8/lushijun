using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class Missing_Index : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        private string P_DataBase_Name = "";
        private string P_DataBase_Ip_Romote = "";
        public string P_Today = "";
        private string P_Keyword = "";
        public string P_OrderBy = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/Missing_Index.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "Total_Cost DESC";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.P_Keyword = this.QueryString("keyword");
                this.P_DataBase_Ip_Romote = this.QueryString("DataBase_Ip_Romote");
                this.P_DataBase_Name = this.QueryString("DataBase_Name");


                this.txtKeyword.Text = this.P_Keyword;

                Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                database_missing_index.SelectColumns = new string[] { database_missing_index._DATABASE_IP_ROMOTE };
                database_missing_index.Distinct = true;
                database_missing_index.CacheTime = 1440;
                DataTable oDt_ip = database_missing_index.Select();
                this.ddl_DataBase_Ip_Romote.DataTextField = database_missing_index._DATABASE_IP_ROMOTE;
                this.ddl_DataBase_Ip_Romote.DataValueField = database_missing_index._DATABASE_IP_ROMOTE;
                this.ddl_DataBase_Ip_Romote.DataSource = oDt_ip;
                this.ddl_DataBase_Ip_Romote.DataBind();
                this.ddl_DataBase_Ip_Romote.Items.Add(new ListItem("-请选择-", ""));
                this.ddl_DataBase_Ip_Romote.SelectedValue = this.P_DataBase_Ip_Romote;
                if (!string.IsNullOrEmpty(this.P_DataBase_Ip_Romote))
                {
                    this.ddl_DataBase_Ip_Romote.SelectedValue = this.P_DataBase_Ip_Romote;
                }

                Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index0 = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                database_missing_index0.SelectColumns = new string[] { database_missing_index0._DATABASE_NAME };
                database_missing_index0.Distinct = true;
                database_missing_index0.CacheTime = 1440;
                DataTable oDt_name = database_missing_index0.Select();
                this.ddl_DataBase_Name.DataTextField = database_missing_index0._DATABASE_NAME;
                this.ddl_DataBase_Name.DataValueField = database_missing_index0._DATABASE_NAME;
                this.ddl_DataBase_Name.DataSource = oDt_name;
                this.ddl_DataBase_Name.DataBind();
                this.ddl_DataBase_Name.Items.Add(new ListItem("-请选择-", ""));
                this.ddl_DataBase_Name.SelectedValue = this.P_DataBase_Name;
                if (!string.IsNullOrEmpty(this.P_DataBase_Name))
                {
                    this.ddl_DataBase_Name.SelectedValue = this.P_DataBase_Name;
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;

            Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
            database_missing_index.LEFT_JOIN_DATABASE_TABLE = true;
            database_missing_index.SelectColumns = new string[] { database_missing_index.TableName+".DataBase_IP_Romote AS DataBase_IP_Romote", 
               database_missing_index.TableName+".DataBase_Name AS DataBase_Name", 
                "Date", 
                "index_handle",
                "group_handle",
                database_missing_index.TableName+".Table_Name AS Table_Name", 
                "equality_columns", 
                "inequality_columns", 
                "included_columns", 
                "statement",
                "unique_compiles", 
                "user_seeks", 
                "user_scans", 
                "last_user_seek", 
                "last_user_scan", 
                "avg_total_user_cost", 
                "avg_user_impact", 
                "system_seeks", 
                "system_scans", 
                "last_system_seek", 
                "last_system_scan", 
                "avg_total_system_cost", 
                "avg_system_impact", 
                //"CreateTime", 
                "Total_Cost", 
                "RowCounts", 
                "ColumnCounts", 
                "Space_Allocation", 
                "Space_Used", 
                "Space_Index_Used", 
                "Space_Available" };
            string wheresql = "1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " and (" +
                    database_missing_index._EQUALITY_COLUMNS + " like '%" + this.txtKeyword.Text.Trim() + "%' OR " +
                    database_missing_index._INCLUDED_COLUMNS + " like '%" + this.txtKeyword.Text.Trim() + "%' OR  " +
                    database_missing_index._STATEMENT + " like '%" + this.txtKeyword.Text.Trim() + "%' OR  " +
                    database_missing_index._INEQUALITY_COLUMNS + " like '%" + this.txtKeyword.Text.Trim() + "%' ) ";
            }
            if (!string.IsNullOrEmpty(this.P_Today))
            {
                wheresql += " and (" + database_missing_index._DATE + " = '" + this.P_Today + "') ";
            }
            if (!string.IsNullOrEmpty(this.ddl_DataBase_Ip_Romote.SelectedValue))
            {
                wheresql += " and (" + database_missing_index.TableName + "." + database_missing_index._DATABASE_IP_ROMOTE + " = '" + this.ddl_DataBase_Ip_Romote.SelectedValue + "') ";
            }
            if (!string.IsNullOrEmpty(this.ddl_DataBase_Name.SelectedValue))
            {
                wheresql += " and (" + database_missing_index.TableName + "." + database_missing_index._DATABASE_NAME + " = '" + this.ddl_DataBase_Name.SelectedValue + "') ";
            }

            database_missing_index.WhereSql = wheresql;
            database_missing_index.OrderBy = this.P_OrderBy;
            DataTable dtLog = database_missing_index.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //==========================匹配认领人==========================
            Business.DataBase.DataBase_Table_My.MatchMine(dtLog, this.CurrentWebManagerName);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/DataBase/Missing_Index.aspx?page={page}" +
                "&keyword=" + Server.UrlEncode(this.txtKeyword.Text) +
                "&orderby=" + this.P_OrderBy +
                "&DataBase_Ip_Romote=" + Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) +
                "&DataBase_Name=" + Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) + "&today=" + Server.UrlEncode(this.P_Today);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();

            //--------------------------------------------------------------
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_ID, database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
            database_owner.CacheTime = 1440;
            DataTable oDt_database_owner = database_owner.Select();
            dtLog.Columns.Add(new DataColumn("DataBase_Id", typeof(int)));
            //dtLog.Columns.Add(new DataColumn("Table_Name", typeof(string)));

            dtLog.Columns.Add(new DataColumn("Space_Allocation_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Used_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Index_Used_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Available_String", typeof(string)));

            foreach (DataRow oDr in dtLog.Rows)
            {
                string[] parameters = oDr["statement"].ToString().Replace("[", "").Replace("]", "").Split('.');
                oDr["Table_Name"] = parameters[2];
                DataRow[] oDrs_database_owner = oDt_database_owner.Select(database_owner._DATABASE_IP_ROMOTE + "='" + oDr["database_ip_romote"].ToString() + "' AND " + database_owner._DATABASE_NAME + "='" + parameters[0] + "'");
                if (oDrs_database_owner != null && oDrs_database_owner.Length > 0)
                {
                    oDr["DataBase_Id"] = oDrs_database_owner[0][database_owner._DATABASE_ID].ToString();
                }

                decimal Space_Allocation = decimal.Parse(oDr["Space_Allocation"].ToString() == "" ? "0" : oDr["Space_Allocation"].ToString());
                decimal Space_Used = decimal.Parse(oDr["Space_Used"].ToString() == "" ? "0" : oDr["Space_Used"].ToString());
                decimal Space_Index_Used = decimal.Parse(oDr["Space_Index_Used"].ToString() == "" ? "0" : oDr["Space_Index_Used"].ToString());
                decimal Space_Available = decimal.Parse(oDr["Space_Available"].ToString() == "" ? "0" : oDr["Space_Available"].ToString());
                oDr["Space_Allocation_String"] = this.GetSpace(Space_Allocation);
                oDr["Space_Used_String"] = this.GetSpace(Space_Used);
                oDr["Space_Index_Used_String"] = this.GetSpace(Space_Index_Used);
                oDr["Space_Available_String"] = this.GetSpace(Space_Available);
            }
            //--------------------------------------------------------------
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion
            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 10; i >= 0; i--)
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
        private string GetSpace(decimal space)
        {
            string Result = "";
            if (space > 1024 * 1024)//GB
            {
                Result = "<font color=red>" + (space / (1024 * 1024)).ToString("f2") + "</font> GB";
            }
            else if (space > 1024)//MB
            {
                Result = "<font color=blue>" + (space / (1024)).ToString("f2") + "</font> MB";
            }
            else if (space > 0)//KB
            {
                Result = "<font color=green>" + (space / (1)).ToString("f2") + "</font> KB";
            }
            return Result;
        }
    }
}
