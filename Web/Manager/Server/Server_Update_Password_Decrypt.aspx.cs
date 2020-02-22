using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Server
{
    public partial class Server_Update_Password_Decrypt : Business.ManageWeb
    {
        protected int P_Id = -1;
        protected string P_Remark = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Server/Server_Update_Password_Decrypt.aspx");
            if (!Page.IsPostBack)
            {
                if (this.QueryString("Id") != "")
                {
                    this.P_Id = int.Parse(Com.Common.EncDec.Decrypt(this.QueryString("Id"), this.Encrypt_key).Split(',')[0]);
                    this.P_Remark = Server.UrlDecode(this.QueryString("remark"));
                    this.BindData();
                }
            }
        }
        private void BindData()
        {

            string password = "";
            string Hour = System.DateTime.Now.Hour.ToString().PadLeft(2, '0');
            string Minute = System.DateTime.Now.Minute.ToString().PadLeft(2, '0');
            int now = int.Parse(Hour + Minute);
            if (
                ((now >= 0 && now <= 900) ||
                (now >= 1200 && now <= 1310) ||
                (now >= 1745 && now <= 2359)) ||
                (this.CurrentIsAdmin == true)

                )
            {
                Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
                server_update_log.ID = this.P_Id;
                if (server_update_log.SelectTop1() != null)
                {
                    password = Com.Common.EncDec.Decrypt(server_update_log.CREATE_PASSWORD, this.Encrypt_key);
                    if (string.IsNullOrEmpty(server_update_log.DECRYPT_PASSWORD))
                    {
                        Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_log_update = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
                        server_update_log_update.ID = this.P_Id;
                        server_update_log_update.DECRYPT_IP = Request.UserHostAddress;
                        server_update_log_update.DECRYPT_USERNAME = this.CurrentWebManagerName;
                        server_update_log_update.DECRYPT_PASSWORD = password;
                        server_update_log_update.DECRYPT_TIME = System.DateTime.Now;
                        server_update_log_update.DECRYPT_REMARK = this.P_Remark;
                        server_update_log_update.DECRYPT_STATUS = 1;
                        if (server_update_log_update.Update() == true)
                        {
                        }
                        else
                        {
                            Response.Write(password);
                        }
                    }

                }
            }
            else
            {
                password = "正式站更新时间为：<br/>00:00至09:00<br/>12:00至13:10<br/>17:45至23:59<br/>";
            }

            Response.Write(password);
        }
    }
}