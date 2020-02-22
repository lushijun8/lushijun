using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Bill
{
    public partial class Bill_Receive : Business.ManageWeb
    {
        private string P_Bill_Receive_leader_realname = "";
        private string P_Bill_Receive_year = "";
        private string P_Bill_Receive_month = "";
        private string P_Bill_Receive_SendEmail = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Bill/Bill_Receive.aspx");
            this.P_BackUrl = this.QueryString("BackUrl");
            if (string.IsNullOrEmpty(this.P_BackUrl))
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
            if (!string.IsNullOrEmpty(this.QueryString("v")))
            {
                string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                this.P_Bill_Receive_leader_realname = v[0];
                this.P_Bill_Receive_year = v[1];
                this.P_Bill_Receive_month = v[2];
                this.P_Bill_Receive_SendEmail = v[3];

                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.BILL_RECEIVE bill_receive = new Entity.TEAMTOOL.BILL_RECEIVE();
            bill_receive.BILL_RECEIVE_LEADER_REALNAME = this.P_Bill_Receive_leader_realname;
            bill_receive.BILL_RECEIVE_YEAR = int.Parse(this.P_Bill_Receive_year);
            bill_receive.BILL_RECEIVE_MONTH = int.Parse(this.P_Bill_Receive_month);
            if (bill_receive.Insert() == true)
            //if (1 == 1)
            {
                this.RedirectConfirm("领取成功！", this.P_BackUrl);
                if (this.P_Bill_Receive_SendEmail == "1")
                {
                    #region 发邮件给领取人
                    string body = @"<!DOCTYPE HTML PUBLIC " + "\"" + @"-//W3C//DTD HTML 4.01//EN" + "\"" + @" " + "\"" + @"http://www.w3.org/TR/html4/strict.dtd" + "\"" + @">
<html>
<head>
    <meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" />
<style type=" + "\"" + @"text/css" + "\"" + @">   
* {word-break:break-all;word-wrap:break-word;margin:0;padding:0;text-align:left;}
body {
    text-align: center;
    font-family: " + "\"" + @"微软雅黑" + "\"" + @",Arial;
    font-size: 12px;
    color: #000;
    background-color: #ffffff;
}
table {
    font-family: " + "\"" + @"微软雅黑" + "\"" + @",Arial;
    font-size: 12px;
    color: #000;
    background-color: #808080;
}
td {background: #ffffff;}
th {background: #cccccc;}
</style>
</head><body>" + this.P_Bill_Receive_leader_realname + ",你好：<br>&nbsp;&nbsp;&nbsp;&nbsp;你的" + this.P_Bill_Receive_year + "年" + this.P_Bill_Receive_month + "月的餐费报销已发放到支付宝，共计{0}元，请注意查收，如果是自己团队成员填报的请注意转账，<a href=" + "\"http://10.2.137.134/Manager/Bill/Bill_List.aspx\"" + @">点击此处查看详情</a>,明细如下:<p>{1}</p></body></html>";

                    string info = "<table id=\"messagelist\" width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\">" + @"
		            <tr>
			            <th>消费日期</th>
			            <th>事由</th>
			            <th>用餐人员</th>
			            <th>填报人</th>
			            <th>工作餐费</th>
		            </tr>";

                    Entity.TEAMTOOL.BILL bill = new Entity.TEAMTOOL.BILL();
                    bill.BILL_YEAR = int.Parse(this.P_Bill_Receive_year);
                    bill.BILL_MONTH = int.Parse(this.P_Bill_Receive_month);
                    bill.BILL_LEADER_REALNAME = this.P_Bill_Receive_leader_realname;
                    bill.Select();
                    int MoneySum = 0;
                    while (bill.Next())
                    {
                        info += @"<tr>
                            <td>" + DateTime.Parse(bill.BILL_DATE_ToString).ToShortDateString() + @"</td>
                            <td>加班用餐(" + bill.BILL_REASON + @")</td>
                            <td>" + bill.BILL_STAFF_WORKER + @"</td>  
			                <td>" + bill.BILL_WEBMANAGER_REALNAME + @"</td>
                            <td>" + bill.BILL_TOTAL_MONEY_ToString + "</td>" +
                                      "</tr>";
                        MoneySum += int.Parse(bill.BILL_TOTAL_MONEY_ToString);
                    }

                    info += "</table>";

                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    admin_webmanager.WEBMANAGER_REALNAME = this.P_Bill_Receive_leader_realname;
                    admin_webmanager.SelectTop1();

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    mail.MailTitle = this.P_Bill_Receive_year + "年" + this.P_Bill_Receive_month + "月的餐费报销已发放[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                    mail.MailContent = body.Replace("{0}", MoneySum.ToString()).Replace("{1}", info);

                    //mail.MailUserList =  "lushijun@fang.com"; 
                    mail.MailUserList = admin_webmanager.WEBMANAGER_NAME + "@fang.com";
                    mail.CopyToMailUserList = "lushijun@fang.com";

                    if (mail.SendOneMailByHTML() == true)
                    {
                        //mail.MailUserList = "lushijun@fang.com";
                        //mail.SendOneMailByHTML();
                    }
                    #endregion
                }
            }
            else
            {
                this.RedirectConfirm("领取失败！可能已经领取过", this.P_BackUrl);
            }
        }
    }
}