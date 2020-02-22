using System;
using System.Configuration;
using Com.Xml;

namespace Com.Config
{
	public enum DBType
	{
		// Fields
		ODBC = 2,
		OleDb = 1,
		Oracle = 3,
		SQLServer = 0
	}
	/// <summary>
	/// 数据层对数据库操作的方式;Sql=0;Parameter = 1;Procedure = 2
	/// </summary>
	public enum DboType
	{
		Sql = 0,
		Parameter = 1,
		Procedure = 2
	}
	/// <summary>
	/// ConfigUtil 的摘要说明。
	/// </summary>
	public class ConfigUtil
	{
		public ConfigUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetValueFromWebConfig(string Key)
		{
			string text1 = "";
			//先从全局变量获取
			try
			{
				if(System.Web.HttpContext.Current.Application[Key]!=null)
				{
					text1=System.Web.HttpContext.Current.Application[Key].ToString();
				}
			}
			catch{}
			if(text1 == "")
			{
				try
				{
                    text1 = System.Configuration.ConfigurationSettings.AppSettings[Key];
				}
				catch (Exception)
				{
					text1 = "";
				}
			}
			if (text1 == null)
			{
				text1 = "";
			}
			if(text1=="")//从本目录下的web.config文件中获取
			{
				try
				{
					System.Xml.XmlDocument doc = Com.Xml.XmlUtil.GetDocFromFile("web.config");
					if(doc!=null)
					{
						System.Xml.XmlNodeList nodelist=doc.SelectNodes("/configuration/appSettings/add");
						for(int i=0;i<nodelist.Count;i++)
						{
							if(nodelist[i].Attributes["key"].Value==Key)
							{
								text1=nodelist[i].Attributes["value"].Value;
								break;
							}

						}
					}
				}
				catch{}
			}
			return text1;
		}
 
		public static bool SetValueFromWebConfig(string Key, string Value)
		{
			bool flag1;
			try
			{
                System.Configuration.ConfigurationSettings.AppSettings.Remove(Key);
                System.Configuration.ConfigurationSettings.AppSettings.Add(Key, Value);
				flag1 = true;
			}
			catch (Exception)
			{
				flag1 = false;
			}
			return flag1;
		}
		public static void SetConfigurationValue(string Name, string Value, bool isPass)
		{
			string text1 = AppDomain.CurrentDomain.BaseDirectory.Replace("/", @"\") + "web.config";
			XmlUtil.UpdateNode(text1, "/configuration/appSettings", "add", "key", Name, "value", Value, isPass);
		}

	}
}
