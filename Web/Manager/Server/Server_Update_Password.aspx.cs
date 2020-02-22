using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Server
{
    public partial class Server_Update_Password : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Server/Server_Update_Password.aspx");
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

            Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
            server_update_password.LEFT_JOIN_ADMIN_WEBMANAGER_CREATE_USERNAME = true;
            server_update_password.LEFT_JOIN_ADMIN_WEBMANAGER_DECRYPT_USERNAME = true;
            server_update_password.SelectColumns = new string[] { "SERVER_UPDATE_PASSWORD.*", "ADMIN_WEBMANAGER.WebManager_RealName", "ADMIN_WEBMANAGER_DECRYPT_USERNAME.WebManager_RealName as WebManager_RealName_Decrypt_UserName" };
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" + server_update_password._SERVERNAME + " like '%" + this.txtKeyword.Text + "%' or " + server_update_password._CREATE_IP + " like '%" + this.txtKeyword.Text + "%'  or " + server_update_password._CREATE_USERNAME + " like '%" + this.txtKeyword.Text + "%') ";
            }
            server_update_password.WhereSql = wheresql;
            server_update_password.OrderBy = server_update_password.TableName + "." + server_update_password._ID + " DESC ";
            DataTable dtLog = server_update_password.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Server/server_update_password.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            dtLog.Columns.Add(new DataColumn("hidden", typeof(int)));
            if (this.P_page == 1)
            {
                string Hour = System.DateTime.Now.Hour.ToString().PadLeft(2, '0');
                string Minute = System.DateTime.Now.Minute.ToString().PadLeft(2, '0');
                int now = int.Parse(Hour + Minute);
                if ((now >= 0 && now <= 900) || (now >= 1200 && now <= 1310) || (now >= 1745 && now <= 2359))
                {
                    dtLog.Rows[0]["hidden"] = "0";
                }
                else
                {
                    if (this.CurrentIsAdmin == false)
                    {
                        dtLog.Rows[0]["hidden"] = "1";
                    }
                }
            }
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
