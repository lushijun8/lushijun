using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Depend
{
    public partial class Depend_List_My : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        public string CurrentWebManagerName_v = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Depend/Depend_List_My.aspx");
            CurrentWebManagerName_v = this.CurrentWebManagerName;
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                CurrentWebManagerName_v = this.QueryString("v");
            }
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "DEPEND_CREATETIME DESC";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (!Page.IsPostBack)
            {
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            DataTable oDt_website_depend = null;

            string CacheName = "Welcome_" + CurrentWebManagerName_v + "_20";
            if (Cache[CacheName] != null)
            {
                oDt_website_depend = (DataTable)Cache[CacheName];
            }
            else
            {
                Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
                website_depend.SelectColumns = new string[] { 
                website_depend._DEPEND_PAGEURL,
                website_depend._DEPEND_CONTENTTYPE,
                website_depend._STATS_DATE,  
                website_depend._DEPEND_TIMEOUT,                 
                //"MAX(" + website_depend._DEPEND_TIMEOUT_MAX + ") AS " + website_depend._DEPEND_TIMEOUT_MAX  ,
                //"MIN(" + website_depend._DEPEND_TIMEOUT_MIN + ") AS " + website_depend._DEPEND_TIMEOUT_MIN  ,
                "SUM(" + website_depend._DEPEND_COUNT + ") AS " + website_depend._DEPEND_COUNT  ,
                "SUM(" + website_depend._DEPEND_COUNT_ERROR + ") AS " + website_depend._DEPEND_COUNT_ERROR  ,
                "SUM(" + website_depend._DEPEND_COUNT_TIMEOUT + ") AS " + website_depend._DEPEND_COUNT_TIMEOUT  ,
                "SUM(" + website_depend._DEPEND_TIMESPAN_SUM + ")/SUM(" + website_depend._DEPEND_COUNT + ") AS " + website_depend._DEPEND_TIMESPAN_AVERAGE  ,
                "MAX(" + website_depend._DEPEND_TIMESPAN_MAX + ") AS " + website_depend._DEPEND_TIMESPAN_MAX  ,
                "MIN(" + website_depend._DEPEND_TIMESPAN_MIN + ") AS " + website_depend._DEPEND_TIMESPAN_MIN  ,
                "MAX(" + website_depend._DEPEND_CREATETIME + ") AS " + website_depend._DEPEND_CREATETIME   ,
                "MAX(" + website_depend._DEPEND_CONTENTLENGTH + ") AS " + website_depend._DEPEND_CONTENTLENGTH   ,
                "MAX(" + website_depend._DEPEND_CONTENT + ") AS " + website_depend._DEPEND_CONTENT  ,
                "MAX(" + website_depend._DEPEND_CONTENTTYPE_ERROR + ") AS " + website_depend._DEPEND_CONTENTTYPE_ERROR  ,
                "MAX(" + website_depend._DEPEND_PAGEURL_DETAIL + ") AS " + website_depend._DEPEND_PAGEURL_DETAIL  
                };
                website_depend.GroupBy = website_depend._DEPEND_PAGEURL + "," + website_depend._STATS_DATE + "," + website_depend._DEPEND_CONTENTTYPE + "," + website_depend._DEPEND_TIMEOUT;
                //website_depend.OrderBy = this.P_orderby ;
                //website_depend.CacheTime = 60;
                oDt_website_depend = website_depend.Select();
                get_Depend_Out(oDt_website_depend);//外部依赖 

                oDt_website_depend.Columns.Add(new DataColumn("DEPEND_CONTENTTYPE_NEW", typeof(string)));
                oDt_website_depend.Columns.Add(new DataColumn("DEPEND_ERROR_RATE", typeof(decimal)));
                oDt_website_depend.Columns.Add(new DataColumn("DEPEND_TIMEOUT_RATE", typeof(decimal)));
                foreach (DataRow oDr_website_depend in oDt_website_depend.Rows)
                {
                    oDr_website_depend["DEPEND_ERROR_RATE"] = decimal.Parse(oDr_website_depend["DEPEND_COUNT_ERROR"].ToString()) * 100 / decimal.Parse(oDr_website_depend["DEPEND_COUNT"].ToString());
                    oDr_website_depend["DEPEND_TIMEOUT_RATE"] = decimal.Parse(oDr_website_depend["DEPEND_COUNT_TIMEOUT"].ToString()) * 100 / decimal.Parse(oDr_website_depend["DEPEND_COUNT"].ToString());
                    string CONTENTTYPE = oDr_website_depend["DEPEND_CONTENTTYPE"].ToString().ToLower();
                    if (CONTENTTYPE.IndexOf("json") > -1)
                    {
                        oDr_website_depend["DEPEND_CONTENTTYPE_NEW"] = "json";
                    }
                    else if (CONTENTTYPE.IndexOf("xml") > -1)
                    {
                        oDr_website_depend["DEPEND_CONTENTTYPE_NEW"] = "xml";
                    }
                    else if (CONTENTTYPE.IndexOf("html") > -1)
                    {
                        oDr_website_depend["DEPEND_CONTENTTYPE_NEW"] = "html";
                    }
                    else
                    {
                        oDr_website_depend["DEPEND_CONTENTTYPE_NEW"] = "text";
                    }
                }
                Cache.Add(CacheName, oDt_website_depend.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 180, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);

            }
            DataView oDv = oDt_website_depend.DefaultView;
            oDv.RowFilter = "STATS_DATE='" + this.P_Today + "' AND Depend_WebManager_Name LIKE '%" + CurrentWebManagerName_v + "%'";
            oDv.Sort = this.P_orderby;
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                oDv.RowFilter += "AND (DEPEND_PAGEURL LIKE '%" + this.txtKeyword.Text + "%' OR Depend_WebManager_RealName LIKE '%" + this.txtKeyword.Text + "%' OR WebManager_RealName LIKE '%" + this.txtKeyword.Text + "%')";
            }

            this.LogCount = oDv.Count;
            this.rptLog.DataSource = oDv;
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

        private void get_Depend_Out(DataTable oDt)
        {
            oDt.Columns.Add(new DataColumn("Depend_PageUrl_Out", typeof(string)));
            oDt.Columns.Add(new DataColumn("Depend_WebManager_RealName", typeof(string)));
            oDt.Columns.Add(new DataColumn("Depend_WebManager_Name", typeof(string)));
            oDt.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            oDt.Columns.Add(new DataColumn("IsMy", typeof(int)));

            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.SelectColumns = new string[] 
            { 
                website_depend._PAGEURL, 
                website_depend._DEPEND_PAGEURL,
                website_depend._DEPEND_PAGEURL_DETAIL, 
                website_depend._DEPEND_CONTENTTYPE, 
                website_depend._DEPEND_CONTENTLENGTH, 
                website_depend._DEPEND_COUNT, 
                website_depend._DEPEND_TIMESPAN_SUM, 
                website_depend._DEPEND_TIMESPAN_MAX, 
                website_depend._DEPEND_TIMESPAN_MIN, 
                website_depend._DEPEND_TIMESPAN_NEW, 
                website_depend._DEPEND_TIMESPAN_AVERAGE, 
                website_depend._DEPEND_CREATETIME 
            };
            website_depend.STATS_DATE = DateTime.Parse(DateTime.Now.AddHours(-12).ToShortDateString());//12小时前de那天的
            //website_depend.CacheTime = 60;
            DataTable dt_website_depend = website_depend.Select();

            //--------------------------------------------------------- 
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

            dt_website_depend.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            dt_website_depend.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dt_website_depend.Columns.Add(new DataColumn("IsMy", typeof(int)));

            foreach (DataRow oDr_website_depend in dt_website_depend.Rows)
            {
                DataRow[] oDrs_website_depend = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_website_depend[website_my_pageurl_all._PAGEURL].ToString() + "'");
                if (oDrs_website_depend != null && oDrs_website_depend.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_depend)
                    {
                        WebManager_Name += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + ",";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + " ";
                        if (oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() == CurrentWebManagerName_v)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_website_depend[website_my_pageurl_all._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_website_depend["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr_website_depend["IsMy"] = IsMy;
                }
            }

            foreach (DataRow oDr in oDt.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr[website_depend._DEPEND_PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr_website_my_pageurl in oDrs_website_my_pageurl)
                    {
                        WebManager_RealName += oDr_website_my_pageurl["WebManager_RealName"].ToString() + " ";
                        if (oDr_website_my_pageurl[website_my_pageurl_all._WEBMANAGER_NAME].ToString() == CurrentWebManagerName_v)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                    oDr["IsMy"] = IsMy;
                }

                string depend_pageurl = oDr[website_depend._DEPEND_PAGEURL].ToString();
                string Depend_PageUrl_Out = "";
                string Depend_WebManager_RealName = "";
                string Depend_WebManager_Name = "";
                DataRow[] oDrs_website_depend = dt_website_depend.Select(website_depend._DEPEND_PAGEURL + "='" + depend_pageurl + "'");
                if (oDrs_website_depend != null && oDrs_website_depend.Length > 0)
                {
                    Depend_PageUrl_Out = "<p>此接口被如下URL调用：<p/>";
                    int i = 0;
                    foreach (DataRow oDr_website_depend in oDrs_website_depend)
                    {
                        i++;
                        Depend_PageUrl_Out += i.ToString() + "、<font color=red>" + oDr_website_depend[website_depend._PAGEURL].ToString() + "</font>";
                        string param = "PageUrl=" + Com.Common.EncDec.Encrypt(oDr_website_depend[website_depend._PAGEURL].ToString(), this.Encrypt_key) + "&BackUrl=" + Server.UrlEncode(Business.Config.HostUrl + "/Manager/Depend/Depend_List_My.aspx");
                        if (!string.IsNullOrEmpty(oDr_website_depend["WebManager_RealName"].ToString()))
                        {
                            Depend_PageUrl_Out += " [" + oDr_website_depend["WebManager_RealName"].ToString() + "]";
                            if (oDr_website_depend["IsMy"].ToString() == "1")
                            {
                                Depend_PageUrl_Out += " <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?" + param + "\"><font color=black>删除</font></a>";
                            }
                        }
                        else
                        {
                            Depend_PageUrl_Out += " <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?" + param + "\"><font color=black>认领</font></a>";
                        }
                        Depend_PageUrl_Out += "<br/><br/>";
                        string[] WebManager_RealNames = oDr_website_depend["WebManager_RealName"].ToString().Split(' ');
                        foreach (string realname in WebManager_RealNames)
                        {
                            if (!string.IsNullOrEmpty(realname))
                            {
                                if (Depend_WebManager_RealName.IndexOf(realname) == -1)
                                {
                                    Depend_WebManager_RealName += realname + " ";
                                    Depend_WebManager_Name += oDr_website_depend["WebManager_Name"].ToString() + ",";
                                }
                            }
                        }
                    }
                }
                oDr["Depend_PageUrl_Out"] = Depend_PageUrl_Out;
                oDr["Depend_WebManager_RealName"] = Depend_WebManager_RealName;
                oDr["Depend_WebManager_Name"] = Depend_WebManager_Name;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
