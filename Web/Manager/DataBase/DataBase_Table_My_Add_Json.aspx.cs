using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Table_My_Add_Json : Business.ManageWeb
    {
        protected string P_DataBase_Name = "";
        protected string P_Table_Name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Table_My_Add.aspx");
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                this.P_DataBase_Name = v[0];
                this.P_Table_Name = v[1];
                this.BindData();
            }
            else
            {
                Response.Write("{\"Message\":\"Failed\",\"Info\":\"认领失败,参数有误!\"}");
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
            database_table.DATABASE_NAME = this.P_DataBase_Name;
            database_table.TABLE_NAME = this.P_Table_Name;
            database_table.COUNTDATE = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
            DataRow oDr = database_table.SelectTop1();

            Entity.TEAMTOOL.DATABASE_TABLE_MY database_table_my = new Entity.TEAMTOOL.DATABASE_TABLE_MY();
            database_table_my.DATABASE_NAME = this.P_DataBase_Name;
            database_table_my.TABLE_NAME = this.P_Table_Name;
            database_table_my.WEBMANAGER_NAME = this.CurrentWebManagerName;
            database_table_my.WEBMANAGER_REALNAME = this.CurrentWebManagerRealName;
            if (oDr != null)
            {
                database_table_my.DATABASE_IP_ROMOTE = database_table.DATABASE_IP_ROMOTE;
                database_table_my.ROWCOUNTS = long.Parse(database_table.ROWCOUNTS_ToString);
                database_table_my.ROWCOUNTS_INCREASING = long.Parse(database_table.ROWCOUNTS_INCREASING_ToString);
                database_table_my.ROWCOUNTS_INCREASING_RATE = decimal.Parse(database_table.ROWCOUNTS_INCREASING_RATE_ToString);
                database_table_my.ROWCOUNTS_INCREASING_WEEK = long.Parse(database_table.ROWCOUNTS_INCREASING_WEEK_ToString);
                database_table_my.ROWCOUNTS_INCREASING_WEEK_RATE = decimal.Parse(database_table.ROWCOUNTS_INCREASING_WEEK_RATE_ToString);
                database_table_my.ROWCOUNTS_INCREASING_MONTH = long.Parse(database_table.ROWCOUNTS_INCREASING_MONTH_ToString);
                database_table_my.ROWCOUNTS_INCREASING_MONTH_RATE = decimal.Parse(database_table.ROWCOUNTS_INCREASING_MONTH_RATE_ToString);
                database_table_my.ROWCOUNTS_INCREASING_YEAR = long.Parse(database_table.ROWCOUNTS_INCREASING_YEAR_ToString);
                database_table_my.ROWCOUNTS_INCREASING_YEAR_RATE = decimal.Parse(database_table.ROWCOUNTS_INCREASING_YEAR_RATE_ToString);
                database_table_my.COLUMNCOUNTS = long.Parse(database_table.COLUMNCOUNTS_ToString);

            }
            database_table_my.CREATETIME = System.DateTime.Now;

            if (database_table_my.Insert() == true)
            {
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                Cache.Remove("database_table_my_all");

                Response.Write("{\"Message\":\"Success\",\"Info\":\"认领成功!\"}");
            }
            else
            {
                Response.Write("{\"Message\":\"Failed\",\"Info\":\"认领失败,可能您已认领此数据库表!\"}");
            }
        }
    }
}