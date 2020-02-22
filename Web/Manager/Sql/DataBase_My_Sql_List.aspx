<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_My_Sql_List.aspx.cs" Inherits="Web.Manager.Sql.DataBase_My_Sql_List" %>

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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼,<asp:Repeater ID="rpt_database_sql_stats_sum" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                �������SQL��:<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=BadRate+ASC"><span class="red">ȱ��<%# Eval("Lack_With_NoLock_Count")%>��WITH(NOLOCK)</span> , <span class="red">��<%# Eval("Select_All_Count")%>��SELECT*</span>  ,  <span class="red">��<%# Eval("Like_Count")%>��LIKEģ����ѯ</span>  , <span class="black">��<%# Eval("Lack_Parameter_Count")%>����ֵδ������</span> ,  <span class="red">��<%# Eval("Count_All")%>��Count(*)</span>  , <span class="red">������<%# Eval("BadRate")%> %</span> , SQL��д�淶����<span class="red">��<%=this.BadSql_Rank_My==-1?"?":this.BadSql_Rank_My.ToString() %>λ</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=Worker_Time+ASC"><span class="red">ƽ����ʱ<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>��</span> �� ��������<span class="red">��<%=this.Worker_Time_Rank_My==-1?"?":this.Worker_Time_Rank_My.ToString() %>λ</span></a>
			                </ItemTemplate>
		                </asp:Repeater> ��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                  <p>&nbsp;</p> 
                      <a <%= this.P_Bug_Type=="0"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=0">ȱ��WITH(NOLOCK)</a>
                      <a <%= this.P_Bug_Type=="1"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=1">SELECT*</a>
                      <a <%= this.P_Bug_Type=="2"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=2">LIKE</a>
                      <a <%= this.P_Bug_Type=="3"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=3">��ֵδ������</a>
                      <a <%= this.P_Bug_Type=="4"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=4">COUNT(*)</a>
                      <a <%= this.P_Bug_Type=="5"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=5">��дȨ��δ�ֿ�</a>
                      <a <%= this.P_Bug_Type==""?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=">ȫ��</a>
                  
                <%-- <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_My_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>&today=<%# Eval("Date")%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> --%>
	            <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=last_execution_time+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ִ��ʱ��</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=DATABASE_IP+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ�IP</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=DATABASE_USER+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ��û�</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=DATABASE_NAME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ�����</th>
			            <th> 
                            <a href="javascript:void(0)" onclick="javascript:showhide_td(this);" id="showhide_td">ִ��SQL������</a>  
			            </th> 
                        <th><a href="DataBase_My_Sql_List.aspx?orderby=SQL_ERROR+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>©��������</th>
                        <th><a href="DataBase_My_Sql_List.aspx?orderby=WebManager_name+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>������</th>
                        <th>����</th>
			            <th>����</th> 
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=execution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>��</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_worker_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>ռcpu(����)</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_elapsed_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>ִ��(����)</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_physical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�����(��)</th>
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_logical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�߼���(��)</th> 
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_logical_writes%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�߼�д(��)</th> 
			            <th><a href="DataBase_My_Sql_List.aspx?orderby=total_rows%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>Ӱ��(��)</th> 
			            <th>���飫</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="120"><%# Eval("LAST_EXECUTION_TIME")%></td>
			                        <td width="80"><%# Eval("DATABASE_IP")%></td>
			                        <td width="80"<%# (Eval("ISWRONGDATABASEUSER").ToString()=="1"&&Eval("ISRUNTIMESQL").ToString()=="1")?" class=wronguser":""%>><%# Eval("DATABASE_USER")%></td>
			                        <td width="80"><%# Eval("DATABASE_NAME")%></td>
			                        <td><div class="cell" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><%# Eval("TEXT_ANALYSIS")%></div></td>
                                    <td width="150" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><div class="cell"><span class=red><%# Eval("SQL_ERROR")%></span></div></td>
			                        <td><%# Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMySql").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_List.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��ɾ����')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_List.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��������')\">����</a>"%></td> 
                                    <td><%# Eval("TEXT_ANALYSIS").ToString().Length%></td>
			                        <td><%# Eval("execution_count")%></td>
			                        <td><%# (Convert.ToDecimal(Eval("total_worker_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td><%# (Convert.ToDecimal(Eval("total_elapsed_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td><%# Convert.ToDecimal(Eval("total_physical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td><%# Convert.ToDecimal(Eval("total_logical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td><%# Convert.ToDecimal(Eval("total_logical_writes/execution_count").ToString()).ToString("f0")%></td>
                                    <td><%# Convert.ToDecimal(Eval("total_rows/execution_count").ToString()).ToString("f0")%></td>
			                        <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');" id="s_v_<%# Eval("sql_md5")%>">����<%# Container.ItemIndex==0?"��":"��"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("sql_md5")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="17" style="border:1px solid #cccccc">
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
