using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Threading;
namespace Com.Net
{
	/// <summary>
	/// NetUtil 的摘要说明。
	/// </summary>
	public class NetUtil
	{
		public NetUtil()
		{
		}
		public static long GetWebResponseLength(string URL)
		{
			long Value=0;
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
				HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
				Value=rep.ContentLength;
			}
			catch(Exception err)
			{
				Com.File.FileLog.WriteLog("Com.Net.NetUtil.GetWebResponse",err.ToString()+"\r\nURL:"+URL);
			}
			return Value;
		}
		public static string GetWebResponse(string URL, out string outContentType,out long outContentLength)
		{
			string Value="";
			outContentType="";
			outContentLength=0;
			try
			{
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
				HttpWebResponse rep = (HttpWebResponse)req.GetResponse();

				string ContentType=rep.ContentType.ToLower();
                string Charset = rep.CharacterSet;

				outContentType=ContentType;

				long ContentLength=rep.ContentLength;
				outContentLength=ContentLength;

				if( ContentType.StartsWith("text/"))
				{
					System.IO.Stream stream=rep.GetResponseStream();
					StreamReader sr=null;
					if(ContentType.ToLower().IndexOf("gb2312")>0)
					{
						sr= new StreamReader(rep.GetResponseStream(), System.Text.Encoding.GetEncoding("GB2312"));
					}
                    else if (ContentType.ToLower().IndexOf("utf-8") > 0)
					{
						sr= new StreamReader(rep.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
                    }
                    else if (ContentType.ToLower().IndexOf("gbk") > 0)
                    {
                        sr = new StreamReader(rep.GetResponseStream(), System.Text.Encoding.GetEncoding("GBK"));
                    }
                    else if (Charset.Trim()!="")
					{
                        sr = new StreamReader(stream, System.Text.Encoding.GetEncoding(Charset));
                    }
                    else
                    {
                        sr = new StreamReader(stream, System.Text.Encoding.Default);
                    }
					Value=sr.ReadToEnd();
					stream.Close();
					sr.Close();	
					rep.Close();
					req.Abort();
					
				}
			}
			catch(Exception err)
			{
				Com.File.FileLog.WriteLog("Com.Net.NetUtil.GetWebResponse",err.ToString()+"\r\nURL:"+URL);
			}
			return Value;
		}
		public static string GetWebResponse(string URL)
		{
			string ContentType="";
			long ContentLength=0;
			return GetWebResponse(URL,out ContentType,out ContentLength);
		}
		public static bool ConnectInternet()
		{
			return ConnectInternet("http://www.sohu.com");
		}
		public static bool ConnectInternet(string Url)
		{
			bool Value =false;
			HttpWebResponse result = null;
			try
			{

				System.Uri server=new Uri(Url);
				WebRequest req = WebRequest.Create(server);
				result = (HttpWebResponse)req.GetResponse();
				if (result.StatusCode == HttpStatusCode.OK )
				{
					Value = true;
				}
			}
			catch(Exception err)
			{
				Value = false;
				Com.File.FileLog.WriteLog("Com.Net.NetUtil.GetWebResponse",err.ToString()+"\r\nURL:");
			}
			return Value;
		}
	}
}
