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
                            <!--��ʼ--> 
                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style1">ѡ���ҵĹ��������ˣ�</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Work_To_Webmanager_Name" runat="server">
                                        </asp:DropDownList><br />������ɺ�����TeamTool��������������ݽ���ת�ƻ��߸��Ƶ����������¡�
                                    </td>
                                    <td rowspan="3">
                                        <b>����������֪��</b><br />
                                         1���������г���Ľ����������֤����Դ�붼�Ѿ�Ǩ�뵽Դ������������������ʱ����ĳ���<br /> 
                                         2����֤���еĳ�����û��д���Լ������䣬�ر��Ǳ����͵����䡣<br /> 
                                         3����֤�Լ������windows��ʱ�����Ѿ��ϲ�����׼�ķ������У������콨����ķ�ʽ������Ҫ���ֵ����������Լ��ľ������������������û�������ȥ <a href="<%=Business.Config.HostUrl %>/Manager/Job/Job_List.aspx">��������</a> ��<br /> 
                                         4����֤���ڽ��еĹ����Ѿ�������ߡ�<br /> 
                                         5������� <a target="_blank" href="http://pms.light.fang.com/index.php">��Ŀ����ϵͳ</a> �������Լ���bug�����񣬻�������ָ�������������ˡ�<br /> 
                                         6���Լ���������ݿ���ֶΣ�˵��ȫ�����룬ȥ <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_List.aspx">����</a> ����
                                        ��<a title="channelsales����" href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=0B71995F71A86343963578473D364BABED1AEBD0CBFC3DB1" target="_blank">[124.251.44.197]..[channelsales]</a>
                                        ��<a title="tuan����" href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=D8E3EF470F67B053858507D90F81F45ADA22333159ED47AD" target="_blank">[124.251.44.220]..[tuan]</a>
                                        ��
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">�������ͣ�</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbl_Transfer_Type" runat="server" RepeatColumns="1" Enabled="False">
                                            <asp:ListItem Value="0">���ƣ����Ӻ��ҵĹ�������������</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">ת�ƣ����Ӻ��ҵĹ�������������</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="ȷ���ύ" OnClick="btnSubmit_Click"/>
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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/> 
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>����ʱ��</th>
			            <th>������</th>
			            <th>��������</th>
			            <th>������</th>
			            <th>����״̬</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# Eval("id")%></td>
			                     <td><%# Eval("CreateTime")%></td>
                                 <td><%# Eval("Work_From_WebManager_realname")%></td> 
			                     <td><%# Eval("Transfer_Type").ToString()=="0"?"����":"ת��"%></td>
			                     <td><%# Eval("Work_To_WebManager_realname")%></td>
			                     <td><%# Eval("Status").ToString()=="0"?"�½�":""%><%# Eval("Status").ToString()=="1"?"�ѽ��գ���ִ��":""%><%# Eval("Status").ToString()=="2"?"ִ�����":""%></td>
			                     <td><%# (Eval("Status").ToString()=="0"&&(Eval("Work_From_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower()||Eval("Work_To_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower()))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("-1",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('ȷ��ɾ����')"+"\""+">ɾ��</a>":""%>
                                     <%# (Eval("Status").ToString()=="0"&&Eval("Work_To_Webmanager_Name").ToString().ToLower()==this.CurrentWebManagerName.ToLower())?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("1",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('ȷ�����գ�')"+"\""+">����</a>":""%>
                                     <%# (Eval("Status").ToString()=="1"&&this.CurrentIsAdmin==true)?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/Work/Work_Transfer_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"&Status="+ Com.Common.EncDec.Encrypt("2",this.Encrypt_key)+"\""+" target=_blank onclick="+"\""+"javascript:return window.confirm('ȷ��ִ�У�')"+"\""+">ִ��</a>":""%>

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
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>�ύ��,��ȴ�....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if (window.confirm("ȷ���ύ��") == true) {
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
