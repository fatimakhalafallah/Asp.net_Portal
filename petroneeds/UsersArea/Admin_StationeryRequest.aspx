<%@ Page Title="Stationery Request :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_StationeryRequest.aspx.cs" Inherits="UsersArea_Admin_StationeryRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style7
        {
            width: 528px;
        }
        .style9
        {
            width: 308px;
        }
        .style10
        {
            width: 201px;
        }
        .style11
        {
            width: 166px;
        }
        .style12
        {
        }
        .style32
        {
            width: 50%;
        }
        .style34
        {
            width: 80px;
        }
        .style37
        {
            width: 112px;
            height: 51px;
        }
        .style38
        {
            width: 40px;
        }
    .style39
    {
        height: 19px;
    }
        .style46
    {
        height: 25px;
        }
    .style47
    {
        width: 123px;
    }
    .style50
    {
        width: 21px;
    }
        .style51
        {
            width: 123px;
            height: 17px;
        }
        .style52
        {
            width: 21px;
            height: 17px;
        }
        .style53
        {
            height: 17px;
        }
        .style54
        {
            width: 123px;
            height: 25px;
        }
        .style55
        {
            width: 21px;
            height: 25px;
        }
        .style56
        {
            width: 123px;
            height: 51px;
        }
        .style57
        {
            width: 21px;
            height: 51px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/ne_8.gif" />
                </b>
            </td>
        </tr>
        <tr>
            <td class="style12">
            </td>
            <td class="style9">
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                <asp:GridView ID="GridView1" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" ForeColor="Maroon" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="ORDER_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1">
                    <Columns>
                        <asp:BoundField DataField="ORDER_NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="ORDER_NO" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_ID" FooterText="Employee No" 
                            HeaderText="Employee No" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Employee" 
                            HeaderText="Employee" SortExpression="EMPLOYEE_NAME" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ORDER_DATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="ORDER_DATE" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" SortExpression="DEP_NAME" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="13px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Verdana" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" BorderStyle="None" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label_Message" runat="server" Font-Size="Small" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:TextBox ID="TextBox1" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:TextBox ID="TextBox2" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="3" rowspan="2">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7" width="600px">
                        <tr>
                            <td class="style19" colspan="2">
                                Stationery Details:</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style47">
                                &nbsp;</td>
                            <td class="style50">
                                &nbsp;</td>
                            <td class="style28">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style46" colspan="3">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CellSpacing="1" DataKeyNames="ORDER_NO" DataMember="ORDER_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000" GridLines="None" 
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="595px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="ORDER_NO" FooterText="Order No" HeaderText="Order No" />
                                        <asp:BoundField DataField="ITEM_NO" FooterText="Item Name" 
                                            HeaderText="Item Name" />
                                        <asp:BoundField DataField="QTY_ORDERED" FooterText="QTY" HeaderText="QTY" />
                                        <asp:BoundField DataField="GROUP_NO" FooterText="Group No" 
                                            HeaderText="Group No" />
                                        <asp:BoundField DataField="DESCRIPTION" FooterText="Description" 
                                            HeaderText="Description" />
                                    </Columns>
                                    <FooterStyle BackColor="#B00000" Font-Bold="True" Font-Size="11px" 
                                        ForeColor="White" />
                                    <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Size="12px" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style47">
                                &nbsp;</td>
                            <td class="style50">
                                &nbsp;</td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                        <td>
                        
                        
                            <asp:Label ID="Label7" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                Text="MNG Comment" Visible="False"></asp:Label>
                        
                        
                        </td>
                        <td>
                        
                            <asp:TextBox ID="TextBox4" runat="server" BorderColor="#B00000" 
                                BorderStyle="Solid" BorderWidth="1px" Height="63px" TextMode="MultiLine" 
                                Visible="False" Width="346px" ReadOnly="True"></asp:TextBox>
                            <br />
                            <br />
                        
                        </td>
                        
                        
                        </tr>

                        <tr>
                        <td class="style72">
                           <asp:Label ID="Label6" runat="server" Text="Comment" Font-Size="12px" 
                                 ForeColor="Maroon"></asp:Label></td>
                        <td>
                         <asp:TextBox ID="TextBox3" runat="server" BorderColor="#B00000" 
                                   BorderStyle="Solid"  BorderWidth="1px" Width="346px" TextMode="MultiLine" 
                                       Visible="true" Height="63px"
                                 ></asp:TextBox>
                        
                        </td>
                        </tr>
                        <tr>
                            <td class="style56">
                                </td>
                            <td class="style57">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <asp:Label ID="Label_Message1" runat="server" Font-Size="Small" 
                                    ForeColor="#CC0000" ondatabinding="RadioButtonList1_SelectedIndexChanged" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="style37">
                                </td>
                        </tr>
                        <tr>
                            <td class="style47">
                                &nbsp;</td>
                            <td class="style50">
                                <table cellpadding="0" cellspacing="0" class="style32">
                                    <tr>
                                        <td class="style34">
                                            &nbsp;</td>
                                        <td class="style39">
                                            &nbsp;</td>
                                        <td class="style38">
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
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style54">
                            </td>
                            <td class="style55">
                            </td>
                            <td class="style46">
                            </td>
                        </tr>
                        <tr>
                            <td class="style51">
                                &nbsp;</td>
                            <td class="style52">
                                &nbsp;</td>
                            <td class="style53">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style29">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <div class="MenuBar">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
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



