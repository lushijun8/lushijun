using System;
using Microsoft.Office;
using System.Web;
using System.IO;
using System.Threading;

namespace Com.File
{
	/// <summary>
	/// Word 的摘要说明。
	/// </summary>
	public class WordUtil
	{
		public WordUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetFileHtmlFromWord(string FileName)
		{
			string Value="";
			// 在此处放置用户代码以初始化页面
			Word.ApplicationClass word = new Word.ApplicationClass();
			Type wordType = word.GetType();
			Word.Documents docs = word.Documents;
			// 打开文件
			Type docsType = docs.GetType();
			object fileName = FileName;
			Word.Document doc = (Word.Document)docsType.InvokeMember("Open", 
				System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] {fileName, true, true});
			// 转换格式，另存为
			Type docType = doc.GetType();
			string HtmlFileName=FileName.ToLower().Replace(".doc","doc.html");
			try
			{
				docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
					null, doc, new object[]{HtmlFileName, Word.WdSaveFormat.wdFormatHTML});
				// 退出 Word
				wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod,
					null, word, null);
				Thread.Sleep(1000);
				Value=Com.File.FileUtil.GetFileContent(HtmlFileName);
			}
			catch(Exception err)
			{
				Com.File.FileLog.WriteLog("WordUtil读取Html文件出错",err.ToString(),"");
			}
			//删除临时文件
			finally
			{
				Thread.Sleep(1000);
				System.IO.FileInfo oFileInfo=new FileInfo(HtmlFileName.Replace(".html",".files")+"/filelist.xml");
				if(oFileInfo.Exists)
				{
					oFileInfo.Directory.Delete(true);
				}
				Com.File.FileUtil.DeleteFile(HtmlFileName);
				Com.File.OfficeUtil.KillProcess("WINWORD.EXE");
			}
			return Value;
		}
		public static string GetFileTextFromWord(string FileName)
		{
			string Value="";
			// 在此处放置用户代码以初始化页面
			Word.ApplicationClass word = new Word.ApplicationClass();
			Type wordType = word.GetType();
			Word.Documents docs = word.Documents;
			// 打开文件
			Type docsType = docs.GetType();
			object fileName = FileName;
			Word.Document doc = (Word.Document)docsType.InvokeMember("Open", 
				System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] {fileName, true, true});
			// 转换格式，另存为
			Type docType = doc.GetType();
			string TxtFileName=FileName.ToLower().Replace(".doc","doc.txt");
			try
			{
				docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
					null, doc, new object[]{TxtFileName, Word.WdSaveFormat.wdFormatText});
				// 退出 Word
				wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod,
					null, word, null);
				Thread.Sleep(1000);
				Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(TxtFileName));
			}
			catch(Exception err)
			{
				Com.File.FileLog.WriteLog("WordUtil读取Txt文件出错",err.ToString(),"");
			}
				//删除临时文件
			finally
			{
				Thread.Sleep(1000);
				Com.File.FileUtil.DeleteFile(TxtFileName);
				Com.File.OfficeUtil.KillProcess("WINWORD.EXE");
			}
			return Value;
		}
		public static void CreateWordFile(string ContentHtml, HttpResponse oResponse)
		{
			StringWriter writer1 = new StringWriter();
			writer1.Write(ContentHtml);
			oResponse.ContentType = "application/vnd.ms-word";
			oResponse.Charset = "";
			oResponse.Write(writer1.ToString());
			oResponse.End();
			writer1.Close();
			writer1 = null;
		}
	}
}
