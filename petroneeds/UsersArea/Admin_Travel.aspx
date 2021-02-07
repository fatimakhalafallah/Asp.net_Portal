<%@ Page Title="Travel Request Form (TRF) :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Travel.aspx.cs" Inherits="UsersArea_Admin_Travel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style7
        {
            width: 50%;
            
        }
        .style32
        {
            width: 50%;
        }
        .style34
        {
            width: 8px;
        }
        .style35
        {
        }
        .style36
        {
            width: 546px;
        }
        .style37
        {
            width: 312px;
            height: 12px;
        }
        .style39
        {
            width: 153px;
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
        .style42
        {
            width: 82px;
        }
        .style43
        {
            width: 153px;
            height: 12px;
        }
        .style44
        {
            height: 110px;
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
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_9.gif" />
                </b>
            </td>
        </tr>
        <tr>
            <td class="style12">
            </td>
            <td class="style9">
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style9">
                <asp:GridView ID="GridView1" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="TRF_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1" 
                    PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="TRF_NO" FooterText="Form No" HeaderText="Form No" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Employee No" 
                            HeaderText="Employee No" Visible="False" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Created By" 
                            HeaderText="Created By">
                            <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FORM_DATE" FooterText="Date" HeaderText="Date" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" HeaderText="Department" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TRAVELER_NAME" FooterText="Name" HeaderText="Name" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRAVELER_POSITION" FooterText="Position" HeaderText="Position" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PURPOSE" FooterText="Purpose" HeaderText="Purpose" >
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PURPOSE_DESC" FooterText="Description" 
                            HeaderText="Description" >
                            <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" >
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
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
                </asp:GridView>
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="Label_Message" runat="server" Font-Size="Small" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style9">
                <asp:TextBox ID="TextBox1" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
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
                            <td class="style39">
                            </td>
                            <td class="style34">
                            </td>
                            <td class="style28">
                            </td>
                        </tr>
                        <tr>
                            <td class="style35" colspan="3">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" BorderWidth="0px" CellPadding="2" CellSpacing="1" 
                                    DataKeyNames="SERIAL_NO" EmptyDataText="No data was returned" 
                                    GridLines="Horizontal" HorizontalAlign="Left" PageIndex="1" PageSize="20" 
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" Width="600px">
                                    <Columns>
                                        <asp:BoundField DataField="SERIAL_NO" FooterText="No" HeaderText="No" />
                                        <asp:BoundField DataField="TRANS_DATE" FooterText="Trans Date" 
                                            HeaderText="Trans Date" />
                                        <asp:BoundField DataField="CITY_FROM" FooterText="From - City" 
                                            HeaderText="From - City" />
                                        <asp:BoundField DataField="FROM_DATE" FooterText="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="CITY_TO" FooterText="To - City" 
                                            HeaderText="To - City" />
                                        <asp:BoundField DataField="TO_DATE" FooterText="Date" HeaderText="Date" />
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
                        </tr>
                        <tr>
                            <td class="style44" colspan="3">
                                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                                    AutoGenerateRows="False" BorderWidth="0px" CellPadding="2" 
                                    DataKeyNames="SERIAL_NO" GridLines="Horizontal" 
                                    onpageindexchanging="DetailsView1_PageIndexChanging" Width="600px">
                                    <FieldHeaderStyle ForeColor="#B00000" />
                                    <Fields>
                                        <asp:BoundField DataField="SERIAL_NO" HeaderText="No" />
                                        <asp:BoundField DataField="TRANS_DATE" HeaderText="Trans Date" />
                                        <asp:BoundField DataField="CITY_FROM" HeaderText="City - From" />
                                        <asp:BoundField DataField="FROM_DATE" HeaderText="Date - From" />
                                        <asp:BoundField DataField="CITY_TO" HeaderText="City - To" />
                                        <asp:BoundField DataField="TO_DATE" HeaderText="Date - To" />
                                    </Fields>
                                    <HeaderStyle BorderColor="#B00000" ForeColor="#B00000" />
                                    <PagerStyle BackColor="#B00000" />
                                </asp:DetailsView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39">
                                &nbsp;</td>
                            <td class="style34">
                                &nbsp;</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                <asp:Label ID="Label21" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td class="style34">
                                <asp:TextBox ID="Text_Comments" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                <asp:Label ID="Label_Message0" runat="server" Font-Size="Small" 
                                    ForeColor="#CC0000" Visible="False"></asp:Label>
                            </td>
                            <td class="style41">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
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
                                <table cellpadding="0" cellspacing="0" class="style32">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style36">
                                            &nbsp;</td>
                                        <td class="style42">
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
                                       
                                        <td>
                                        &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style37">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                </td>
                            <td class="style34">
                            </td>
                            <td>
                                </td>
                        </tr>
                        <tr>
                            <td class="style39">
                                &nbsp;</td>
                            <td class="style34">
                                &nbsp;</td>
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
            <td class="style12">
                &nbsp;</td>
            <td class="style9">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <asp:LinkButton ID="Link_Travel" runat="server" CausesValidation="False" 
                    ForeColor="#B00000" Visible="False"> HISTORY</asp:LinkButton>
                <br />
&nbsp;&nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>




