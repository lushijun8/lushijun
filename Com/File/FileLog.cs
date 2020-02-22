using System;
using System.Text;
using Com.Config;

namespace Com.File
{
    /// <summary>
    /// FileLog ��ժҪ˵����
    /// </summary>
    public class FileLog //: System.Web.UI.Page
    {
        public FileLog()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
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
                builder1.Append("-----------------ʱ��:" + DateTime.Now.ToString() + "----------------\r\n");
                builder1.Append("\u4f4d\u7f6e\uff1a" + strErrPos + "\r\n");
                builder1.Append("\u5185\u5bb9\uff1a" + strErrInfo + "\r\n");
                if (strErrReason != "")
                {
                    builder1.Append("\u539f\u56e0\uff1a" + strErrReason + "\r\n");
                }
                builder1.Append("--------------------------����-----------------------------\r\n");
                if (Com.Config.SystemConfig.LogFilePath != "") //��ȫ��־·��Ϊ��ʱ��д��־
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
