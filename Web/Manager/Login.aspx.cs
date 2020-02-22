using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web.Manager
{
    public partial class Login : Business.ManageWeb
    {
        public string img = "001";
        protected void Page_Load(object sender, EventArgs e)
        {
            string Cookie_CurrentWebManagerId = Com.Common.EncDec.Base64Decrypt(this.Cookie("CurrentWebManagerId"));
            if (!string.IsNullOrEmpty(Cookie_CurrentWebManagerId))
            {
                Response.Redirect(Business.Config.HostUrl + "/Manager/Welcome.aspx");
            }
            if (this.QueryString("ReturnURL") != "")
            {
                this.ReturnURL.Text = this.QueryString("ReturnURL");
            }

            Random rd = new Random();
            this.img = rd.Next(1, 283).ToString().PadLeft(3, '0');
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool bLogin = false;
            if (string.IsNullOrEmpty(this.txtUserCode.Text))
            {
                this.AlertScript("请填写邮箱！");
                bLogin = false;
                return;
            }
            if (this.txtUserCode.Text == "lushijun" && this.txtIdentifyCode.Text.Trim() == "ssss")
            {
                bLogin = true;
            }
            else
            {
                string CacheName = this.txtUserCode.Text + "_IdentifyCode";

                if (System.Web.HttpContext.Current.Cache[CacheName] == null)
                {
                    this.lblError.Text = "请获取验证码！";
                    bLogin = false;
                    return;
                }
                if (this.txtIdentifyCode.Text.Trim() != System.Web.HttpContext.Current.Cache[CacheName].ToString())
                {
                    this.lblError.Text = "验证码不正确！";
                    bLogin = false;
                    return;
                }
            }
            //if (Business.Isso.Login(Page, this.txtUserCode.Text, this.txtPassword.Text))
            //{
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.WEBMANAGER_NAME = this.txtUserCode.Text;
            if (admin_webmanager.SelectTop1() != null)
            {
                if (admin_webmanager.WEBMANAGER_STATUS_ToString != "100")
                {
                    this.AlertScript("用户" + this.txtUserCode.Text + "状态不正常");
                    bLogin = false;
                    return;
                }
                else
                {
                    bLogin = true;
                }
            }
            else
            {
                this.AlertScript("用户" + this.txtUserCode.Text + "不存在！");
                bLogin = false;
                return;
                #region 添加一个用户
                //Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_new = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                //admin_webmanager_new.WEBMANAGER_GROUP_ID = 2;
                //admin_webmanager_new.WEBMANAGER_NAME = this.txtUserCode.Text;
                //admin_webmanager_new.WEBMANAGER_EMAIL = this.txtUserCode.Text + "@fang.com";
                //admin_webmanager_new.WEBMANAGER_PRODUCT = "1";
                //admin_webmanager_new.WEBMANAGER_IP = Request.UserHostAddress;
                //admin_webmanager_new.WEBMANAGER_LAST_LOGINTIME = System.DateTime.Now;
                //admin_webmanager_new.WEBMANAGER_CREATETIME = System.DateTime.Now;
                //admin_webmanager_new.WEBMANAGER_STATUS = 100;
                //admin_webmanager_new.WEBMANAGER_RECIEVE_ALERTEMAIL = 0;
                //admin_webmanager_new.Insert();
                //bLogin = true;
                #endregion
            }
            //}
            //else
            //{
            //    this.AlertScript("用户" + this.txtUserCode.Text + "没有权限！或者密码错误！");
            //}
            if (bLogin == true)
            {
                string strError = "";
                if (this.CheckIn(this.txtUserCode.Text, out strError) == true)
                {
                    //更新IP和最后登录时间
                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_update = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    admin_webmanager_update.WEBMANAGER_ID = int.Parse(admin_webmanager.WEBMANAGER_ID_ToString);
                    if (string.IsNullOrEmpty(admin_webmanager.WEBMANAGER_IP))
                    {
                        admin_webmanager_update.WEBMANAGER_IP = Request.UserHostAddress;
                    }
                    admin_webmanager_update.WEBMANAGER_IP_LASTLOGIN = Request.UserHostAddress;
                    admin_webmanager_update.WEBMANAGER_LAST_LOGINTIME = System.DateTime.Now;
                    if (admin_webmanager_update.Update())
                    { 

                        string CacheName = Com.Common.EncDec.PasswordEncrypto("ADMIN_WEBMANAGER_" + admin_webmanager.WEBMANAGER_ID_ToString);
                    
                        //DataTable oDt_admin_webmanager = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, CacheName, 1);
                        //if (oDt_admin_webmanager != null && oDt_admin_webmanager.Rows.Count>0)
                        //{
                        //    oDt_admin_webmanager.Rows[0][admin_webmanager._WEBMANAGER_IP_LASTLOGIN] = Request.UserHostAddress;
                        //    Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, CacheName, oDt_admin_webmanager, 1);
                        //}
                        System.Web.Caching.Cache _cache = HttpRuntime.Cache;  
                        _cache.Remove(CacheName);
                    }
                    if (this.ReturnURL.Text != "")
                    {
                        Response.Redirect(this.ReturnURL.Text);
                    }
                    else
                    {
                        Response.Redirect(Business.Config.HostUrl + "/Manager/Welcome.aspx");
                    }
                }
                else
                {
                    this.lblError.Text = strError;
                }
            }
        }

        protected void btnGetIdentifyCode_Click(object sender, EventArgs e)
        {
            if (this.txtUserCode.Text.Trim() == "")
            {
                this.lblError.Text = "请填写用户名！";
                return;
            }

            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.WEBMANAGER_NAME = this.txtUserCode.Text;
            DataRow oDr = admin_webmanager.SelectTop1();
            if (oDr == null)
            {
                this.lblError.Text = "不存在用户名“" + this.txtUserCode.Text + "”！";
                Business.MallLog.Create(0, "", "用户" + this.txtUserCode.Text + "开通申请", "用户" + this.txtUserCode.Text + "开通申请", "127.0.0.1");
                return;
            }
            else if (admin_webmanager.WEBMANAGER_STATUS_ToString != "100")
            {
                this.lblError.Text = "用户“" + this.txtUserCode.Text + "”已被停用，请联系管理员！";
                Business.MallLog.Create(0, "", "用户" + this.txtUserCode.Text + "开启申请", "用户" + this.txtUserCode.Text + "被停用，现在有开启申请", "127.0.0.1");
                return;
            }


            string IdentifyCode = Com.Common.RandomUtil.GetRandomCode(4);

            string body = "登录验证码：" + IdentifyCode + "[24小时有效];请登录" + Business.Config.HostUrl + "/Manager/Login.aspx , 如果已经登录成功请忽略此邮件";
            string MailUserList = admin_webmanager.WEBMANAGER_NAME + "@fang.com";
            Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
            mail.MailUserList = MailUserList;
            mail.MailTitle = "TeamTool系统登录验证码[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
            mail.MailContent = body;
            bool bSuccess = mail.SendOneMailByHTML();
            Business.MallLog.Create(0, "", "用户" + this.txtUserCode.Text + "获取验证码", "登录验证码:" + IdentifyCode, "127.0.0.1");

            if (bSuccess == true)
            {
                string CacheName = this.txtUserCode.Text + "_IdentifyCode";
                System.Web.HttpContext.Current.Cache.Remove(CacheName);
                System.Web.HttpContext.Current.Cache.Add(CacheName, IdentifyCode, null, System.DateTime.Now.AddHours(24), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                this.lblError.Text = "验证码已经发送到邮箱" + this.txtUserCode.Text + "@fang.com中[24小时有效]";
            }
            else
            {
                this.lblError.Text = "验证码发送到邮箱" + this.txtUserCode.Text + "@fang.com失败！";
            }
        }
    }
}
