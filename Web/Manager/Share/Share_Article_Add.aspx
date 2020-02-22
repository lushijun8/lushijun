<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share_Article_Add.aspx.cs" Inherits="Web.Manager.Share.Share_Article_Add" ValidateRequest="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
                                    <td>������⣺</td>
                                    <td>

                                        <asp:TextBox ID="txt_Article_Title" runat="server" MaxLength="50" Width="532px"></asp:TextBox>
                                        <asp:CheckBox ID="cb_SendEmail" runat="server" Checked="True" Text="Ⱥ���ʼ�" />
                                         
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="ȷ�Ϸ���" OnClick="btnSubmit_Click" />
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                         ����������Ϊ�ʼ����ⷢ��
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <FCKeditorV2:FCKeditor ID="frtb_Article_text" runat="server" Height="600px"></FCKeditorV2:FCKeditor>
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
                if (window.confirm('ϵͳ���Զ�������������Ⱥ���ʼ������Ǵ��Ŷӵ�������Ŷ��ȷ�������𣿿�ȷ���ɣ���Һ��ڴ���~') == true) {
                    $("#Loading").show();
                }
                else {
                    return false;
                }
            });
        })
    </script>
</body>
</html>