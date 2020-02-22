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

namespace Web.Manager.Admin
{
    public partial class PassWord : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/PassWord.aspx");
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_user = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_user.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
                admin_user.SelectTop1();
                this.txt_Email.Text = admin_user.WEBMANAGER_EMAIL;
                this.txt_Mobile.Text = admin_user.WEBMANAGER_MOBILE;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txt_Password.Text.Trim() == "" || this.txt_Password_New.Text.Trim() == "" || this.txt_Password_New1.Text.Trim() == "")
            {
                this.ltrError.Text = "����д������";
                return;
            }
            if (this.txt_Password_New.Text.Trim() != this.txt_Password_New1.Text.Trim())
            {
                this.ltrError.Text = "ȷ�����벻��ȷ��";
                return;
            }
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_user = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_user.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
            DataTable oDt = admin_user.Select();
            if (oDt.Rows[0][admin_user._WEBMANAGER_PASSWORD].ToString() != Com.Common.EncDec.PasswordEncrypto(this.txt_Password.Text))
            {
                this.ltrError.Text = "ԭ���벻��ȷ��";
                return;
            }

            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_user1 = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_user1.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
            admin_user1.WEBMANAGER_PASSWORD = Com.Common.EncDec.PasswordEncrypto(this.txt_Password_New.Text);
            if (admin_user1.Update())
            {
                this.ltrError.Text = "�����޸ĳɹ���";
            }
            else
            {
                this.ltrError.Text = "�����޸�ʧ�ܣ���͹���Ա��ϵ��";
            }

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (this.txt_Mobile.Text.Trim() == "" || this.txt_Email.Text.Trim() == "" )
            {
                this.ltrError1.Text = "����д������";
                return;
            }            

            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_user1 = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_user1.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
            admin_user1.WEBMANAGER_EMAIL = this.txt_Email.Text;
            admin_user1.WEBMANAGER_MOBILE = this.txt_Mobile.Text;
            if (admin_user1.Update())
            {
                this.ltrError1.Text = "�����޸ĳɹ���";
            }
            else
            {
                this.ltrError1.Text = "�����޸�ʧ�ܣ���͹���Ա��ϵ��";
            }
        }
    }
}
