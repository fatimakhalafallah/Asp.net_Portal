<%@ Page Title="Petroneeds Services International :: Welcome" Language="C#" MasterPageFile="~/AdminArea/MasterPage.master" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="AdminArea_welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style70
        {
            width: 389px;
            height: 22px;
        }
        .style71
        {
            width: 202px;
        }
        .style72
        {
            width: 5px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21" colspan="2">
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_1.gif" />
            </td>
            <td class="style72">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21">
                &nbsp;</td>
            <td class="style50">
                &nbsp;</td>
            <td class="style72">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21">
                <asp:Label ID="Label19" runat="server" Text="Title" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style50">
                <asp:TextBox ID="Text_Title" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="33px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style72">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Title" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21">
                <asp:Label ID="Label20" runat="server" Text="Paragraph 1" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style50">
                <asp:TextBox ID="Text_Details" runat="server"  
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="107px" 
                                TextMode="MultiLine" BorderColor="#B00000"></asp:TextBox>
            </td>
            <td class="style72">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Details" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21">
                <asp:Label ID="Label21" runat="server" Text="Paragraph 2" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style50">
                <asp:TextBox ID="Text_Details2" runat="server"  
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="107px" 
                                TextMode="MultiLine" BorderColor="#B00000"></asp:TextBox>
            </td>
            <td class="style72">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
            <td class="style21">
                <asp:Label ID="Label22" runat="server" Text="Paragraph 3" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style50">
                <asp:TextBox ID="Text_Details3" runat="server"  
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="107px" 
                                TextMode="MultiLine" BorderColor="#B00000"></asp:TextBox>
            </td>
            <td class="style72">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                            &nbsp;</td>
            <td class="style22" colspan="3">
                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                            &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                            &nbsp;</td>
            <td class="style22" colspan="3">
                                <table cellpadding="0" cellspacing="0" class="style70" __designer:mapid="63">
                                    <tr __designer:mapid="64">
                                        <td __designer:mapid="65">
                                            &nbsp;</td>
                                        <td class="style92" __designer:mapid="66">
                                            &nbsp;</td>
                                        <td __designer:mapid="67">
                                        </td>
                                        <td class="style91" __designer:mapid="68">
                                            &nbsp;</td>
                                        <td class="style93" __designer:mapid="6a">
                                            &nbsp;</td>
                                        <td __designer:mapid="6b">
                                            &nbsp;</td>
                                        <td __designer:mapid="6c" class="style71">
                                            &nbsp;</td>
                                        <td __designer:mapid="6e">
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" style="margin-left: 0px" 
                                                Text="Submit" Width="65px" />
                                        </td>
                                        <td __designer:mapid="6f">
                                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                Width="65px" />
                                        </td>
                                    </tr>
                                </table>
            </td>
            <td class="style24">
                            &nbsp;</td>
        </tr>
    </table>
</asp:Content>



