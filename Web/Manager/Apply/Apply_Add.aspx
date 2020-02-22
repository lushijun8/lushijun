<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply_Add.aspx.cs" Inherits="Web.Manager.Apply.Apply_Add" %>

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
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>
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
                                    <td class="auto-style1">�������ڣ�</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" Width="58px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">�����ˣ�</td>
                                    <td>                                       
                                        <%=this.CurrentWebManagerRealName %></td>
                                </tr>
                                 <tr>
                                    <td class="auto-style1">������Ʒ��</td>
                                    <td>
                                        <asp:CheckBox ID="cbPen" runat="server" Text="��" />
                                        <asp:CheckBox ID="cbPenLead" runat="server" Text="��о" />
                                        <asp:CheckBox ID="cbBook" runat="server" Text="�ʼǲ�" />
                                        <asp:CheckBox ID="cbGlue" runat="server" Text="��ˮ" />
                                        <asp:CheckBox ID="cbNotePaper" runat="server" Text="��ǩֽ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="ȷ���ύ" OnClick="btnSubmit_Click" />
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td>
                                        <font color="red"> * ��Ҫ�����ͬ�£�������³�10��ǰ�ύ���롣</font><br /> 
                                    </td>
                                </tr>
                                </table>
                     </td> 
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
