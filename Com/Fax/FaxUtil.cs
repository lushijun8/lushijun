using System;

namespace Com.Fax
{
	/// <summary>
	/// FaxUtil ��ժҪ˵����
	/// </summary>
	public class FaxUtil
	{
		public FaxUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static bool SendFax()
		{

			return true;
			//���ʹ���
//			FAXCOMEXLib.FaxDocumentClass FaxDoc=new FAXCOMEXLib.FaxDocumentClass();
//			FaxDoc.Body="E:\\test.txt";
//			FaxDoc.CoverPage="E:\\test.txt";
//			FaxDoc.Note="E:\\test.txt";
//			FaxDoc.GroupBroadcastReceipts=true;
//			FaxDoc.DocumentName="E:\\test.txt";
//			FaxDoc.Subject="Subject";
//			FaxDoc.Recipients.Add("01063260698","������1");
//			FaxDoc.Recipients.Add("01088888888","������2");
//			FaxDoc.Sender.Name="������";
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
//			fd.RecipientName = "���������ڷ��Ƽ���չ��˾";
//			fd.Send();
//			fsc.Disconnect();
		}
	}
}
