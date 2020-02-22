using System;
using System.Net;
using System.IO;
using System.Web;
using System.Data;
using System.Xml;
namespace Business
{
    /// <summary>
    /// 从网络获取资源(Html代码和图片)
    /// </summary>
    public class Net
    {
        /// <summary>
        /// 从网络获取资源(Html代码和图片)
        /// </summary>
        public Net() { }

        /// <summary>
        /// 获得解析过的网页文件的Html代码
        /// </summary>
        /// <param name="url">网络绝对网址, 如http://www.abc.com/index.htm </param>
        /// <returns>解析过的网页文件的Html代码</returns>
        public static string ScreenScraper(string url)
        {
            string result;
            WebResponse myResponse;
            WebRequest myRequest = HttpWebRequest.Create(url);
            myResponse = myRequest.GetResponse();
            using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.Default))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            myResponse.Close();
            return result;
        }

       
        //获取客户端IP地址
        public static string GetCurrentUserCilentIp()
        {
            string _UserCilentIp = "";

            HttpContext currentPage = HttpContext.Current;
            if (currentPage.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                _UserCilentIp = currentPage.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Trim();
            }
            if (_UserCilentIp.Length == 0)
            {
                _UserCilentIp = currentPage.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (_UserCilentIp.IndexOf(",") > -1)
            {
                string[] tempIp = _UserCilentIp.Split(',');
				_UserCilentIp = tempIp[0].Trim();
            }
            try
            {
                System.Net.IPAddress.Parse(_UserCilentIp);
            }
            catch
            {
                _UserCilentIp = "127.0.0.1";
            }
            return _UserCilentIp;
        }
        //获得客户端 UserAgent
        public static string GetUserCilentUserAgent()
        {
            HttpContext currentPage = HttpContext.Current;
            return currentPage.Request.UserAgent;

        }

        //获取主机IP地址
        public static string GetServerIP()
        {
            string result="";
            IPAddress[] iPAddresses = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
            if (iPAddresses.Length > 0)
            {
                result = iPAddresses[0].ToString();
            }
            return result;
        }
        //判断是否浏览器客户
        public static bool IsUserCilentByBrowser()
        {
            bool flag = true;
            string UserAgentLower = "";
            UserAgentLower = GetUserCilentUserAgent();
            if (UserAgentLower == null)
            {
                return false;
            }
            else
            {
                UserAgentLower = UserAgentLower.ToLower();
            }
            foreach (string spider in GetSpiders())
            {
                if (UserAgentLower.IndexOf(spider) >= 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static String[] GetSpiders()
        {
            string SpidersStr = System.Configuration.ConfigurationManager.AppSettings["Spiders"];
            if (SpidersStr != null)
            {
                return SpidersStr.Split(',');
            }
            return null;
        }
        //站点域名 如  http://www.jiatx.com
        public static string DomainFull()
        {
            string domainFull = System.Configuration.ConfigurationManager.AppSettings["DomainFull"];
            if (domainFull == null)
                domainFull = "";
            return domainFull;
        }

        /// <summary>
        /// 读取HTTP XML
        /// </summary>
        /// <param name="URLpath"></param>
        /// <param name="en"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DataSet GetDSByXmlURL(string URLpath, System.Text.Encoding en, int timeout)
        {
            DataSet ds = new DataSet();
            WebRequest req = WebRequest.Create(URLpath);
            req.Timeout = timeout;
            WebResponse result;
            try
            {
                result = req.GetResponse();
            }
            catch 
            {
                return ds;
            }
            Stream ReceiveStream = result.GetResponseStream();
            StreamReader sr = new StreamReader(ReceiveStream, en);
            try
            {
                ds.ReadXml(sr, XmlReadMode.Auto);
            }
            catch { }
            ReceiveStream.Close();
            sr.Close();
            result.Close();
            return ds;
        }
        /// <summary>
        /// 读取HTTP XML
        /// </summary>
        /// <param name="URLpath"></param>
        /// <param name="en"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static Stream GetStreamByXmlURL(string URLpath, System.Text.Encoding en, int timeout)
        {
            Stream ReceiveStream;
            WebRequest req = WebRequest.Create(URLpath);
            req.Timeout = timeout;
            WebResponse result;
            try
            {
                result = req.GetResponse();
            }
            catch
            {
                return null;
            }
            ReceiveStream = result.GetResponseStream();
            return ReceiveStream;
        }
        /// <summary>
        /// 读取HTTP XML
        /// </summary>
        /// <param name="URLpath"></param>
        /// <param name="en"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static XmlDocument GetXDByXmlURL(string URLpath, System.Text.Encoding en, int timeout)
        {
            XmlDocument xml = new XmlDocument();            
            WebRequest req = WebRequest.Create(URLpath);
            req.Timeout = timeout;
            WebResponse result;
            try
            {
                result = req.GetResponse();
            }
            catch
            {
                return xml;
            }
            Stream ReceiveStream = result.GetResponseStream();
            xml.Load(ReceiveStream);
            ReceiveStream.Close();
            result.Close();
            return xml;
        } 
    }
}
