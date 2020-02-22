using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace Business
{
    public class MemcachedStats
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MEMCACHE_IP"></param>
        /// <param name="MEMCACHE_PORT"></param>
        /// <returns></returns>
        public static bool Refresh(string MEMCACHE_IP, int MEMCACHE_PORT)
        {
            bool bResult = false;
            DateTime Today = DateTime.Parse(DateTime.Now.ToShortDateString());
            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            memcache_server.MEMCACHE_IP = MEMCACHE_IP;
            memcache_server.MEMCACHE_PORT = MEMCACHE_PORT;
            memcache_server.SelectColumns = new string[] { memcache_server._MEMCACHE_IP, memcache_server._MEMCACHE_PORT, memcache_server._MEMCACHE_LOCAL_IP, memcache_server._ERROR_KEY };
            memcache_server.CacheTime = 30;
            memcache_server.Select();
            while (memcache_server.Next())
            {
                string data = "";

                Com.Net.TelnetUtil telnet = new Com.Net.TelnetUtil(memcache_server.MEMCACHE_IP, int.Parse(memcache_server.MEMCACHE_PORT_ToString), 20);
                if (telnet.Connect() == true)
                {
                    //等待指定字符返回后才执行下一命令 
                    telnet.Send("stats");
                    telnet.WaitFor("END");
                    data = telnet.WorkingData;
                    telnet.Send("quit");
                    //telnet.WaitFor("+OK");
                }
                string Error = "";
                foreach (string error_key in memcache_server.ERROR_KEY.Split(','))
                {
                    Business.Memcached memcached = new Business.Memcached(MEMCACHE_IP + ":" + MEMCACHE_PORT);
                    object val = memcached.Instance.Get(error_key);
                    if (val != null)
                    {
                        memcached.Instance.Remove(error_key);//清空记录
                        Error += error_key + ";" + (string)val + ";";
                        if ("set_misses_count,set_hits_count,get_misses_count,get_hits_count".IndexOf(error_key.ToLower()) > -1 && (string)val != "")
                        {
                            //memcached.Instance.Remove(error_key);//清空记录
                            string[] items = ((string)val).Split(';');
                            foreach (string item in items)
                            {
                                if (item.StartsWith("http") && item.EndsWith("]"))
                                {
                                    string[] sub_items = item.Split(',');
                                    if (sub_items.Length == 2)
                                    {
                                        #region 更新
                                        string classname = "";
                                        string functionname = Regex.Replace(sub_items[1], @"\[[0-9]{1,}\]", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                                        if (functionname.IndexOf("@") > -1)
                                        {
                                            string[] functionnames = functionname.Split('@');
                                            functionname = functionnames[0];
                                            classname = functionnames[1].Replace(";", "");
                                        }
                                        long count = 0;
                                        Match match = Regex.Match(sub_items[1], @"\[([0-9]{1,})\]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                                        if (match.Success)
                                        {
                                            int MatchCount = match.Groups.Count;
                                            if (MatchCount > 1)
                                            {
                                                count = long.Parse(match.Groups[1].Value);
                                            }
                                        }

                                        Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits_select = new Entity.TEAMTOOL.MEMCACHE_HITS();
                                        memcache_hits_select.PAGEURL = sub_items[0];
                                        memcache_hits_select.FUNCTIONNAME = functionname;
                                        memcache_hits_select.STATS_DATE = Today;
                                        DataRow oDr = memcache_hits_select.SelectTop1();

                                        //===================================================

                                        Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits = new Entity.TEAMTOOL.MEMCACHE_HITS();
                                        if (oDr != null)//已经存在了记录
                                        {
                                            memcache_hits[error_key] = (long.Parse(memcache_hits_select[error_key]) + count).ToString();
                                            if (memcache_hits_select.CLASSNAME.IndexOf(classname) == -1)
                                            {
                                                memcache_hits.CLASSNAME = memcache_hits_select.CLASSNAME + ";" + classname;
                                            }
                                        }
                                        else
                                        {
                                            memcache_hits[error_key] = count.ToString();
                                            memcache_hits.CLASSNAME = classname;
                                        }
                                        memcache_hits.STATS_DATE = Today;
                                        memcache_hits.PAGEURL = sub_items[0];
                                        memcache_hits.FUNCTIONNAME = functionname;
                                        memcache_hits.MEMCACHE_IP = MEMCACHE_IP;
                                        memcache_hits.MEMCACHE_PORT = MEMCACHE_PORT;
                                        memcache_hits.CREATETIME = DateTime.Now;
                                        if (oDr != null)//已经存在了记录
                                        {
                                            memcache_hits.Update();
                                        }
                                        else
                                        {
                                            memcache_hits.Insert();
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
                string Sql = "update Memcache_Hits set set_count=set_hits_count+set_misses_count,get_count=get_hits_count+get_misses_count";
                memcache_server.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);

                if (!string.IsNullOrEmpty(data))
                {
                    #region 更新
                    #region 统计那些域名在用
                    string WebSite = "";
                    Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits_sum = new Entity.TEAMTOOL.MEMCACHE_HITS();
                    memcache_hits_sum.Distinct = true;
                    memcache_hits_sum.GroupBy = "SUBSTRING(" + memcache_hits_sum._PAGEURL + ",8,charindex('/'," + memcache_hits_sum._PAGEURL + "+'/',8)-8)";
                    memcache_hits_sum.STATS_DATE = Today;
                    memcache_hits_sum.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_hits_sum.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_hits_sum.SelectColumns = new string[]{
                        "SUBSTRING(" + memcache_hits_sum._PAGEURL + ",8,charindex('/'," + memcache_hits_sum._PAGEURL + "+'/',8)-8) as " + memcache_hits_sum._PAGEURL + "",
                        "SUM(" + memcache_hits_sum._SET_HITS_COUNT + ") as " + memcache_hits_sum._SET_HITS_COUNT + "",
                        "SUM(" + memcache_hits_sum._SET_MISSES_COUNT + ") as " + memcache_hits_sum._SET_MISSES_COUNT + "",
                        "SUM(" + memcache_hits_sum._SET_COUNT + ") as " + memcache_hits_sum._SET_COUNT + "",
                        "SUM(" + memcache_hits_sum._GET_HITS_COUNT + ") as " + memcache_hits_sum._GET_HITS_COUNT + "",
                        "SUM(" + memcache_hits_sum._GET_MISSES_COUNT + ") as " + memcache_hits_sum._GET_MISSES_COUNT + "",
                        "SUM(" + memcache_hits_sum._GET_COUNT + ") as " + memcache_hits_sum._GET_COUNT + ""};
                    DataTable oDt = memcache_hits_sum.Select();
                    foreach (DataRow oDr in oDt.Rows)
                    {
                        WebSite += oDr[memcache_hits_sum._PAGEURL].ToString() + "[set_hits:" + oDr[memcache_hits_sum._SET_HITS_COUNT].ToString() + ",set_misses:" + oDr[memcache_hits_sum._SET_MISSES_COUNT].ToString() +
                            ",get_hits:" + oDr[memcache_hits_sum._GET_HITS_COUNT].ToString() + ",get_misses:" + oDr[memcache_hits_sum._GET_MISSES_COUNT].ToString() + ",get_hits_rate:" +
                            (
                            ((long.Parse(oDr[memcache_hits_sum._GET_HITS_COUNT].ToString()) * 100) /
                            long.Parse(oDr[memcache_hits_sum._GET_COUNT].ToString() == "0" ? "1" : oDr[memcache_hits_sum._GET_COUNT].ToString())).ToString("f2").Replace(".00", "")
                            ) + "%];";
                    }
                    #endregion

                    string[] cols = new string[] {  "pid", "uptime", "time", "version", "libevent", "pointer_size", 
                        "rusage_user", "rusage_system", "curr_connections", "total_connections", "connection_structures",
                        "reserved_fds", "cmd_get", "cmd_set", "cmd_flush", "cmd_touch", "get_hits",
                        "get_misses", "delete_misses", "delete_hits", "incr_misses",
                        "incr_hits", "decr_misses", "decr_hits", "cas_misses", "cas_hits", 
                        "cas_badval", "touch_hits", "touch_misses", "auth_cmds", "auth_errors",
                        "bytes_read", "bytes_written", "limit_maxbytes", "accepting_conns", 
                        "listen_disabled_num", "threads", "conn_yields", "hash_power_level", 
                        "hash_bytes", "hash_is_expanding", "bytes", "curr_items", "total_items",
                        "expired_unfetched", "evicted_unfetched", "evictions", "reclaimed"};
                    //更新
                    Entity.TEAMTOOL.MEMCACHE_STATS memcache_stats_update = new Entity.TEAMTOOL.MEMCACHE_STATS();
                    memcache_stats_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_stats_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_stats_update.STATS_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                    memcache_stats_update.MEMCACHE_LOCAL_IP = memcache_server.MEMCACHE_LOCAL_IP;
                    memcache_stats_update.ERROR = Error;
                    memcache_stats_update.ERROR_KEY = memcache_server.ERROR_KEY;
                    memcache_stats_update.CREATETIME = System.DateTime.Now;
                    if (data.ToLower().IndexOf("limit_maxbytes") > -1)
                    {
                        memcache_stats_update.STATUS = 1;
                    }
                    else
                    {
                        memcache_stats_update.STATUS = 0;
                    }
                    memcache_stats_update.WEBSITE = WebSite;
                    memcache_stats_update.STATSINFO = data;

                    foreach (string col in cols)
                    {
                        string[] arr = Com.Net.HtmlUtil.GetRegexGroupFromString(@"STAT\s" + col + @"\s([^\s]+)\s", data, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        if (arr != null)
                        {
                            memcache_stats_update[col] = arr[0];
                        }
                    }
                    if (!memcache_stats_update.Insert())
                    {
                        if (!memcache_stats_update.Update())
                        {
                            bResult = false;
                        }
                        else
                        {

                            bResult = true;
                        }
                    }
                    else
                    {
                        bResult = true;
                    }


                    Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server_update = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                    memcache_server_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_server_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    if (data.ToLower().IndexOf("limit_maxbytes") > -1)
                    {
                        memcache_server_update.STATUS = 1;
                    }
                    else
                    {
                        memcache_server_update.STATUS = 0;
                    }
                    memcache_server_update.Update();

                    #endregion
                }
                else
                {
                    //更新
                    Entity.TEAMTOOL.MEMCACHE_STATS memcache_stats_update = new Entity.TEAMTOOL.MEMCACHE_STATS();
                    memcache_stats_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_stats_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_stats_update.STATS_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                    memcache_stats_update.STATUS = 0;
                    memcache_stats_update.Update();

                    Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server_update = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                    memcache_server_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_server_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_server_update.STATUS = 0;
                    memcache_server_update.Update();
                }
            }
            return bResult;
        }
    }
}
