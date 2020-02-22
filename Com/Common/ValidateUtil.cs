using System;

namespace Com.Common
{
	/// <summary>
	/// ValidateUtil 的摘要说明。
	/// </summary>
	public class ValidateUtil
	{
		public ValidateUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private static bool checkDatePart(string year, string month, string day)
		{
			int num1 = Convert.ToInt16(year);
			int num2 = Convert.ToInt16(month);
			int num3 = Convert.ToInt16(day);
			if ((num1 > 0x833) || (num1 < 1900))
			{
				return false;
			}
			if ((num2 > 12) || (num2 < 1))
			{
				return false;
			}
			if ((num3 > DateUtil.GetDaysOfMonth(num1, num2)) || (num3 < 1))
			{
				return false;
			}
			return true;
		}
 
		public static bool isBlank(string strInput)
		{
			if ((strInput == null) || (strInput.Trim() == ""))
			{
				return true;
			}
			return false;
		}
 
		public static bool isDate(string strInput)
		{
			string text1 = strInput;
			string[] textArray1 = new string[3] { "/", "-", "." } ;
			string text5 = "";
			for (int num1 = 0; num1 < textArray1.Length; num1++)
			{
				if (text1.IndexOf(textArray1[num1]) > 0)
				{
					text5 = textArray1[num1];
					break;
				}
			}
			if (text5 != "")
			{
				string text2 = text1.Substring(0, text1.IndexOf(text5));
				if (text2.Length != 4)
				{
					return false;
				}
				text1 = text1.Substring(text1.IndexOf(text5) + 1);
				string text3 = text1.Substring(0, text1.IndexOf(text5));
				if ((text3.Length != 2) || (Convert.ToInt16(text3) > 12))
				{
					return false;
				}
				text1 = text1.Substring(text1.IndexOf(text5) + 1);
				string text4 = text1;
				if ((text4.Length != 2) || (Convert.ToInt16(text4) > 0x1f))
				{
					return false;
				}
				return ValidateUtil.checkDatePart(text2, text3, text4);
			}
			return false;
		}
 
		public static bool isDouble(string strInput)
		{
			return true;
		}
 
		public static bool isEmail(string strInput)
		{
			return true;
		}
 
		public static bool isInt(string strInput)
		{
			return true;
		}
 
		public static bool isNull(object strInput)
		{
			return true;
		}
 
		public static bool isNumeric(string strInput)
		{
			char[] chArray1 = strInput.ToCharArray();
			bool flag1 = true;
			for (int num1 = 0; num1 < chArray1.Length; num1++)
			{
				if (((chArray1[num1] < '0') || (chArray1[num1] > '9')) && (chArray1[num1] != '.'))
				{
					flag1 = false;
					break;
				}
			}
			return flag1;
		}
 
		public static bool isTel(string strInput)
		{
			return true;
		}
 
		public static bool isZip(string strInput)
		{
			return true;
		}
 

	}
}
