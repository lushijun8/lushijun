using System;
using System.Globalization;

namespace Com.Common
{
	/// <summary>
	/// NumberUtil ��ժҪ˵����
	/// </summary>
	public class NumberUtil
	{
		public NumberUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static double GetRandomNumber(double InValue, int Num)
		{
			NumberFormatInfo info1 = new NumberFormatInfo();
			info1.NumberDecimalDigits = Num;
			return Convert.ToDouble(InValue, info1);
		}
 

	}
}
