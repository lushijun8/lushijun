using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Manager.Memcache
{
    public partial class Memcache_Rank : Business.ManageWeb
    {
        public string P_Today = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_orderby = "";
        public int LogCount = 0;
        public int _PageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Memcache/Memcache_Rank.aspx");
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "get_rate";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;


            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits_sum = new Entity.TEAMTOOL.MEMCACHE_HITS();
            memcache_hits_sum.Distinct = true;
            memcache_hits_sum.GroupBy = "substring(" + memcache_hits_sum._PAGEURL + ",8,charindex('.com'," + memcache_hits_sum._PAGEURL + ")-4)";
            memcache_hits_sum.OrderBy = this.P_orderby;
            memcache_hits_sum.INNER_JOIN_MEMCACHE_SERVER = true;
            if (!string.IsNullOrEmpty(this.P_Today) && this.P_Today!="all")
            {
                memcache_hits_sum.STATS_DATE = DateTime.Parse(this.P_Today);
            }

            memcache_hits_sum.SelectColumns = new string[]{
                        "substring(" + memcache_hits_sum._PAGEURL + ",8,charindex('.com'," + memcache_hits_sum._PAGEURL + ")-4) as " + memcache_hits_sum._PAGEURL + "",
						"min("+memcache_hits_sum.TableName+"." + memcache_hits_sum._MEMCACHE_IP + ") as " + memcache_hits_sum._MEMCACHE_IP + "",
						"min("+memcache_server.TableName+"." + memcache_server._MEMCACHE_LOCAL_IP + ") as " + memcache_server._MEMCACHE_LOCAL_IP + "",
						"min("+memcache_server.TableName+"." + memcache_server._STATUS + ") as " + memcache_server._STATUS + "",
						"min(" +memcache_hits_sum.TableName+"." +  memcache_hits_sum._MEMCACHE_PORT + ") as " + memcache_hits_sum._MEMCACHE_PORT + "",
                        "sum(" + memcache_hits_sum._SET_HITS_COUNT + ") as " + memcache_hits_sum._SET_HITS_COUNT + "",
                        "sum(" + memcache_hits_sum._SET_MISSES_COUNT + ") as " + memcache_hits_sum._SET_MISSES_COUNT + "",
                        "sum(" + memcache_hits_sum._SET_COUNT + ") as " + memcache_hits_sum._SET_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_HITS_COUNT + ") as " + memcache_hits_sum._GET_HITS_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_MISSES_COUNT + ") as " + memcache_hits_sum._GET_MISSES_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_COUNT + ") as " + memcache_hits_sum._GET_COUNT + "",                        
                        "sum(" + memcache_hits_sum._GET_HITS_COUNT + ")/(sum(" + memcache_hits_sum._GET_COUNT + ")+0.0001) as get_rate",
                        "sum(" + memcache_hits_sum._SET_HITS_COUNT + ")/(sum(" + memcache_hits_sum._SET_COUNT + ")+0.0001) as set_rate"};
            DataTable dtLog = memcache_hits_sum.Select();
            this.LogCount = dtLog.Rows.Count;
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Memcache/Memcache_Rank.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_orderby) + "&today=" + Server.UrlEncode(this.P_Today);

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
                if (!string.IsNullOrEmpty(this.P_Today) && this.P_Today != "all" && System.DateTime.Now.AddDays(-1 * i).ToShortDateString() == DateTime.Parse(this.P_Today).ToShortDateString())
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
