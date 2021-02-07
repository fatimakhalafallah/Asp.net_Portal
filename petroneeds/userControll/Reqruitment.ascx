<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Reqruitment.ascx.cs" Inherits="userControll_Reqruitment"  EnableViewState="false"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
    .style30
        {
            width: 540px;
        }
        td {
	font-family: Verdana;
	font-size: 14px;
            text-align: left;
            margin-bottom: 15px;
        }
        .style115
    {
        height: 25px;
        width: 204px;
    }
    .style116
    {
        width: 6px;
        height: 25px;
    }
    .style118
    {
        height: 50px;
        width: 204px;
    }
    .style119
    {
        width: 6px;
        height: 50px;
    }
    .style121
    {
        width: 197px;
        height: 25px;
    }
    .style122
    {
        width: 197px;
        height: 50px;
    }
        
        </style>
                        <table cellpadding="0" cellspacing="0" class="style30">
                            <tr>
                                <td class="style121">
                                    <asp:Label ID="Label25" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                        Text="Candidates"></asp:Label>
                                </td>
                                <td class="style115">
                                    <asp:Label ID="Label30" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                        Text="No" Visible="False"></asp:Label>
                                </td>
                                <td class="style116">
                                    &nbsp;</td>
                                <td class="style115">
                                    <asp:TextBox ID="Text_Num2" runat="server" BorderColor="#B00000" 
                                        BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="37px" 
                                        Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style121">
                                    <asp:Label ID="Label31" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Experience"></asp:Label>
                                </td>
                                <td class="style115">
                                    <asp:TextBox ID="Text_Experience" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="79px" BorderWidth="1px" 
                                    MaxLength="20" Rows="1">0</asp:TextBox>
                                </td>
                                <td class="style116">
                                    &nbsp;</td>
                                <td class="style115">
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ControlToValidate="Text_Experience" ErrorMessage="Insert No" 
                                        Font-Overline="False" Font-Size="10px" ForeColor="Maroon" 
                                        MaximumValue="2147483647" MinimumValue="0" SetFocusOnError="True" 
                                        Type="Integer">Insert No</asp:RangeValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="Text_Experience" ErrorMessage="*" Font-Size="10px" 
                                        ForeColor="Maroon" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style121">
                                    <asp:Label ID="Label28" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Candidate"></asp:Label>
                                </td>
                                <td class="style115">
                                    <asp:TextBox ID="Text_Candidate" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Height="21px" MaxLength="50" 
                                        Width="167px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="Text_Candidate" ErrorMessage="*" ForeColor="#CC0000" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style116">
                                    &nbsp;</td>
                                <td class="style115">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style122">
                                    <asp:Label ID="Label32" runat="server" Text="Credits" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                                </td>
                                <td class="style118">
                                    <asp:TextBox ID="Text_Description" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="230px" BorderWidth="1px" Height="83px" TextMode="MultiLine" 
                                    MaxLength="5" Rows="2" Columns="1"></asp:TextBox>
                                </td>
                                <td class="style119">
                                </td>
                                <td class="style118">
                                    <asp:Label ID="Label_Chractor1" runat="server" Font-Size="10px" 
                                        ForeColor="Maroon" Text="Less than 100 Chractor" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style121">
                                    <asp:Label ID="Label33" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                        Text="Remarks"></asp:Label>
                                </td>
                                <td class="style115">
                                    <asp:TextBox ID="Text_Remarks" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Height="83px" MaxLength="100" 
                                        Width="230px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td class="style116">
                                </td>
                                <td class="style115">
                                    <asp:Label ID="Label_Chractor2" runat="server" Font-Size="10px" 
                                        ForeColor="Maroon" Text="Less than 100 Chractor" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            </table>
                    
