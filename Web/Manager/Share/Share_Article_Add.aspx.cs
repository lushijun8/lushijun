using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Share
{
    public partial class Share_Article_Add : Business.ManageWeb
    {
        string P_WebManager_name = "";
        string P_Date = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Share/Share_Article_Add.aspx");
            string v = this.QueryString("v");
            if (!string.IsNullOrEmpty(v))
            {
                v = Com.Common.EncDec.Decrypt(v, "fang.com");
                this.P_WebManager_name = v.Split('|')[0];
                this.P_Date = v.Split('|')[1];
            }
            if (!Page.IsPostBack)
            {
                if (this.CurrentIsAdmin == true)
                {
                    this.cb_SendEmail.Visible = true;
                    this.cb_SendEmail.Checked = false;
                }
                else
                {
                    this.cb_SendEmail.Visible = false;
                    this.cb_SendEmail.Checked = true;
                }
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
                share_article.ARTICLE_TYPE = 1;
                share_article.ARTICLE_SHARE_WEBMANAGER_NAME = this.CurrentWebManagerName;
                share_article.ARTICLE_TITLE = this.txt_Article_Title.Text.Trim();
                share_article.ARTICLE_TEXT = Article_text;
                share_article.ARTICLE_CREATETIME = System.DateTime.Now;
                share_article.ARTICLE_DELETED = 0;
                if (share_article.Insert())//添加到数据库成功！
                {
                    System.Threading.Thread.Sleep(2000);
                    if (this.cb_SendEmail.Checked == true)
                    {
                        //发邮件
                        Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                        admin_webmanager.Select();
                        string MailUserList = "";
                        while (admin_webmanager.Next())
                        {
                            MailUserList += admin_webmanager.WEBMANAGER_NAME + "@fang.com,";
                        }
                        //MailUserList = "lushijun@fang.com,sogogo1@126.com";
                        if (!string.IsNullOrEmpty(MailUserList))
                        {
                            string Article_Id_Encrypt = Com.Common.EncDec.Encrypt(share_article.ARTICLE_ID_ToString, this.Encrypt_key);
                            string Image_PageUrl = Business.Config.HostUrl + "/Manager/Share/Share_Article_View_1.aspx?Article_Id=" + Article_Id_Encrypt ;

                            Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                            mail.MailUserList = MailUserList.TrimEnd(',');
                            mail.MailTitle = this.CurrentWebManagerRealName + "分享的：" + this.txt_Article_Title.Text.Trim();
                            mail.MailContent =
                                "<p><b>如果你觉得 " + this.CurrentWebManagerRealName + " 分享的内容很棒，立刻给TA <a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_Good.aspx?Article_Id=" + int.Parse(share_article.ARTICLE_ID_ToString) + "\">点赞</a> 吧！</b><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View.aspx?Article_Id=" + Article_Id_Encrypt + "\">查看原文</a></p>" +
                                 "<img src=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View_Image.aspx?pageurl=" + Com.Common.EncDec.Encrypt(Image_PageUrl, this.Encrypt_key) + "\" width=\"860\"/>" +
                                "<p><b>如果你觉得 " + this.CurrentWebManagerRealName + " 分享的内容很棒，立刻给TA <a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_Good.aspx?Article_Id=" + int.Parse(share_article.ARTICLE_ID_ToString) + "\">点赞</a> 吧！</b><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View.aspx?Article_Id=" + Article_Id_Encrypt + "\">查看原文</a></p>"+
                                "<p><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_List.aspx\">看看大家曾经分享了什么？</a></p>";
                            if (!mail.SendOneMailByHTML())
                            {
                                Business.MallLog.Create(0, "Web.Report", this.CurrentWebManagerRealName + "在TeamTool分享文章失败", "发送给" + MailUserList + "失败", Request.UserHostAddress);
                                this.RedirectConfirm("插入数据库成功，但是发邮件失败！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                            }
                            else
                            {
                                this.RedirectConfirm("分享成功！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                                //随机给奖品
                            }
                        }
                    }
                    else
                    {
                        this.RedirectConfirm("分享成功！", Business.Config.HostUrl + "/Manager/Welcome.aspx");
                    }
                    #region 更新任务表Task
                    Entity.TEAMTOOL.TASK task_update = new Entity.TEAMTOOL.TASK();
                    task_update.PrimaryKey = new string[]{""};
                    //task_update.TASK_PAGEURL_OR_SQL_MD5 = this.CurrentWebManagerName + "," + DateTime.Now.ToString("yyyyMMdd") + ",share";
                    task_update.UpdateWhereSql = 
                        task_update._TASK_FINISHED + "=0 and " +
                        task_update._TASK_TYPE + "=2 and " +
                        task_update._TASK_WEBMANAGER_NAME + "='" + this.CurrentWebManagerName + "' ";

                    task_update.TASK_FINISHED = 1;
                    task_update.TASK_FINISHED_TIME = DateTime.Now;
                    task_update.TASK_WEBMANAGER_NAME_FINISHED = this.CurrentWebManagerName;

                    task_update.Update();
                    #endregion
                }
                else
                {
                    Business.MallLog.Create(0, "share_article.Insert", this.CurrentWebManagerRealName + "分享文章失败", this.txt_Article_Title.Text + ";" + Article_text, Request.UserHostAddress);
                    this.AlertScript("分享失败！");
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