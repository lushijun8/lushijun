using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_CfgFiles : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_TYPE = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            this.AdminCheck("Manager/Job/Job_List.aspx");
            if (this.QueryString("ID") != "")
            {
                this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
            }
            this.P_TYPE = this.QueryString("TYPE");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.P_ID) && !string.IsNullOrEmpty(this.P_TYPE))
                {
                    this.BindData();
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
                    Response.Write(tuantaskautorun.CFGFILES);
                }
            }
            else if (this.P_TYPE == "1")
            {
                Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN_TEST.TUANTASKAUTORUN();
                tuantaskautorun.ID = this.P_ID;
                if (tuantaskautorun.SelectTop1() != null)
                {
                    Response.Write(tuantaskautorun.CFGFILES);
                }
            }
        }

    }
}