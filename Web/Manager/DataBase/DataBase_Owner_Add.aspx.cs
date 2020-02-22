using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Owner_Add : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_Owner_Add.aspx");
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
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { "isnull(max(DataBase_Id),0) as DataBase_Id " };
            database_owner.SelectTop1();
            int DataBase_Id = int.Parse(database_owner.DATABASE_ID_ToString)+1;

            Entity.TEAMTOOL.DATABASE_OWNER database_owner_new = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner_new.DATABASE_ID = DataBase_Id;

            database_owner_new.DATABASE_NAME = this.txt_DataBase_Name.Text;
            database_owner_new.DATABASE_REMARK = this.txt_DataBase_Remark.Text;
            database_owner_new.DATABASE_IP_LOCAL = this.txt_DataBase_IP_Local.Text;
            database_owner_new.DATABASE_IP_ROMOTE = this.txt_DataBase_IP_Romote.Text;
            database_owner_new.DATABASE_VIP_LOCAL = this.txt_DataBase_VIP_Local.Text;
            database_owner_new.DATABASE_VIP_ROMOTE = this.txt_DataBase_VIP_Romote.Text;
            database_owner_new.DATABASE_IP_SPECIAL = this.txt_DataBase_IP_Special.Text;
            database_owner_new.DATABASE_IP_RECOVERY = this.txt_DataBase_IP_Recovery.Text;
            database_owner_new.DATABASE_ADMIN_USER = this.txt_DataBase_Admin_User.Text;
            database_owner_new.DATABASE_ADMIN_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Admin_PassWord.Text, this.Encrypt_key);
            database_owner_new.DATABASE_READER_USER = this.txt_DataBase_Reader_User.Text;
            database_owner_new.DATABASE_READER_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Reader_PassWord.Text, this.Encrypt_key);
            database_owner_new.DATABASE_WRITER_USER = this.txt_DataBase_Writer_User.Text;
            database_owner_new.DATABASE_WRITER_PASSWORD = Com.Common.EncDec.Encrypt(this.txt_DataBase_Writer_PassWord.Text, this.Encrypt_key);
            //database_owner_new.DATABASE_TABLE_DESCRIPTION = this.DATABASE_TABLE_DESCRIPTION.Text; 

            if (database_owner_new.Insert())
            {
                this.RedirectConfirmScript("添加成功！", Business.Config.HostUrl + "/Manager/DataBase/DataBase_Owner_List.aspx");
            }
            else
            {
                this.ltrMsg.Text = "添加失败！";
            }


        }
    }
}