<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_My_Sql_Ignore_List_All.aspx.cs" Inherits="Web.Manager.Sql.DataBase_My_Sql_Ignore_List_All" %>

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
    <script language="javascript">
        function confirm_me(pageurl) {
            if (window.confirm("ȷ����?\r\n" + pageurl) == true) {
                return true;
            }
            return false;
        }
        function showhide(id) {
            var ishidden = 0;
            $("#" + id).each(function () {
                if ($(this).is(":hidden")) {
                    ishidden = 1;
                }
            });
            if (ishidden == 0) {
                $("#" + id).hide();
                $("#s_" + id).text("���飫");
            }
            else {
                $("#" + id).show();
                $("#s_" + id).text("���飭");
            }
        }
        function showhide_td() {
            if ($("#showhide_td").text() == "ִ��SQL������") {

                $(".cell").css("overflow", "visible");
                $(".cell").css("height", "auto");
                $(".cell").css("white-space", "pre-wrap");
                $("#showhide_td").text("ִ��SQL������");
            }
            else {
                $(".cell").css("overflow", "hidden");
                $(".cell").css("height", "20px");
                $(".cell").css("white-space", "normal");
                $("#showhide_td").text("ִ��SQL������");
            }
        }
     </script>
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
			<!--��ʼ-->
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                <%-- <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> --%>
	            <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=last_execution_time+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>���ִ��ʱ��</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_IP+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>���ݿ�IP</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_USER+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>���ݿ��û�</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_NAME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>���ݿ�����</th>
			            <th> 
                            <a href="javascript:void(0)" onclick="javascript:showhide_td(this);" id="showhide_td">ִ��SQL������</a>  
			            </th> 
                        <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=SQL_ERROR+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>©��������</th>
                        <th>������</th>
                        <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=WebManager_name+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>������</th>
                        <th>����</th>
                        <th>ɾ��</th>
			            <th>����</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=execution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>��</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_worker_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>ռcpu(����)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_elapsed_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>ִ��(����)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_physical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>�����(��)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_logical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>�߼���(��)</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_logical_writes%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>�߼�д(��)</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_rows%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">��</a>Ӱ��(��)</th> 
			            <th>���飫</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="120"<%# this.P_orderby.ToLower()=="last_��xecution_time desc"?" class=orderby":""%>><%# Eval("LAST_EXECUTION_TIME")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_ip desc"?" class=orderby":""%>><%# Eval("DATABASE_IP")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_user desc"?" class=orderby":""%>><%# Eval("DATABASE_USER")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_name desc"?" class=orderby":""%>><%# Eval("DATABASE_NAME")%></td>
			                        <td><div class="cell" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><%# Eval("TEXT_ANALYSIS")%></div></td>
                                    <td width="150" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><div class="cell"><span class=red><%# Eval("SQL_ERROR")%></span></div></td>
			                        <td><%# Eval("WebManager_RealName").ToString()%></td> 
			                        <td><%# Eval("WebManager_RealName_Charge").ToString()%></td> 
                                    <td><%# Eval("IsMy_Charge").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��ɾ����')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��������')\">����</a>"%></td> 
                                    <td><%# Eval("IsMy_Ignore").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('ȷ��ɾ����')\">ɾ��</a>":"-"%></td> 
                                    <td><%# Eval("TEXT_ANALYSIS").ToString().Length%></td>
			                        <td<%# this.P_orderby.ToLower()=="��xecution_count desc"?" class=orderby":""%>><%# Eval("execution_count")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_worker_time/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_worker_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_elapsed_time/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_elapsed_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_physical_reads/��xecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_physical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_reads/��xecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_logical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_writes/��xecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_logical_writes/execution_count").ToString()).ToString("f0")%></td>
                                    <td<%# this.P_orderby.ToLower()=="total_rows/��xecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_rows/execution_count").ToString()).ToString("f0")%></td>
			                        <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');" id="s_v_<%# Eval("sql_md5")%>">����<%# Container.ItemIndex==0?"��":"��"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("sql_md5")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="19" style="border:1px solid #cccccc">
                                     <p><%# Eval("TEXT_ANALYSIS").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p> 
                                      <br />---------------------------------------------------------------------
                                     <br />(<b><%# Convert.ToDecimal(Eval("total_rows/execution_count").ToString()).ToString()%> ����Ӱ��</b>)
                                     <br />�߼���ȡ <%# Convert.ToDecimal(Eval("total_logical_reads/execution_count").ToString()).ToString("f0")%> �Σ������ȡ <%# Convert.ToDecimal(Eval("total_physical_reads/execution_count").ToString()).ToString("f0")%> �Ρ�

                                     <br />SQL Server ִ��ʱ��:
                                     <br />  CPU ʱ�� = <%# (Convert.ToDecimal(Eval("total_worker_time/execution_count").ToString())/1000).ToString("f0")%> ���롣

                                     <br />SQL Server ִ��ʱ��:
                                      <br /> CPU ʱ�� = <%# (Convert.ToDecimal(Eval("total_elapsed_time/execution_count").ToString())/1000).ToString("f0")%> ���롣
                                      <br />----------------------------------------------------------------------
                                     <br />(<b>©��������</b>)
                                     <br /><span class=red><%# Eval("SQL_ERROR")%></span>
                                     <br />----------------------------------<br />(<b>�޸Ľ���</b>)<br>1��������Ҫ��LIKEģ����ѯ��<br>2����Ҫʹ��COUNT(*)�����Ըĳ�COUNT(1)����Ȼ�ֶι���Ļ���ѯЧ���½���<br>3����ѯ����ȱ��WITH(NOLOCK)��<br>4����ֵ��ʹ�ò���������Ȼ���ױ�������<br>5����Ҫʹ��SELECT*����д����ȷ���ֶΣ���Ȼ�ֶι���Ļ���ѯЧ���½���
                                     <br />
                                     <%# Eval("PageUrl").ToString()=="" ?"":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+Server.UrlEncode(Eval("PageUrl").ToString())+"\" target=_blank>"+Eval("PageUrl").ToString()+"</a> "+( Eval("IsMyUrl").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ������</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">�����URL</a>")%>
                                      
                                 </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--����-->
	  		</div> 
	  		<div class="Body_Pages">
                  <%=this.outPage %>
	  		</div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
     <script language="javascript">
         //showhide_td();
    </script>
</body>
</html>
