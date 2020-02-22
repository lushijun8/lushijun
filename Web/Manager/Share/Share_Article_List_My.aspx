<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share_Article_List_My.aspx.cs" Inherits="Web.Manager.Share.Share_Article_List_My" %>

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
                共查到<font color=red><%=this.LogCount.ToString() %></font>条记录。
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th>分享人</th>
			            <th>标题</th>
			            <th><a href="Share_Article_List_My.aspx?orderby=Article_createtime+desc" class="orderby">↓</a>日期</th>
			            <th><a href="Share_Article_List_My.aspx?orderby=Article_good+desc" class="orderby">↓</a>点赞数</th>
                        <th>点赞人</th>
                        <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# (Container.ItemIndex+1)+(this.P_page-1)*20%></td> 
                                <td width="100"><%# Eval("WebManager_RealName")%></td>
			                        <td width="400"><a href="<%# Business.Config.HostUrl %>/Manager/Share/Share_Article_View.aspx?Article_Id=<%# Com.Common.EncDec.Encrypt( Eval("Article_id").ToString(), this.Encrypt_key)%>" target="_blank">
                                        <%# string.IsNullOrEmpty(Eval("Article_Title").ToString())?Com.Common.StringUtil.GetLenContent(Eval("Article_Text").ToString(),80):Eval("Article_Title").ToString()%>
			                            </a></td>
			                        <td width="125"><%# Eval("Article_createtime")%></td>
			                        <td><%# Eval("Article_good")%></td>
			                        <td><%# Eval("Article_good_WebManager_RealName")%></td>
			                        <td width="120"><a href="<%# Business.Config.HostUrl %>/Manager/Share/Share_Article_SendEamil.aspx?Article_Id=<%# Com.Common.EncDec.Encrypt( Eval("Article_id").ToString(), this.Encrypt_key)%>" target="_blank" onclick="javascript:return window.confirm('确定再群发邮件吗？');">邮件分享</a> |
                                        <a href="<%# Business.Config.HostUrl %>/Manager/Share/Share_Article_Edit.aspx?Article_Id=<%# Com.Common.EncDec.Encrypt( Eval("Article_id").ToString(), this.Encrypt_key)%>" target="_blank" onclick="javascript:return window.confirm('确定编辑吗？');">编辑</a> | 
                                        <a href="<%# Business.Config.HostUrl %>/Manager/Share/Share_Article_Delete.aspx?Article_Id=<%# Com.Common.EncDec.Encrypt( Eval("Article_id").ToString(), this.Encrypt_key)%>" target="_blank" onclick="javascript:return window.confirm('确定删除吗？');">删除</a>

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
