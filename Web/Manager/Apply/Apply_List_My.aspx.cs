using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Apply
{
    public partial class Apply_List_My : Business.ManageWeb
    {
        public string P_OrderBy = "";
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Apply/Apply_List_My.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "Apply_CreateTime desc";
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
            int _PageSize = 20;
            this.LogCount = 0;
            Entity.TEAMTOOL.APPLY apply = new Entity.TEAMTOOL.APPLY();
            apply.APPLY_WEBMANAGER_NAME = (this.QueryString("v") == "" ? this.CurrentWebManagerName : this.QueryString("v"));
            apply.Distinct = false;
            apply.OrderBy = this.P_OrderBy;
            DataTable oDt_apply = apply.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Apply/Apply_List_My.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_OrderBy);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 
            this.rptLog.DataSource = oDt_apply;
            this.rptLog.DataBind();
            #endregion

        }
    }
}
