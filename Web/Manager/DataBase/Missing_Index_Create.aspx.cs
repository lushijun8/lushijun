using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Web.Manager.DataBase
{
    public partial class Missing_Index_Create : Business.ManageWeb
    {
        private string P_v = "";
        private string P_DataBase_IP_Romote = "";
        private string P_DataBase_Name = "";
        public string P_Date = "";
        public string P_Index_Handle = "";
        public string P_Group_Handle = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/Missing_Index_Create.aspx");
            this.P_v = this.QueryString("v");
            if (!string.IsNullOrEmpty(this.P_v))
            {
                string[] vs = Com.Common.EncDec.Decrypt(this.P_v, this.Encrypt_key).Split(',');
                this.P_DataBase_IP_Romote = vs[0];
                this.P_DataBase_Name = vs[1];
                this.P_Date = vs[2];
                this.P_Index_Handle = vs[3];
                this.P_Group_Handle = vs[4];
            }
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
                this.BindData();
            }
        }
        private void BindData()
        {

            Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
            database_missing_index.DATABASE_IP_ROMOTE = this.P_DataBase_IP_Romote;
            database_missing_index.DATABASE_NAME = this.P_DataBase_Name;
            database_missing_index.DATE = DateTime.Parse(this.P_Date);
            database_missing_index.INDEX_HANDLE = long.Parse(this.P_Index_Handle);
            database_missing_index.GROUP_HANDLE = long.Parse(this.P_Group_Handle);

            if (database_missing_index.SelectTop1() != null)
            {
                #region Sql拼装
                string DataBase_Name = database_missing_index.STATEMENT.Split('.')[0].Replace("[", "").Replace("]", "");
                string TableName = database_missing_index.STATEMENT.Split('.')[2].Replace("[", "").Replace("]", "");
                string Columns_Name = ((string.IsNullOrEmpty(database_missing_index.INCLUDED_COLUMNS) || database_missing_index.INCLUDED_COLUMNS.Split(',').Length > 4) ?
                    "" : "_" + database_missing_index.INCLUDED_COLUMNS.Trim().Replace("]", "").Replace("[", "").Replace(",", "_").Replace(" ", ""));

                string equality_columns = database_missing_index.EQUALITY_COLUMNS;
                string inequality_columns = database_missing_index.INEQUALITY_COLUMNS;
                string included_columns = database_missing_index.INCLUDED_COLUMNS;
                string split = "";
                if (!string.IsNullOrEmpty(equality_columns) && !string.IsNullOrEmpty(inequality_columns))
                {
                    split = ",";
                }
                string Sql = @"/**来自teamtool自动建缺失的索引**/
                              CREATE INDEX [IDX_" + database_missing_index.GROUP_HANDLE_ToString + "_" + database_missing_index.INDEX_HANDLE_ToString + "_" + TableName + Columns_Name + @"] 
                              ON " + database_missing_index.STATEMENT + " (" + database_missing_index.EQUALITY_COLUMNS + split + inequality_columns + @")
                              " + (string.IsNullOrEmpty(included_columns) ? "" : "INCLUDE (" + included_columns + ")") + @"";
                #endregion
                #region 获取主库IP
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.DATABASE_IS_MAIN = 1;
                database_owner.DATABASE_NAME = this.P_DataBase_Name;
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE };
                database_owner.CacheTime = 1440;
                database_owner.SelectTop1();
                #endregion
                Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_missing_index.DATABASE_NAME + "_DataBaseInstance");
                int i = Database_Owner.ExecuteNonQuery(CommandType.Text, Sql);
                if (i > -100)//建立索引成功！
                {
                    #region 删除索引缺失记录
                    Entity.TEAMTOOL.DATABASE_MISSING_INDEX database_missing_index_delete = new Entity.TEAMTOOL.DATABASE_MISSING_INDEX();
                    database_missing_index_delete.DATABASE_IP_ROMOTE = this.P_DataBase_IP_Romote;
                    database_missing_index_delete.DATABASE_NAME = this.P_DataBase_Name;
                    //database_missing_index_delete.DATE = DateTime.Parse(this.P_Date);
                    database_missing_index_delete.INDEX_HANDLE = long.Parse(this.P_Index_Handle);
                    database_missing_index_delete.GROUP_HANDLE = long.Parse(this.P_Group_Handle);

                    database_missing_index_delete.PrimaryKey = new string[] { 
                        database_missing_index_delete._DATABASE_IP_ROMOTE,
                        database_missing_index_delete._DATABASE_NAME,
                        database_missing_index_delete._INDEX_HANDLE,
                        database_missing_index_delete._GROUP_HANDLE
                    };
                    #endregion
                    if (database_missing_index_delete.Delete() == true)
                    {
                        this.RedirectConfirmScript("建立缺失索引成功，同时删除缺失信息成功！", this.P_BackUrl);
                    }
                    else
                    {
                        this.RedirectConfirmScript("建立缺失索引成功，同时删除缺失信息失败！", this.P_BackUrl);
                    }
                }
                else
                {
                    this.RedirectConfirmScript("建立缺失索引失败！", this.P_BackUrl);
                }
            }
            else
            {
                this.RedirectConfirmScript("建立失败，不存在此缺失索引信息！", this.P_BackUrl);
            }

        }
    }
}