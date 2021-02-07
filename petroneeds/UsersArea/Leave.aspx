<%@ Page Title="Leave Request Form (LRF)" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Leave.aspx.cs" Inherits="Leave" %>
<%@ Register src="../userControll/TravelDescription.ascx" tagname="TravelDescription" tagprefix="uc1" %>
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
        .style13
        {
            width: 420px;
        }
       
        .style15
        {
            height: 30px;
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
        .style36
        {
            height: 25px;
        }
        .style37
        {
            width: 100%;
        }
     
        .style39
        {
            height: 20px;
        }
        .style41
    {
            height: 20px;
            width: 88px;
        }
    .style42
    {
            width: 88px;
        }
        .style43
        {
            height: 12px;
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
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                <asp:Label ID="Label7" runat="server" Text="Type of Leave" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <table width="300px">
                    <tr>
                        <td class="style15">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="LEAVE_TYPE_NAME" 
                                DataValueField="LEAVE_TYPE_NO" Width="183px" 
                                AutoPostBack="True" Font-Size="12px">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                oncheckedchanged="CheckBox1_CheckedChanged" Text="Other" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style45">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style16" colspan="3">
                <asp:Panel ID="Panel1" runat="server" Width="470px">
                    <asp:Label ID="Label8" runat="server" Text="Please Specify" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Text_Specify" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="349px" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style56">
                    <asp:Label ID="Label9" runat="server" Text="Dates of Leave" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style10" colspan="2">
                <table style="width: 453px">
                    <tr>
                        <td class="style30">
                    <asp:Label ID="Label10" runat="server" Text="From" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style31">
                <asp:TextBox ID="Text_from" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="150px" BorderWidth="1px" AutoPostBack="True" 
                                ontextchanged="Text_from_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="Text_from_CalendarExtender" runat="server" 
                                TargetControlID="Text_from" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>
                        </td>
                        <td class="style32">
                    <asp:Label ID="Label11" runat="server" Text="To" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style53">
                <asp:TextBox ID="Text_To" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="150px" BorderWidth="1px" AutoPostBack="True" 
                                ontextchanged="Text_To_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="Text_To_CalendarExtender" runat="server" 
                                TargetControlID="Text_To" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>
                        </td>
                        <td class="style51">
                            </td>
                    </tr>
                    <tr>
                        <td class="style33">
                    <asp:Label ID="Label12" runat="server" Text="No. of Days" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style34">
                <asp:TextBox ID="Text_NoofDay" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="95px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                        <td class="style35">
                            </td>
                        <td class="style54">
                            </td>
                        <td class="style52">
                            </td>
                    </tr>
                    </table>
                </td>
        </tr>
        <tr>
            <td class="style27">
                    <asp:Label ID="Label13" runat="server" Text="Reasons for Leave" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                    <asp:TextBox ID="Text_Reasons" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                </td>
            <td class="style55">
                </td>
        </tr>
        <tr>
            <td class="style27">
                    <asp:Label ID="Label15" runat="server" Text="Contacts While on Leave" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                    <asp:TextBox ID="Text_ContactLeave" runat="server" BorderColor="#B00000" 
                    BorderStyle="Inset" Width="320px" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="Label_Error" runat="server" Font-Size="10px" 
                    ForeColor="Maroon">Less than 100</asp:Label>
                </td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style11">
                    &nbsp;</td>
            <td class="style48">
                    <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
               </td>
            <td class="style50">
                &nbsp;</td>
            <td class="style45">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Submit" onclick="Butt_Submit_Click" Width="90px" 
                    style="height: 22px" />
&nbsp;<asp:Button ID="Butt_Reset" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Reset" CausesValidation="False" onclick="Butt_Reset_Click" 
                    Width="90px" />
                <b style="mso-bidi-font-weight:normal">
                <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
                &nbsp;<asp:Button ID="leaveHistory" runat="server" 
                    Text="View History" CausesValidation="False" Width="90px" style="margin-left: 0px" 
                                Height="23px" onclick="leaveHistory_Click"/> 



                <asp:ToolkitScriptManager 
                    ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <b style="mso-bidi-font-weight:normal">
                <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PetroneedsConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PetroneedsConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT LEAVE_TYPE_NAME, LEAVE_TYPE_NO FROM MP.LKP_LEAVE_TYPES">
                </asp:SqlDataSource>
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
    <table cellpadding="0" cellspacing="0" class="style9">
    <tr>
        <td valign="top">
                <table cellpadding="0" cellspacing="0" class="style37">
                    <tr>
                        <td class="style43" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style38" colspan="2">
                <asp:Label ID="Label18" runat="server" Text="Leftover Days" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style36" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="style41">
                <asp:Label ID="Label17" runat="server" Text="Entitlement" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style39">
                <asp:TextBox ID="Text_Days" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="60px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style41">
                <asp:Label ID="Label20" runat="server" Text="Taken" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style39">
                <asp:TextBox ID="Text_Taken" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="60px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style41">
                <asp:Label ID="Label21" runat="server" Text="Previous" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style39">
                <asp:TextBox ID="Text_Previous" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="60px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style41">
                <asp:Label ID="Label22" runat="server" Text="Balance" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style39">
                <asp:TextBox ID="Text_Balance" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="60px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                <asp:Label ID="Label19" runat="server" Text="Year" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="Text_Year" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="60px" BorderWidth="1px" ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style42">
                            </td>
                        <td>
                            </td>
                    </tr>
                </table>
                </td>
    </tr>
</table>
</asp:Content>









