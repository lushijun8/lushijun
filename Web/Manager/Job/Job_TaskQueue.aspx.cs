using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_TaskQueue : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_TaskQueue.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                    this.P_page = int.Parse(QueryString("page"));

                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;

            Entity.TUAN.TUANTASKQUEUE tuantaskqueue = new Entity.TUAN.TUANTASKQUEUE();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" +
                    tuantaskqueue._CREATOR + " = '" + this.txtKeyword.Text + "' or " +
                    tuantaskqueue._URL + " like '%" + this.txtKeyword.Text + "%'  or " +
                    tuantaskqueue._REQUESTURL + " like '%" + this.txtKeyword.Text + "%'  or " +
                    tuantaskqueue._XML + " like '%" + this.txtKeyword.Text + "%' ) ";
            }


            tuantaskqueue.WhereSql = wheresql;
            tuantaskqueue.OrderBy = tuantaskqueue._ID + " DESC ";
            DataTable oDt_tuantaskqueue = tuantaskqueue.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            DataColumn oDc_tuantaskqueue = new DataColumn("database_name", typeof(string));
            oDc_tuantaskqueue.DefaultValue = "正式";
            oDt_tuantaskqueue.Columns.Add(oDc_tuantaskqueue);
            if (this.P_page == 1)
            {
                Entity.TUAN_TEST.TUANTASKQUEUE tuantaskqueue_test = new Entity.TUAN_TEST.TUANTASKQUEUE();
                tuantaskqueue_test.STATE = 0;
                tuantaskqueue_test.WhereSql = wheresql;
                tuantaskqueue_test.OrderBy = tuantaskqueue_test._ID + " DESC ";
                int LogCount_test = 0;
                DataTable oDt_tuantaskqueue_test = tuantaskqueue_test.SelectByPaging(_PageSize, this.P_page - 1, out LogCount_test);

                DataColumn oDc_tuantaskqueue_test = new DataColumn("database_name", typeof(string));
                oDc_tuantaskqueue_test.DefaultValue = "测试";
                oDt_tuantaskqueue_test.Columns.Add(oDc_tuantaskqueue_test);

                foreach (DataRow oDr_tuantaskqueue_test in oDt_tuantaskqueue_test.Rows)
                {
                    DataRow oDr_New = oDt_tuantaskqueue.NewRow();
                    foreach (DataColumn oDc in oDt_tuantaskqueue_test.Columns)
                    {
                        if (oDt_tuantaskqueue.Columns.Contains(oDc.ColumnName))
                        {
                            oDr_New[oDc.ColumnName] = oDr_tuantaskqueue_test[oDc.ColumnName];
                        }
                    }
                    oDt_tuantaskqueue.Rows.Add(oDr_New);
                }
            }
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Job/Job_TaskQueue.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            string RequestUrl = "";
            int BackGroundColor_Index = -1;
            string[] BackGroundColor = new string[] { "#ff0000", "#000000", "#ff6a00", "#970f0f", "#ff00dc", "#009933", "#b200ff", "#000000" };
            foreach (DataRow oDr in oDt_tuantaskqueue.Rows)
            {
                if (oDr["RequestUrl"].ToString() != RequestUrl)
                {
                    BackGroundColor_Index++;
                    if (BackGroundColor_Index >= BackGroundColor.Length)
                    {
                        BackGroundColor_Index = 0;
                    }
                } 
                RequestUrl = oDr["RequestUrl"].ToString();
                oDr["RequestUrl"] = "<font style=\"color:" + BackGroundColor[BackGroundColor_Index] + "\">" + oDr["RequestUrl"].ToString() + "</font>";

            }
            DataView oDv_tuantaskqueue = oDt_tuantaskqueue.DefaultView;
            oDv_tuantaskqueue.Sort = "State ASC,id DESC";
            this.rptLog.DataSource = oDv_tuantaskqueue;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

    }
}
