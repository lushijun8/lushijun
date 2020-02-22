using System;
using  System.Security.Cryptography;
namespace Com.Common
{
	/// <summary>
	/// 获取随即机字符串
	/// </summary>
	public  sealed  class  RandomUtil
	{

		/// <summary>
		/// 默认长度是8
		/// </summary>
		private  static  readonly  int  DefaultLength  =  8;

		/// <summary>
		/// 获取随机种子
		/// </summary>
		/// <returns></returns>
		private  static  int  GetNewSeed()
		{
			byte[]  rndBytes  =  new  byte[4];
			RNGCryptoServiceProvider  rng  =  new  RNGCryptoServiceProvider();
			rng.GetBytes(rndBytes);
			return  BitConverter.ToInt32(rndBytes,0);
		}

		/// <summary>
		/// 获取指定长度的所有随机字符串
		/// </summary>
		/// <param name="strlen"></param>
		/// <returns></returns>
		private  static  string  BuildRndCodeAll(int  strLen)  
		{
			System.Random  RandomObj  =  new  System.Random(GetNewSeed());  
			string  buildRndCodeReturn  =  null;
			for(int  i=0;  i<strLen;  i++)  
			{
				buildRndCodeReturn  +=  (char)RandomObj.Next(33,125);
			}
			return  buildRndCodeReturn;
		}

		/// <summary>
		/// 获取默认长度8位随机字符串
		/// </summary>
		/// <returns></returns>
		public  static  string  GetRandomString()  
		{
			return  BuildRndCodeAll(DefaultLength);
		}

		/// <summary>
		/// 获取指定长度的所有随机字符串
		/// </summary>
		/// <param name="lenof"></param>
		/// <returns></returns>
		public  static  string  GetRandomString(int  LenOf)  
		{
			return  BuildRndCodeAll(LenOf);
		}

		/// <summary>
		/// 小写字母
		/// </summary>
		private  static  string  sCharLow  =  "abcdefghijklmnopqrstuvwxyz";
		/// <summary>
		/// 大写字母
		/// </summary>
		private  static  string  sCharUpp  =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		/// <summary>
		/// 数字
		/// </summary>
		private  static  string  sNumber  =  "0123456789";

		/// <summary>
		/// 获取字母和数字组成的指定长度的字符串
		/// </summary>
		/// <param name="strof"></param>
		/// <param name="strlen"></param>
		/// <returns></returns>
		private  static  string  BuildRndCodeOnly(string  StrOf,int  strLen)  
		{
			System.Random  RandomObj  =  new  System.Random(GetNewSeed());  
			string  buildRndCodeReturn  =  null;
			for(int  i=0;  i<strLen;  i++)  
			{
				buildRndCodeReturn  +=  StrOf.Substring(RandomObj.Next(0,StrOf.Length-1),1);
			}
			return  buildRndCodeReturn;
		}

		/// <summary>
		/// 获取字母和数字组成的默认长度8的字符串
		/// </summary>
		/// <returns></returns>
		public  static  string  GetRandomCode()  
		{
			return  BuildRndCodeOnly(sCharLow  +  sNumber,DefaultLength);
		}

		/// <summary>
		/// 获取字母和数字组成的指定长度的字符串
		/// </summary>
		/// <param name="lenof"></param>
		/// <returns></returns>
		public  static  string  GetRandomCode(int  LenOf)  
		{
			return  BuildRndCodeOnly(sCharLow  +  sNumber,LenOf);
		}

		/// <summary>
		/// 获取字母和数字组成的指定长度的字符串
		/// </summary>
		/// <param name="buseupper">是否包含大写字母</param>
		/// <param name="busenumber">是否包含数字</param>
		/// <returns></returns>
		public  static  string  GetRandomCode(bool  bUseUpper,bool  bUseNumber)  
		{
			string  strTmp  =  sCharLow;
			if  (bUseUpper)  strTmp  +=  sCharUpp;
			if  (bUseNumber)  strTmp  +=  sNumber;

			return  BuildRndCodeOnly(strTmp,DefaultLength);
		}

		/// <summary>
		/// 获取字母和数字组成的指定长度的字符串
		/// </summary>
		/// <param name="lenof">长度</param>
		/// <param name="buseupper">是否包含大写字母</param>
		/// <param name="busenumber">是否包含数字</param>
		/// <returns></returns>
		public  static  string  GetRandomCode(int  lenof,bool  bUseUpper,bool  bUseNumber)  
		{
			string  strTmp  =  sCharLow;
			if  (bUseUpper)  strTmp  +=  sCharUpp;
			if  (bUseNumber)  strTmp  +=  sNumber;

			return  BuildRndCodeOnly(strTmp,lenof);
		}
	}
}
