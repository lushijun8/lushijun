using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_List_SqlServer : Business.ManageWeb
    {
        public string P_Today = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_orderby = "";
        public string P_DataBase = "";
        public string P_Run_Status = "";
        public int LogCount = 0;
        public int _PageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_List_SqlServer.aspx");
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyyMMdd");
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
                this.P_DataBase = QueryString("DataBase");
                this.P_Run_Status = QueryString("Run_Status");

                this.cbRun_Status.Checked = (this.P_Run_Status == "1" ? true : false);
                this.txtKeyword.Text = this.P_keyword;

                Entity.TEAMTOOL.JOB_LOG job_log = new Entity.TEAMTOOL.JOB_LOG();
                job_log.Distinct =true;
                job_log.SelectColumns = new string[] { job_log._DATABASE_IP + "+'|'+" + job_log._DATABASE_NAME + " as " + job_log._DATABASE_NAME };
                job_log.CacheTime = 1440;
                DataTable oDt_job_log = job_log.Select();

                this.ddlDataBase.DataSource = oDt_job_log;
                this.ddlDataBase.DataTextField = job_log._DATABASE_NAME;
                this.ddlDataBase.DataValueField = job_log._DATABASE_NAME;
                this.ddlDataBase.DataBind();

                this.ddlDataBase.Items.Add(new ListItem("-请选择-", ""));
                if (this.ddlDataBase.Items.FindByValue(this.P_DataBase) != null)
                {
                    this.ddlDataBase.Items.FindByValue(this.P_DataBase).Selected = true;
                }

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;

            Entity.TEAMTOOL.JOB_LOG job_log = new Entity.TEAMTOOL.JOB_LOG();
            string wheresql = " 1=1 ";//
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                wheresql += " AND (" +
                    job_log._DATABASE_IP + " like '%" + this.txtKeyword.Text + "%' or " +
                    job_log._DATABASE_NAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    job_log._NAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    job_log._STEP_NAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    job_log._MESSAGE + " like '%" + this.txtKeyword.Text + "%' or " +
                    job_log._DESCRIPTION + " like '%" + this.txtKeyword.Text + "%') ";
            }
            job_log.WhereSql = wheresql;
            job_log.RUN_DATE = this.P_Today;
            if (this.cbRun_Status.Checked == true)
            {
                job_log.RUN_STATUS = 0;
            }
            if (!string.IsNullOrEmpty(this.ddlDataBase.SelectedItem.Value))
            {
                string[] DataBases=this.ddlDataBase.SelectedItem.Value.Split('|');
                job_log.DATABASE_IP = DataBases[0];
                job_log.DATABASE_NAME = DataBases[1];
            }
            job_log.OrderBy = job_log._RUN_DATE + "+" + job_log._RUN_TIME + " DESC";
            DataTable dtLog = job_log.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_orderby) + "&today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&DataBase=" + Server.UrlEncode(this.ddlDataBase.SelectedItem.Value) + "&Run_Status=" + (this.cbRun_Status.Checked == true ? "1" : "0");

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
            oDt_Date.Columns.Add(new DataColumn("Date1", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 9; i >= 0; i--)
            {
                DataRow oDr_New = oDt_Date.NewRow();
                oDr_New["Date"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyyMMdd");
                oDr_New["Date1"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyy-MM-dd");
                if (System.DateTime.Now.AddDays(-1 * i).ToString("yyyyMMdd") == this.P_Today)
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
