using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Apply
{
    public partial class Apply_Add : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Apply/Apply_Add.aspx");
            if (!Page.IsPostBack)
            {
                this.txtDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (System.DateTime.Now.Day > 10)
            {
                string msg = "添加失败！请在每月1号至10号提交申请！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            if (this.cbPen.Checked == false && this.cbPenLead.Checked == false && this.cbBook.Checked == false && this.cbGlue.Checked == false && this.cbNotePaper.Checked == false)
            {
                string msg = "添加失败！至少申请一样物品！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            DateTime Apply_Date = DateTime.Parse(this.txtDate.Text);
            Entity.TEAMTOOL.APPLY apply = new Entity.TEAMTOOL.APPLY();
            apply.APPLY_WEBMANAGER_NAME = this.CurrentWebManagerName; ;
            apply.APPLY_YEAR = Apply_Date.Year;
            apply.APPLY_MONTH = Apply_Date.Month;
            if (apply.SelectTop1() != null)
            {
                string msg =  Apply_Date.Year.ToString()+"年"+Apply_Date.Month.ToString()+"月份你已经申请过了，请删除此月数据后再申请。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            Entity.TEAMTOOL.APPLY apply_new = new Entity.TEAMTOOL.APPLY();
            apply_new.APPLY_WEBMANAGER_NAME = this.CurrentWebManagerName;
            apply_new.APPLY_YEAR = Apply_Date.Year;
            apply_new.APPLY_MONTH = Apply_Date.Month;
            apply_new.APPLY_WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
            apply_new.APPLY_PEN = this.cbPen.Checked == true ? 1 : 0;
            apply_new.APPLY_PENLEAD = this.cbPenLead.Checked == true ? 1 : 0; 
            apply_new.APPLY_BOOK = this.cbBook.Checked == true ? 1 : 0;
            apply_new.APPLY_GLUE = this.cbGlue.Checked == true ? 1 : 0;
            apply_new.APPLY_NOTEPAPER = this.cbNotePaper.Checked == true ? 1 : 0; 
            apply_new.APPLY_LOCK = 0;
            apply_new.APPLY_RECEIVE = 0;
            apply_new.APPLY_CREATETIME = System.DateTime.Now;
            if (apply_new.Insert() == false)
            {
                string msg = "添加失败！你可能已经申请过了！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            else
            {
                string msg = "添加成功！";

                #region 发邮件
                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailUserList = "lushijun@fang.com";
                mail.CopyToMailUserList = this.CurrentWebManagerName + "@fang.com";
                mail.MailTitle = this.CurrentWebManagerRealName + " 申请了办公用品,请及时处理[系统邮件请勿回复]";
                mail.MailContent = "Hi!!&nbsp;&nbsp;<br/><br/>" +
                    "&nbsp;&nbsp;“" + this.CurrentWebManagerRealName + "”申请了办公用品,请 <a href=\"" + Business.Config.HostUrl + "/Manager/Apply/Apply_List.aspx\" target=\"_blank\">点击这里</a> 查看！";
                if (!mail.SendOneMailByHTML())
                {
                    Business.MallLog.Create(0, "Share", "TeamTool发送:申请了办公用品~邮件失败", "发送失败", Request.UserHostAddress);
                }
                #endregion

                this.RedirectConfirm(msg, Business.Config.HostUrl + "/Manager/Apply/Apply_List_My.aspx");
                this.ltrMsg.Text = msg;
                return;
            }
        }
    }
}