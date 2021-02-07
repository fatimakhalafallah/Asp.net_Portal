<%@ Page Title="Recruitment :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Recruitment.aspx.cs" Inherits="UsersArea_Admin_Recruitment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style32
        {
            width: 50%;
        }
        .style33
        {
            height: 17px;
        }
        .style34
        {
            width: 29px;
        }
        .style36
        {
            width: 31px;
        }
        .style37
        {
            width: 37px;
        }
        .style38
        {
            width: 165px;
        }
        .style40
        {
            height: 18px;
        }
        .style41
        {
            width: 37px;
            height: 18px;
        }
        .style42
        {
            height: 21px;
        }
        .style44
        {
            height: 22px;
        }
        .style46
        {
            width: 197px;
        }
        .style48
        {
            width: 150px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
     <div class="MenuBar">
        <asp:Menu ID="menuBar" runat="server" BackColor="#B00000" BorderColor="White" 
            ForeColor="White" Height="25px" 
            Orientation="Horizontal" RenderingMode="Table" 
            StaticEnableDefaultPopOutImage="False" style="text-align: center" 
                                                
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
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
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
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_11.gif" />
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
                    onrowcreated="GridView1_RowCreated" DataKeyNames="RF_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1" 
                    PageSize="20">
                    <AlternatingRowStyle Font-Size="11px" />
                    <Columns>
                        <asp:BoundField DataField="RF_NO" FooterText="Form No" HeaderText="Form No" >
                          <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MNG_CREATER" FooterText="Emp Creater" 
                            HeaderText="Emp Creator" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SINGLE_JUSTIFICATION" FooterText="Justification" 
                            HeaderText="Justification" >
                            <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RF_TYPE" FooterText="Type" HeaderText="Type" >
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="POSITION_JUSTIFICATION" HeaderText="Position" 
                            FooterText="Position" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NO_OF_CANDIDATE" FooterText="Candidates No" 
                            HeaderText="Candidates No" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RF_DATE" FooterText="Date" HeaderText="Date" >  
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" >
                         <ControlStyle Font-Size="11px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="Small" />
                         </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="13px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20"/>
                    <PagerStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#B00000" 
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
                <asp:GridView ID="GridView3" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView3_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    onrowcreated="GridView3_RowCreated" DataKeyNames="RF_NO" 
                    onselectedindexchanged="GridView3_SelectedIndexChanged" PageIndex="1" 
                    PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="RF_NO" FooterText="Form No" HeaderText="Form No" >
                          <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MNG_CREATER" FooterText="Emp Creater" 
                            HeaderText="Emp Creator" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" >  <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SINGLE_JUSTIFICATION" FooterText="Justification" 
                            HeaderText="Justification" >
                            <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RF_TYPE" FooterText="Type" HeaderText="Type" >
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="POSITION_JUSTIFICATION" HeaderText="Position" 
                            FooterText="Position" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NO_OF_CANDIDATE" FooterText="Candidates No" 
                            HeaderText="Candidates No" >
                              <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RF_DATE" FooterText="Date" HeaderText="Date" >  
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" >
                        <ControlStyle Font-Size="11px" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="13px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#B00000" 
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
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
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
            <td class="style48">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7">
                        <tr>
                            <td class="style33" colspan="2">
                                Recruitment Details:</td>
                            <td class="style33">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="2" CellSpacing="1" DataKeyNames="SERIAL_NO" DataMember="SERIAL_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000" GridLines="None" 
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="600px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="SERIAL_NO" FooterText="No" HeaderText="No">
                                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                                        <asp:BoundField DataField="CAND_NAME" FooterText="Cand Name" 
                                            HeaderText="Cand Name" >
                                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                                        <asp:BoundField DataField="EXP_YEAR" FooterText="Experience" 
                                            HeaderText="Experience" >
                                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                                        <asp:BoundField DataField="ADD_CREDIT" FooterText="Candidates" 
                                            HeaderText="Candidates" >
                                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                                        <asp:BoundField DataField="REMARKS" FooterText="Remarks" HeaderText="Remarks" >
                                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#B00000" Font-Bold="True" ForeColor="White" Font-Size="12px"/>
                                    <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Size="12px" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
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
                            <td class="style44" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <table cellpadding="0" cellspacing="0" class="style6">
                                    <tr>
                                        <td class="style46">
                                            &nbsp;</td>
                                        <td colspan="3">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                                Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                                Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                                RepeatDirection="Horizontal" Width="194px">
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style46">
                                            &nbsp;</td>
                                        <td colspan="3">
                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                                Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                                Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                                RepeatDirection="Horizontal" Width="194px">
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style46">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" class="style32">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td class="style36">
                                                        &nbsp;</td>
                                                    <td class="style42">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td class="style36">
                                                        &nbsp;</td>
                                                    <td class="style42">
                                                        <asp:Button ID="Butt_Submit0" runat="server" Font-Names="Verdana" 
                                                            Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" />
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
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style41">
                                &nbsp;</td>
                            <td class="style37">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style41">
                                &nbsp;</td>
                            <td class="style37">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                            </td>
                            <td class="style34">
                            </td>
                            <td>
                            </td>
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




