<%@ Page Title="Petroneeds International Services :: Salary Advance Form (SAF)" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Salary_Advance.aspx.cs" Inherits="UsersArea_Salary_Advance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 198px;
        }
        .style28
    {
        height: 17px;
    }
        .style29
        {
            height: 25px;
        }
        .style30
        {
            height: 24px;
        }
        .style31
        {
            height: 21px;
        }
        .style32
        {
            height: 22px;
            width: 10px;
        }
        .style33
        {
            height: 23px;
        }
        .style34
        {
            height: 20px;
        }
        .style35
        {
            height: 20px;
            width: 10px;
        }
        .style36
        {
            height: 24px;
            width: 10px;
        }
        .style37
        {
            height: 23px;
            width: 10px;
        }
        .style38
        {
            height: 25px;
            width: 10px;
        }
        .style39
        {
            height: 17px;
            width: 10px;
        }
        .style40
        {
            height: 20px;
            width: 426px;
        }
        .style41
        {
            width: 426px;
        }
        .style42
        {
            height: 24px;
            width: 426px;
        }
        .style43
        {
            height: 23px;
            width: 426px;
        }
        .style44
        {
            height: 25px;
            width: 426px;
        }
        .style45
        {
            height: 21px;
            width: 426px;
        }
        .style46
        {
            height: 17px;
            width: 426px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_10.gif" />
                </b></td>
        </tr>
        <tr>
            <td class="style40">
            </td>
            <td class="style34">
            </td>
            <td class="style35">
            </td>
        </tr>
        <tr>
            <td class="style41">
                <b style="mso-bidi-font-weight: normal">
                <span style="font-size: 12.0pt; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;; mso-ascii-theme-font: minor-latin; mso-fareast-font-family: &quot;Times New Roman&quot;; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                <asp:Label ID="Label26" runat="server" Text="Employee Request" Font-Size="13px" 
                    ForeColor="Maroon" Font-Bold="False" Font-Names="Verdana"></asp:Label>
                </span></b>
            </td>
            <td class="style9">
            </td>
            <td class="style32">
            </td>
        </tr>
        <tr>
            <td class="style42">
                <asp:Label ID="Label28" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style30">
                <asp:TextBox ID="Text_No" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="92px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style36">
                </td>
        </tr>
        <tr>
            <td class="style42">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style30">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="193px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style36">
                </td>
        </tr>
        <tr>
            <td class="style42">
                <asp:Label ID="Label2" runat="server" Text="Employee Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style30">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="320px" BorderWidth="1px" MaxLength="50" 
                    Height="20px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style36">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Name" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style42">
                <asp:Label ID="Label3" runat="server" Text="Employee ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style30">
                <asp:TextBox ID="Text_Id" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="92px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style36">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Id" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style43">
                <asp:Label ID="Label4" runat="server" Text="Position" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="250px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style37">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Position" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style44">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style29">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="250px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style38">
                </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style42">
                            <asp:Label ID="Label27" runat="server" Text="Month of Salary " Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
            <td class="style30">
                            <asp:TextBox ID="Text_MonthSalary" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="150px" BorderWidth="1px" Height="20px"></asp:TextBox>
                      <asp:CalendarExtender ID="Text_MonthSalary_CalendarExtender" runat="server" 
                                TargetControlID="Text_MonthSalary" Format="MM/yyyy">
                            </asp:CalendarExtender>
                        
                        </td>
            <td class="style36">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="Text_MonthSalary" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="style45">
                                    <asp:Label ID="Label33" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                        Text="Remarks"></asp:Label>
                                </td>
            <td class="style10">
                                    <asp:TextBox ID="Text_Remarks" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Height="83px" MaxLength="100" 
                                        Width="405px" TextMode="MultiLine"></asp:TextBox>
                                </td>
            <td class="style37">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style46">
            </td>
            <td class="style28">
                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style39">
                </td>
        </tr>
        <tr>
            <td class="style43">
                </td>
            <td class="style33">
                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Submit" onclick="Butt_Submit_Click" Width="65px" />
                <asp:Button ID="Butt_Reset" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Reset" CausesValidation="False" onclick="Butt_Reset_Click" 
                    Width="65px" />
            </td>
            <td class="style37">
                </td>
        </tr>
        <tr>
            <td class="style31" colspan="3">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
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



