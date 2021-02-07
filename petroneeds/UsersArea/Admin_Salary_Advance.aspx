<%@ Page Title="Salary Advance :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Salary_Advance.aspx.cs" Inherits="UsersArea_Admin_Salary_Advance" %>

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
            width: 100%;
        }
        .style33
        {
            height: 17px;
        }
        .style34
        {
            width: 286px;
        }
        .style36
        {
            width: 115px;
        }
        .style37
        {
            width: 112px;
        }
        .style38
        {
            width: 40px;
        }
    .style39
    {
        height: 19px;
    }
    .style40
    {
        height: 25px;
    }
        .style43
        {
            height: 17px;
            width: 123px;
        }
        .style46
    {
        height: 25px;
        width: 123px;
    }
    .style47
    {
        width: 123px;
    }
    .style48
    {
        height: 25px;
        width: 21px;
    }
    .style49
    {
        height: 17px;
        width: 21px;
    }
    .style50
    {
        width: 21px;
    }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_10.gif" />
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
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="ADV_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1">
                    <Columns>
                        <asp:BoundField DataField="ADV_NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="ADV_NO" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Employee No" 
                            HeaderText="Employee No" SortExpression="EMPLOYEE_NO" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="13px" />
                        <HeaderStyle Font-Size="13px" />
                        <ItemStyle Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SAL_DATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="SAL_DATE" >
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
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
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
                                Salary Advance Details:</td>
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
                            <td class="style46">
                                <asp:Label ID="Label26" runat="server" Text="Request Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_ReqNum" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True" Width="66px"></asp:TextBox>
                            </td>
                            <td class="style40">
                            </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                <asp:Label ID="Label27" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Employee Number"></asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True" Width="66px"></asp:TextBox>
                            </td>
                            <td class="style40">
                            </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                <asp:Label ID="Label28" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Employee Name"></asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True" 
                                    Width="320px"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                <asp:Label ID="Label29" runat="server" Text="Request Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_Request" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                <asp:Label ID="Label30" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Salary Date"></asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_Request_Date" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True" Width="140px"></asp:TextBox>
                            </td>
                            <td class="style40">
                               </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                <asp:Label ID="Label31" runat="server" Font-Size="12px" ForeColor="Maroon">Remark</asp:Label>
                            </td>
                            <td class="style49">
                                <asp:TextBox ID="Text_Remarks" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" Height="97px" ReadOnly="True" 
                                    TextMode="MultiLine" Width="336px"></asp:TextBox>
                            </td>
                            <td class="style33">
                            </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                <asp:Label ID="Label32" runat="server" Font-Size="12px" ForeColor="Maroon">AMT</asp:Label>
                            </td>
                            <td class="style48">
                                <asp:TextBox ID="Text_AMT" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True" Width="340px"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style47">
                                <asp:Label ID="Label33" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_Comments" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                            <td class="style47">
                                </td>
                            <td class="style50">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
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



