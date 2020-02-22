using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_Update : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_ISOPEN = "";
        protected string P_TYPE = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_Update.aspx");
            if (this.QueryString("ID") != "")
            {
                this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
            }
            this.P_TYPE = this.QueryString("TYPE");
            this.P_ISOPEN = this.QueryString("ISOPEN");

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
                            this.P_BackUrl = Business.Config.HostUrl + "/Manager/Job/Job_List.aspx";
                        }
                    }
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Job/Job_List.aspx";
                    }

                }
                if (!string.IsNullOrEmpty(this.P_ID) && !string.IsNullOrEmpty(this.P_ISOPEN) && !string.IsNullOrEmpty(this.P_TYPE))
                {
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("执行失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            if (this.P_TYPE == "0")
            {
                Entity.TUAN.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                tuantaskautorun.ISOPEN = int.Parse(this.P_ISOPEN);
                if (tuantaskautorun.Update() == false)
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
                else
                {
                    //记录日志
                    string Remark = "修改字段ISOPEN，改成“" + tuantaskautorun.ISOPEN_ToString + "”;\r\n";
                    Entity.TEAMTOOL.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TEAMTOOL.TUANTASKAUTORUN_LOG();
                    tuantaskautorun_log.DATABASE_NAME = "tuan";
                    tuantaskautorun_log.ID = this.P_ID;
                    tuantaskautorun_log.CREATETIME = System.DateTime.Now;
                    tuantaskautorun_log.WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
                    tuantaskautorun_log.REMARK = Remark;
                    tuantaskautorun_log.Insert();
                    this.RedirectConfirm("执行成功！", this.P_BackUrl);
                }
            }
            else if (this.P_TYPE == "1")
            {
                Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                tuantaskautorun.ISOPEN = int.Parse(this.P_ISOPEN);
                if (tuantaskautorun.Update() == false)
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
                else
                {//记录日志
                    string Remark = "修改字段ISOPEN，改成“" + tuantaskautorun.ISOPEN_ToString + "”;\r\n";
                    Entity.TEAMTOOL.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TEAMTOOL.TUANTASKAUTORUN_LOG();
                    tuantaskautorun_log.DATABASE_NAME = "tuan_test";
                    tuantaskautorun_log.ID = this.P_ID;
                    tuantaskautorun_log.CREATETIME = System.DateTime.Now;
                    tuantaskautorun_log.WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
                    tuantaskautorun_log.REMARK = Remark;
                    tuantaskautorun_log.Insert();
                    this.RedirectConfirm("执行成功！", this.P_BackUrl);
                }
            }
        }
    }
}