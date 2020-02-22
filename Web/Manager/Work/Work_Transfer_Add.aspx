<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_Transfer_Add.aspx.cs" Inherits="Web.Manager.Work.Work_Transfer_Add" %>

<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=this.CurrentWebTitle%></title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="l2">&nbsp;</td>
                    <td class="c2">
                            <!--开始--> 
                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style1">选择我的工作接收人：</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Work_To_Webmanager_Name" runat="server">
                                        </asp:DropDownList><br />交接完成后你在TeamTool中所有认领的内容将会转移或者复制到接收人名下。
                                    </td>
                                    <td rowspan="3">
                                        <b>工作交接须知：</b><br />
                                         1、请检查所有程序的解决方案、保证所有源码都已经迁入到源码管理服务器，包括定时任务的程序。<br /> 
                                         2、保证所有的程序里没有写死自己的邮箱，特别是报错发送的邮箱。<br /> 
                                         3、保证自己负责的windows定时任务已经合并到标准的服务器中（按照徐建世组的方式），不要出现单独部署在自己的局域网服务器的情况，没认领的请去 <a href="<%=Business.Config.HostUrl %>/Manager/Job/Job_List.aspx">这里认领</a> 。<br /> 
                                         4、保证正在进行的工作已经完成上线。<br /> 
                                         5、解决完 <a target="_blank" href="http://pms.light.fang.com/index.php">项目管理系统</a> 上所有自己的bug和任务，或者重新指定到工作交接人。<br /> 
                                         6、自己负责的数据库表、字段，说明全部补齐，去 <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_List.aspx">这里</a> 补齐
                                        ，<a title="channelsales主库" href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=0B71995F71A86343963578473D364BABED1AEBD0CBFC3DB1" target="_blank">[124.251.44.197]..[channelsales]</a>
                                        ，<a title="tuan主库" href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=D8E3EF470F67B053858507D90F81F45ADA22333159ED47AD" target="_blank">[124.251.44.220]..[tuan]</a>
                                        。
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">交接类型：</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbl_Transfer_Type" runat="server" RepeatColumns="1" Enabled="False">
                                            <asp:ListItem Value="0">复制（交接后我的工作，还保留）</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">转移（交接后我的工作，不保留）</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认提交" OnClick="btnSubmit_Click"/>
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>                                
                                </table>
  
                     </td> 
                </tr>
            </table>
               <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">			
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/> 
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>创建时间</th>
			            <th>交接人</th>
			            <th>交接类型</th>
			            <th>接收人</th>
			            <th>交接状态</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# Eval("id")%></td>
			                     <td><%# Eval("CreateTime")%></td>
                                 <td><%# Eval("Work_From_WebManager_realname")%></td> 
			                     <td><%# Eval("Transfer_Type").ToString()=="0"?"复制":"转移"%></td>
			                     <td><%# Eval("Work_To_WebManager_realname")%></td>
			                     <td><%# Eval("Status").ToString()=="0"?"新建":""%><%# Eval("Status").ToString()=="1"?"已接收，待执行":""%><%# Eval("Status").ToString()=="2"?"执行完成":""%></td>
			                     <td><%# (Eval("Status").ToString()=="0"&&(Eval("Work_From_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower()||Eval("Work_To_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower()))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("-1",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('确定删除？')"+"\""+">删除</a>":""%>
                                     <%# (Eval("Status").ToString()=="0"&&Eval("Work_To_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower())?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("1",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('确定接收？')"+"\""+">接收</a>":""%>
                                     <%# (Eval("Status").ToString()=="1"&&this.CurrentIsAdmin==true)?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("2",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('确定执行？')"+"\""+">执行</a>":""%>

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
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>提交中,请等待....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if (window.confirm("确定提交吗？") == true) {
                    $("#Loading").show();
                    return true;
                }
                else {
                    return false;
                }
            });
        })
    </script>
</body>
</html>
