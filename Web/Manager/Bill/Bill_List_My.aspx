<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_List_My.aspx.cs" Inherits="Web.Manager.Bill.Bill_List_My" %>

<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=this.CurrentWebTitle%></title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />    
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />    
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">			
                <font color="red"> * 公司规定晚上加班到晚7点以后才能报销餐费，请确保报销人当天晚7点以后有考勤打卡记录（晚餐可以晚7点前预订），因为财务会查考勤，周末加班报销的也需要有考勤打卡记录。</font><br />
                                        <font color="red"> * 请在发票背面签上报销人的姓名，同面额、同尺寸的发票沿着发票左边用胶水贴在一起，再交给你的团队长</font> <%=this.CurrentWebManagerLeaderRealName %>。<br />   
                                        <font color="red"> * 机打发票付款单位：“<font color=black>北京宏岸图升网络技术有限公司</font>”，务必正确才能报销。</font><br />
                                        <font color="red"> * 加班餐费必须使用国税局监制的发票才能报销。</font><br />
                                        <font color="red"> * 一次加班的几个人（一起订餐的人），由一人统一报销即可。</font><br />
                                        <%--<font color="red"> * 每天加班临走时均需要发邮件给“曹艳白caoyanbai@fang.com”,并抄送给你的团队长，进行备案。财务报销加班餐时，以此为依据。要求如下：</font><br /> 
                                        <font color="red">01、加班结束临走时发送。</font><br />
                                        <font color="red">02、一次加班的几个人（一起报销的人），由一人统一发邮件即可。</font><br />
                                        <font color="red">03、邮件标题为“加班备案 xxxx-xx-xx xx:xx:xx”，正文列出人员、金额及事由。</font><br /> --%>
                共查到<font color=red><%=this.LogCount.ToString() %></font>条记录。
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th>类型</th>
			            <th><a href="Bill_List_My.aspx?orderby=bill_date+desc" class="orderby">↓</a>消费日期</th>
			            <th>报销人</th>
			            <th>所属团队</th>
			            <th>事由</th>
			            <th>人员</th>
			            <th><a href="Bill_List_My.aspx?orderby=bill_total_money+desc" class="orderby">↓</a>金额(元)</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
                                 <td>餐费</td>
			                     <td><%# DateTime.Parse(Eval("bill_date").ToString()).ToShortDateString()%></td>
			                     <td><%# Eval("bill_WebManager_realname").ToString()%></td>
			                     <td><%# Eval("bill_leader_realname").ToString()%></td>
			                     <td><%# Eval("bill_reason").ToString()%></td>
			                     <td><%# Eval("bill_staff_worker").ToString()%></td>
			                     <td><%# Eval("bill_total_money").ToString()%></td>
			                     <td><%# Eval("bill_lock").ToString()=="1"?"已锁定":"<a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Delete.aspx?v="+ Com.Common.EncDec.Encrypt( Eval("bill_WebManager_name").ToString()+","+Eval("bill_date").ToString(), this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('确定删除吗？');\">删除</a>"%>
                                      <%# Eval("bill_receive").ToString()=="1"?"已发放":""%>
			                     </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages"><%=this.outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
