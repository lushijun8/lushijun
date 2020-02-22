using System;
using System.Data;
using System.Web;
using System.IO;
using System.Text;

namespace Com.File
{
	/// <summary>
	/// FileUtil 的摘要说明。
	/// </summary>
	public class FileUtil
	{
		public FileUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static bool AppendFileContent(string strSourceFile, string sContent)
		{
			return FileUtil.AppendFileContent(strSourceFile, sContent, "GB2312");
		}
 
		public static bool AppendFileContent(string strSourceFile, string sContent, string strEncode)
		{
			return FileUtil.WriteFileContent(strSourceFile, sContent, strEncode, true);
		}
 
		public static bool CopyFile(string strSourceFile, string strTargetFile)
		{
			bool flag1;
			try
			{
				System.IO.File.Copy(strSourceFile, strTargetFile, true);
				flag1 = true;
			}
			catch (Exception exception1)
			{
				FileLog.WriteLog("\u62f7\u8d1d\u6587\u4ef6", exception1.Message);
				flag1 = false;
			}
			return flag1;
		}
 
		public static void CreateExcelFile(DataSet oIn, HttpResponse oResponse)
		{
			OfficeUtil.CreateExcelFile(oIn, oResponse);
		}
 
		public static bool DeleteFile(string strSourceFileFullPath)
		{
			bool flag1;
			try
			{
				System.IO.File.Delete(strSourceFileFullPath);
				flag1 = true;
			}
			catch (Exception exception1)
			{
				FileLog.WriteLog("\u5220\u9664\u6587\u4ef6", exception1.Message);
				flag1 = false;
			}
			return flag1;
		}
 
		public static int DictoryCreate(string strFilePath)
		{
			int num1;
			strFilePath = FileUtil.GetDealedFilePath(strFilePath);
			bool flag1 = Directory.Exists(strFilePath);
			try
			{
				if (!flag1)
				{
					Directory.CreateDirectory(strFilePath);
				}
				num1 = 1;
			}
			catch (Exception exception1)
			{
				FileLog.WriteLog("\u521b\u5efa\u6587\u4ef6\u8def\u5f84\u5931\u8d25", exception1.Message);
				num1 = 0;
			}
			return num1;
		}
 /// <summary>
 /// iSwitch=1:替换;0:不替换
 /// </summary>
 /// <param name="strFileAllName"></param>
 /// <param name="iSwitch"></param>
 /// <returns></returns>
		public static int FileCreate(string strFileAllName, int iSwitch)
		{
			int num2;
			string text1 = FileUtil.GetFileDictory(strFileAllName);
			text1 = FileUtil.GetDealedFilePath(text1);
			int num1 = FileUtil.DictoryCreate(text1);
			if (num1 == 0)
			{
				return -2;
			}
			bool flag1 = System.IO.File.Exists(strFileAllName);
			if ((iSwitch != 1) && flag1)
			{
				return -1;
			}
			try
			{
				if (flag1)
				{
					System.IO.File.Delete(strFileAllName);
				}
				FileStream stream1 = System.IO.File.Create(strFileAllName);
				stream1.Close();
				stream1 = null;
				num2 = 1;
			}
			catch (Exception)
			{
				num2 = 0;
			}
			return num2;
		}
 
		public static bool FileExists(string strFileAllName)
		{
			return System.IO.File.Exists(strFileAllName);
		}
 
		public static string GetDealedFilePath(string strFilePath)
		{
			strFilePath = strFilePath.Trim();
			if (strFilePath.Length == 0)
			{
				return "";
			}
			strFilePath = strFilePath.Replace("/", @"\");
			return strFilePath;
		}
 
		public static string GetFileContent(string strSourceFile)
		{
			return FileUtil.GetFileContent(strSourceFile, "GB2312");
		}
 
		public static string GetFileContent(string strSourceFile, string strEnCode)
		{
			string text1 = "";
			try
			{
				StreamReader reader1 = new StreamReader(strSourceFile, Encoding.GetEncoding(strEnCode));
				text1 = reader1.ReadToEnd();
				reader1.Close();
			}
			catch (Exception)
			{
			}
			return text1;
		}
 
		public static string GetFileDictory(string strFileAllName)
		{
			FileInfo info1 = new FileInfo(strFileAllName);
			return info1.DirectoryName;
		}
 
		public static string GetFileExtName(string strFileAllName)
		{
			FileInfo info1 = new FileInfo(strFileAllName);
			return info1.Extension;
		}
 
		public static string GetFileName(string strFileAllName)
		{
			FileInfo info1 = new FileInfo(strFileAllName);
			return info1.Name;
		}
 
		public static bool ReplaceFileContent(string strSourceFile, string strSourceString, string strTargetString)
		{
			return FileUtil.ReplaceFileContent(strSourceFile, strSourceString, strTargetString, "GB2312");
		}
 
		public static bool ReplaceFileContent(string strSourceFile, string strSourceString, string strTargetString, string strEncode)
		{
			string text1 = FileUtil.GetFileContent(strSourceFile, strEncode);
			text1 = text1.Replace(strSourceString, strTargetString);
			return FileUtil.WriteFileContent(strSourceFile, text1, strEncode);
		}
 
		public static bool WriteFileContent(string strSourceFile, string sContent)
		{
			return FileUtil.WriteFileContent(strSourceFile, sContent, "GB2312");
		}
 
		public static bool WriteFileContent(string strSourceFile, string sContent, string strEncode)
		{
			return FileUtil.WriteFileContent(strSourceFile, sContent, strEncode, false);
		}
 
		public static bool WriteFileContent(string strSourceFile, string sContent, string strEncode, bool AppendOrNot)
		{
			bool flag1;
			try
			{
				FileInfo info1 = new FileInfo(strSourceFile);
				if (!info1.Exists)
				{
					FileUtil.FileCreate(strSourceFile, 0);
				}
				info1 = null;
				StreamWriter writer1 = new StreamWriter(strSourceFile, AppendOrNot, Encoding.GetEncoding(strEncode));
				writer1.Write(sContent);
				writer1.Close();
				flag1 = true;
			}
			catch (Exception exception1)
			{
				FileLog.WriteLog("\u6539\u5199\u6587\u4ef6", exception1.Message);
				flag1 = false;
			}
			return flag1;
		}
 

	}
}
