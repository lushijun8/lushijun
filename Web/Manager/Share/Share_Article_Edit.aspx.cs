using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_Edit : Business.ManageWeb
    {
        private int P_Article_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_Edit.aspx");
            if (!string.IsNullOrEmpty(this.QueryString("Article_Id")))
            {
                this.P_Article_Id = int.Parse(Com.Common.EncDec.Decrypt(this.QueryString("Article_Id"), this.Encrypt_key));

            }
            else
            {
                return;
            }
            if (!Page.IsPostBack)
            {
                this.BindData();
            }

        }
        private void BindData()
        {
            Entity.TEAMTOOL.SHARE_ARTICLE share_article = new Entity.TEAMTOOL.SHARE_ARTICLE();
            share_article.ARTICLE_ID = this.P_Article_Id;
            if (share_article.SelectTop1() != null)
            {
                this.txt_Article_Title.Text = share_article.ARTICLE_TITLE;
                this.frtb_Article_text.Value = share_article.ARTICLE_TEXT;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Regex re = new Regex(@"src\s*=\s*(" + "\"" + "|')data:image", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (this.txt_Article_Title.Text.Trim() == "" || this.frtb_Article_text.Value.Trim() == "")
            {
                this.AlertScript("请填写完毕！");
                return;
            } 
            else if (re.Matches(this.frtb_Article_text.Value).Count > 0)
            {
                this.AlertScript("请不要从微信直接拷贝图片，因为微信的图片格式是base64编码，你可以下载到自己的电脑再通过本编辑器上传！");
                return;
            } 
            else
            {

                string Article_text = this.frtb_Article_text.Value;
                //=========================================
                //下载网上的图片到本地
                DateTime oNow = System.DateTime.Now;
                string ImagePath = "/UpFile" + "/Article/" + oNow.Year.ToString() +
                    "/" + oNow.Month.ToString().PadLeft(2, '0') + "/Img/";

                Com.File.FileUtil.FileCreate(Server.MapPath(ImagePath + "readme.txt"), 0);

                Article_text = SavePhotoFromUrl(Article_text, ImagePath, Server);

                Entity.TEAMTOOL.SHARE_ARTICLE share_article = new Entity.TEAMTOOL.SHARE_ARTICLE();
                share_article.ARTICLE_ID = this.P_Article_Id; 
                share_article.ARTICLE_TITLE = this.txt_Article_Title.Text.Trim();
                share_article.ARTICLE_TEXT = Article_text; 
                if (share_article.Update())//更新数据库成功！
                {
                    this.RedirectConfirm("编辑成功！", Business.Config.HostUrl + "/Manager/Share/Share_Article_List.aspx");
                   
                }
                else
                {
                    this.AlertScript("编辑失败！");
                }
            }
        }

        private string SavePhotoFromUrl(string Html, string Path, System.Web.HttpServerUtility Server)
        {
            Regex reimg = new Regex(@"(\<img(.*)>)|(\<input [^>]*? type=(" + "\"" + @"|')image(" + "\"" + @"|')[^>]*?>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (reimg.Matches(Html).Count > 0)
            {
                string img = reimg.Matches(Html)[0].Value;
                Regex re = new Regex(@"<(IMG|INPUT)[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                DataTable ImageTrans = new DataTable("ImageTrans");
                if (re.Matches(img).Count > 0)
                {
                    ImageTrans.Columns.Add("URL", typeof(string));//网址
                    ImageTrans.Columns.Add("LOCAL", typeof(string));//本地地址
                    ImageTrans.PrimaryKey = new DataColumn[] { ImageTrans.Columns["URL"] };
                }
                foreach (Match imgMatch in re.Matches(Html))
                {
                    string ImageUrl = imgMatch.Groups["src"].Value;
                    if (ImageUrl.ToUpper().StartsWith("HTTP://") &&
                        ImageTrans.Select("URL='" + ImageUrl + "'").Length == 0 &&
                        ImageUrl.ToUpper().IndexOf(Business.Config.HostUrl.ToUpper()) == -1)
                    {
                        try
                        {
                            string RandName = Business.Common.GenFileNameFromDateTime();
                            string vImageName = Path + RandName;// +"." + ImageUrl.Split('/')[ImageUrl.Split('/').Length - 1].Split('.')[1];
                            string imgname = ImageUrl.Split('/')[ImageUrl.Split('/').Length - 1];
                            bool have_suffix = false;
                            if (imgname.IndexOf(".") > -1)
                            {
                                vImageName += "." + imgname.Split('.')[1];
                                have_suffix = true;
                            }

                            string ImageName = Server.MapPath(vImageName);
                            string imagetype = "";
                            if (Com.Net.Image.SavePhotoFromUrl(ImageName, ImageUrl, out imagetype))
                            {
                                DataRow New = ImageTrans.NewRow();
                                New[0] = ImageUrl;
                                New[1] = Business.Config.HostUrl + vImageName + (have_suffix == true ? "" : ("." + imagetype));
                                ImageTrans.Rows.Add(New);
                                ImageTrans.AcceptChanges();
                            }
                        }
                        catch { }
                    }
                    else if (ImageUrl.ToUpper().StartsWith("/"))
                    {
                        DataRow[] oDrs = ImageTrans.Select("URL='" + ImageUrl + "'");
                        if (oDrs == null || oDrs.Length == 0)
                        {
                            DataRow New = ImageTrans.NewRow();
                            New[0] = ImageUrl;
                            New[1] = Business.Config.HostUrl + ImageUrl;
                            ImageTrans.Rows.Add(New);
                            ImageTrans.AcceptChanges();
                        }
                    }
                }

                if (re.Matches(img).Count > 0)
                {
                    foreach (DataRow oDr in ImageTrans.Rows)
                    {
                        Html = Html.Replace(oDr["URL"].ToString(), oDr["LOCAL"].ToString());
                    }
                }
                ImageTrans.Dispose();
            }
            return Html;
        }

    }
}