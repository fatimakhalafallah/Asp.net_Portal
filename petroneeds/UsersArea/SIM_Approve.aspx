<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SIM_Approve.aspx.cs" MasterPageFile="~/UsersArea/MasterPage.master"  Inherits="UsersArea_SIM_Approve" %>


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
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/SIM@.PNG"  Height="36px" />
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
                    CellSpacing="1" EmptyDataText="No data was returned" ForeColor="Maroon" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView1_RowCreated" DataKeyNames="FORM_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="FORM_NO" FooterText="Form No" HeaderText="Form No" 
                            />
                             <asp:BoundField DataField="USER_ID" FooterText="Employee No" 
                            HeaderText="Employee No" />
                             <asp:BoundField DataField="FORM_DATE" FooterText="Date" HeaderText="Date" 
                            />
                            <asp:BoundField DataField="POSITION" FooterText="Employee Position" HeaderText="Employee Position" 
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
                                Request Details:<br />
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CellSpacing="1" DataKeyNames="FORM_NO" DataMember="FORM_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000" GridLines="None" 
                                    ShowFooter="true" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="595px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="FORM_NO" FooterText="" HeaderText="Form No" />
                                        <asp:BoundField DataField="USER_NAME" HeaderText="Requester" />
                                        <asp:BoundField DataField="USER_DEP" 
                                            HeaderText="Requester DEP" />
                                             <asp:BoundField DataField="NEW_USER"
                                            HeaderText="New User" />
                                        <asp:BoundField DataField="SIM_TYPE" FooterText="" 
                                            HeaderText="SIM Services" />
                                        <asp:BoundField DataField="SIM_CEIL" FooterText="" 
                                            HeaderText="SIM Ceil" />
                                    </Columns>
                                    <FooterStyle BackColor="#B00000" Font-Bold="True" Font-Size="11px" 
                                        ForeColor="White" />
                                    <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Size="12px" ForeColor="White" />
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
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style46" colspan="3">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CellSpacing="1" DataKeyNames="FORM_NO" DataMember="FORM_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000" GridLines="None" 
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="595px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                         <asp:BoundField DataField="FORM_NO"
                                            HeaderText="Form No" />
                                        <asp:BoundField DataField="USER_NAME"  
                                            HeaderText="User Name" />
                                        <asp:BoundField DataField="USER_DEP" HeaderText="User DEP" />
                                        <asp:BoundField DataField="USER_SIM_NU"  
                                            HeaderText="SIM Number"/>
                                        <asp:BoundField DataField="SIM_TYPE"  
                                            HeaderText="SIM Services"/>
                                            <asp:BoundField DataField="SIM_CEIL"  
                                            HeaderText="SIM Ceil"/>
                                            
                                    </Columns>
                                    <FooterStyle BackColor="#B00000" Font-Bold="True" Font-Size="11px" 
                                        ForeColor="White" />
                                    <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
                                        Font-Bold="True" Font-Size="12px" ForeColor="White" />
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

                            <tr>
                                <td class="style72">
                                <asp:Label ID="Label6" runat="server" Text="MNG Comment" Font-Size="12px" 
                                 ForeColor="Maroon" Visible="False"></asp:Label>
                                 </td>

                                <td class="style63" rowspan="1">
                                <asp:TextBox ID="TextBox3" runat="server" BorderColor="#B00000" 
                                   BorderStyle="Solid"  BorderWidth="1px" Width="346px" TextMode="MultiLine" 
                                        ReadOnly="True" Visible="False" Height="63px"
                                 ></asp:TextBox>
                                    <br />
                                    <br />
                                </td>
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
                                        Text="Comment"></asp:Label>
                                </td>

                                <td class="style17">
                                    <asp:TextBox ID="TextBox5" runat="server" BorderColor="#B00000" 
                                        BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                        Width="346px"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="Validator_Cnew" runat="server" 
                                ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="#CC0000" 
                                 SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                        Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                        Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                        RepeatDirection="Horizontal" Width="194px">
                                    </asp:RadioButtonList>
                                    &nbsp;
                                    <br />
                                </td>
                                <td class="style37">
                                </td>
                            </tr>
                            <tr>
                            
                            <td>
                             <asp:Label ID="Label2" runat="server" Text="Assgin To" Font-Size="12px" 
                                 ForeColor="Maroon" Visible="False"></asp:Label>

                            </td>
                            <td> 
     
                             <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="true" 
                                    Visible="False" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
                                </asp:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1"
                                ErrorMessage="Please Select!"  ForeColor="Maroon" InitialValue="0" 
                                    Visible="False"></asp:RequiredFieldValidator>
                                &nbsp;</td>
                            
                            </tr>
                            <tr>
                            
                                <td class="style42">
                                    &nbsp;</td>

                                <tr>
                                    <td class="style42">
                                        &nbsp;</td>
                                    <td class="style24">
                                        <table cellpadding="0" cellspacing="0" class="style32">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                <td class="style39">
                                                    &nbsp;</td>
                                                <td class="style38">
                                                    <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                        Font-Size="9pt" onclick="Butt_Submit_Click" style="height: 22px" Text="Submit" 
                                                        Width="65px" />
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                        Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Reset_Click" Text="Reset" 
                                                        Width="65px" />
                                                </td>
                                                <td>
                                                    &nbsp; </td>
                                                     <td>
                                                    &nbsp; </td>
                                                <td>
                                                    
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



