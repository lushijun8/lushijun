using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using System.IO;
namespace Business
{
    public  class Zip
    {
        /// <summary>
        /// ��ѹzip�ļ�
        /// </summary>
        /// <param name="sourceFile">Ҫ��ѹ��Դ�ļ�</param>
        /// <param name="desFile">��ѹ����Ŀ��λ��</param>
        public static void UnZip(string sourceFile, string desFile)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {                 
                string directoryName = Path.GetDirectoryName(desFile);
                string fileName = Path.GetFileName(theEntry.Name);

                //���ɽ�ѹĿ¼   
                Directory.CreateDirectory(directoryName);

                if (fileName != String.Empty)
                {
                    //��ѹ�ļ���ָ����Ŀ¼   
                    FileStream streamWriter = File.Create(desFile + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
        }
        
    }
}
