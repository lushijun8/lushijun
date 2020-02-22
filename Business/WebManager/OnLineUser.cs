using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Business.WebManager
{
    public class OnLineUser
    {
        /// <summary>
        /// 获取最近登录的用户邮箱，用;隔开
        /// </summary>
        /// <param name="LastLoginDays">最后登录天数以来的.</param>
        /// <param name="level">最小级别，0成员，1小团队长，2大团队长</param>
        /// <returns></returns>
        public static string GetWebmanagerEmails(int LastLoginDays,int minlevel)
        {
            string Value = "";
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME };
            admin_webmanager.Distinct = true;
            admin_webmanager.WEBMANAGER_STATUS = 100;
            admin_webmanager.WhereSql = admin_webmanager._WEBMANAGER_LEADER_LEVEL + ">=" + minlevel + " AND " + admin_webmanager._WEBMANAGER_LAST_LOGINTIME + ">CONVERT(varchar(100), Dateadd(day,-" + LastLoginDays + ",getdate()) , 23)";
            admin_webmanager.CacheTime = 1440;
            admin_webmanager.Select();
            while (admin_webmanager.Next())
            {
                Value += admin_webmanager.WEBMANAGER_NAME + "@fang.com;";
            }
            return Value.TrimEnd(';');
        }
    }
}
