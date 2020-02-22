using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Threading;
namespace TeamToolTask
{
    public class PageUrlMatchController
    {
        private delegate void MyDelegate(string MyPageUrl);
        public static void Sync()
        {
            MyDelegate caller = new MyDelegate(Match);
            caller.BeginInvoke(null, null, null);
        }

        public static void Match(string MyPageUrl)
        {
            #region 报错情况
            Entity.TEAMTOOL.LOG_STATS log_stats_today_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_today_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            if (!string.IsNullOrEmpty(MyPageUrl))
            {
                log_stats_today_all.PAGEURL = MyPageUrl;
            }
            DataTable dt_log_stats_today_all = log_stats_today_all.Select();
            //--------------------------------------------------------------------------------
            Entity.TEAMTOOL.LOG_STATS log_stats_yestoday_all = new Entity.TEAMTOOL.LOG_STATS();
            log_stats_yestoday_all.LOG_DATE = DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString());
            if (!string.IsNullOrEmpty(MyPageUrl))
            {
                log_stats_yestoday_all.PAGEURL = MyPageUrl;
            }
            DataTable dt_log_stats_yestoday_all = log_stats_yestoday_all.Select();
            #endregion

            #region 认领情况
            //--------------------------------------------------------------------------------
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            //if (!string.IsNullOrEmpty(MyPageUrl))
            //{
            //    website_my_pageurl_all.PAGEURL = MyPageUrl;
            //}
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();
            #endregion

            #region 负责相关域名
            Entity.TEAMTOOL.WEBSITE_MY_DOMAIN website_my_domain = new Entity.TEAMTOOL.WEBSITE_MY_DOMAIN();
            DataTable oDt_website_my_domain = website_my_domain.Select();
            #endregion

            Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
            website_pageurl.SelectColumns = new string[] { "*" };
            //website_pageurl.ANALYSIS = 0; 
            if (!string.IsNullOrEmpty(MyPageUrl))
            {
                website_pageurl.PAGEURL = MyPageUrl;
            }
            DataTable oDt_website_pageurl = website_pageurl.Select();
            //-----------------------------------------
            #region 依赖情况
            //---------------------------------------------------------------------------------
            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.Distinct = true;
            website_depend.SelectColumns = new string[] 
            { 
                website_depend._PAGEURL, 
                website_depend._DEPEND_PAGEURL
                //website_depend._DEPEND_PAGEURL_DETAIL, 
                //website_depend._DEPEND_CONTENTTYPE, 
                //website_depend._DEPEND_CONTENTLENGTH, 
                //website_depend._DEPEND_COUNT, 
                //website_depend._DEPEND_TIMESPAN_SUM, 
                //website_depend._DEPEND_TIMESPAN_MAX, 
                //website_depend._DEPEND_TIMESPAN_MIN, 
                //website_depend._DEPEND_TIMESPAN_NEW, 
                //website_depend._DEPEND_TIMESPAN_AVERAGE, 
                //website_depend._DEPEND_CREATETIME 
            };
            // website_depend.STATS_DATE = DateTime.Parse(DateTime.Now.AddHours(-12).ToShortDateString());//12小时前de那天的

            website_depend.WhereSql = website_depend._STATS_DATE + ">'" + DateTime.Now.AddDays(-15).ToShortDateString() + "'";//15天内的

            if (!string.IsNullOrEmpty(MyPageUrl))
            {
                website_depend.WhereSql += " AND (" + website_depend._PAGEURL + "='" + MyPageUrl + "' OR " + website_depend._DEPEND_PAGEURL + "='" + MyPageUrl + "')";
            }
            DataTable dt_website_depend = website_depend.Select();
            dt_website_depend.Columns.Add(new DataColumn("WebManager_Name", typeof(string)));
            dt_website_depend.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));
            dt_website_depend.Columns.Add(new DataColumn("WebManager_Name_Depend", typeof(string)));
            dt_website_depend.Columns.Add(new DataColumn("WebManager_RealName_Depend", typeof(string)));

            foreach (DataRow oDr_website_depend in dt_website_depend.Rows)
            {
                DataRow[] oDrs_website = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_website_depend[website_depend._PAGEURL].ToString() + "'");
                if (oDrs_website != null && oDrs_website.Length > 0)
                {
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    foreach (DataRow oDr in oDrs_website)
                    {
                        WebManager_Name += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + " ";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + " ";
                    }
                    oDr_website_depend[website_my_pageurl_all._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(' ');
                    oDr_website_depend["WebManager_RealName"] = WebManager_RealName.TrimEnd(' ');
                }
                //------------------------------------
                DataRow[] oDrs_website_depend = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + oDr_website_depend[website_depend._DEPEND_PAGEURL].ToString() + "'");
                if (oDrs_website_depend != null && oDrs_website_depend.Length > 0)
                {
                    string WebManager_Name_Depend = "";
                    string WebManager_RealName_Depend = "";
                    foreach (DataRow oDr in oDrs_website_depend)
                    {
                        WebManager_Name_Depend += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + " ";
                        WebManager_RealName_Depend += oDr["WebManager_RealName"].ToString() + " ";
                    }
                    oDr_website_depend[website_pageurl._WEBMANAGER_NAME_DEPEND] = WebManager_Name_Depend.TrimEnd(' ');
                    oDr_website_depend[website_pageurl._WEBMANAGER_REALNAME_DEPEND] = WebManager_RealName_Depend.TrimEnd(' ');
                }
            }
            //---------------------------------------------------------------------------
            #endregion

            int index = 0;
            int allcount = oDt_website_pageurl.Rows.Count;
            string PageUrls = "'-1'";
            foreach (DataRow oDr_website_pageurl in oDt_website_pageurl.Rows)
            {
                index++;
                string pageurl = oDr_website_pageurl[website_pageurl._PAGEURL].ToString();
                PageUrls += ",'" + pageurl + "'";
                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "='" + pageurl + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    #region 匹配负责人
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    string IsMy_CreateTime = "";
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        WebManager_Name += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + " ";
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + " ";
                        IsMy_CreateTime += oDr["CreateTime"].ToString() + "<br>";

                    }
                    oDr_website_pageurl[website_pageurl._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(' ');
                    oDr_website_pageurl[website_pageurl._WEBMANAGER_REALNAME] = WebManager_RealName.TrimEnd(' ');
                    oDr_website_pageurl[website_pageurl._ISMY_CREATETIME] = IsMy_CreateTime;
                    #endregion
                }
                else
                {
                    #region 匹配疑似负责人
                    string[] pageurls = pageurl.Split('/');
                    string pageurl_regex = pageurl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
                    string pageurl_like = pageurl_regex.Replace(pageurls[0] + "//(www.)?[a-z0-9\\.]+", "");//页面匹配

                    if (!string.IsNullOrEmpty(pageurl_like) && pageurl_like.Length >= 2 && pageurl_like.IndexOf("(www.)?[a-z0-9\\.]+") == -1)
                    {
                        //页面弱匹配
                        DataRow[] oDrs_website_my_pageurl_Like = null;
                        oDrs_website_my_pageurl_Like = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "<>'" + pageurl + "' " +
                             " AND " + website_my_pageurl_all._PAGEURL + " LIKE '%" + pageurl_like + "%' ");
                        if (oDrs_website_my_pageurl_Like == null || oDrs_website_my_pageurl_Like.Length == 0)//url匹配失败则启动目录匹配
                        {
                            string[] path_names = pageurl_like.TrimStart('/').Split('/');
                            string pageurl_path = "";//目录匹配
                            if (path_names.Length >= 2)
                            {
                                pageurl_path = "/";
                                for (int i = 0; i < path_names.Length - 1; i++)
                                {
                                    pageurl_path += path_names[i] + "/";
                                }
                            }
                            if (path_names.Length >= 2)
                            {
                                oDrs_website_my_pageurl_Like = oDt_website_my_pageurl_all.Select(website_my_pageurl_all._PAGEURL + "<>'" + pageurl + "' " +
                                     " AND " + website_my_pageurl_all._PAGEURL + " LIKE '%" + pageurl_path + "%'");
                            }
                        }
                        if (oDrs_website_my_pageurl_Like != null && oDrs_website_my_pageurl_Like.Length > 0)
                        {
                            string WebManager_Name_Like = "";
                            string WebManager_RealName_Like = "";
                            int i = 0;
                            foreach (DataRow oDr in oDrs_website_my_pageurl_Like)
                            {

                                if (WebManager_Name_Like.IndexOf(oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString()) == -1)
                                {
                                    DataRow[] oDrs_website_my_domain = oDt_website_my_domain.Select(website_my_domain._WEBMANAGER_NAME + "='" + oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + "' AND '" + pageurl + "' like " + website_my_domain._DOMAIN_NAME + "+'%'");
                                    if (oDrs_website_my_domain != null && oDrs_website_my_domain.Length > 0)
                                    {
                                        WebManager_Name_Like += oDr[website_my_pageurl_all._WEBMANAGER_NAME].ToString() + " ";
                                        WebManager_RealName_Like += oDr["WebManager_RealName"].ToString() + " ";
                                        i++;
                                        if (i % 3 == 0)
                                        {
                                            WebManager_RealName_Like += "<br>";
                                        }
                                    }
                                }
                            }
                            oDr_website_pageurl[website_pageurl._WEBMANAGER_NAME_LIKE] = WebManager_Name_Like.TrimEnd(' ');
                            oDr_website_pageurl[website_pageurl._WEBMANAGER_REALNAME_LIKE] = WebManager_RealName_Like.TrimEnd(' ');
                        }
                    }
                    #endregion
                }

                #region 匹配调用人、匹配依赖的外部URL情况、匹配被依赖的外部URL情况

                string Depend_PageUrl = "";//本地URL依赖的外部URL汇总
                string Depend_PageUrl_Out = "";//依赖本地URL的外部URL汇总
                string WebManager_Name_Depend = "";//调用人
                string WebManager_RealName_Depend = "";//调用人姓名
                DataRow[] oDrs_website_depend_Out = dt_website_depend.Select(website_depend._DEPEND_PAGEURL + "='" + pageurl + "'");
                if (oDrs_website_depend_Out != null && oDrs_website_depend_Out.Length > 0)
                {
                    Depend_PageUrl_Out = "<p>此URL被如下页面调用：<p/>";
                    int i = 0;
                    int icount = 0;
                    foreach (DataRow oDr_website_depend in oDrs_website_depend_Out)
                    {
                        i++;
                        Depend_PageUrl_Out += i.ToString() + "、<font color=red>" + oDr_website_depend[website_depend._PAGEURL].ToString() + "</font>";
                        if (!string.IsNullOrEmpty(oDr_website_depend["WebManager_RealName"].ToString()))
                        {
                            Depend_PageUrl_Out += " [" + oDr_website_depend["WebManager_RealName"].ToString() + "]";
                        }
                        Depend_PageUrl_Out += "<br/><br/>";
                        string[] WebManager_Names = oDr_website_depend["WebManager_Name"].ToString().Split(' ');
                        string[] WebManager_RealNames = oDr_website_depend["WebManager_RealName"].ToString().Split(' ');
                        for (int k = 0; k < WebManager_RealNames.Length; k++)
                        {
                            string realname = WebManager_RealNames[k];
                            if (!string.IsNullOrEmpty(realname))
                            {
                                if (WebManager_RealName_Depend.IndexOf(realname) == -1)
                                {
                                    WebManager_Name_Depend += WebManager_Names[k] + " ";
                                    WebManager_RealName_Depend += realname + " "; 
                                    icount++;
                                    if (icount % 3 == 0)
                                    {
                                        WebManager_RealName_Depend += "<br>";
                                    }

                                }
                            }
                        }
                    }
                }
                DataRow[] oDrs_website_depend = dt_website_depend.Select(website_depend._PAGEURL + "='" + pageurl + "'");
                if (oDrs_website_depend != null && oDrs_website_depend.Length > 0)
                {
                    Depend_PageUrl = "<p>此页面调用了以下URL：<p/>";
                    int i = 0;
                    foreach (DataRow oDr_website_depend in oDrs_website_depend)
                    {
                        i++;
                        Depend_PageUrl += i.ToString() + "、<font color=red>" + oDr_website_depend[website_depend._DEPEND_PAGEURL].ToString() + "</font>";
                        if (!string.IsNullOrEmpty(oDr_website_depend["WebManager_RealName_Depend"].ToString()))
                        {
                            Depend_PageUrl += " [" + oDr_website_depend["WebManager_RealName_Depend"].ToString() + "]";
                        }
                        Depend_PageUrl += "<br/><br/>";
                    }
                }
                oDr_website_pageurl[website_pageurl._DEPEND_PAGEURL] = Depend_PageUrl;
                oDr_website_pageurl[website_pageurl._DEPEND_PAGEURL_OUT] = Depend_PageUrl_Out;
                oDr_website_pageurl[website_pageurl._WEBMANAGER_NAME_DEPEND] = WebManager_Name_Depend;
                oDr_website_pageurl[website_pageurl._WEBMANAGER_REALNAME_DEPEND] = WebManager_RealName_Depend;
                #endregion

                #region 匹配实时报错情况
                string error_pageurl_regex = pageurl;
                string[] error_pageurls = pageurl.Split('/');
                if (error_pageurls.Length >= 3)
                {
                    error_pageurl_regex = pageurl.Replace(error_pageurls[2], "(www.)?[a-z0-9\\.]+");
                }
                DataRow[] oDrs_log_stats_today_all = dt_log_stats_today_all.Select(log_stats_today_all._PAGEURL_REGEX + "='" + error_pageurl_regex + "'");
                DataRow oDr_error = null;
                if (oDrs_log_stats_today_all != null && oDrs_log_stats_today_all.Length > 0)//今天的
                {
                    oDr_error = oDrs_log_stats_today_all[0];
                }
                else//昨天的
                {
                    DataRow[] oDrs_log_stats_yestoday_all = dt_log_stats_yestoday_all.Select(log_stats_yestoday_all._PAGEURL_REGEX + "='" + error_pageurl_regex + "'");
                    if (oDrs_log_stats_yestoday_all != null && oDrs_log_stats_yestoday_all.Length > 0)//今天的
                    {
                        oDr_error = oDrs_log_stats_yestoday_all[0];
                    }
                }
                if (oDr_error != null)
                {
                    oDr_website_pageurl[website_pageurl._ERRORTIME] = oDr_error["Error_CreateTime"];
                    oDr_website_pageurl[website_pageurl._ERRORINFO] = "<p>报错时间：" + oDr_error["Error_CreateTime"].ToString() + "</p>" +
                        "<p>标题：" + oDr_error["Title"].ToString() + "</p>" +
                        "<p>username：" + oDr_error["username"].ToString() + "</p>" +
                        "<p>ip：" + oDr_error["ip"].ToString() + "</p>" +
                        "<p>username：" + oDr_error["username"].ToString() + "</p>" +
                        "<p>------------------------</p>报错信息：<p>Content:<br />" + oDr_error["Content"].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p>" +
                        "<p>Remarks:<br />" + oDr_error["Remarks"].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p><br/>";
                }
                #endregion

                oDr_website_pageurl[website_pageurl._ANALYSIS] = 1;
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "PageUrlMatchController.Match()已经处理到第" + index + "/" + allcount + "条数据");
            }
            if (allcount > 0)
            {
                Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl_delete = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
                website_pageurl_delete.DeleteWhereSql = website_pageurl_delete._PAGEURL + " IN(" + PageUrls + ")";
                if (website_pageurl_delete.Delete() == true)
                {
                    if (website_pageurl.BulkCopy(oDt_website_pageurl) == true)
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_pageurl.BulkCopy() 成功！");
                        if (string.IsNullOrEmpty(MyPageUrl))
                        {
                            #region 匹配请求参数QueryString和Form
                            string Sql = @"   DECLARE @i int
                                SET @i = 0
                                WHILE(@i<=10)
                                BEGIN
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[QueryString] = DataBase_Sql_Connect_Stats.[QueryString]
	                                FROM [DataBase_Sql_Connect_Stats]
	                                WHERE [DataBase_Sql_Connect_Stats].[PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [DataBase_Sql_Connect_Stats].Stats_Date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([DataBase_Sql_Connect_Stats].[QueryString], '')) > LEN(ISNULL([WebSite_PageUrl].[QueryString], ''))
	                                --------------------------------------------------------------------------------------------------------------------
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[QueryString] = WebSite_Depend.[PageUrl_Detail]
	                                FROM [WebSite_Depend]
	                                WHERE [WebSite_Depend].[PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [WebSite_Depend].Stats_Date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([WebSite_Depend].[PageUrl_Detail], '')) > LEN(ISNULL([WebSite_PageUrl].[QueryString], ''))
	                                --------------------------------------------------------------------------------------------------------------------
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[QueryString] = WebSite_Depend.[Depend_PageUrl_Detail]
	                                FROM [WebSite_Depend]
	                                WHERE [WebSite_Depend].[Depend_PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [WebSite_Depend].Stats_Date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([WebSite_Depend].[Depend_PageUrl_Detail], '')) > LEN(ISNULL([WebSite_PageUrl].[QueryString], ''))
	                                --------------------------------------------------------------------------------------------------------------------
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[QueryString] = Log_Stats.[QueryString]
	                                FROM [Log_Stats]
	                                WHERE [Log_Stats].[PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [Log_Stats].log_date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([Log_Stats].[QueryString], '')) > LEN(ISNULL([WebSite_PageUrl].[QueryString], ''))
	                                -----------------------------------------------------------------------------------------------------------------------------------
	                                -----------------------------------------------------------------------------------------------------------------------------------
	                                -----------------------------------------------------------------------------------------------------------------------------------
	                                -----------------------------------------------------------------------------------------------------------------------------------
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[form] = DataBase_Sql_Connect_Stats.[form]
	                                FROM [DataBase_Sql_Connect_Stats]
	                                WHERE [DataBase_Sql_Connect_Stats].[PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [DataBase_Sql_Connect_Stats].Stats_Date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([DataBase_Sql_Connect_Stats].[form], '')) > LEN(ISNULL([WebSite_PageUrl].[form], ''))
	                                --------------------------------------------------------------------------------------------------------------------
	                                UPDATE [WebSite_PageUrl]
	                                SET [WebSite_PageUrl].[form] = Log_Stats.[form]
	                                FROM [Log_Stats]
	                                WHERE [Log_Stats].[PageUrl] = [WebSite_PageUrl].[PageUrl]
	                                AND [Log_Stats].log_date >= DATEADD(DAY, -10, GETDATE())
	                                AND LEN(ISNULL([Log_Stats].[form], '')) > LEN(ISNULL([WebSite_PageUrl].[form], ''))
	                                SET @i = @i + 1
                                END
                                    ---------------------------更新表，以识别手机号是否已经加密------------------------------
	                                    declare @regex varchar(500)
	                                    set @regex='(.+?)([^0-9])(13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8}([^0-9])'
                                    ----------------
	                                    update [WebSite_PageUrl] set querystring_Phone_Encrypt=1,form_Phone_Encrypt=1
	                                    update [WebSite_PageUrl] set querystring_Phone_Encrypt=0 where dbo.regexIsMatch('&'+querystring+'&',@regex,1) =1
	                                    update [WebSite_PageUrl] set form_Phone_Encrypt=0 where dbo.regexIsMatch('&'+form+'&',@regex,1) =1   
                                ";

                            MyDelegate caller = new MyDelegate(UpdateQueryStringAndForm);
                            caller.BeginInvoke(Sql, null, null);                             
                            #endregion
                        }
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_pageurl.BulkCopy() 失败！");
                    }
                }
                else
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_pageurl_delete.Delete() 失败！");
                }
            }

        }
        public static void UpdateQueryStringAndForm(string Sql)
        {
            Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
            if (website_pageurl.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql) > 0)
            {
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " website_pageurl 匹配请求参数QueryString和Form 成功！");
            }
            else
            {
                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + " website_pageurl 匹配请求参数QueryString和Form 失败！");
            }
        }
    }
}
