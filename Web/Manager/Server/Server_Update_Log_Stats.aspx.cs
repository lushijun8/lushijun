using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Web.Manager.Server
{
    public partial class Server_Update_Log_Stats : Business.ManageWeb
    {
        public string P_website = "";
        public string P_CreateTime0 = "";
        public string P_CreateTime1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Server/server_update_log_Stats.aspx");
            if (!Page.IsPostBack)
            {
                this.P_website = QueryString("website");
                this.P_CreateTime0 = QueryString("createtime0");
                this.P_CreateTime1 = QueryString("createtime1");

                this.txtCreateTime0.Text = System.DateTime.Now.AddDays(-7).ToShortDateString();
                this.txtCreateTime1.Text = System.DateTime.Now.ToShortDateString();

                Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
                server_update_log.SelectColumns = new string[] { server_update_log._SERVERNAME };
                server_update_log.Distinct = true;
                server_update_log.CacheTime = 1440;
                server_update_log.WhereSql = "(" + server_update_log._SERVERNAME + " <>'' AND " + server_update_log._SERVERNAME + " IS NOT NULL )";
                DataTable oDt = server_update_log.Select();
                this.ddl_WebSite.DataSource = oDt;
                this.ddl_WebSite.DataTextField = server_update_log._SERVERNAME;
                this.ddl_WebSite.DataValueField = server_update_log._SERVERNAME;
                this.ddl_WebSite.DataBind();

                string ItemValue = "";
                this.ddl_WebSite.Items.Add(new ListItem("-请选择-", ItemValue));
                this.ddl_WebSite.SelectedValue = ItemValue;
                if (!string.IsNullOrEmpty(this.P_website))
                {
                    if (this.ddl_WebSite.Items.FindByValue(this.P_website) != null)
                    {
                        this.ddl_WebSite.SelectedValue = this.P_website;
                    }
                }

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            string GrouBy = this.ddl_GroupBy.SelectedValue;
            string Sql = "SELECT TOP 500 " + GrouBy + ", COUNT(1) AS COUNTS FROM [Server_Update_Log] left join Admin_WebManager on Admin_WebManager.WebManager_name=username WHERE 1=1 ";
            Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
            if (this.txtCreateTime0.Text.Trim() != "")
            {
                Sql += " AND  " + server_update_log._CREATETIME + ">'" + this.txtCreateTime0.Text + "' ";
            }
            if (this.txtCreateTime1.Text.Trim() != "")
            {
                Sql += " AND  " + server_update_log._CREATETIME + "<'" + this.txtCreateTime1.Text + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(this.ddl_WebSite.SelectedValue))
            {

                Sql += " AND  " + server_update_log._SERVERNAME + "='" + this.ddl_WebSite.SelectedValue + "'";
            }

            Sql += " GROUP BY " + GrouBy + " ORDER BY COUNTS DESC";
            string cacheName = Com.Common.EncDec.PasswordEncrypto(Sql);
            DataTable oDt = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName, 120);
            if (oDt == null)
            {
                oDt = server_update_log.Database_Owner.ExecuteDataSet(CommandType.Text, Sql).Tables[0];
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName, oDt, 120);
            }
            this.rptLog.DataSource = oDt;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
