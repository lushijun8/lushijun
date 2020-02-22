using System;
using System.Text;
using System.Web;

namespace Com.Common
{
	/// <summary>
	/// Charset 的摘要说明。
	/// </summary>
	public class Charset
	{
		public Charset()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private const string PRE_FIX_HTML="&";
		private const string PRE_FIX_UTF="&#x";
		private const string POS_FIX_UTF=";";

		private static string CharToUnicode(char cChar)
		{
			string temp = Char.ToString(cChar);
			string str = HttpUtility.UrlEncodeUnicode(temp);
			str = str.Replace("%","\\");
			str = str.Substring(2);
			return str;
		}

		public static string ToUnicode(string inStr)
		{
			string sResult = "";
			if(inStr == null || "".Equals(inStr)) return "";
			for (int i=0;i<inStr.Length;i++)
			{
				byte[] BT = Encoding.Unicode.GetBytes(inStr.Substring(i,1));
				if(BT[1] == 0)
				{
					// 如果不是双长度的字符，不需要unicode转换
					switch(inStr.Substring(i,1))
					{
						case " ":
							sResult += "&nbsp;";
							break;
						case "\"":
							sResult += "&quot;";
							break;
						case "&":
							sResult += "&amp;";
							break;
						case "<":
							sResult += "&lt;";
							break;
						case ">":
							sResult += "&gt;";
							break;
						default:
							sResult += inStr.Substring(i,1);
							break;
					}
					continue;
				}
				ushort US = BitConverter.ToUInt16(BT, 0); 
				string sEscape = "&#" + US.ToString() + ";"; 
				sResult += sEscape;

			}
			return sResult;

		}		
		public static string ToUnicode(string inStr,string except)
		{

			string sResult = "";
			if(inStr == null || "".Equals(inStr)) return "";
			for (int i=0;i<inStr.Length;i++)
			{
				byte[] BT = Encoding.Unicode.GetBytes(inStr.Substring(i,1));
				if(BT[1] == 0)
				{
					// 如果不是双长度的字符，不需要unicode转换
					switch(inStr.Substring(i,1))
					{
						case " ":
							sResult += "&nbsp;";
							break;
						case "\"":
							sResult += "&quot;";
							break;
						case "&":
							sResult += "&amp;";
							break;
						default:
							sResult += inStr.Substring(i,1);
							break;
					}
					continue;
				}
				ushort US = BitConverter.ToUInt16(BT, 0); 
				string sEscape = "&#" + US.ToString() + ";"; 
				sResult += sEscape;

			}
			return sResult;

		}		
		

		public static String GetDigital(String s)
		{
			if (s==null||s.Trim().Length==0) return "0";
			String sReturn = "";
			int iStart = 0;
			for (int i=0; i<s.Length; i++)
			{
				if(Char.IsNumber(s,i))
				{
					iStart = i;
					break;
				}
			}
			for (int i=iStart; i<s.Length; i++)
			{
				if(Char.IsNumber(s,i))
				{
					sReturn = String.Format("{0}{1}",sReturn,s.Substring(i,1));
				}
				else
				{
					break;
				}
			}
			return sReturn;
		}

		public static bool IsDigitalString(String s)
		{
			if(s==null||s.Length==0)
				return false;
			for(int i=0;i<s.Length;i++)
			{
				if(!Char.IsNumber(s,i))
					return false;
			}
			return true;

		}
		public static String ProcessNull(String s)
		{
			if (s==null) return "";
			return s;
		}	
		
		public static String ToChineseNumber(int i)
		{
			String sNumber = "";
			switch (i)
			{
				case 0: sNumber = "○";
					break;
				case 1: sNumber = "一";
					break;
				case 2: sNumber = "二";
					break;
				case 3: sNumber = "三";
					break;
				case 4: sNumber = "四";
					break;
				case 5: sNumber = "五";
					break;
				case 6: sNumber = "六";
					break;
				case 7: sNumber = "七";
					break;
				case 8: sNumber = "八";
					break;
				case 9: sNumber = "九";
					break;
				case 10: sNumber = "十";
					break;
				default: sNumber = "";
					break;
			}
			return sNumber;
		}

	}
}
