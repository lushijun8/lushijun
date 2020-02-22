using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;

namespace Web.Manager
{
    public partial class Login_Qrcode : Business.ManageWeb
    {
        private string P_Url = "";
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!string.IsNullOrEmpty(this.QueryString("url")))
            {
                this.P_Url = this.QueryString("url");
            }
            else
            {
                this.P_Url = Page.Request.Url.Host.ToString();
            }
            this.BindData(this.P_Url);             
        }
        private void BindData(string url)
        {
            Response.ContentType = "image/jpeg";
            Bitmap bitmap = Com.Drawing.QrCode.GetDimensionalCode(url);
            bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);

        }
    }
}