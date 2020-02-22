<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_List.aspx.cs" Inherits="Web.Manager.Job.Job_List" %>

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
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="30%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" /> <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Add.aspx" class="button" > <img id="plus" src="<%=Business.Config.HostUrl %>/images/plus.gif" style="border:none;vertical-align:middle;" height="22" />添加windows作业</a>
                &nbsp;&nbsp;&nbsp;
                <a <%=this.P_Type.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">全部</a>
                <a <%=this.P_Type.ToString()=="0"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=0&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">正式环境</a>
                <a <%=this.P_Type.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=1&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">测试环境</a>   
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_IsOpen.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">全部</a>
                <a <%=this.P_IsOpen.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=1&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">开启的</a>
                <a <%=this.P_IsOpen.ToString()=="0"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=0&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">关闭的</a>   
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_runType.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=&path=<%=Server.UrlEncode(this.P_path)%>">全部</a>
                <a <%=this.P_runType.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=1&path=<%=Server.UrlEncode(this.P_path)%>">间隔时间执行的</a>  
                <a <%=this.P_runType.ToString()=="2"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=2&path=<%=Server.UrlEncode(this.P_path)%>">每天执行一次的</a> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_path.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=">全部</a>
                <a <%=this.P_path.ToString()==".exe"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=.exe">EXE</a>  
                <a <%=this.P_path.ToString()=="http"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=http">HTTP</a> 

                 <br /> 正式环境Windows定时作业，对应 ftp://xujianshi:11E011Eq$J@124.251.50.114:33321  根目录E:\soufun\
                <br /> 测试环境Windows定时作业，对应 ftp://xujianshi:xujianshi@10.2.136.156  根目录E:\SouFunWeb\   ; 远程密码 1q2w#E$R
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th>环境</th>
			            <th><a href="Job_List.aspx?orderby=NAME&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>ID名称</th>
			            <th width="75">配置</th>
			            <th>描述</th>
			            <th><a href="Job_List.aspx?orderby=PATH&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>目录</th>
			            <th><a href="Job_List.aspx?orderby=RUNMINITEOF&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>执行时间</th>
			            <th width="125"><a href="Job_List.aspx?orderby=LASTRUNTIME&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>上次执行时间</th>
			            <th>执行</th>
			            <th width="65"><a href="Job_List.aspx?orderby=LOGLENGTH&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>日志</th>
			            <th><a href="Job_List.aspx?orderby=ISOPEN&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>开关状态</th>
			            <th><a href="Job_List.aspx?orderby=AUTHOR&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">↓</a>创建人</th>
			            <th>负责人</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> onclick="javascript:showhide('v_<%# (Container.ItemIndex+1)+(P_page-1)*20%>');" style="cursor:pointer;">
                                <td><%# this._PageSize*(this.P_page-1)+ Container.ItemIndex+1%></td> 
                                 <td><%# Eval("database_name")%></td>
			                     <td<%# this.P_OrderBy.ToLower()=="name"?" class=orderby":""%>>
                                     ID:<%# Eval("id")%>
                                    <br /><%# Eval("name")%>
                                    <br /><%# Eval("SVNSOURCECODE").ToString()==""?"":"<font color=red>"+ Eval("SVNSOURCECODE").ToString()+"</font>"%><%# Eval("ftp").ToString()==""?"":"<br/><font color=blue>"+ Eval("ftp").ToString()+"</font>"%>
                                 </td>
			                     <td>  
                                     <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Config.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>" target="_blank"><%# Eval("path").ToString().ToLower().StartsWith("http")?"":"App.Config"%></a><br />
                                     <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_CfgFiles.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>" target="_blank"><%# (Eval("path").ToString().ToLower().StartsWith("http") || string.IsNullOrEmpty(Eval("cfgfiles").ToString()))?"":"dbcfg.conf"%></a>                                    
			                     </td>
                                 <td>
                                      <%# Eval("taskdetail").ToString()!=""?"<span class=\"why_tooltip tooltip\" titles=\""+Eval("taskdetail").ToString().Replace("\"","'")+"\"></span>":""%>   
			                     </td>
			                     <td<%# this.P_OrderBy.ToLower()=="path"?" class=orderby":""%>><%# Eval("path")%></td>
			                     <td<%# this.P_OrderBy.ToLower().IndexOf("runminiteof")>-1?" class=orderby":""%>><%# Eval("runtypename")%></td>
			                     <td<%# this.P_OrderBy.ToLower()=="lastruntime"?" class=orderby":""%>><%# Eval("lastruntime")%> <br />~  <br /><%# Eval("lastruntimeend")%></td>
                                 <td><%# Eval("whatwrong")%><br /><%# Eval("isrunning").ToString()=="1"?"执行中...":""%><br /><%# Eval("Remark")%><br /><%# Eval("testDb").ToString()=="1"?"testdb..":""%><br /><a href="javascript:void(0);" title="<%# Eval("testDb_Remark")%>"><%# !string.IsNullOrEmpty(Eval("testDb_Remark").ToString())?"数据库连通性":""%></a></td>		
                                 <td<%# this.P_OrderBy.ToLower()=="loglength"?" class=orderby":""%>><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_LogTxt.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>" target="_blank"><%# (Eval("path").ToString().ToLower().StartsWith("http")|| Eval("logcount").ToString()=="0")?"":(""+Eval("logcount").ToString()+"个文件<br/>共"+Eval("loglengthstr").ToString()+"<br><br><a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_Log_List.aspx?keyword="+Server.UrlEncode(Eval("ID").ToString())+"\" target=_blank>管理</a>")%></a></td>	
			                     <td><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("isopen").ToString()=="1"?"yes":""%><%# Eval("isopen").ToString()=="0"?"no":""%><%# int.Parse(Eval("isopen").ToString())>1?"alert":""%>.gif" /><br />isopen:<%# Eval("isopen").ToString()%></td>	
                                 <td<%# this.P_OrderBy.ToLower()=="author"?" class=orderby":""%>><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_List.aspx?page=1&keyword=<%# Server.UrlEncode( Eval("author").ToString())%>"><%# Eval("author")%></a></td>
			                     <td><%# Eval("WebManager_RealName")%></td>	
                                 <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_My_Delete.aspx?JobName="+Com.Common.EncDec.Encrypt(Eval("path").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("path").ToString()+"')\">删除认领</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_My_Add.aspx?JobName="+Com.Common.EncDec.Encrypt(Eval("path").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("path").ToString()+"')\">认领</a>"%>
                                    <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Edit.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>"  onclick="javascript:return confirm_me('编辑？')">编辑</a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Update.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>&isopen=<%# Eval("isopen").ToString()=="1"?"0":"1"%>"  onclick="javascript:return confirm_me('<%# Eval("isopen").ToString()=="1"?"停用":"开启"%>？')"><%# Eval("isopen").ToString()=="1"?"停用":"开启"%></a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Delete.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>"  onclick="javascript:return confirm_me('删除？')">删除</a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Kill.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>"  onclick="javascript:return confirm_me('杀死？')"><%# Eval("path").ToString().ToLower().EndsWith(".exe")==true?"杀死":""%></a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_TestDb.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="正式"?"0":"1"%>"  onclick="javascript:return confirm_me('测试数据库连通性？')"><%# Eval("path").ToString().ToLower().EndsWith(".exe")==true?"测库":""%></a>
                                 </td>		                        
				            </tr>      
                              <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# (Container.ItemIndex+1)+(P_page-1)*20%>" style="<%# Container.ItemIndex==0?"":"display:none;"%>background-color:lightblue;">
                                 <td colspan="14" style="border:1px solid #cccccc">
                                     <p>
                                         <%# Eval("Log").ToString().Replace("\r\n","<br>")%>
                                     </p>                                     
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
