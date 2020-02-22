using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;

namespace Com.Drawing
{
    public class QrCode
    {
        /// <summary>
        /// 根据链接获取二维码
        /// </summary>
        /// <param name="link">链接</param>
        /// <returns>返回二维码图片</returns>
        public static Bitmap GetDimensionalCode(string link)
        {
            Bitmap bmp = null;
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                bmp = qrCodeEncoder.Encode(link);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Invalid version !");
            }
            return bmp;
        }
    }
}
