using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_BackUp : Business.ManageWeb
    {
        protected int P_DataBase_Id = -1;
        protected string P_Bak = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_BackUp.aspx");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.QueryString("Bak")))
                {
                    this.P_Bak = this.QueryString("Bak");
                }
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
            string DATABASE_PROC_VIEW_FUNCTION_BAK = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK1;
            if (this.P_Bak == "1")
            {
                DATABASE_PROC_VIEW_FUNCTION_BAK = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK1;
            }
            if (this.P_Bak == "2")
            {
                DATABASE_PROC_VIEW_FUNCTION_BAK = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK2;
            }
            if (this.P_Bak == "3")
            {
                DATABASE_PROC_VIEW_FUNCTION_BAK = database_owner.DATABASE_PROC_VIEW_FUNCTION_BAK3;
            }
            Response.Write(DATABASE_PROC_VIEW_FUNCTION_BAK.Replace("\r\n","<br/>"));
        }
    }
}