using System;
using System.Collections.Generic;


using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Web.Manager.Job
{
    public partial class Job_Edit : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_TYPE = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_Edit.aspx");
            if (this.QueryString("ID") != "")
            {
                this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
            }
            this.P_TYPE = this.QueryString("TYPE");
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
                this.ddl_runType.Attributes.Add("onchange", "javascript:runTypeChange();");
                if (!string.IsNullOrEmpty(this.P_ID) && !string.IsNullOrEmpty(this.P_TYPE))
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
                if (tuantaskautorun.SelectTop1() != null)
                {
                    this.txt_id.Text = tuantaskautorun.ID;
                    this.txt_name.Text = tuantaskautorun.NAME;
                    this.txt_path.Text = tuantaskautorun.PATH;
                    this.ddl_runType.SelectedValue = tuantaskautorun.RUNTYPE_ToString;
                    this.txt_runMiniteOf.Text = tuantaskautorun.RUNMINITEOF_ToString;
                    this.txt_runTimeAt.Text = tuantaskautorun.RUNTIMEAT;
                    this.txt_Author.Text = tuantaskautorun.AUTHOR;
                    this.txt_LastRunTime.Text = tuantaskautorun.LASTRUNTIME_ToString;
                    this.txt_isOpen.Text = tuantaskautorun.ISOPEN_ToString;
                    this.txt_TaskDetail.Text = tuantaskautorun.TASKDETAIL;
                    this.txt_isRunning.Text = tuantaskautorun.ISRUNNING_ToString;
                    this.txt_SvnSourceCode.Text = tuantaskautorun.SVNSOURCECODE;
                    this.txt_CreateTime.Text = tuantaskautorun.CREATETIME_ToString;
                }
                else
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
            }
            else if (this.P_TYPE == "1")
            {
                Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                if (tuantaskautorun.SelectTop1() != null)
                {
                    this.txt_id.Text = tuantaskautorun.ID;
                    this.txt_name.Text = tuantaskautorun.NAME;
                    this.txt_path.Text = tuantaskautorun.PATH;
                    this.ddl_runType.SelectedValue = tuantaskautorun.RUNTYPE_ToString;
                    this.txt_runMiniteOf.Text = tuantaskautorun.RUNMINITEOF_ToString;
                    this.txt_runTimeAt.Text = tuantaskautorun.RUNTIMEAT;
                    this.txt_Author.Text = tuantaskautorun.AUTHOR;
                    this.txt_LastRunTime.Text = tuantaskautorun.LASTRUNTIME_ToString;
                    this.txt_isOpen.Text = tuantaskautorun.ISOPEN_ToString;
                    this.txt_TaskDetail.Text = tuantaskautorun.TASKDETAIL;
                    this.txt_isRunning.Text = tuantaskautorun.ISRUNNING_ToString;
                    this.txt_SvnSourceCode.Text = tuantaskautorun.SVNSOURCECODE;
                    this.txt_CreateTime.Text = tuantaskautorun.CREATETIME_ToString;
                }
                else
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_id.Text) ||
           string.IsNullOrEmpty(this.txt_name.Text) ||
           string.IsNullOrEmpty(this.txt_path.Text) ||
           string.IsNullOrEmpty(this.ddl_runType.SelectedItem.Value) ||
           (string.IsNullOrEmpty(this.txt_runMiniteOf.Text) && string.IsNullOrEmpty(this.txt_runTimeAt.Text)) ||
           string.IsNullOrEmpty(this.txt_Author.Text) ||
           string.IsNullOrEmpty(this.txt_isOpen.Text) ||
           string.IsNullOrEmpty(this.txt_TaskDetail.Text) ||
           string.IsNullOrEmpty(this.txt_SvnSourceCode.Text)
           )
            {
                this.AlertScript("请填写必填项！");
                return;
            }
            if (this.P_TYPE == "0")
            {
                Entity.TUAN.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                if (tuantaskautorun.SelectTop1() != null)
                {
                    Entity.TUAN.TUANTASKAUTORUN tuantaskautorun_update = new Entity.TUAN.TUANTASKAUTORUN();
                    tuantaskautorun_update.ID = this.txt_id.Text;
                    tuantaskautorun_update.NAME = this.txt_name.Text;
                    tuantaskautorun_update.PATH = this.txt_path.Text;
                    tuantaskautorun_update.RUNTYPE = int.Parse(this.ddl_runType.SelectedItem.Value);
                    if (!string.IsNullOrEmpty(this.txt_runMiniteOf.Text))
                    {
                        tuantaskautorun_update.RUNMINITEOF = decimal.Parse(this.txt_runMiniteOf.Text);
                    }
                    tuantaskautorun_update.RUNTIMEAT = this.txt_runTimeAt.Text;
                    tuantaskautorun_update.AUTHOR = this.txt_Author.Text;
                    // tuantaskautorun_update.LASTRUNTIME =DateTime.Parse( this.txt_LastRunTime.Text);
                    tuantaskautorun_update.ISOPEN = int.Parse(this.txt_isOpen.Text);
                    tuantaskautorun_update.TASKDETAIL = this.txt_TaskDetail.Text;
                    //tuantaskautorun_update.ISRUNNING= this.txt_isRunning.Text;
                    tuantaskautorun_update.SVNSOURCECODE = this.txt_SvnSourceCode.Text;

                    if (tuantaskautorun_update.Update() == false)
                    {
                        string msg = "提交失败！";
                        this.AlertScript(msg);
                        this.ltrMsg.Text = msg;
                        return;
                    }
                    else
                    {
                        //记录日志
                        string Remark = "";
                        if (tuantaskautorun.NAME != tuantaskautorun_update.NAME)
                        {
                            Remark += "修改字段NAME，从“" + tuantaskautorun.NAME + "”改成“" + tuantaskautorun_update.NAME + "”;\r\n";
                        }
                        if (tuantaskautorun.PATH != tuantaskautorun_update.PATH)
                        {
                            Remark += "修改字段PATH，从“" + tuantaskautorun.PATH + "”改成“" + tuantaskautorun_update.PATH + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNTYPE_ToString != tuantaskautorun_update.RUNTYPE_ToString)
                        {
                            Remark += "修改字段RUNTYPE，从“" + tuantaskautorun.RUNTYPE_ToString + "”改成“" + tuantaskautorun_update.RUNTYPE_ToString + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNMINITEOF_ToString != tuantaskautorun_update.RUNMINITEOF_ToString)
                        {
                            Remark += "修改字段RUNMINITEOF，从“" + tuantaskautorun.RUNMINITEOF_ToString + "”改成“" + tuantaskautorun_update.RUNMINITEOF_ToString + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNTIMEAT != tuantaskautorun_update.RUNTIMEAT)
                        {
                            Remark += "修改字段RUNTIMEAT，从“" + tuantaskautorun.RUNTIMEAT + "”改成“" + tuantaskautorun_update.RUNTIMEAT + "”;\r\n";
                        }
                        if (tuantaskautorun.AUTHOR != tuantaskautorun_update.AUTHOR)
                        {
                            Remark += "修改字段AUTHOR，从“" + tuantaskautorun.AUTHOR + "”改成“" + tuantaskautorun_update.AUTHOR + "”;\r\n";
                        }
                        if (tuantaskautorun.ISOPEN_ToString != tuantaskautorun_update.ISOPEN_ToString)
                        {
                            Remark += "修改字段ISOPEN，从“" + tuantaskautorun.ISOPEN_ToString + "”改成“" + tuantaskautorun_update.ISOPEN_ToString + "”;\r\n";
                        }

                        if (tuantaskautorun.TASKDETAIL != tuantaskautorun_update.TASKDETAIL)
                        {
                            Remark += "修改字段TASKDETAIL，从“" + tuantaskautorun.TASKDETAIL + "”改成“" + tuantaskautorun_update.TASKDETAIL + "”;\r\n";
                        }
                        if (tuantaskautorun.SVNSOURCECODE != tuantaskautorun_update.SVNSOURCECODE)
                        {
                            Remark += "修改字段SVNSOURCECODE，从“" + tuantaskautorun.SVNSOURCECODE + "”改成“" + tuantaskautorun_update.SVNSOURCECODE + "”;\r\n";
                        }
                        Entity.TEAMTOOL.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TEAMTOOL.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.DATABASE_NAME = "tuan";
                        tuantaskautorun_log.ID = this.txt_id.Text;
                        tuantaskautorun_log.CREATETIME = System.DateTime.Now;
                        tuantaskautorun_log.WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
                        tuantaskautorun_log.REMARK = Remark;
                        if (!string.IsNullOrEmpty(Remark))
                        {
                            tuantaskautorun_log.Insert();
                        }
                        string msg = "提交成功！";
                        this.RedirectConfirm(msg, this.P_BackUrl);
                    }
                }
                else
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
            }
            else if (this.P_TYPE == "1")
            {
                Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                if (tuantaskautorun.SelectTop1() != null)
                {
                    Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun_update = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                    tuantaskautorun_update.ID = this.txt_id.Text;
                    tuantaskautorun_update.NAME = this.txt_name.Text;
                    tuantaskautorun_update.PATH = this.txt_path.Text;
                    tuantaskautorun_update.RUNTYPE = int.Parse(this.ddl_runType.SelectedItem.Value);
                    if (!string.IsNullOrEmpty(this.txt_runMiniteOf.Text))
                    {
                        tuantaskautorun_update.RUNMINITEOF = decimal.Parse(this.txt_runMiniteOf.Text);
                    }
                    tuantaskautorun_update.RUNTIMEAT = this.txt_runTimeAt.Text;
                    tuantaskautorun_update.AUTHOR = this.txt_Author.Text;
                    // tuantaskautorun_update.LASTRUNTIME =DateTime.Parse( this.txt_LastRunTime.Text);
                    tuantaskautorun_update.ISOPEN = int.Parse(this.txt_isOpen.Text);
                    tuantaskautorun_update.TASKDETAIL = this.txt_TaskDetail.Text;
                    //tuantaskautorun_update.ISRUNNING= this.txt_isRunning.Text;
                    tuantaskautorun_update.SVNSOURCECODE = this.txt_SvnSourceCode.Text;

                    if (tuantaskautorun_update.Update() == false)
                    {
                        string msg = "提交失败！";
                        this.AlertScript(msg);
                        this.ltrMsg.Text = msg;
                        return;
                    }
                    else
                    {
                        //记录日志
                        string Remark = "";
                        if (tuantaskautorun.NAME != tuantaskautorun_update.NAME)
                        {
                            Remark += "修改字段NAME，从“" + tuantaskautorun.NAME + "”改成“" + tuantaskautorun_update.NAME + "”;\r\n";
                        }
                        if (tuantaskautorun.PATH != tuantaskautorun_update.PATH)
                        {
                            Remark += "修改字段PATH，从“" + tuantaskautorun.PATH + "”改成“" + tuantaskautorun_update.PATH + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNTYPE_ToString != tuantaskautorun_update.RUNTYPE_ToString)
                        {
                            Remark += "修改字段RUNTYPE，从“" + tuantaskautorun.RUNTYPE_ToString + "”改成“" + tuantaskautorun_update.RUNTYPE_ToString + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNMINITEOF_ToString != tuantaskautorun_update.RUNMINITEOF_ToString)
                        {
                            Remark += "修改字段RUNMINITEOF，从“" + tuantaskautorun.RUNMINITEOF_ToString + "”改成“" + tuantaskautorun_update.RUNMINITEOF_ToString + "”;\r\n";
                        }
                        if (tuantaskautorun.RUNTIMEAT != tuantaskautorun_update.RUNTIMEAT)
                        {
                            Remark += "修改字段RUNTIMEAT，从“" + tuantaskautorun.RUNTIMEAT + "”改成“" + tuantaskautorun_update.RUNTIMEAT + "”;\r\n";
                        }
                        if (tuantaskautorun.AUTHOR != tuantaskautorun_update.AUTHOR)
                        {
                            Remark += "修改字段AUTHOR，从“" + tuantaskautorun.AUTHOR + "”改成“" + tuantaskautorun_update.AUTHOR + "”;\r\n";
                        }
                        if (tuantaskautorun.ISOPEN_ToString != tuantaskautorun_update.ISOPEN_ToString)
                        {
                            Remark += "修改字段ISOPEN，从“" + tuantaskautorun.ISOPEN_ToString + "”改成“" + tuantaskautorun_update.ISOPEN_ToString + "”;\r\n";
                        }

                        if (tuantaskautorun.TASKDETAIL != tuantaskautorun_update.TASKDETAIL)
                        {
                            Remark += "修改字段TASKDETAIL，从“" + tuantaskautorun.TASKDETAIL + "”改成“" + tuantaskautorun_update.TASKDETAIL + "”;\r\n";
                        }
                        if (tuantaskautorun.SVNSOURCECODE != tuantaskautorun_update.SVNSOURCECODE)
                        {
                            Remark += "修改字段SVNSOURCECODE，从“" + tuantaskautorun.SVNSOURCECODE + "”改成“" + tuantaskautorun_update.SVNSOURCECODE + "”;\r\n";
                        }
                        Entity.TEAMTOOL.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TEAMTOOL.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.DATABASE_NAME = "tuan_test";
                        tuantaskautorun_log.ID = this.txt_id.Text;
                        tuantaskautorun_log.CREATETIME = System.DateTime.Now;
                        tuantaskautorun_log.WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
                        tuantaskautorun_log.REMARK = Remark;
                        if (!string.IsNullOrEmpty(Remark))
                        {
                            tuantaskautorun_log.Insert();
                        }

                        string msg = "提交成功！";
                        this.RedirectConfirm(msg, this.P_BackUrl);
                    }
                }
                else
                {
                    this.RedirectConfirm("执行失败，不存在此记录！", this.P_BackUrl);
                }
            }
        }
    }
}