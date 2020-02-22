using System;
using System.Text;
using System.Net;
using System.Xml;
using System.Data;
using System.Collections.Specialized;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
namespace Com.Net
{
    public class UrlRequest
    {
		private static int DefaultTimeout = 12000;//毫秒为单位
        private static Encoding DefaultCoding = Encoding.GetEncoding("gb2312");

        private UrlRequest() { }

        #region 函数
        private static string Read(HttpWebRequest request, Encoding code)
		{
			string str = string.Empty;
			string error = request.Address.ToString();
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				error = response.ContentType + ";" + response.ResponseUri.AbsoluteUri + ";";
				if (response.StatusCode == HttpStatusCode.OK)
				{
					StreamReader reader = new StreamReader(Gzip(response), code);
					str = reader.ReadToEnd();
					reader.Close();
				}
				response.Close();
			}
			catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Net.UrlRequest.Read(HttpWebRequest request, Encoding code)", ex.ToString() + ";response:" + error);   
			}
			return str;
		}
        private static XmlDocument ReadXmlDocument(HttpWebRequest request)
		{
			XmlDocument doc = new XmlDocument();
			string error = request.Address.ToString();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                error = response.ContentType + ";" + response.ResponseUri.AbsoluteUri + ";";
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    doc.Load(Gzip(response));

                }
                response.Close();
            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Net.UrlRequest.ReadXmlDocument(HttpWebRequest request)", ex.ToString() + ";response:" + error);  
            }
			return doc;
		}
		private static Stream Gzip(HttpWebResponse response)
		{
			Stream stream1 = null;
			string encode = response.ContentEncoding;
			if (encode == "gzip")
			{
				stream1 = new GZipInputStream(response.GetResponseStream());
			}
			else if (encode == "deflate")
			{
				stream1 = new InflaterInputStream(response.GetResponseStream());
			}
			if (stream1 == null)
			{
				return response.GetResponseStream();
			}
			MemoryStream stream2 = new MemoryStream();
			int per = 0x800;
			int count = 0;
			byte[] buffer = new byte[0x800];
			do
			{
				count = stream1.Read(buffer, 0, per);
				stream2.Write(buffer, 0, count);
			}
			while (count >0);
			stream2.Seek((long)0, SeekOrigin.Begin);
			return stream2;
		}
        
        private static HttpWebRequest LoadRequest(string url, int timeout)
		{
            return LoadRequest(url, null, timeout);
		}
        private static HttpWebRequest LoadRequest(string url, string PostContent, int timeout)
        {
            return LoadRequest(url, PostContent, timeout, DefaultCoding);
        }
        private static HttpWebRequest LoadRequest(string url, string PostContent, Encoding encoding)
        {
            return LoadRequest(url, PostContent, DefaultTimeout, encoding);
        }
        private static HttpWebRequest LoadRequest(string url, string PostContent, int timeout,Encoding encoding)
        {
            HttpWebRequest request = null;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                if (string.IsNullOrEmpty(PostContent))
                {
                    request.Timeout = timeout;
                    request.AllowAutoRedirect = true;
                }
                else
                {
                    byte[] bt = encoding.GetBytes(PostContent);
                    int len = bt.Length;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.ContentLength = len;
                    Stream stream = request.GetRequestStream();
                    stream.Write(bt, 0, len);
                    stream.Close();
                }

            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Net.UrlRequest.LoadRequest(string url, string PostContent, int timeout,Encoding encoding)", ex.ToString() + ";URL=" + url);  
            }
            return request;
        }       

        public static XmlDocument LoadXmlDocument(string url, string PostContent, int timeout,Encoding encoding)
        {
            XmlDocument doc = new XmlDocument();
            HttpWebRequest request = LoadRequest(url, PostContent, timeout, encoding);
            doc = ReadXmlDocument(request);
            return doc;
        }
        #endregion

        #region 读取DataSet
        public static DataSet LoadDataSet(string url)
        {
            return LoadDataSet(url, null);
        }
        public static DataSet LoadDataSet(string url, string PostContent)
        {
            return LoadDataSet(url, null, DefaultTimeout);
        }
        public static DataSet LoadDataSet(string url, string PostContent, int timeout)
        {
            return LoadDataSet(url, PostContent, timeout,DefaultCoding);
        }
        public static DataSet LoadDataSet(string url, string PostContent, Encoding encoding)
        {
            return LoadDataSet(url, PostContent, DefaultTimeout, encoding);
        }
        public static DataSet LoadDataSet(string url, string PostContent,int timeout,Encoding encoding)
        {
            DataSet ds = new DataSet();
            XmlNodeReader xnr = new XmlNodeReader(LoadXmlDocument(url, PostContent, timeout, encoding));
            ds.ReadXml(xnr);
            return ds;
        }
        
        #endregion

        #region 读取内容
        public static string GetResponse(string url, string PostContent)
        {
            return GetResponse(url, PostContent, DefaultTimeout);
        }
        public static string GetResponse(string url, string PostContent,int timeout)
        {
            return GetResponse(url, PostContent, timeout, DefaultCoding);
        }
        public static string GetResponse(string url, string PostContent, Encoding encoding)
        {
            return GetResponse(url, PostContent, DefaultTimeout, encoding);
        }
        public static string GetResponse(string url, string PostContent,int timeout, Encoding encoding)
        {
            return Read(LoadRequest(url, PostContent, timeout), encoding);
        }
        #endregion
        #region 读取DataTable
        public static DataTable LoadDataTable(string url, string tablename)
        {
            return LoadDataTable(url, tablename, null);
        }
        public static DataTable LoadDataTable(string url, string tablename, string PostContent)
        {
            return LoadDataTable(url, tablename, PostContent, DefaultTimeout);
        }
        public static DataTable LoadDataTable(string url, string tablename, string PostContent,Encoding encoding)
        {
            return LoadDataTable(url, tablename, PostContent, DefaultTimeout, encoding);
        }
        public static DataTable LoadDataTable(string url, string tablename, string PostContent, int timeout)
        {
            return LoadDataTable(url, tablename, PostContent, timeout, DefaultCoding);
        }
        public static DataTable LoadDataTable(string url, string tablename, string PostContent, int timeout, Encoding encoding)
        {
            DataSet ds = LoadDataSet(url, PostContent, timeout, encoding);
            DataTable dt = ds.Tables[tablename];
            if (dt != null)
            {
                DataTable result = dt.Copy();
                ds.Clear();
                return result;
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion
    }
}
