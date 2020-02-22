using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Alter_Delete : Business.ManageWeb
    {
        protected string P_ID = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Alter_Delete.aspx");

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
                if (this.QueryString("ID") != "")
                {
                    this.P_ID = Com.Common.EncDec.Decrypt(this.QueryString("ID"), this.Encrypt_key);
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("删除失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_ALTER database_alter = new Entity.TEAMTOOL.DATABASE_ALTER();
            database_alter.ID = int.Parse(this.P_ID);
            if (database_alter.SelectTop1() != null)
            {
                #region 存在
                Entity.TEAMTOOL.DATABASE_ALTER database_alter_delete = new Entity.TEAMTOOL.DATABASE_ALTER();
                database_alter_delete.ID = int.Parse(this.P_ID);

                if (database_alter_delete.Delete() == true)
                {
                    this.RedirectConfirm("删除成功！", this.P_BackUrl);
                }
                else
                {
                    this.RedirectConfirm("删除失败！", this.P_BackUrl);
                }
                #endregion
            }
            else
            {
                this.RedirectConfirm("删除失败！不存在此记录！", this.P_BackUrl);
            }
        }
    }
}