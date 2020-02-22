<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Add.aspx.cs" Inherits="Web.Manager.Bill.Bill_Add" %>


<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=this.CurrentWebTitle%></title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="l2">&nbsp;</td>
                    <td class="c2">
                            <!--开始-->

                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style1">报销类型：</td>
                                    <td>餐费报销</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">报销人：</td>
                                    <td>
                                        <%=this.CurrentWebManagerRealName %>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">所属团队：</td>
                                    <td>                                       
                                        <%=this.CurrentWebManagerLeaderRealName %>团队</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">消费日期：</td>
                                    <td>

                                        <asp:TextBox ID="txt_Bill_Date" runat="server" MaxLength="12" Width="102px" onfocus="javascript:ShowCalendar(this.id)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">事由：</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Reason" runat="server" MaxLength="12" Width="439px">交易平台记提成开发</asp:TextBox>
                                        用简短明确的一句话说明事由</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">人员：</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Staff_Worker" runat="server" MaxLength="100" Width="600px" Height="52px" TextMode="MultiLine">张三三 李四 王五 孙六六</asp:TextBox>
                                        <br />
                                        姓名之间请用空格隔开，名字本身不能含有空格。</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">金额：</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Total_Money" runat="server" MaxLength="6" Width="65px"></asp:TextBox>
                                        元，请填写整数，报销金额可以小于或等于发票实际面额</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认提交" OnClick="btnSubmit_Click" />
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td>
                                        <font color="red"> * 公司规定晚上加班到晚7点以后才能报销餐费，请确保报销人当天晚7点以后有考勤打卡记录（晚餐可以晚7点前预订），因为财务会查考勤，周末加班报销的也需要有考勤打卡记录。</font><br />
                                        <font color="red"> * 请在发票背面签上报销人的姓名，同面额、同尺寸的发票沿着发票左边用胶水贴在一起，再交给你的团队长</font> <%=this.CurrentWebManagerLeaderRealName %>。<br />   
                                        <font color="red"> * 机打发票付款单位：“<font color=black>北京宏岸图升网络技术有限公司</font>”，务必正确才能报销。</font><br /> 
                                        <font color="red"> * 加班餐费必须使用国税局监制的发票才能报销。</font><br />  
                                        <font color="red"> * 一次加班的几个人（一起订餐的人），由一人统一报销即可。</font><br />   
                                        <img src="../../images/bill.png" />                                   
                                     <%--   <font color="red"> * 每天加班临走时均需要发邮件给“曹艳白caoyanbai@fang.com”，并抄送给你的团队长，进行备案。财务报销加班餐时，以此为依据。要求如下：</font><br /> 
                                        <font color="red">01、加班结束临走时发送。</font><br />
                                        <font color="red">02、一次加班的几个人（一起报销的人），由一人统一发邮件即可。</font><br />
                                        <font color="red">03、邮件标题为“加班备案 xxxx-xx-xx xx:xx:xx”，正文列出人员、金额及事由。</font><br />--%> 
                                    </td>
                                </tr>
                            </table>
                     </td> 
                </tr>
            </table>
        </div>
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>提交中,请等待....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if (window.confirm("确定提交吗？") == true)
                {
                    $("#Loading").show();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        })
    </script>
</body>
</html>
