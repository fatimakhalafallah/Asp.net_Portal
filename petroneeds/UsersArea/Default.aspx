<%@ Page Title="" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UsersArea_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
    {
        width: 97%;
        
    }
        .style23
        {
            height: 29px;
            width: 414px;
        }
        .style25
        {
            width: 90%;
        }
        .style31
        {
            height: 29px;
        }
        .style34
        {
            width: 76px;
            height: 29px;
        }
        .style36
        {
            width: 277px;
        }
        .style37
        {
            height: 19px;
            width: 277px;
        }
        .style38
        {
            width: 101%;
        }
        .style39
        {
            width: 326px;
        }
        .style40
        {
            width: 277px;
            height: 20px;
        }
        .style42
        {
            width: 76px;
            height: 3px;
        }
        .style43
        {
            height: 3px;
            width: 414px;
        }
        .style44
        {
            height: 3px;
        }
        .style45
        {
            width: 76px;
            height: 44px;
        }
        .style46
        {
            height: 44px;
            width: 414px;
        }
        .style47
        {
            height: 44px;
        }
        .style48
        {
            width: 76px;
        }
        .style49
        {
            width: 414px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="2">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/na_15.gif" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style48">
            </td>
            <td class="style49">
                <table cellpadding="0" cellspacing="0" class="style25">
                    <tr>
                        <td class="style36">
                            <asp:TextBox ID="Text_Name" runat="server" 
                    BorderStyle="None" Width="300px" 
                    Height="20px" ReadOnly="True" Font-Names="Tahoma" Font-Size="11px" 
                                ontextchanged="Text_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style40">
                            <asp:TextBox ID="Text_ID" runat="server" 
                    BorderStyle="None" Width="300px" 
                    Height="20px" ReadOnly="True" Font-Names="Tahoma" Font-Size="11px" 
                                style="margin-top: 0px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style37">
                            <asp:TextBox ID="Text_E_Mail" runat="server" 
                    BorderStyle="None" Width="300px" 
                    Height="20px" ReadOnly="True" Font-Names="Tahoma" Font-Size="11px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style36">
                            <asp:TextBox ID="Text_Department" runat="server" 
                    BorderStyle="None" Width="300px" 
                    Height="20px" ReadOnly="True" Font-Names="Tahoma" Font-Size="11px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style43">
                &nbsp;</td>
            <td class="style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style43">
                                <asp:Label ID="Label_Check_Password" runat="server" Font-Size="11px" 
                                    ForeColor="#993333"></asp:Label>
                            </td>
            <td class="style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style43">
                &nbsp;</td>
            <td class="style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td class="style43">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:LinkButton ID="Link_Update_Password" runat="server" ForeColor="#AF0102" 
                    onclick="Link_Update_Password_Click">Update Password</asp:LinkButton>
    </span>
            </td>
            <td class="style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                Font-Size="10px" ForeColor="#993333" onclick="LinkButton6_Click" Width="100px">Add Comment</asp:LinkButton>
            </td>
            <td class="style43">
            </td>
            <td class="style44">
            </td>
        </tr>
        <tr>
            <td class="style45">
            </td>
            <td class="style46">
                <asp:Panel ID="Panel1" runat="server" Width="447px">
                    <asp:TextBox ID="Text_Comment" runat="server" Height="115px" 
                        TextMode="MultiLine" Width="452px"></asp:TextBox>
                    <table cellpadding="0" cellspacing="0" class="style38">
                        <tr>
                            <td class="style39">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                <asp:Label ID="Label_Messages" runat="server" Font-Size="11px" 
                                    ForeColor="#993333"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                <asp:TextBox ID="Text_Date" runat="server" BorderStyle="None" 
                                    Font-Names="Tahoma" Font-Size="11px" Height="20px" ReadOnly="True" 
                                    Width="300px"></asp:TextBox>
                            </td>
                            <td>
                                <span style="color: #1350c5; font-family: Tierra Blanca">
                                <asp:Button ID="Butt_send" runat="server" Font-Names="Corbel" 
                                    OnClick="Butt_send_Click" Text="Send" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                    Font-Names="Corbel" OnClick="Butt_Reset_Click" Text="Reset" />
                                </span>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style47">
            </td>
        </tr>
        <tr>
            <td class="style34">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style31">
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
            ItemWrap="True" onmenuitemclick="menuBar_MenuItemClick">
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










