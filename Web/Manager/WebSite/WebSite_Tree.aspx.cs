using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_Tree : Business.ManageWeb
    {
        public string treehtml = "";
        public string P_keyword = "";
        public int LogCount = 0;
        public int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_Tree.aspx");
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
            string CacheName = "Welcome_" + this.CurrentWebManagerName + "_18";

            if (Cache[CacheName] != null)
            {
                treehtml = (string)Cache[CacheName];
            }
            else
            {
                Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
                website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
                website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
                DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

                Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
                website_pageurl.CacheTime = 600;
                website_pageurl.SelectColumns = new string[] { website_pageurl._PAGEURL };
                DataTable oDt_PageUrl = website_pageurl.Select();
                //--------------------------------------------------------- 
                oDt_PageUrl.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
                oDt_PageUrl.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
                oDt_PageUrl.Columns.Add(new DataColumn("IsMy", typeof(int)));

                foreach (DataRow oDr_PageUrl in oDt_PageUrl.Rows)
                {

                    DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_PageUrl[website_my_pageurl_all._PAGEURL].ToString() + "'");
                    if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                    {
                        string WebManager_Name = "";
                        string WebManager_RealName = "";
                        int IsMy = 0;
                        foreach (DataRow oDr in oDrs_website_my_pageurl)
                        {
                            WebManager_Name += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + ",";
                            WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                            if (oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                            {
                                IsMy = 1;
                            }
                        }
                        oDr_PageUrl[website_my_pageurl_all._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                        oDr_PageUrl["WebManager_RealName"] = WebManager_RealName.TrimEnd(',');
                        oDr_PageUrl["IsMy"] = IsMy;
                    }
                }
                //

                //--------------------------------------------------------------
                DataView oDv = oDt_PageUrl.DefaultView;
                oDv.RowFilter = "";
                if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
                {
                    oDv.RowFilter = "PAGEURL LIKE '%" + this.txtKeyword.Text + "%' or WEBMANAGER_NAME='" + this.txtKeyword.Text + "'";
                }
                DataTable oDtNew_PageUrl = oDt_PageUrl.Clone();
                foreach (DataRowView oDr_New in oDv)
                {
                    DataRow oDr_add = oDtNew_PageUrl.NewRow();
                    oDr_add.ItemArray = oDr_New.Row.ItemArray;
                    oDtNew_PageUrl.Rows.Add(oDr_add);
                }
                DataRow[] oDrs_New_WebManager_Name = oDtNew_PageUrl.Select("WebManager_Name <> ''");
                string path = "http:/";
                this.treehtml += "<li class=\"expandable\">";
                this.treehtml += "<div class=\"hitarea collapsable-hitarea\"></div><span>" + path + "/(" + oDrs_New_WebManager_Name.Length + "/" + oDtNew_PageUrl.Rows.Count + ")</span>";
                this.treehtml += "<ul style=\"display: block;\">" + gettree(path, oDtNew_PageUrl) + "</ul>";
                this.treehtml += "</li>";
                oDt_PageUrl.Dispose();
                Cache.Add(CacheName, this.treehtml, null, System.DateTime.Now.Add(new TimeSpan(8,0,0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            #endregion
        }
        public ArrayList arr_pageurl = new ArrayList();
        public string gettree(string path, DataTable oDt)
        {
            oDt.CaseSensitive = true;
            string html = "";
            ArrayList arr = new ArrayList();
            DataRow[] oDrs = oDt.Select("PAGEURL LIKE '" + path + "/%' AND PAGEURL <> '" + path + "' AND PAGEURL <> '" + path + "/' ");

            foreach (DataRow oDr in oDrs)
            {
                string pageurl = oDr["PAGEURL"].ToString();
                string pathname = pageurl.Replace(path, "").Substring(1).Split('/')[0];
                if (pageurl.Length > path.Length + 1 && !arr.Contains(pathname))
                {
                    arr.Add(pathname);
                    string newpath = path + "/" + pathname;
                    DataRow[] oDrs_New = oDt.Select("PAGEURL LIKE '" + newpath + "/%' AND PAGEURL <> '" + newpath + "' AND PAGEURL <> '" + newpath + "/' ");
                    if (oDrs_New.Length > 0)
                    {
                        DataTable oDtNew = oDt.Clone(); // 复制DataRow的表结构
                        foreach (DataRow oDr_New in oDrs_New)
                        {
                            DataRow oDr_add = oDtNew.NewRow();
                            oDr_add.ItemArray = oDr_New.ItemArray;
                            oDtNew.Rows.Add(oDr_add); // 将DataRow添加到DataTable中
                        }
                        string delete_Html = "";
                        int iGet = 0;
                        DataRow[] oDrs_New_WebManager_Name = oDtNew.Select("WebManager_Name <> ''");
                        iGet = oDrs_New_WebManager_Name.Length;
                        if (this.CurrentIsAdmin == true)
                        {
                            if (iGet == 0)
                            {
                                delete_Html = " <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_Tree_Delete.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(newpath, this.Encrypt_key) + "\" target=\"_blank\" onclick=\"javascript:return confirm_me('" + newpath + "');\">删除</a>";
                            }
                        }
                        html += "<li class=\"expandable\">";
                        html += "<div class=\"hitarea expandable-hitarea\"></div><span>" + newpath + "/ (" + 
                            (iGet == 0 ? "0" : ("<font color=green>" + iGet.ToString() + "</font>"))
                            + "/" + oDrs_New.Length + ")" +
                            delete_Html +
                            "</span>";
                        html += "<ul style=\"display: none;\">" + gettree(newpath, oDtNew) + "</ul>";
                        html += "</li>";
                    }
                    else if (pageurl != path && pageurl != path + "/")
                    {
                        string IsMy = oDr["IsMy"].ToString();
                        string WebManager_Name = oDr["WebManager_Name"].ToString();
                        string WebManager_RealName = oDr["WebManager_RealName"].ToString();
                        string WebManager_Name_html = "";
                        string IsMy_html = "";
                        if (WebManager_Name != "")
                        {
                            if (WebManager_Name.IndexOf(",") > -1)
                            {
                                WebManager_Name_html = "" + WebManager_Name;
                            }
                            else
                            {
                                WebManager_Name_html = "<a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_Tree.aspx?keyword=" + WebManager_Name + "\">" + WebManager_RealName + "</a>";

                            }
                        }
                        if (IsMy == "1")
                        {
                            IsMy_html = " , <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(pageurl, this.Encrypt_key) + "\" onclick=\"javascript:return confirm_me('" + pageurl + "');\">删除</a>";
                        }
                        else
                        {
                            IsMy_html = " , <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(pageurl, Encrypt_key) + "\" onclick=\"javascript:return confirm_me('" + pageurl + "');\">认领</a>";
                        }
                        if (!arr_pageurl.Contains(pageurl))
                        {
                            html += "<li>" + pageurl + " <span class=\"tool\">[" +
                                //this.i.ToString() + " , " +
                                WebManager_Name_html +
                                IsMy_html +
                                "]</span></li>";
                            i++;
                            arr_pageurl.Add(pageurl);
                        }
                    }
                }
            }
            return html;

        }

        public void get_Error(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("Content", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("Error_CreateTime", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("IP", typeof(string)));
            dt.Columns.Add(new DataColumn("username", typeof(string)));
            dt.Columns.Add(new DataColumn("classname", typeof(string)));
            dt.Columns.Add(new DataColumn("MethodName", typeof(string)));
            dt.Columns.Add(new DataColumn("loglevel", typeof(int)));

            Entity.TEAMTOOL.LOG_STATS log_stats_today_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_today_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            log_stats_today_all.CacheTime = 10;
            DataTable dt_log_stats_today_all = log_stats_today_all.Select();

            Entity.TEAMTOOL.LOG_STATS log_stats_yestoday_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_yestoday_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
            log_stats_yestoday_all.CacheTime = 10;
            DataTable dt_log_stats_yestoday_all = log_stats_yestoday_all.Select();

            foreach (DataRow oDr_Connect_Log_Stats in dt.Rows)
            {
                string pageurl = oDr_Connect_Log_Stats[log_stats_today_all._PAGEURL].ToString();
                string pageurl_regex = pageurl;
                string[] pageurls = pageurl.Split('/');
                if (pageurls.Length >= 3)
                {
                    pageurl_regex = pageurl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
                }
                DataRow[] oDrs_log_stats_today_all = dt_log_stats_today_all.Select(log_stats_today_all._PAGEURL_REGEX + "='" + pageurl_regex + "'");
                if (oDrs_log_stats_today_all != null && oDrs_log_stats_today_all.Length > 0)//今天的
                {
                    DataRow oDr_log_stats_today_all = oDrs_log_stats_today_all[0];
                    oDr_Connect_Log_Stats["Content"] = oDr_log_stats_today_all["Content"];
                    oDr_Connect_Log_Stats["Remarks"] = oDr_log_stats_today_all["Remarks"];
                    oDr_Connect_Log_Stats["Error_CreateTime"] = oDr_log_stats_today_all["Error_CreateTime"];
                    oDr_Connect_Log_Stats["Title"] = oDr_log_stats_today_all["Title"];
                    oDr_Connect_Log_Stats["IP"] = oDr_log_stats_today_all["IP"];
                    oDr_Connect_Log_Stats["username"] = oDr_log_stats_today_all["username"];
                    oDr_Connect_Log_Stats["classname"] = oDr_log_stats_today_all["classname"];
                    oDr_Connect_Log_Stats["MethodName"] = oDr_log_stats_today_all["MethodName"];
                    oDr_Connect_Log_Stats["loglevel"] = oDr_log_stats_today_all["loglevel"];

                }
                else//昨天的
                {
                    DataRow[] oDrs_log_stats_yestoday_all = dt_log_stats_yestoday_all.Select(log_stats_yestoday_all._PAGEURL_REGEX + "='" + pageurl_regex + "'");
                    if (oDrs_log_stats_yestoday_all != null && oDrs_log_stats_yestoday_all.Length > 0)//今天的
                    {
                        DataRow oDr_log_stats_yestoday_all = oDrs_log_stats_yestoday_all[0];
                        oDr_Connect_Log_Stats["Content"] = oDr_log_stats_yestoday_all["Content"];
                        oDr_Connect_Log_Stats["Remarks"] = oDr_log_stats_yestoday_all["Remarks"];
                        oDr_Connect_Log_Stats["Error_CreateTime"] = oDr_log_stats_yestoday_all["Error_CreateTime"];
                        oDr_Connect_Log_Stats["Title"] = oDr_log_stats_yestoday_all["Title"];
                        oDr_Connect_Log_Stats["IP"] = oDr_log_stats_yestoday_all["IP"];
                        oDr_Connect_Log_Stats["username"] = oDr_log_stats_yestoday_all["username"];
                        oDr_Connect_Log_Stats["classname"] = oDr_log_stats_yestoday_all["classname"];
                        oDr_Connect_Log_Stats["MethodName"] = oDr_log_stats_yestoday_all["MethodName"];
                        oDr_Connect_Log_Stats["loglevel"] = oDr_log_stats_yestoday_all["loglevel"];
                    }

                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }

}