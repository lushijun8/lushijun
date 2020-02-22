using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Table_UpdateLog : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            string[] v0 = Com.Common.EncDec.Decrypt(this.QueryString("v0"), this.Encrypt_key).Split(',');
            string[] v1 = Com.Common.EncDec.Decrypt(this.QueryString("v1"), this.Encrypt_key).Split('.');
            Entity.TEAMTOOL.DATABASE_TABLE_UPDATELOG database_table_updatelog = new Entity.TEAMTOOL.DATABASE_TABLE_UPDATELOG();
            database_table_updatelog.DATABASE_IP_ROMOTE = v0[0];
            database_table_updatelog.DATABASE_NAME = v0[1];
            database_table_updatelog.TABLE_NAME = v1[0];
            database_table_updatelog.COLUMN_NAME = v1[1];
            database_table_updatelog.CacheTime = 5;
            database_table_updatelog.Select();
            database_table_updatelog.OrderBy = database_table_updatelog._CREATETIME + " DESC";
            while (database_table_updatelog.Next())
            {
                html += "<br>" + database_table_updatelog.CREATETIME_ToString + "," + database_table_updatelog.WEBMANAGER_NAME + " 修改成：<font color=red>" + database_table_updatelog.DESCRIPTION + ";</font>";
            }

            string Result = "{\"Message\":\"Success\",\"Log\":\"点击可修改.<br/>" + html.Replace("\"", "'") + "\"}";
            Response.ContentType = "application/json;";
            Response.Write(Result);

        }
    }
}