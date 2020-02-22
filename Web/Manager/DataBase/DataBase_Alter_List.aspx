<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Alter_List.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Alter_List" %>


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
        .auto-style2 {
            width: 146px;
            text-align:right;
        }
        </style>
     <script language="javascript">
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
         function showhide_td() {
             if ($("#showhide_td").text() == "ִ��SQL������") {

                 $(".cell").css("overflow", "visible");
                 $(".cell").css("height", "auto");
                 $(".cell").css("white-space", "pre-wrap");
                 $("#showhide_td").text("ִ��SQL������");
             }
             else {
                 $(".cell").css("overflow", "hidden");
                 $(".cell").css("height", "20px");
                 $(".cell").css("white-space", "normal");
                 $("#showhide_td").text("ִ��SQL������");
             }
         }
     </script>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="c2">
                            <!--��ʼ--> 
                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style2">ѡ���޸ĵ����ݿ⣺</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Database_Name" runat="server">
                                        </asp:DropDownList>ÿ����ÿ��ֻ�����޸�һ�����ݿ⣬���һ�����жദ�޸ģ���ϲ���һ�ν����ύ��</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">��дִ�е�SQL��</td>
                                    <td>
                                        <asp:TextBox ID="txt_Alter_Sql" runat="server" TextMode="MultiLine" Width="100%" Height="250px"></asp:TextBox>
                                        <br />
                                        ����д�����޸����ݿ�ṹ��Ȩ�޵�SQL�����ұ�֤SQL����ڲ��Կ���ִ����ȷ�������������ʽ���ϻ�ִ�г���</br>
                                        ��ӻ����޸��ֶα������ֶ�˵����������ִ�У�ʾ����</br>
                                        <font color=green>/*����ֶ�˵��*/</font></br>
                                        <font color=blue>EXEC</font> <font color=lightgreen>sys</font>.<font color="#990033">sp_addextendedproperty</font> @name=<font color="red">N'MS_Description'</font>, @value=<font color="red">N'�������'</font> , @level0type=<font color="red">N'SCHEMA'</font>,@level0name=<font color="red">N'dbo'</font>, @level1type=<font color="red">N'TABLE'</font>,@level1name=<font color="red">N'MallPayrecorde'</font>, @level2type=<font color="red">N'COLUMN'</font>,@level2name=<font color="red">N'Orderno'</font></br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*�޸��ֶ�˵��*/</font></br>
                                        <font color=blue>EXEC</font> <font color=lightgreen>sys</font>.<font color="#990033">sp_updateextendedproperty</font> @name=<font color="red">N'MS_Description'</font>, @value=<font color="red">N'�ѷ������û�ID'</font> , @level0type=<font color="red">N'SCHEMA'</font>,@level0name=<font color="red">N'dbo'</font>, @level1type=<font color="red">N'TABLE'</font>,@level1name=<font color="red">N'MallPayrecorde'</font>, @level2type=<font color="red">N'COLUMN'</font>,@level2name=<font color="red">N'CID'</font></br>
                                        <font color=blue>GO</font></br></br>
                                        SQL SERVER ��Ȩ�޵�����GRANT���ܾ�DENY���ջ�REVOKE��ʾ����</br>
                                        <font color=green>/*���û�channelsales_oa_r��Ȩ����������ж����ݶ���MallPayrecorde�������Ǳ���ͼ���ĸ��º�ɾ���Ĳ���Ȩ��*/</font></br>
                                        <font color=blue>GRANT</font> <font color="#ff00ff">UPDATE</font>,<font color=blue>DELETE ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r <font color=blue>WITH GRANT OPTION</font> ;<font color=green>/*--WITH GRANT OPTION��ʾ���û������������û���������ӵ�е�Ȩ�ޣ������ֹʹ��*/</font></br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*���û�channelsales_oa_r��Ȩ����������ж����ݶ���MallPayrecorde�������Ǳ���ͼ����SELECT�Ĳ���Ȩ��*/</font></br>
                                        <font color=blue>GRANT SELECT ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>                                            
                                        <font color=green>/*���û�channelsales_oa_r��Ȩ����������ж����ݶ���proc_autorun���洢���̣���EXECUTE�Ĳ���Ȩ��*/</font></br>
                                        <font color=blue>GRANT EXECUTE ON</font> proc_autorun <font color=blue>TO</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*��ֹchannelsales_oa_r�û������ݶ���MallPayrecorde�������Ǳ���ͼ���ĸ���Ȩ��*/</font></br>
                                        <font color=blue>DENY</font> <font color="#ff00ff">UPDATE</font> <font color=blue>ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r <font color=blue>CASCADE</font> ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*�ջ��û�channelsales_oa_r�Զ���MallPayrecorde�������Ǳ���ͼ����ɾ��Ȩ��*/</font></br>
                                        <font color=blue>REVOKE DELETE ON</font> MallPayrecorde <font color=blue>FROM</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*�ջ��û�channelsales_oa_r�Զ���proc_autorun���洢���̣���EXECUTEȨ��*/</font></br>
                                        <font color=blue>REVOKE EXECUTE ON</font> proc_autorun <font color=blue>FROM</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">��ע��</td>
                                    <td>
                                        <asp:TextBox ID="txt_Alter_Remark" runat="server" Height="33px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        <br />
                                        ����дΪ��Ҫִ�д�SQL</td>
                                </tr>                                
                                <tr>
                                    <td class="auto-style2"></td>
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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼,���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="21%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;<br/> 
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>����ʱ��</th>
			            <th>IP</th>
			            <th>���ݿ�</th>
			            <th><a href="javascript:void(0)" onclick="javascript:showhide_td();" id="showhide_td">ִ��SQL������</a>  </th>
			            <th>����</th>
			            <th>״̬</th>
			            <th>ִ��ʱ��</th>
			            <th>�ύ��</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="25"><%# Eval("id")%></td>
			                     <td width="120"><%# Eval("CreateTime")%></td>
                                 <td width="100"><%# Eval("DATABASE_IP")%></td> 
			                     <td width="80"><%# Eval("DATABASE_NAME")%></td>
			                     <td width="50%" onclick="javascript:showhide('v_<%# Eval("id")%>');"><div class="cell"><font color="green">/**<%# Eval("ALTER_REMARK")%>**/</font><br /><font color="blue"><%# Eval("ALTER_SQL").ToString().Replace("\r\n","<br>")%></font></div></td>
			                     <td onclick="javascript:showhide('v_<%# Eval("id")%>');"><div class="cell"><font color="red"><%# Eval("ALTER_PROBLEM")%></font></div></td>
			                     <td width="40"><%# Eval("ALTER_STATUS").ToString()=="0"?"�½�":""%><%# Eval("ALTER_STATUS").ToString()=="1"?"��ִ��":""%></td>
			                     <td width="120"><%# Eval("ALTER_TIME")%></td>
			                     <td width="40"><%# Eval("WebManager_realname")%></td>
			                     <td><%# (Eval("ALTER_STATUS").ToString()=="0"&&(Eval("WebManager_name").ToString().ToLower()==this.CurrentWebManagerName.ToLower() || this.CurrentIsAdmin==true))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_Delete.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('ȷ��ɾ����')"+"\""+">ɾ��</a><br>":""%>
                                     <%# (Eval("ALTER_STATUS").ToString()=="0"&&this.CurrentIsAdmin==true)?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('ȷ��ִ�У�')"+"\""+">ִ��</a><br>":""%>
                                     <%# Eval("ALTER_STATUS").ToString()=="1"?"��ִ��":""%>
                                    <%-- <%if (this.CurrentIsAdmin == true) { %>
                                     <a href="DataBase_Alter_SqlEdit.aspx?Id=<%# Com.Common.EncDec.Encrypt( Eval("id").ToString(),this.Encrypt_key)%>"> <%# Eval("ALTER_STATUS").ToString()=="0"?"�޸�SQL":""%></a>
                                     <%} %>--%>
                                     <%# (Eval("ALTER_STATUS").ToString()=="0"&&(Eval("WebManager_name").ToString().ToLower()==this.CurrentWebManagerName.ToLower() || this.CurrentIsAdmin==true))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_SqlEdit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('ȷ���޸ģ�')"+"\""+">�޸�</a><br>":""%>
			                     </td>
				            </tr>  
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("id")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="10" style="border:1px solid #cccccc">
                                     <p><font color="green">/**<%# Eval("ALTER_REMARK")%>**/</font><br /><font color="blue"><%# Eval("ALTER_SQL").ToString().Replace("\r\n","<br>")%></font></p>
                                     <p><font color="red"><%# Eval("ALTER_PROBLEM")%></font></p>
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
