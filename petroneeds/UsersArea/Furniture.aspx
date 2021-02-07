<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" CodeFile="Furniture.aspx.cs" Inherits="UsersArea_Furniture" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 80%;
        }
        .style27
        {
        }
        .style30
        {
            width: 98%;
        }
        .style31
        {
            height: 21px;
        }
        .style42
        {
            height: 25px;
        }
        .style43
        {
            width: 125px;
            height: 20px;
        }
        .style44
        {
            width: 70px;
            height: 25px;
        }
        .style45
        {
            height: 20px;
        }
        .style46
        {
            height: 25px;
        }
        .style47
        {
            width: 60px;
            height: 25px;
        }
        .style49
        {
            width: 260px;
            height: 25px;
        }
        .style58
        {
            width: 90px;
            height: 25px;
        }
        .style59
        {
            width: 245px;
            height: 25px;
        }
        .style70
        {
            width: 389px;
            height: 22px;
        }
        .style73
        {
            height: 25px;
        }
        .style74
        {
            width: 82px;
        }
        .style75
        {
            height: 25px;
            width: 82px;
        }
        .style91
        {
            width: 52px;
        }
        .style92
        {
            height: 25px;
        }
        .style93
        {
            width: 2px;
            height: 25px;
        }
        .style96
    {
        width: 186px;
        height: 25px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3" class="style31">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/FunNew.PNG" 
                    Height="39px" />
                </b></td>
            <td class="style31">
            </td>
        </tr>
        <tr>
            <td class="style74">
                &nbsp;</td>
            <td class="style43">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td class="style45">
            </td>
        </tr>
        <tr>
            <td class="style27" colspan="4">
                <table cellpadding="0" cellspacing="0" class="style30">
                    <tr>
                        <td class="style58">
                <asp:Label ID="Label16" runat="server" Text="Request No" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style59">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style44">
                            &nbsp;</td>
                        <td class="style46">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style58">
                            <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style59">
                            <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style47">
                           </td>
                        <td class="style44">
                           </td>
                        <td class="style46">
                           </td>
                    </tr>
                    <tr>
                        <td class="style58">
                <asp:Label ID="Label23" runat="server" Text="Request By" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style59">
                            <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style44">
                            &nbsp;</td>
                        <td class="style46">
                            </td>
                    </tr>
                    <tr>
                        <td class="style58">
                            <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style59">
                            <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style44">
                            &nbsp;</td>
                        <td class="style46">
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td class="style75">
                            &nbsp;</td>
            <td class="style73">
                            &nbsp;</td>
            <td class="style42">
                            &nbsp;</td>
            <td class="style46">
            </td>
        </tr>
        <tr>
            <td class="style46" colspan="4">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:Button ID="Butt_AddRequest" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Add Request" onclick="Butt_Add_New_Click" Width="110px" style="margin-left: 0px" 
                                Height="23px" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td class="style75">
                            &nbsp;</td>
            <td class="style73" colspan="2">
                                <table cellpadding="0" cellspacing="0" class="style70" __designer:mapid="72">
                                    <tr __designer:mapid="73">
                                        <td __designer:mapid="74">
                                            &nbsp;</td>
                                        <td class="style92" __designer:mapid="75" colspan="6">
                                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                                        </td>
                                        <td __designer:mapid="7d">
                                            &nbsp;</td>
                                        <td __designer:mapid="7e">
                                            &nbsp;</td>
                                    </tr>
                                    <tr __designer:mapid="73">
                                        <td __designer:mapid="74">
                                            &nbsp;</td>
                                        <td class="style96" __designer:mapid="75">
                                            &nbsp;</td>
                                        <td __designer:mapid="76">
                                        </td>
                                        <td class="style91" __designer:mapid="77">
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" style="margin-left: 0px" 
                                                Text="Submit" Width="65px" />
                                        </td>
                                        <td class="style93" __designer:mapid="79">
                                            &nbsp;</td>
                                        <td __designer:mapid="7a">
                                            &nbsp;</td>
                                        <td __designer:mapid="7b">
                                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                Width="65px" />
                                        </td>
                                        <td __designer:mapid="7d">
                                        </td>
                                        <td __designer:mapid="7e">
                                        </td>
                                    </tr>
                                </table>
                            </td>
            <td class="style46">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style75">
                            &nbsp;</td>
            <td class="style73">
                            &nbsp;</td>
            <td class="style42">
                &nbsp;</td>
            <td class="style46">
                &nbsp;</td>
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



