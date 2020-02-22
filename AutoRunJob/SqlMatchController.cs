using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace TeamToolTask
{
    public class SqlMatchController
    {
        public static void FindSeemLikeWebmanager()
        {
            //匹配今天以来SQL的疑似负责人
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats.SelectColumns = new string[] { database_sql_stats._STATS_DATE, database_sql_stats._SQL_MD5, database_sql_stats._SOURCE_MD5, database_sql_stats._SEEMLIKE_WEBMANAGER_NAME, database_sql_stats._TEXT };
            database_sql_stats.WhereSql = "(" + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME + " is null or " + database_sql_stats._SEEMLIKE_WEBMANAGER_NAME + "='') AND (" + database_sql_stats._STATS_DATE + ">='" + DateTime.Now.ToShortDateString() + "')";
            Log.WriteLog("\r\n" + DateTime.Now.ToString() + "开始database_sql_stats.Select();");
            DataTable oDt_database_sql_stats = database_sql_stats.Select();

            Log.WriteLog("\r\n" + DateTime.Now.ToString() + "database_sql_stats.Select()结束;并开始进行疑似负责人匹配");
            foreach (DataRow oDr_database_sql_stats in oDt_database_sql_stats.Rows)
            {
                if (string.IsNullOrEmpty(oDr_database_sql_stats[database_sql_stats._SEEMLIKE_WEBMANAGER_NAME].ToString()))
                {
                    #region 找出疑似负责人
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    FindSeemLikeWebmanager(oDr_database_sql_stats[database_sql_stats._TEXT].ToString(), oDr_database_sql_stats[database_sql_stats._SOURCE_MD5].ToString(), out WebManager_Name, out WebManager_RealName);
                    if (!string.IsNullOrEmpty(WebManager_Name))
                    {
                        Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats_update = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                        database_sql_stats_update.STATS_DATE = DateTime.Parse(oDr_database_sql_stats[database_sql_stats._STATS_DATE].ToString());
                        database_sql_stats_update.SQL_MD5 = oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString();
                        database_sql_stats_update.SEEMLIKE_WEBMANAGER_NAME = WebManager_Name.TrimEnd(',');
                        database_sql_stats_update.SEEMLIKE_WEBMANAGER_REALNAME = WebManager_RealName.TrimEnd(',');
                        string error = "";
                        if (database_sql_stats_update.Update() == true)
                        {
                            error = "成功";
                        }
                        else
                        {
                            error = "失败";
                        }
                        Log.WriteLog("\r\n" + DateTime.Now.ToString() + "database_sql_stats.SQL_MD5=" + oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString() +
                             " and database_sql_stats.STATS_DATE=" + oDr_database_sql_stats[database_sql_stats._STATS_DATE].ToString() + " 疑似负责人更新为" + WebManager_RealName.TrimEnd(',') + error + "!");
                    }
                    #endregion
                }
            }
        }

        public static void FindSeemLikeWebmanager(string Sql_Text, string Source_Md5, out string out_WebManager_Name, out string out_WebManager_RealName)
        {
            out_WebManager_Name = "";
            out_WebManager_RealName = "";
            #region 根据认领的PageUrl找出疑似负责人
            Regex reg_pageurl = new Regex(@"Request:http(s?)://(www.)?[a-z0-9\.]+/.*?(\?|\s|\*|\%)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            System.Text.RegularExpressions.MatchCollection matchs_pageurl = reg_pageurl.Matches(System.Web.HttpUtility.UrlDecode(Sql_Text), 0);
            string PageUrl = "";
            if (matchs_pageurl.Count > 0)
            {
                Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
                website_my_pageurl.LEFT_JOIN_ADMIN_WEBMANAGER = true;
                website_my_pageurl.SelectColumns = new string[] { "WEBSITE_MY_PAGEURL.*", "WebManager_RealName" };
                website_my_pageurl.CacheTime = 3;
                DataTable oDt_website_my_pageurl = website_my_pageurl.Select();

                PageUrl = matchs_pageurl[0].Value.Replace("Request:", "").TrimEnd('*').TrimEnd(' ').TrimEnd('?') + "?";
                PageUrl = PageUrl.Split('?')[0];

                string[] pageurls = PageUrl.Split('/');
                string PageUrl_Regex = PageUrl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");


                DataRow[] oDrs_website_my_pageurl = oDt_website_my_pageurl.Select(website_my_pageurl._PAGEURL_REGEX + "='" + PageUrl_Regex + "'");
                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    foreach (DataRow oDr in oDrs_website_my_pageurl)
                    {
                        if (out_WebManager_Name.IndexOf(oDr[website_my_pageurl._WEBMANAGER_NAME].ToString()) == -1)
                        {
                            out_WebManager_Name += oDr[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                            out_WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        }
                    }
                    out_WebManager_Name = out_WebManager_Name.TrimEnd(',');
                    out_WebManager_RealName = out_WebManager_RealName.TrimEnd(',');
                }
            }
            #endregion
            #region 根据认领的source_md5匹配疑似负责人
            if (string.IsNullOrEmpty(out_WebManager_Name))
            {
                Entity.TEAMTOOL.DATABASE_SQL_MY database_sql_my = new Entity.TEAMTOOL.DATABASE_SQL_MY();
                database_sql_my.LEFT_JOIN_ADMIN_WEBMANAGER = true;
                database_sql_my.SelectColumns = new string[] { database_sql_my.TableName + ".*", "WebManager_RealName" };
                database_sql_my.CacheTime = 3;
                DataTable oDt_database_sql_my = database_sql_my.Select();


                DataRow[] oDrs_database_sql_my = oDt_database_sql_my.Select(database_sql_my._SOURCE_MD5 + "='" + Source_Md5 + "'");
                if (oDrs_database_sql_my != null && oDrs_database_sql_my.Length > 0)
                {
                    foreach (DataRow oDr in oDrs_database_sql_my)
                    {
                        if (out_WebManager_Name.IndexOf(oDr[database_sql_my._WEBMANAGER_NAME].ToString()) == -1)
                        {
                            out_WebManager_Name += oDr[database_sql_my._WEBMANAGER_NAME].ToString() + ",";
                            out_WebManager_RealName += oDr["WebManager_RealName"].ToString() + ",";
                        }
                    }
                    out_WebManager_Name = out_WebManager_Name.TrimEnd(',');
                    out_WebManager_RealName = out_WebManager_RealName.TrimEnd(',');
                }
            }
            #endregion

            #region 根据URL疑似人匹配疑似负责人
            if (string.IsNullOrEmpty(out_WebManager_Name) && !string.IsNullOrEmpty(PageUrl))
            {
                Entity.TEAMTOOL.WEBSITE_PAGEURL website_pageurl = new Entity.TEAMTOOL.WEBSITE_PAGEURL();
                website_pageurl.SelectColumns = new string[] { 
                    website_pageurl._PAGEURL, 
                    website_pageurl._WEBMANAGER_NAME, 
                    website_pageurl ._WEBMANAGER_REALNAME,
                    website_pageurl._WEBMANAGER_NAME_LIKE, 
                    website_pageurl ._WEBMANAGER_REALNAME_LIKE
                };
                website_pageurl.CacheTime = 120;
                DataTable oDt_website_pageurl = website_pageurl.Select();
                if (oDt_website_pageurl != null && oDt_website_pageurl.Rows.Count > 0)
                {
                    DataRow[] oDrs_website_pageurl = oDt_website_pageurl.Select(website_pageurl._PAGEURL + "='" + PageUrl + "'");
                    if (oDrs_website_pageurl != null && oDrs_website_pageurl.Length > 0)
                    {
                        DataRow oDr_website_pageurl = oDrs_website_pageurl[0];
                        out_WebManager_Name += oDr_website_pageurl[website_pageurl._WEBMANAGER_NAME_LIKE].ToString() ;
                        out_WebManager_RealName += oDr_website_pageurl[website_pageurl._WEBMANAGER_REALNAME_LIKE].ToString() ;

                    }
                }
            }
            #endregion
        }
    }
}
