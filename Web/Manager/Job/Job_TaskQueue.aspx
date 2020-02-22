<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_TaskQueue.aspx.cs" Inherits="Web.Manager.Job.Job_TaskQueue" %>

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
                共查到<font color= "red"><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>本地URL（数据库）</th>
			            <th>请求外部URL（执行SQL）</th>
			            <th>编码方式</th>
			            <th>执行状态</th>
			            <th>请求～执行时间</th>	 					 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> onclick="javascript:showhide('v_<%# Eval("id")%>');" style="cursor:pointer;">
                                 <td width="120"><%# Eval("database_name")%><br /><%# Eval("id")%><br /><%# Eval("Creator")%></td>
			                        <td><%# Eval("RequestUrl")%></td>
			                        <td><%# Eval("URL")%></td>
			                        <td><%# Eval("CodeType").ToString()=="0"?"gb2312":"utf8"%></td>
			                        <td><%# Eval("ExecutedTime").ToString()==""?"":((DateTime.Parse( Eval("ExecutedTime").ToString()) - DateTime.Parse( Eval("CreateTime").ToString())).TotalSeconds.ToString()+" 秒<br>")%>
                                        <%# Eval("State").ToString()=="0"?"<font color=red>未执行</font>":"完成"%></td>
			                        <td width="120"><%# Eval("CreateTime")%>～<br /><%# Eval("ExecutedTime")%></td>			           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("id")%>" style="<%# Container.ItemIndex==0?"":"display:none;"%>background-color:lightyellow;">
                                 <td colspan="11" style="border:1px solid #cccccc">返回内容：
                                     <p><%# Server.HtmlEncode( Eval("XML").ToString()).Replace("\t","&nbsp;").Replace("\r\n","<br/>").Replace("&gt;&lt;","&gt;<br/>&lt;")%></p>
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
    </form>
</body>
</html>
