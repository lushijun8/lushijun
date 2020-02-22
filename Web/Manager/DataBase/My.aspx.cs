using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class My : Business.ManageWeb
    {

        public string P_Script = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_Description.aspx");
            if (!Page.IsPostBack)
            {
                string P_v = this.QueryString("v");
                if (!string.IsNullOrEmpty(P_v))
                {
                    this.BindData(P_v);
                }
            }
        }
        private void BindData(string P_v)
        {
            string[] vs = P_v.TrimEnd(';').TrimStart(';').Split('@');
            string DataBase_Name = vs[0];
            int Start_Index = int.Parse(vs[1]);
            string[] TableNames = vs[2].Split(';');

            DataTable oDt = new DataTable();
            oDt.Columns.Add(new DataColumn("DATABASE_NAME", typeof(string)));
            oDt.Columns.Add(new DataColumn("TABLE_NAME", typeof(string)));
            foreach (string TableName in TableNames)
            {
                DataRow oDr = oDt.NewRow();
                oDr["DATABASE_NAME"] = DataBase_Name;
                oDr["TABLE_NAME"] = TableName;
                oDt.Rows.Add(oDr);
            }
            Business.DataBase.DataBase_Table_My.MatchMine(oDt, this.CurrentWebManagerName);
            for (int k = 0; k < TableNames.Length; k++)
            {
                string myscript = "";
                DataRow oDr = oDt.Select("DATABASE_NAME='" + DataBase_Name + "' AND TABLE_NAME='" + TableNames[k] + "'")[0];
                string WebManager_RealName = oDr["WebManager_RealName"].ToString();
                string IsMy = oDr["IsMy"].ToString();
                if (!string.IsNullOrEmpty(WebManager_RealName))
                {
                    myscript += "<a href='javascript:void(0);' class='mys tooltip' titles='" + WebManager_RealName + "'></a>";
                }
                myscript += "<a href='javascript:void(0);' onclick='javascript:Add_Delete_My(\\\"" + Com.Common.EncDec.Encrypt(DataBase_Name + "," + TableNames[k], this.Encrypt_key) + "\\\",\\\"" + Start_Index + "\\\",\\\"" + (IsMy == "1" ? "Delete" : "Add") + "\\\");' class='" + (IsMy == "1" ? "" : "not") + "my tooltip'></a> <a href='javascript:void(0);' class='indexs_tooltip tooltip " + DataBase_Name + "_" + TableNames[k] + "' id='" + DataBase_Name + "." + TableNames[k] + "'></a>";
                P_Script += "$(\"#m" + Start_Index + "\").html(\"" + myscript + "\");";
                Start_Index++;               
            }
        }
    }
}