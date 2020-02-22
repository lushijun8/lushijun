using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Depend
{
    public partial class Depend_Tree : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string dependhtml = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Depend/Depend_Tree.aspx"); this.P_Today = this.QueryString("today");
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
            string pageurl = "substring(replace(replace( website_depend.pageurl,'http://',''),'https://','')    +'/',1, CHARINDEX('/',replace(replace( website_depend.pageurl,'http://',''),'https://',''))-1)";
            string Depend_PageUrl = "substring( replace(replace( website_depend.Depend_PageUrl,'http://',''),'https://','')    +'/',1, CHARINDEX('/',replace(replace( website_depend.Depend_PageUrl,'http://',''),'https://',''))-1)";
            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.Distinct = true;
            website_depend.LEFT_JOIN_WEBSITE_PAGEURL_ON_DEPEND_PAGEURL = true;
            website_depend.SelectColumns = new string[] { 
                pageurl+" AS pageurl_domain",
                Depend_PageUrl+" AS depend_pageurl_domain",
                " website_depend."+website_depend._DEPEND_PAGEURL+"",
                
                "website_pageurl.ErrorInfo",
                "website_pageurl.ErrorTime",
                "website_pageurl.Depend_PageUrl AS Depend_PageUrl_Info",
                "website_pageurl.Depend_PageUrl_Out",
                "website_pageurl.form_Phone_Encrypt",
                "website_pageurl.querystring_Phone_Encrypt",
                "website_pageurl.querystring",
                "website_pageurl.form",
                "website_pageurl.webmanager_name",
                "website_pageurl.webmanager_realname",
                "website_pageurl.webmanager_realname_depend",
                "website_pageurl.webmanager_realname_like",


                "sum("+website_depend._DEPEND_COUNT+") as "+website_depend._DEPEND_COUNT+"",                
                "SUM("+website_depend._DEPEND_COUNT_ERROR+") AS "+website_depend._DEPEND_COUNT_ERROR+"",
                "SUM("+website_depend._DEPEND_COUNT_TIMEOUT+") AS "+website_depend._DEPEND_COUNT_TIMEOUT+"",
                "SUM("+website_depend._DEPEND_TIMESPAN_SUM+")/SUM("+website_depend._DEPEND_COUNT+") AS "+website_depend._DEPEND_TIMESPAN_AVERAGE+"",
                "MAX("+website_depend._DEPEND_TIMESPAN_MAX+") AS "+website_depend._DEPEND_TIMESPAN_MAX+"",
                "MIN("+website_depend._DEPEND_TIMESPAN_MIN+") AS "+website_depend._DEPEND_TIMESPAN_MIN+"",
                "MAX("+website_depend._DEPEND_CREATETIME+") AS "+website_depend._DEPEND_CREATETIME+"" 

            };
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                website_depend.WhereSql = "( website_depend." + website_depend._PAGEURL + " LIKE '%" + this.txtKeyword.Text + "%' OR website_depend." + website_depend._DEPEND_PAGEURL + " LIKE '%" + this.txtKeyword.Text + "%')";
            }
            if (!string.IsNullOrEmpty(this.P_Today) && this.P_Today != "all")
            {
                website_depend.STATS_DATE = DateTime.Parse(this.P_Today);
            }
            website_depend.OrderBy = "Depend_Count DESC, website_depend.Depend_PageUrl";
            website_depend.GroupBy = pageurl + "," + Depend_PageUrl + ",website_depend.Depend_PageUrl" +
                ",website_pageurl.ErrorInfo,website_pageurl.ErrorTime,website_pageurl.Depend_PageUrl,website_pageurl.Depend_PageUrl_Out,website_pageurl.form_Phone_Encrypt,website_pageurl.querystring_Phone_Encrypt,website_pageurl.querystring,website_pageurl.form,website_pageurl.webmanager_name,website_pageurl.webmanager_realname,website_pageurl.webmanager_realname_depend,website_pageurl.webmanager_realname_like";
             
            DataTable oDt = website_depend.Select();

            //Depend_List_All.get_Depend_Out(oDt, this.CurrentWebManagerName);//外部依赖 

            this.LogCount = oDt.Rows.Count;

            ArrayList pageurl_domains = new ArrayList();
            foreach (DataRow oDr in oDt.Rows)
            {
                if (!pageurl_domains.Contains(oDr["pageurl_domain"].ToString()))
                {
                    pageurl_domains.Add(oDr["pageurl_domain"].ToString());
                }
            }

            dependhtml += "<table class=\"joblist\" width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\"><tr><th>本地域名</th><th>依赖域名</th><th>序号</th><th>依赖URL</th><th>调用次数</th><th>负责人</th><th>调用人</th><th>错误数</th><th>错误率</th><th>超时数</th><th>超时率</th><th>耗时</th><th>平均</th><th>最后调用时间</th></tr><tr>";
            int no = 1;
            for (int i = 0; i < pageurl_domains.Count; i++)
            {
                DataRow[] oDrs_depend_pageurl_domains = oDt.Select("pageurl_domain='" + pageurl_domains[i].ToString() + "'");
                if (i > 0)
                {
                    dependhtml += "</tr><tr>";
                }
                dependhtml += "<td rowspan=\"" + oDrs_depend_pageurl_domains.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/Depend/Depend_Tree.aspx?today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(pageurl_domains[i].ToString()) + "\">" + pageurl_domains[i].ToString() + "</a></td>";
                #region 获取依赖域名
                ArrayList depend_pageurl_domains = new ArrayList();
                foreach (DataRow oDr in oDrs_depend_pageurl_domains)
                {
                    if (!depend_pageurl_domains.Contains(oDr["depend_pageurl_domain"].ToString()))
                    {
                        depend_pageurl_domains.Add(oDr["depend_pageurl_domain"].ToString());
                    }
                }
                for (int j = 0; j < depend_pageurl_domains.Count; j++)
                {
                    DataRow[] oDrs_depend_pageurls = oDt.Select("pageurl_domain='" + pageurl_domains[i].ToString() + "' and depend_pageurl_domain='" + depend_pageurl_domains[j].ToString() + "'");
                    if (j > 0)
                    {
                        dependhtml += "</tr><tr>";
                    }
                    dependhtml += "<td rowspan=\"" + oDrs_depend_pageurls.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/Depend/Depend_Tree.aspx?today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(depend_pageurl_domains[j].ToString()) + "\">" + depend_pageurl_domains[j].ToString() + "</a></td>";
                    #region 获取依赖URL
                    ArrayList depend_pageurl = new ArrayList();
                    ArrayList depend_pageurl_count = new ArrayList();
                    ArrayList depend_count_error = new ArrayList();
                    ArrayList depend_count_timeout = new ArrayList();
                    ArrayList depend_timespan_max = new ArrayList();
                    ArrayList depend_timespan_min = new ArrayList();
                    ArrayList depend_timespan_average = new ArrayList();
                    ArrayList depend_createtime = new ArrayList();
                    ArrayList Depend_WebManager_RealName = new ArrayList();
                    ArrayList WebManager_RealName = new ArrayList();
                    ArrayList IsMy = new ArrayList();
                    ArrayList Depend_PageUrl_Out = new ArrayList();
                    ArrayList Depend_PageUrl_Info = new ArrayList();
                    ArrayList ErrorInfo = new ArrayList();
                    
                    foreach (DataRow oDr in oDrs_depend_pageurls)
                    {
                        if (!depend_pageurl.Contains(oDr["depend_pageurl"].ToString()))
                        {
                            depend_pageurl.Add(oDr["depend_pageurl"].ToString());
                            depend_pageurl_count.Add(oDr["Depend_Count"].ToString());
                            depend_count_error.Add(oDr["Depend_Count_error"].ToString());
                            depend_count_timeout.Add(oDr["Depend_Count_timeout"].ToString());

                            depend_timespan_max.Add(oDr["depend_timespan_max"].ToString());
                            depend_timespan_min.Add(oDr["depend_timespan_min"].ToString());
                            depend_timespan_average.Add(oDr["depend_timespan_average"].ToString());
                            depend_createtime.Add(oDr["depend_createtime"].ToString());
                            Depend_WebManager_RealName.Add(oDr["WebManager_RealName_Depend"].ToString());
                            WebManager_RealName.Add(oDr["WebManager_RealName"].ToString());
                            string IsMyUrl = "0";
                            if (oDr["WebManager_Name"].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                            {
                                IsMyUrl = "1";
                            }
                            IsMy.Add(IsMyUrl);
                            Depend_PageUrl_Out.Add(oDr["Depend_PageUrl_Out"].ToString());
                            Depend_PageUrl_Info.Add(oDr["Depend_PageUrl_Info"].ToString());
                            ErrorInfo.Add(oDr["ErrorInfo"].ToString());
                        }
                    }
                    for (int k = 0; k < depend_pageurl.Count; k++)
                    {
                        if (k > 0)
                        {
                            dependhtml += "</tr><tr>";
                        }
                        string getMy = "";
                        if (IsMy[k].ToString() == "1")
                        {
                            getMy = "<a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(depend_pageurl[k].ToString(), this.Encrypt_key) + "\" onclick=\"javascript:return confirm_me('" + depend_pageurl[k].ToString() + "')\">删除</a>";

                        }
                        else
                        {
                            getMy = "<a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(depend_pageurl[k].ToString(), this.Encrypt_key) + "\" onclick=\"javascript:return confirm_me('" + depend_pageurl[k].ToString() + "')\">认领</a>";
                        }

                        dependhtml += "<td>" + no.ToString() + "</td><td><a href=\"" + Business.Config.HostUrl + "/Manager/Depend/Depend_Tree.aspx?today=" + Server.UrlEncode(this.P_Today) + "&keyword=" + Server.UrlEncode(depend_pageurl[k].ToString()) + "\">" + depend_pageurl[k].ToString() + "</a>" +
                            (ErrorInfo[k].ToString() != "" ? (" <span class=\"bug_tooltip\" titles=\"" + ErrorInfo[k].ToString().Replace("\"", "'") + "\"></span>") : "") +
                            (Depend_PageUrl_Info[k].ToString()+Depend_PageUrl_Out[k].ToString() != "" ? (" <span class=\"depend_tooltip\" titles=\"" + Depend_PageUrl_Info[k].ToString().Replace("\"", "'")+Depend_PageUrl_Out[k].ToString().Replace("\"", "'") + "\"></span>") : "") +
                                    "</td>" +
                        "<td>" + depend_pageurl_count[k].ToString() + "</td>" +
                            "<td>" + WebManager_RealName[k].ToString() + getMy + "</td><td>" + Depend_WebManager_RealName[k].ToString() + "</td><td>" + depend_count_error[k].ToString() + "</td><td>" +
                             (decimal.Parse(depend_count_error[k].ToString()) * 100 / decimal.Parse(depend_pageurl_count[k].ToString())).ToString("f2").Replace(".00", "") + "%</td><td>" +
                            depend_count_timeout[k].ToString() + "</td><td>" +
                             (decimal.Parse(depend_count_timeout[k].ToString()) * 100 / decimal.Parse(depend_pageurl_count[k].ToString())).ToString("f2").Replace(".00", "") + "%</td><td>" +
                            (decimal.Parse(depend_timespan_min[k].ToString()) / 1000).ToString("f2").Replace(".00", "") + "～" +
                            (decimal.Parse(depend_timespan_max[k].ToString()) / 1000).ToString("f2").Replace(".00", "") + "秒</td><td>" +
                            (decimal.Parse(depend_timespan_average[k].ToString()) / 1000).ToString("f2").Replace(".00", "") + "秒</td><td>"
                            + depend_createtime[k].ToString() + "</td>";
                        no++;
                    }
                    #endregion
                    dependhtml += "";
                }
                #endregion
                dependhtml += "";
            }
            dependhtml += "</tr></table>";
            dependhtml = dependhtml.Replace("<tr></tr>", "").Replace("<td>0</td>", "<td></td>").Replace("<td>0秒</td>", "<td></td>").Replace("<td>0%</td>", "<td></td>");
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
            #region 绑定域名
            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend_doamin = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend_doamin.SelectColumns = new string[] { "SUBSTRING(REPLACE(REPLACE(" + website_depend_doamin._DEPEND_PAGEURL + ", 'http://', ''), 'https://', '') + '/', 1, CHARINDEX('/', REPLACE(REPLACE(" + website_depend_doamin._DEPEND_PAGEURL + ", 'http://', ''), 'https://', '')) - 1) AS DOMAIN" };
            website_depend_doamin.Distinct = true;
            website_depend_doamin.WhereSql = website_depend_doamin._STATS_DATE + ">Dateadd(day,-2,getdate())";
            website_depend_doamin.CacheTime = 1440;
            DataTable oDt_Domain = website_depend_doamin.Select();

            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend_doamin1 = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend_doamin1.SelectColumns = new string[] { "SUBSTRING(REPLACE(REPLACE(" + website_depend_doamin1._PAGEURL + ", 'http://', ''), 'https://', '') + '/', 1, CHARINDEX('/', REPLACE(REPLACE(" + website_depend_doamin1._PAGEURL + ", 'http://', ''), 'https://', '')) - 1) AS DOMAIN" };
            website_depend_doamin1.Distinct = true;
            website_depend_doamin1.WhereSql = website_depend_doamin1._STATS_DATE + ">Dateadd(day,-2,getdate())";
            website_depend_doamin1.CacheTime = 1440;
            DataTable oDt_Domain1 = website_depend_doamin1.Select();
            foreach (DataRow oDr in oDt_Domain1.Rows)
            {
                DataRow[] oDrs = oDt_Domain.Select("DOMAIN='" + oDr["DOMAIN"].ToString() + "'");
                if (oDrs == null || oDrs.Length == 0)
                {
                    DataRow oDr_New = oDt_Domain.NewRow();
                    oDr_New["DOMAIN"] = oDr["DOMAIN"].ToString();
                    oDt_Domain.Rows.Add(oDr_New);
                }
            }
            this.rpt_Domain.DataSource = oDt_Domain;
            this.rpt_Domain.DataBind();
            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
