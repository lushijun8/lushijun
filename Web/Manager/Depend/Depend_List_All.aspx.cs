using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Depend
{
    public partial class Depend_List_All : Business.ManageWeb
    {
        public string P_Today = "";
        public string P_keyword = "";
        public string P_notlikekeyword = "";
        public string P_orderby = "";
        public int LogCount = 0;
        public string P_My = "0";
        private string P_CurrentWebManagerName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Depend/Depend_List_All.aspx");
            this.P_orderby = QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_orderby))
            {
                this.P_orderby = "DEPEND_CREATETIME DESC";
            }
            this.P_Today = this.QueryString("today");
            if (string.IsNullOrEmpty(this.P_Today))
            {
                this.P_Today = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            this.P_My = this.QueryString("My");
            if (string.IsNullOrEmpty(this.P_My))
            {
                this.P_My = "0";
            }
            this.P_CurrentWebManagerName = this.CurrentWebManagerName;
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                this.P_CurrentWebManagerName = this.QueryString("v");
            }
            if (!Page.IsPostBack)
            {
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.P_notlikekeyword = QueryString("notlikekeyword");
                this.txtNotLikeKeyWord.Text = this.P_notlikekeyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            DataTable oDt_website_depend = null;


            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.LEFT_JOIN_WEBSITE_PAGEURL_ON_DEPEND_PAGEURL = true;
            website_depend.SelectColumns = new string[] { 
                website_depend.TableName+"."+website_depend._DEPEND_PAGEURL,
                website_depend._DEPEND_CONTENTTYPE,
                website_depend._STATS_DATE,  
                website_depend._DEPEND_TIMEOUT,  
              

                
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
                "website_pageurl.webmanager_name_depend",
                "website_pageurl.webmanager_realname_depend",
                "website_pageurl.webmanager_realname_like",


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
            website_depend.GroupBy = website_depend.TableName + "." + website_depend._DEPEND_PAGEURL + "," + website_depend._STATS_DATE + "," + website_depend._DEPEND_CONTENTTYPE + "," + website_depend._DEPEND_TIMEOUT +
            ",website_pageurl.ErrorInfo,website_pageurl.ErrorTime,website_pageurl.Depend_PageUrl,website_pageurl.Depend_PageUrl_Out,website_pageurl.form_Phone_Encrypt,website_pageurl.querystring_Phone_Encrypt,website_pageurl.querystring,website_pageurl.form,website_pageurl.webmanager_name,website_pageurl.webmanager_realname,website_pageurl.webmanager_name_depend,website_pageurl.webmanager_realname_depend,website_pageurl.webmanager_realname_like";

            //website_depend.OrderBy = this.P_orderby ;
            if (DateTime.Parse(this.P_Today) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                website_depend.CacheName = "Depend_List_All_history" ;
                website_depend.CacheTime = 480;
            }
            else
            {
                website_depend.CacheName = "Depend_List_All_" + this.P_Today;
                website_depend.CacheTime = 15;
            }
            oDt_website_depend = website_depend.Select();
            //get_Depend_Out(oDt_website_depend, this.CurrentWebManagerName);//外部依赖 

            oDt_website_depend.Columns.Add(new DataColumn("DEPEND_CONTENTTYPE_NEW", typeof(string)));
            oDt_website_depend.Columns.Add(new DataColumn("DEPEND_ERROR_RATE", typeof(decimal)));
            oDt_website_depend.Columns.Add(new DataColumn("DEPEND_TIMEOUT_RATE", typeof(decimal)));
            oDt_website_depend.Columns.Add(new DataColumn("IsMy", typeof(int)));
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
                if (oDr_website_depend["webmanager_name"].ToString().IndexOf(this.P_CurrentWebManagerName) > -1)
                {
                    oDr_website_depend["IsMy"] = 1;
                }
                else
                {
                    oDr_website_depend["IsMy"] = 0;
                }
            }

            DataView oDv = oDt_website_depend.DefaultView;
            oDv.RowFilter = "STATS_DATE='" + this.P_Today + "'";
            oDv.Sort = this.P_orderby;
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                oDv.RowFilter += "AND (DEPEND_PAGEURL LIKE '%" + this.txtKeyword.Text + "%' OR WebManager_RealName_Depend LIKE '%" + this.txtKeyword.Text + "%' OR WebManager_RealName LIKE '%" + this.txtKeyword.Text + "%')";
            }
            if (!string.IsNullOrEmpty(this.txtNotLikeKeyWord.Text))
            {
                string[] NotLikeKeyWords = this.txtNotLikeKeyWord.Text.Split(',');
                foreach (string NotLikeKeyWord in NotLikeKeyWords)
                {
                    if (!string.IsNullOrEmpty(NotLikeKeyWord))
                    {
                        oDv.RowFilter += "AND (DEPEND_PAGEURL NOT LIKE '%" + NotLikeKeyWord + "%')";
                    }
                }
            }
            if (this.P_My == "1")
            {
                oDv.RowFilter += " AND WebManager_Name_Depend LIKE '%" + this.P_CurrentWebManagerName + "%' ";
            }
            //--------------------------------------------------------------
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
