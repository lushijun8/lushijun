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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="30%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" /> <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Add.aspx" class="button" > <img id="plus" src="<%=Business.Config.HostUrl %>/images/plus.gif" style="border:none;vertical-align:middle;" height="22" />���windows��ҵ</a>
                &nbsp;&nbsp;&nbsp;
                <a <%=this.P_Type.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">ȫ��</a>
                <a <%=this.P_Type.ToString()=="0"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=0&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">��ʽ����</a>
                <a <%=this.P_Type.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=1&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">���Ի���</a>   
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_IsOpen.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">ȫ��</a>
                <a <%=this.P_IsOpen.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=1&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">������</a>
                <a <%=this.P_IsOpen.ToString()=="0"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=0&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=<%=Server.UrlEncode(this.P_path)%>">�رյ�</a>   
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_runType.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=&path=<%=Server.UrlEncode(this.P_path)%>">ȫ��</a>
                <a <%=this.P_runType.ToString()=="1"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=1&path=<%=Server.UrlEncode(this.P_path)%>">���ʱ��ִ�е�</a>  
                <a <%=this.P_runType.ToString()=="2"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=2&path=<%=Server.UrlEncode(this.P_path)%>">ÿ��ִ��һ�ε�</a> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_path.ToString()==""?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=">ȫ��</a>
                <a <%=this.P_path.ToString()==".exe"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=.exe">EXE</a>  
                <a <%=this.P_path.ToString()=="http"?"class=button":"class=button_off"%> href="Job_List.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&isopen=<%=Server.UrlEncode(this.P_IsOpen)%>&type=<%=Server.UrlEncode(this.P_Type)%>&runtype=<%=Server.UrlEncode(this.P_runType)%>&path=http">HTTP</a> 

                 <br /> ��ʽ����Windows��ʱ��ҵ����Ӧ ftp://xujianshi:11E011Eq$J@124.251.50.114:33321  ��Ŀ¼E:\soufun\
                <br /> ���Ի���Windows��ʱ��ҵ����Ӧ ftp://xujianshi:xujianshi@10.2.136.156  ��Ŀ¼E:\SouFunWeb\   ; Զ������ 1q2w#E$R
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>���</th>
			            <th>����</th>
			            <th><a href="Job_List.aspx?orderby=NAME&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>ID����</th>
			            <th width="75">����</th>
			            <th>����</th>
			            <th><a href="Job_List.aspx?orderby=PATH&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>Ŀ¼</th>
			            <th><a href="Job_List.aspx?orderby=RUNMINITEOF&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>ִ��ʱ��</th>
			            <th width="125"><a href="Job_List.aspx?orderby=LASTRUNTIME&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>�ϴ�ִ��ʱ��</th>
			            <th>ִ��</th>
			            <th width="65"><a href="Job_List.aspx?orderby=LOGLENGTH&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>��־</th>
			            <th><a href="Job_List.aspx?orderby=ISOPEN&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>����״̬</th>
			            <th><a href="Job_List.aspx?orderby=AUTHOR&keyword=<%= Server.UrlEncode( this.txtKeyword.Text)%>" class="orderby">��</a>������</th>
			            <th>������</th>
			            <th>����</th>
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
                                     <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Config.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>" target="_blank"><%# Eval("path").ToString().ToLower().StartsWith("http")?"":"App.Config"%></a><br />
                                     <a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_CfgFiles.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>" target="_blank"><%# (Eval("path").ToString().ToLower().StartsWith("http") || string.IsNullOrEmpty(Eval("cfgfiles").ToString()))?"":"dbcfg.conf"%></a>                                    
			                     </td>
                                 <td>
                                      <%# Eval("taskdetail").ToString()!=""?"<span class=\"why_tooltip tooltip\" titles=\""+Eval("taskdetail").ToString().Replace("\"","'")+"\"></span>":""%>   
			                     </td>
			                     <td<%# this.P_OrderBy.ToLower()=="path"?" class=orderby":""%>><%# Eval("path")%></td>
			                     <td<%# this.P_OrderBy.ToLower().IndexOf("runminiteof")>-1?" class=orderby":""%>><%# Eval("runtypename")%></td>
			                     <td<%# this.P_OrderBy.ToLower()=="lastruntime"?" class=orderby":""%>><%# Eval("lastruntime")%> <br />~  <br /><%# Eval("lastruntimeend")%></td>
                                 <td><%# Eval("whatwrong")%><br /><%# Eval("isrunning").ToString()=="1"?"ִ����...":""%><br /><%# Eval("Remark")%><br /><%# Eval("testDb").ToString()=="1"?"testdb..":""%><br /><a href="javascript:void(0);" title="<%# Eval("testDb_Remark")%>"><%# !string.IsNullOrEmpty(Eval("testDb_Remark").ToString())?"���ݿ���ͨ��":""%></a></td>		
                                 <td<%# this.P_OrderBy.ToLower()=="loglength"?" class=orderby":""%>><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_LogTxt.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>" target="_blank"><%# (Eval("path").ToString().ToLower().StartsWith("http")|| Eval("logcount").ToString()=="0")?"":(""+Eval("logcount").ToString()+"���ļ�<br/>��"+Eval("loglengthstr").ToString()+"<br><br><a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_Log_List.aspx?keyword="+Server.UrlEncode(Eval("ID").ToString())+"\" target=_blank>����</a>")%></a></td>	
			                     <td><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("isopen").ToString()=="1"?"yes":""%><%# Eval("isopen").ToString()=="0"?"no":""%><%# int.Parse(Eval("isopen").ToString())>1?"alert":""%>.gif" /><br />isopen:<%# Eval("isopen").ToString()%></td>	
                                 <td<%# this.P_OrderBy.ToLower()=="author"?" class=orderby":""%>><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_List.aspx?page=1&keyword=<%# Server.UrlEncode( Eval("author").ToString())%>"><%# Eval("author")%></a></td>
			                     <td><%# Eval("WebManager_RealName")%></td>	
                                 <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_My_Delete.aspx?JobName="+Com.Common.EncDec.Encrypt(Eval("path").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("path").ToString()+"')\">ɾ������</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Job/Job_My_Add.aspx?JobName="+Com.Common.EncDec.Encrypt(Eval("path").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("path").ToString()+"')\">����</a>"%>
                                    <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Edit.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>"  onclick="javascript:return confirm_me('�༭��')">�༭</a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Update.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>&isopen=<%# Eval("isopen").ToString()=="1"?"0":"1"%>"  onclick="javascript:return confirm_me('<%# Eval("isopen").ToString()=="1"?"ͣ��":"����"%>��')"><%# Eval("isopen").ToString()=="1"?"ͣ��":"����"%></a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Delete.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>"  onclick="javascript:return confirm_me('ɾ����')">ɾ��</a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_Kill.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>"  onclick="javascript:return confirm_me('ɱ����')"><%# Eval("path").ToString().ToLower().EndsWith(".exe")==true?"ɱ��":""%></a>
                                     <br /><a href="<%=Business.Config.HostUrl%>/Manager/Job/Job_TestDb.aspx?id=<%# Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)%>&type=<%# Eval("database_name").ToString()=="��ʽ"?"0":"1"%>"  onclick="javascript:return confirm_me('�������ݿ���ͨ�ԣ�')"><%# Eval("path").ToString().ToLower().EndsWith(".exe")==true?"���":""%></a>
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
			<!--����-->
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
