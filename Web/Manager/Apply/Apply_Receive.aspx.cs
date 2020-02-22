using System;
using System.Collections.Generic;

using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Apply
{
    public partial class Apply_Receive : Business.ManageWeb
    {
        private string P_apply_WebManager_name = "";
        private string P_apply_Year = "";
        private string P_apply_Month = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Apply/Apply_Receive.aspx");
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
                this.P_apply_WebManager_name = v[0];
                this.P_apply_Year = v[1];
                this.P_apply_Month = v[2];
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.APPLY apply = new Entity.TEAMTOOL.APPLY();
            apply.APPLY_WEBMANAGER_NAME = this.P_apply_WebManager_name;
            apply.APPLY_YEAR = int.Parse(this.P_apply_Year);
            apply.APPLY_MONTH = int.Parse(this.P_apply_Month);
            apply.APPLY_RECEIVE = 1;
            if (apply.Update() == true)
            {
                this.RedirectConfirm("领取成功！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("领取失败！", this.P_BackUrl);
            }
        }
    }
}