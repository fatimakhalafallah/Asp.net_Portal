<%@ Page Title="Travel Request Form (TRF)" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Copy of Travel.aspx.cs" Inherits="Travel" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       .style8
        {
            height: 17px;
        }
        .style9
        {
            height: 17px;
            width: 309px;
        }
        .style10
        {
        }
        .style12
        {
        }
        .style14
        {
            height: 30px;
        }
        .style22
        {
            height: 21px;
        }
        .style23
        {
            width: 12px;
            height: 25px;
        }
        .style24
        {
            height: 21px;
        }
        .style26
        {
        height: 25px;
    }
        .style27
        {
        width: 39px;
        height: 21px;
    }
        .style30
        {
    }
        .style38
        {
            height: 24px;
            width: 308px;
        }
        .style39
        {
            height: 24px;
            }
        .style42
        {
            height: 23px;
        }
        .style47
        {
            height: 20px;
            width: 308px;
        }
        .style50
        {
            height: 25px;
        }
        .style52
        {
            height: 20px;
        }
        .style54
        {
            width: 462px;
        }
        .style55
        {
            width: 107px;
            height: 25px;
        }
        .style56
        {
            height: 21px;
            width: 107px;
        }
        .style57
        {
            height: 20px;
            width: 171px;
        }
        .style58
        {
            height: 17px;
            width: 171px;
        }
        .style60
        {
            height: 24px;
            width: 171px;
        }
        .style62
        {
            height: 22px;
            width: 171px;
        }
        .style63
        {
            height: 22px;
            width: 308px;
        }
        .style64
        {
            height: 22px;
        }
        .style65
        {
            height: 17px;
            width: 308px;
            text-align: left;
            vertical-align: text-top;
        }
        .style67
        {
            height: 17px;
            width: 308px;
        }
        .style68
        {
            width: 462px;
            height: 23px;
        }
        .style69
        {
            width: 308px;
            height: 23px;
        }
        .style70
        {
            width: 308px;
        }
        .style71
        {
            width: 171px;
            height: 23px;
        }
        .style72
        {
            width: 171px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" style="width: 674px">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_9.gif" />
                </b></td>
        </tr>
        <tr>
            <td class="style57">
            </td>
            <td class="style47">
            </td>
            <td class="style52">
                </td>
        </tr>
        <tr>
            <td class="style58">
                <b style="mso-bidi-font-weight: normal">
                <span style="font-size: 12.0pt; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;; mso-ascii-theme-font: minor-latin; mso-fareast-font-family: &quot;Times New Roman&quot;; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    <asp:Label ID="Label26" runat="server" Text="General" Font-Size="13px" 
                    ForeColor="Maroon" Font-Bold="False" Font-Names="Verdana"></asp:Label>
                </span></b>
            </td>
            <td class="style65">
            </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style69" rowspan="1">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style42" rowspan="1">
                </td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style69" rowspan="1">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="193px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style42" rowspan="1">
                </td>
        </tr>
        <tr>
            <td class="style60" rowspan="1">
                <asp:Label ID="Label2" runat="server" Text="Employee Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style38" rowspan="1">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style39" rowspan="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Name" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="style62" rowspan="1">
                <asp:Label ID="Label3" runat="server" Text="Employee ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style63" rowspan="1">
                <asp:TextBox ID="Text_Id" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="92px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style64" rowspan="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Id" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label4" runat="server" Text="Position" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style69" rowspan="1">
                <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="300px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style42" rowspan="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Position" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td rowspan="1" class="style72">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style70" rowspan="1">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="200px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td rowspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label6" runat="server" Text="Reporting to" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                </td>
            <td class="style69" rowspan="1">
                <asp:TextBox ID="Text_report" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50"></asp:TextBox>
                </td>
            <td class="style42" rowspan="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="Text_report" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td rowspan="1" class="style72">
                <asp:Label ID="Label7" runat="server" Text="Purpose of Travel" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style70" rowspan="1">
                <table class="style7" style="width: 337px">
                    <tr>
                        <td class="style14">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="PURPOSE" 
                                DataValueField="SERIAL">
                            </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PetroneedsConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PetroneedsConnectionString.ProviderName %>" 
                    SelectCommand="SELECT SERIAL, PURPOSE FROM TRAVEL_PURPOSE">
                </asp:SqlDataSource>
                        </td>
                    </tr>
                    </table>
            </td>
            <td rowspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td rowspan="1" class="style72">
                    <asp:Label ID="Label8" runat="server" Text="Please Specify" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                    </td>
            <td class="style70" rowspan="1">
                    <asp:TextBox ID="Text_Specify" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="325px" BorderWidth="1px" TextMode="MultiLine" 
                        Height="46px"></asp:TextBox>
                </td>
            <td rowspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style57">
            </td>
            <td class="style52" colspan="2">
                </td>
        </tr>
        <tr>
            <td class="style58" rowspan="1">
                    &nbsp;</td>
            <td class="style8" colspan="2" rowspan="1">
                <table cellpadding="0" cellspacing="0" class="style7" style="width: 452px">
                    <tr>
                        <td class="style42">
                            </td>
                        <td class="style68">
                            </td>
                        <td class="style42">
                            </td>
                        <td class="style42">
                <asp:Button ID="Butt_Add_New" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Add New" onclick="Butt_Add_New_Click" Width="110px" style="margin-left: 0px" 
                                Height="23px" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style54">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style54">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Butt_Add_Description" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Add Trip" onclick="Butt_Add_Description_Click" Width="110px" style="margin-left: 0px" 
                                Height="23px" />
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td class="style12" colspan="3" rowspan="1">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style30" colspan="3" rowspan="1">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table class="style7">
                        <tr>
                            <td class="style26" colspan="2">
                                <asp:Label ID="Label9" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Description"></asp:Label>
                            </td>
                            <td class="style50">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style55">
                                <asp:Label ID="Label27" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Number"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_NumDeta" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="66px"></asp:TextBox>
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
                                    Text="Location"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_from_Loca" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="Text_from_Loca" ErrorMessage="*" ForeColor="#CC0000" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                <asp:Label ID="Label20" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Date"></asp:Label>
                            </td>
                            <td class="style23">
                                <asp:TextBox ID="Text_from_Date" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="Text_from_Date_CalendarExtender" runat="server" 
                                    Format="dd-MMMM-yyyy" TargetControlID="Text_from_Date">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style26">
                                <asp:Label ID="Label21" runat="server" Text="To" Font-Size="13px" 
                    ForeColor="Maroon" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="style55">
                                <asp:Label ID="Label18" runat="server" Text="Location" Font-Size="12px" 
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
                                <asp:Label ID="Label22" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style23">
                                <asp:TextBox ID="Text_To_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="150px" BorderWidth="1px"></asp:TextBox>
                                <asp:CalendarExtender ID="Text_To_Date_CalendarExtender" runat="server" 
                                TargetControlID="Text_To_Date" Format="dd-MMMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
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
                    BorderStyle="Solid" Width="375px" BorderWidth="1px" Height="107px" 
                                TextMode="MultiLine"></asp:TextBox>
                            </td>
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
                                &nbsp;</td>
                            <td class="style24">
                                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                    Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" 
                                    style="height: 22px" />
                                &nbsp;<asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                    Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                    Width="65px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td class="style58">
                   </td>
            <td class="style67">
                &nbsp;</td>
            <td class="style8">
               </td>
        </tr>
        <tr>
            <td class="style72">
                </td>
            <td class="style70">
                <b style="mso-bidi-font-weight: normal">
                   <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><asp:ToolkitScriptManager 
                    ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </span></b>
            </td>
            <td>
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



<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder5">
</asp:Content>




