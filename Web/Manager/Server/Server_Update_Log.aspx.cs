using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Server
{
    public partial class Server_Update_Log : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Server/Server_Update_Log.aspx");
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

            Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
            server_update_log.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            server_update_log.SelectColumns = new string[] { "SERVER_UPDATE_LOG.*", "WebManager_RealName" };
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" + server_update_log._IP + " = '" + this.txtKeyword.Text + "' or " + server_update_log._USERNAME + " = '" + this.txtKeyword.Text + "'  or " + server_update_log._SERVERNAME + " like '%" + this.txtKeyword.Text + "%') ";
            }
            server_update_log.WhereSql = wheresql;
            server_update_log.OrderBy = server_update_log.TableName + "." + server_update_log._ID + " DESC ";
            DataTable dtLog = server_update_log.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Server/Server_Update_Log.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

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
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
