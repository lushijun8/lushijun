using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Bill
{
    public partial class Bill_Delete : Business.ManageWeb
    {
        private string P_bill_WebManager_name = "";
        private string P_bill_Date = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Bill/Bill_Delete.aspx");
            this.P_BackUrl = this.QueryString("BackUrl"); 
            if (string.IsNullOrEmpty(this.P_BackUrl))
            {
                if (Request.UrlReferrer != null)
                {
                    this.P_BackUrl = Request.UrlReferrer.ToString();
                }
                else
                {
                    this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                }
            }
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                this.P_bill_WebManager_name = v[0];
                this.P_bill_Date = v[1];
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.BILL bill = new Entity.TEAMTOOL.BILL();
            bill.BILL_WEBMANAGER_NAME = this.P_bill_WebManager_name;
            bill.BILL_DATE = DateTime.Parse(this.P_bill_Date);
            if (bill.Delete() == true)
            {
                this.RedirectConfirm("删除成功！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("删除失败！", this.P_BackUrl);
            }
        }
    }
}