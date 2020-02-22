using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager
{
    public partial class Report : Com.Web.WebUI
    {
        public string ConnectString_Date = "";
        public string CurrentWebManagerName = "";
        public string Encrypt_key = "fang.com";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentWebManagerName = this.QueryString("WebManager_Name");
            if (string.IsNullOrEmpty(this.CurrentWebManagerName))
            {
                this.CurrentWebManagerName = "xxxxxxxxx";
            }
            this.BindData();
        }
        private void BindData()
        {
            #region 绑定服务器和数据库列表
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_ID, database_owner._DATABASE_IP_LOCAL, database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_VIP_LOCAL, database_owner._DATABASE_VIP_ROMOTE, database_owner._DATABASE_IP_SPECIAL, database_owner._DATABASE_NAME, database_owner._DATABASE_REMARK, database_owner._DATABASE_ADMIN_USER, database_owner._DATABASE_ADMIN_PASSWORD, database_owner._DATABASE_READER_USER, database_owner._DATABASE_READER_PASSWORD, database_owner._DATABASE_WRITER_USER, database_owner._DATABASE_WRITER_PASSWORD };
            database_owner.OrderBy = database_owner._DATABASE_NAME + " ASC";
            database_owner.CacheTime = 1440;
            DataTable dt_database_owner = database_owner.Select(10);
            this.rptDataBase.DataSource = dt_database_owner;
            this.rptDataBase.DataBind();
            //-------------------------------------------
            Entity.TEAMTOOL.DATABASE_CONNECTSTRING database_connectstring = new Entity.TEAMTOOL.DATABASE_CONNECTSTRING();
            database_connectstring.OrderBy = database_connectstring._DATABASE_CONNECT_TIMES + " DESC";
            database_connectstring.CacheTime = 20;
            DataTable dt_database_connectstring = database_connectstring.Select(10);
            dt_database_connectstring.Columns.Add(new DataColumn(database_owner._DATABASE_ID, typeof(int)));
            //dt_database_connectstring.Columns.Add(new DataColumn(database_owner._DATABASE_REMARK, typeof(string)));
            foreach (DataRow oDr_database_connectstring in dt_database_connectstring.Rows)
            {

                DataRow[] oDrs_database_owner = dt_database_owner.Select(database_connectstring._DATABASE_IP_ROMOTE + "='" + oDr_database_connectstring[database_connectstring._DATABASE_IP_ROMOTE].ToString().Split('/')[0] + "' and " + database_connectstring._DATABASE_NAME + "='" + oDr_database_connectstring[database_connectstring._DATABASE_NAME].ToString() + "'");
                if (oDrs_database_owner != null && oDrs_database_owner.Length > 0)
                {
                    oDr_database_connectstring[database_owner._DATABASE_ID] = oDrs_database_owner[0][database_owner._DATABASE_ID].ToString();
                    //oDr_database_connectstring[database_owner._DATABASE_REMARK] = oDrs_database_owner[0][database_owner._DATABASE_REMARK].ToString();
                }
            }
            dt_database_connectstring.AcceptChanges();
            this.rptConnectstring.DataSource = dt_database_connectstring;
            this.rptConnectstring.DataBind();

            Entity.TEAMTOOL.DATABASE_CONNECT_LOG database_connect_log_min_date = new Entity.TEAMTOOL.DATABASE_CONNECT_LOG();
            database_connect_log_min_date.SelectColumns = new string[] { "min(" + database_connect_log_min_date._CONNECTIME + ") AS " + database_connect_log_min_date._CONNECTIME };
            database_connect_log_min_date.CacheTime = 60;
            database_connect_log_min_date.SelectTop1();
            this.ConnectString_Date = database_connect_log_min_date.CONNECTIME_ToString;
            //-------------------------------------------
            Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
            server_update_log.OrderBy = server_update_log._ID + " DESC";
            DataTable dt_server_update_log = server_update_log.Select(5);
            this.rptServerUpdateLog.DataSource = dt_server_update_log;
            this.rptServerUpdateLog.DataBind();
            //-------------------------------------------

            Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
            server_update_password.OrderBy = server_update_password._ID + " DESC";
            DataTable dt_server_update_password = server_update_password.Select(5);
            this.rptServerUpdatePassword.DataSource = dt_server_update_password;
            this.rptServerUpdatePassword.DataBind();
            #endregion

            #region 获取pageurl统计数据和已认领数据
            //---------------------------------------------------------
            string Sql_today = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + System.DateTime.Now.ToShortDateString() + "','5000' ,'','connectionstring_today_min'";
            // string cacheName_today = Com.Common.EncDec.PasswordEncrypto(Sql_today);
            DataTable dt_Connect_Log_Stats_today = null;// Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName_today, 20);
            // if (dt_Connect_Log_Stats_today == null)
            {
                dt_Connect_Log_Stats_today = server_update_log.Database_Owner.ExecuteDataSet(CommandType.Text, Sql_today).Tables[0];
                // Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName_today, dt_Connect_Log_Stats_today, 20);
            }
            //---------------------------------------------------------
            string Sql_yestoday = "EXECUTE SP_DataBase_Connect_Log_Stats_Search '" + System.DateTime.Now.AddDays(-1).ToShortDateString() + "','5000' ,'','connectionstring_today_min'";
            //string cacheName_yestoday = Com.Common.EncDec.PasswordEncrypto(Sql_yestoday);
            DataTable dt_Connect_Log_Stats_yestoday = null;// Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, cacheName_yestoday, 20);
            // if (dt_Connect_Log_Stats_yestoday == null)
            {
                dt_Connect_Log_Stats_yestoday = server_update_log.Database_Owner.ExecuteDataSet(CommandType.Text, Sql_yestoday).Tables[0];
                //Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, cacheName_yestoday, dt_Connect_Log_Stats_yestoday, 20);
            }
            //----------------------------------------------------------
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            DataTable oDt_website_my_pageurl = website_my_pageurl.Select();
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
            DataTable oDt_website_my_pageurl_ignore = website_my_pageurl_ignore.Select();

            #endregion


            #region 绑定我认领的页面列表

            DataRow[] oDrs_website_my_pageurl_my = oDt_website_my_pageurl.Select("WEBMANAGER_NAME='" + this.CurrentWebManagerName + "'");
            DataTable oDt_website_my_pageurl_my = oDt_website_my_pageurl.Clone();
            foreach (DataRow oDr in oDrs_website_my_pageurl_my)
            {
                DataRow oNewRow = oDt_website_my_pageurl_my.NewRow();
                oNewRow.ItemArray = oDr.ItemArray;
                oDt_website_my_pageurl_my.Rows.Add(oNewRow);
            }

            //--------------------------------------------------------- 
            oDt_website_my_pageurl_my.Columns.Add(new DataColumn("request_count_today", typeof(int)));
            oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_today_min", typeof(int)));
            oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_yestoday_min", typeof(int)));
            oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_today_max", typeof(int)));
            oDt_website_my_pageurl_my.Columns.Add(new DataColumn("connectionstring_yestoday_max", typeof(int)));

            foreach (DataRow oDr_website_my_pageurl_my in oDt_website_my_pageurl_my.Rows)
            {
                DataRow[] oDr_Connect_Log_Stats = dt_Connect_Log_Stats_today.Select(website_my_pageurl._PAGEURL + "='" + oDr_website_my_pageurl_my[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDr_Connect_Log_Stats != null && oDr_Connect_Log_Stats.Length > 0)
                {
                    oDr_website_my_pageurl_my["request_count_today"] = oDr_Connect_Log_Stats[0]["request_count_today"].ToString();
                    oDr_website_my_pageurl_my["connectionstring_today_min"] = oDr_Connect_Log_Stats[0]["connectionstring_today_min"].ToString();
                    oDr_website_my_pageurl_my["connectionstring_yestoday_min"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_min"].ToString();
                    oDr_website_my_pageurl_my["connectionstring_today_max"] = oDr_Connect_Log_Stats[0]["connectionstring_today_max"].ToString();
                    oDr_website_my_pageurl_my["connectionstring_yestoday_max"] = oDr_Connect_Log_Stats[0]["connectionstring_yestoday_max"].ToString();
                }
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_website_my_pageurl_my[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                    }
                    oDr_website_my_pageurl_my[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                }

            }
            //--------------------------------------------------------------
            int k = 0;
            DataTable oDt_website_my_pageurl_my_sort = oDt_website_my_pageurl_my.Clone();
            DataView oDv_website_my_pageurl_my = oDt_website_my_pageurl_my.DefaultView;
            oDv_website_my_pageurl_my.Sort = "connectionstring_today_min DESC";
            foreach (DataRowView oDv in oDv_website_my_pageurl_my)
            {
                DataRow oNewRow = oDt_website_my_pageurl_my_sort.NewRow();
                oNewRow.ItemArray = oDv.Row.ItemArray;
                oDt_website_my_pageurl_my_sort.Rows.Add(oNewRow);
                k++;
                if (k >= 5)
                {
                    break;
                }
            }

            this.rpt_website_my_pageurl_my.DataSource = oDt_website_my_pageurl_my_sort;
            this.rpt_website_my_pageurl_my.DataBind();
            #endregion

            #region 绑定疑似我的页面列表
            DataTable oDt_website_my_pageurl_my_like = dt_Connect_Log_Stats_today.Clone();
            oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_today, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 0);
            oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_yestoday, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 0);
            oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_today, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 1);
            oDt_website_my_pageurl_my_like = this.get_website_my_pageurl_like(dt_Connect_Log_Stats_yestoday, oDt_website_my_pageurl, oDt_website_my_pageurl_my, oDt_website_my_pageurl_my_like, 1);

            //过滤掉已经忽略的
            for (int i = oDt_website_my_pageurl_my_like.Rows.Count - 1; i >= 0; i--)
            {
                DataRow oDr_website_my_pageurl_my_like = oDt_website_my_pageurl_my_like.Rows[i];
                DataRow[] oDrs_website_my_pageurl_ignore = oDt_website_my_pageurl_ignore.Select(website_my_pageurl_ignore._PAGEURL + "='" + oDr_website_my_pageurl_my_like[website_my_pageurl_ignore._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl_ignore != null && oDrs_website_my_pageurl_ignore.Length > 0)
                {
                    oDt_website_my_pageurl_my_like.Rows[i].Delete();
                }
            }
            oDt_website_my_pageurl_my_like.AcceptChanges();
            DataView oDv_website_my_pageurl_my_like = oDt_website_my_pageurl_my_like.DefaultView;
            oDv_website_my_pageurl_my_like.Sort = "connectionstring_today_min DESC";


            this.rpt_website_my_pageurl_my_like.DataSource = oDv_website_my_pageurl_my_like;
            this.rpt_website_my_pageurl_my_like.DataBind();
            #endregion

            #region 绑定性能最差列表
            DataTable dt_connectionstring_today = dt_Connect_Log_Stats_today.Clone();
            DataTable dt_connectionstring_yestoday = dt_Connect_Log_Stats_yestoday.Clone();
            DataTable dt_duration_today = dt_Connect_Log_Stats_today.Clone();
            DataTable dt_duration_yestoday = dt_Connect_Log_Stats_yestoday.Clone();

            DataView oDv_connectionstring_today = dt_Connect_Log_Stats_today.DefaultView;
            oDv_connectionstring_today.Sort = "connectionstring_today_min DESC";
            k = 0;
            foreach (DataRowView oDv in oDv_connectionstring_today)
            {
                string pageurl = oDv.Row[website_my_pageurl._PAGEURL].ToString();
                //判断是否已经在我认领的和疑似我的列表中
                DataRow[] oDrs_my = oDt_website_my_pageurl_my.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs_my != null && oDrs_my.Length > 0)
                {
                    continue;
                }
                else
                {
                    DataRow[] oDrs_my_like = oDt_website_my_pageurl_my_like.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                    if (oDrs_my_like != null && oDrs_my_like.Length > 0)
                    {
                        continue;
                    }
                }
                DataRow oNewRow = dt_connectionstring_today.NewRow();
                oNewRow.ItemArray = oDv.Row.ItemArray;
                dt_connectionstring_today.Rows.Add(oNewRow);
                k++;
                if (k >= 5)
                {
                    break;
                }
            }
            k = 0;
            DataView oDv_connectionstring_yestoday = dt_Connect_Log_Stats_yestoday.DefaultView;
            oDv_connectionstring_yestoday.Sort = "connectionstring_today_min DESC";
            foreach (DataRowView oDv in oDv_connectionstring_yestoday)
            {
                string pageurl = oDv.Row[website_my_pageurl._PAGEURL].ToString();
                //判断是否已经在我认领的和疑似我的列表中
                DataRow[] oDrs_my = oDt_website_my_pageurl_my.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs_my != null && oDrs_my.Length > 0)
                {
                    continue;
                }
                else
                {
                    DataRow[] oDrs_my_like = oDt_website_my_pageurl_my_like.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                    if (oDrs_my_like != null && oDrs_my_like.Length > 0)
                    {
                        continue;
                    }
                }
                DataRow oNewRow = dt_connectionstring_yestoday.NewRow();
                oNewRow.ItemArray = oDv.Row.ItemArray;
                dt_connectionstring_yestoday.Rows.Add(oNewRow);
                k++;
                if (k >= 5)
                {
                    break;
                }
            }
            k = 0;
            DataView oDv_duration_today = dt_Connect_Log_Stats_today.DefaultView;
            oDv_duration_today.Sort = "duration_today_min DESC";
            foreach (DataRowView oDv in oDv_duration_today)
            {
                string pageurl = oDv.Row[website_my_pageurl._PAGEURL].ToString();
                //判断是否已经在我认领的和疑似我的列表中
                DataRow[] oDrs_my = oDt_website_my_pageurl_my.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs_my != null && oDrs_my.Length > 0)
                {
                    continue;
                }
                else
                {
                    DataRow[] oDrs_my_like = oDt_website_my_pageurl_my_like.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                    if (oDrs_my_like != null && oDrs_my_like.Length > 0)
                    {
                        continue;
                    }
                }
                DataRow oNewRow = dt_duration_today.NewRow();
                oNewRow.ItemArray = oDv.Row.ItemArray;
                dt_duration_today.Rows.Add(oNewRow);
                k++;
                if (k >= 5)
                {
                    break;
                }
            }
            k = 0;
            DataView oDv_duration_yestoday = dt_Connect_Log_Stats_yestoday.DefaultView;
            oDv_duration_yestoday.Sort = "duration_today_min DESC";
            foreach (DataRowView oDv in oDv_duration_yestoday)
            {
                string pageurl = oDv.Row[website_my_pageurl._PAGEURL].ToString();
                //判断是否已经在我认领的和疑似我的列表中
                DataRow[] oDrs_my = oDt_website_my_pageurl_my.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                if (oDrs_my != null && oDrs_my.Length > 0)
                {
                    continue;
                }
                else
                {
                    DataRow[] oDrs_my_like = oDt_website_my_pageurl_my_like.Select(website_my_pageurl._PAGEURL + " = '" + pageurl + "'");
                    if (oDrs_my_like != null && oDrs_my_like.Length > 0)
                    {
                        continue;
                    }
                }
                DataRow oNewRow = dt_duration_yestoday.NewRow();
                oNewRow.ItemArray = oDv.Row.ItemArray;
                dt_duration_yestoday.Rows.Add(oNewRow);
                k++;
                if (k >= 5)
                {
                    break;
                }
            }

            //-----------------------------------------------------------
            for (int i = dt_connectionstring_today.Rows.Count - 1; i > 0; i--)
            {
                DataRow oDr_Connect_Log_Stats = dt_connectionstring_today.Rows[i];
                if (int.Parse(oDr_Connect_Log_Stats["connectionstring_today_min"].ToString()) <= 1)
                {
                    dt_connectionstring_today.Rows[i].Delete();
                }
            }
            dt_connectionstring_today.AcceptChanges();
            dt_connectionstring_today.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_connectionstring_today.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_connectionstring_today.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }

            }
            //-----------------------------------------------------------
            for (int i = dt_connectionstring_yestoday.Rows.Count - 1; i > 0; i--)
            {
                DataRow oDr_Connect_Log_Stats = dt_connectionstring_yestoday.Rows[i];
                if (int.Parse(oDr_Connect_Log_Stats["connectionstring_today_min"].ToString()) <= 1)
                {
                    dt_connectionstring_yestoday.Rows[i].Delete();
                }
            }
            dt_connectionstring_yestoday.AcceptChanges();
            dt_connectionstring_yestoday.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_connectionstring_yestoday.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_connectionstring_yestoday.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }

            }

            //-----------------------------------------------------------
            for (int i = dt_duration_today.Rows.Count - 1; i > 0; i--)
            {
                DataRow oDr_Connect_Log_Stats = dt_duration_today.Rows[i];
                if (int.Parse(oDr_Connect_Log_Stats["duration_today_min"].ToString()) <= 1)
                {
                    dt_duration_today.Rows[i].Delete();
                }
            }
            dt_duration_today.AcceptChanges();
            dt_duration_today.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_duration_today.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_duration_today.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }

            }
            //-----------------------------------------------------------
            for (int i = dt_duration_yestoday.Rows.Count - 1; i > 0; i--)
            {
                DataRow oDr_Connect_Log_Stats = dt_duration_yestoday.Rows[i];
                if (int.Parse(oDr_Connect_Log_Stats["duration_today_min"].ToString()) <= 1)
                {
                    dt_duration_yestoday.Rows[i].Delete();
                }
            }
            dt_duration_yestoday.AcceptChanges();
            dt_duration_yestoday.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_duration_yestoday.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_duration_yestoday.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }

            }
            //---------------------------------------------------------- 
            this.rpt_connectionstring_today.DataSource = dt_connectionstring_today;
            this.rpt_connectionstring_today.DataBind();

            this.rpt_connectionstring_yestoday.DataSource = dt_connectionstring_yestoday;
            this.rpt_connectionstring_yestoday.DataBind();

            this.rpt_duration_today.DataSource = dt_duration_today;
            this.rpt_duration_today.DataBind();

            this.rpt_duration_yestoday.DataSource = dt_duration_yestoday;
            this.rpt_duration_yestoday.DataBind();



            //=======================================================================
            dt_Connect_Log_Stats_today.Columns.Add(new DataColumn(website_my_pageurl._WEBMANAGER_NAME, typeof(string)));
            dt_Connect_Log_Stats_today.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Connect_Log_Stats in dt_Connect_Log_Stats_today.Rows)
            {
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL + "='" + oDr_Connect_Log_Stats[website_my_pageurl._PAGEURL].ToString() + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_Name = "";
                    int IsMy = 0;
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                        if (oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() == this.CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr_Connect_Log_Stats[website_my_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(',');
                    oDr_Connect_Log_Stats["IsMy"] = IsMy;
                }

            }
            DataView dv_Connect_Log_Stats = dt_Connect_Log_Stats_today.DefaultView;
            dv_Connect_Log_Stats.Sort = "connectionstring_today_min DESC";
            this.rptLog.DataSource = dv_Connect_Log_Stats;
            this.rptLog.DataBind();

            #endregion


        }
        private DataTable get_website_my_pageurl_like(DataTable dt_Connect_Log_Stats, DataTable oDt_website_my_pageurl, DataTable oDt_website_my_pageurl_my, DataTable oDt_website_my_pageurl_my_like, int type)
        {
            foreach (DataRow oDr_website_my_pageurl_my in oDt_website_my_pageurl_my.Rows)
            {
                string pageurl = oDr_website_my_pageurl_my["PAGEURL"].ToString();
                string pageurl_like = oDr_website_my_pageurl_my["PAGEURL_REGEX"].ToString().Replace("http://(www.)?[a-z0-9\\.]+", "");
                if (type == 1)
                {
                    pageurl_like = "";
                    string[] path_names = oDr_website_my_pageurl_my["PAGEURL_REGEX"].ToString().Replace("http://(www.)?[a-z0-9\\.]+", "").TrimStart('/').Split('/');

                    if (path_names.Length >= 2)
                    {
                        pageurl_like = "/";
                        for (int i = 0; i < path_names.Length - 1; i++)
                        {
                            pageurl_like += path_names[i] + "/";
                        }
                    }
                }
                //页面弱匹配
                DataRow[] oDr_Connect_Log_Stats_today = dt_Connect_Log_Stats.Select("PAGEURL like '%" + pageurl_like + "%' and PAGEURL <> '" + pageurl + "'");
                if (oDr_Connect_Log_Stats_today != null && oDr_Connect_Log_Stats_today.Length > 0)
                {
                    foreach (DataRow oDr in oDr_Connect_Log_Stats_today)
                    {
                        DataRow[] oDrs = oDt_website_my_pageurl.Select("PAGEURL = '" + oDr["PAGEURL"].ToString() + "'");
                        if (oDrs == null || oDrs.Length == 0)
                        {
                            DataRow[] oDrs_like = oDt_website_my_pageurl_my_like.Select("PAGEURL = '" + oDr["PAGEURL"].ToString() + "'");
                            if (oDrs_like == null || oDrs_like.Length == 0)
                            {
                                DataRow oNewRow = oDt_website_my_pageurl_my_like.NewRow();
                                oNewRow.ItemArray = oDr.ItemArray;
                                oDt_website_my_pageurl_my_like.Rows.Add(oNewRow);
                                oDt_website_my_pageurl_my_like.AcceptChanges();
                            }
                        }
                    }
                }

            }
            return oDt_website_my_pageurl_my_like;
        }
    }
}
