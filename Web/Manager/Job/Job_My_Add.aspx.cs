using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_My_Add :  Business.ManageWeb
    {
        protected string P_JobName = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_My_Add.aspx");

            if (!Page.IsPostBack)
            {
                this.P_BackUrl = this.QueryString("BackUrl");
                if (string.IsNullOrEmpty(this.P_BackUrl))
                {
                    if (Request.UrlReferrer != null)
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
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                    }

                }
                if (!string.IsNullOrEmpty(this.QueryString("JobName")))
                {
                    this.P_JobName = Com.Common.EncDec.Decrypt(this.QueryString("JobName"), this.Encrypt_key); 
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("认领失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.JOB_MY job_my = new Entity.TEAMTOOL.JOB_MY();
            job_my.WEBMANAGER_NAME = this.CurrentWebManagerName;
            job_my.JOBNAME = this.P_JobName;
            job_my.CREATETIME = System.DateTime.Now;

            if (job_my.Insert() == true)
            {
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                this.RedirectConfirm("认领成功！" , this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("认领失败,可能您已认领此作业！", this.P_BackUrl);
            }
        }
    }
}