using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Table_My_Delete : Business.ManageWeb
    {
        protected string P_DataBase_Name = "";
        protected string P_Table_Name = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Table_My_Delete.aspx");

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
                if (!string.IsNullOrEmpty(this.QueryString("v")))
                {
                    string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                    this.P_DataBase_Name = v[0];
                    this.P_Table_Name = v[1];
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

            Entity.TEAMTOOL.DATABASE_TABLE_MY database_table_my = new Entity.TEAMTOOL.DATABASE_TABLE_MY();
            database_table_my.DATABASE_NAME = this.P_DataBase_Name;
            database_table_my.TABLE_NAME = this.P_Table_Name;
            database_table_my.WEBMANAGER_NAME = this.CurrentWebManagerName;

            if (database_table_my.Delete() == true)
            {
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                Cache.Remove("database_table_my_all");
                this.RedirectConfirm("删除成功！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("删除失败,可能您已删除此表的认领！", this.P_BackUrl);

            }
        }
    }
}