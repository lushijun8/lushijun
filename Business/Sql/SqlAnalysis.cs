using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Sql
{

    public class SqlAnalysis
    {
        private static string Table_Names = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="oDt_database_table"></param>
        /// <param name="Database_User"></param>
        /// <param name="Sql_Analysis"></param>
        /// <param name="counts">counts = new int[] { nolock_count, select_all_count, not_parameter_count, like_count ,count_all,IsWriteSql,IsRuntimeSql,IsWrongDataBaseUser };</param>
        /// <returns></returns>
        public static string GelSqlError(string Sql, DataTable oDt_database_table, string Database_User, out string Sql_Analysis, out int[] counts)
        {
            string SqlError = "";
            Sql_Analysis = Sql;

            #region 如果SQL_ERROR为空，则重新算

            #region 得出所有表
            if (string.IsNullOrEmpty(Table_Names))
            {
                Entity.TEAMTOOL.DATABASE_TABLE database_table = new Entity.TEAMTOOL.DATABASE_TABLE();
                //database_table.Distinct = true;
                //database_table.CacheTime = 120;
                //database_table.SelectColumns = new string[] { database_table._TABLE_NAME, database_table._DATABASE_NAME }; 
                //database_table.WhereSql =   database_table._TABLE_NAME + " NOT IN ('INSERT','SELECT','DELETE','UPDATE','GROUP','ORDER','LIKE','WHERE','FROM')";
                //oDt_database_table = database_table.Select();
                foreach (DataRow oDr_database_table in oDt_database_table.Rows)
                {
                    if (oDr_database_table[database_table._TABLE_NAME].ToString().Trim().Length > 3)
                    {
                        Table_Names += oDr_database_table[database_table._TABLE_NAME].ToString() + "|";
                    }
                }
            }
            #endregion

            #region 正则表达式
            Regex reg_parameter = new Regex(@"(like|\=|\<|\>)(\s+)?\'([^\']{2,}|[^\%])\'", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_like = new Regex(@"\s(like)\s", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_nolock = new Regex(@"\(\s*NOLOCK\s*\)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_table = new Regex(@"(from|join)\s+[^\(]\S*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_select = new Regex(@"[^pagesize]([a-z]\.|\s+|\,|\d)\*(\s[^\@^\(]|\,)[^\d]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_delete = new Regex(@"(delete)\s+(from|join)\s+[^\(]\S*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_count_all = new Regex(@"count\(\*\)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_iswritesql = new Regex(@"(insert(\s+into)?|delete(\s+from)?|update|truncate)(\s+)?(\[?(\s+)?dbo(\s+)?\]?\.)?(\[?|(\s+))(" + Table_Names + "|[a-z|0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_iswritesql_temp = new Regex(@"(insert(\s+into)?|delete(\s+from)?|update|truncate)(\s+)?(\[?(\s+)?dbo(\s+)?\]?\.)?(\[?|(\s+))(@|#)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex reg_isruntimesql = new Regex(@"(\/\*(\*+)?(\s+)?SqlDebug)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            MatchCollection matchs_parameter = reg_parameter.Matches(Sql, 0);
            MatchCollection matchs_like = reg_like.Matches(Sql, 0);
            MatchCollection matchs_nolock = reg_nolock.Matches(Sql, 0);
            MatchCollection matchs_table = reg_table.Matches(Sql, 0);
            MatchCollection matchs_select = reg_select.Matches(Sql, 0);
            MatchCollection matchs_delete = reg_delete.Matches(Sql, 0);
            MatchCollection matchs_count_all = reg_count_all.Matches(Sql, 0);

            MatchCollection matchs_iswritesql_temp = reg_iswritesql_temp.Matches(Sql, 0);
            MatchCollection matchs_isruntimesql = reg_isruntimesql.Matches(Sql, 0);
            #endregion
            #region 去掉表变量和临时表，否则对更新sql提取有干扰
            string Sql_temp = Sql;
            foreach (Match match in matchs_iswritesql_temp)
            {
                Sql_temp = Sql_temp.Replace(match.Value, "");
            }
            #endregion

            MatchCollection matchs_iswritesql = reg_iswritesql.Matches(Sql_temp, 0);//从筛检后的sql进行匹配是否是更新的sql

            foreach (Match match in matchs_delete)
            {
                Sql = Sql.Replace(match.Value, match.Value.Replace(" ", ""));
            }
            int parameter_count = matchs_parameter.Count;
            int like_count = matchs_like.Count;
            int nolock_count = matchs_nolock.Count;
            int table_count = 0;
            int select_count = matchs_select.Count;
            int count_all = matchs_count_all.Count;
            int iswritesql = 0;
            int isruntimesql = 0;
            int IsWrongDataBaseUser = 0;
            if (matchs_iswritesql.Count > 0)
            {
                iswritesql = 1;
            }
            if (matchs_isruntimesql.Count > 0)
            {
                isruntimesql = 1;
            }
            else if (matchs_isruntimesql.Count == 0 && Database_User.ToLower().EndsWith("_w"))
            {
                isruntimesql = 1;
            }
            ArrayList list_matchs = new ArrayList();
            foreach (Match match in matchs_table)
            {
                #region 匹配表
                string[] tables0 = match.Value.Split(' ');
                string[] tables = tables0[tables0.Length - 1].Split('.');

                string tablename = tables[tables.Length - 1].Replace("[", "").Replace("]", "").Replace("(nolock)", "").Replace(")", "").Replace("'", "");
                DataRow[] oDrs_database_table = oDt_database_table.Select("TABLE_NAME='" + tablename + "'");
                if (oDrs_database_table != null && oDrs_database_table.Length > 0)//是真实表
                {
                    table_count++;
                    bool bReplace = false;
                    string color = "yellow";
                    string titles = "";
                    if (!list_matchs.Contains(match.Value + " "))
                    {
                        string split_char = " ";
                        int index_match = Sql.IndexOf(match.Value + split_char);
                        if (index_match == -1)
                        {
                            split_char = "\r";
                            index_match = Sql.IndexOf(match.Value + split_char);
                        }
                        if (index_match > -1)
                        {
                            string substring0 = Sql.Substring(index_match).ToLower();
                            int index_nolock = substring0.IndexOf("nolock");
                            if (index_nolock == -1 || index_nolock < match.Value.Length)
                            {
                                bReplace = true;
                                color = "red";
                                titles = "请加上WITH（NOLOCK）";
                            }
                            else if (index_nolock > match.Value.Length)
                            {
                                string substring1 = substring0.Substring(match.Value.Length, index_nolock - match.Value.Length);
                                string[] letters = substring1.Split(' ');
                                int count_letter = 0;
                                foreach (string letter in letters)
                                {
                                    if (!string.IsNullOrEmpty(letter.Trim()))
                                    {
                                        count_letter++;
                                    }
                                }
                                if (count_letter > 4)
                                {
                                    bReplace = true;
                                    color = "red";
                                    titles = "请加上WITH（NOLOCK）";
                                }
                            }
                        }
                        list_matchs.Add(match.Value + " ");
                        string prefix = match.Value.Split(' ')[0];
                        Sql_Analysis = Sql_Analysis.Replace(match.Value + split_char, prefix + "<span class=\"" + color + " sql_tooltip\" titles=\"" + titles + "\">" + match.Value.Substring(prefix.Length) + "</span>" + split_char);
                    }
                }
                #endregion
            }
            foreach (Match match in matchs_nolock)
            {
                Sql_Analysis = Sql_Analysis.Replace(match.Value, "<span class=\"green\">" + match.Value + "</span>");
            }
            foreach (Match match in matchs_select)
            {
                Sql_Analysis = Sql_Analysis.Replace(match.Value, "<span class=\"red sql_tooltip\" titles=\"请填写具体字段\">" + match.Value + "</span>");
            }
            foreach (Match match in matchs_delete)
            {
                Sql_Analysis = Sql_Analysis.Replace(match.Value.Replace(" ", ""), match.Value);
            }
            foreach (Match match in matchs_parameter)
            {
                Sql_Analysis = Sql_Analysis.Replace(match.Value, "<span class=\"black sql_tooltip\" titles=\"有sql漏洞，请使用参数化赋值,如：city=@city\">" + match.Value + "</span>");
            }
            Sql_Analysis = Regex.Replace(Sql_Analysis, @"\s(like)\s", "<span class=\"red sql_tooltip\" titles=\"请不要使用模糊查询\"> like </span>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Sql_Analysis = Regex.Replace(Sql_Analysis, @"\>(like)\s", "><span class=\"red sql_tooltip\" titles=\"请不要使用模糊查询\">like </span>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Sql_Analysis = Regex.Replace(Sql_Analysis, @"count\(\*\)", "><span class=\"red sql_tooltip\" titles=\"请写上明确的字段,不要使用count(*)\">count(*)</span>", RegexOptions.IgnoreCase | RegexOptions.Multiline);


            if (table_count > nolock_count)
            {
                SqlError += "少" + (table_count - nolock_count) + "个 WITH（NOLOCK）<br/>";
            }
            if (select_count > 0)
            {
                SqlError += "有" + select_count + "个 SELECT*<br/>";
            }
            if (parameter_count > 0)
            {
                SqlError += "有" + parameter_count + "个 赋值未参数化<br/>";
            }
            if (like_count > 0)
            {
                SqlError += "有" + like_count + "个 LIKE模糊查询<br/>";
            }
            if (count_all > 0)
            {
                SqlError += "有" + count_all + "个 COUNT(*)<br/>";
            }

            bool isWriter = false;
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_ADMIN_USER, database_owner._DATABASE_WRITER_USER, database_owner._DATABASE_READER_USER };
            database_owner.Distinct = true;
            database_owner.CacheTime = 1440;
            database_owner.Select();

            while (database_owner.Next())
            {
                if (Database_User.ToLower() == database_owner.DATABASE_WRITER_USER.ToLower() || Database_User.ToLower() == database_owner.DATABASE_ADMIN_USER.ToLower())
                {
                    isWriter = true;
                    break;
                }
            }


            if (isWriter == false)
            {
                string[] Writers = new string[] { 
                "btnet_admin",
                "btnet_w",
                "channelsales_admin",
                "channelsales_stats_admin",
                "channelsales_stats_w",
                "channelsales_test_admin",
                "channelsales_test_w",
                "channelsales_tuan_w",
                "channelsales_w", 
                "common_pay_admin",
                "common_pay_w",
                "guestbook_admin",
                "guestbook_w",
                "jk_pay_admin",
                "keyword_admin",
                "newhouse_xft_admin",
                "newhouse_xft_w",   
                "onlinesales_tao_admin",
                "onlinesales_tao_w",
                "pai_pai_admin",
                "pai_pai_w",
                "pai_w",
                "pai_zyhg_admin",
                "pai_zyhg_w",
                "Pay_admin",
                "Pay_w",
                "sfcostar_admin",
                "sfcostar_w",
                "tuan_admin",
                "tuan_api_w",
                "tuan_broker_api_w",
                "tuan_broker_w",
                "tuan_broker_web_w",
                "tuan_channel_api_w",
                "tuan_channel_w",
                "tuan_jktuan_w",
                "tuan_payorder_w",
                "tuan_tao_w",
                "tuan_test_admin",
                "tuan_test_xfw",
                "tuan_w",
                "tuan_xft_api_w",
                "tuan_xft_w",
                "villadb_w",
                "xft_admin",
                "xft_login_log_admin",
                "xft_login_log_w",
                "xft_w",
                "xinfangbangjk_wap_admin",
                "xinfangbangjk_wap_w"
                };
                foreach (string writer in Writers)
                {
                    if (Database_User.ToLower() == writer.ToLower())
                    {
                        isWriter = true;
                        break;
                    }
                }
            }

            if (iswritesql == 0 && isWriter == true)//非更新SQL，却用了可写用户
            {
                SqlError += "数据库读写权限未分开,有潜在危险<br/>";
                IsWrongDataBaseUser = 1;
            }
            #endregion
            counts = new int[] { (table_count - nolock_count) < 0 ? 0 : (table_count - nolock_count), select_count, parameter_count, like_count, count_all, iswritesql, isruntimesql, IsWrongDataBaseUser };
            return SqlError;
        }
        public static string GetRequestPageUrl(string text)
        {
            string PageUrl = "";
            Regex reg_SqlDebug = new Regex(@"\/\*\*(\s+)?SqlDebug.*?\*\*\/", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_SqlDebug = reg_SqlDebug.Matches(text, 0);
            if (matchs_SqlDebug.Count > 0)
            {
                string sqldebug = System.Web.HttpUtility.UrlDecode(matchs_SqlDebug[0].Value);
                Regex reg_pageurl = new Regex(@"Request:http(s?)://(www.)?[a-z0-9\.]+/.*?(\?|\s|\*|\%)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

                MatchCollection matchs_pageurl = reg_pageurl.Matches(sqldebug, 0);
                if (matchs_pageurl.Count > 0)
                {
                    PageUrl = Regex.Replace(matchs_pageurl[0].Value, "Request:", "", RegexOptions.IgnoreCase).TrimEnd('*').TrimEnd(' ').TrimEnd('?') + "?";
                    PageUrl = PageUrl.Split('?')[0];

                }
            }
            return PageUrl;
        }
        public static string GetNamespace(string text)
        {
            string Namespace = "";
            Regex reg_SqlDebug = new Regex(@"\/\*\*(\s+)?SqlDebug.*?\*\*\/", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_SqlDebug = reg_SqlDebug.Matches(text, 0);
            if (matchs_SqlDebug.Count > 0)
            {
                string sqldebug = System.Web.HttpUtility.UrlDecode(matchs_SqlDebug[0].Value);
                Regex reg_namespace = new Regex(@"Namespace\:[a-z|.|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                MatchCollection matchs_namespace = reg_namespace.Matches(sqldebug, 0);
                if (matchs_namespace.Count > 0)
                {
                    Namespace = Regex.Replace(matchs_namespace[0].Value, "Namespace:", "", RegexOptions.IgnoreCase);
                }
            }
            return Namespace;
        }
        public static string GetFunction(string text)
        {
            string Function = "";
            Regex reg_SqlDebug = new Regex(@"\/\*\*(\s+)?SqlDebug.*?\*\*\/", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_SqlDebug = reg_SqlDebug.Matches(text, 0);
            if (matchs_SqlDebug.Count > 0)
            {
                string sqldebug = System.Web.HttpUtility.UrlDecode(matchs_SqlDebug[0].Value);
                Regex reg_function = new Regex(@"Function\:[a-z|.|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                MatchCollection matchs_function = reg_function.Matches(sqldebug, 0);
                if (matchs_function.Count > 0)
                {
                    Function = Regex.Replace(matchs_function[0].Value, "Function:", "", RegexOptions.IgnoreCase);
                }
            }
            return Function;
        }
        public static string GetServerInfo(string text)
        {
            string ServerInfo = "";
            Regex reg_ServerInfo = new Regex(@"ServerInfo\:[a-z|\.|_|\-|0-9|\;|\:|\%]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_ServerInfo = reg_ServerInfo.Matches(text, 0);
            if (matchs_ServerInfo.Count > 0)
            {
                ServerInfo = Regex.Replace(matchs_ServerInfo[0].Value, "ServerInfo:", "", RegexOptions.IgnoreCase);
            }
            return ServerInfo;
        }
        public static string GetConnectionString(string text)
        {
            string ConnectionString = "";
            Regex reg_ConnectionString = new Regex(@"ConnectionString\:[a-z|0-9]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_ConnectionString = reg_ConnectionString.Matches(text, 0);
            if (matchs_ConnectionString.Count > 0)
            {
                ConnectionString = Regex.Replace(matchs_ConnectionString[0].Value, "ConnectionString:", "", RegexOptions.IgnoreCase);
            }
            return Com.Common.EncDec.Decrypt(ConnectionString, "fang.com");
        }
        public static string GetConnectionStringDataBaseUserId(string ConnectionString)
        {
            string UserId = "";
            Regex reg_UserId = new Regex(@"(user(\s+)|u)id(\s+)?\=(\s+)?[a-z|0-9|_|-]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_UserId = reg_UserId.Matches(ConnectionString, 0);
            if (matchs_UserId.Count > 0)
            {
                UserId = matchs_UserId[0].Value.Split('=')[1].Trim();
            }
            return UserId;
        }
        public static string GetConnectionStringDataBaseName(string ConnectionString)
        {
            string UserId = "";
            Regex reg_UserId = new Regex(@"database(\s+)?\=(\s+)?[a-z|0-9|_|-]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_UserId = reg_UserId.Matches(ConnectionString, 0);
            if (matchs_UserId.Count > 0)
            {
                UserId = matchs_UserId[0].Value.Split('=')[1].Trim();
            }
            return UserId;
        }
        public static string GetConnectionStringDataBaseIp(string ConnectionString)
        {
            string UserId = "";
            Regex reg_UserId = new Regex(@"(Data(\s+)?Source|server(\s+)?)\=(\s+)?[a-z|0-9|\.]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_UserId = reg_UserId.Matches(ConnectionString, 0);
            if (matchs_UserId.Count > 0)
            {
                UserId = matchs_UserId[0].Value.Split('=')[1].Trim();
            }
            return UserId;
        }
        public static string GetSessionId(string text)
        {
            string SessionId = "";
            Regex reg_SessionId = new Regex(@"SessionId\:[a-z|0-9|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_SessionId = reg_SessionId.Matches(text, 0);
            if (matchs_SessionId.Count > 0)
            {
                SessionId = Regex.Replace(matchs_SessionId[0].Value, "SessionId:", "", RegexOptions.IgnoreCase);
            }
            return SessionId;
        }
        public static DateTime GetDateTime(string text)
        {
            string Time = "";
            Regex reg_Time = new Regex(@"Time\:\d{4}(-|/)\d{1,2}(-|/)\d{1,2}\s+\d{1,2}:\d{1,2}:\d{1,2}(.\d{1,3})?(\s+)?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_Time = reg_Time.Matches(text, 0);
            if (matchs_Time.Count > 0)
            {
                Time = Regex.Replace(matchs_Time[0].Value, "Time:", "", RegexOptions.IgnoreCase);
            }
            if (string.IsNullOrEmpty(Time))
            {
                Time = "1900-1-1 00:00:00";
            }
            DateTime dt = DateTime.Now;
            try
            {
                dt = DateTime.Parse(Time);
            }
            catch (Exception ex)
            {
                Console.Write("\r\n" + DateTime.Now.ToString() + "text:" + text + "; Time:" + Time);
                throw ex;
            }
            return dt;
        }
        public static string GetSourceMd5(string text)
        {
            string source_featrue = "";
            Regex reg_SqlDebug = new Regex(@"\/\*\*(\s+)?SqlDebug.*?\*\*\/", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matchs_SqlDebug = reg_SqlDebug.Matches(text, 0);
            if (matchs_SqlDebug.Count > 0)
            {
                #region 抓取sql特征
                string sqldebug = System.Web.HttpUtility.UrlDecode(matchs_SqlDebug[0].Value);
                Regex reg_pageurl = new Regex(@"Request:http(s?)://(www.)?[a-z0-9\.]+/.*?(\?|\s|\*|\%)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Regex reg_namespace = new Regex(@"Namespace\:[a-z|.|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Regex reg_function = new Regex(@"Function\:[a-z|.|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Regex reg_parameter = new Regex(@"\@[a-z|_]+", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                MatchCollection matchs_pageurl = reg_pageurl.Matches(sqldebug, 0);
                MatchCollection matchs_parameter = reg_parameter.Matches(sqldebug, 0);
                MatchCollection matchs_namespace = reg_namespace.Matches(sqldebug, 0);
                MatchCollection matchs_function = reg_function.Matches(sqldebug, 0);
                if (matchs_pageurl.Count > 0)
                {
                    string PageUrl = Regex.Replace(matchs_pageurl[0].Value, "Request:", "", RegexOptions.IgnoreCase).TrimEnd('*').TrimEnd(' ').TrimEnd('?') + "?";
                    PageUrl = PageUrl.Split('?')[0];
                    string[] pageurls = PageUrl.Split('/');
                    string PageUrl_Regex = PageUrl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");
                    source_featrue += PageUrl_Regex.ToLower();
                }
                if (matchs_parameter.Count > 0)
                {
                    foreach (Match match in matchs_parameter)
                    {
                        source_featrue += match.Value;
                    }
                }
                if (matchs_namespace.Count > 0)
                {

                    source_featrue += matchs_namespace[0].Value;

                }
                if (matchs_function.Count > 0)
                {

                    source_featrue += matchs_function[0].Value;
                }
                #endregion
            }
            if (!string.IsNullOrEmpty(source_featrue))
            {
                return Com.Common.EncDec.PasswordEncrypto(source_featrue);
            }
            return source_featrue;
        }
        public static string FormatSql(string Sql)
        {
            string formatSql = Sql;
            string exec_sp_executesql = "exec sp_executesql N'";
            int index_sp_executesql_index = Sql.IndexOf(exec_sp_executesql);
            if (index_sp_executesql_index > -1)
            {
                int index_sp_executesql_start = index_sp_executesql_index + exec_sp_executesql.Length;
                int index_sp_executesql_end = Sql.IndexOf("',N'");
                if (index_sp_executesql_start > 0 && index_sp_executesql_end > index_sp_executesql_start)
                {
                    formatSql = Sql.Substring(index_sp_executesql_start, index_sp_executesql_end - index_sp_executesql_start);
                }
            }

            //exec sp_executesql N'select count(*) from UserAndProjMainTable with (nolock) where Rowstate>@maxRowState ',N'@maxRowState varbinary(10)',@maxRowState=0x000000032EF2A14E0000


            formatSql = Regex.Replace(formatSql, @"\s(like)\s", "(?)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            formatSql = Regex.Replace(formatSql, @"\([^\(][^=][^<][^>][^nolock][^select][^varchar][^int][^datetime][^decimal]+[^\)]\)", "(?)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"''''", "''?''", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"''[^'']+?''", "''?''", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\s(-?[0-9]{1,})\s", " ? ", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\s?&[^a-z](-?[0-9]{1,})\s?,", "?,", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            formatSql = Regex.Replace(formatSql, @"(=[^\s]-?[0-9]{1,})", "=?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(=\s?-?[0-9]{1,})", "=?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(<>[^\s]-?[0-9]{1,})", "<>?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(<>\s?-?[0-9]{1,})", "<>?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(!=[^\s]-?[0-9]{1,})", "!=?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(!=\s?-?[0-9]{1,})", "!=?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(>[^\s]-?[0-9]{1,})", ">?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(>\s?-?[0-9]{1,})", ">?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(<[^\s]-?[0-9]{1,})", "<?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(<\s?-?[0-9]{1,})", "<?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"(\/\*(.*?)\*\/)", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\sn?(var)?char\(\d+\)", " ?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\(([0-9]|\s|\,|\'')+\)", "?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\d+", "?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            formatSql = Regex.Replace(formatSql, @"\s", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return formatSql.ToLower();

        }
    }
}
