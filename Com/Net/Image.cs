using System;
using System.Net;
using System.IO;

namespace Com.Net
{
	/// <summary>
	/// Image 的摘要说明。
	/// </summary>
	public class Image
	{
		public Image()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 从图片地址下载图片到本地磁盘
		/// </summary>
		/// <param name="ToLocalPath">图片本地磁盘地址</param>
		/// <param name="Url">图片网址</param>
		/// <returns></returns>
        public static bool SavePhotoFromUrl(string FileName, string Url, out string imagetype)
		{
			bool Value=false;
			WebResponse response = null;
			Stream stream = null;
            imagetype = "";

			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
							
				response = request.GetResponse();
				stream = response.GetResponseStream();	

				if( !response.ContentType.ToLower().StartsWith("text/") )
                {
                    string[] filenames = FileName.Split('/');
                    if (filenames[filenames.Length - 1].IndexOf(".") == -1)
                    {
                        string[] imagetypes=new string[]{"jpg","jpeg","bmp","png","gif"};
                        foreach(string type in imagetypes)
                        {
                            if(response.ContentType.ToLower().IndexOf(type)>-1)
                            {
                                FileName += "." + type;
                                imagetype = type;
                                break;
                            }
                        }
                    }
					Value=Image.SaveBinaryFile(response,FileName);
				}

			}
			catch(Exception err)
			{
				string aa=err.ToString();
			}
			return Value;
		}
		/// <summary>
		/// Save a binary file to disk.
		/// </summary>
		/// <param name="response">The response used to save the file</param>
		// 将二进制文件保存到磁盘
		private static bool SaveBinaryFile(WebResponse response,string FileName)
		{
			bool Value=true;
			byte []buffer = new byte[1024];

			try
			{
				if(Com.File.FileUtil.FileExists(FileName))
					Com.File.FileUtil.DeleteFile(FileName);
				Stream outStream =System.IO.File.Create( FileName );
				Stream inStream = response.GetResponseStream();	
			
				int l;
				do
				{
					l = inStream.Read(buffer,0,buffer.Length);
					if(l>0)
						outStream.Write(buffer,0,l);
				}
				while(l>0);
			
				outStream.Close();
				inStream.Close();
			}
			catch
			{
				Value=false;
			}
			return Value;
		}
	}
}
