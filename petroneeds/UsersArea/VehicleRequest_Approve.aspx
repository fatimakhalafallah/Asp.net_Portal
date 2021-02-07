<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UsersArea/MasterPage.master"  CodeFile="VehicleRequest_Approve.aspx.cs" Inherits="UsersArea_VehicleRequest_Approve" %>


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
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/VehicelRequest.PNG" 
                    ImageAlign="Left" Height="36px" Width="469px" />
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
                    onrowcreated="GridView1_RowCreated" DataKeyNames="REQ_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="REQ_NO" FooterText="Form No" HeaderText="Form No" 
                            />
                             <asp:BoundField DataField="EMPLOYEE_ID" FooterText="Employee No" 
                            HeaderText="Employee No" />
                            
                            <asp:BoundField DataField="POSITION" FooterText="Employee Position" HeaderText="Employee Position" 
                            />  
                            <asp:BoundField DataField="DEP_NAME" FooterText="Employee DEP" HeaderText="Employee DEP" 
                            /> 
                             <asp:BoundField DataField="REQ_DATE" FooterText="Date" HeaderText="Date" 
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
                                    CellPadding="3" CellSpacing="1" DataKeyNames="REQ_NO" DataMember="REQ_NO" 
                                    EnablePersistedSelection="True" ForeColor="#B00000" GridLines="None" 
                                    ShowFooter="True" ShowHeaderWhenEmpty="True" style="margin-top: 7px" 
                                    Width="595px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>

                     
      
                                         <asp:BoundField DataField="REQ_NO"
                                            HeaderText="Form No" />
                                        <asp:BoundField DataField="DESTINATION"  
                                            HeaderText="Destination" />
                                    
                                        <asp:BoundField DataField="PURPOSE"  
                                            HeaderText="Purpose"/> 
                                            <asp:BoundField DataField="DEPAR_DAY"  
                                            HeaderText="Departure Day"/> 
                                             <asp:BoundField DataField="DEPAR_TIME"  
                                            HeaderText="Departure Time"/>        
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
                                

                                <td class="style63" rowspan="1">
                                    <br />
                                    <br />
                                </td>
                                <td>
                                
                                
                                
                                
                                    <br />
                                    <br />
                                
                                
                                
                                
                                </td>
                            </tr>
                            <tr>
                            <td>
                            
                            
                            
                                <asp:Label ID="Super_l" runat="server" Text="Super Comment" Font-Size="12px" ForeColor="Maroon"  Visible="False" ></asp:Label>
                            
                                      
                            
                            </td>
                            <td>
                            <asp:TextBox ID="Super_c" runat="server" BorderColor="#B00000" 
                                        BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                        Width="346px" ReadOnly="True" Visible="False"></asp:TextBox>
                            
                                <br />
                            
                                <br />
                            
                            </td>
                                <caption>
                                </caption>
                            
                            </tr>
                           <tr>
                                <td class="style43">
                                    <asp:Label ID="Label3" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                        Text=" Comment"></asp:Label>
                                </td>

                                <td class="style17">
                                    <asp:TextBox ID="Text_COMMENT" runat="server" BorderColor="#B00000" 
                                        BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                        Width="346px"></asp:TextBox>
                                    <br />
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




