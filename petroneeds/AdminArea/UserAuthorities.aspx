<%@ Page Title="Petroneeds Services International :: Authorities" Language="C#" MasterPageFile="~/AdminArea/MasterPage.master" AutoEventWireup="true" CodeFile="UserAuthorities.aspx.cs" Inherits="AdminArea_UserAuthorities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style7
    {
        width: 674px;
    }
    .style9
    {
        width: 230px;
    }
    .style10
    {
        height: 17px;
    }
    .style11
    {
        width: 230px;
        height: 17px;
    }
    .style12
    {
        height: 17px;
    }
    .style13
    {
            width: 103px;
            height: 17px;
        }
    .style14
    {
        width: 103px;
    }
        .style21
        {
            width: 103px;
            height: 25px;
        }
        .style22
        {
            width: 230px;
            height: 25px;
        }
        .style23
        {
            height: 25px;
        }
        .style25
        {
            width: 103px;
            height: 20px;
        }
        .style26
        {
            width: 230px;
            height: 20px;
        }
        .style27
        {
            height: 20px;
        }
        .style34
        {
            width: 100%;
        }
        .style35
        {
            width: 104px;
        }
        .style28
        {
            width: 400px;
        }
        .style37
        {
            width: 30px;
        }
        .style38
        {
            width: 90px;
        }
        .style39
        {
            height: 17px;
        }
        .style40
        {
            width: 100px;
        }
        .style41
        {
            width: 100px;
            height: 20px;
        }
        .style42
        {
            width: 100px;
            height: 25px;
        }
        .style44
        {
            width: 87px;
        }
        .style45
        {
            width: 104px;
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0">
    <tr>
        <td class="style10" colspan="3">
            <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_9.gif" />
        </td>
        <td class="style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style39">
            &nbsp;</td>
        <td class="style13">
                &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10" colspan="3">
            <table class="style28">
                <tr>
                    <td class="style38">
                        <asp:LinkButton ID="Link_New" runat="server" ForeColor="#C03434" 
                            onclick="Link_New_Click">New User</asp:LinkButton>
                    </td>
                    <td class="style37">
                        &nbsp;</td>
                    <td class="style38">
                        <asp:LinkButton ID="Link_Update" runat="server" ForeColor="#C03434" 
                            onclick="Link_Update_Click">Update User</asp:LinkButton>
                    </td>
                    <td class="style37">
                        &nbsp;</td>
                    <td class="style38">
                        <asp:LinkButton ID="Link_Delete" runat="server" ForeColor="#C03434" 
                            onclick="Link_Edit_Click">Delete User</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="style10">
            </td>
    </tr>
    <tr>
        <td class="style39">
            &nbsp;</td>
        <td class="style13">
                &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style39">
            &nbsp;</td>
        <td class="style13">
                &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style39" colspan="4">
            <asp:Panel ID="Panel3" runat="server">
                <table cellpadding="0" cellspacing="0" class="style34">
                    <tr>
                        <td class="style44">
                            <asp:Label ID="Label16" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                Text="User Name"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <span style="font-family: Tierra Blanca">
                            <asp:Button ID="Butt_Search" runat="server" Font-Names="Corbel" 
                                OnClick="Butt_Search_Click" Text="Search" Width="50px" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="style44">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style10" colspan="4">
            <asp:Panel ID="Panel1" runat="server">
                <table cellpadding="0" cellspacing="0" class="style34">
                    <tr>
                        <td class="style35">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style35">
                            <asp:Label ID="Label17" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                Text="Screens Name"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style45">
                        </td>
                        <td class="style10">
                            <span style="font-family: Tierra Blanca">
                            <asp:Label ID="Label_Messages" runat="server" Font-Names="Tahoma" 
                                Font-Size="Small" ForeColor="DarkRed" Height="16px" Width="350px"></asp:Label>
                            </span>
                        </td>
                        <td class="style10">
                        </td>
                    </tr>
                    <tr>
                        <td class="style45">
                        </td>
                        <td class="style10">
                        </td>
                        <td class="style10">
                        </td>
                    </tr>
                    <tr>
                        <td class="style35">
                            &nbsp;</td>
                        <td>
                            <span style="font-family: Tierra Blanca">
                            <table ID="TABLE1" border="0" cellpadding="0" cellspacing="0" 
                                style="width: 164px">
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style15">
                                        <asp:Button ID="Butt_Save" runat="server" Font-Names="Corbel" 
                                            OnClick="Butt_Save_Click" Text="Save" Width="50px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <span style="font-family: Tierra Blanca">
                                        <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                            Font-Names="Corbel" OnClick="Butt_Reset_Click" Text="Reset" Width="50px" />
                                        </span>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </span>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style10" colspan="4">
            <asp:Panel ID="Panel2" runat="server">
                <table cellpadding="0" cellspacing="0" class="style34">
                    <tr>
                        <td class="style35">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style35">
                            <asp:Label ID="Label18" runat="server" Text="Screens Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style45">
                        </td>
                        <td class="style10">
                            <span style="font-family: Tierra Blanca">
                            <asp:Label ID="Label_Messages0" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                    ForeColor="DarkRed" Width="350px" Height="16px"></asp:Label>
                            </span>
                        </td>
                        <td class="style10">
                        </td>
                    </tr>
                    <tr>
                        <td class="style45">
                        </td>
                        <td class="style10">
                        </td>
                        <td class="style10">
                        </td>
                    </tr>
                    <tr>
                        <td class="style35">
                            &nbsp;</td>
                        <td>
                            <span style="font-family: Tierra Blanca">
                            <table id="TABLE2" border="0" cellpadding="0" cellspacing="0" 
                    style="width: 164px">
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style15">
                                        <asp:Button ID="Butt_Update" runat="server" Font-Names="Corbel" 
                                OnClick="Butt_Update_Click" Text="Update" Width="50px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <span style="font-family: Tierra Blanca">
                                        <asp:Button ID="Butt_Reset2" runat="server" CausesValidation="False" 
                                Font-Names="Corbel" OnClick="Butt_Reset2_Click" Text="Reset" Width="50px" />
                                        </span>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </span>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style10" colspan="4">
            <asp:Panel ID="Panel4" runat="server">
                <asp:GridView ID="GridView1" runat="server" Width="500px" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" 
                GridLines="Horizontal" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" DataKeyNames="number" PageIndex="1" 
                    PageSize="20" onrowdeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="number" FooterText="Menu No" 
                            HeaderText="Menu No" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MenuID" FooterText="Menu Code" 
                            HeaderText="Menu Code">
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MenuName" FooterText="Name" 
                            HeaderText="Name" >
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" ></asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="12px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="12px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style39">
        </td>
        <td class="style13">
                &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style12">
        </td>
    </tr>
    </table>
</asp:Content>


