using System;

namespace Com.Fax
{
	/// <summary>
	/// FaxUtil 的摘要说明。
	/// </summary>
	public class FaxUtil
	{
		public FaxUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static bool SendFax()
		{

			return true;
			//发送传真
//			FAXCOMEXLib.FaxDocumentClass FaxDoc=new FAXCOMEXLib.FaxDocumentClass();
//			FaxDoc.Body="E:\\test.txt";
//			FaxDoc.CoverPage="E:\\test.txt";
//			FaxDoc.Note="E:\\test.txt";
//			FaxDoc.GroupBroadcastReceipts=true;
//			FaxDoc.DocumentName="E:\\test.txt";
//			FaxDoc.Subject="Subject";
//			FaxDoc.Recipients.Add("01063260698","接收人1");
//			FaxDoc.Recipients.Add("01088888888","接收人2");
//			FaxDoc.Sender.Name="发件人";
//			FaxDoc.Submit("guoyu");
//
//			FAXCOMLib.FaxServerClass fsc = new FAXCOMLib.FaxServerClass(); 
//			fsc.Connect(""); 
//			object obj = fsc.CreateDocument("E:\\help.htm"); 
//			FAXCOMLib.FaxDoc fd = (FAXCOMLib.FaxDoc)obj; 
//			fd.DisplayName="DisplayName";
//			fd.CoverpageNote="CoverpageNote";
//			fd.CoverpageSubject="CoverpageSubject";
//			fd.FaxNumber = "027905007"; 
//			fd.RecipientName = "北京昆仑亿发科技发展公司";
//			fd.Send();
//			fsc.Disconnect();
		}
	}
}
