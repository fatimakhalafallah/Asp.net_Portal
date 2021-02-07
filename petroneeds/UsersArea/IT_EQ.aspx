<%@ Page Title="" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="IT_EQ.aspx.cs" Inherits="UsersArea_IT_EQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            height: 17px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3" class="style40">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/IT_ICT.PNG" />
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
                    onrowcreated="GridView1_RowCreated" DataKeyNames="FORM_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="FORM_NO" FooterText="Form No" HeaderText="Form No" 
                            />
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Employee No" 
                            HeaderText="Employee No" />
                             <asp:BoundField DataField="REQUESTER_NAME" FooterText="Employee Name" HeaderText="Employee Name" 
                            />
                        <asp:BoundField DataField="FORM_DATE" FooterText="Date" HeaderText="Date" 
                            />   
                            
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
                <asp:TextBox ID="TextBox1" runat="server" Visible="false" AutoPostBack="True"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Visible="false" AutoPostBack="True"></asp:TextBox>
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
                                Request Details:</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style46" colspan="3">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CellSpacing="1" DataKeyNames="FORM_NO" DataMember="REQ_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000"  
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="595px" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        
                                         <asp:BoundField DataField="FORM_NO" FooterText="FORM_NO" 
                                            HeaderText="FORM_NO" />
                                        <asp:BoundField DataField="EQ_NAME" FooterText="Item Name" 
                                            HeaderText="Item Name" />
                                        <asp:BoundField DataField="QUANTITY" FooterText="QUNTITY" HeaderText="QUNTITY" />
                                        <asp:BoundField DataField="DESCRIPTION" FooterText="Description" 
                                            HeaderText="Description" />
                                            

                                    </Columns>
                                    <FooterStyle BackColor="#B00000" Font-Bold="True" Font-Size="11px" 
                                        ForeColor="#808080" />
                                    <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Size="12px" ForeColor="#808080" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFE1E6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFFAFB" Font-Bold="True" ForeColor="Navy" />
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
                            <td class="style13">
                                </td>
                            <td class="style13">
                                    
                                </td>
                                </tr> 

                            

                            </tr>
                           <tr>
                                <td class="style63" rowspan="1">
                                    <br />
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td class="style43">
                                        <asp:Label ID="Label3" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                            Text="ICT MNG COMMENT"></asp:Label>
                                    </td>
                                    <td class="style17">
                                        <asp:TextBox ID="TextBox5" runat="server" BorderColor="#B00000" 
                                            BorderStyle="Inset" BorderWidth="1px" Height="67px" ReadOnly="True" 
                                            TextMode="MultiLine" Width="346px"></asp:TextBox>
                                    </td>
                                    <td class="style18">
                                    </td>
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
                                    <td class="style44">
                                        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td class="style36">
                                        &nbsp;
                                        <br />
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
                                                    &nbsp;&nbsp;</td>
                                                <td class="style38">
                                                    <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                        Font-Size="9pt" onclick="Butt_Submit_Click" Text="Complete" Width="105px" 
                                                        style="margin-left: 0px" Height="25px" />
                                                    &nbsp;&nbsp;&nbsp;</td>
                                                <td>
                                                     &nbsp;<asp:Button ID="Button1" runat="server" Text="EXPORT TO PDF" 
                                                         onclick="Button1_Click" Font-Size="9pt" Height="25px" Width="105px" />
                                                     &nbsp;&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                        Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                        Height="25px" Width="105px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="style8">
                                        &nbsp;</td>
                                </tr>
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



