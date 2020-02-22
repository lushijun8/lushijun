using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_Add : Business.ManageWeb
    {
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_Add.aspx");
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
                this.BindData();
            }
        }
        private void BindData()
        {
            this.txt_id.Text = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            this.txt_Author.Text = this.CurrentWebManagerRealName;
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
            if (this.ddl_runType.SelectedItem.Value == "1" && string.IsNullOrEmpty(this.txt_runMiniteOf.Text))
            {
                this.AlertScript("请填写runMiniteOf！");
                return;
            }
            if (this.ddl_runType.SelectedItem.Value == "2" && string.IsNullOrEmpty(this.txt_runTimeAt.Text))
            {
                this.AlertScript("请填写runTimeAt！");
                return;
            }
            if (this.ddl_Type.SelectedItem.Value == "0")
            {
                Entity.TUAN.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.txt_id.Text;
                tuantaskautorun.NAME = this.txt_name.Text;
                tuantaskautorun.PATH = this.txt_path.Text;
                tuantaskautorun.RUNTYPE = int.Parse(this.ddl_runType.SelectedItem.Value);
                if (!string.IsNullOrEmpty(this.txt_runMiniteOf.Text))
                {
                    tuantaskautorun.RUNMINITEOF = decimal.Parse(this.txt_runMiniteOf.Text);
                }
                tuantaskautorun.RUNTIMEAT = this.txt_runTimeAt.Text;
                tuantaskautorun.AUTHOR = this.txt_Author.Text;
                tuantaskautorun.ISOPEN = int.Parse(this.txt_isOpen.Text);
                tuantaskautorun.TASKDETAIL = this.txt_TaskDetail.Text;
                tuantaskautorun.ISRUNNING = false;
                tuantaskautorun.SVNSOURCECODE = this.txt_SvnSourceCode.Text;
                tuantaskautorun.CREATETIME = DateTime.Now;
                if (tuantaskautorun.Insert() == false)
                {
                    string msg = "提交失败！";
                    this.AlertScript(msg);
                    this.ltrMsg.Text = msg;
                    return;
                }
                else
                {
                    string msg = "提交成功！";
                    this.RedirectConfirm(msg, this.P_BackUrl);
                }

            }
            else if (this.ddl_Type.SelectedItem.Value == "1")
            {

                Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.txt_id.Text;
                tuantaskautorun.NAME = this.txt_name.Text;
                tuantaskautorun.PATH = this.txt_path.Text;
                tuantaskautorun.RUNTYPE = int.Parse(this.ddl_runType.SelectedItem.Value);
                if (!string.IsNullOrEmpty(this.txt_runMiniteOf.Text))
                {
                    tuantaskautorun.RUNMINITEOF = decimal.Parse(this.txt_runMiniteOf.Text);
                }
                tuantaskautorun.RUNTIMEAT = this.txt_runTimeAt.Text;
                tuantaskautorun.AUTHOR = this.txt_Author.Text;
                tuantaskautorun.ISOPEN = int.Parse(this.txt_isOpen.Text);
                tuantaskautorun.TASKDETAIL = this.txt_TaskDetail.Text;
                tuantaskautorun.ISRUNNING = false;
                tuantaskautorun.SVNSOURCECODE = this.txt_SvnSourceCode.Text;
                tuantaskautorun.CREATETIME = DateTime.Now;

                if (tuantaskautorun.Insert() == false)
                {
                    string msg = "提交失败！";
                    this.AlertScript(msg);
                    this.ltrMsg.Text = msg;
                    return;
                }
                else
                {
                    string msg = "提交成功！";
                    this.RedirectConfirm(msg, this.P_BackUrl);
                }
            }
        }
    }
}