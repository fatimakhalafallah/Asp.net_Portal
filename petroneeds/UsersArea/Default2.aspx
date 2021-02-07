<%@ Page Title="IT Equipments Request Form (ERF)" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Leave.aspx.cs" Inherits="Leave" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 186px;
        }
        .style8
        {
            text-align: left;
        }
        .style9
        {
            width: 150px;
        }
        .style11
        {
            width: 124px;
            text-align: left;
        }
        .style12
        {
        width: 104px;
    }
        .style16
        {
            height: 22px;
        }
        .style27
        {
            height: 23px;
            width: 124px;
        }
        .style28
        {
            height: 23px;
            width: 168px;
        }
        .style29
        {
        }
        .style30
        {
            width: 237px;
            height: 22px;
        }
        .style31
        {
            width: 23px;
            height: 22px;
        }
        .style32
        {
            width: 12px;
            height: 22px;
        }
        .style33
        {
            width: 237px;
            height: 25px;
        }
        .style34
        {
            width: 23px;
            height: 25px;
        }
        .style35
        {
            width: 12px;
            height: 25px;
        }
        .style45
        {
            text-align: left;
        }
        .style48
        {
            text-align: left;
            vertical-align: text-top;
            width: 168px;
        }
        .style49
        {
            width: 168px;
        }
        .style50
        {
            text-align: left;
            width: 168px;
        }
        .style51
        {
            width: 162px;
            height: 22px;
        }
        .style52
        {
            width: 162px;
            height: 25px;
        }
        .style53
        {
            width: 136px;
            height: 22px;
        }
        .style54
        {
            width: 136px;
            height: 25px;
        }
        .style55
        {
            height: 23px;
        }
        .style56
        {
            width: 124px;
        }
        .style57
        {
            width: 124px;
            height: 34px;
        }
        .style58
        {
            width: 168px;
            height: 34px;
        }
        .style59
        {
            text-align: left;
            height: 34px;
        }
        .style60
        {
            width: 124px;
            height: 29px;
        }
        .style61
        {
            width: 168px;
            height: 29px;
        }
        .style62
        {
            text-align: left;
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" width="600px">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_12.gif" 
                    ImageAlign="Left" />
                </b></td>
        </tr>
        <tr>
            <td class="style11">
                </td>
            <td class="style48">
                </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style29" rowspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label2" runat="server" Text="Employee Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Name" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label3" runat="server" Text="Employee ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Id" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="92px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Id" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label4" runat="server" Text="Position" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="300px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="200px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True" ontextchanged="Text_Department_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style57">
                <asp:Label ID="Label17" runat="server" Text="Items" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style58">
                <asp:DropDownList ID="DropDownList1" runat="server"
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged"> 
                
                 <asp:ListItem Selected="True" Text="<<<Select>>>" Value="0">&lt;&lt;&lt;Select&gt;&gt;&gt;</asp:ListItem>
                    <asp:ListItem Value="1">Desktop</asp:ListItem>
                    <asp:ListItem Value="2">Labtop</asp:ListItem>
                    <asp:ListItem Value="3">Printer</asp:ListItem>
                    <asp:ListItem Value="4">Sim card</asp:ListItem>
                    <asp:ListItem Value="5">ink cartridges </asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td class="style59">
                </td>
        </tr>
        <tr>
            <td class="style56">
                <asp:Label ID="Label18" runat="server" Text="Quantity" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" BorderWidth="1px" Width="66px"></asp:TextBox>
            </td>
            <td class="style45">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="style60">
                <asp:Label ID="Label19" runat="server" Text="Location" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style61">
                <asp:DropDownList ID="DropDownList2" runat="server" ForeColor="#6C6459" 
                    Height="25px" AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged"> 
                 <asp:ListItem Selected="True" Text="<<<Select>>>" Value="0">&lt;&lt;&lt;Select&gt;&gt;&gt;</asp:ListItem>
                    <asp:ListItem Value="1">HQ</asp:ListItem>
                    <asp:ListItem Value="2">Almamora</asp:ListItem>
                    <asp:ListItem Value="3">Work shop</asp:ListItem>
                    <asp:ListItem Value="4">Albager</asp:ListItem>
                    <asp:ListItem Value="5">Balila</asp:ListItem>
                    <asp:ListItem Value="6">Higlig</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style62">
                </td>
        </tr>
        <tr>
            <td class="style16" colspan="3">
                <asp:Panel ID="Panel1" runat="server" Width="511px">
                    <asp:Label ID="Label8" runat="server" Text="Justification" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Text_Specify" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="349px" BorderWidth="1px" TextMode="MultiLine" 
                        style="margin-left: 33px"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
&nbsp;<b style="mso-bidi-font-weight:normal"><span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PetroneedsConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PetroneedsConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT LEAVE_TYPE_NAME, LEAVE_TYPE_NO FROM MP.LKP_LEAVE_TYPES">
                </asp:SqlDataSource>
                <b style="mso-bidi-font-weight:normal">
                <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><asp:ToolkitScriptManager 
                    ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </span></b>
                </span></b>
            </td>
            <td>
               </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td>
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








<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder5">
    </asp:Content>









