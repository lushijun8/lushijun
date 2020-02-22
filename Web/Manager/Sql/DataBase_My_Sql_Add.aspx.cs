using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_My_Sql_Add : Business.ManageWeb
    {
        protected string P_Sql_Md5 = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Sql/DataBase_My_Sql_Add.aspx");

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
                    this.RedirectConfirm("认领失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {

            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats.SQL_MD5 = this.P_Sql_Md5;
            database_sql_stats.OrderBy = database_sql_stats._STATS_DATE + " DESC";
            database_sql_stats.SelectTop1();

            Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
            database_sql_my.WEBMANAGER_NAME = this.CurrentWebManagerName;
            database_sql_my.SQL_MD5 = this.P_Sql_Md5;
            database_sql_my.SOURCE_MD5 = database_sql_stats.SOURCE_MD5;
            database_sql_my.SQL_ERROR = database_sql_stats.SQL_ERROR;
            database_sql_my.TEXT_ANALYSIS = database_sql_stats.TEXT_ANALYSIS;

            database_sql_my.ISWRITESQL = int.Parse(database_sql_stats.ISWRITESQL_ToString);
            database_sql_my.LACK_WITH_NOLOCK_COUNT = int.Parse(database_sql_stats.LACK_WITH_NOLOCK_COUNT_ToString);
            database_sql_my.SELECT_ALL_COUNT = int.Parse(database_sql_stats.SELECT_ALL_COUNT_ToString);
            database_sql_my.LIKE_COUNT = int.Parse(database_sql_stats.LIKE_COUNT_ToString);
            database_sql_my.LACK_PARAMETER_COUNT = int.Parse(database_sql_stats.LACK_PARAMETER_COUNT_ToString);
            database_sql_my.COUNT_ALL = int.Parse(database_sql_stats.COUNT_ALL_ToString);

            database_sql_my.CREATETIME = System.DateTime.Now;

            if (database_sql_my.Insert() == true)
            {
                //删除忽略的记录
                Entity.TEAMTOOL.DATABASE_SQL_MY_IGNORE database_sql_my_ignore = new Entity.TEAMTOOL.DATABASE_SQL_MY_IGNORE();
                database_sql_my_ignore.SQL_MD5 = this.P_Sql_Md5;
                database_sql_my_ignore.WEBMANAGER_NAME = this.CurrentWebManagerName;
                string error = "";
                if (database_sql_my_ignore.Delete() == false)
                {
                    error = "删除忽略记录失败！";
                }
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                Cache.Remove("DataBase_Sql_List_LikeMine_dtLog");
                //删除忽略的记录                
                this.RedirectConfirm("认领成功！" + error, this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("认领失败,可能您已认领此SQL！", this.P_BackUrl);
            }
        }
    }
}