using System;
using System.Text;
using Com.Config;

namespace Com.File
{
    /// <summary>
    /// FileLog 的摘要说明。
    /// </summary>
    public class FileLog //: System.Web.UI.Page
    {
        public FileLog()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string GetBasePath()
        {
            return (SystemConfig.LogFilePath + @"\");
        }

        public static string GetLogFileName()
        {
            return FileLog.GetLogFileName(DateTime.Today);
        }

        public static string GetLogFileName(DateTime oDate)
        {
            string text1 = oDate.ToShortDateString();
            return (FileLog.GetBasePath() + @"Log\Log" + text1 + ".log");
        }

        public static string GetPath(int i, int n, string strSplit)
        {
            if (n > 1)
            {
                return (FileLog.GetPath(i / 100, n - 1, strSplit) + FileLog.GetPath(i % 100, 1, strSplit));
            }
            if (i < 10)
            {
                return ("0" + i + strSplit);
            }
            if (i < 100)
            {
                return ("" + i + strSplit);
            }
            return FileLog.GetPath(i % 100, 1, strSplit);
        }

        public static int WriteLog(string strErrPos, string strErrInfo)
        {
            return FileLog.WriteLog(strErrPos, strErrInfo, "");
        }
        public int WriteLogs(string strErrPos, string strErrInfo, string strErrReason)
        {
            int Value;
            try
            {
                StringBuilder builder1 = new StringBuilder();
                builder1.Append("-----------------时间:" + DateTime.Now.ToString() + "----------------\r\n");
                builder1.Append("\u4f4d\u7f6e\uff1a" + strErrPos + "\r\n");
                builder1.Append("\u5185\u5bb9\uff1a" + strErrInfo + "\r\n");
                if (strErrReason != "")
                {
                    builder1.Append("\u539f\u56e0\uff1a" + strErrReason + "\r\n");
                }
                builder1.Append("--------------------------结束-----------------------------\r\n");
                if (Com.Config.SystemConfig.LogFilePath != "") //安全日志路径为空时不写日志
                {
                    FileUtil.AppendFileContent(FileLog.GetLogFileName(), builder1.ToString());
                }
                else
                {
                }
                Value = 1;
            }
            catch (Exception)
            {
                Value = 0;
            }
            return Value;
        }
        public static int WriteLog(string strErrPos, string strErrInfo, string strErrReason)
        {
            int Value;
            FileLog oFileLog = new FileLog();
            Value = oFileLog.WriteLogs(strErrPos, strErrInfo, strErrReason);
            return Value;
        }
    }
}
