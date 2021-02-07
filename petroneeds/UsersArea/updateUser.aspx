<%@ Page Title="" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="updateUser.aspx.cs" Inherits="UsersArea_updateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            height: 17px;
        }
        .style16
        {
        }
        .style18
        {
            height: 17px;
            width: 338px;
        }
        .style19
        {
            height: 17px;
            width: 330px;
        }
        .style20
        {
            height: 17px;
            width: 46px;
        }
        .style21
        {
            height: 17px;
            width: 143px;
        }
        .style23
        {
            width: 10px;
        }
        .style24
        {
            height: 17px;
            width: 10px;
        }
        .style25
        {
            height: 17px;
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <span style="color: #1350c5; font-family: Tierra Blanca">
    <table border="0" cellpadding="0" cellspacing="0" style="font-size: 20px; width: 68px;
                font-family: Tahoma; height: 149px; text-align: left">
        <tr>
            <td class="style7" colspan="5">
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/na_16.gif" />
            </td>
        </tr>
        <tr>
            <td class="style23">
            </td>
            <td class="style21">
            </td>
            <td class="style16">
                &nbsp;</td>
            <td class="style25">
            </td>
            <td class="style7" width="100">
            </td>
        </tr>
        <tr>
            <td class="style24">
                </td>
            <td class="style21">
                </td>
            <td class="style20">
                &nbsp;</td>
            <td class="style25">
                </td>
            <td width="100" class="style15">
                </td>
        </tr>
        <tr>
            <td class="style23">
                &nbsp;</td>
            <td class="style21">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label2" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Current Password" Width="115px" Height="17px"></asp:Label>
                </span>
            </td>
            <td class="style16">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:TextBox ID="Text_Old_Password" runat="server" TextMode="Password" 
                    Width="164px"></asp:TextBox>
    </span>
            </td>
            <td class="style25">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Old_Password" ErrorMessage="*" ForeColor="#993300" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
    </span>
            </td>
            <td width="100">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style23">
            </td>
            <td class="style21">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label5" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="New Password" Width="115px" Height="17px"></asp:Label>
                </span>
            </td>
            <td class="style16">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:TextBox ID="Text_New_Password" runat="server" TextMode="Password" 
                    Width="164px"></asp:TextBox>
                </span>
            </td>
            <td class="style25">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_New_Password" ErrorMessage="*" ForeColor="#993300" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
    </span>
            </td>
            <td width="100">
            </td>
        </tr>
        <tr>
            <td class="style23">
                &nbsp;</td>
            <td class="style21">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label6" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Confirm Password" Width="137px" Height="17px"></asp:Label>
    </span>
            </td>
            <td class="style16">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:TextBox ID="Text_Confirm_Password" runat="server" TextMode="Password" 
                    Width="164px"></asp:TextBox>
    </span>
            </td>
            <td class="style25">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Confirm_Password" ErrorMessage="*" ForeColor="#993300" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
    </span>
            </td>
            <td width="100">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style23">
                &nbsp;</td>
            <td class="style21">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td width="100">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                    ForeColor="#AF0102" onclick="LinkButton1_Click">Back</asp:LinkButton>
    </span>
            </td>
        </tr>
        <tr>
            <td class="style23">
            </td>
            <td class="style21">
            </td>
            <td class="style16" colspan="3">
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label4" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                    ForeColor="DarkRed" Height="16px"></asp:Label>
    </span>
            </td>
        </tr>
        <tr>
            <td class="style24">
            </td>
            <td class="style21">
            </td>
            <td class="style20">
            </td>
            <td class="style25">
            </td>
            <td class="style18" width="100">
            </td>
        </tr>
        <tr>
            <td class="style23">
            </td>
            <td class="style21">
            </td>
            <td class="style16">
                <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" 
                    style="width: 128px" align="left">
                    <tr>
                        <td>
                            <span style="color: #1350c5; font-family: Tierra Blanca">
                            <asp:Button ID="Butt_Send" runat="server" Font-Names="Corbel" 
                                OnClick="Butt_Send_Click" Text="Send" />
                            </span>
                        </td>
                        <td class="style19">
                            &nbsp;</td>
                        <td>
                            <span style="color: #1350c5; font-family: Tierra Blanca">
                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                Font-Names="Corbel" OnClick="Butt_Reset_Click" Text="Reset" />
                            </span>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="style25">
            </td>
            <td width="100">
            </td>
        </tr>
        <tr>
            <td class="style23">
                &nbsp;</td>
            <td class="style21">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td width="100">
                &nbsp;</td>
        </tr>
    </table>
    </span>
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
</asp:Content>



