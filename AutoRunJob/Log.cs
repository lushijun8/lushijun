using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace TeamToolTask
{
    public class Log
    {
        // 文件名
        private static string logFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
        // 文件路径
        private static string logPathName = "log";

        private static void LogMethod(string message)
        {
            try
            {

                bool flag1 = Directory.Exists(logPathName);
                if (!flag1)
                {
                    Directory.CreateDirectory(logPathName);
                }
                StreamWriter sw = new StreamWriter(logPathName + "/" + logFileName, true, Encoding.Default);
                sw.WriteLine("时间:" + DateTime.Now.ToString().Trim() + "  记录:" + message);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }
        public static void WriteLog(string log)
        {
            LogMethod(log);
            Console.WriteLine(log);
        }
    }
}
