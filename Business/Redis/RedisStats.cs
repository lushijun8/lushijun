using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;


namespace Business.Redis
{
    public class RedisStats
    {
        public static bool Refresh(string MEMCACHE_IP, int MEMCACHE_PORT)
        {
            bool bResult = false;
            DateTime Today = DateTime.Parse(DateTime.Now.ToShortDateString());
            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            memcache_server.MEMCACHE_IP = MEMCACHE_IP;
            memcache_server.MEMCACHE_PORT = MEMCACHE_PORT;
            //memcache_server.SelectColumns = new string[] { memcache_server._MEMCACHE_IP, memcache_server._MEMCACHE_PORT, memcache_server._MEMCACHE_LOCAL_IP, memcache_server._ERROR_KEY, memcache_server._AUTH };
            memcache_server.CacheTime = 30;
            memcache_server.Select();
            while (memcache_server.Next())
            {
                string data = "";

                Com.Net.TelnetUtil telnet = new Com.Net.TelnetUtil(memcache_server.MEMCACHE_IP, int.Parse(memcache_server.MEMCACHE_PORT_ToString), 10);
                if (telnet.Connect() == true)
                {
                    //等待指定字符返回后才执行下一命令 
                    telnet.Send("auth " + memcache_server.AUTH);
                    telnet.WaitFor("+OK");
                    telnet.Send("info");
                    telnet.WaitFor("$");
                    data = telnet.WorkingData;
                    telnet.Send("quit");
                    //telnet.WaitFor("+OK");
                }
                string Error = "";
                if (!string.IsNullOrEmpty(data))
                {
                    #region 更新
                    #region 统计那些域名在用
                    string WebSite = "";
                    Entity.TEAMTOOL.MEMCACHE_HITS memcache_hits_sum = new Entity.TEAMTOOL.MEMCACHE_HITS();
                    memcache_hits_sum.Distinct = true;
                    memcache_hits_sum.GroupBy = "substring(" + memcache_hits_sum._PAGEURL + ",8,charindex('.com'," + memcache_hits_sum._PAGEURL + ")-4)";
                    memcache_hits_sum.STATS_DATE = Today;
                    memcache_hits_sum.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_hits_sum.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_hits_sum.SelectColumns = new string[]{
                        "substring(" + memcache_hits_sum._PAGEURL + ",8,charindex('.com'," + memcache_hits_sum._PAGEURL + ")-4) as " + memcache_hits_sum._PAGEURL + "",
                        "sum(" + memcache_hits_sum._SET_HITS_COUNT + ") as " + memcache_hits_sum._SET_HITS_COUNT + "",
                        "sum(" + memcache_hits_sum._SET_MISSES_COUNT + ") as " + memcache_hits_sum._SET_MISSES_COUNT + "",
                        "sum(" + memcache_hits_sum._SET_COUNT + ") as " + memcache_hits_sum._SET_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_HITS_COUNT + ") as " + memcache_hits_sum._GET_HITS_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_MISSES_COUNT + ") as " + memcache_hits_sum._GET_MISSES_COUNT + "",
                        "sum(" + memcache_hits_sum._GET_COUNT + ") as " + memcache_hits_sum._GET_COUNT + ""};
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

                    //更新
                    Entity.TEAMTOOL.MEMCACHE_STATS memcache_stats_update = new Entity.TEAMTOOL.MEMCACHE_STATS();
                    memcache_stats_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                    memcache_stats_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                    memcache_stats_update.STATS_DATE = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                    memcache_stats_update.MEMCACHE_LOCAL_IP = memcache_server.MEMCACHE_LOCAL_IP;
                    memcache_stats_update.ERROR = Error;
                    memcache_stats_update.ERROR_KEY = memcache_server.ERROR_KEY;
                    memcache_stats_update.CREATETIME = System.DateTime.Now;

                    if (data.ToLower().IndexOf("redis_version") > -1)
                    {
                        memcache_stats_update.STATUS = 1;
                    }
                    else
                    {
                        memcache_stats_update.STATUS = 0;
                    }
                    memcache_stats_update.WEBSITE = WebSite;

                    string RedisInfo = "";

                    string[] redisinfos = data.Split("\r\n".ToCharArray());

                    foreach (string item in redisinfos)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            string remark = "";
                            if (item.IndexOf(":") > -1)
                            {
                                string key = item.Split(':')[0].Trim();
                                for (int i = 0; i < Entity.TEAMTOOL.REDISINFO.Keys.Length; i++)
                                {
                                    if (key.ToLower() == Entity.TEAMTOOL.REDISINFO.Keys[i].ToLower())
                                    {
                                        remark = Entity.TEAMTOOL.REDISINFO.Remarks[i];
                                        break;
                                    }
                                }
                            }
                            if (item.StartsWith("#"))
                            {

                                RedisInfo += "\r\n";
                            }
                            RedisInfo += item;
                            if (!string.IsNullOrEmpty(remark))
                            {
                                RedisInfo += "       <font color=green>//" + remark + "</font>";
                            }
                            RedisInfo += "\r\n";
                        }
                    }
                    memcache_stats_update.STATSINFO = RedisInfo;

                    string[] cols = new string[] {"pid", "uptime", "version",  "pointer_size", 
                        "curr_connections", "total_connections", 
                        "get_hits",
                        "get_misses", 
                        "limit_maxbytes", "bytes","bytes_read","bytes_written"};

                    string[] cols1 = new string[] {"process_id", "uptime_in_seconds", "redis_version", "arch_bits", 
                       "connected_clients", "total_connections_received",
                        "keyspace_hits",
                        "keyspace_misses",
                        "used_memory_peak", "used_memory","bytes_read","bytes_written"};

                    for (int i = 0; i < cols.Length; i++)
                    {
                        memcache_stats_update[cols[i]] = "0";
                        string[] arr = Com.Net.HtmlUtil.GetRegexGroupFromString(cols1[i] + @":(.*)\r\n", data, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        if (arr != null)
                        {
                            memcache_stats_update[cols[i]] = arr[0];
                        }
                    }



                    long expired_keys = 0; //因为过期而被自动删除的数据库键数量
                    long evicted_keys = 0; //因为最大内存容量限制而被驱逐（evict）的键数量

                    string[] arr_expired_keys = Com.Net.HtmlUtil.GetRegexGroupFromString(@"expired_keys:(.*)\r\n", data, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    if (arr_expired_keys != null)
                    {
                        expired_keys = long.Parse(arr_expired_keys[0]);
                    }
                    string[] arr_evicted_keys = Com.Net.HtmlUtil.GetRegexGroupFromString(@"evicted_keys:(.*)\r\n", data, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    if (arr_evicted_keys != null)
                    {
                        evicted_keys = long.Parse(arr_evicted_keys[0]);
                    }


                    long curr_items = 0;
                    ArrayList arr_DB = Com.Net.HtmlUtil.GetRegexFromString(@"db[0-9]+:keys=(\d+),expires=(\d+),avg_ttl=(\d+)", data, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    for (int i = 0; i < arr_DB.Count; i++)
                    {
                        string[] arr_keys = Com.Net.HtmlUtil.GetRegexGroupFromString(@"db[0-9]+:keys=(\d+),expires=(\d+),avg_ttl=(\d+)", arr_DB[i].ToString(), RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        if (arr_keys.Length >= 3)
                        {
                            curr_items += long.Parse(arr_keys[0]);
                        }
                    }
                    memcache_stats_update.CURR_ITEMS = curr_items;
                    memcache_stats_update.TOTAL_ITEMS = curr_items + expired_keys + evicted_keys;

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
                    if (data.ToLower().IndexOf("redis_version") > -1)
                    {
                        memcache_server_update.STATUS = 1;
                    }
                    else
                    {
                        memcache_server_update.STATUS = 0;
                    }
                    if (data.ToLower().IndexOf("role:master") > -1)
                    {
                        memcache_server_update.REMARK = memcache_server.REMARK.Replace("slave", "master");
                    }
                    else if (data.ToLower().IndexOf("role:slave") > -1)
                    {
                        memcache_server_update.REMARK = memcache_server.REMARK.Replace("master", "slave");
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
