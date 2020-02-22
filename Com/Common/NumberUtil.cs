using System;
using System.Globalization;

namespace Com.Common
{
	/// <summary>
	/// NumberUtil 的摘要说明。
	/// </summary>
	public class NumberUtil
	{
		public NumberUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
