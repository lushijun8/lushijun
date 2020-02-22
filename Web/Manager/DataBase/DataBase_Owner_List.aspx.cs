using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public int AllCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_List.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                    this.P_page = int.Parse(QueryString("page"));
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定
            int _PageSize = 100;
            //列表 
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { 
                database_owner._DATABASE_ID,
                database_owner._DATABASE_IP_LOCAL,
                database_owner._DATABASE_IP_ROMOTE,
                database_owner._DATABASE_VIP_LOCAL, 
                database_owner._DATABASE_VIP_ROMOTE, 
                database_owner._DATABASE_IP_SPECIAL, 
                database_owner._DATABASE_IP_RECOVERY,
                database_owner._DATABASE_NAME,
                database_owner._DATABASE_REMARK, 
                database_owner._DATABASE_IS_MAIN, 
                database_owner._DATABASE_ADMIN_USER,
                database_owner._DATABASE_ADMIN_PASSWORD, 
                database_owner._DATABASE_READER_USER, 
                database_owner._DATABASE_READER_PASSWORD, 
                database_owner._DATABASE_WRITER_USER,
                database_owner._DATABASE_WRITER_PASSWORD ,
                database_owner._LAST_UPDATE_TIME  ,
                database_owner._SPACE_USED 
            };
            database_owner.OrderBy = database_owner._DATABASE_NAME + " ASC";
            database_owner.CacheTime = 120;
            DataTable dtLog = database_owner.SelectByPaging(_PageSize, this.P_page - 1, out AllCount);

            dtLog.Columns.Add(new DataColumn("Space_Used_String", typeof(string)));
            foreach (DataRow oDr_log in dtLog.Rows)
            {
                decimal Space_Used = decimal.Parse(string.IsNullOrEmpty(oDr_log["Space_Used"].ToString()) ? "0" : oDr_log["Space_Used"].ToString());
                oDr_log["Space_Used_String"] = this.GetSpace(Space_Used);
            }
            dtLog.AcceptChanges();

            //=====================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.Url = Business.Config.HostUrl + "/Manager/DataBase/DataBase_Owner_List.aspx?page={page}";
            page.ModelCount = this.AllCount;
            if (this.AllCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            this.rptDataBase.DataSource = dtLog;
            this.rptDataBase.DataBind();
            #endregion
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(Business.DataConfiguration.InitConfig.UpdateConfig(Server.MapPath("/ConfigFile/dataconfiguration.config"))==true)
            {
                this.AlertScript("固化成功！");
            }
            else
            {
                this.AlertScript("固化失败！");
            }
            this.BindData();
        }
    }
}