using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using CDO;
using ADODB;

namespace Com.Common
{
	/// <summary>
	/// EMailUtil 的摘要说明。
	/// </summary>
	public class EMailUtil
	{
		public EMailUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public string[] getMailInfo(string strUserName, string strPass, string Pop3ServerIP, int iBeginNo, int iCount)
		{
			TcpClient client1 = new TcpClient();
			int num1 = 0;
			string[] textArray1 = new string[iCount * 6];
			try
			{
				client1.Connect(Pop3ServerIP, 110);
			}
			catch (Exception)
			{
				client1 = null;
				num1 = -1;
			}
			if (num1 == 0)
			{
				StreamReader reader1 = new StreamReader(client1.GetStream(), Encoding.GetEncoding("GB2312"));
				string text1 = this.Logon(client1, strUserName, strPass);
				if (this.JudgeString(text1) != "+OK")
				{
					num1 = -2;
				}
				if (num1 == 0)
				{
					for (int num2 = iBeginNo; num2 < (iBeginNo + iCount); num2++)
					{
						string[] textArray2 = this.PopMail(client1, num2);
						if (textArray2[0] == "+OK")
						{
							for (int num3 = 0; num3 < 6; num3++)
							{
								textArray1[((num2 - 1) * 6) + num3] = textArray2[num3];
							}
						}
					}
				}
			}
			client1.Close();
			return textArray1;
		}
 
		public int getMailNumber(string strUserName, string strPass, string Pop3ServerIP)
		{
			TcpClient client1 = new TcpClient();
			int num1 = 0;
			int num2 = 0;
			try
			{
				client1.Connect(Pop3ServerIP, 110);
			}
			catch (Exception)
			{
				client1 = null;
				num1 = -1;
			}
			if (num1 == 0)
			{
				StreamReader reader1 = new StreamReader(client1.GetStream(), Encoding.Default);
				string text1 = this.Logon(client1, strUserName, strPass);
				if (this.JudgeString(text1) != "+OK")
				{
					num1 = -2;
				}
				if (num1 == 0)
				{
					string[] textArray1 = this.StaticMailBox(client1);
					if (textArray1[0] != "+OK")
					{
						num1 = -3;
					}
					else
					{
						num2 = Convert.ToInt32(textArray1[3]);
					}
				}
				reader1.Close();
			}
			client1.Close();
			if (num1 < 0)
			{
				return num1;
			}
			return num2;
		}
 
		private string JudgeString(string strCheck)
		{
			if (strCheck.Substring(0, 3) != "+OK")
			{
				return "-ERR";
			}
			return "+OK";
		}
 
		private string Logon(TcpClient tcpc, string user, string pass)
		{
			string text1 = this.SendPopCmd(tcpc, "user " + user);
			return this.SendPopCmd(tcpc, "pass " + pass);
		}
 
		private string[] PopMail(TcpClient tcpc, int i)
		{
			bool flag1 = false;
			string[] textArray1 = new string[10];
			string text1 = this.SendPopCmd(tcpc, "retr " + i.ToString());
			if (this.JudgeString(text1) != "+OK")
			{
				return "-ERR -ERR".Split(" ".ToCharArray());
			}
			StreamReader reader1 = new StreamReader(tcpc.GetStream(), Encoding.GetEncoding("GB2312"));
			while (reader1.Peek() != 0x2e)
			{
				text1 = reader1.ReadLine();
				string[] textArray2 = text1.Split(":".ToCharArray());
				if (text1 == "")
				{
					flag1 = true;
				}
				if (textArray2[0] == "Date")
				{
					textArray1[1] = textArray2[1];
				}
				if (textArray2[0] == "From")
				{
					textArray1[2] = textArray2[1];
				}
				if (textArray2[0] == "To")
				{
					textArray1[3] = textArray2[1];
				}
				if (textArray2[0] == "Subject")
				{
					textArray1[4] = textArray2[1];
				}
				if (flag1)
				{
					textArray1[5] = textArray1[5] + text1 + "\n";
				}
			}
			textArray1[0] = "+OK";
			return textArray1;
		}
 
		public static bool SendOneMail(string sSmtpServer, string sUserName, string sPassword, string sFrom, string sTo, string sCCTo, string sBCCTo, string sSubject, string sContent, string[] sAttachmentUrlArray)
		{
			bool flag1 = false;
			Message message1 = new MessageClass();

			message1.From=(sFrom);
			message1.To=sTo;
			message1.CC=sCCTo;
			message1.BCC=sBCCTo;
			message1.Subject=sSubject;
			message1.TextBody=sContent;
			try
			{
				if (sAttachmentUrlArray.Length > 0)
				{
					for (int num1 = 0; num1 < sAttachmentUrlArray.Length; num1++)
					{
						message1.AddAttachment(sAttachmentUrlArray[num1], sUserName, sPassword);
					}
				}
				IConfiguration configuration1 = message1.Configuration;
				Fields fields1 = configuration1.Fields;
				fields1["http://schemas.microsoft.com/cdo/configuration/sendusing"].Value=(2);
				fields1["http://schemas.microsoft.com/cdo/configuration/sendemailaddress"].Value=(sFrom);
				fields1["http://schemas.microsoft.com/cdo/configuration/smtpuserreplyemailaddress"].Value=(sFrom);
				fields1["http://schemas.microsoft.com/cdo/configuration/smtpaccountname"].Value=(sUserName);
				fields1["http://schemas.microsoft.com/cdo/configuration/sendusername"].Value=(sUserName);
				fields1["http://schemas.microsoft.com/cdo/configuration/sendpassword"].Value=(sPassword);
				fields1["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"].Value=(1);
				fields1["http://schemas.microsoft.com/cdo/configuration/smtpserver"].Value=(sSmtpServer);
				fields1.Update();
				message1.Send();
				message1 = null;
				flag1 = true;
			}
			catch (Exception)
			{
				flag1 = false;
			}
			return flag1;
		}
 
		private string SendPopCmd(TcpClient tcpc, string strCmd)
		{
			strCmd = strCmd + "\r\n";
			byte[] buffer1 = Encoding.Default.GetBytes(strCmd.ToCharArray());
			System.IO.Stream stream1 = tcpc.GetStream();
			stream1.Write(buffer1, 0, strCmd.Length);
			StreamReader reader1 = new StreamReader(tcpc.GetStream(), Encoding.Default);
			return reader1.ReadLine();
		}
 
		private string[] StaticMailBox(TcpClient tcpc)
		{
			string text1 = this.SendPopCmd(tcpc, "stat");
			if (this.JudgeString(text1) != "+OK")
			{
				return "-ERR -ERR".Split(" ".ToCharArray());
			}
			return text1.Split(" ".ToCharArray());
		}
 

	}
}
