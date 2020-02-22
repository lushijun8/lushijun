using System;
using System.Collections.Generic;

using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_Edit : Business.ManageWeb
    {
        protected int P_DataBase_Id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_Edit.aspx");
            if (this.QueryString("DataBase_Id") != "")
            {
                this.P_DataBase_Id = int.Parse(Com.Common.EncDec.Decrypt(this.QueryString("DataBase_Id"), this.Encrypt_key).Split(',')[0]);
            }
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.DATABASE_ID = this.P_DataBase_Id;
            database_owner.SelectColumns = new string[] {
                database_owner._DATABASE_NAME,
                database_owner._DATABASE_REMARK,
                database_owner._DATABASE_IP_LOCAL,
                database_owner._DATABASE_IP_ROMOTE,
                database_owner._DATABASE_VIP_LOCAL,
                database_owner._DATABASE_VIP_ROMOTE,
                database_owner._DATABASE_IP_SPECIAL,
                database_owner._DATABASE_IP_RECOVERY,
                database_owner._DATABASE_ADMIN_USER,
                database_owner._DATABASE_ADMIN_PASSWORD ,
                database_owner._DATABASE_READER_USER,
                database_owner._DATABASE_READER_PASSWORD ,
                database_owner._DATABASE_WRITER_USER,
                database_owner._DATABASE_WRITER_PASSWORD           
        };
            database_owner.SelectTop1();

            this.txt_DataBase_Name.Text = database_owner.DATABASE_NAME;
            this.txt_DataBase_Remark.Text = database_owner.DATABASE_REMARK;
            this.txt_DataBase_IP_Local.Text = database_owner.DATABASE_IP_LOCAL;
            this.txt_DataBase_IP_Romote.Text = database_owner.DATABASE_IP_ROMOTE;
            this.txt_DataBase_VIP_Local.Text = database_owner.DATABASE_VIP_LOCAL;
            this.txt_DataBase_VIP_Romote.Text = database_owner.DATABASE_VIP_ROMOTE;
            this.txt_DataBase_IP_Special.Text = database_owner.DATABASE_IP_SPECIAL;
            this.txt_DataBase_IP_Recovery.Text = database_owner.DATABASE_IP_RECOVERY;
            this.txt_DataBase_Admin_User.Text = database_owner.DATABASE_ADMIN_USER;
            this.txt_DataBase_Admin_PassWord.Text = Com.Common.EncDec.Decrypt(database_owner.DATABASE_ADMIN_PASSWORD, this.Encrypt_key);
            this.txt_DataBase_Reader_User.Text = database_owner.DATABASE_READER_USER;
            this.txt_DataBase_Reader_PassWord.Text = Com.Common.EncDec.Decrypt(database_owner.DATABASE_READER_PASSWORD, this.Encrypt_key);
            this.txt_DataBase_Writer_User.Text = database_owner.DATABASE_WRITER_USER;
            this.txt_DataBase_Writer_PassWord.Text = Com.Common.EncDec.Decrypt(database_owner.DATABASE_WRITER_PASSWORD, this.Encrypt_key);
        }
        public static bool IsValidIP(string IP)
        {
            const string regPattern = @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))";
            return Regex.IsMatch(IP, regPattern);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txt_DataBase_Name.Text.Trim() == "" ||
              this.txt_DataBase_Remark.Text.Trim() == "" ||
              this.txt_DataBase_IP_Local.Text.Trim() == "" ||
              this.txt_DataBase_IP_Romote.Text.Trim() == "" ||
              this.txt_DataBase_VIP_Local.Text.Trim() == "" ||
              this.txt_DataBase_VIP_Romote.Text.Trim() == "" ||
              this.txt_DataBase_IP_Special.Text.Trim() == "" ||
              this.txt_DataBase_IP_Recovery.Text.Trim() == "" ||
              this.txt_DataBase_Admin_User.Text.Trim() == "" ||
              this.txt_DataBase_Admin_PassWord.Text.Trim() == "" ||
              this.txt_DataBase_Reader_User.Text.Trim() == "" ||
              this.txt_DataBase_Reader_PassWord.Text.Trim() == "" ||
              this.txt_DataBase_Writer_User.Text.Trim() == "" ||
              this.txt_DataBase_Writer_PassWord.Text.Trim() == "")
            {
                this.AlertScript("请填写完毕再提交！");
                return;
            }

            if (!IsValidIP(this.txt_DataBase_IP_Local.Text.Trim()))
            {
                this.AlertScript("请填写正确的内网实IP！");
                return;
            }
            if (!IsValidIP(this.txt_DataBase_IP_Romote.Text.Trim()))
            {
                this.AlertScript("请填写正确的外网实IP！");
                return;
            }
            if (!IsValidIP(this.txt_DataBase_VIP_Local.Text.Trim()))
            {
                this.AlertScript("请填写正确的内网VIP！");
                return;
            }
            if (!IsValidIP(this.txt_DataBase_VIP_Romote.Text.Trim()))
            {
                this.AlertScript("请填写正确的外网VIP！");
                return;
            }
            if (!IsValidIP(this.txt_DataBase_IP_Special.Text.Trim()))
            {
                this.AlertScript("请填写正确的堡垒机专线IP！");
                return;
            }
            if (!IsValidIP(this.txt_DataBase_IP_Recovery.Text.Trim()))
            {
                this.AlertScript("请填写正确的容灾IP！");
                return;
            }

            Entity.TEAMTOOL.DATABASE_OWNER database_owner_update = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner_update.DATABASE_ID = this.P_DataBase_Id;
            database_owner_update.DATABASE_NAME = this.txt_DataBase_Name.Text;
            database_owner_update.DATABASE_REMARK = this.txt_DataBase_Remark.Text;
            database_owner_update.DATABASE_IP_LOCAL = this.txt_DataBase_IP_Local.Text;
            database_owner_update.DATABASE_IP_ROMOTE = this.txt_DataBase_IP_Romote.Text;
            database_owner_update.DATABASE_VIP_LOCAL = this.txt_DataBase_VIP_Local.Text;
            database_owner_update.DATABASE_VIP_ROMOTE = this.txt_DataBase_VIP_Romote.Text;
            database_owner_update.DATABASE_IP_SPECIAL = this.txt_DataBase_IP_Special.Text;
            database_owner_update.DATABASE_IP_RECOVERY = this.txt_DataBase_IP_Recovery.Text;
            database_owner_update.DATABASE_ADMIN_USER = this.txt_DataBase_Admin_User.Text;
            database_owner_update.DATABASE_ADMIN_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Admin_PassWord.Text, this.Encrypt_key);
            database_owner_update.DATABASE_READER_USER = this.txt_DataBase_Reader_User.Text;
            database_owner_update.DATABASE_READER_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Reader_PassWord.Text, this.Encrypt_key);
            database_owner_update.DATABASE_WRITER_USER = this.txt_DataBase_Writer_User.Text;
            database_owner_update.DATABASE_WRITER_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Writer_PassWord.Text, this.Encrypt_key);
            //database_owner_update.DATABASE_TABLE_DESCRIPTION = this.DATABASE_TABLE_DESCRIPTION.Text; 

            if (database_owner_update.Update())
            {
                this.RedirectConfirmScript("修改成功！", Business.Config.HostUrl + "/Manager/DataBase/DataBase_Owner_List.aspx");
            }
            else
            {
                this.ltrMsg.Text = "修改失败！";
            }

        }
    }
}