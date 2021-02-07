<%@ Page Title="Accommodation, Travel & Migration Request" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="TravelMigration.aspx.cs" Inherits="UsersArea_TravelMigration" %>
<%@ Register src="../userControll/ServicesRequested.ascx" tagname="ServicesRequested" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style10
    {
        width: 120px;
    }
    .style11
    {
            width: 196px;
        }
    .style12
    {
            width: 434px;
            height: 17px;
        }
    .style14
    {
        height: 17px;
    }
        .style15
        {
            width: 196px;
            height: 25px;
        }
        .style17
        {
            width: 116px;
            height: 25px;
        }
        .style19
    {
        height: 25px;
    }
        .style20
        {
            height: 17px;
        }
        .style22
        {
            height: 17px;
            }
        .style23
        {
            width: 36px;
        }
        .style24
        {
            width: 36px;
            height: 25px;
        }
        .style29
        {
            width: 296px;
            height: 17px;
        }
        .style31
        {
            width: 120px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_13.gif" />
                </b>
            </td>
        </tr>
        <tr>
            <td class="style15">
            </td>
            <td class="style24">
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style19">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style19">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label2" runat="server" Text="Employee Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style19">
               </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="190px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style19">
                </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label21" runat="server" Text="Section" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_SectionName" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="300" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style19">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label26" runat="server" Text="Contractor Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_ContractorName" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="300"></asp:TextBox>
            </td>
            <td class="style19">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    Font-Names="Tahoma" Font-Size="12px" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label22" runat="server" Text="Location" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    Font-Names="Tahoma" Font-Size="12px" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
            <td class="style19">
               </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Label ID="Label27" runat="server" Text="Remarks" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style24">
                <asp:TextBox ID="Text_Remarks" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="300" 
                    Height="85px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style19">
                <asp:Label ID="Label_Charactor" runat="server" Text="Less Than 500 Character" Font-Size="10px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
               </td>
        </tr>
        <tr>
            <td class="style20" colspan="3">
                            
                
                                <asp:FileUpload ID="FileUploader" runat="server" Font-Names="Tahoma" 
                                        Width="529px" />
                                <asp:Button ID="UploadButton" runat="server" CausesValidation="False" 
                                        Height="24px" onclick="UploadButton_Click" 
                     Text="Upload" Width="75px" />
                            
                
                        </td>
        </tr>
        <tr>
            <td class="style20">
                &nbsp;</td>
            <td class="style22" colspan="2">
                <asp:Label ID="Label19" runat="server" Font-Names="Tahoma" Font-Size="12px" 
                    Text="Please make sure to submit all supporting documents"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style14">
                </td>
            <td class="style14" colspan="2">
                <asp:Label ID="Label_Uplode" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style20">
                &nbsp;</td>
            <td class="style22" colspan="2">
                <asp:Label ID="Label_UplodeName" runat="server" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style20" colspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <table cellpadding="0" cellspacing="0" class="style6">
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Services Requested"></asp:Label>
                            </td>
                            <td class="style31">
                                &nbsp;</td>
                            <td class="style31">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style31">
                                <asp:Label ID="Label23" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="From"></asp:Label>
                            </td>
                            <td class="style31">
                                <asp:Label ID="Label24" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="To"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Remark"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                                    Height="27px">
                                </asp:CheckBoxList>
                            </td>
                            <td colspan="3">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style31">
                                &nbsp;</td>
                            <td class="style31">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style14">
                </td>
            <td class="style14">
                &nbsp;</td>
            <td class="style14">
                </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style10" colspan="2">
                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style10" colspan="2">
                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Submit" onclick="Butt_Submit_Click" Width="65px" 
                    style="height: 22px" />
                    <asp:Button ID="Butt_Reset" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Reset" CausesValidation="False" onclick="Butt_Reset_Click" 
                    Width="65px" />
            </td>
        </tr>
        <tr>
            <td class="style11">
                </td>
            <td class="style23">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
            </td>
            <td class="style29">
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



