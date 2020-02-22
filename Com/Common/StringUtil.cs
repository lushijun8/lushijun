using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.Common
{
	
	/// <summary>
	/// StringUtil ��ժҪ˵����
	/// </summary>
	public class StringUtil
	{
		public StringUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static string AddComma(string strInput)
		{
			StringBuilder builder1 = new StringBuilder(strInput.Length + 1);
			return builder1.Append(strInput).Append(",").ToString();
		}
 
		public static string AddSingleQuotes(string strInput)
		{
			StringBuilder builder1 = new StringBuilder(strInput.Length + 2);
			return builder1.Append("'").Append(strInput).Append("'").ToString();
		}
 
		public static ArrayList breakLongString(string strInput, int maxSize)
		{
			string text1 = strInput;
			ArrayList list1 = new ArrayList();
			while (text1.Length > maxSize)
			{
				list1.Add(text1.Substring(0, maxSize));
				text1 = text1.Substring(maxSize, text1.Length - maxSize);
			}
			if (text1.Length > 0)
			{
				list1.Add(text1);
			}
			return list1;
		}
 
		public static string charArrayToString(char[] cIn)
		{
			string text1 = "";
			for (int num1 = 0; num1 < cIn.Length; num1++)
			{
				text1 = text1 + cIn[num1].ToString();
			}
			return text1;
		}
 
		public static string FillLeft(string strInput, char c, int iMaxLength)
		{
			return strInput.PadLeft((strInput.Length - StringUtil.GetByteLength(strInput)) + iMaxLength, c);
		}
 
		public static string FillRight(string strInput, char c, int iMaxLength)
		{
			return strInput.PadRight((strInput.Length - StringUtil.GetByteLength(strInput)) + iMaxLength, c);
		}
 
//		public static string GenHtmlCode(string Temp)
//		{
//			Temp = Com.Data.StringUtil.BackSqlString(Temp);
//			return Temp.Replace("\n", "<br>");
//		}
 
		/// <summary>
		/// ��ȡ�ָ�����ַ�������
		/// </summary>
		/// <param name="strInput">�����ַ���</param>
		/// <param name="cSign">ʹ�õķָ��ַ�</param>
		/// <returns>���طָ��������</returns>
		public static string[] GetArrayBySegment(string strInput, char cSign)
		{
			char[] chArray1 = new char[1] { cSign } ;
			return strInput.Split(chArray1);
		}
 
		/// <summary>
		/// ��ȡ�������ı��Ĵ�С
		/// </summary>
		/// <param name="strInput">�����ַ���</param>
		/// <returns>���ض����ƴ�С</returns>
		public static int GetByteLength(string strInput)
		{
			ASCIIEncoding encoding1 = new ASCIIEncoding();
			byte[] buffer1 = encoding1.GetBytes(strInput);
			int num1 = 0;
			for (int num2 = 0; num2 <= (buffer1.Length - 1); num2++)
			{
				if (((buffer1[num2] >= 0) && (buffer1[num2] <= 0xff)) && (buffer1[num2] != 0x3f))
				{
					num1++;
				}
				else
				{
					num1 += 2;
				}
			}
			return num1;
		}
 
		/// <summary>
		/// ��ȡ����ַ���
		/// </summary>
		/// <param name="strInput">�����ַ���</param>
		/// <param name="strEnds">����λ��</param>
		/// <returns></returns>
		public static string GetLeftPart(string strInput, string strEnds)
		{
			int num1 = strInput.LastIndexOf(strEnds);
			if (num1 > 0)
			{
				return strInput.Substring(0, num1);
			}
			return strInput;
		}
 
		/// <summary>
		/// ��ȡһ�����ȵ��ַ���
		/// </summary>
		/// <param name="Value">ԭ�ַ���</param>
		/// <param name="Num">��ȡ����</param>
		/// <returns>���ؽ�ȡ���,����ϳ�����...ʡ��</returns>
		public static string GetLenContent(string Value, int Num)
		{
            //if (Encoding.Default.GetByteCount(Value) > Num)
            //{
            //    while (Encoding.Default.GetByteCount(Value) >= (Num - 3))
            //    {
            //        Value = Value.Substring(0, Value.Length - 1);
            //    }
            //    Value = Value + "...";
            //}


            if (Value.Length > Num)
            {
                Value = Value.Substring(0, Num)+"...";
            }
			return Value;
		}

        /// <summary>
        /// ��ȡһ�����ȵ��ַ���
        /// </summary>
        /// <param name="Value">ԭ�ַ���</param>
        /// <param name="Num">��ȡ����</param>
        /// <returns>���ؽ�ȡ���,����ϳ�����...ʡ��</returns>
        public static string SubString(string Value, int Num)
        {
            if (Value.Length > Num)
            {
                Value = Value.Substring(0, Num);
            }
            return Value;
        }
 
		public static string GetNotNull(object Input)
		{
			if (Input == null)
			{
				return "";
			}
			return Input.ToString();
		}
 
		public static string GetNotNull(object Input, string strDefault)
		{
			if (Input == null)
			{
				return strDefault;
			}
			return Input.ToString();
		}
 
		/// <summary>
		/// ��ȡ�ظ��ַ���
		/// </summary>
		/// <param name="strRepeat">��Ҫ�ظ���ԭ�ַ���</param>
		/// <param name="nCount">�ظ�����</param>
		/// <returns></returns>
		public static string GetRepeatStr(string strRepeat, int nCount)
		{
			StringBuilder builder1 = new StringBuilder(strRepeat.Length * nCount);
			for (int num1 = 0; num1 <= nCount; num1++)
			{
				builder1.Append(strRepeat);
			}
			return builder1.ToString();
		}
 
		/// <summary>
		/// ��ȡ�ұ��ַ���
		/// </summary>
		/// <param name="strInput">ԭ�ַ���</param>
		/// <param name="strStarts">��ȡ��ʼλ��</param>
		/// <returns></returns>
		public static string GetRightPart(string strInput, string strStarts)
		{
			int num1 = strInput.IndexOf(strStarts);
			if (num1 > 0)
			{
				return strInput.Substring(num1 + 1, (strInput.Length - num1) - 1);
			}
			return strInput;
		}
 
		/// <summary>
		/// ��÷ָ��ַ���
		/// </summary>
		/// <param name="strInput">��Ҫ�ָ����ַ�������</param>
		/// <param name="cSign">�ָ��ַ���</param>
		/// <returns></returns>
		public static string GetStringBySegment(string[] strInput, string cSign)
		{
			StringBuilder builder1 = new StringBuilder();
			string text1 = "";
			for (int num1 = 0; num1 < strInput.Length; num1++)
			{
				builder1.Append(strInput[num1] + cSign);
			}
			text1 = builder1.ToString();
			if (text1.Length > 0)
			{
				text1 = text1.Substring(0, text1.LastIndexOf(cSign));
			}
			return text1;
		}
 
		public static string GetValueFromBoolModify(bool IsTrue)
		{
			return StringUtil.GetValueFromBoolVariant(IsTrue, "Y", "N");
		}
 
		public static string GetValueFromBoolQuery(bool IsTrue)
		{
			return StringUtil.GetValueFromBoolVariant(IsTrue, "Y", "");
		}
 
		public static string GetValueFromBoolVariant(bool IsTrue, string Yes, string No)
		{
			return (IsTrue ? Yes : No);
		}
 
		/// <summary>
		/// �ж��ַ����Ƿ���ĸ�����ֵ����
		/// </summary>
		/// <param name="sCode">��Ҫ�жϵ��ַ���</param>
		/// <returns>���ؽ��</returns>
		public static bool IsCode(string sCode)
		{
			Regex regex1 = new Regex("[^A-Za-z0-9]", RegexOptions.IgnoreCase);
			if (regex1.Match(sCode).Success)
			{
				return false;
			}
			return true;
		}
 
		/// <summary>
		/// �ж��ַ����Ƿ�����
		/// </summary>
		/// <param name="sCode">��Ҫ�жϵ��ַ���</param>
		/// <returns>���ؽ��</returns>
		public static bool IsNumber(string sCode)
		{
			Regex regex1 = new Regex("[^0-9]");
			if (regex1.Match(sCode).Success)
			{
				return false;
			}
			return true;
		}
        /// <summary>
        /// �ж��Ƿ�ȫ��������
        /// </summary>
        /// <param name="CString"></param>
        /// <returns></returns>
        public static bool IsAllChinese(string CString)
        {
            bool BoolValue = true;
            for (int i = 0; i < CString.Length; i++)
            {
                bool bChinese = System.Text.RegularExpressions.Regex.IsMatch(CString.Substring(i, 1), @"[\u4e00-\u9fa5]+$");
                if (bChinese == false)
                {
                    BoolValue = false;
                    break;
                }
            }
            return BoolValue;
        }

		public static string SetZeroToMonth(string Value)
		{
			return StringUtil.SetZeroToPrefix("0", Value, 2);
		}
 
		public static string SetZeroToPrefix(string PrefixValue, string Value, int ValueLength)
		{
			return StringUtil.SetZeroToPrefix(PrefixValue, Value, ValueLength, true);
		}
 
		public static string SetZeroToPrefix(string PrefixValue, string Value, int ValueLength, bool IsFront)
		{
			string text1 = "";
			for (int num1 = Value.Length; num1 < ValueLength; num1 = text1.Length)
			{
				text1 = text1 + PrefixValue;
			}
			if (IsFront)
			{
				return (text1 + Value);
			}
			return (Value + text1);
		}
 

	}
}
