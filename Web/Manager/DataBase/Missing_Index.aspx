<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Missing_Index.aspx.cs" Inherits="Web.Manager.DataBase.Missing_Index" %>
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
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>  
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
              if ($("#showhide_td").text() == "�����У�����") {

                  $(".cell").css("overflow", "visible");
                  $(".cell").css("height", "auto");
                  $(".cell").css("width", "120px");
                  $(".cell").css("white-space", "pre-wrap");
                  $("#showhide_td").text("�����У�����");
              }
              else {
                  $(".cell").css("overflow", "hidden");
                  $(".cell").css("height", "20px");
                  $(".cell").css("white-space", "normal");
                  $("#showhide_td").text("�����У�����");
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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>
                <asp:TextBox ID="txtKeyword" runat="server" Width="166px"></asp:TextBox>
                 
                ��������<asp:DropDownList ID="ddl_DataBase_Ip_Romote" runat="server">
                </asp:DropDownList>
                 
                ���ݿ⣺<asp:DropDownList ID="ddl_DataBase_Name" runat="server">
                </asp:DropDownList>
                 
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                   <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Missing_Index.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> 
                <!--stats��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" style="white-space:nowrap">
		            <tr>
			            <th>���</th>  
                        <th><a href="Missing_Index.aspx?orderby=DataBase_IP_Romote+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>���ݿ�IP</th>  
                        <th><a href="Missing_Index.aspx?orderby=statement+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>���ݿ���..����</th>  
                        <th>������</th>
                        <th>����</th>
                        <th><a href="Missing_Index.aspx?orderby=equality_columns+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>��ʽ��</th> 
                        <th><a href="Missing_Index.aspx?orderby=inequality_columns+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>�ǵ�ʽ��</th>  
                        <th><a href="Missing_Index.aspx?orderby=included_columns+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a><a href="javascript:void(0)" onclick="javascript:showhide_td(this);" id="showhide_td">�����У�����</a> </th> 
                        <th title="���Ӹ�ȱʧ����������ı�������±�������  ��಻ͬ��ѯ�ı�������±����Ӱ�����ֵ��"><a href="Missing_Index.aspx?orderby=unique_compiles+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>��ʡ������</th> 
                        <th title="�ɿ���ʹ�������н����������û���ѯ�����µĲ��Ҵ�����"><a href="Missing_Index.aspx?orderby=user_seeks+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>�����д���</th> 
                        <%--<th><a href="Missing_Index.aspx?orderby=user_scans+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>user_scans</th>  --%>
                        <%--<th><a href="Missing_Index.aspx?orderby=last_user_scan+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>last_user_scan</th>  --%>
                        <th title="��ͨ�����е��������ٵ��û���ѯ��ƽ���ɱ�"><a href="Missing_Index.aspx?orderby=avg_total_user_cost+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>ƽ����ʡʱ(��)</th>  
                        <th title="ʵ�ִ�ȱʧ��������û���ѯ���ܻ�õ�ƽ���ٷֱ����档 ��ֵ��ʾ���ʵ�ִ�ȱʧ�����飬���ѯ�ɱ������˰ٷֱ�ƽ���½�"><a href="Missing_Index.aspx?orderby=avg_user_impact+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>ƽ��������</th> 
                        <th><a href="Missing_Index.aspx?orderby=Total_Cost+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>���ɽ�ʡ(Сʱ)</th> 
                        <th title="�ɿ���ʹ�������н����������û���ѯ�����µ��ϴβ������ں�ʱ�䡣"><a href="Missing_Index.aspx?orderby=last_user_seek+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>���������ʱ��</th>  
                        <%--<th><a href="Missing_Index.aspx?orderby=system_seeks+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>system_seeks</th>  
                        <th><a href="Missing_Index.aspx?orderby=system_scans+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>system_scans</th>  
                        <th><a href="Missing_Index.aspx?orderby=last_system_seek+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>last_system_seek</th>  
                        <th><a href="Missing_Index.aspx?orderby=last_system_scan+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>last_system_scan</th>  
                        <th><a href="Missing_Index.aspx?orderby=avg_total_system_cost+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>avg_total_system_cost</th>  
                        <th><a href="Missing_Index.aspx?orderby=avg_system_impact+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.P_Today) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">��</a>avg_system_impact</th>--%>

                               
			            <th>�˱� ��¼��</th> 
			            <th>�˱� �ֶ���</th>  
			            <th>�˱� �����ռ�</th> 
			            <th>�˱� ʹ�ÿռ�</th> 
			            <th>�˱� ����ʹ�ÿռ�</th> 
			            <th>�˱� δ�ÿռ�</th> 
		           

                        <th>���飫</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> onclick="javascript:showhide('v_<%# (Container.ItemIndex+1)+(P_page-1)*20%>');" style="cursor:pointer;">
					            <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="database_ip_romote desc"?" class=orderby":""%>><%# Eval("DataBase_IP_Romote")%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="statement desc"?" class=orderby":""%>>
                                   <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=<%# Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)%>#<%#  Eval("Table_Name").ToString()%>" target="_blank">
                                       <%# Eval("statement").ToString().Replace("[dbo]","")%>
                                   </a> <span class="indexs_tooltip <%# Eval("DataBase_Name").ToString()+"_"+Eval("Table_Name").ToString()%>" id="<%# Eval("DataBase_Name").ToString()+"."+Eval("Table_Name").ToString()%>"></span>
                                 </td>  
                                <td><%# Eval("WebManager_RealName").ToString().Replace(",","<br>")%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Table_My_Delete.aspx?v="+Com.Common.EncDec.Encrypt(Eval("DataBase_Name").ToString()+","+Eval("Table_Name").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('ɾ������?')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Table_My_Add.aspx?v="+Com.Common.EncDec.Encrypt(Eval("DataBase_Name").ToString()+","+Eval("Table_Name").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('����?')\">����</a>"%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="equality_columns desc"?" class=orderby":""%>><div class="cell" title="<%# Eval("equality_columns")%>"><%# Eval("equality_columns").ToString().Replace(",","<br>")%></div></td> 
                                <td<%# this.P_OrderBy.ToLower()=="inequality_columns desc"?" class=orderby":""%>><div class="cell" title="<%# Eval("inequality_columns")%>"><%# Eval("inequality_columns").ToString().Replace(",","<br>")%></div></td>  
                                <td<%# this.P_OrderBy.ToLower()=="included_columns desc"?" class=orderby":""%>><div class="cell" title="<%# Eval("included_columns")%>"><%# Eval("included_columns").ToString().Replace(",","<br>")%></div></td> 
                                <td<%# this.P_OrderBy.ToLower()=="unique_compiles desc"?" class=orderby":""%>><%# Eval("unique_compiles")%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="user_seeks desc"?" class=orderby":""%>><%# Eval("user_seeks")%></td> 
                                <%--<td><%# Eval("user_scans")%></td> --%>  
                                <%--<td><%# Eval("last_user_scan")%></td>  --%>
                                <td<%# this.P_OrderBy.ToLower()=="avg_total_user_cost desc"?" class=orderby":""%>><%# (float.Parse(Eval("avg_total_user_cost").ToString()==""?"0":Eval("avg_total_user_cost").ToString())/1000).ToString("f2").Replace(".00","")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="avg_user_impact desc"?" class=orderby":""%>><%# Eval("avg_user_impact")%> %</td>
                                <td<%# this.P_OrderBy.ToLower()=="total_cost desc"?" class=orderby":""%>><%# (decimal.Parse(Eval("total_cost").ToString())/3600000).ToString("f2").Replace(".00","")%></td>
                                <%--<td><%# Eval("system_seeks")%></td>  
                                <td><%# Eval("system_scans")%></td>  
                                <td><%# Eval("last_system_seek")%></td>  
                                <td><%# Eval("last_system_scan")%></td>  
                                <td><%# Eval("avg_total_system_cost")%></td>  
                                <td><%# Eval("avg_system_impact")%></td> --%>
                                <td<%# this.P_OrderBy.ToLower()=="last_user_seek desc"?" class=orderby":""%>><%# Eval("last_user_seek")%></td> 	
                                    
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts"?" class=orderby":""%>><%#Eval("RowCounts")%> </td>
                                <td<%# this.P_OrderBy.ToLower()=="columncounts"?" class=orderby":""%>><%#Eval("ColumnCounts")%> </td>

                                <td<%# this.P_OrderBy.ToLower()=="space_allocation"?" class=orderby":""%>><%#Eval("Space_Allocation_String")%> </td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_used"?" class=orderby":""%>><%# Eval("Space_Used_String")%> </td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_index_used"?" class=orderby":""%>><%# Eval("Space_Index_Used_String")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_available"?" class=orderby":""%>><%# Eval("Space_Available_String")%> </td>  

                                <td>����<%# Container.ItemIndex==0?"��":"��"%></td>	                                    				           
				            </tr>
                              <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# (Container.ItemIndex+1)+(P_page-1)*20%>" style="<%# Container.ItemIndex==0?"":"display:none;"%>background-color:lightblue;">
                                 <td colspan="21" style="border:1px solid #cccccc">
                                     <p>
                                         <font color=green>/**�����ǽ�����ȱʧ������SQL���,����������ȱʧ����������Ҫ����,��Ҫ�˹�Ȩ��,�����ĲŽ�,��Ϊ������ռӲ�̿ռ��,���һ�Ӱ����ɾ���ٶ�,��Ӱ�����ݸ�������**/</font>
                                        <br /><font color=blue>USE</font> [<%# Eval("statement").ToString().Split('.')[0].Replace("[","").Replace("]","")%>]
                                        <br /><font color=blue>GO</font>
                                        <br /><font color=blue>CREATE INDEX</font> [IDX_<%# Eval("group_handle")%>_<%# Eval("index_handle")%>_<%# Eval("statement").ToString().Split('.')[2].Replace("[","").Replace("]","")%><%# (string.IsNullOrEmpty(Eval("included_columns").ToString())||Eval("included_columns").ToString().Split(',').Length>4)?"":("_"+Eval("included_columns").ToString().Trim().Replace("]","").Replace("[","").Replace(",","_").Replace(" ",""))%>] 
                                        <br /><font color=blue>ON</font> <%# Eval("statement")%> (<%# Eval("equality_columns")%><%# (!string.IsNullOrEmpty(Eval("equality_columns").ToString()) && !string.IsNullOrEmpty(Eval("inequality_columns").ToString()))?",":""%><%# Eval("inequality_columns")%>)
                                        <%# string.IsNullOrEmpty( Eval("included_columns").ToString())?"":"<br /><font color=blue>INCLUDE</font> ("+Eval("included_columns").ToString().Replace(",",",<br>")+")"%>
                                        <br /><font color=blue>GO</font>
                                     </p>
                                     ------------------------------------------------------
                                     <br />������������<br />�ɼ��� <font color=red><%# Eval("unique_compiles")%></font> ��SQL����;
                                     ������ <font color=red><%# Eval("user_seeks")%></font> ������ ; ���һ�����н��� <font color=red><%# Eval("last_user_seek")%></font>;
                                     ƽ����ѯ�ɼ��� <font color=red><%# (float.Parse(Eval("avg_total_user_cost").ToString()==""?"0":Eval("avg_total_user_cost").ToString())/1000).ToString("f2").Replace(".00","")%></font> ��;
                                     ƽ�����ܿ����� <font color=red><%# Eval("avg_user_impact")%> %</font>; 
                                     �ɽ�ʡ�ܿ��� <font color=red><%# (decimal.Parse(Eval("total_cost").ToString())/3600000).ToString("f2").Replace(".00","")%></font>Сʱ;
                                     <%if(this.CurrentIsAdmin==true){ %>
                                     <br /><a href="Missing_Index_Create.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("DataBase_IP_Romote").ToString()+","+Eval("DataBase_Name").ToString()+","+Eval("Date").ToString()+","+Eval("index_handle").ToString()+","+Eval("group_handle").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('ȷ������������')">���̽�������</a>
                                     <%} %>
                                 </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--stats����-->
	  		</div>  
	  		<div class="Body_Pages"><%=outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
        <script language="javascript">
            $(".indexs_tooltip").mouseover(function (e) {
                if ($(this).attr("titles") == null) {
                    var id = $(this).attr("id");
                    var data = "v=" + id;
                    //��ѯ
                    $.ajax({
                        async: true,
                        type: "GET",
                        url: "<%=Business.Config.HostUrl%>/Manager/DataBase/Indexs.aspx",
                        cache: false,
                        timeout: 10 * 1000,
                        dataType: "json",
                        data: data,
                        success: function (result) {
                            $("." + id.replace(".", "_")).attr("titles", result.Message);
                        }
                    });
                }
            });
        </script>
    </form>
</body>
</html>