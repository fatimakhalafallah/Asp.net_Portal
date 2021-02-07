<%@ Page Title="Recruitment Request Form" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Recruitment.aspx.cs" Inherits="UsersArea_Recruitment" %>
<%@ Register src="../userControll/Reqruitment.ascx" tagname="Reqruitment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style61
        {
            width: 315px;
        }
        .style63
    {
        width: 100px;
    }
        .style68
        {
            height: 20px;
            }
        .style72
        {
            height: 17px;
        }
        .style76
        {
            height: 25px;
        }
        .style88
        {
            width: 138px;
        }
        .style91
        {
            width: 260px;
            height: 25px;
        }
        .style93
        {
            height: 20px;
            width: 44px;
        }
        .style100
        {
            width: 127px;
            height: 17px;
        }
        .style101
        {
            width: 127px;
        }
        .style103
        {
            height: 17px;
        }
        .style120
        {
        }
        .style121
        {
            height: 25px;
            width: 10px;
        }
        .style122
        {
            width: 10px;
        }
        .style123
        {
            width: 99%;
        }
        .style124
        {
            width: 260px;
            height: 50px;
        }
        .style125
        {
            height: 20px;
            width: 392px;
        }
        .style126
        {
            width: 260px;
            height: 32px;
        }
        .style127
        {
            height: 32px;
        }
        .style128
        {
            width: 10px;
            height: 32px;
        }
        .style129
        {
            width: 260px;
            height: 24px;
        }
        .style130
        {
            height: 24px;
        }
        .style131
        {
            width: 10px;
            height: 24px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7" 
        style="height: 160px; width: 612px">
    <tr>
        <td colspan="2">
            <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_11.gif" />
            </b></td>
    </tr>
    <tr>
        <td class="style125">
            <asp:Label ID="Label16" runat="server" Text="General Information" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
        </td>
        <td class="style93">
        </td>
    </tr>
    <tr>
        <td class="style68" colspan="2">
                    <table cellpadding="0" cellspacing="0" class="style6" __designer:mapid="182" 
                        width="600px">
                        <tr __designer:mapid="183">
                            <td class="style91" __designer:mapid="188">
            <asp:Label ID="Label27" runat="server" Text="Recruitment  Type" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style76" __designer:mapid="189">
            <asp:DropDownList ID="DropDownList2" runat="server" ForeColor="#6C6459" 
                    Height="25px" AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Selected="True" Text="<<<Select>>>" Value="0">&lt;&lt;&lt;Select&gt;&gt;&gt;</asp:ListItem>
                <asp:ListItem Value="1">Permanent</asp:ListItem>
                <asp:ListItem Value="2">Temporary</asp:ListItem>
            </asp:DropDownList>
                            </td>
                            <td class="style121" __designer:mapid="18a">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="#CC0000" 
                    InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr __designer:mapid="18b">
                            <td class="style91" __designer:mapid="190">
            <asp:Label ID="Label26" runat="server" Text="No" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style76" __designer:mapid="191">
            <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="80px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style121" __designer:mapid="192">
                                </td>
                        </tr>
                        <tr __designer:mapid="193">
                            <td class="style91" __designer:mapid="198">
            <asp:Label ID="Label17" runat="server" Text="Data" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style76" __designer:mapid="199">
            <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True" 
                    EnableTheming="True"></asp:TextBox>
                            </td>
                            <td class="style121" __designer:mapid="19a">
                                </td>
                        </tr>
                        <tr __designer:mapid="19b">
                            <td class="style91" __designer:mapid="1a0">
            <asp:Label ID="Label18" runat="server" Text="Position to be Filled" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style76" __designer:mapid="1a2">
            <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="262px" BorderWidth="1px"></asp:TextBox>
                            </td>
                            <td class="style121" __designer:mapid="1a3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Position" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr __designer:mapid="1aa">
                            <td class="style91" __designer:mapid="1ad">
            <asp:Label ID="Label19" runat="server" 
                    Text="Availability on Organization Chart" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style76" __designer:mapid="1ae">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="16px" 
                    RepeatDirection="Horizontal" Width="261px">
                <asp:ListItem Value="0">Vacant</asp:ListItem>
                <asp:ListItem Value="1">Not Available</asp:ListItem>
            </asp:RadioButtonList>
                            </td>
                            <td class="style121" __designer:mapid="1af">
                                </td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style126" __designer:mapid="1b4">
            <asp:Label ID="Label21" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td __designer:mapid="1b5" class="style127">
            <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="#6C6459" 
                    Height="28px">
                <asp:ListItem Selected="True" Text="<<<Select>>>" Value="0">&lt;&lt;&lt;Select&gt;&gt;&gt;</asp:ListItem>
            </asp:DropDownList>
                            </td>
                            <td class="style128" __designer:mapid="1b6">
                                </td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style129" __designer:mapid="1b4">
            <asp:Label ID="Label29" runat="server" Text="Period" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td __designer:mapid="1b5" class="style130">
            <asp:TextBox ID="Text_period" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" 
                    EnableTheming="True"></asp:TextBox>
                            &nbsp;<asp:Label ID="Label30" runat="server" Text="Month/s" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style131" __designer:mapid="1b6">
                                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                    ControlToValidate="Text_period" ErrorMessage="Insert No" Font-Overline="False" 
                                    Font-Size="10px" ForeColor="Maroon" MaximumValue="2147483647" 
                                    MinimumValue="0" SetFocusOnError="True" Type="Double">Insert Number</asp:RangeValidator>
                                </td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style124" __designer:mapid="1b4">
            <asp:Label ID="Label23" runat="server" 
                    Text="Justification for the Position Urgency" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td __designer:mapid="1b5">
                                <table cellpadding="0" cellspacing="0" class="style123">
                                    <tr>
                                        <td>
            <asp:TextBox ID="Text_Justific" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="293px" BorderWidth="1px" 
                    Height="82px" TextMode="MultiLine" style="left: 28px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style122" __designer:mapid="1b6">
            <asp:Label ID="Label_Charactor" runat="server" 
                    Text="Less Than 100 Charactor" Font-Size="10px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
                                        </td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style124" __designer:mapid="1b4">
            <asp:Label ID="Label24" runat="server" 
                    Text="Number of Candidates" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td __designer:mapid="1b5">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="16px" 
                    RepeatDirection="Horizontal" Width="261px" AutoPostBack="True" 
                                    onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                <asp:ListItem Value="1">One</asp:ListItem>
                <asp:ListItem Value="2">More than One</asp:ListItem>
            </asp:RadioButtonList>
                            </td>
                            <td class="style122" __designer:mapid="1b6">
                                &nbsp;</td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style124" __designer:mapid="1b4">
            <asp:Label ID="Label28" runat="server" 
                    Text="Justification when Single Candidate" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td __designer:mapid="1b5">
            <asp:TextBox ID="Text_Single_Justific" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="293px" BorderWidth="1px" 
                    Height="82px" TextMode="MultiLine" style="left: 28px"></asp:TextBox>
                                        </td>
                            <td class="style122" __designer:mapid="1b6">
            <asp:Label ID="Label_Charactor0" runat="server" 
                    Text="Less Than 100 Charactor" Font-Size="10px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
                                        </td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style124" __designer:mapid="1b4">
                                &nbsp;</td>
                            <td __designer:mapid="1b5">
                                &nbsp;</td>
                            <td class="style122" __designer:mapid="1b6">
                                &nbsp;</td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style120" __designer:mapid="1b4" colspan="2">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:Button ID="Butt_Add_Details" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Add Details" onclick="Butt_Add_Details_Click" Width="98px" style="margin-left: 0px" 
                                Height="23px" CausesValidation="False" />
                            </td>
                            <td class="style122" __designer:mapid="1b6">
                                &nbsp;</td>
                        </tr>
                        <tr __designer:mapid="1b0">
                            <td class="style124" __designer:mapid="1b4">
                                &nbsp;</td>
                            <td __designer:mapid="1b5">
                                    <table cellpadding="0" cellspacing="0" class="style61">
                                        <tr>
                                            <td class="style103" colspan="2">
                                    <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                                                </td>
                                            <td class="style72">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style72">
                                            </td>
                                            <td class="style100">
                                                <table cellpadding="0" cellspacing="0" class="style63">
                                                    <tr>
                                                        <td class="style96">
                                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                                Font-Size="9pt" onclick="Submit_Click_Click" Text="Submit" Width="65px" 
                                                                style="height: 22px" />
                                                        </td>
                                                        <td class="style96">
                                                        </td>
                                                        <td class="style96">
                                                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                                Font-Names="Verdana" Font-Size="9pt" Height="22px" onclick="Butt_Reset_Click" 
                                                                Text="Reset" Width="65px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="style72">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style88">
                                                &nbsp;</td>
                                            <td class="style101">
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            <td class="style122" __designer:mapid="1b6">
                                &nbsp;</td>
                        </tr>
                    </table>
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



