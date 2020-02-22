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
                </asp:DropDownList>��
                <asp:DropDownList ID="ddl_bill_month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bill_month_SelectedIndexChanged">
                </asp:DropDownList>��                 
                <asp:DropDownList ID="ddl_bill_leader_realname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_bill_leader_realname_SelectedIndexChanged">
                </asp:DropDownList>�Ŷ�
                 
                <asp:Button CssClass="button" ID="btn_Lock" runat="server" Text="������������" OnClick="btn_Lock_Click" OnClientClick="javascript:return Lock_Click();" />
                 <!--��ʼ-->
	            <p>&nbsp;</p>
                <h2>����,��<font color="red"><%=this.TotalSum.ToString() %></font>Ԫ��</h2>
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>��������</th>
			            <th>����</th>
			            <th>�ò���Ա</th>
			            <th>��ͨ��</th>
			            <th>�����ͷ�</th>
                        <%if(this.CurrentIsAdmin==true){ %>
			            <th>����</th>
                        <%} %>
		            </tr>
		            <asp:Repeater ID="rpt_sum" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# DateTime.Parse( Eval("bill_date").ToString()).ToShortDateString()%></td> 
			                    <td>�Ӱ��ò�(<%# Eval("bill_reason").ToString()%>)</td>
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
                <h2>���Ŷӻ��ܣ�</h2>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>�Ŷ�</th>
			            <th>�����ͷ�</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rpt_sum_by_leader" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("bill_leader_realname").ToString()%></td> 
			                    <td><%# Eval("bill_total_money").ToString()%></td>
                                <td><%# Eval("bill_lock").ToString()=="1"?"������ ":"-"%>  
                                     <%if (this.CurrentIsAdmin == true) {%>
                                    <%# Eval("bill_lock").ToString()=="1"?(Eval("BILL_RECEIVE").ToString()=="1"?"�ѷ���":"<a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Receive.aspx?v="+Com.Common.EncDec.Encrypt(Eval("bill_leader_realname").ToString()+","+this.ddl_bill_year.SelectedValue+","+this.ddl_bill_month.SelectedValue+",1",this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('ȷ����');\">��ȡ���ʼ�</a> <a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Receive.aspx?v="+Com.Common.EncDec.Encrypt(Eval("bill_leader_realname").ToString()+","+this.ddl_bill_year.SelectedValue+","+this.ddl_bill_month.SelectedValue+",0",this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('ȷ����');\">��ȡ�����ʼ�</a>"):"-"%>  
                                    <% }%>                                    
                                </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
                
                <h2>���������ܣ�</h2>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>����</th>
			            <th>�����ͷ�</th>
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
                <h2>������ϸ��</h2>
                 <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>��������</th>
			            <th>������</th>
			            <th>�����Ŷ�</th>
			            <th>����</th>
			            <th>�ò���Ա</th>
			            <th>�����ͷ�</th>
			            <th>¼��ʱ��</th>
			            <th>����</th>
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
                                <td><%# Eval("bill_lock").ToString()=="1"?"������":"-"%> <%# Eval("bill_receive").ToString()=="1"?"�ѷ���":""%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--����-->
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
                window.alert("��ѡ���Ŷӣ�");
                return false;

            } else {
                return window.confirm("ȷ������ " + $('#ddl_bill_month option:selected').text() + " �� " + $('#ddl_bill_leader_realname option:selected').text() + " �ŶӵĲͷѱ�����\n�������Ŷӳ�Ա������ɾ�����еģ�\n�Ŷӳ�ԱҲ��������µġ�");
            }
        }
    </script>
</body>
</html>
