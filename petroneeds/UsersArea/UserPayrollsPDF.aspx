<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPayrollsPDF.aspx.cs" Inherits="UsersArea_UserPayrollsPDF" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        td {
	font-family: Verdana;
	font-size: 14px;
            text-align: left;
            margin-bottom: 15px;
        }
a:link {
	color: #FFFFFF;
	text-decoration: none;
}
a {
	font-family: Verdana;
	font-size: 13px;
}
        .style10
        {
            width: 12px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" align="center" rules="groups">
        <tr>
            <td class="style10" colspan="3">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
            
</asp:ScriptManager>
                <asp:TextBox ID="Text_Name" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="Text_Department" runat="server" Visible="False"></asp:TextBox>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="" Width="660px">
                </rsweb:ReportViewer>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    onclick="Button1_Click" Text="Export" Visible="False" />
            </td>
            <td>
                </td>
            <td class="style22" colspan="0">
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
