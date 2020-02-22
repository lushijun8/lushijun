using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_Sql_Ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
//select WebManager_name,
//(select count(distinct sql_md5) from DataBase_Sql_Stats where seemlike_WebManager_name like '%'+Admin_WebManager.WebManager_name+'%') as counts_seemlike,
//(select count(distinct sql_md5) from DataBase_Sql_My where DataBase_Sql_My.WebManager_name =Admin_WebManager.WebManager_name) as counts_my,
//(select count(distinct sql_md5) from DataBase_Sql_My_Ignore where DataBase_Sql_My_Ignore.WebManager_name=Admin_WebManager.WebManager_name) as counts_ignore
// from Admin_WebManager 
        }
    }
}