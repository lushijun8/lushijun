using System;

namespace Com.Net
{
	/// <summary>
	/// IPUtil 的摘要说明。
	/// </summary>
	public class IPUtil
	{
		public IPUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// Function Ip2Str(cIp)
		/// 参考动网ip算法
		/// 参数：cIp ip地址
		/// 返回值: 转换后数值
		/// </summary>
		/// <param name="?"></param>
		public static decimal  Ip2Str(string cIp)
		{
			decimal Value=-1;
			string str1="",str2="",str3="",str4="";
			//string cIp_Temp;
			if (cIp=="127.0.0.1")
			{
				cIp="192.168.0.1";
			}

			str1=cIp.Split('.')[0];
			str2=cIp.Split('.')[1];
			str3=cIp.Split('.')[2];
			str4=cIp.Split('.')[3];
			Value=Convert.ToDecimal(str1)*256*256*256+
				Convert.ToDecimal(str2)*256*256+
				Convert.ToDecimal(str3)*256+
				Convert.ToDecimal(str4)-1;
			return Value;
		}
	}
}
