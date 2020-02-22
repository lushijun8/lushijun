<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_Log_List.aspx.cs" Inherits="Web.Manager.Job.Job_Log_List" %>

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
            if (window.confirm("确定吗?\r\n" + pageurl) == true) {
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
            }
            else {
                $("#" + id).show();
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
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找TaskID：
                <asp:TextBox ID="txtKeyword" runat="server" Width="30%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />  
                 &nbsp;<!--开始--><table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th><input type="checkbox" id="checkall" value="checkall" name="checkall">全选
                 
                            <br />
                <asp:Button CssClass="button" ID="btnDeleteFile" runat="server" Text="删除所选日志文件" OnClick="btnDeleteFile_Click" OnClientClick="javascript:return confirm_me('删除所选日志文件？');" />  
                            <br />
                <asp:Button CssClass="button" ID="btnDelete0" runat="server" Text="删除所选记录" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm_me('删除所选记录？');" />  
                        </th>
			            <th>序号</th>
			            <th>环境</th>
			            <th><a href="Job_Log_List.aspx?orderby=taskid&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>TASKID</th>
			            <th><a href="Job_Log_List.aspx?orderby=filepath&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>日志文件路径</th>
			            <th><a href="Job_Log_List.aspx?orderby=filesize&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>文件大小</th>
			            <th><a href="Job_Log_List.aspx?orderby=lastwritetime&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>文件更新时间</th>
			            <th><a href="Job_Log_List.aspx?orderby=createtime&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>创建时间</th> 
			            <th>是否删除</th> 
			            <th>备注</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> onclick="javascript:showhide('v_<%# (Container.ItemIndex+1)+(P_page-1)*20%>');" style="cursor:pointer;">
                                 <td>
                                    <input type="checkbox" id="filepath_<%# Com.Common.EncDec.PasswordEncrypto(Eval("filepath").ToString())%>" value="<%# Eval("database_name")%>|<%# Eval("filepath")%>" name="filepath">
                                 </td>	
                                <td><%# this._PageSize*(this.P_page-1)+ Container.ItemIndex+1%></td> 
                                 <td><%# Eval("database_name")%></td>
			                     <td<%# this.P_OrderBy.ToLower()=="taskid"?" class=orderby":""%>>
                                     <%# Eval("taskid")%>
                                 </td>			                     
			                     <td<%# this.P_OrderBy.ToLower()=="filepath"?" class=orderby":""%>>
                                     <%# Eval("filepath")%>
			                     </td>			                     
			                     <td<%# this.P_OrderBy.ToLower()=="filesize"?" class=orderby":""%>>
                                     <%# Eval("filesizestr")%>
			                     </td>
			                     <td<%# this.P_OrderBy.ToLower()=="lastwritetime"?" class=orderby":""%>>
                                     <%# Eval("lastwritetime")%>
			                     </td>
			                     <td<%# this.P_OrderBy.ToLower()=="createtime"?" class=orderby":""%>>
                                     <%# Eval("createtime")%>
			                     </td>
			                     <td<%# this.P_OrderBy.ToLower()=="needdelete"?" class=orderby":""%>>
                                     <%# Eval("needdelete").ToString()=="0"?"正常":""%>
                                     <%# Eval("needdelete").ToString()=="1"?"删除中..":""%>
                                     <%# Eval("needdelete").ToString()=="9"?"已删除":""%>
			                     </td>
			                     <td> 
                                     <%# Eval("remark")%>
			                     </td>
				            </tr>      
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages"><%=outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
          <script language="javascript">
              $("#checkall").click(function () {
                  $("input[type='checkbox']").each(function () {
                      if ($(this).attr("id") != "checkall" && $(this).is(":disabled")== false) {
                          $(this).attr("checked", $("#checkall").is(":checked"));
                      }
                  })
              })
     </script>
    </form>
</body>
</html>
