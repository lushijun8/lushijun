using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Bill
{
    public partial class Bill_Add : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Bill/Bill_Add.aspx");
            if (!Page.IsPostBack)
            {
                //this.txt_Bill_Date.Text = System.DateTime.Now.ToShortDateString();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            DateTime Bill_Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            try
            {
                Bill_Date = DateTime.Parse(this.txt_Bill_Date.Text);
            }
            catch
            {
                string msg = "请填写正确日期。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            int Bill_Total_Money = 0;
            try
            {
                Bill_Total_Money = int.Parse(this.txt_Bill_Total_Money.Text);
            }
            catch
            {
                string msg = "请填写整数的金额。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            if (this.txt_Bill_Reason.Text.Trim() == "" || this.txt_Bill_Staff_Worker.Text.Trim() == "")
            {
                string msg = "请填写事由和人员。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            string[] splitchars = new string[] {
                ",",".","/","\\","|","-" ,";",":",
                "，","。","、","|","-" ,"；","："};
            foreach (string splitchar in splitchars)
            {
                if (this.txt_Bill_Staff_Worker.Text.IndexOf(splitchar) >= 0)
                {
                    string msg = "姓名之间请用空格隔开，不能含有特殊符号。";
                    this.AlertScript(msg);
                    this.ltrMsg.Text = msg;
                    return;
                }
            }
            if (this.txt_Bill_Staff_Worker.Text.IndexOf("  ") >= 0)
            {
                string msg = "姓名之间请用一个空格隔开。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            string[] workers = this.txt_Bill_Staff_Worker.Text.Split(' ');
            foreach (string worker in workers)
            {
                if (worker.Length == 1)
                {
                    string msg = "单个姓名内不能含有空格。";
                    this.AlertScript(msg);
                    this.ltrMsg.Text = msg;
                    return;
                }
                if (worker.Length >= 4)
                {
                    string msg = "姓名之前请用空格隔开。";
                    this.AlertScript(msg);
                    this.ltrMsg.Text = msg;
                    return;
                }
            }
            Entity.TEAMTOOL.BILL_LOCK bill_lock = new Entity.TEAMTOOL.BILL_LOCK();
            bill_lock.BILL_LOCK_LEADER_REALNAME = this.CurrentWebManagerLeaderRealName;
            bill_lock.BILL_LOCK_YEAR = Bill_Date.Year;
            bill_lock.BILL_LOCK_MONTH = Bill_Date.Month;
            if (bill_lock.SelectTop1() != null)
            {
                string msg = this.CurrentWebManagerLeaderRealName + " 团队的" + Bill_Date.Month.ToString() + "月份报销已经被锁定，不能再添加" + Bill_Date.Month.ToString() + "月份的了。";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            #region 判断同一天有没有用餐人员重复
            string[] staffs = this.txt_Bill_Staff_Worker.Text.Split(' ');
            foreach(string staff in staffs)
            {
                if (!string.IsNullOrEmpty(staff))
                {
                    Entity.TEAMTOOL.BILL bill = new Entity.TEAMTOOL.BILL();
                    bill.BILL_DATE = Bill_Date;
                    bill.BILL_STAFF_WORKER = "%"+staff+"%";
                    if (bill.SelectTop1() != null)
                    {
                        string msg = "添加失败！" + Bill_Date.ToShortDateString()+ "这天，用餐人员“"+staff+"”已经被“"+bill.BILL_WEBMANAGER_REALNAME+"”添加过！";
                        this.AlertScript(msg);
                        this.ltrMsg.Text = msg;
                        return;
                    }
                }
            }
            #endregion
            Entity.TEAMTOOL.BILL bill_new = new Entity.TEAMTOOL.BILL();
            bill_new.BILL_DATE = Bill_Date;
            bill_new.BILL_WEBMANAGER_NAME = this.CurrentWebManagerName;
            bill_new.BILL_WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
            bill_new.BILL_LEADER_REALNAME = this.CurrentWebManagerLeaderRealName;
            bill_new.BILL_LOCK = 0;
            bill_new.BILL_YEAR = Bill_Date.Year;
            bill_new.BILL_MONTH = Bill_Date.Month;
            bill_new.BILL_REASON = this.txt_Bill_Reason.Text;
            bill_new.BILL_STAFF_WORKER = this.txt_Bill_Staff_Worker.Text;
            bill_new.BILL_TOTAL_MONEY = int.Parse(this.txt_Bill_Total_Money.Text);
            bill_new.BILL_CREATETIME = System.DateTime.Now;
            if (bill_new.Insert() == false)
            {
                string msg = "添加失败！你可能已经添加过这天的报销！";
                this.AlertScript(msg);
                this.ltrMsg.Text = msg;
                return;
            }
            else
            {
                string msg = "添加成功！";
                this.RedirectConfirm(msg, Business.Config.HostUrl + "/Manager/Bill/Bill_List_My.aspx");
                this.ltrMsg.Text = msg;
                return;
            }
        }
    }
}