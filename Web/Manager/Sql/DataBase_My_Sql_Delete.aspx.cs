using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_My_Sql_Delete : Business.ManageWeb
    {
        protected string P_Sql_Md5 = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_My_Sql_Delete.aspx");

            if (!Page.IsPostBack)
            {
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
                if (this.QueryString("Sql_Md5") != "")
                {
                    this.P_Sql_Md5 = Com.Common.EncDec.Decrypt(this.QueryString("Sql_Md5"), this.Encrypt_key);
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
            Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
            database_sql_my.WEBMANAGER_NAME = this.CurrentWebManagerName;
            database_sql_my.SQL_MD5 = this.P_Sql_Md5;

            if (database_sql_my.Delete() == true)
            {
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                Cache.Remove("DataBase_Sql_List_LikeMine_dtLog");  
                this.RedirectConfirm("删除成功！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("删除失败,可能您已删除此SQL！", this.P_BackUrl);

            }
        }
    }
}