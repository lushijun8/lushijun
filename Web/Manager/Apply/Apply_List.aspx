<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply_List.aspx.cs" Inherits="Web.Manager.Apply.Apply_List" %>

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
                <asp:DropDownList ID="ddl_apply_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_apply_year_SelectedIndexChanged">
                </asp:DropDownList>年
                <asp:DropDownList ID="ddl_apply_month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_apply_month_SelectedIndexChanged">
                </asp:DropDownList>月<asp:Button CssClass="button" ID="btn_Lock" runat="server" Text="锁定该月数据" OnClick="btn_Lock_Click" OnClientClick="javascript:return Lock_Click();" /><br />
                 &nbsp;共查到<font color=red><%=this.LogCount.ToString() %></font>条记录,总共申请<font color=red><%=this.Apply_Pen.ToString() %></font>支笔，<font color=red><%=this.Apply_PenLead.ToString() %></font>支笔芯，<font color=red><%=this.Apply_Book.ToString() %></font>个笔记簿，<font color=red><%=this.Apply_Glue.ToString() %></font>个胶水，<font color=red><%=this.Apply_NotePaper.ToString() %></font>个便签纸。
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th>时间</th>
			            <th>申请人</th>
			            <th>申请月份</th>
			            <th>用品</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
                                 <td><%# Eval("Apply_CreateTime").ToString()%></td>
                                 <td><%# Eval("Apply_WebManager_realname")%></td> 
                                 <td><%# Eval("Apply_year")%>年<%# Eval("Apply_month")%>月</td> 
                                 <td><%# Eval("Apply_pen").ToString()=="1"?"1支笔、":""%>
                                     <%# Eval("Apply_penlead").ToString()=="1"?"1支笔芯、":""%>
                                     <%# Eval("Apply_book").ToString()=="1"?"1个笔记簿、":""%>
                                     <%# Eval("Apply_glue").ToString()=="1"?"胶水、":""%>
                                     <%# Eval("Apply_notepaper").ToString()=="1"?"便签纸、":""%>
                                 </td> 
			                     <td><%# Eval("Apply_lock").ToString()=="1"?"已锁定":"未锁定"%>                                       
                                     <%# Eval("Apply_Receive").ToString()=="1"?"已发放":"<a href=\""+Business.Config.HostUrl+"/Manager/Apply/Apply_Receive.aspx?v="+ Com.Common.EncDec.Encrypt(Eval("Apply_WebManager_name").ToString()+","+Eval("Apply_year").ToString()+","+Eval("Apply_month").ToString(), this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('确定领取吗？');\">领取</a>"%>                                  
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
