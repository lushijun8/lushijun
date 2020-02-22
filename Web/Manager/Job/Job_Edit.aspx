<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_Edit.aspx.cs" Inherits="Web.Manager.Job.Job_Edit" %>
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
        function runTypeChange() {
            // $("#runType1").hide();
            //$("#runType2").hide();
            //$("#runType" + $("#runType").find("option:selected").val()).show();
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
			<table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td align="right" width="180">环境：</td>
                                    <td>
                                        <%=this.P_TYPE=="0"?"正式环境":"测试环境" %> 
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="180">ID：</td>
                                    <td>
                                         <asp:TextBox ID="txt_id" runat="server" Width="100%" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">name：</td>
                                    <td>
                                         <asp:TextBox ID="txt_name" runat="server" Width="100%"></asp:TextBox><br />(任务名称)
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">path：</td>
                                    <td>
                                        <asp:TextBox ID="txt_path" runat="server" Width="100%"></asp:TextBox><br />(作业服务器上的物理路径)
                                        </td>
                                </tr> 
                 <tr>
                                    <td align="right">runType：</td>
                                    <td>
                                         <asp:DropDownList ID="ddl_runType" runat="server">
                                             <asp:ListItem Value="1" Selected="True">每隔一段时间执行(分钟)</asp:ListItem>
                                             <asp:ListItem Value="2">每天定时执行一次</asp:ListItem>
                                         </asp:DropDownList>
&nbsp;</td>
                                </tr>                                
                                <tr id="runType1">
                                    <td align="right">runMiniteOf(runType=1)：</td>
                                    <td>
                                         <asp:TextBox ID="txt_runMiniteOf" runat="server" Width="37%"></asp:TextBox>时间间隔（分钟）<br />
                                        
                                    </td>
                                </tr>                                
                                <tr id="runType2">
                                    <td align="right">runTimeAt(runType=2)：</td>
                                    <td>
                                        <asp:TextBox ID="txt_runTimeAt" runat="server" Width="38%"></asp:TextBox>定时（如01:15:00）<br />
                                        </td>
                                </tr>                   
                 <tr>
                                    <td align="right">Author：</td>
                                    <td>
                                         <asp:TextBox ID="txt_Author" runat="server" Width="100%"></asp:TextBox><br />(作者)

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">LastRunTime：</td>
                                    <td>
                                         <asp:TextBox ID="txt_LastRunTime" runat="server" Width="100%" Enabled="False" ReadOnly="True"></asp:TextBox><br />(最后执行时间)
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">isOpen：</td>
                                    <td>                                        
                                         <asp:TextBox ID="txt_isOpen" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                </tr>    
                 <tr>
                                    <td align="right">TaskDetail：</td>
                                    <td>
                                         <asp:TextBox ID="txt_TaskDetail" runat="server" Width="100%"></asp:TextBox><br />(任务描述)

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">isRunning：</td>
                                    <td>
                                         <asp:TextBox ID="txt_isRunning" runat="server" Width="100%" Enabled="False" ReadOnly="True"></asp:TextBox><br />(是否在执行)
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">SvnSourceCode：</td>
                                    <td>
                                        <asp:TextBox ID="txt_SvnSourceCode" runat="server" Width="100%"></asp:TextBox><br />(源码位置)
                                        </td>
                                </tr>   <tr>
                                    <td align="right">CreateTime：</td>
                                    <td>
                                        <asp:TextBox ID="txt_CreateTime" runat="server" Width="100%"  Enabled="False" ReadOnly="True"></asp:TextBox><br />(创建时间)
                                        </td>
                                </tr>                                   
                                <tr>
                                    <td align="right"></td>
                                    <td>
                                       <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认提交" OnClick="btnSubmit_Click"/>
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>                                
                                </table>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
 <script language="javascript">
     runTypeChange();
 </script>
