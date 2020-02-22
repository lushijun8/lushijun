using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;
namespace ProcessManager
{
    class Program
    {
        public static bool ConnectionString_SetConfig = SetConnectionStringConfig();//动态的设置App.Config里原来的连接串（只是修改了内存里的config配置，不会实际修改文件）
        /// <summary>
        /// 动态的设置App.Config里原来的连接串（只是修改了内存里的config配置，不会实际修改文件）
        /// </summary>
        /// <returns></returns>
        public static bool SetConnectionStringConfig()
        {
            #region 获取数据库连接串配置文件的json内容
            string cfgfiles = SoufunLab.Framework.Configuration.SlConfig.GetValue<string>("cfgfiles");//获取数据库连接串的json配置文件路径
            if (!System.IO.Path.IsPathRooted(cfgfiles))
            {
                //如果不是物理路径，则转换成物理路径，因为有的配置需要写成虚拟路径
                cfgfiles = System.IO.Path.GetFullPath(cfgfiles);
            }
            string jsonText = "";
            if (System.IO.File.Exists(cfgfiles))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(cfgfiles, System.Text.Encoding.Default);
                jsonText = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            #endregion
            if (!string.IsNullOrEmpty(jsonText))
            {
                Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
                foreach (Newtonsoft.Json.Linq.JProperty jo in (Newtonsoft.Json.Linq.JToken)jobject)
                {
                    #region 将所有的配置全部反写到App.Config或者Web.Config内存文件中，这样就省去了一个个的单独读取了，更加简洁了（只是修改了内存，不会实际修改文件）

                    string ConnectionString_Format_Mysql = "Server={DBaddr};port={DBport};database={DBname};uid={DBusername};pwd={DBpw};";//mysql的端口号用分号隔开
                    string ConnectionString_Format_MSsql = "server={DBaddr},{DBport};database={DBname};user id={DBusername};pwd={DBpw};"; //sqlserver的端口号用逗号隔开
                    string ConnectionString = ConnectionString_Format_MSsql;
                    string DBtype = jo.Value["DBtype"].ToString().ToLower();
                    string DBusername = jo.Value["DBusername"].ToString().ToLower();
                    if (DBtype == "mssql")
                    {
                        ConnectionString = ConnectionString_Format_MSsql;
                    }
                    else if (DBtype == "mysql")
                    {
                        ConnectionString = ConnectionString_Format_Mysql;
                    }
                    Newtonsoft.Json.Linq.JToken jobject1 = (Newtonsoft.Json.Linq.JToken)Newtonsoft.Json.JsonConvert.DeserializeObject(jobject[jo.Name].ToString());
                    foreach (Newtonsoft.Json.Linq.JProperty jo1 in jobject1)
                    {
                        ConnectionString = System.Text.RegularExpressions.Regex.Replace(ConnectionString, "{" + jo1.Name + "}", jo1.Value.ToString().TrimEnd('"').TrimStart('"'), System.Text.RegularExpressions.RegexOptions.IgnoreCase);//不区分大小写就能替换
                    }
                    System.Configuration.ConfigurationSettings.AppSettings.Set(jo.Name, ConnectionString);
                    #endregion
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            //获取本地机器名 
            string _myHostName = Dns.GetHostName();
            //获取本机
            string _myHostIP = Dns.GetHostEntry(_myHostName).AddressList[1].ToString();
            string ConfigFile = System.IO.Path.GetFullPath(".\\Config.txt");
            DateTime LastAlertTime = DateTime.Parse("1900-01-01");
            while (1 == 1)//一直运行
            {
                Thread.Sleep(10000);
                if (!File.Exists(ConfigFile))
                {
                    Com.File.FileUtil.FileCreate(ConfigFile, 0);
                }
                if (File.Exists(ConfigFile))
                {
                    string Content = Com.File.FileUtil.GetFileContent(ConfigFile);
                    if (!string.IsNullOrEmpty(Content))
                    {
                        //string[] Params = Content.Split(',');
                        if (Content == "0" || Content == "1")
                        {
                            string ProcessPath = Config.TuanTaskAutoRun_Path + "TuanTaskAutoRun.exe";
                            if (Content == "0")
                            {
                                #region 杀死进程
                                string error = "";
                                string[] paths = ProcessPath.Replace("/", "\\").Split('\\');
                                string ProcessName = paths[paths.Length - 1].ToLower().Replace(".exe", "");

                                Process[] allProcess = Process.GetProcessesByName(ProcessName);
                                bool bResult = true;
                                foreach (Process process in allProcess)
                                {
                                    try
                                    {
                                        if (ProcessPath.ToLower() == process.MainModule.FileName.ToLower())//已经有在执行的程序
                                        {
                                            process.Kill();
                                            bResult = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        bResult = false;
                                        error = ex.Message;
                                    }
                                }
                                if (bResult == true)
                                {
                                    Log.WriteLog("杀死了进程" + ProcessPath);
                                }
                                else
                                {
                                    Log.WriteLog("杀死进程" + ProcessPath + "失败," + error);
                                }
                                #endregion
                            }
                            else if (Content == "1")
                            {
                                #region 开启进程
                                string error = "";
                                bool bResult = false;
                                try
                                {
                                    Process process = new Process();
                                    ProcessStartInfo info = new ProcessStartInfo
                                    {
                                        FileName = ProcessPath,
                                        CreateNoWindow = true,
                                        UseShellExecute = false,
                                        RedirectStandardOutput = true,
                                        Arguments = "0"
                                    };

                                    var folderPath = ProcessPath.Substring(0, ProcessPath.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                                    if (Directory.Exists(folderPath))
                                    {
                                        info.WorkingDirectory = folderPath;
                                    }
                                    process.StartInfo = info;
                                    process.Start();
                                    bResult = true;
                                }
                                catch (Exception ex)
                                {
                                    bResult = false;
                                    error = ex.Message;
                                }
                                if (bResult == true)
                                {
                                    Log.WriteLog("开启了进程" + ProcessPath);
                                }
                                else
                                {
                                    Log.WriteLog("开启进程" + ProcessPath + "失败," + error);
                                }
                                #endregion
                            }
                            Com.File.FileUtil.WriteFileContent(ConfigFile, "");
                        }
                    }
                }
                #region 监控总管程序是否正常，如果不正常则发报警邮件和报警短信
                if (System.IO.Directory.Exists(Config.TuanTaskAutoRun_Path))//如果是目录
                {
                    string[] files_txt = System.IO.Directory.GetFiles(Config.TuanTaskAutoRun_Path, "*.txt", SearchOption.AllDirectories);
                    string[] files_log = System.IO.Directory.GetFiles(Config.TuanTaskAutoRun_Path, "*.log", SearchOption.AllDirectories);
                    string[] files = new string[files_txt.Length + files_log.Length];
                    if (files != null && files.Length > 0)
                    {
                        int i = 0;
                        if (files_txt != null && files_txt.Length > 0)
                        {
                            foreach (string file in files_txt)
                            {
                                files[i] = file;
                                i++;
                            }
                        }
                        if (files_log != null && files_log.Length > 0)
                        {
                            foreach (string file in files_log)
                            {
                                files[i] = file;
                                i++;
                            }
                        }
                    }
                    if (files.Length > 0)
                    {
                        System.IO.FileInfo fileinfo0 = new FileInfo(files[0]);
                        DateTime LastWriteTime = fileinfo0.LastWriteTime;
                        foreach (string file in files)
                        {
                            if (!string.IsNullOrEmpty(file))
                            {
                                System.IO.FileInfo fileinfo = new FileInfo(file);
                                if (fileinfo.LastWriteTime > LastWriteTime)
                                {
                                    LastWriteTime = fileinfo.LastWriteTime;
                                }
                            }
                        }
                        int AlertIntervalTime = 5;
                        if (!string.IsNullOrEmpty(Config.AlertIntervalTime))
                        {
                            try
                            {
                                AlertIntervalTime = int.Parse(Config.AlertIntervalTime);
                            }
                            catch { }
                        }

                        if (LastWriteTime.AddMinutes(AlertIntervalTime) <= DateTime.Now)
                        {
                            if (LastAlertTime.AddMinutes(AlertIntervalTime) < DateTime.Now)
                            {
                                #region 如果超过5分钟没有更新日志则进行报警
                                try
                                {
                                    if (!string.IsNullOrEmpty(Config.Manager_Mobile))
                                    {
                                        string[] Manager_Mobiles = Config.Manager_Mobile.Split(',');
                                        foreach (string Manager_Mobile in Manager_Mobiles)
                                        {
                                            if (!string.IsNullOrEmpty(Manager_Mobile))
                                            {
                                                string sql = "exec [serv_sms_send].northwind.dbo.csp_add_sms_mobie '" + Manager_Mobile + "','" + _myHostIP + " " + Config.TuanTaskAutoRun_Path + "TuanTaskAutoRun.exe异常';";
                                                SoufunLab.Framework.Data.SlDatabase.ExecuteNonQuery(Config.ConnectionString_Channelsales_Admin, sql);
                                            }
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(Config.Manager_Email))
                                    {
                                        Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                                        mail.MailTitle = "" + _myHostIP + " " + Config.TuanTaskAutoRun_Path + "TuanTaskAutoRun.exe异常";
                                        mail.MailUserList = Config.Manager_Email;
                                        mail.MailContent = "" + _myHostIP + " " + Config.TuanTaskAutoRun_Path + "TuanTaskAutoRun.exe异常,最后执行时间" + LastWriteTime.ToString() + "，请检查！";
                                        if (!mail.SendOneMailByHTML())
                                        {
                                            Log.WriteLog("发送邮件失败！");
                                        }
                                    }
                                    LastAlertTime = DateTime.Now;
                                }
                                catch (Exception ex)
                                {
                                    Log.WriteLog(ex.Message);
                                }
                                #endregion
                            }
                        }
                    }
                }
                #endregion
            }
        }
    }
}
