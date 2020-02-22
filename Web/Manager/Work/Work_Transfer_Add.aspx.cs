using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Work
{
    public partial class Work_Transfer_Add : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        public int _PageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Work/Work_Transfer_Add.aspx");
            if (this.QueryString("page") != "")
            {
                this.P_page = int.Parse(this.QueryString("page"));
            }
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME, admin_webmanager._WEBMANAGER_REALNAME };
                admin_webmanager.CacheTime = 60;
                admin_webmanager.WhereSql = admin_webmanager._WEBMANAGER_NAME + "<>'" + this.CurrentWebManagerName + "'";
                DataTable oDt_admin_webmanager = admin_webmanager.Select();

                this.ddl_Work_To_Webmanager_Name.DataTextField = admin_webmanager._WEBMANAGER_REALNAME;
                this.ddl_Work_To_Webmanager_Name.DataValueField = admin_webmanager._WEBMANAGER_NAME;

                this.ddl_Work_To_Webmanager_Name.DataSource = oDt_admin_webmanager;
                this.ddl_Work_To_Webmanager_Name.DataBind();

                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.WORK_TRANSFER work_transfer = new Entity.TEAMTOOL.WORK_TRANSFER();
            work_transfer.OrderBy = work_transfer._ID + " DESC";
            if(this.CurrentIsAdmin==false)
            {
                work_transfer.WhereSql = "(" + work_transfer._WORK_FROM_WEBMANAGER_NAME + " ='" + this.CurrentWebManagerName + "' OR " + work_transfer._WORK_TO_WEBMANAGER_NAME + " ='" + this.CurrentWebManagerName + "' )";
            }
            DataTable oDt_work_transfer = work_transfer.SelectByPaging(this._PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Work/Work_Transfer_Add.aspx?page={page}";

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================


            this.rptLog.DataSource = oDt_work_transfer;
            this.rptLog.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Entity.TEAMTOOL.WORK_TRANSFER work_transfer_select = new Entity.TEAMTOOL.WORK_TRANSFER();
            work_transfer_select.WhereSql =
                "(" + work_transfer_select._WORK_TO_WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "' OR " +
                work_transfer_select._WORK_FROM_WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "')";
            work_transfer_select.STATUS = 0;
            if (work_transfer_select.SelectTop1() != null)
            {
                string msg = "你有一个工作交接未处理，请删除或者让“" + work_transfer_select.WORK_TO_WEBMANAGER_REALNAME + "”接收后再提交新的！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }

            Entity.TEAMTOOL.WORK_TRANSFER work_transfer = new Entity.TEAMTOOL.WORK_TRANSFER();
            work_transfer.WORK_FROM_WEBMANAGER_NAME = this.CurrentWebManagerName;
            work_transfer.WORK_FROM_WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
            work_transfer.WORK_TO_WEBMANAGER_NAME = this.ddl_Work_To_Webmanager_Name.SelectedItem.Value;
            work_transfer.WORK_TO_WEBMANAGER_REALNAME = this.ddl_Work_To_Webmanager_Name.SelectedItem.Text;
            work_transfer.TRANSFER_TYPE = int.Parse(this.rbl_Transfer_Type.SelectedItem.Value);
            work_transfer.STATUS = 0;
            work_transfer.CREATETIME = System.DateTime.Now;

            if (work_transfer.Insert() == false)
            {
                string msg = "添加失败！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
            else
            {
                string msg = "添加成功！";
                #region 发邮件
                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailUserList = this.ddl_Work_To_Webmanager_Name.SelectedItem.Value + "@fang.com";
                mail.CopyToMailUserList = this.CurrentWebManagerName + "@fang.com;lushijun@fang.com";
                mail.MailTitle = this.CurrentWebManagerRealName + " 给 " + this.ddl_Work_To_Webmanager_Name.SelectedItem.Text + " 交接了工作，请接收~[系统邮件请勿回复]";
                mail.MailContent = "Hi!!&nbsp;&nbsp;" + this.ddl_Work_To_Webmanager_Name.SelectedItem.Text + " 同学.<br/><br/>" +
                    "&nbsp;&nbsp;“" + this.CurrentWebManagerRealName + "”将TA的TeamTool里认领的工作交接给你，请 <a href=\"" + Business.Config.HostUrl + "/Manager/Work/Work_Transfer_Add.aspx\" target=\"_blank\">点击这里</a> 进行接收！";
                if (!mail.SendOneMailByHTML())
                {
                    Business.MallLog.Create(0, "Share", "TeamTool发送:给你交接了工作，请接收~邮件失败", "发送给" + this.ddl_Work_To_Webmanager_Name.SelectedItem.Value + "失败", Request.UserHostAddress);
                }                 
                #endregion
                this.btnSubmit.Enabled = false;
                this.btnSubmit.BackColor = System.Drawing.Color.Gray;
                this.ltrMsg.Text = msg;
                this.BindData();
                return;
            }
        }
    }
}