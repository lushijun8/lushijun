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
                <font color="red"> * ��˾�涨���ϼӰൽ��7���Ժ���ܱ����ͷѣ���ȷ�������˵�����7���Ժ��п��ڴ򿨼�¼����Ϳ�����7��ǰԤ��������Ϊ�����鿼�ڣ���ĩ�Ӱ౨����Ҳ��Ҫ�п��ڴ򿨼�¼��</font><br />
                                        <font color="red"> * ���ڷ�Ʊ����ǩ�ϱ����˵�������ͬ��ͬ�ߴ�ķ�Ʊ���ŷ�Ʊ����ý�ˮ����һ���ٽ�������Ŷӳ�</font> <%=this.CurrentWebManagerLeaderRealName %>��<br />   
                                        <font color="red"> * ����Ʊ���λ����<font color=black>�����갶ͼ�����缼�����޹�˾</font>���������ȷ���ܱ�����</font><br />
                                        <font color="red"> * �Ӱ�ͷѱ���ʹ�ù�˰�ּ��Ƶķ�Ʊ���ܱ�����</font><br />
                                        <font color="red"> * һ�μӰ�ļ����ˣ�һ�𶩲͵��ˣ�����һ��ͳһ�������ɡ�</font><br />
                                        <%--<font color="red"> * ÿ��Ӱ�����ʱ����Ҫ���ʼ��������ް�caoyanbai@fang.com��,�����͸�����Ŷӳ������б������������Ӱ��ʱ���Դ�Ϊ���ݡ�Ҫ�����£�</font><br /> 
                                        <font color="red">01���Ӱ��������ʱ���͡�</font><br />
                                        <font color="red">02��һ�μӰ�ļ����ˣ�һ�������ˣ�����һ��ͳһ���ʼ����ɡ�</font><br />
                                        <font color="red">03���ʼ�����Ϊ���Ӱ౸�� xxxx-xx-xx xx:xx:xx���������г���Ա�������ɡ�</font><br /> --%>
                ���鵽<font color=red><%=this.LogCount.ToString() %></font>����¼��
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>���</th>
			            <th>����</th>
			            <th><a href="Bill_List_My.aspx?orderby=bill_date+desc" class="orderby">��</a>��������</th>
			            <th>������</th>
			            <th>�����Ŷ�</th>
			            <th>����</th>
			            <th>��Ա</th>
			            <th><a href="Bill_List_My.aspx?orderby=bill_total_money+desc" class="orderby">��</a>���(Ԫ)</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
                                 <td>�ͷ�</td>
			                     <td><%# DateTime.Parse(Eval("bill_date").ToString()).ToShortDateString()%></td>
			                     <td><%# Eval("bill_WebManager_realname").ToString()%></td>
			                     <td><%# Eval("bill_leader_realname").ToString()%></td>
			                     <td><%# Eval("bill_reason").ToString()%></td>
			                     <td><%# Eval("bill_staff_worker").ToString()%></td>
			                     <td><%# Eval("bill_total_money").ToString()%></td>
			                     <td><%# Eval("bill_lock").ToString()=="1"?"������":"<a href=\""+Business.Config.HostUrl+"/Manager/Bill/Bill_Delete.aspx?v="+ Com.Common.EncDec.Encrypt( Eval("bill_WebManager_name").ToString()+","+Eval("bill_date").ToString(), this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('ȷ��ɾ����');\">ɾ��</a>"%>
                                      <%# Eval("bill_receive").ToString()=="1"?"�ѷ���":""%>
			                     </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--����-->
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
