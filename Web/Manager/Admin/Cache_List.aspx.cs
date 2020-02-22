using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class Cache_List : Business.ManageWeb
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/Cache_List.aspx");
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            DataTable oDt = new DataTable("Log");
            oDt.Columns.Add(new DataColumn("CacheName", typeof(string)));
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            System.Collections.IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                string _key = CacheEnum.Key.ToString();
                DataRow oDr = oDt.NewRow();
                oDr["CacheName"] = _key;
                oDt.Rows.Add(oDr);
            }
            this.rpt_Log.DataSource = oDt;
            this.rpt_Log.DataBind();
        }

        protected void btn_ClearCache_Click(object sender, EventArgs e)
        {
            string str = "";
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            System.Collections.IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                string _key = CacheEnum.Key.ToString();
                str += "成功清除缓存名<b>[" + _key + "]</b><br />";
                _cache.Remove(_key);
            }
            Response.Write(str);
        }
    }
}