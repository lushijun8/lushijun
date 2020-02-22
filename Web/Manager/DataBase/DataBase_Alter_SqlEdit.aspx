<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Alter_SqlEdit.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Alter_SqlEdit" %>

<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html>

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
        .button {
            height: 21px;
        }
    </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="5" cellspacing="5" width="100%">
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
                                         <asp:TextBox ID="txt_Alter_Sql" runat="server" TextMode="MultiLine" Width="100%" Height="450px"></asp:TextBox>
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
            </div>   
  
    </form>
</body>
</html>
