using System;
using  System.Security.Cryptography;
namespace Com.Common
{
	/// <summary>
	/// ��ȡ�漴���ַ���
	/// </summary>
	public  sealed  class  RandomUtil
	{

		/// <summary>
		/// Ĭ�ϳ�����8
		/// </summary>
		private  static  readonly  int  DefaultLength  =  8;

		/// <summary>
		/// ��ȡ�������
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
		/// ��ȡָ�����ȵ���������ַ���
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
		/// ��ȡĬ�ϳ���8λ����ַ���
		/// </summary>
		/// <returns></returns>
		public  static  string  GetRandomString()  
		{
			return  BuildRndCodeAll(DefaultLength);
		}

		/// <summary>
		/// ��ȡָ�����ȵ���������ַ���
		/// </summary>
		/// <param name="lenof"></param>
		/// <returns></returns>
		public  static  string  GetRandomString(int  LenOf)  
		{
			return  BuildRndCodeAll(LenOf);
		}

		/// <summary>
		/// Сд��ĸ
		/// </summary>
		private  static  string  sCharLow  =  "abcdefghijklmnopqrstuvwxyz";
		/// <summary>
		/// ��д��ĸ
		/// </summary>
		private  static  string  sCharUpp  =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		/// <summary>
		/// ����
		/// </summary>
		private  static  string  sNumber  =  "0123456789";

		/// <summary>
		/// ��ȡ��ĸ��������ɵ�ָ�����ȵ��ַ���
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
		/// ��ȡ��ĸ��������ɵ�Ĭ�ϳ���8���ַ���
		/// </summary>
		/// <returns></returns>
		public  static  string  GetRandomCode()  
		{
			return  BuildRndCodeOnly(sCharLow  +  sNumber,DefaultLength);
		}

		/// <summary>
		/// ��ȡ��ĸ��������ɵ�ָ�����ȵ��ַ���
		/// </summary>
		/// <param name="lenof"></param>
		/// <returns></returns>
		public  static  string  GetRandomCode(int  LenOf)  
		{
			return  BuildRndCodeOnly(sCharLow  +  sNumber,LenOf);
		}

		/// <summary>
		/// ��ȡ��ĸ��������ɵ�ָ�����ȵ��ַ���
		/// </summary>
		/// <param name="buseupper">�Ƿ������д��ĸ</param>
		/// <param name="busenumber">�Ƿ��������</param>
		/// <returns></returns>
		public  static  string  GetRandomCode(bool  bUseUpper,bool  bUseNumber)  
		{
			string  strTmp  =  sCharLow;
			if  (bUseUpper)  strTmp  +=  sCharUpp;
			if  (bUseNumber)  strTmp  +=  sNumber;

			return  BuildRndCodeOnly(strTmp,DefaultLength);
		}

		/// <summary>
		/// ��ȡ��ĸ��������ɵ�ָ�����ȵ��ַ���
		/// </summary>
		/// <param name="lenof">����</param>
		/// <param name="buseupper">�Ƿ������д��ĸ</param>
		/// <param name="busenumber">�Ƿ��������</param>
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
