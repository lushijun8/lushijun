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
        /// 解压zip文件
        /// </summary>
        /// <param name="sourceFile">要解压的源文件</param>
        /// <param name="desFile">解压到得目标位置</param>
        public static void UnZip(string sourceFile, string desFile)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {                 
                string directoryName = Path.GetDirectoryName(desFile);
                string fileName = Path.GetFileName(theEntry.Name);

                //生成解压目录   
                Directory.CreateDirectory(directoryName);

                if (fileName != String.Empty)
                {
                    //解压文件到指定的目录   
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
