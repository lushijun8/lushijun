using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;

namespace Business
{
    //// <summary>
    /// ����WebClient.UploadData�����������������
    /// </summary>
    public class CreateBytes
    {
        Encoding encoding = Encoding.UTF8;

        /**/
        /// <summary>
        /// ƴ�����еĶ���������Ϊһ������
        /// </summary>
        /// <param name="byteArrays">����</param>
        /// <returns></returns>
        /// <remarks>���Ͻ����߽�</remarks>
        public byte[] JoinBytes(ArrayList byteArrays)
        {
            int length = 0;
            int readLength = 0;

            // ���Ͻ����߽�
            string endBoundary = Boundary + "--\r\n"; //�����߽�
            byte[] endBoundaryBytes = encoding.GetBytes(endBoundary);
            byteArrays.Add(endBoundaryBytes);

            foreach (byte[] b in byteArrays)
            {
                length += b.Length;
            }
            byte[] bytes = new byte[length];

            // ��������
            //
            foreach (byte[] b in byteArrays)
            {
                b.CopyTo(bytes, readLength);
                readLength += b.Length;
            }

            return bytes;
        }

        public bool UploadData(string uploadUrl, byte[] bytes, out byte[] responseBytes)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", ContentType);

            try
            {
                responseBytes = webClient.UploadData(uploadUrl, bytes);
                return true;
            }
            catch (WebException ex)
            {
                Stream resp = ex.Response.GetResponseStream();
                responseBytes = new byte[ex.Response.ContentLength];
                resp.Read(responseBytes, 0, responseBytes.Length);
            }
            return false;
        }

        /// <summary>
        /// ��ȡ��ͨ���������������
        /// </summary>
        /// <param name="fieldName">����</param>
        /// <param name="fieldValue">��ֵ</param>
        /// <returns></returns>
        /// <remarks>
        /// -----------------------------7d52ee27210a3c\r\nContent-Disposition: form-data; name=\"����\"\r\n\r\n��ֵ\r\n
        /// </remarks>
        public byte[] CreateFieldData(string fieldName, string fieldValue)
        {
            string textTemplate = Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
            string text = String.Format(textTemplate, fieldName, fieldValue);
            byte[] bytes = encoding.GetBytes(text);
            return bytes;
        }


        /**/
        /// <summary>
        /// ��ȡ�ļ��ϴ����������������
        /// </summary>
        /// <param name="fieldName">����</param>
        /// <param name="filename">�ļ���</param>
        /// <param name="contentType">�ļ�����</param>
        /// <param name="contentLength">�ļ�����</param>
        /// <param name="stream">�ļ���</param>
        /// <returns>����������</returns>
        public byte[] CreateFieldData(string fieldName, string filename, string contentType, byte[] fileBytes)
        {
            string end = "\r\n";
            string textTemplate = Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";

            // ͷ����
            string data = String.Format(textTemplate, fieldName, filename, contentType);
            byte[] bytes = encoding.GetBytes(data);



            // β����
            byte[] endBytes = encoding.GetBytes(end);

            // �ϳɺ������
            byte[] fieldData = new byte[bytes.Length + fileBytes.Length + endBytes.Length];

            bytes.CopyTo(fieldData, 0); // ͷ����
            fileBytes.CopyTo(fieldData, bytes.Length); // �ļ��Ķ���������
            endBytes.CopyTo(fieldData, bytes.Length + fileBytes.Length); // \r\n

            return fieldData;
        }


        #region ����
        public string Boundary
        {
            get
            {
                string[] bArray, ctArray;
                string contentType = ContentType;
                ctArray = contentType.Split(';');
                if (ctArray[0].Trim().ToLower() == "multipart/form-data")
                {
                    bArray = ctArray[1].Split('=');
                    return "--" + bArray[1];
                }
                return null;
            }
        }

        public string ContentType
        {
            get
            {
                //if (HttpContext.Current == null)
                //{
                return "multipart/form-data; boundary=---------------------------7d5b915500cee";
                //}
                //return HttpContext.Current.Request.ContentType;
            }
        }
        #endregion
    }
}
