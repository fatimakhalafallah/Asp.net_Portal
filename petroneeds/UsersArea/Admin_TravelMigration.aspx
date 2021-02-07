<%@ Page Title="Travel Migration :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_TravelMigration.aspx.cs" Inherits="UsersArea_Admin_TravelMigration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style7
        {
            width: 99%;
        }
        .style37
        {
            width: 312px;
            height: 12px;
        }
        .style40
        {
            width: 153px;
            height: 25px;
        }
        .style41
        {
            width: 8px;
            height: 12px;
        }
        .style43
        {
            width: 153px;
            height: 12px;
        }
        .style45
        {
            width: 50%;
        }
        .style46
        {
            width: 183px;
        }
        .style48
        {
            width: 10px;
        }
        .style49
        {
            width: 10px;
            height: 97px;
        }
        .style50
        {
            height: 97px;
        }
        .style51
        {
            width: 153px;
            height: 67px;
        }
        .style52
        {
            width: 8px;
            height: 67px;
        }
        .style54
        {
            height: 67px;
        }
        .style55
        {
            height: 15px;
        }
        .style56
        {
            width: 10px;
            height: 38px;
        }
        .style57
        {
            width: 150px;
            text-align: left;
            vertical-align: text-top;
            height: 38px;
        }
        .style58
        {
            height: 38px;
        }
        .style59
        {
            height: 35px;
        }
        </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
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



<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3" class="style40">
                <b>
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_9.gif" />
                </b>
            </td></tr><tr><td class="style48"></td>
            <td>
                </td>
            <td></td> </tr><tr> <td class="style48"></td>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="TS_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1" 
                    PageSize="20" Font-Size="12px">
                    <Columns>
                        <asp:BoundField DataField="TS_NO" FooterText="Form No" HeaderText="Form No" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_USER" FooterText="Emp No" 
                            HeaderText="Emp No" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Employee Name" 
                            HeaderText="Employee Name">
                             <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TS_DATE" FooterText="Date" 
                            HeaderText="Date" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Bold="False" Font-Size="12px" />
                        <HeaderStyle Font-Bold="False" Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_DATE" FooterText="Create Date" 
                            HeaderText="Create Date" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PASSEN_NAME" FooterText="Passenger Name" 
                            HeaderText="Passenger Name" >
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="FILE_NAME" FooterText="Documents" 
                            HeaderText="Documents" Target="_blank" 
                            Text="Documents">
                        <ControlStyle ForeColor="#B00000" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle ForeColor="#B00000" Font-Size="11px" />
                        </asp:HyperLinkField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" >
                        <ControlStyle Font-Size="11px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="12px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="12px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#B00000" BorderColor="White" ForeColor="White" />
                </asp:GridView>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style56">
                </td>
            <td class="style57">
                <asp:TextBox ID="TextBox1" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="Label_Message" runat="server" Font-Size="Small" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
            <td class="style58">
                </td>
        </tr>
        <tr>
            <td class="style48">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style49">
            </td>
            <td class="style50">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7">
                        <tr>
                            <td class="style59" colspan="2">
                                </td>
                            <td class="style59">
                                </td>
                        </tr>
                        <tr>
                            <td class="style55" colspan="2">
                                Travel Migration Details:</td>
                            <td class="style55">
                            </td>
                        </tr>
                        <tr>
                            <td class="style55" colspan="3">
                                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                                    AutoGenerateRows="False" BorderWidth="0px" CellPadding="2" DataKeyNames="TS_NO" 
                                    GridLines="Horizontal" onpageindexchanging="DetailsView1_PageIndexChanging" 
                                    Width="600px">
                                    <FieldHeaderStyle ForeColor="#B00000" />
                                    <Fields>
                                        <asp:BoundField DataField="TS_NO" HeaderText="No" />
                                        <asp:BoundField DataField="SER_NAME" HeaderText="Service Name" />
                                    </Fields>
                                    <HeaderStyle BorderColor="#B00000" ForeColor="#B00000" />
                                    <PagerStyle BackColor="#B00000" />
                                </asp:DetailsView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style51">
                                <asp:Label ID="Label21" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td class="style52">
                                <asp:TextBox ID="Text_Comments" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style54">
                                </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                <asp:Label ID="Label_Message0" runat="server" Font-Size="Small" 
                                    ForeColor="#CC0000" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="12px" 
                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                    RepeatDirection="Horizontal" Width="194px" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                </asp:RadioButtonList>
                            </td>
                            <td class="style37">
                            </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                &nbsp;</td>
                            <td class="style41">
                                &nbsp;</td>
                            <td class="style37">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style43">
                                &nbsp;</td>
                            <td class="style41">
                                &nbsp;<table cellpadding="0" cellspacing="0" class="style45">
                                    <tr>
                                        <td class="style46">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" />
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
                            <td class="style37">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style50">
            </td>
        </tr>
        <tr>
            <td class="style48">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>




