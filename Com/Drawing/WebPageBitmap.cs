using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Com.Drawing
{
    public class WebPageBitmap
    {
        Bitmap m_Bitmap;
        string m_Url;
        int Width;
        public WebPageBitmap(string Url, int iWidth)
        {
            m_Url = Url;
            Width = iWidth; 
        }
        public static Bitmap GetImage(string Url, int iWidth)
        {
            WebPageBitmap thumbnailGenerator = new WebPageBitmap(Url, iWidth);
            return thumbnailGenerator.GenerateWebSiteThumbnailImage();
        }
        public Bitmap GenerateWebSiteThumbnailImage()
        {
            Thread m_thread = new Thread(new ThreadStart(_GenerateWebSiteThumbnailImage));
            m_thread.SetApartmentState(ApartmentState.STA);
            m_thread.Start();
            m_thread.Join();
            return m_Bitmap;
        }
        private void _GenerateWebSiteThumbnailImage()
        {
            WebBrowser m_WebBrowser = new WebBrowser();
            m_WebBrowser.ScrollBarsEnabled = false;
            m_WebBrowser.Navigate(m_Url);
            m_WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            while (m_WebBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            m_WebBrowser.Dispose();
        }
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser m_WebBrowser = (WebBrowser)sender;
            int Height = m_WebBrowser.Document.Body.ScrollRectangle.Height;
            m_WebBrowser.ClientSize = new Size(Width, Height);
            m_WebBrowser.ScrollBarsEnabled = false;
            m_Bitmap = new Bitmap(Width, Height);
            m_WebBrowser.BringToFront();
            m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds);
            m_Bitmap = (Bitmap)m_Bitmap.GetThumbnailImage(Width, Height, null, IntPtr.Zero);
        }
    }
}