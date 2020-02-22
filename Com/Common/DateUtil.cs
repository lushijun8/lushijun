using System;
using System.Globalization;
using System.Data;
using Com.Config;
using Com.Data;

namespace Com.Common
{
	/// <summary>
	/// DateUtil 的摘要说明。
	/// </summary>
	public class DateUtil
	{
		public DateUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        private static string[] DateTimeList = { "yyyy-M-d H:mm:ss", "yyyy-MM-dd H:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy-M-d HH:mm:ss", "yyyy-M-d H:mm:ss.fff", "yyyy-MM-dd H:mm:ss.fff", "yyyy-MM-dd HH:mm:ss.fff", "yyyy-M-d HH:mm:ss.fff", "yyyy-M-d", "yyyy-MM-dd", "yyyy/M/d tt hh:mm:ss", "yyyy/MM/dd tt hh:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/M/d HH:mm:ss", "yyyy/M/d", "yyyy/MM/dd", "yyyy年MM月dd日dddd HH:mm:ss", "yyyy年MM月dd日dddd HH:mm:s", "yyyy年MM月dd日dddd HH:m:ss", "yyyy年MM月dd日dddd HH:m:s", "yyyy年MM月dd日dddd H:mm:ss", "yyyy年MM月dd日dddd H:mm:s", "yyyy年MM月dd日dddd H:m:ss", "yyyy年MM月dd日dddd H:m:s", "yyyy年MM月dd日dddd hh:mm:ss", "yyyy年MM月dd日dddd hh:mm:s", "yyyy年MM月dd日dddd hh:m:ss", "yyyy年MM月dd日dddd hh:m:s", "yyyy年MM月dd日dddd h:mm:ss", "yyyy年MM月dd日dddd h:mm:s", "yyyy年MM月dd日dddd h:m:ss", "yyyy年MM月dd日dddd h:m:s", "yyyy年M月d日dddd HH:mm:ss", "yyyy年M月d日dddd HH:mm:s", "yyyy年M月d日dddd HH:m:ss", "yyyy年M月d日dddd HH:m:s", "yyyy年M月d日dddd H:mm:ss", "yyyy年M月d日dddd H:mm:s", "yyyy年M月d日dddd H:m:ss", "yyyy年M月d日dddd H:m:s", "yyyy年M月d日dddd hh:mm:ss", "yyyy年M月d日dddd hh:mm:s", "yyyy年M月d日dddd hh:m:ss", "yyyy年M月dd日dddd hh:m:s", "yyyy年M月d日dddd h:mm:ss", "yyyy年M月d日dddd h:mm:s", "yyyy年M月d日dddd h:m:ss", "yyyy年M月dd日dddd h:m:s" };
       
		public static string ConvertDateStringToShortFormat(string strInput)
		{
			if (DateUtil.IsDateTime(strInput))
			{
				DateTime time1 = Convert.ToDateTime(strInput);
				return time1.ToShortDateString();
			}
			return "";
		}
		public static string ConvertDateToString(DateTime oDateTime, string strFormat)
		{
			string text1 = "";
			try
			{
				string text3;
				if ((text3 = strFormat.ToUpper()) != null)
				{
					text3 = string.IsInterned(text3);
					if (text3 != "SHORTDATE")
					{
						if (text3 == "LONGDATE")
						{
							return oDateTime.ToLongDateString();
						}
					}
					else
					{
						return oDateTime.ToShortDateString();
					}
				}
				text1 = oDateTime.ToString(strFormat);
			}
			catch (Exception)
			{
				text1 = oDateTime.ToShortDateString();
			}
			return text1;
		}
		public static string ConvertObjToDateString(object oIn, string strFormat)
		{
			string text1;
			try
			{
				text1 = DateUtil.ConvertDateToString(Convert.ToDateTime(oIn), strFormat);
			}
			catch (Exception)
			{
				text1 = "";
			}
			return text1;
		}
		public static DateTime ConvertStringToDate(string strInput)
		{
			DateTime time1;
			try
			{
				time1 = DateTime.Parse(strInput);
			}
			catch (Exception)
			{
				time1 = DateTime.Today;
			}
			return time1;
		}
        public static DateTime ConvertStringToDateTime(string strInput)
        {
            DateTime dtResult = System.DateTime.Now;           
            try
            {
                dtResult = DateTime.Parse(strInput);
            }
            catch
            {
                try
                {
                    dtResult = DateTime.ParseExact(strInput, DateTimeList, CultureInfo.GetCultureInfo("zh-CN"), DateTimeStyles.AllowWhiteSpaces);
                }
                catch (Exception ex)
                {
                    File.FileLog.WriteLog("Com.Common.DateUtil.ConvertStringToDateTime(string strInput)", ex.Message + "Com.Common.DateUtil.ConvertStringToDateTime(),Wrong Time:" + strInput);  
                }
            }
            return dtResult;
        }
		public static DateTime ConvertStringToDate(string strInput, string strDefault)
		{
			DateTime time1;
			try
			{
				time1 = DateTime.Parse(strInput);
			}
			catch (Exception)
			{
				if (strDefault != "")
				{
					return DateTime.Parse(strDefault);
				}
				time1 = DateTime.Parse("1900-1-1");
			}
			return time1;
		}

		public static int DiffDays(DateTime dtfrm, DateTime dtto)
		{
			TimeSpan span1 = (TimeSpan) (dtto - dtfrm);
			return span1.Days;
		}
		public static DateTime GetCurrentDate()
		{
			DateTime time2 = DateUtil.GetCurrentTime();
			return Convert.ToDateTime(time2.ToShortDateString());
		}
		public static DateTime GetCurrentTime()
		{
			string text1 = "select GetDate() as CurrentTime ";
			DBType type1 = SystemConfig.DatabaseType;
			if (type1 != DBType.SQLServer)
			{
				if (type1 == DBType.Oracle)
				{
					text1 = "select sysdate as CurrentTime  from dual ";
				}
			}
			else
			{
				text1 = "select GetDate() as CurrentTime ";
			}
			DataSet set1 = Com.Data.DatabaseOperater.DataBaseReader .ExecuteDataSet(text1);
			DataRow row1 = set1.Tables[0].Rows[0];
			DateTime time1 = Convert.ToDateTime(row1["CurrentTime"].ToString());
			row1 = null;
			set1.Dispose();
			set1 = null;
			return time1;
		}
		public static int GetDaysOfMonth(DateTime dt)
		{
			int num3 = 0;
			int num1 = dt.Year;
			switch (dt.Month)
			{
				case 1:
				{
					return 0x1f;
				}
				case 2:
				{
					if (DateUtil.IsRuYear(num1))
					{
						return 0x1d;
					}
					return 0x1c;
				}
				case 3:
				{
					return 0x1f;
				}
				case 4:
				{
					return 30;
				}
				case 5:
				{
					return 0x1f;
				}
				case 6:
				{
					return 30;
				}
				case 7:
				{
					return 0x1f;
				}
				case 8:
				{
					return 0x1f;
				}
				case 9:
				{
					return 30;
				}
				case 10:
				{
					return 0x1f;
				}
				case 11:
				{
					return 30;
				}
				case 12:
				{
					return 0x1f;
				}
			}
			return num3;
		}
 
		public static int GetDaysOfMonth(int iYear, int Month)
		{
			int num1 = 0;
			switch (Month)
			{
				case 1:
				{
					return 0x1f;
				}
				case 2:
				{
					if (DateUtil.IsRuYear(iYear))
					{
						return 0x1d;
					}
					return 0x1c;
				}
				case 3:
				{
					return 0x1f;
				}
				case 4:
				{
					return 30;
				}
				case 5:
				{
					return 0x1f;
				}
				case 6:
				{
					return 30;
				}
				case 7:
				{
					return 0x1f;
				}
				case 8:
				{
					return 0x1f;
				}
				case 9:
				{
					return 30;
				}
				case 10:
				{
					return 0x1f;
				}
				case 11:
				{
					return 30;
				}
				case 12:
				{
					return 0x1f;
				}
			}
			return num1;
		}
 
		public static int GetDaysOfYear(DateTime idt)
		{
			if (DateUtil.IsRuYear(idt.Year))
			{
				return 0x16e;
			}
			return 0x16d;
		}
 
		public static int GetDaysOfYear(int iYear)
		{
			if (DateUtil.IsRuYear(iYear))
			{
				return 0x16e;
			}
			return 0x16d;
		}
 
		public static string GetFirstDayOfMonth(string sDateTime)
		{
			DateTime time1 = Convert.ToDateTime(sDateTime);
			object[] objArray1 = new object[4] { time1.Year, "-", time1.Month, "-01" } ;
			return string.Concat(objArray1);
		}
 
		public static string GetHourFromMinutes(string strInput)
		{
			if (strInput.Trim() == "")
			{
				return "0";
			}
			int num1 = Convert.ToInt32(strInput);
			int num2 = num1 / 60;
			int num3 = num1 % 60;
			char ch1 = '0';
			return (num2.ToString() + ":" + StringUtil.FillLeft(num3.ToString(), ch1, 2));
		}
 
		public static string GetLastDayOfMonth(string sDateTime)
		{
			DateTime time2 = Convert.ToDateTime(sDateTime);
			DateTime time1 = time2.AddMonths(1);
			time1 = Convert.ToDateTime(DateUtil.GetFirstDayOfMonth(time1.ToShortDateString()));
			time1 = time1.AddDays(-1);
			return time1.ToShortDateString();
		}
 
		public static DateTime GetWeekFristDay(DateTime Dt)
		{
			string text1 = DateUtil.GetWeekNumberOfDay(Dt);
			return Dt.AddDays((double) ((-1 * Convert.ToInt16(text1)) + 1));
		}
 
		public static string GetWeekNameOfDay(DateTime idt)
		{
			string text4="星期一";
			text4=idt.ToString("ddd", (new CultureInfo("zh-cn")));
			return text4;
		}
 
		public static string GetWeekNumberOfDay(DateTime idt)
		{
			string text4;
			string text2 = "";
			string text1 = idt.DayOfWeek.ToString();
			if ((text4 = text1) == null)
			{
				return text2;
			}
			text4 = string.IsInterned(text4);
			if (text4 != "Monday")
			{
				if (text4 == "Tuesday")
				{
					return "2";
				}
				if (text4 == "Wednesday")
				{
					return "3";
				}
				if (text4 == "Thursday")
				{
					return "4";
				}
				if (text4 == "Friday")
				{
					return "5";
				}
				if (text4 == "Saturday")
				{
					return "6";
				}
				if (text4 != "Sunday")
				{
					return text2;
				}
				return "7";
			}
			return "1";
		}
 
		public static bool IsDateTime(string strDate)
		{
			bool flag1;
			try
			{
				DateTime time1 = DateTime.Parse(strDate);
				if (time1.CompareTo(DateTime.Parse("1800-1-1")) > 0)
				{
					return true;
				}
				flag1 = false;
			}
			catch (Exception)
			{
				flag1 = false;
			}
			return flag1;
		}
 
		public static bool IsRuYear(DateTime idt)
		{
			return DateTime.IsLeapYear(idt.Year);
		}
 
		public static bool IsRuYear(int iYear)
		{
			return DateTime.IsLeapYear(iYear);
		}
 

	}
}
