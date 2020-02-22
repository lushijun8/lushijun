using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class Indexs : Business.ManageWeb
    {

        public string P_Titles = "";
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
            string[] vs = P_v.Split('.');
            string DataBase_Name = vs[0];
            string Table_Name = vs[1];

            Entity.TEAMTOOL.DATABASE_TABLE_INDEX database_table_index_all = new Entity.TEAMTOOL.DATABASE_TABLE_INDEX();
            database_table_index_all.DATABASE_NAME = DataBase_Name;
            database_table_index_all.OrderBy = database_table_index_all._COLID;
            database_table_index_all.Distinct = true;
            database_table_index_all.SelectColumns = new string[] { database_table_index_all._DATABASE_NAME, database_table_index_all._TABLE_NAME, database_table_index_all._INDEX_NAME, database_table_index_all._COLUMN_NAME, database_table_index_all._COLID };
            database_table_index_all.CacheTime = 1440;
            DataTable oDt_database_table_index_all = database_table_index_all.Select();


            Entity.TEAMTOOL.DATABASE_TABLE_INDEX database_table_index = new Entity.TEAMTOOL.DATABASE_TABLE_INDEX();
            database_table_index.DATABASE_NAME = DataBase_Name;
            database_table_index.OrderBy = database_table_index._INDEX_NAME;
            database_table_index.Distinct = true;
            database_table_index.SelectColumns = new string[] { database_table_index._DATABASE_NAME, database_table_index._TABLE_NAME, database_table_index._INDEX_NAME };
            database_table_index.CacheTime = 1440;
            DataTable oDt_database_table_index = database_table_index.Select();

            this.P_Titles += "{\"Message\":\"";
            DataRow[] oDrs_database_table_index = oDt_database_table_index.Select(database_table_index._DATABASE_NAME + "='" + DataBase_Name + "' AND " + database_table_index._TABLE_NAME + "='" + Table_Name + "'");
            if (oDrs_database_table_index != null && oDrs_database_table_index.Length > 0)
            {
                foreach (DataRow oDr_database_table_index in oDrs_database_table_index)
                {
                    string index_name = oDr_database_table_index[database_table_index._INDEX_NAME].ToString();
                    this.P_Titles += "<img src=" + Business.Config.HostUrl + "/images/";
                    if (index_name.ToUpper().StartsWith("PK_"))
                    {
                        this.P_Titles += "key";
                    }
                    else
                    {
                        this.P_Titles += "indexs";
                    }
                    this.P_Titles += ".gif> " + index_name;
                    string column_name = "";
                    DataRow[] oDrs_database_table_index_all = oDt_database_table_index_all.Select(
                        database_table_index._DATABASE_NAME + "='" + DataBase_Name +
                        "' AND " + database_table_index._TABLE_NAME + "='" + Table_Name + 
                        "' AND " + database_table_index._INDEX_NAME + "='" + index_name + "'"
                        );
                    if (oDrs_database_table_index_all != null && oDrs_database_table_index_all.Length > 0)
                    {
                        foreach (DataRow oDr_database_table_index_all in oDrs_database_table_index_all)
                        {
                            column_name += oDr_database_table_index_all[database_table_index._COLUMN_NAME].ToString() + ",";
                        }
                    }

                    if (!string.IsNullOrEmpty(column_name))
                    {

                        this.P_Titles += "(<font color=lightgray>" + column_name.TrimEnd(',') + "</font>)";
                    }
                    this.P_Titles += "<br>";

                }
            }
            this.P_Titles += "\"}";

        }
    }
}