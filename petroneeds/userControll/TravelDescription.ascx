<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TravelDescription.ascx.cs" Inherits="userControll_TravelDescription" EnableViewState="false"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">

        .style7
        {
            width: 600px;
        }
        .style26
        {
        height: 25px;
    }
        td {
	font-family: Verdana;
	font-size: 14px;
            text-align: left;
            margin-bottom: 15px;
        }
        .style50
        {
            height: 25px;
        }
        .style23
        {
            width: 12px;
            height: 25px;
        }
        .style55
        {
            width: 107px;
            height: 25px;
        }
        .style27
        {
        width: 39px;
        height: 21px;
    }
        .style56
        {
            height: 21px;
            width: 107px;
        }
        .style22
        {
            height: 21px;
        }
        .style24
        {
            height: 21px;
        }
        </style>
                    <table class="style7">
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style55">
                                <asp:Label ID="Label27" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Number" Visible="False"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_NumDeta" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="66px" 
                                    Visible="False"></asp:TextBox>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="13px" 
                                    ForeColor="Maroon" Text="From"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label19" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="City"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_from_Loca" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="Text_from_Loca" ErrorMessage="*" ForeColor="#CC0000" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                <asp:Label ID="Label21" runat="server" Text="To" Font-Size="13px" 
                    ForeColor="Maroon" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label18" runat="server" Text="City" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_To_Loca" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="150px" BorderWidth="1px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="Text_To_Loca" ErrorMessage="*" ForeColor="#CC0000" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style55">
                                <asp:Label ID="Label20" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Date"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_from_Date" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="Text_from_Date_CalendarExtender" runat="server" 
                                    Format="dd-MMMM-yyyy" TargetControlID="Text_from_Date">
                                     </asp:CalendarExtender>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style27">
                                &nbsp;</td>
                            <td class="style56">
                                <asp:Label ID="Label23" runat="server" Text="Airlines Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style22">
                                <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="#6C6459" 
                    Height="28px" Width="175px">
                                    <asp:ListItem Selected="True" Text="<<<Select>>>" Value="0">&lt;&lt;&lt;Select&gt;&gt;&gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style24">
                                <asp:Label ID="Label24" runat="server" Text="Class" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Class" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="150px" BorderWidth="1px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style27">
                                &nbsp;</td>
                            <td class="style56">
                                <asp:Label ID="Label25" runat="server" Text="Remarks" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24" colspan="3">
                                <asp:TextBox ID="Text_Remarks" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="375px" BorderWidth="1px" Height="75px" 
                                TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                
