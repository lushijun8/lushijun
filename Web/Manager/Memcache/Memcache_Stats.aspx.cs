using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Memcache
{
    public partial class Memcache_Stats : Business.ManageWeb
    {
        public string P_Today = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_CacheType = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Memcache/Memcache_Stats.aspx");
            this.P_Today = this.QueryString("today");
            this.P_CacheType = this.QueryString("cachetype");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }

                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 50;
            this.LogCount = 0;

            Entity.TEAMTOOL.MEMCACHE_STATS memcache_stats = new Entity.TEAMTOOL.MEMCACHE_STATS();
            string wheresql = " 1=1 ";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                wheresql += " AND (" +
                    "MEMCACHE_SERVER." + memcache_stats._MEMCACHE_IP + " like '%" + this.txtKeyword.Text + "%' or " +
                    "MEMCACHE_SERVER." + memcache_stats._MEMCACHE_LOCAL_IP + " like '%" + this.txtKeyword.Text + "%'  or " +
                    "MEMCACHE_SERVER." + memcache_stats._MEMCACHE_PORT + " like '%" + this.txtKeyword.Text + "%'  or " +
                     memcache_stats._LIBEVENT + " like '%" + this.txtKeyword.Text + "%'  or " +
                     memcache_stats._VERSION + " like '%" + this.txtKeyword.Text + "%') ";
            }
            if (!string.IsNullOrEmpty(this.P_CacheType))
            {
                wheresql += " AND (CacheType=" + this.P_CacheType + ") ";
            }
            memcache_stats.WhereSql = wheresql;
            memcache_stats.STATS_DATE = DateTime.Parse(this.P_Today);
            memcache_stats.OrderBy = memcache_stats._CREATETIME + " DESC";
            memcache_stats.LEFT_JOIN_MEMCACHE_SERVER = true;
            memcache_stats.SelectColumns = new string[] { memcache_stats.TableName + ".*", "CacheType", "Remark", "Auth", "ResetTime" };
            DataTable dtLog = memcache_stats.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            #region 补充没统计到的Memcached
            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            if (!string.IsNullOrEmpty(this.P_CacheType))
            {
                memcache_server.CACHETYPE = int.Parse(this.P_CacheType);
            }
            //memcache_server.CacheTime = 60;
            memcache_server.Select();
            while (memcache_server.Next())
            {
                DataRow[] oDrs_dtLog=dtLog.Select(memcache_server._MEMCACHE_IP+"='"+memcache_server.MEMCACHE_IP+"' AND "+memcache_server._MEMCACHE_PORT+"='"+memcache_server.MEMCACHE_PORT_ToString+"'");
                if (oDrs_dtLog == null || oDrs_dtLog.Length == 0)
                {
                    DataRow oDr_New = dtLog.NewRow();
                    oDr_New[memcache_server._MEMCACHE_IP] = memcache_server.MEMCACHE_IP;
                    oDr_New[memcache_server._MEMCACHE_LOCAL_IP] = memcache_server.MEMCACHE_LOCAL_IP;
                    oDr_New[memcache_server._MEMCACHE_PORT] = memcache_server.MEMCACHE_PORT_ToString;
                    oDr_New[memcache_server._REMARK] = memcache_server.REMARK;
                    oDr_New[memcache_server._CACHETYPE] = memcache_server.CACHETYPE_ToString;
                    oDr_New[memcache_stats._WEBSITE] ="不存在此缓存服务，请检查";
                    oDr_New[memcache_stats._STATS_DATE] = System.DateTime.Now.ToShortDateString();
                    oDr_New[memcache_stats._CREATETIME] = "1900-1-1";
                    oDr_New[memcache_stats._STATUS] = 0;
                    oDr_New[memcache_stats._BYTES] = 0;
                    oDr_New[memcache_stats._BYTES_READ] = 0;
                    oDr_New[memcache_stats._BYTES_WRITTEN] = 0;
                    oDr_New[memcache_stats._LIMIT_MAXBYTES] = 0;
                    oDr_New[memcache_stats._UPTIME] = 0;
                    oDr_New[memcache_stats._GET_HITS] = 0;
                    oDr_New[memcache_stats._GET_MISSES] = 0;
                    oDr_New["AUTH"] = memcache_server.AUTH;
                    dtLog.Rows.InsertAt(oDr_New,0);
                }
            }

            #endregion

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Memcache/Memcache_Stats.aspx?page={page}&today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion

            #region 绑定时间选项
            DataTable oDt_Date = new DataTable();
            oDt_Date.Columns.Add(new DataColumn("Date", typeof(string)));
            oDt_Date.Columns.Add(new DataColumn("isCurrentDate", typeof(int)));
            for (int i = 9; i >= 0; i--)
            {
                DataRow oDr_New = oDt_Date.NewRow();
                oDr_New["Date"] = System.DateTime.Now.AddDays(-1 * i).ToString("yyyy-MM-dd");
                if (System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.P_Today).ToShortDateString())
                {
                    oDr_New["isCurrentDate"] = 1;
                }
                else
                {
                    oDr_New["isCurrentDate"] = 0;
                }
                oDt_Date.Rows.Add(oDr_New);
            }
            this.rpt_Date.DataSource = oDt_Date;
            this.rpt_Date.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
