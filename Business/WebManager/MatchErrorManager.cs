using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace Business.WebManager
{
    public class MatchErrorManager
    {
        /// <summary>
        /// 根据PageUrl或者文件路径匹配内容的负责人
        /// </summary>
        /// <param name="Content">The content.</param>
        /// <returns>负责人的用户名，例如:zhangsan</returns>
        public static ArrayList MatchWebManager(string Content,out DataTable oDt_PageUrl)
        {
            oDt_PageUrl = new DataTable();
            oDt_PageUrl.Columns.Add(new DataColumn("PageUrl", typeof(string)));
            oDt_PageUrl.Columns.Add(new DataColumn("WebManager_RealName", typeof(string)));

            ArrayList Result = new ArrayList();
            string webmanager = "";
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME };
            admin_webmanager.CacheTime = 1440;
            admin_webmanager.WEBMANAGER_STATUS = 100;
            admin_webmanager.Select();
            while(admin_webmanager.Next())
            {
                webmanager += "(" + admin_webmanager.WEBMANAGER_NAME + ")|";
                
            }
            Regex regex_pageurl = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex regex_filepath = new Regex(@"(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+.[\w]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex regex_webmanager= new Regex(webmanager.TrimEnd('|'), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_pageurl = regex_pageurl.Matches(Content, 0);
            MatchCollection matchs_filepath = regex_filepath.Matches(Content, 0);
            MatchCollection matchs_webmanager = regex_webmanager.Matches(Content, 0);

            ArrayList list_pageurl = new ArrayList();
            ArrayList list_filepath = new ArrayList();
            ArrayList list_webmanager = new ArrayList();
            foreach (Match match in matchs_pageurl)
            {
                string pageurl = (match.Value.ToString().TrimEnd('?') + "?").Split('?')[0];
                if (!list_pageurl.Contains(pageurl))
                {
                    list_pageurl.Add(pageurl);

                    DataRow oDr_New = oDt_PageUrl.NewRow();
                    oDr_New["PageUrl"] = pageurl;
                    oDt_PageUrl.Rows.Add(oDr_New);
                }
            }

            foreach (Match match in matchs_filepath)
            {
                if (!list_filepath.Contains(match.Value))
                {
                    list_filepath.Add(match.Value);
                }
            }
            //--------------------------------------------------------------------
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.INNER_JOIN_ADMIN_WEBMANAGER = true;
            website_my_pageurl.SelectColumns = new string[] { website_my_pageurl._PAGEURL, website_my_pageurl._PAGEURL_REGEX, website_my_pageurl.TableName + "." + website_my_pageurl._WEBMANAGER_NAME,"WEBMANAGER_REALNAME" };
            website_my_pageurl.CacheTime = 1440;
            DataTable dt_website_my_pageurl = website_my_pageurl.Select();

            foreach (string pageurl in list_pageurl.ToArray())
            {
                //string pageurl = (url.ToString().TrimEnd('?') + "?").Split('?')[0];
                string[] pageurls = pageurl.Split('/');
                string pageurl_regex = pageurl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
                DataRow[] oDrs_website_my_pageurl = dt_website_my_pageurl.Select(website_my_pageurl._PAGEURL_REGEX + "='" + pageurl_regex + "'");

                if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                {
                    string WebManager_RealName = "";
                    foreach (DataRow oDr_website_my_pageurl in oDrs_website_my_pageurl)
                    {
                        if (!Result.Contains(oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString()))
                        {
                            Result.Add(oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString().ToLower());
                        }
                        //----------------------------------------------------------
                        if(WebManager_RealName.IndexOf(oDr_website_my_pageurl["WEBMANAGER_REALNAME"].ToString())==-1)
                        {
                            WebManager_RealName += oDr_website_my_pageurl["WEBMANAGER_REALNAME"].ToString() + " ";
                        }
                    }
                    oDt_PageUrl.Select("PageUrl='" + pageurl + "'")[0]["WEBMANAGER_REALNAME"] = WebManager_RealName;
                }
            }
            //----------------------------------------------------------------------            
            Entity.TEAMTOOL.SVN_LOG svn_log = new Entity.TEAMTOOL.SVN_LOG();
            svn_log.SelectColumns = new string[] { svn_log._WEBMANAGER_NAME, svn_log._COMMIT_FILE, "COUNT(1) AS COUNTS", "MAX(" + svn_log._COMMIT_TIME + ") AS " + svn_log._COMMIT_TIME };
            svn_log.WhereSql = svn_log._WEBMANAGER_NAME + " IN (SELECT " + svn_log._WEBMANAGER_NAME + " FROM Admin_WebManager ) AND ( " + svn_log._COMMIT_FILE + " like '%.cs' OR " + svn_log._COMMIT_FILE + " like '%.cshtml' OR " + svn_log._COMMIT_FILE + " like '%.aspx')";
            svn_log.GroupBy = svn_log._WEBMANAGER_NAME + "," + svn_log._COMMIT_FILE;
            svn_log.CacheTime = 120;
            DataTable oDt_svn_log = svn_log.Select();
            foreach (object path in list_filepath.ToArray())
            {
                string[] items = null;
                int lastindex = path.ToString().LastIndexOf('.');
                if (lastindex > 0)
                { 
                    items = path.ToString().Substring(0, lastindex).Split('\\');//D:\inetpub\ECChannelStatistics\Business\Common\LogBusiness
                }
                else
                {
                    items = path.ToString().Split('\\');

                }
                for (int i = 0; i < items.Length; i++)
                {
                    string filepath = "";
                    for (int j = i; j < items.Length; j++)
                    {
                        filepath += items[j] + "/";
                    }
                    filepath = filepath.TrimEnd('/');
                    DataView oDv_svn_log = oDt_svn_log.DefaultView;
                    oDv_svn_log.RowFilter = svn_log._COMMIT_FILE + " LIKE '%" + filepath + "%'";
                    oDv_svn_log.Sort = svn_log._COMMIT_TIME + " DESC,COUNTS DESC";
                    if (oDv_svn_log.Count > 0)
                    {
                        foreach (DataRowView oDv in oDv_svn_log)
                        {
                            if (!Result.Contains(oDv.Row[svn_log._WEBMANAGER_NAME].ToString()))
                            {
                                Result.Add(oDv.Row[svn_log._WEBMANAGER_NAME].ToString().ToLower());
                            }
                        }
                        break;
                    }

                }
            } 
            //----------------------------------------------------------
            foreach (Match match in matchs_webmanager)
            {
                if (!Result.Contains(match.Value))
                {
                    Result.Add(match.Value.ToLower());
                }
            }
            return Result;
        }
    }
}
