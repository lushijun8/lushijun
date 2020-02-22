using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoufunLab.Framework.Configuration;

namespace ProcessManager
{
    public class Config
    {
        public static string ConnectionString_Channelsales_Admin = SlConfig.GetValue<string>("ConnectionString_Channelsales_Admin");
        public static string TuanTaskAutoRun_Path = SlConfig.GetValue<string>("TuanTaskAutoRun_path");
        public static string Manager_Mobile = SlConfig.GetValue<string>("Manager_Mobile");
        public static string Manager_Email = SlConfig.GetValue<string>("Manager_Email");
        public static string AlertIntervalTime = SlConfig.GetValue<string>("AlertIntervalTime");
    }
}
