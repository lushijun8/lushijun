using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
namespace Web.Manager.Share
{
    public partial class Share_Article_View_Image : Business.ManageWeb
    {
        private string P_PageUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.QueryString("Article_Id")))
            {
                this.P_PageUrl = Business.Config.HostUrl + "/Manager/Share/Share_Article_View_1.aspx?Article_Id=" + this.QueryString("Article_Id");
            }
            else if (!string.IsNullOrEmpty(this.QueryString("pageurl")))
            {
                this.P_PageUrl = Com.Common.EncDec.Decrypt(this.QueryString("pageurl"), this.Encrypt_key);
            }
            if (!string.IsNullOrEmpty(this.P_PageUrl))
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            Response.ContentType = "image/jpeg";
            Bitmap bitmap = Com.Drawing.WebPageBitmap.GetImage(this.P_PageUrl, 860);
            bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);

        }
    }
}