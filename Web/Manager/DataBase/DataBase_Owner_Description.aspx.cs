using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_Description : Business.ManageWeb
    {
        protected int P_DataBase_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_Description.aspx");
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

            Response.Write(database_owner.DATABASE_TABLE_DESCRIPTION);
        }
    }
}