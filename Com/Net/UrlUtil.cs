using System;

namespace Com.Net
{
	/// <summary>
	/// UrlUtil 的摘要说明。
	/// </summary>
	public class UrlUtil
	{
		public UrlUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetAbsoluteUrl(string PageUrl,string ParentPageUrl)
		{
			string Value=PageUrl;
			string[] ParentPageUrlsplit=ParentPageUrl.Split('/');
//			if(PageUrl.ToLower().IndexOf("http://")>0)
			if(PageUrl.ToLower().IndexOf("http://")==0)
				Value=PageUrl.Remove(0,PageUrl.ToLower().IndexOf("http://"));
			else if(!PageUrl.ToLower().StartsWith("http") && ParentPageUrl.ToLower().StartsWith("http")&&ParentPageUrlsplit.Length>=3)
			{
				
				string RootUrl="http://"+ParentPageUrlsplit[2];
				if(PageUrl.ToLower().TrimStart().StartsWith("/"))
				{
					Value=RootUrl+PageUrl;
				}
				else if(PageUrl.ToLower().TrimStart().StartsWith(".."))
				{
					string[] PageUrlsplit=PageUrl.Split('/');
					int k=1;
					string text1=ParentPageUrl.Replace("/"+ParentPageUrlsplit[ParentPageUrlsplit.Length-1],"");
					for(int i=0;i<PageUrlsplit.Length;i++)
					{
						if(PageUrlsplit[i]=="..")
						{
							if(ParentPageUrlsplit.Length-1-k>0)
							{
								text1=text1.Replace("/"+ParentPageUrlsplit[ParentPageUrlsplit.Length-1-k],""); 
								k++;
							}
						}
					}
					Value=text1+"/"+PageUrl.Replace("../","");
				}
				else
				{
					if(ParentPageUrlsplit.Length==3)
					{
						Value=ParentPageUrl+"/"+PageUrl;
					}
					else if(ParentPageUrlsplit.Length-1>0 )
					{
						if(ParentPageUrlsplit[ParentPageUrlsplit.Length-1].Length>0)
						{
							Value=ParentPageUrl.Replace(ParentPageUrlsplit[ParentPageUrlsplit.Length-1],"")+PageUrl;
						}
						else
						{
							Value=ParentPageUrl+PageUrl;
						}
					}
				}
				
			}
			return Value.Replace("./","");
		}
	}
}
