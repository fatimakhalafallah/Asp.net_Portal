<%@ Page Title="Salary Details" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="UserPayrolls.aspx.cs" Inherits="UsersArea_UserPayrolls" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
        width: 90%;
            margin-right: 0px;
        }
        .style10
        {
        }
        .style13
        {
            width: 118px;
        }
        .style16
        {
            height: 25px;
        }
        .style17
        {
            height: 25px;
        }
        .style22
        {
            width: 160px;
            height: 25px;
        }
        .style29
        {
            width: 118px;
            height: 17px;
        }
        .style30
        {
            height: 17px;
        }
        .style31
        {
            width: 160px;
            height: 17px;
        }
    .style34
    {
        width: 160px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td class="style16" colspan="2">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_14.gif" />
                </b>
            </td>
            <td class="style22" colspan="0">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
            </td>
            <td>
                </td>
            <td class="style34" colspan="0">
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label18" runat="server" Text="Select Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="180px" BorderWidth="1px"></asp:TextBox>
                            <asp:CalendarExtender ID="Text_Date_CalendarExtender" runat="server" 
                                TargetControlID="Text_Date" Format="MM/yyyy">
                            </asp:CalendarExtender></td>
            <td class="style22" colspan="0">
                <asp:Button ID="Butt_Search" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Find" onclick="Butt_Butt_Search" Width="50px" />
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label19" runat="server" Text="User ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="Text_ID" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="100px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            <asp:CalendarExtender ID="Text_ID_CalendarExtender" runat="server" 
                                TargetControlID="Text_ID" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender></td>
            <td class="style22" colspan="0">
                </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label16" runat="server" Text="User Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style22" colspan="0">
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label17" runat="server" Text="User Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style17">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="0" class="style22">
                </td>
        </tr>
        <tr>
            <td class="style29">
                </td>
            <td class="style30">
                </td>
            <td colspan="0" class="style31">
                </td>
        </tr>
        <tr>
            <td class="style10" colspan="3">
                <asp:GridView ID="GridView1" runat="server" Width="600px" AllowPaging="True" 
                    AllowSorting="True" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="None" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onselectedindexchanging="GridView1_SelectedIndexChanging" 
                    onsorting="GridView1_Sorting" PageSize="100" ShowFooter="True" 
                    AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated">
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
            <td class="style13">
                <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    onclick="Button1_Click" Text="Export" />
            </td>
            <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td class="style22" colspan="0">
            </td>
        </tr>
        </table>
</asp:Content>


<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">
         <div class="MenuBar">
        <asp:Menu ID="menuBar" runat="server" BackColor="#B00000" BorderColor="White" 
            ForeColor="White" Height="25px" 
            Orientation="Horizontal" RenderingMode="Table" 
            StaticEnableDefaultPopOutImage="False" style="text-align: center" Width="" 
                                                
            DynamicEnableDefaultPopOutImage="False" DynamicVerticalOffset="2" 
            ItemWrap="True">
            <DynamicHoverStyle CssClass="DynamicHover" Font-Bold="False" BackColor="White" 
                Font-Italic="True" Font-Names="Tahoma" Font-Size="13px" ForeColor="#B00000" />
            <DynamicMenuItemStyle BackColor="#B00000" BorderColor="White" 
                CssClass="DynamicMenuItem" ForeColor="White" Height="25px" 
                HorizontalPadding="0px" ItemSpacing="0px" VerticalPadding="0px" Width="" 
                Font-Italic="True" Font-Names="Tahoma" Font-Size="13px" />
            <DynamicMenuStyle BorderColor="White" 
                HorizontalPadding="0px" VerticalPadding="0px" />
            <DynamicSelectedStyle CssClass="DynamicHover" />
            <StaticHoverStyle CssClass="staticHover" ForeColor="White" Height="25px" 
                Width="" />
            <StaticMenuItemStyle BackColor="#B00000" BorderColor="#FFFFFF" 
                CssClass="StaticMenuItem" Height="25px" HorizontalPadding="1px" 
                ItemSpacing="0px" VerticalPadding="0px" Width="120px" Font-Bold="False" 
                Font-Italic="True" Font-Names="Tahoma" Font-Size="13px" ForeColor="White" />
            <StaticMenuStyle BackColor="#B00000" BorderColor="White" Height="25px" 
                Width="" />
            <StaticSelectedStyle BackColor="#B00000" BorderColor="White" 
                CssClass="staticHover" Font-Names="Tahoma" Font-Size="13px" Height="25px" 
                HorizontalPadding="0px" ItemSpacing="0px" VerticalPadding="0px" Width="" 
                Font-Italic="True" />
        </asp:Menu>
    </div>
</asp:Content>





