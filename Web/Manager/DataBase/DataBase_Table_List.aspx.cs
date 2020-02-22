using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Table_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        private string P_DataBase_Name = "";
        private string P_DataBase_Ip_Romote = "";
        private string P_Today = "";
        private string P_Keyword = "";
        public string P_OrderBy = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Table_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "RowCounts_Increasing_Rate";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.P_Today = this.QueryString("today");
                this.P_Keyword = this.QueryString("keyword");
                this.P_DataBase_Ip_Romote = this.QueryString("DataBase_Ip_Romote");
                this.P_DataBase_Name = this.QueryString("DataBase_Name");

                if (string.IsNullOrEmpty(this.P_Today))
                {
                    this.P_Today = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                }
                this.txtToday.Text = this.P_Today;
                this.txtKeyword.Text = this.P_Keyword;

                Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
                database_table.SelectColumns = new string[] { database_table._DATABASE_IP_ROMOTE };
                database_table.Distinct = true;
                database_table.CacheTime = 1440;
                DataTable oDt_ip = database_table.Select();
                this.ddl_DataBase_Ip_Romote.DataTextField = database_table._DATABASE_IP_ROMOTE;
                this.ddl_DataBase_Ip_Romote.DataValueField = database_table._DATABASE_IP_ROMOTE;
                this.ddl_DataBase_Ip_Romote.DataSource = oDt_ip;
                this.ddl_DataBase_Ip_Romote.DataBind();
                this.ddl_DataBase_Ip_Romote.Items.Add(new ListItem("-请选择-", ""));
                this.ddl_DataBase_Ip_Romote.SelectedValue = this.P_DataBase_Ip_Romote;
                if (!string.IsNullOrEmpty(this.P_DataBase_Ip_Romote))
                {
                    this.ddl_DataBase_Ip_Romote.SelectedValue = this.P_DataBase_Ip_Romote;
                }

                Entity.TEAMTOOL.DATABASE_TABLE database_table0 = new Entity.TEAMTOOL.DATABASE_TABLE();
                database_table0.SelectColumns = new string[] { database_table0._DATABASE_NAME };
                database_table0.Distinct = true;
                database_table0.CacheTime = 1440;
                DataTable oDt_name = database_table0.Select();
                this.ddl_DataBase_Name.DataTextField = database_table0._DATABASE_NAME;
                this.ddl_DataBase_Name.DataValueField = database_table0._DATABASE_NAME;
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


            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            string wheresql = "1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                wheresql += " and (" + database_table._TABLE_NAME + " like '%" + this.txtKeyword.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtToday.Text))
            {
                wheresql += " and (" + database_table._COUNTDATE + " = '" + this.txtToday.Text + "') ";
            }
            if (!string.IsNullOrEmpty(this.ddl_DataBase_Ip_Romote.SelectedValue))
            {
                wheresql += " and (" + database_table._DATABASE_IP_ROMOTE + " = '" + this.ddl_DataBase_Ip_Romote.SelectedValue + "') ";
            }
            if (!string.IsNullOrEmpty(this.ddl_DataBase_Name.SelectedValue))
            {
                wheresql += " and (" + database_table._DATABASE_NAME + " = '" + this.ddl_DataBase_Name.SelectedValue + "') ";
            }

            database_table.WhereSql = wheresql;
            database_table.OrderBy = this.P_OrderBy + " DESC ";
            database_table.CacheTime = 180;
            DataTable dtLog = database_table.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //==========================================================
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { 
                database_owner._DATABASE_ID, 
                database_owner._DATABASE_IP_ROMOTE, 
                database_owner._DATABASE_NAME, 
                database_owner._DATABASE_REMARK};
            database_owner.CacheTime = 1440;
            DataTable oDt_database_owner = database_owner.Select();
            dtLog.Columns.Add(new DataColumn("DataBase_Id", typeof(int)));
            dtLog.Columns.Add(new DataColumn("DataBase_Remark", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Allocation_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Used_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Index_Used_String", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Space_Available_String", typeof(string)));
            foreach (DataRow oDr_log in dtLog.Rows)
            {
                DataRow[] oDrs = oDt_database_owner.Select("DataBase_IP_Romote='" + oDr_log[database_table._DATABASE_IP_ROMOTE].ToString() + "' and DataBase_Name='" + oDr_log[database_table._DATABASE_NAME].ToString() + "'");
                if (oDrs != null && oDrs.Length > 0)
                {
                    oDr_log["DataBase_Id"] = oDrs[0]["DataBase_Id"].ToString();
                    oDr_log["DataBase_Remark"] = oDrs[0]["DataBase_Remark"].ToString();
                }
                decimal Space_Allocation = 0;
                if (!string.IsNullOrEmpty(oDr_log["Space_Allocation"].ToString()))
                {
                    Space_Allocation=decimal.Parse(oDr_log["Space_Allocation"].ToString());
                }
                decimal Space_Used = 0;
                if (!string.IsNullOrEmpty(oDr_log["Space_Used"].ToString()))
                {
                    Space_Used = decimal.Parse(oDr_log["Space_Used"].ToString());
                } 
                decimal Space_Index_Used = 0;
                if (!string.IsNullOrEmpty(oDr_log["Space_Index_Used"].ToString()))
                {
                    Space_Index_Used = decimal.Parse(oDr_log["Space_Index_Used"].ToString());
                }
                decimal Space_Available = 0;
                if (!string.IsNullOrEmpty(oDr_log["Space_Available"].ToString()))
                {
                    Space_Available = decimal.Parse(oDr_log["Space_Available"].ToString());
                }
                oDr_log["Space_Allocation_String"] = this.GetSpace(Space_Allocation);
                oDr_log["Space_Used_String"] = this.GetSpace(Space_Used);
                oDr_log["Space_Index_Used_String"] = this.GetSpace(Space_Index_Used);
                oDr_log["Space_Available_String"] = this.GetSpace(Space_Available);
            }
            dtLog.AcceptChanges();
            //==========================匹配认领人==========================
            Business.DataBase.DataBase_Table_My.MatchMine(dtLog,this.CurrentWebManagerName);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Table_List.aspx?page={page}" +
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
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion
            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 10; i > 0; i--)
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
