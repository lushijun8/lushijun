using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Memcache
{
    public partial class Memcache_Edit : Business.ManageWeb
    {
        private string P_Memcache_IP = "";
        private string P_Memcache_Local_IP = "";
        private string P_Memcache_Port = "";
        protected string P_BackUrl = "";
        protected string P_Command = "";
        protected string P_CacheType = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Memcache/Memcache_Edit.aspx");

            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                this.P_Memcache_IP = v[0];
                this.P_Memcache_Port = v[1];
                this.P_Memcache_Local_IP = v[2];
            }
            else
            {
                this.AlertScript("参数有误！");
                return;
            }
            this.P_BackUrl = Business.Config.HostUrl + "/Manager/Memcache/Memcache_Stats.aspx";

            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定

            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            memcache_server.MEMCACHE_IP = this.P_Memcache_IP;
            memcache_server.MEMCACHE_PORT = int.Parse(this.P_Memcache_Port);
            memcache_server.SelectTop1();

            this.txt_Memcache_IP.Text = this.P_Memcache_IP;
            this.txt_Memcache_Local_IP.Text = this.P_Memcache_Local_IP;
            this.txt_Memcache_Port.Text = this.P_Memcache_Port;
            this.txt_Remark.Text = memcache_server.REMARK;
            #endregion

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Memcache_Local_IP.Text) || string.IsNullOrEmpty(this.txt_Memcache_IP.Text) || string.IsNullOrEmpty(this.txt_Memcache_Port.Text))
            {
                this.AlertScript("请填写完毕！");
                return;
            }
            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
            int i = memcache_server.Database_Writer.ExecuteNonQuery(System.Data.CommandType.Text, @"UPDATE MEMCACHE_SERVER
                                                                                            SET	 Memcache_IP = '" + this.txt_Memcache_IP.Text + @"'
                                                                                                ,Memcache_Local_IP = '" + this.txt_Memcache_Local_IP.Text + @"'
                                                                                                ,Memcache_Port = '" + this.txt_Memcache_Port.Text + @"'
                                                                                                ,Remark = '" + this.txt_Remark.Text + @"'
                                                                                            WHERE Memcache_IP = '" + this.P_Memcache_IP + @"'
                                                                                            AND Memcache_Port = '" + this.P_Memcache_Port + @"' ;");
            if (i > 0)
            {
                this.RedirectConfirm("修改成功！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("修改失败！", this.P_BackUrl);
            }
        }
    }
}
