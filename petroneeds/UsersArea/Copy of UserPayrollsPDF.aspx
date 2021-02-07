<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of UserPayrollsPDF.aspx.cs" Inherits="UsersArea_UserPayrollsPDF" %>

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
        .style8
        {
            height: 20px;
        }
        .style10
        {
            width: 12px;
        }
        .style11
        {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" align="center" rules="groups">
        <tr>
            <td class="style11" colspan="3">
                <asp:Image ID="Image1" runat="server" DescriptionUrl="~/images/Portal-Head.gif" 
                    GenerateEmptyAlternateText="True" ImageAlign="Middle" 
                    ImageUrl="~/images/Portal-Head.gif" TabIndex="1" />
            </td>
        </tr>
        <tr>
            <td class="style13">
            </td>
            <td>
                &nbsp;</td>
            <td class="style34" colspan="0">
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label18" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="180px" BorderWidth="1px" Visible="False"></asp:TextBox>
                            </td>
            <td class="style22" colspan="0">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label19" runat="server" Text="User ID" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="Text_ID" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="100px" BorderWidth="1px" ReadOnly="True" 
                    Visible="False"></asp:TextBox>
                            </td>
            <td class="style8" colspan="0">
                </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label16" runat="server" Text="User Name" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
            <td class="style8" colspan="0">
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label17" runat="server" Text="User Department" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
            <td colspan="0" class="style8">
                </td>
        </tr>
        <tr>
            <td class="style29">
                </td>
            <td>
                </td>
            <td colspan="0" class="style31">
                </td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
                <asp:GridView ID="GridView1" runat="server" Width="667px" AllowPaging="True" 
                    AllowSorting="True" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="None" 
                    PageSize="15" ShowFooter="True" 
                    AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NAME" FooterText="Item Name" 
                            HeaderText="Item Name" />
                        <asp:BoundField DataField="AMT" FooterText="AMT" HeaderText="AMT" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="14px" 
                        ForeColor="White" />
                    <RowStyle Font-Size="9px" ForeColor="Black" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
            
</asp:ScriptManager>
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
