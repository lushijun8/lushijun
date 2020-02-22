using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Net;
using System.Diagnostics;
namespace TeamToolTask
{
    class App
    {
        private static string RunType = Com.Config.ConfigUtil.GetValueFromWebConfig("RunType");
        private static string Local = Com.Config.ConfigUtil.GetValueFromWebConfig("Local");
        private static int PauseMilliSecond = int.Parse(Com.Config.ConfigUtil.GetValueFromWebConfig("PauseMilliSecond"));
        #region
        private static string[] ContractNos = new string[] { 
"1NR(YRJK55)GL20171100024"
};

        private static string[] ContractUrls = new string[] { 
"http://img11.soufunimg.com/xfbang/2017_11/14/M16/15/09/ChCE4FoKW6qIX0edABxgf2gT9BwAA2e_gBcV3wAHGCX237.jpg"
        };
        #endregion
        static void Main(string[] args)
        {
            Log.WriteLog("\r\n" + DateTime.Now.ToString() + "此程序是定时发报错信息，不能关闭！！！！！！");
            long loop = 0;
            //while (1 == 1)
            {
                //loop++;
                try
                {

                    string today = DateTime.Now.ToShortDateString();
                    string tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
                    string yestoday = DateTime.Now.AddDays(-1).ToShortDateString();

                    if (Local == "1" || Local == "")//是否需要在本地运行
                    {
                        SvnController.NewCommitLog();//抓取SVN的Commit日志
                        SvnController.UpdateLastCommitLog();//监控SVN的每个目录最新Commit信息
                        MemcachedController.MemcacheStats("10.2.");//监控memcache
                    }
                    if (Local == "0" || Local == "")
                    {
                        ErrorController.SendEmail();//发报错邮件
                        if (System.DateTime.Now.Hour == 2)//每天凌晨2点同步前一天正式库的sql
                        {
                            SqlSyncController.OnLineSqlSync();
                        }
                        if (System.DateTime.Now.Hour > 5)//因为正式库的sql凌晨才同步，需要计算sql_md5,花费将近2个小时，所以等计算完再同步
                        {
                            //SqlController.DataBase_Sql("channelsales_test", "'channelsales_test','tuan_test'");//同步抓到的SQL
                        }
                        SqlController.DataBase_Sql_Stats(today, tomorrow);//进行今天的SQL统计
                        SqlController.DataBase_Sql_Stats(yestoday, today);//进行昨天的SQL统计
                        SqlController.DataBase_Sql_Analysis();//分析sql
                        //SqlMatchController.FindSeemLikeWebmanager();//对分析结果进行疑似匹配
                        if (loop % 3 == 0)
                        {
                            DependController.PageUrl_Depend("124.251.44.244_channelsales_stats_DataBaseInstance");//外部依赖的URL匹配
                            //Business.Sql.SendSlowSqlEmail.Run();
                            //Business.Sql.SendLackWithNoLockSqlEmail.Run();
                            //Business.Sql.SendWrongDataBaseUserEmail.Run();
                        }
                        if (loop % 5 == 0)
                        {
                            //PageUrlMatchController.Sync();//匹配PageUrl负责人
                            /*
                            string ConfigFilePath = "";
                            if (Com.File.FileUtil.FileExists("dataconfiguration.config") == true)
                            {
                                ConfigFilePath = "dataconfiguration.config";
                            }
                            else
                            {
                                ConfigFilePath = "D:\\inetpub\\TeamTool\\Web\\ConfigFile\\dataconfiguration.config";
                            }
                            Business.DataConfiguration.InitConfig.UpdateConfig(ConfigFilePath); //固化数据库配置
                             * */
                            //DataBaseUserController.Monitor();//监控数据库用户授予权限
                        }
                        //if (System.DateTime.Now.Hour == 12)
                        //{
                        //    MemcachedController.GetMemcachePort();//扫描最近网段的memcached可用端口,一天扫描一次
                        //}
                        if (System.DateTime.Now.Hour == 1)
                        {
                            //DataBaseTableController.Monitor();//每天检查一次数据库表的情况
                        }
                        //JobDataBaseController.Monitor();//数据库作业监控
                        //IndexController.Monitor();//监控现有索引
                        ServerController.Sync();
                        JobWindowsController.Sync();//监控windows作业的执行情况
                        MemcachedController.MemcacheStats("124.");//监控memcache
                        //MissingIndexController.Monitor();//扫描索引缺失情况。
                        SqlExecuteLogController.SyncSqlExecuteLog();//分析数据库连接记录
                    }

                }
                catch (Exception err)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "AutoRunJob执行失败-" + err.ToString());

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailTitle = "AutoRunJo执行失败" + DateTime.Now.ToString();
                    mail.MailContent = err.ToString();
                    mail.MailUserList = "lushijun@fang.com";
                    if (!mail.SendOneMailByHTML())
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "报错邮件发给 lushijun@fang.com失败！");
                    }
                    //Thread.Sleep(1800000);//30分钟 
                }
                //Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "，暂停" + PauseMilliSecond / 1000 + "秒再执行第" + loop.ToString() + "轮更新！");
                //Thread.Sleep(PauseMilliSecond);//15分钟 
                //System.GC.Collect();
            }
        }
        static void download()
        {
            for (int i = 0; i < ContractNos.Length; i++)
            {
                Log.WriteLog("\r\n" + DateTime.Now.ToString() + "开始下载第 " + i + "/" + ContractNos.Length + " 个合同附件！");
                if (!string.IsNullOrEmpty(ContractNos[i]))
                {
                    string[] urls = ContractUrls[i].Split(';');
                    for (int j = 0; j < urls.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(urls[j]))
                        {
                            string imagetype = "";
                            string filename = @"D:\Contract\" + ContractNos[i];
                            if (j > 0)
                            {
                                filename += "-" + j + "";
                            }
                            string[] imgs = urls[j].Split('.');
                            filename += "." + imgs[imgs.Length - 1];
                            Com.Net.Image.SavePhotoFromUrl(filename, urls[j], out imagetype);
                        }
                    }
                }
            }

        }
        static void ReplaceName()
        {
            DirectoryInfo theFolder = new DirectoryInfo(@"G:\mp3\");
            FileInfo[] fileInfo = theFolder.GetFiles("*.mp3", SearchOption.AllDirectories);
            foreach (FileInfo NextFile in fileInfo)  //遍历文件
            {
                try
                {
                    System.IO.File.Move(NextFile.FullName, NextFile.FullName.Replace("[mqms2]", "").Replace(" ", "").Replace("MP3", "mp3"));
                }
                catch
                {

                }
                //NextFile.MoveTo(NextFile.DirectoryName + "\\"+NextFile.Name.Replace(NextFile.Extension,"")+".mp3" );
            }

        }
    }
}
