using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Config
    {
        public static string HostUrl = System.Configuration.ConfigurationManager.AppSettings["HostUrl"].ToString();
        public static string ResourcePath = System.Configuration.ConfigurationManager.AppSettings["ResourcePath"].ToString();
        public static string Version = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
    }
}
