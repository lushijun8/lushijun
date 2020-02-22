using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Web.Manager.Memcache
{
    public partial class Memcache_Reset : Business.ManageWeb
    {
        private string P_Memcache_IP = "";
        private string P_Memcache_Port = "";
        protected string P_BackUrl = "";
        protected string P_Command = "";
        protected string P_CacheType = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Memcache/Memcache_Reset.aspx");

            if (!Page.IsPostBack)
            {
                this.P_BackUrl = this.QueryString("BackUrl");
                if (string.IsNullOrEmpty(this.P_BackUrl))
                {
                    if (Request.UrlReferrer != null)
                    {
                        if (Request.UrlReferrer != null)
                        {
                            this.P_BackUrl = Request.UrlReferrer.ToString();
                        }
                        else
                        {
                            this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                        }
                    }
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                    }

                }
                if (!string.IsNullOrEmpty(this.QueryString("v")))
                {
                    string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                    this.P_Memcache_IP = v[0];
                    this.P_Memcache_Port = v[1];
                    this.P_Command = v[2];
                    this.P_CacheType = v[3];
                    this.BindData();
                }
            }
        }
        private void BindData()
        {
            #region 绑定列表
            if (this.P_Command == "flush_all" || this.P_Command == "stats reset")
            {
                Com.Net.TelnetUtil telnet = new Com.Net.TelnetUtil(this.P_Memcache_IP, int.Parse(this.P_Memcache_Port), 30);
                if (telnet.Connect() == true)
                {
                    //等待指定字符返回后才执行下一命令 
                    telnet.Send(this.P_Command);
                    if (this.P_Command == "flush_all")
                    {
                        telnet.WaitFor("OK");
                    }
                    else if (this.P_Command == "stats reset")
                    {
                        telnet.WaitFor("RESET");
                    }
                    string data = telnet.WorkingData;
                    if (data.IndexOf("OK") > -1 || data.IndexOf("RESET") > -1)
                    {
                        if (this.P_Command == "flush_all")//更新回收时间
                        {
                            Entity.TEAMTOOL.MEMCACHE_SERVER memcache_server = new Entity.TEAMTOOL.MEMCACHE_SERVER();
                            memcache_server.MEMCACHE_IP = this.P_Memcache_IP;
                            memcache_server.MEMCACHE_PORT = int.Parse(this.P_Memcache_Port);
                            memcache_server.RESETTIME = System.DateTime.Now;
                            memcache_server.Update();
                        }
                        if (Business.MemcachedStats.Refresh(this.P_Memcache_IP, int.Parse(this.P_Memcache_Port)) == true)
                        {
                            this.RedirectConfirm("成功！", this.P_BackUrl);
                        }
                        else
                        {
                            this.RedirectConfirm("失败！", this.P_BackUrl);
                        }
                    }
                    else
                    {
                        this.RedirectConfirm("失败！", this.P_BackUrl);
                    }

                }
            }
            else//刷新
            {

                bool bRefresh = false;
                try
                {
                    if (this.P_CacheType == "0")
                    {
                        bRefresh = Business.MemcachedStats.Refresh(this.P_Memcache_IP, int.Parse(this.P_Memcache_Port));

                    }
                    else
                    {
                        bRefresh = Business.Redis.RedisStats.Refresh(this.P_Memcache_IP, int.Parse(this.P_Memcache_Port));

                    }
                }
                catch { }
                if (bRefresh == true)
                {
                    this.RedirectConfirm("成功！", this.P_BackUrl);
                }
                else
                {
                    this.RedirectConfirm("失败！", this.P_BackUrl);
                }
            }
            #endregion

        }
    }
}
