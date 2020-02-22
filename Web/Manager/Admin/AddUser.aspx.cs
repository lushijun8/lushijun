using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
namespace Web.Manager.Admin
{
    public partial class AddUser : Business.ManageWeb
    {
        private string P_WebManager_Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/AddUser.aspx");
            this.P_WebManager_Id = Com.Common.EncDec.Decrypt(this.QueryString("WebManager_Id"), this.Encrypt_key);
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.ADMIN_PRODUCT pay_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                //pay_product.SelectColumns = new string[] { pay_product._PRODUCTID, pay_product._PRODUCTNAME };
                if (!string.IsNullOrEmpty(this.CurrentWebManagerProduct))
                {
                    pay_product.Split_Or_And = true;
                    pay_product[pay_product._PRODUCTID] = this.CurrentWebManagerProduct;
                }
                else
                {
                    pay_product.PRODUCTID = -100;
                }
                pay_product.Distinct = true;
                pay_product.CacheTime = 30;
                DataTable oDt = pay_product.Select();
                this.ddlProduct.DataSource = oDt;
                this.ddlProduct.DataValueField = pay_product._PRODUCTID;
                this.ddlProduct.DataTextField = pay_product._PRODUCTNAME;
                this.ddlProduct.DataBind();
                //=====================================================================
                Entity.TEAMTOOL.ADMIN_WEBMANAGER_GROUP admin_webmanager_group = new Entity.TEAMTOOL.ADMIN_WEBMANAGER_GROUP();
                //if (!this.CurrentIsAdmin)
                //{
                //    admin_webmanager_group.GROUP_ID = 6;
                //}
                admin_webmanager_group.Distinct = true;
                admin_webmanager_group.CacheTime = 60;
                DataTable oDt_admin_webmanager_group = admin_webmanager_group.Select();
                this.ddlWebManager_Group_id.DataSource = oDt_admin_webmanager_group;
                this.ddlWebManager_Group_id.DataValueField = admin_webmanager_group._GROUP_ID;
                this.ddlWebManager_Group_id.DataTextField = admin_webmanager_group._GROUP_NAME;
                this.ddlWebManager_Group_id.DataBind();
                //====================================================================
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_LEADER_LEVEL = 1;
                admin_webmanager.WEBMANAGER_STATUS = 100;
                admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_LEADER_REALNAME };
                admin_webmanager.CacheTime = 1440;
                DataTable dt_admin_webmanager = admin_webmanager.Select();
                this.ddlWebManager_leader_realname.DataSource = dt_admin_webmanager;
                this.ddlWebManager_leader_realname.DataValueField = admin_webmanager._WEBMANAGER_LEADER_REALNAME;
                this.ddlWebManager_leader_realname.DataTextField = admin_webmanager._WEBMANAGER_LEADER_REALNAME;
                this.ddlWebManager_leader_realname.DataBind();

                if (!string.IsNullOrEmpty(this.P_WebManager_Id))
                {
                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_select = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    admin_webmanager_select.WEBMANAGER_ID = int.Parse(this.P_WebManager_Id);
                    if (admin_webmanager_select.SelectTop1() != null)
                    {
                        this.ddlProduct.ClearSelection();
                        this.ddlProduct.SelectedValue = admin_webmanager_select.WEBMANAGER_PRODUCT;
                        this.ddlWebManager_Group_id.ClearSelection();
                        this.ddlWebManager_Group_id.SelectedValue = admin_webmanager_select.WEBMANAGER_GROUP_ID_ToString;
                        this.ddlWebManager_leader_realname.ClearSelection();
                        this.ddlWebManager_leader_realname.SelectedValue = admin_webmanager_select.WEBMANAGER_LEADER_REALNAME;
                        this.ddlWebManager_leader_level.ClearSelection();
                        this.ddlWebManager_leader_level.SelectedValue = admin_webmanager_select.WEBMANAGER_LEADER_LEVEL_ToString;

                        this.txtWebManager_Email.Text = admin_webmanager_select.WEBMANAGER_EMAIL;
                        this.txtWebManager_mobile.Text = admin_webmanager_select.WEBMANAGER_MOBILE;
                        this.txtWebManager_name.Text = admin_webmanager_select.WEBMANAGER_NAME;
                        this.txtWebManager_realname.Text = admin_webmanager_select.WEBMANAGER_REALNAME;
                        this.ddlWebManager_Recieve_AlertEmail.Text = admin_webmanager_select.WEBMANAGER_RECIEVE_ALERTEMAIL_ToString;

                        this.txtWebManager_name.ReadOnly = true;
                        this.txtWebManager_name.Enabled = false;
                    }
                }
            }
        }

        public static bool IsValidMobileNo(string MobileNo)
        {
            const string regPattern = @"^1[3|4|5|6|7|8|][0-9]{9}$";
            return Regex.IsMatch(MobileNo, regPattern);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtWebManager_Email.Text.Trim() == "" ||
               this.txtWebManager_name.Text.Trim() == "")
            {
                this.AlertScript("请填写必填项！");
                return;
            }
            if (!string.IsNullOrEmpty(this.P_WebManager_Id))
            { 
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_update = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager_update.WEBMANAGER_ID = int.Parse(this.P_WebManager_Id);
                admin_webmanager_update.WEBMANAGER_GROUP_ID = int.Parse(this.ddlWebManager_Group_id.SelectedItem.Value);
                admin_webmanager_update.WEBMANAGER_PRODUCT = this.ddlProduct.SelectedItem.Value;
                admin_webmanager_update.WEBMANAGER_RECIEVE_ALERTEMAIL = int.Parse(this.ddlWebManager_Recieve_AlertEmail.SelectedItem.Value);
                admin_webmanager_update.WEBMANAGER_LEADER_LEVEL = int.Parse(this.ddlWebManager_leader_level.SelectedValue);
                admin_webmanager_update.WEBMANAGER_LEADER_REALNAME = this.ddlWebManager_leader_realname.SelectedValue;

                admin_webmanager_update.WEBMANAGER_NAME = this.txtWebManager_name.Text.Trim();
                admin_webmanager_update.WEBMANAGER_REALNAME = this.txtWebManager_realname.Text.Trim(); 
                admin_webmanager_update.WEBMANAGER_EMAIL = this.txtWebManager_Email.Text.Trim();
                admin_webmanager_update.WEBMANAGER_MOBILE = this.txtWebManager_mobile.Text.Trim(); 
                if (admin_webmanager_update.Update())
                {
                    this.RedirectConfirmScript("修改成功！" , Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                else
                {
                    this.ltrMsg.Text = "修改失败！";
                }
            }
            else
            {

                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.WEBMANAGER_NAME = this.txtWebManager_name.Text;
                DataRow oDr = admin_webmanager.SelectTop1();
                if (oDr != null)
                {
                    this.ltrMsg.Text = "用户“" + this.txtWebManager_name.Text + "”已存在！";
                    return;
                }
                string Password = Com.Common.RandomUtil.GetRandomCode(8);
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_insert = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager_insert.WEBMANAGER_GROUP_ID = int.Parse(this.ddlWebManager_Group_id.SelectedItem.Value);
                admin_webmanager_insert.WEBMANAGER_PRODUCT = this.ddlProduct.SelectedItem.Value;
                admin_webmanager_insert.WEBMANAGER_NAME = this.txtWebManager_name.Text.Trim();
                admin_webmanager_insert.WEBMANAGER_REALNAME = this.txtWebManager_realname.Text.Trim();
                admin_webmanager_insert.WEBMANAGER_PASSWORD = Com.Common.EncDec.PasswordEncrypto(Password);
                admin_webmanager_insert.WEBMANAGER_EMAIL = this.txtWebManager_Email.Text.Trim();
                admin_webmanager_insert.WEBMANAGER_MOBILE = this.txtWebManager_mobile.Text.Trim();
                admin_webmanager_insert.WEBMANAGER_CREATETIME = System.DateTime.Now;
                admin_webmanager_insert.WEBMANAGER_REMARK = "";
                admin_webmanager_insert.WEBMANAGER_STATUS = 100;
                admin_webmanager_insert.WEBMANAGER_RECIEVE_ALERTEMAIL = int.Parse(this.ddlWebManager_Recieve_AlertEmail.SelectedItem.Value);
                admin_webmanager_insert.WEBMANAGER_LEADER_LEVEL = int.Parse(this.ddlWebManager_leader_level.SelectedValue);
                admin_webmanager_insert.WEBMANAGER_LEADER_REALNAME = this.ddlWebManager_leader_realname.SelectedValue;
                if (admin_webmanager_insert.Insert())
                {
                    string body = "恭喜您成功开通" + this.CurrentWebTitle + "权限,用户名：" + this.txtWebManager_name.Text.Trim() + ",密码同单点登录密码;请及时登录<a href=\"" + Business.Config.HostUrl + "/Manager/Login.aspx\">" + Business.Config.HostUrl + "/Manager/Login.aspx</a> , 如果已经登录成功请忽略此邮件。";
                    string MailUserList = this.txtWebManager_name.Text.Trim() + "@fang.com";

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailUserList = MailUserList;
                    mail.MailTitle = "恭喜您成功开通" + this.CurrentWebTitle + "权限[系统邮件请勿回复]";
                    mail.MailContent = body;
                    string error = "";
                    if (!mail.SendOneMailByHTML())
                    {
                        error += "但是发送邮件失败！";
                    }

                    Business.MallLog.Create(0, "", this.CurrentWebManagerName + ",添加用户“" + this.txtWebManager_name.Text.Trim() + "”成功！" + error, "", "127.0.0.1");
                    this.RedirectConfirmScript("添加成功！" + error, Business.Config.HostUrl + "/Manager/Admin/UserList.aspx");
                }
                else
                {
                    this.ltrMsg.Text = "添加失败！";
                }
            }

        }
    }
}