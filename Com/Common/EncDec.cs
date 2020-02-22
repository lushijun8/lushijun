using System;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Com.File;


namespace Com.Common
{
    /// <summary>
    /// EncDec 的摘要说明。
    /// </summary>
    public class EncDec
    {
        public EncDec()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt); 

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            if (pToDecrypt == null || pToDecrypt == "")
            {
                return "";
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            try
            {
                cs.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Common.EncDec.Decrypt(string pToDecrypt,string sKey)", ex.Message);
            }

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        public static string Base64Decrypt(string CryptText)
        {
            byte[] buffer1 = Convert.FromBase64String(CryptText);
            return EncDec.ByteToChineseString(buffer1);
        }

        public static string Base64Encrypt(string PlainText)
        {
            byte[] buffer1 = EncDec.ChineseStringToByte(PlainText);
            return Convert.ToBase64String(buffer1, 0, buffer1.Length);
        }

        public static char ByteToChineseChar(byte bHigh, byte bLow)
        {
            uint num1 = (uint)((bHigh * 0x100) + bLow);
            return Convert.ToChar(num1);
        }

        public static string ByteToChineseString(byte[] bIn)
        {
            string text1 = "";
            for (int num1 = 0; num1 < bIn.Length; num1 += 2)
            {
                text1 = text1 + EncDec.ByteToChineseChar(bIn[num1], bIn[num1 + 1]);
            }
            return text1;
        }

        public static byte[] ChineseCharToByte(char cIn)
        {
            byte[] buffer1 = new byte[2];
            uint num1 = cIn;
            buffer1[0] = (byte)(num1 / 0x100);
            buffer1[1] = (byte)(num1 - (buffer1[0] * 0x100));
            return buffer1;
        }

        public static byte[] ChineseStringToByte(string strIn)
        {
            char[] chArray1 = strIn.ToCharArray();
            byte[] buffer1 = new byte[chArray1.Length * 2];
            for (int num1 = 0; num1 < chArray1.Length; num1++)
            {
                byte[] buffer2 = EncDec.ChineseCharToByte(chArray1[num1]);
                buffer1[num1 * 2] = buffer2[0];
                buffer1[(num1 * 2) + 1] = buffer2[1];
            }
            return buffer1;
        }

        public static string GetDecString(string EncString)
        {
            string text1 = "";
            for (int num1 = 0; num1 < EncString.Length; num1++)
            {
                text1 = text1 + ((EncString[num1] - '\n') + '\x0002');
            }
            return text1;
        }

        public static string GetEncString(string OriginString)
        {
            string text1 = "";
            for (int num1 = 0; num1 < OriginString.Length; num1++)
            {
                text1 = text1 + ((OriginString[num1] + '\n') - '\x0002');
            }
            return text1;
        }

        public static string PasswordEncrypto(string sPassword)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sPassword, "md5");
        }

        public static string PasswordEncrypto(string sPassword, string sFormat)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sPassword, sFormat);
        }

        public static string RC2Decrpt(string CryptText)
        {
            byte[] buffer1 = new byte[0x10] { 0x5b, 0x12, 4, 0x93, 0x4c, 0x4e, 0xbd, 0, 0x53, 0x63, 0x71, 0x8a, 0xd9, 0x4e, 70, 0x2d };
            byte[] buffer2 = new byte[8] { 140, 0x33, 0x68, 0x4b, 0x71, 0xbf, 0xf3, 9 };
            RC2CryptoServiceProvider provider1 = new RC2CryptoServiceProvider();
            ICryptoTransform transform1 = provider1.CreateDecryptor(buffer1, buffer2);
            string[] textArray1 = CryptText.Split(",".ToCharArray());
            byte[] buffer3 = new byte[textArray1.Length];
            for (int num1 = 0; num1 < buffer3.Length; num1++)
            {
                buffer3[num1] = Convert.ToByte(textArray1[num1]);
            }
            byte[] buffer4 = transform1.TransformFinalBlock(buffer3, 0, buffer3.Length);
            return EncDec.ByteToChineseString(buffer4);
        }

        public static string RC2Encrypt(string PlainText)
        {
            string text1 = "";
            byte[] buffer1 = new byte[0x10] { 0x5b, 0x12, 4, 0x93, 0x4c, 0x4e, 0xbd, 0, 0x53, 0x63, 0x71, 0x8a, 0xd9, 0x4e, 70, 0x2d };
            byte[] buffer2 = new byte[8] { 140, 0x33, 0x68, 0x4b, 0x71, 0xbf, 0xf3, 9 };
            RC2CryptoServiceProvider provider1 = new RC2CryptoServiceProvider();
            ICryptoTransform transform1 = provider1.CreateEncryptor(buffer1, buffer2);
            byte[] buffer3 = EncDec.ChineseStringToByte(PlainText);
            byte[] buffer4 = transform1.TransformFinalBlock(buffer3, 0, buffer3.Length);
            for (int num1 = 0; num1 < buffer4.Length; num1++)
            {
                text1 = text1 + Convert.ToString(buffer4[num1]) + ",";
            }
            return text1.Substring(0, text1.Length - 1);
        }

        public static bool Base64DecryptFile(string strInFilePath, string strOutFilePath)
        {
            bool Value = true;
            string text1 = "";
            try
            {

                text1 = File.FileUtil.GetFileContent(strInFilePath, "GB2312");
                File.FileUtil.FileCreate(strOutFilePath, 1);
                File.FileUtil.WriteFileContent(strOutFilePath, EncDec.Base64Decrypt(text1));
            }
            catch (Exception exception1)
            {
                File.FileLog.WriteLog("\u6539\u5199\u6587\u4ef6", exception1.Message);
                Value = false;
            }
            return Value;
        }
        public static bool Base64EncryptFile(string strInFilePath, string strOutFilePath)
        {
            bool Value = true;
            string text1 = "";
            try
            {

                text1 = File.FileUtil.GetFileContent(strInFilePath, "GB2312");
                File.FileUtil.FileCreate(strOutFilePath, 1);
                File.FileUtil.WriteFileContent(strOutFilePath, EncDec.Base64Encrypt(text1));
            }
            catch (Exception exception1)
            {
                File.FileLog.WriteLog("\u6539\u5199\u6587\u4ef6", exception1.Message);
                Value = false;
            }
            return Value;
        }
        public static bool RC2DecrptFile(string strInFilePath, string strOutFilePath)
        {
            bool Value = true;
            string text1 = "";
            try
            {

                text1 = File.FileUtil.GetFileContent(strInFilePath, "GB2312");
                File.FileUtil.FileCreate(strOutFilePath, 1);
                File.FileUtil.WriteFileContent(strOutFilePath, EncDec.RC2Decrpt(text1));
            }
            catch (Exception exception1)
            {
                File.FileLog.WriteLog("\u6539\u5199\u6587\u4ef6", exception1.Message);
                Value = false;
            }
            return Value;
        }
        public static bool RC2EncryptFile(string strInFilePath, string strOutFilePath)
        {
            bool Value = true;
            string text1 = "";
            try
            {

                text1 = File.FileUtil.GetFileContent(strInFilePath, "GB2312");
                File.FileUtil.FileCreate(strOutFilePath, 1);
                File.FileUtil.WriteFileContent(strOutFilePath, EncDec.RC2Encrypt(text1));
            }
            catch (Exception exception1)
            {
                File.FileLog.WriteLog("\u6539\u5199\u6587\u4ef6", exception1.Message);
                Value = false;
            }
            return Value;
        }
    }
}