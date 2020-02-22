<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_List.aspx.cs" Inherits="Web.Manager.Bill.Bill_List" %>

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
                <asp:DropDownList ID="ddl_bill_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bill_year_SelectedIndexChanged">
                </asp:DropDownList>年
                <asp:DropDownList ID="ddl_bill_month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bill_month_SelectedIndexChanged">
                </asp:DropDownList>月                 
                <asp:DropDownList ID="ddl_bill_leader_realname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bill_leader_realname_SelectedIndexChanged">
                </asp:DropDownList>团队
                 
                <asp:Button CssClass="button" ID="btn_Lock" runat="server" Text="锁定该月数据" OnClick="btn_Lock_Click" OnClientClick="javascript:return Lock_Click();" />
                 <!--开始-->
	            <p>&nbsp;</p>
                <h2>汇总,共<font color="red"><%=this.TotalSum.ToString() %></font>元：</h2>
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>消费日期</th>
			            <th>事由</th>
			            <th>用餐人员</th>
			            <th>交通费</th>
			            <th>工作餐费</th>
                        <%if(this.CurrentIsAdmin==true){ %>
			            <th>超额</th>
                        <%} %>
		            </tr>
		            <asp:Repeater ID="rpt_sum" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# DateTime.Parse( Eval("bill_date").ToString()).ToShortDateString()%></td> 
			                    <td>加班用餐(<%# Eval("bill_reason").ToString()%>)</td>
			                    <td><%# Eval("bill_staff_worker").ToString()%></td>
			                    <td> </td>
			                    <td><%# Eval("bill_total_money").ToString()%></td>
                                <%if(this.CurrentIsAdmin==true){ %>
			                    <td><%# Eval("BILL_TOTAL_MONEY_OVER").ToString()=="0"?"":Eval("BILL_TOTAL_MONEY_OVER").ToString()%></td>
                                <%} %>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
                <h2>按团队汇总：</h2>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>团队</th>
			            <th>工作餐费</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rpt_sum_by_leader" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("bill_leader_realname").ToString()%></td> 
			                    <td><%# Eval("bill_total_money").ToString()%></td>
                                <td><%# Eval("bill_lock").ToString()=="1"?"已锁定 ":"-"%>  
                                     <%if (this.CurrentIsAdmin == true) {%>
                                    <%# Eval("bill_lock").ToString()=="1"?(Eval("BILL_RECEIVE").ToString()=="1"?"已发放":"<a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Receive.aspx?v="+Com.Common.EncDec.Encrypt(Eval("bill_leader_realname").ToString()+","+this.ddl_bill_year.SelectedValue+","+this.ddl_bill_month.SelectedValue+",1",this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('确定吗？');\">领取发邮件</a> <a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Receive.aspx?v="+Com.Common.EncDec.Encrypt(Eval("bill_leader_realname").ToString()+","+this.ddl_bill_year.SelectedValue+","+this.ddl_bill_month.SelectedValue+",0",this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('确定吗？');\">领取不发邮件</a>"):"-"%>  
                                    <% }%>                                    
                                </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
                
                <h2>按姓名汇总：</h2>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>姓名</th>
			            <th>工作餐费</th>
		            </tr>
		            <asp:Repeater ID="rpt_sum_by_person" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("bill_WebManager_realname").ToString()%></td> 
			                    <td><%# Eval("bill_total_money").ToString()%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
                <h2>报销明细：</h2>
                 <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>消费日期</th>
			            <th>报销人</th>
			            <th>所属团队</th>
			            <th>事由</th>
			            <th>用餐人员</th>
			            <th>工作餐费</th>
			            <th>录入时间</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rpt_bill" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# DateTime.Parse( Eval("bill_date").ToString()).ToShortDateString()%></td> 
			                    <td><%# Eval("bill_WebManager_realname").ToString()%></td>
			                    <td><%# Eval("bill_leader_realname").ToString()%></td>
			                    <td><%# Eval("bill_reason").ToString()%></td>
			                    <td><%# Eval("bill_staff_worker").ToString()%></td>
			                    <td><%# Eval("bill_total_money").ToString()%></td>
			                    <td><%# Eval("bill_Createtime").ToString()%></td>
                                <td><%# Eval("bill_lock").ToString()=="1"?"已锁定":"-"%> <%# Eval("bill_receive").ToString()=="1"?"已发放":""%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages">
            </div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
    <script language="javascript">
        function Lock_Click() {
            if ($('#ddl_bill_leader_realname option:selected').val() == "") {
                window.alert("请选择团队！");
                return false;

            } else {
                return window.confirm("确定锁定 " + $('#ddl_bill_month option:selected').text() + " 月 " + $('#ddl_bill_leader_realname option:selected').text() + " 团队的餐费报销吗？\n锁定后团队成员不能再删除已有的；\n团队成员也不能添加新的。");
            }
        }
    </script>
</body>
</html>
