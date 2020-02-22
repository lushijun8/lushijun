<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Owner_Edit.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Owner_Edit" %>


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
        .button {
            height: 21px;
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
                            <table width="100%" border="0">
                                <tr>
                                    <td class="auto-style1">���ݿ����ƣ�</td>
                                    <td>

                                        <asp:TextBox ID="txt_DataBase_Name" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">��ע��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Remark" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">����ʵIP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Local" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">����ʵIP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Romote" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">����VIP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_VIP_Local" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">����VIP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_VIP_Romote" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">���ݻ�ר��IP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Special" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">����IP��</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Recovery" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">admin�û�����</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Admin_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">admin�û����룺</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Admin_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">ֻ���û�����</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Reader_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">ֻ���û����룺</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Reader_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">��д�û�����</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Writer_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">��д�û����룺</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Writer_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="ȷ���޸�" OnClick="btnSubmit_Click" />
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
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>�ύ��,��ȴ�....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                $("#Loading").show();
            });
        })
    </script>
</body>
</html>
