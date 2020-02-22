using System;
using System.Data;

namespace Business
{
    public class ManageWeb : Com.Web.WebUI
    {
        #region 临时域
        /// <summary>
        /// 用户ID
        /// </summary>
        public string CurrentWebManagerId = "";
        /// <summary>
        /// 用户名称
        /// </summary>
        public string CurrentWebManagerName = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string CurrentWebManagerRealName = "";
        /// <summary>
        /// 团队长姓名
        /// </summary>
        public string CurrentWebManagerLeaderRealName = "";
        /// <summary>
        /// 用户分组ID 
        /// </summary>
        public string CurrentWebManagerGroupId = "";
        /// <summary>
        /// 用户分组名称
        /// </summary>
        public string CurrentWebManagerGroupName = "";
        /// <summary>
        /// 用户管理的ProductID
        /// </summary>
        public string CurrentWebManagerProduct = "";

        /// <summary>
        /// 用户管理的ProductName
        /// </summary>
        public string CurrentWebManagerProductName = "";
        /// <summary>
        /// 用户分组权限代码
        /// </summary>
        public string CurrentGroupFunctionIds = "";//用,隔开 
        public string CurrentWebTitle = "TeamTool";
        public string FunctionName = "";
        public bool CurrentIsAdmin = false;
        public string Encrypt_key = "fang.com";
        public static string encrypt_key = "fang.com";
        private delegate void AsyncDelegate(int WebManager_id, bool update_ip, bool update_clientname, string WebManager_Name);
        #endregion
        /// <summary>
        /// 验证是否登录
        /// </summary>
        public void AdminCheck()
        {
            string Cookie_CurrentWebManagerId = this.Cookie("CurrentWebManagerId");
            //如果USER_CODE为空，表示没有当前用户，则跳转至标准出错页面。
            if (string.IsNullOrEmpty(Cookie_CurrentWebManagerId))
            {
                this.ClearCookie();
                Response.Redirect(Config.HostUrl + "/Manager/Login.aspx?ReturnURL=" + Server.UrlEncode(Request.RawUrl));
                return;
            }
            else
            {
                try
                {
                    this.CurrentWebManagerId = Com.Common.EncDec.Base64Decrypt(Cookie_CurrentWebManagerId).Split(',')[1];
                    int.Parse(this.CurrentWebManagerId);
                }
                catch
                {
                    Response.Redirect(Config.HostUrl + "/Manager/Logout.aspx");
                    return;
                }
                string CacheName = Com.Common.EncDec.PasswordEncrypto("ADMIN_WEBMANAGER_" + this.CurrentWebManagerId);
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                Entity.TEAMTOOL.ADMIN_WEBMANAGER_GROUP admin_webmanager_group = new Entity.TEAMTOOL.ADMIN_WEBMANAGER_GROUP();
                admin_webmanager.INNER_JOIN_ADMIN_WEBMANAGER_GROUP = true;
                admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_ID, admin_webmanager._WEBMANAGER_PRODUCT, admin_webmanager._WEBMANAGER_NAME, admin_webmanager_group._GROUP_ID, admin_webmanager_group._GROUP_NAME, admin_webmanager._WEBMANAGER_IS_ADMIN, admin_webmanager._WEBMANAGER_IP, admin_webmanager._WEBMANAGER_IP_LASTLOGIN, admin_webmanager._WEBMANAGER_LAST_LOGINTIME, admin_webmanager._WEBMANAGER_REALNAME, admin_webmanager._WEBMANAGER_LEADER_REALNAME };
                admin_webmanager.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
                admin_webmanager.CacheName = CacheName;
                admin_webmanager.CacheTime = 5;
                DataRow oDr = admin_webmanager.SelectTop1();
                if (oDr != null)
                {
                    if (oDr[admin_webmanager._WEBMANAGER_IP_LASTLOGIN].ToString() != Request.UserHostAddress)
                    {
                        //Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager0 = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                        //admin_webmanager0.WEBMANAGER_ID = int.Parse(this.CurrentWebManagerId);
                        //admin_webmanager0.SelectTop1();

                        //DataTable oDt_admin_webmanager = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, CacheName, 1);                      

                        //if (oDt_admin_webmanager != null && oDt_admin_webmanager.Rows.Count > 0)
                        //{
                        //    oDt_admin_webmanager.Rows[0][admin_webmanager._WEBMANAGER_IP_LASTLOGIN] = admin_webmanager0.WEBMANAGER_IP_LASTLOGIN;
                        //    Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, CacheName, oDt_admin_webmanager, 1);
                        //}

                        System.Web.Caching.Cache _cache = System.Web.HttpRuntime.Cache;
                        _cache.Remove(CacheName);

                        this.ClearCookie();
                        Response.Write("您的账号已经在别处登录！<a href=\"" + Config.HostUrl + "/Manager/Login.aspx\">重新登录</a>");
                        Response.End();
                    }
                    this.CurrentWebManagerName = oDr[admin_webmanager._WEBMANAGER_NAME].ToString();	//用户名称
                    this.CurrentWebManagerRealName = oDr[admin_webmanager._WEBMANAGER_REALNAME].ToString();	//
                    this.CurrentWebManagerLeaderRealName = oDr[admin_webmanager._WEBMANAGER_LEADER_REALNAME].ToString();	//
                    this.CurrentWebManagerGroupId = oDr[admin_webmanager_group._GROUP_ID].ToString();	//用户分组ID
                    this.CurrentWebManagerGroupName = oDr[admin_webmanager_group._GROUP_NAME].ToString();//用户分组名称
                    this.CurrentWebManagerProduct = oDr[admin_webmanager._WEBMANAGER_PRODUCT].ToString();

                    string cacheName = "CurrentWebManagerProductName_" + this.CurrentWebManagerId;
                    if (Cache[cacheName] != null)
                    {
                        try
                        {
                            this.CurrentWebManagerProductName = (string)Cache[cacheName];
                        }
                        catch (Exception ex)
                        {
                            Business.HandleException.LogException(ex);
                        }
                    }
                    else
                    {
                        Entity.TEAMTOOL.ADMIN_PRODUCT admin_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                        admin_product.CacheTime = 120;
                        admin_product.Split_Or_And = true;
                        admin_product[admin_product._PRODUCTID] = this.CurrentWebManagerProduct;
                        if (admin_product.Select() != null)
                        {
                            while (admin_product.Next())
                            {
                                this.CurrentWebManagerProductName += admin_product.PRODUCTNAME + "|";
                            }
                            Cache.Add(cacheName, this.CurrentWebManagerProductName.TrimEnd('|'), null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                        }
                    }
                    if (this.CurrentWebManagerGroupId != null && this.CurrentWebManagerGroupId != "")
                    {
                        if (admin_webmanager.WEBMANAGER_IS_ADMIN_ToString == "1")
                        {
                            this.CurrentIsAdmin = true;
                        }
                        this.CurrentGroupFunctionIds = this.GroupFunctionIds(int.Parse(this.CurrentWebManagerGroupId));	//用户分组权限代码
                        string now = Com.Common.RandomUtil.GetRandomCode(16, true, true);
                        string now1 = Com.Common.RandomUtil.GetRandomCode(16, true, true);
                        this.setCookies("CurrentWebManagerId", Com.Common.EncDec.Base64Encrypt(now + "," + oDr[admin_webmanager._WEBMANAGER_ID].ToString() + "," + now1), System.DateTime.Now.AddHours(168));

                        bool update_clientname = false;// string.IsNullOrEmpty(admin_webmanager.WEBMANAGER_REMARK) ? true : false;
                        bool update_ip = string.IsNullOrEmpty(admin_webmanager.WEBMANAGER_IP) ? true : false;
                        if ((string.IsNullOrEmpty(admin_webmanager.WEBMANAGER_LAST_LOGINTIME_ToString) ||
                            DateTime.Compare(DateTime.Parse(admin_webmanager.WEBMANAGER_LAST_LOGINTIME_ToString).AddDays(7), DateTime.Now) <= 0))
                        {
                            update_ip = true;
                            //update_clientname = true;
                        }
                        AsyncDelegate caller = new AsyncDelegate(AsyncExe);
                        caller.BeginInvoke(int.Parse(oDr[admin_webmanager._WEBMANAGER_ID].ToString()), update_ip, update_clientname, this.QueryString("WebManager_Name"), null, caller);
                    }
                    else
                    {
                        Response.Write("您没有权限！");
                        Response.End();
                    }

                }
                else
                {
                    this.ClearCookie();
                    Response.Redirect(Config.HostUrl + "/Manager/Login.aspx");
                    return;
                }
            }

        }
        private void AsyncExe(int WebManager_id, bool update_ip, bool update_clientname, string WebManager_Name)
        {
            //更新登录时间
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_update = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager_update.WEBMANAGER_ID = WebManager_id;
            if (string.IsNullOrEmpty(WebManager_Name))
            {
                admin_webmanager_update.WEBMANAGER_LAST_LOGINTIME = System.DateTime.Now;
            }
            if (update_ip == true)
            {
                //判断这个ip是否有人占用
                string ip = Request.UserHostAddress;
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager_ip = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager_ip.WEBMANAGER_IP = ip;
                if (admin_webmanager_ip.SelectTop1() == null)
                {
                    admin_webmanager_update.WEBMANAGER_IP = ip;
                }
            }
            //if (update_clientname == true)
            //{
            //    //机器名
            //    string clientname = Request.UserHostName;
            //    admin_webmanager_update.WEBMANAGER_REMARK = clientname;
            //}
            admin_webmanager_update.Update();
        }
        /// <summary>
        /// 页面权限验证
        /// </summary>
        /// <param name="MenuCode"></param>
        public void AdminCheck(string PageUrl)
        {
            this.AdminCheck();
            if (this.CurrentWebManagerGroupId.Trim() == "")
            {
                this.ClearCookie();
                Response.Redirect(Config.HostUrl + "/Manager/Login.aspx");
                return;
            }
            //获取当前权限代码
            string GroupFunctionUrls = "";
            string Cachekey = "GroupFunctionUrls_" + this.CurrentWebManagerGroupId;
            if (Cache[Cachekey] != null)
            {
                try
                {
                    GroupFunctionUrls = (string)Cache[Cachekey];
                }
                catch (Exception ex)
                {
                    Business.HandleException.LogException(ex);
                }
            }
            Entity.TEAMTOOL.ADMIN_FUNCTION fun = new Entity.TEAMTOOL.ADMIN_FUNCTION();
            if (this.CurrentIsAdmin == false)
            {
                string Sql = "UPDATE ADMIN_FUNCTION SET FUNCTION_VIEW_COUNT=ISNULL(FUNCTION_VIEW_COUNT,0)+1 WHERE FUNCTION_URL='" + PageUrl + "'";
                fun.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);
            }

            if (GroupFunctionUrls.IndexOf(PageUrl + ";") > -1)
            {
                return;//已经判断过了
            }

            bool bAdmin = false;
            string[] FunctionIds = this.CurrentGroupFunctionIds.Split(',');

            string Function_Id = "-1";
            fun.INNER_JOIN_ADMIN_MODULE = true;
            fun.SelectColumns = new string[] { fun._FUNCTION_URL, fun._FUNCTION_NAME, fun._FUNCTION_ID, "Module_name" };
            //fun.CacheName = "ADMIN_FUNCTION_ALL";
            fun.CacheTime = 10;
            DataTable oDt = fun.Select();
            DataRow[] oDr = oDt.Select(fun._FUNCTION_URL + "='" + PageUrl + "'");
            if (oDr.Length == 0)
            {
                this.ClearCookie();
                Response.Redirect(Config.HostUrl + "/Manager/Login.aspx");
                return;
            }
            else
            {
                Function_Id = oDr[0][fun._FUNCTION_ID].ToString();
                //CurrentWebTitle += " -> " + oDr[0]["Module_name"].ToString() + " -> " + oDr[0][fun._FUNCTION_NAME].ToString();
                CurrentWebTitle += "->" + oDr[0][fun._FUNCTION_NAME].ToString();
                FunctionName = oDr[0][fun._FUNCTION_NAME].ToString();
            }


            foreach (string Fid in FunctionIds)
            {
                if (Fid.Trim() != "" && Fid.ToLower() == Function_Id.ToLower())
                {
                    bAdmin = true;
                    break;
                }
            }
            if (bAdmin == false)
            {
                //this.ClearCookie();
                Response.Redirect(Config.HostUrl + "/Manager/Error.aspx");
                return;
            }
            else//如果有权限，则将url记录在缓存中，下次直接进入
            {
                GroupFunctionUrls += PageUrl + ";";
                Cache.Add(Cachekey, GroupFunctionUrls, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="WebManager_Name"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public bool CheckIn(string WebManager_Name, out string Error)
        {
            bool Value = true;

            Error = "";
            if (WebManager_Name == "")
            {
                Error = "请填写用户代码！";
                return false;
            }


            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.WEBMANAGER_NAME = WebManager_Name;
            DataRow oDr = admin_webmanager.SelectTop1();
            if (oDr == null)
            {
                Error = "用户不存在！";
                return false;
            }
            else if (admin_webmanager.WEBMANAGER_STATUS_ToString != "100")
            {
                Error = "用户" + WebManager_Name + "已被停用，请联系管理员！";
                Business.MallLog.Create(0, "", "用户" + WebManager_Name + "开启申请", Business.Config.HostUrl + "/Manager/Admin/UpdateUserStatus.aspx?v=" + Com.Common.EncDec.Base64Encrypt(admin_webmanager.WEBMANAGER_ID_ToString + ",100," + System.DateTime.Now.ToString("yyyyMMdd")) + " ,当日有效", "127.0.0.1");
                return false;
            }
            else
            {
                string now = Com.Common.RandomUtil.GetRandomCode(16, true, true);
                string now1 = Com.Common.RandomUtil.GetRandomCode(16, true, true);
                this.setCookies("CurrentWebManagerId", Com.Common.EncDec.Base64Encrypt(now + "," + admin_webmanager.WEBMANAGER_ID_ToString + "," + now1), System.DateTime.Now.AddHours(168));
                Business.MallLog.Create(0, "", "管理员登录", "登录名:" + WebManager_Name + "*密码:*操作:登录Pay管理后台", Business.Net.GetCurrentUserCilentIp());

            }
            return Value;
        }
        /// <summary>
        /// 权限组ID和对应的URL
        /// </summary>
        /// <param name="Group_Id"></param>
        /// <returns></returns>
        private string GroupFunctionIds(int Group_Id)
        {
            //获取当前权限代码
            string FunctionIds = "";
            string Cachekey = "GroupFunctionIds_" + Group_Id;
            if (Cache[Cachekey] != null)
            {
                try
                {
                    FunctionIds = (string)Cache[Cachekey];
                }
                catch (Exception ex)
                {
                    Business.HandleException.LogException(ex);
                }
            }
            if (FunctionIds.Trim() == "")
            {
                FunctionIds = "";
                Entity.TEAMTOOL.ADMIN_PERMISSION admin_permission = new Entity.TEAMTOOL.ADMIN_PERMISSION();
                admin_permission.PERMISSION_GROUP_ID = Group_Id;
                //admin_permission.CacheTime = 10;
                admin_permission.Select();
                while (admin_permission.Next())
                {
                    FunctionIds += admin_permission.PERMISSION_FUNCTION_ID_ToString + ",";
                }
                Cache.Add(Cachekey, FunctionIds.TrimEnd(','), null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return FunctionIds.TrimEnd(',');
        }
        private void ClearCookie()
        {

            this.setCookies("CurrentWebManagerId", "", System.DateTime.Now.AddSeconds(2));
            //清楚权限的缓存
            Cache.Remove("GroupFunctionIds_" + this.CurrentWebManagerGroupId);
            Cache.Remove("GroupFunctionUrls_" + this.CurrentWebManagerGroupId);
            Cache.Remove("Manage_Index_Menu_" + this.CurrentWebManagerGroupId);
            Cache.Remove("ADMIN_WEBMANAGER_" + this.CurrentWebManagerId);
            Cache.Remove("ADMIN_FUNCTION_ALL");
        }
    }
}


