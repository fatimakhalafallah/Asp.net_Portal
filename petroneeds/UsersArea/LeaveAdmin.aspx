<%@ Page Title="Petroneeds Services International :: Leave Request International" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="LeaveAdmin.aspx.cs" Inherits="UsersArea_LeaveAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style7
        {
            width: 99%;
        }
        .style8
        {
            width: 244px;
        }
        .style9
        {
            width: 517px;
        }
        .style11
        {
            width: 5px;
        }
        .style12
        {
            width: 5px;
            height: 17px;
        }
        .style13
        {
            width: 517px;
            height: 17px;
        }
        .style14
        {
            height: 17px;
        }
        .style17
        {
            height: 20px;
            width: 335px;
        }
        .style18
        {
            width: 244px;
            height: 20px;
        }
        .style19
        {
            color: #800000;
            font-size: 16px;
        }
        .style24
        {
            width: 335px;
        }
        .style27
        {
            width: 335px;
            height: 25px;
        }
        .style28
        {
            width: 244px;
            height: 25px;
        }
        .style29
        {
            width: 129px;
            height: 17px;
        }
        .style32
        {
            width: 100%;
        }
        .style36
        {
            width: 335px;
            height: 50px;
        }
        .style37
        {
            width: 244px;
            height: 50px;
        }
        .style38
        {
            width: 75px;
        }
        .style39
        {
            width: 316px;
        }
        .style40
        {
            height: 35px;
        }
        .style41
        {
            width: 228px;
            height: 25px;
        }
        .style42
        {
            width: 228px;
        }
        .style43
        {
            width: 228px;
            height: 20px;
        }
        .style44
        {
            width: 228px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3" class="style40">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_12.gif" />
                </b>
            </td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style9">
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <asp:GridView ID="GridView1" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="LEAVE_FORM__NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="LEAVE_FORM__NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="LEAVE_FORM__NO" />
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Employee No" 
                            HeaderText="Employee No" SortExpression="EMPLOYEE_NO" />
                        <asp:BoundField DataField="FORM_DATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="FORM_DATE" />
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="14px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <asp:GridView ID="GridView2" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView2_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView2_RowCreated" DataKeyNames="LEAVE_FORM__NO" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="LEAVE_FORM__NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="LEAVE_FORM__NO" />
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Employee No" 
                            HeaderText="Employee No" SortExpression="EMPLOYEE_NO" />
                        <asp:BoundField DataField="FORM_DATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="FORM_DATE" />
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="14px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
            </td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="Label_Message" runat="server" Font-Size="Small" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
            </td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                </td>
            <td class="style13">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7">
                        <tr>
                            <td class="style19" colspan="2">
                                Leave Details:</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                            </td>
                            <td class="style27">
                            </td>
                            <td class="style28">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label16" runat="server" Text="Employee Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label2" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Employee Name"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True" 
                                    Width="320px"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label19" runat="server" Text="Request Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Request" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label14" runat="server" Text="Start Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_StDate" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label18" runat="server" Text="End Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_EnDate" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label20" runat="server" Text="No of Days" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_NumOfDays" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label17" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Leave Name"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Leave_Name" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True" 
                                    Width="320px"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                &nbsp;</td>
                            <td class="style24">
                                &nbsp;</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style43">
                                <asp:Label ID="Label21" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:TextBox ID="Text_Comments" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                            <td class="style44">
                                </td>
                            <td class="style36">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal" Width="194px">
                                </asp:RadioButtonList>
                                <asp:Label ID="Label_Message0" runat="server" Font-Size="Small" 
                                    ForeColor="#CC0000" ondatabinding="RadioButtonList1_SelectedIndexChanged" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="style37">
                                </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                &nbsp;</td>
                            <td class="style24">
                                <table cellpadding="0" cellspacing="0" class="style32">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style39">
                                            &nbsp;</td>
                                        <td class="style38">
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" 
                                                style="height: 22px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                Width="65px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel2" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7">
                        <tr>
                            <td class="style19" colspan="2">
                                Leave Details:</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                            </td>
                            <td class="style27">
                            </td>
                            <td class="style28">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label22" runat="server" Text="Employee Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Num0" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label23" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Employee Name"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Name0" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True" 
                                    Width="320px"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label24" runat="server" Text="Request Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Request0" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label25" runat="server" Text="Start Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_StDate0" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                            </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label26" runat="server" Text="End Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_EnDate0" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label27" runat="server" Text="No of Days" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_NumOfDays0" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label28" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Leave Name"></asp:Label>
                            </td>
                            <td class="style24">
                                <asp:TextBox ID="Text_Leave_Name0" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True" 
                                    Width="320px"></asp:TextBox>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style42">
                                &nbsp;</td>
                            <td class="style24">
                                &nbsp;</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style43">
                                <asp:Label ID="Label29" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:TextBox ID="Text_Comments0" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                            <td class="style44">
                                </td>
                            <td class="style36">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                    onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal" Width="194px">
                                </asp:RadioButtonList>
                                <asp:Label ID="Label_Message1" runat="server" Font-Size="Small" 
                                    ForeColor="#CC0000" ondatabinding="RadioButtonList1_SelectedIndexChanged" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="style37">
                                </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                &nbsp;</td>
                            <td class="style24">
                                <table cellpadding="0" cellspacing="0" class="style32">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style39">
                                            &nbsp;</td>
                                        <td class="style38">
                                            <asp:Button ID="Butt_Submit0" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" 
                                                style="height: 22px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="Butt_Reset0" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                Width="65px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style14">
                </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style29">
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


