using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_Description_Create : Business.ManageWeb
    {
        protected int P_DataBase_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AdminCheck("Manager/DataBase/DataBase_Owner_Description_Create.aspx");
            if (!Page.IsPostBack)
            {
                if (this.QueryString("DataBase_Id") != "")
                {
                    this.P_DataBase_Id = int.Parse(Com.Common.EncDec.Decrypt(this.QueryString("DataBase_Id"), this.Encrypt_key).Split(',')[0]);
                    this.BindData();
                }
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.DATABASE_ID = this.P_DataBase_Id;
            database_owner.SelectTop1();

            Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
            string DataBase_Table_Description = Com.AutoCode.TableDescriptionCoder.GetAutoCode(Database_Owner, database_owner.DATABASE_IP_ROMOTE, Business.Config.HostUrl + "/images/");
            string DataBase_BackUp = Com.AutoCode.BackUp.Get_Proc_View_Fun_Bak(Database_Owner, database_owner.DATABASE_IP_ROMOTE);

            Entity.TEAMTOOL.DATABASE_OWNER database_owner_update = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner_update.PrimaryKey = new string[] { database_owner_update._DATABASE_NAME, database_owner_update._DATABASE_ADMIN_USER };
            database_owner_update.DATABASE_NAME = database_owner.DATABASE_NAME;
            database_owner_update.DATABASE_ADMIN_USER = database_owner.DATABASE_ADMIN_USER;
            database_owner_update.DATABASE_TABLE_DESCRIPTION = DataBase_Table_Description;
            database_owner_update.LAST_UPDATE_TIME = System.DateTime.Now;
            if (!string.IsNullOrEmpty(DataBase_BackUp))
            {
                database_owner_update.DATABASE_PROC_VIEW_FUNCTION_BAK3 = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK2;
                database_owner_update.DATABASE_PROC_VIEW_FUNCTION_BAK2 = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK1;
                database_owner_update.DATABASE_PROC_VIEW_FUNCTION_BAK1 = DataBase_BackUp;

            }
            if (database_owner_update.Update() == true)
            {
                this.RedirectConfirm("刷新成功！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
            }
            else
            {
                this.RedirectConfirm("刷新失败！", Business.Config.HostUrl + "/Manager/Welcome.aspx");

            }
        }
    }
}