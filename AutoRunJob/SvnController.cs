using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class SvnController
    {
        private delegate void MyDelegate(string path);

        #region 更新目录最新日志
        public static void UpdateCommitLog()
        {
            string FileName = System.Environment.CurrentDirectory + "\\svnlog.txt";
            string svn_logtext = Com.File.FileUtil.GetFileContent(FileName).Replace("\r\n", "\n");
            Com.File.FileUtil.WriteFileContent(FileName, "", "GB2312", false);

            string[] Commit_logs = svn_logtext.Split(new string[] { "Revision:" }, StringSplitOptions.None);

            foreach (string Commit_log in Commit_logs)
            {
                if (!string.IsNullOrEmpty(Commit_log))
                {
                    #region 获取各个字段值
                    string Commit_log_new = "Revision:" + Commit_log;
                    string[] items = Commit_log_new.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string Revision = items[0].Split(':')[1].TrimStart();
                    string Author = items[1].Split(':')[1].TrimStart();
                    DateTime Date = DateTime.Parse(items[2].Replace("Date: ", ""));
                    int start_index = Commit_log_new.IndexOf("Message:\n");
                    int end_index = Commit_log_new.IndexOf("----");
                    string Message = Commit_log_new.Substring(start_index + 8, end_index - start_index - 8).Replace("\n", "");
                    string[] commit_files = Commit_log_new.Split(new string[] { "----\n" }, StringSplitOptions.None)[1].Split(new string[] { "\n" }, StringSplitOptions.None);
                    #endregion

                    foreach (string commit_file in commit_files)
                    {
                        if (!string.IsNullOrEmpty(commit_file))
                        {
                            #region  添加记录
                            string[] files = commit_file.Split(':');

                            int Commit_type = 0;
                            string commit_type = files[0].Trim().ToLower();
                            string file = files[1].Trim();
                            if (commit_type == "added")
                            {
                                Commit_type = 0;
                            }
                            else if (commit_type == "modified")
                            {
                                Commit_type = 1;
                            }
                            else if (commit_type == "deleted")
                            {
                                Commit_type = 2;
                            }
                            else if (commit_type == "replacing")
                            {
                                Commit_type = 3;
                            }

                            Entity.TEAMTOOL.SVN_LOG svn_log = new Entity.TEAMTOOL.SVN_LOG();
                            svn_log.REVISION = long.Parse(Revision);
                            svn_log.WEBMANAGER_NAME = Author;
                            svn_log.COMMIT_SERVER = "svn://192.168.5.215:2002";
                            svn_log.COMMIT_TYPE = Commit_type;
                            svn_log.COMMIT_FILE_MD5 = Com.Common.EncDec.PasswordEncrypto(file);
                            svn_log.COMMIT_FILE = file;
                            svn_log.COMMIT_TIME = Date;
                            svn_log.COMMIT_MESSAGE = Message;
                            svn_log.CREATETIME = DateTime.Now;
                            if (!svn_log.Insert())
                            {
                                Log.WriteLog("\r\n" + DateTime.Now.ToString() + "svn_log.Insert()失败！Revision=" + Revision);
                            }
                            #endregion
                        }
                    }
                }
            }

        }
        public static void UpdateLastCommitLog()
        {
            Entity.TEAMTOOL.SVN_LOG_LASTUPDATE svn_log_lastupdate = new Entity.TEAMTOOL.SVN_LOG_LASTUPDATE();
            Entity.TEAMTOOL.SVN_LOG svn_log = new Entity.TEAMTOOL.SVN_LOG();
            svn_log.WhereSql = svn_log._COMMIT_TIME + ">(SELECT ISNULL(MAX(" + svn_log._COMMIT_TIME + "),'1900-1-1') FROM " + svn_log_lastupdate.TableName + ")";
            svn_log.OrderBy = svn_log._COMMIT_TIME + " ASC";
            DataTable oDt_svn_log = svn_log.Select();
            while (svn_log.Next())
            {
                string[] paths = svn_log.COMMIT_FILE.Split('/');
                string[] Commit_Files = new string[paths.Length - 1];
                for (int i = 1; i < paths.Length; i++)
                {
                    string Commit_File = "";
                    for (int j = 1; j <= i; j++)
                    {
                        Commit_File += "/" + paths[j];
                    }
                    Commit_Files[i - 1] = Commit_File;
                }
                foreach (string Commit_File in Commit_Files)
                {
                    if (!string.IsNullOrEmpty(Commit_File))
                    {
                        Entity.TEAMTOOL.SVN_LOG_LASTUPDATE svn_log_lastupdate_delete = new Entity.TEAMTOOL.SVN_LOG_LASTUPDATE();
                        svn_log_lastupdate_delete.COMMIT_FILE = Commit_File;
                        if (svn_log_lastupdate_delete.Delete() == true)
                        {

                            Entity.TEAMTOOL.SVN_LOG_LASTUPDATE svn_log_lastupdate_insert = new Entity.TEAMTOOL.SVN_LOG_LASTUPDATE();
                            svn_log_lastupdate_insert.COMMIT_FILE = Commit_File;
                            svn_log_lastupdate_insert.REVISION = long.Parse(svn_log.REVISION_ToString);
                            svn_log_lastupdate_insert.WEBMANAGER_NAME = svn_log.WEBMANAGER_NAME;
                            svn_log_lastupdate_insert.COMMIT_SERVER = svn_log.COMMIT_SERVER;
                            svn_log_lastupdate_insert.COMMIT_TYPE = int.Parse(svn_log.COMMIT_TYPE_ToString);
                            svn_log_lastupdate_insert.COMMIT_FILE_MD5 = svn_log.COMMIT_FILE_MD5;
                            svn_log_lastupdate_insert.COMMIT_TIME = DateTime.Parse(svn_log.COMMIT_TIME_ToString);
                            svn_log_lastupdate_insert.COMMIT_MESSAGE = svn_log.COMMIT_MESSAGE;
                            svn_log_lastupdate_insert.CREATETIME = System.DateTime.Now;
                            if (svn_log_lastupdate_insert.Insert() == true)
                            {
                                Log.WriteLog("\r\n" + DateTime.Now.ToString() + " svn_log_lastupdate_insert.Insert()成功！Commit_File=" + Commit_File);
                            }
                            else
                            {
                                Log.WriteLog("\r\n" + DateTime.Now.ToString() + " svn_log_lastupdate_insert.Insert()失败！Commit_File=" + Commit_File);
                            }
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + DateTime.Now.ToString() + " svn_log_lastupdate_delete.Delete()失败！Commit_File=" + Commit_File);
                        }
                    }
                }
            }
        }
        #endregion

        #region 历史日志
        public static void HistoryCommitLog()
        {
            Entity.TEAMTOOL.SVN_LOG_LASTUPDATE svn_log_lastupdate = new Entity.TEAMTOOL.SVN_LOG_LASTUPDATE();
            svn_log_lastupdate.TruncateTable();
            HistoryCommitLog("/tech");
        }
        private static void HistoryCommitLog(string path)
        {
            #region  LastCommitLog
            Entity.TEAMTOOL.SVN_LOG_LASTUPDATE svn_log_lastupdate = new Entity.TEAMTOOL.SVN_LOG_LASTUPDATE();
            DataTable oDt_svn_log_lastupdate = svn_log_lastupdate.Database_Writer.ExecuteDataSet(CommandType.Text, @"
declare @path varchar(1000);
declare @len int;
SET @path = '" + path + @"';
SET @len = LEN(@path) + 1;

SELECT TOP 1000
	@path + SUBSTRING(Commit_File + '/', @len, CHARINDEX('/', REPLACE(Commit_File, @path + '/', '') + '/')) AS Commit_File_max,
	MAX(Revision) AS Revision_max,
	MAX(Commit_Time) AS Commit_Time_max INTO #temp
FROM SVN_Log WITH(NOLOCK)
WHERE Commit_File LIKE @path + '/%'
GROUP BY @path + SUBSTRING(Commit_File + '/', @len, CHARINDEX('/', REPLACE(Commit_File, @path + '/', '') + '/'))
ORDER BY Commit_Time_max DESC
----------------------------------------------------------------------------------------------------------
SELECT
	#temp.Commit_File_max AS Commit_File,
	#temp.Revision_max AS Revision,
	MAX(SVN_Log.WebManager_Name) AS WebManager_Name,
	MAX(SVN_Log.Commit_Server) AS Commit_Server,
	MAX(SVN_Log.Commit_Type) AS Commit_Type,
	MAX(SVN_Log.Commit_File_Md5) AS Commit_File_Md5,
	#temp.Commit_Time_max AS Commit_Time,
	MAX(SVN_Log.Commit_Message) AS Commit_Message,
	GETDATE() as CreateTime 
	INTO #temp1
FROM #temp
LEFT JOIN SVN_Log WITH(NOLOCK)
	ON SVN_Log.Revision = #temp.Revision_max
GROUP BY	#temp.Commit_File_max,
			#temp.Revision_max,
			#temp.Commit_Time_max
ORDER BY Commit_Time_max DESC
----------------------------------------------------------------------------------------------------------
INSERT INTO SVN_Log_LastUpdate (Commit_File, Revision, WebManager_Name, Commit_Server, Commit_Type, Commit_File_Md5, Commit_Time, Commit_Message, CreateTime)
SELECT * FROM #temp1;
SELECT * FROM #temp1;

DROP TABLE #temp
DROP TABLE #temp1").Tables[0];
            if (oDt_svn_log_lastupdate.Rows.Count > 0)
            {
                foreach (DataRow oDr_svn_log_lastupdate in oDt_svn_log_lastupdate.Rows)
                {
                    MyDelegate caller = new MyDelegate(HistoryCommitLog);
                    caller.BeginInvoke(oDr_svn_log_lastupdate["Commit_File"].ToString(), null, caller);
                }
            }
            #endregion
        }
        #endregion

        #region 更新日常的Commit日志
        public static void NewCommitLog()
        {
            Entity.TEAMTOOL.SVN_LOG svn_log_max_commit_time = new Entity.TEAMTOOL.SVN_LOG();
            svn_log_max_commit_time.SelectColumns = new string[] { "MAX(ISNULL(" + svn_log_max_commit_time._COMMIT_TIME + ",'1900-1-1')) AS " + svn_log_max_commit_time._COMMIT_TIME };
            svn_log_max_commit_time.SelectTop1();

            string str = "svn log D:\\inetpub\\交易研发中心 -r {" + DateTime.Parse(svn_log_max_commit_time.COMMIT_TIME_ToString).AddSeconds(-20).ToString("yyyy-MM-ddTHH:mm:ss") + "}:{" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ss") + "} -v";

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令


            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            string[] Commit_logs = output.Split(new string[] { "------------------------------------------------------------------------" }, StringSplitOptions.None);
            for (int i = 1; i < Commit_logs.Length - 1; i++)
            {
                //"\r\nr133625 | luyujie | 2016-12-12 10:50:29 +0800 (周一, 12 十二月 2016) | 1 line\r\nChanged paths:\r\n   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Common/SubsidyAuditHelper.cs\r\n\r\n首页推送消息接口修复\r\n"

                string Commit_log = Commit_logs[i];
                if (!string.IsNullOrEmpty(Commit_log))
                {
                    #region 获取各个字段值
                    string[] items = Commit_log.Split(new string[] { "\r\nChanged paths:\r\n" }, StringSplitOptions.None);
                    string[] item0s = items[0].Split('|');

                    string Revision = item0s[0].Replace("r", "").Trim();
                    string Author = item0s[1].Trim();
                    DateTime Date = DateTime.Parse(item0s[2].Split('+')[0]);

                    int start_index = items[1].IndexOf("\r\n\r\n");
                    string Message = items[1].Substring(start_index + 4).Replace("\r\n", "");

                    string[] commit_files = items[1].Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)[0].Split(new string[] { "\n" }, StringSplitOptions.None);
                    #endregion

                    foreach (string commit_file in commit_files)
                    {
                        if (!string.IsNullOrEmpty(commit_file))
                        {
                            #region  添加记录
                            string[] files = commit_file.Trim().Split(' ');

                            int Commit_type = 0;
                            string commit_type = files[0].Trim().ToLower();
                            string file = files[1].Trim();
                            if (commit_type == "a")
                            {
                                Commit_type = 0;
                            }
                            else if (commit_type == "m")
                            {
                                Commit_type = 1;
                            }
                            else if (commit_type == "d")
                            {
                                Commit_type = 2;
                            }
                            else if (commit_type == "r")
                            {
                                Commit_type = 3;
                            }

                            Entity.TEAMTOOL.SVN_LOG svn_log = new Entity.TEAMTOOL.SVN_LOG();
                            svn_log.REVISION = long.Parse(Revision);
                            svn_log.WEBMANAGER_NAME = Author;
                            svn_log.COMMIT_SERVER = "svn://192.168.5.215:2002";
                            svn_log.COMMIT_TYPE = Commit_type;
                            svn_log.COMMIT_FILE_MD5 = Com.Common.EncDec.PasswordEncrypto(file);
                            svn_log.COMMIT_FILE = file;
                            svn_log.COMMIT_TIME = Date;
                            svn_log.COMMIT_MESSAGE = Message;
                            svn_log.CREATETIME = DateTime.Now;
                            if (!svn_log.Insert())
                            {
                                Log.WriteLog("\r\n" + DateTime.Now.ToString() + "svn_log.Insert()失败！Revision=" + Revision);
                            }
                            #endregion
                        }
                    }
                }
                //------------------------------------------------------------------------
                //r133613 | wangyantao | 2016-12-12 10:28:07 +0800 (周一, 12 十二月 2016) | 1 line
                //Changed paths:
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/EfficiencyAnalysisController.cs
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Temp/Business/UserIndexController.cs

                //添加项目审核待申请
                //------------------------------------------------------------------------
                //r133616 | wangyantao | 2016-12-12 10:36:33 +0800 (周一, 12 十二月 2016) | 1 line
                //Changed paths:
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/PotentialDianshangProjController.cs
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/PurposeStatisticsController.cs
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/StatisticsOnCityAndRoleAndNameController.cs
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/StatisticsOnCityAndTeamAndDayController.cs
                //   M /tech/Mix/交易研发中心/ECChannelStatistics/ECChannelStatistics/Controllers/Business/StatisticsOnCityAndTeamAndSellerController.cs

                //添加行为记录特性
                //------------------------------------------------------------------------
            }
        }
        #endregion

    }
}
