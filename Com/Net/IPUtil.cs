using System;

namespace Com.Net
{
	/// <summary>
	/// IPUtil ��ժҪ˵����
	/// </summary>
	public class IPUtil
	{
		public IPUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// Function Ip2Str(cIp)
		/// �ο�����ip�㷨
		/// ������cIp ip��ַ
		/// ����ֵ: ת������ֵ
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
