using System;
using System.Web ;

namespace Com.File
{
	/// <summary>
	/// UploadFile ��ժҪ˵����
	/// </summary>
	public class UploadFile
	{
		private HttpPostedFile FileUp;

		public UploadFile(HttpPostedFile File)
		{
			this.FileUp = File;
		}
 
		~ UploadFile()
		{
			this.FileUp = null;
		}
		public string GetUpFileAllName()
		{
			if (this.FileUp == null)
			{
				return "";
			}
			return this.FileUp.FileName;
		}
 
		public long GetUpFileContentLength()
		{
			if (this.FileUp == null)
			{
				return (long) 0;
			}
			return this.FileUp.ContentLength;
		}
 
		public string GetUpFileExtName()
		{
			if (this.FileUp == null)
			{
				return "";
			}
			return FileUtil.GetFileExtName(this.FileUp.FileName);
		}
 
		public string GetUpFileName()
		{
			if (this.FileUp == null)
			{
				return "";
			}
			return FileUtil.GetFileName(this.FileUp.FileName);
		}

		/// <summary>
		/// �ϴ��ļ�
		/// </summary>
		/// <param name="iSwitch">�Ƿ��滻ԭ���ļ�</param>
		/// <param name="strFileAllName">�ļ���������·���ļ���</param>
		/// <returns>1:�ɹ� 0:ʧ�� </returns>
		public int UpFileSaveAs(int iSwitch, string strFileAllName)
		{
			int num3;
			if (strFileAllName == "")
			{
				return -2;
			}
			long num1 = this.GetUpFileContentLength();
			if (num1 > 4000000)
			{
				return -3;
			}
			strFileAllName = strFileAllName.Trim();
			string text1 = FileUtil.GetFileDictory(strFileAllName);
			text1 = FileUtil.GetDealedFilePath(text1);
			int num2 = FileUtil.DictoryCreate(text1);
			if (num2 != 1)
			{
				return -4;
			}
			bool flag1 = FileUtil.FileExists(strFileAllName);
			if ((iSwitch != 1) && flag1)
			{
				return -1;
			}
			try
			{
				this.FileUp.SaveAs(strFileAllName);
				num3 = 1;
			}
			catch (Exception exception1)
			{
				FileLog.WriteLog("\u6587\u4ef6\u4e0a\u4f20\u5931\u8d25", exception1.Message);
				num3 = 0;
			}
			return num3;
		}
 


	}
}
