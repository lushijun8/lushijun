using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace TeamToolTask
{
    public class DependController
    {
        public static void PageUrl_Depend(string DataBaseInstance)
        {

            Entity.CHANNELSALES_STATS.REQUEST_LOG request_log = new Entity.CHANNELSALES_STATS.REQUEST_LOG();
            request_log.TruncateTable();
            //request_log.DeleteWhereSql = " 1=1 ";
            //request_log.Delete();
            return;


            #region Sql
            string Sql = @"SELECT TOP 5000
	                        SUBSTRING(pageurl + '?', 1, CHARINDEX('?', pageurl + '?') - 1) AS pageurl,
	                        SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1) AS Depend_PageUrl,
	                        --max(isnull(timeout,0)) as timeout_max,
	                        --min(isnull(timeout,0)) as timeout_min,
	                        ISNULL(timeout, 0) AS timeout,
	                        SUM(timespan) AS timespan_sum,
	                        MAX(timespan) AS timespan_max,
	                        MIN(timespan) AS timespan_min,
	                        MAX(createtime) AS createtime_max,
	                        MAX(CAST(CONTENT AS NVARCHAR(MAX))) AS CONTENT,
	                        MAX(CONTENTTYPE) AS CONTENTTYPE,
	                        MAX(ContentLength) AS ContentLength,
	                        MAX(requesturl) AS requesturl,
	                        MAX(PageURL) AS PageUrl_Detail,
	                        COUNT(1) AS counts,
	                        SUM(CASE HttpStatusCode
		                        WHEN 'TimeOut' THEN (CASE LEN(CAST(timeout AS DECIMAL(18, 0))) + 1 - CHARINDEX('.', CAST(timespan AS DECIMAL(18, 4)))
				                        WHEN 0 THEN 0
				                        ELSE 1
			                        END)
		                        WHEN 'OK' THEN 0
		                        ELSE 1
	                        END) AS counts_error,
	                        SUM(CASE HttpStatusCode
		                        WHEN 'TimeOut' THEN (CASE LEN(CAST(timeout AS DECIMAL(18, 0))) + 1 - CHARINDEX('.', CAST(timespan AS DECIMAL(18, 4)))
				                        WHEN 0 THEN 1
				                        ELSE 0
			                        END)
		                        ELSE 0
	                        END) AS counts_timeout
                        FROM Request_Log WITH(NOLOCK)
                        WHERE CreateTime > CONVERT(VARCHAR(100), GETDATE(), 23) + ' 00:00:00'
                        AND CreateTime < CONVERT(VARCHAR(100), GETDATE(), 23) + ' 23:59:59'
                        GROUP BY	SUBSTRING(pageurl + '?', 1, CHARINDEX('?', pageurl + '?') - 1),
			                        SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1),
			                        ISNULL(timeout, 0)
                        -------------------------------
                       SELECT
	                        SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1) AS Depend_PageUrl,
	                        MAX(CAST(CONTENT AS NVARCHAR(MAX))) AS CONTENT,
	                        MAX(requesturl) AS requesturl,
	                        CAST(AVG(timespan) AS DECIMAL(18, 2)) AS timespan,
	                        MAX(createtime) AS createtime_max,
	                        MIN(createtime) AS createtime_min,
	                        COUNT(1) AS counts
                        FROM Request_Log WITH(NOLOCK)
                        WHERE HttpStatusCode = 'TimeOut'
                        AND CHARINDEX('.', CAST(timespan AS DECIMAL(18, 4))) != LEN(CAST(timeout AS DECIMAL(18, 0))) + 1
                        GROUP BY SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1)
                        -------------------------------------------------------------- 
                        SELECT DISTINCT
	                        SUBSTRING(pageurl + '?', 1, CHARINDEX('?', pageurl + '?') - 1) AS pageurl,
	                        SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1) AS Depend_PageUrl,
	                        timeout,
	                        CAST(AVG(timespan) AS DECIMAL(18, 2)) AS timespan,
	                        COUNT(1) AS counts
                        FROM Request_Log WITH(NOLOCK)
                        GROUP BY	SUBSTRING(pageurl + '?', 1, CHARINDEX('?', pageurl + '?') - 1),
			                        SUBSTRING(requesturl + '?', 1, CHARINDEX('?', requesturl + '?') - 1),
			                        timeout
                        -------------------------------------------------------------- 
                        SELECT
	                        MAX(createtime) AS createtime_max,
	                        MIN(createtime) AS createtime_min
                        FROM Request_Log WITH(NOLOCK)
						-------------------------------------------------------------- 
                            ";
            #endregion
            Database Database_Log = DatabaseFactory.CreateDatabase(DataBaseInstance);
            DataSet oDs = Database_Log.ExecuteDataSet(CommandType.Text, Sql);
            DataTable oDt_Request_Log = oDs.Tables[0];
            DataTable oDt_Request_Log_Error = oDs.Tables[1];
            DataTable oDt_Request_Log_Depend = oDs.Tables[2];
            DataTable oDt_Request_Log_Time = oDs.Tables[3];
            //删除原始记录
            Sql = @"truncate table request_log";
            Database_Log.ExecuteNonQuery(CommandType.Text, Sql);
            int count = 0;
            foreach (DataRow oDr_Request_Log in oDt_Request_Log.Rows)
            {
                count++;
                #region 赋值
                string PageUrl = (oDr_Request_Log["PageUrl"].ToString().TrimEnd(' ').TrimEnd('?') + "?").Split('?')[0];
                string[] pageurls = PageUrl.Split('/');
                string PageUrl_Regex = PageUrl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");

                string Depend_PageUrl = (oDr_Request_Log["RequestURL"].ToString().TrimEnd(' ').TrimEnd('?') + "?").Split('?')[0];
                string[] Depend_pageurls = Depend_PageUrl.Split('/');
                string Depend_PageUrl_Regex = Depend_PageUrl.Replace(Depend_pageurls[2], "(www.)?[a-z0-9\\.]+");
                //------------------------------------------------
                int timespan_sum = 0;
                if (!string.IsNullOrEmpty(oDr_Request_Log["timespan_sum"].ToString()))
                {
                    timespan_sum = (int)Math.Round(decimal.Parse(oDr_Request_Log["timespan_sum"].ToString()), 0);
                }
                int timespan_max = 0;
                if (!string.IsNullOrEmpty(oDr_Request_Log["timespan_max"].ToString()))
                {
                    timespan_max = (int)Math.Round(decimal.Parse(oDr_Request_Log["timespan_max"].ToString()), 0);
                }
                int timespan_min = 0;
                if (!string.IsNullOrEmpty(oDr_Request_Log["timespan_min"].ToString()))
                {
                    timespan_min = (int)Math.Round(decimal.Parse(oDr_Request_Log["timespan_min"].ToString()), 0);
                }

                DateTime createtime_max = DateTime.MinValue;
                if (!string.IsNullOrEmpty(oDr_Request_Log["createtime_max"].ToString()))
                {
                    createtime_max = DateTime.Parse(oDr_Request_Log["createtime_max"].ToString());
                }
                int counts = int.Parse(oDr_Request_Log["counts"].ToString());
                long timeout = int.Parse(oDr_Request_Log["timeout"].ToString());
                int counts_error = int.Parse(oDr_Request_Log["counts_error"].ToString());
                int counts_timeout = int.Parse(oDr_Request_Log["counts_timeout"].ToString());
                string Content = oDr_Request_Log["Content"].ToString();
                string ContentType = oDr_Request_Log["CONTENTTYPE"].ToString().ToLower();
                int ContentType_Error = 0;
                int ContentLength = 0;
                if (!string.IsNullOrEmpty(oDr_Request_Log["CONTENTLENGTH"].ToString()))
                {
                    ContentLength = int.Parse(oDr_Request_Log["CONTENTLENGTH"].ToString());
                }
                try
                {
                    if (ContentType.IndexOf("xml") == -1 && ContentType.IndexOf("json") == -1)
                    {
                        if (Com.Json.Convert.JsonToDataTable(Content) != null)//尝试看看是否json 
                        {
                            ContentType = "application/json;";
                        }
                        else if (Com.Xml.XmlUtil.GetDocFromString(Content) != null)//尝试看看是否xml
                        {
                            ContentType = "application/xml;";
                        }
                    }
                    else if (ContentType.IndexOf("xml") > -1)
                    {
                        if (Com.Xml.XmlUtil.GetDocFromString(Content) == null)//尝试看看是否xml
                        {
                            ContentType_Error = 1;
                        }
                    }
                    else if (ContentType.IndexOf("json") > -1)
                    {
                        if (Com.Json.Convert.JsonToDataTable(Content) == null)//尝试看看是否json 
                        {
                            ContentType_Error = 1;
                        }
                    }
                }
                catch { }
                #endregion
                #region 查询是否已经存在此依赖关系
                DateTime Stats_Date = DateTime.Parse(createtime_max.ToShortDateString());
                Entity.TEAMTOOL.WEBSITE_DEPEND website_depend_select = new Entity.TEAMTOOL.WEBSITE_DEPEND();
                website_depend_select.PAGEURL = PageUrl;
                website_depend_select.DEPEND_PAGEURL = Depend_PageUrl;
                website_depend_select.STATS_DATE = Stats_Date;
                website_depend_select.DEPEND_TIMEOUT = timeout;
                #endregion
                if (website_depend_select.SelectTop1() != null)//已经存在此依赖关系
                {
                    #region 更新
                    Entity.TEAMTOOL.WEBSITE_DEPEND website_depend_update = new Entity.TEAMTOOL.WEBSITE_DEPEND();
                    website_depend_update.PAGEURL = PageUrl;
                    website_depend_update.DEPEND_PAGEURL = Depend_PageUrl;
                    website_depend_update.STATS_DATE = Stats_Date;
                    website_depend_update.DEPEND_TIMEOUT = timeout;

                    website_depend_update.PAGEURL_REGEX = PageUrl_Regex;
                    website_depend_update.DEPEND_PAGEURL_REGEX = Depend_PageUrl_Regex;
                    website_depend_update.DEPEND_PAGEURL_DETAIL = oDr_Request_Log["RequestURL"].ToString();
                    website_depend_update.PAGEURL_DETAIL = oDr_Request_Log["PageUrl_Detail"].ToString();
                    website_depend_update.DEPEND_CONTENTTYPE = ContentType;
                    website_depend_update.DEPEND_CONTENTTYPE_ERROR = ContentType_Error;
                    if (Content.Length > website_depend_select.DEPEND_CONTENT.Length)
                    {
                        website_depend_update.DEPEND_CONTENT = Content;
                    }
                    if (ContentLength > int.Parse(website_depend_select.DEPEND_CONTENTLENGTH_ToString))
                    {
                        website_depend_update.DEPEND_CONTENTLENGTH = ContentLength;
                    }
                    website_depend_update.DEPEND_COUNT = int.Parse(website_depend_select.DEPEND_COUNT_ToString) + counts;
                    website_depend_update.DEPEND_COUNT_ERROR = int.Parse(website_depend_select.DEPEND_COUNT_ERROR_ToString) + counts_error;
                    website_depend_update.DEPEND_COUNT_TIMEOUT = int.Parse(website_depend_select.DEPEND_COUNT_TIMEOUT_ToString) + counts_timeout;

                    website_depend_update.DEPEND_ERROR_RATE = decimal.Parse((decimal.Parse(website_depend_update.DEPEND_COUNT_ERROR_ToString) * 100).ToString()) / decimal.Parse(website_depend_update.DEPEND_COUNT_ToString);
                    website_depend_update.DEPEND_TIMEOUT_RATE = decimal.Parse((decimal.Parse(website_depend_update.DEPEND_COUNT_TIMEOUT_ToString) * 100).ToString()) / decimal.Parse(website_depend_update.DEPEND_COUNT_ToString);

                    website_depend_update.DEPEND_TIMESPAN_SUM = timespan_sum + int.Parse(website_depend_select.DEPEND_TIMESPAN_SUM_ToString);
                    if (timespan_max > int.Parse(website_depend_select.DEPEND_TIMESPAN_MAX_ToString))
                    {
                        website_depend_update.DEPEND_TIMESPAN_MAX = timespan_max;
                    }
                    if (timespan_min < int.Parse(website_depend_select.DEPEND_TIMESPAN_MIN_ToString))
                    {
                        website_depend_update.DEPEND_TIMESPAN_MIN = timespan_min;
                    }

                    website_depend_update.DEPEND_TIMESPAN_NEW = timespan_sum / counts;
                    website_depend_update.DEPEND_TIMESPAN_AVERAGE = (timespan_sum + int.Parse(website_depend_select.DEPEND_TIMESPAN_SUM_ToString)) / (int.Parse(website_depend_select.DEPEND_COUNT_ToString) + counts);
                    website_depend_update.DEPEND_CREATETIME = createtime_max;
                    if (!website_depend_update.Update())
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_depend.Update()失败，PageUrl=" + PageUrl);
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_depend.Update()成功，PageUrl=" + PageUrl);
                    }
                    #endregion
                }
                else
                {
                    #region 插入
                    Entity.TEAMTOOL.WEBSITE_DEPEND website_depend_insert = new Entity.TEAMTOOL.WEBSITE_DEPEND();
                    website_depend_insert.PAGEURL = PageUrl;
                    website_depend_insert.DEPEND_PAGEURL = Depend_PageUrl;
                    website_depend_insert.STATS_DATE = Stats_Date;
                    website_depend_insert.DEPEND_TIMEOUT = timeout;
                    website_depend_insert.PAGEURL_REGEX = PageUrl_Regex;
                    website_depend_insert.DEPEND_PAGEURL_REGEX = Depend_PageUrl_Regex;
                    website_depend_insert.DEPEND_PAGEURL_DETAIL = oDr_Request_Log["RequestURL"].ToString();
                    website_depend_insert.PAGEURL_DETAIL = oDr_Request_Log["PageUrl_Detail"].ToString();
                    website_depend_insert.DEPEND_CONTENTTYPE = ContentType;
                    website_depend_insert.DEPEND_CONTENTTYPE_ERROR = ContentType_Error;
                    website_depend_insert.DEPEND_CONTENT = Content;
                    website_depend_insert.DEPEND_CONTENTLENGTH = ContentLength;
                    website_depend_insert.DEPEND_COUNT = counts;
                    website_depend_insert.DEPEND_COUNT_ERROR = counts_error;
                    website_depend_insert.DEPEND_COUNT_TIMEOUT = counts_timeout;
                    website_depend_insert.DEPEND_ERROR_RATE = decimal.Parse((counts_error * 100).ToString()) / decimal.Parse(counts.ToString());
                    website_depend_insert.DEPEND_TIMEOUT_RATE = decimal.Parse((counts_timeout * 100).ToString()) / decimal.Parse(counts.ToString());
                    website_depend_insert.DEPEND_TIMESPAN_SUM = timespan_sum;
                    website_depend_insert.DEPEND_TIMESPAN_MAX = timespan_max;
                    website_depend_insert.DEPEND_TIMESPAN_MIN = timespan_min;

                    website_depend_insert.DEPEND_TIMESPAN_NEW = timespan_sum / counts;
                    website_depend_insert.DEPEND_TIMESPAN_AVERAGE = timespan_sum / counts;
                    website_depend_insert.DEPEND_CREATETIME = createtime_max;
                    if (!website_depend_insert.Insert())
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_depend.Insert()失败，PageUrl=" + PageUrl);
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "website_depend.Insert()成功，PageUrl=" + PageUrl);
                    }
                    #endregion
                }

            }
            #region 发接口报错邮件
            //--------------------------------------------------------- 
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl_all = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl_all.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl_all.CacheTime = 30;
            website_my_pageurl_all.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
            DataTable oDt_website_my_pageurl_all = website_my_pageurl_all.Select();

            string body = @"<!DOCTYPE HTML PUBLIC " + "\"" + @"-//W3C//DTD HTML 4.01//EN" + "\"" + @" " + "\"" + @"http://www.w3.org/TR/html4/strict.dtd" + "\"" + @">
<html>
<head>
    <meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" />
<style type=" + "\"" + @"text/css" + "\"" + @">   
* {word-break:break-all;word-wrap:break-word;margin:0;padding:0;text-align:left;}
body {text-align:center;font-family:" + "\"" + @"微软雅黑" + "\"" + @",Arial;font-size:12px;color:#000;background:#ffffff;}
div.div_tooltip
{
    border:1px solid #cccccc;
    background-color:lightyellow;
}
</style>
</head><body><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Depend/Depend_List_All.aspx?orderby=DEPEND_COUNT_ERROR+DESC\"" + @">点击此处查看详情</a><br>1、如果是您负责的接口请立刻查明原因并解决。<br>2、如果是您调用了对方的接口报错请转发给对应的负责人并督促对方解决。{0}</body></html>";
            string Error = "";
            string MailUserList = "";
            int i = 0;
            foreach (DataRow oDr_Request_Log_Error in oDt_Request_Log_Error.Rows)
            {
                if (i >= 10)
                {
                    Error += "<p>......</p>";
                    break;
                }
                #region 超时数
                int counts_timeout = 0;
                DataRow[] oDrs = oDt_Request_Log.Select("Depend_PageUrl='" + oDr_Request_Log_Error["Depend_PageUrl"].ToString() + "'");
                if (oDrs != null && oDrs.Length > 0)
                {
                    foreach (DataRow oDr in oDrs)
                    {
                        counts_timeout += int.Parse(oDr["counts_timeout"].ToString());
                    }
                }
                #endregion
                #region 接口负责人
                string WebManager_Name = "";
                string WebManager_RealName = GetWebManager_RealName(oDt_website_my_pageurl_all, oDr_Request_Log_Error["Depend_PageUrl"].ToString(), out WebManager_Name);
                if (!string.IsNullOrEmpty(WebManager_Name))
                {
                    string[] names = WebManager_Name.Split(' ');
                    foreach (string name in names)
                    {
                        if (MailUserList.IndexOf(name) == -1)
                        {
                            MailUserList +=  name + "@fang.com;";
                        }
                    }
                }
                #endregion
                #region 接口调用人
                string Request_info = "";
                DataRow[] oDrs_Request_Log_Depend = oDt_Request_Log_Depend.Select("DEPEND_PAGEURL='" + oDr_Request_Log_Error["Depend_PageUrl"].ToString() + "'");
                if (oDrs_Request_Log_Depend != null && oDrs_Request_Log_Depend.Length > 0)
                {
                    foreach (DataRow oDr in oDrs_Request_Log_Depend)
                    {
                        if (Request_info.IndexOf(oDr["PageUrl"].ToString()) == -1)
                        {
                            string WebManager_Name_Request = "";
                            string WebManager_RealName_Request = GetWebManager_RealName(oDt_website_my_pageurl_all, oDr["PageUrl"].ToString(), out WebManager_Name_Request);
                            Request_info += "<br/> " + oDr["PageUrl"].ToString() + " 超时设置 " + oDr["timeout"].ToString() + " 毫秒 平均响应时间 " + oDr["timespan"].ToString() + " 毫秒 共请求 " + oDr["counts"].ToString() + " 次 <font color=red>" + WebManager_RealName_Request + "</font> <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(oDr["PageUrl"].ToString(), "fang.com") + "\">认领</a>";
                            
                            if (!string.IsNullOrEmpty(WebManager_Name_Request))
                            {
                                string[] names = WebManager_Name_Request.Split(' ');
                                foreach (string name in names)
                                {
                                    if (MailUserList.IndexOf(name) == -1)
                                    {
                                        MailUserList +=  name + "@fang.com;";
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 拼接错误信息
                Error += "<div class=" + "\"" + @"div_tooltip" + "\"" +
                    @"><p>接口 : " + oDr_Request_Log_Error["requesturl"].ToString() + " <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(oDr_Request_Log_Error["Depend_PageUrl"].ToString(), "fang.com") + "\">认领</a>" +
                     @"<br/>监控时间 : " + oDr_Request_Log_Error["createtime_min"].ToString() + " ～ " + oDr_Request_Log_Error["createtime_max"].ToString() +
                     @"<br/>报错时响应时间 : " + oDr_Request_Log_Error["timespan"].ToString() + " 毫秒" +
                     @"<br/>报错数 : " + oDr_Request_Log_Error["counts"].ToString() +
                     @"<br/>超时数 : " + counts_timeout +
                     @"<br/>负责人 : <font color=red>" + WebManager_RealName + "</font>" +
                     @"<br/>调用情况 : " + Request_info +
                     @"<br/>---------------------------------------------------------------</p>接口返回的报错信息 : <p>" +
                     System.Web.HttpUtility.HtmlEncode(oDr_Request_Log_Error["CONTENT"].ToString()).Replace("\r\n", "<br>").Replace("\t", "&nbsp;") +
                     "</p></div><p>---------------------------------------------------------------</p>";
                #endregion
                i++;
            }
            if (!string.IsNullOrEmpty(Error))
            {
                #region 发报错邮件
                string timespan = "";
                if (oDt_Request_Log_Time != null && oDt_Request_Log_Time.Rows.Count > 0)
                {
                    timespan = oDt_Request_Log_Time.Rows[0]["createtime_min"].ToString() + " 至 " + oDt_Request_Log_Time.Rows[0]["createtime_max"].ToString();
                }
                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailTitle = timespan + "接口有报错和超时[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                mail.MailContent = body.Replace("{0}", Error);
                mail.MailUserList = MailUserList + (!string.IsNullOrEmpty(MailUserList) ? "" : "lushijun@fang.com") ;
                if (!string.IsNullOrEmpty(MailUserList))
                {
                    mail.CopyToMailUserList = "lushijun@fang.com";
                }
                if (!mail.SendOneMailByHTML())
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "报错邮件发给“" + MailUserList + "”失败！");
                    Business.MallLog.Create(0, "AutoRunJob.DependController", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                }
                #endregion
            }
            #endregion
        }
        private static string GetWebManager_RealName(DataTable oDt_website_my_pageurl_all, string PageUrl, out string WebManager_Name)
        {
            string WebManager_RealName = "";
            WebManager_Name = "";
            DataRow[] oDrs_website_my_pageurl_all_request = oDt_website_my_pageurl_all.Select("PAGEURL='" + PageUrl + "'");
            if (oDrs_website_my_pageurl_all_request != null && oDrs_website_my_pageurl_all_request.Length > 0)
            {
                foreach (DataRow oDr in oDrs_website_my_pageurl_all_request)
                {
                    if (WebManager_RealName.IndexOf(oDr["WebManager_RealName"].ToString()) == -1)
                    {
                        WebManager_RealName += oDr["WebManager_RealName"].ToString() + " ";
                        WebManager_Name += oDr["WebManager_Name"].ToString() + " ";
                    }
                }
            }
            WebManager_Name = WebManager_Name.TrimEnd();
            return WebManager_RealName.TrimEnd();
        }
    }
}
