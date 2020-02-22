using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Task
{
    public partial class Task_List : Business.ManageWeb
    {
        public string P_OrderBy = "";
        public string P_Task_Finished = "";
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        public int LogCount_finished = 0;
        public int _PageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Task/Task_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            this.P_Task_Finished = this.QueryString("Task_Finished");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "Task_CreateTime desc";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            Entity.TEAMTOOL.TASK task = new Entity.TEAMTOOL.TASK();
            task.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            task.SelectColumns = new string[] { "TASK.*", "WebManager_RealName" };
            task.Distinct = false;
            if (!string.IsNullOrEmpty(this.P_Task_Finished))
            {
                task.TASK_FINISHED = int.Parse(this.P_Task_Finished);
            }
            task.OrderBy = task.TableName + "." + this.P_OrderBy;
            DataTable dt_task = task.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Task/Task_List.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_OrderBy) + "&Task_Finished=" + this.P_Task_Finished;

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
           this.LogCount_finished=int.Parse( task.Database_Writer.ExecuteDataSet(CommandType.Text, "select count(1) from task where task_finished=1").Tables[0].Rows[0][0].ToString());
            //this.LogCount = dt_task.Rows.Count;
            this.rptLog.DataSource = dt_task;
            this.rptLog.DataBind();
            #endregion

        }
    }
}
