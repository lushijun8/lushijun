using System;
using System.Text;
using System.Web;

namespace Com.Common
{
	/// <summary>
	/// Charset ��ժҪ˵����
	/// </summary>
	public class Charset
	{
		public Charset()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
					// �������˫���ȵ��ַ�������Ҫunicodeת��
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
					// �������˫���ȵ��ַ�������Ҫunicodeת��
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
				case 0: sNumber = "��";
					break;
				case 1: sNumber = "һ";
					break;
				case 2: sNumber = "��";
					break;
				case 3: sNumber = "��";
					break;
				case 4: sNumber = "��";
					break;
				case 5: sNumber = "��";
					break;
				case 6: sNumber = "��";
					break;
				case 7: sNumber = "��";
					break;
				case 8: sNumber = "��";
					break;
				case 9: sNumber = "��";
					break;
				case 10: sNumber = "ʮ";
					break;
				default: sNumber = "";
					break;
			}
			return sNumber;
		}

	}
}
