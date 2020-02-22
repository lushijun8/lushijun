using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace TeamToolTask
{
    public class MemcachedController
    {
        static string GetMemcachePortDate = "";
        public static void MemcacheStats(string ip)
        {
            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();

            //memcache_server.CACHETYPE = 1;
            //memcache_server.MEMCACHE_IP = "124.251.45.133";
            //memcache_server.MEMCACHE_PORT = 11211;

            memcache_server.SelectColumns = new string[] { memcache_server._MEMCACHE_IP, memcache_server._MEMCACHE_PORT, memcache_server._MEMCACHE_LOCAL_IP, memcache_server._ERROR_KEY, memcache_server._CACHETYPE, memcache_server._RESETTIME };
            memcache_server.MEMCACHE_IP = ip + "%";
            memcache_server.Select();
            while (memcache_server.Next())
            {
                #region 检查是否可用
                bool bRefresh = false;
                string StatsType = "MemcachedStats";
                try
                {
                    if (memcache_server.CACHETYPE_ToString == "0")
                    {
                        bRefresh = Business.MemcachedStats.Refresh(memcache_server.MEMCACHE_IP, int.Parse(memcache_server.MEMCACHE_PORT_ToString));
                        StatsType = "MemcachedStats";
                    }
                    else
                    {
                        bRefresh = Business.Redis.RedisStats.Refresh(memcache_server.MEMCACHE_IP, int.Parse(memcache_server.MEMCACHE_PORT_ToString));
                        StatsType = "Redis.RedisStats";
                    }
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                }
                if (bRefresh == false)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "Business." + StatsType + ".Refresh(" + memcache_server.MEMCACHE_IP + "," + memcache_server.MEMCACHE_PORT_ToString + ")失败!");
                    #region 发邮件给负责人
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
</head><body><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Memcache/Memcache_Stats.aspx\"" + @">点击此处查看详情</a><div class=" + "\"" + @"div_tooltip" + "\">" +
                    @"<p><b>服务器IP</b> ： " + memcache_server.MEMCACHE_IP +
                     @"<br/><b>端口PORT</b> ： " + memcache_server.MEMCACHE_PORT_ToString +
                     @"<br/><b>缓存类型</b> ： " + (memcache_server.CACHETYPE_ToString == "0" ? "Memcached" : "Redis") +
                     @"<br/>---------------------------------------------------------------</p>" +
                     "<b>描    述</b> ： <p>连接失败！可能服务停止或者服务不可用，请立刻检查。</p></div><p>---------------------------------------------------------------</p></body></html>";


                    string MailUserList = Business.WebManager.OnLineUser.GetWebmanagerEmails(30, 1);

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailTitle = memcache_server.MEMCACHE_IP + ":" + memcache_server.MEMCACHE_PORT_ToString + "," + (memcache_server.CACHETYPE_ToString == "0" ? "Memcached" : "Redis") + "服务不可用,请及时处理[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                    mail.MailContent = body;
                    mail.MailUserList = MailUserList;
                    if (!mail.SendOneMailByHTML())
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "报错邮件发给“" + MailUserList + "”失败！");
                        Business.MallLog.Create(0, "AutoRunJob.MemcachedController", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                    }
                    #endregion
                }
                else
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "Business." + StatsType + ".Refresh(" + memcache_server.MEMCACHE_IP + "," + memcache_server.MEMCACHE_PORT_ToString + ")成功!");
                }
                #endregion
                #region 超过24小时则在5点后回收Memcache缓存一次
                if (memcache_server.CACHETYPE_ToString == "0" && DateTime.Parse(memcache_server.RESETTIME_ToString) < System.DateTime.Now.AddDays(-1) && DateTime.Now.Hour >= 5)
                {
                    Com.Net.TelnetUtil telnet = new Com.Net.TelnetUtil(memcache_server.MEMCACHE_IP, int.Parse(memcache_server.MEMCACHE_PORT_ToString), 30);
                    if (telnet.Connect() == true)
                    {
                        //等待指定字符返回后才执行下一命令 
                        telnet.Send("flush_all");
                        telnet.WaitFor("OK");
                        string data = telnet.WorkingData;
                        if (data.IndexOf("OK") > -1)
                        {
                            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server_update = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                            memcache_server_update.MEMCACHE_IP = memcache_server.MEMCACHE_IP;
                            memcache_server_update.MEMCACHE_PORT = int.Parse(memcache_server.MEMCACHE_PORT_ToString);
                            memcache_server_update.RESETTIME = System.DateTime.Now;
                            memcache_server_update.Update();
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "回收Memcached " + memcache_server.MEMCACHE_IP + ":" + memcache_server.MEMCACHE_PORT_ToString + " 成功！");
                        }
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 检查局域网内所有可用的memcahce端口
        /// </summary>
        public static void GetMemcachePort()
        {
            if (GetMemcachePortDate.IndexOf(DateTime.Now.ToShortDateString()) == -1)
            {
                GetMemcachePortDate += DateTime.Now.ToShortDateString() + ";";

                //获取本地机器名 
                string _myHostName = Dns.GetHostName();
                //获取本机
                string _myHostIP = Dns.GetHostEntry(_myHostName).AddressList[1].ToString();
                string[] ips = _myHostIP.Split('.');
                string MyIpDuan = ips[0] + "." + ips[1] + ".";
                //截取IP网段
                string[] ipDuans = new string[] { 
                MyIpDuan + "." + ips[2],
                MyIpDuan + "." + (int.Parse(ips[2]) + 1).ToString(), 
                MyIpDuan + "." + (int.Parse(ips[2]) -1).ToString()
                };//我的IP段+1或者-1
                foreach (string ipDuan in ipDuans)
                {
                    for (int i = 1; i <= 255; i++)
                    {
                        #region  枚举网段计算机
                        string ip = ipDuan + "." + i.ToString();
                        int port = 11211;
                        Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server_select = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                        memcache_server_select.MEMCACHE_IP = ip;
                        memcache_server_select.MEMCACHE_PORT = port;
                        if (memcache_server_select.SelectTop1() == null)
                        {
                            Com.Net.TelnetUtil telnet = new Com.Net.TelnetUtil(ip, port, 30);
                            if (telnet.Connect() == true)
                            {
                                //等待指定字符返回后才执行下一命令 
                                telnet.Send("stats");
                                telnet.WaitFor("END");
                                string data = telnet.WorkingData;
                                if (data.ToLower().IndexOf("limit_maxbytes") > -1)
                                {
                                    Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server_top1 = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                                    memcache_server_top1.CacheTime = 60;
                                    memcache_server_top1.SelectTop1();

                                    Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                                    memcache_server.MEMCACHE_IP = ip;
                                    memcache_server.MEMCACHE_PORT = port;
                                    memcache_server.MEMCACHE_LOCAL_IP = ip;
                                    memcache_server.ERROR_KEY = memcache_server_top1.ERROR_KEY;
                                    memcache_server.Insert();
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
        }
    }
}
