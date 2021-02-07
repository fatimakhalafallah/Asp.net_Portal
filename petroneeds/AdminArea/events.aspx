<%@ Page Title="Petroneeds Services International :: News & Events" Language="C#" MasterPageFile="~/AdminArea/MasterPage.master"AutoEventWireup="true" CodeFile="events.aspx.cs" Inherits="AdminArea_events" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style74
        {
            width: 655px;
        }

        .style70
        {
            width: 663px;
            height: 22px;
        }
        .style75
        {
            width: 179px;
        }
        .style76
        {
            width: 145px;
        }
        .style77
        {
            width: 159px;
        }
        .style78
        {
            width: 600px;
        }
        .style79
        {
            width: 171px;
        }
        .style80
        {
            width: 86px;
        }
        .style81
        {
            width: 80px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style74">
        <tr>
            <td>
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_7.gif" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="style78">
                    <tr>
                        <td class="style79">
                            &nbsp;</td>
                        <td class="style81">
                            <asp:LinkButton ID="LinkButton6" runat="server" Font-Size="15px" 
                                ForeColor="#993333" onclick="LinkButton6_Click" CausesValidation="False">New</asp:LinkButton>
                        </td>
                        <td class="style80">
                            <asp:LinkButton ID="LinkButton7" runat="server" Font-Size="15px" 
                                ForeColor="#993333" onclick="LinkButton7_Click" CausesValidation="False">Edit</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21" colspan="2">
                                &nbsp;</td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                &nbsp;</td>
                            <td class="style50">
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </asp:ToolkitScriptManager>
                            </td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                &nbsp;</td>
                            <td class="style50">
                                <asp:FileUpload ID="FileUploader" runat="server" Font-Names="Tahoma" 
                                        Width="529px" />
                                <asp:Button ID="UploadButton" runat="server" CausesValidation="False" 
                                        Height="20px" onclick="UploadButton_Click" 
                     Text="Upload" Width="70px" />
                            </td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                &nbsp;</td>
                            <td class="style50">
                                <asp:Label ID="Label8" runat="server" Font-Names="Tahoma" ForeColor="#C00000" 
                                        Width="210px"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" 
                    ForeColor="#C00000" Visible="False" Width="208px"></asp:Label>
                            </td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                <asp:Label ID="Label22" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px"></asp:TextBox>
                                <asp:CalendarExtender ID="Text_Date_CalendarExtender" runat="server" 
                    TargetControlID="Text_Date" ClearTime="false" Format="dd-MMMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td class="style72">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="Text_Date" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                <asp:Label ID="Label19" runat="server" Text="Title" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_Title" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="33px" 
                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="style72">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Title" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                <asp:Label ID="Label21" runat="server" Text="Details" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style50">
                                <asp:TextBox ID="Text_Details" runat="server"  
                    BorderStyle="Solid" Width="500px" BorderWidth="1px" Height="107px" 
                                TextMode="MultiLine" BorderColor="#B00000"></asp:TextBox>
                            </td>
                            <td class="style72">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Details" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style26">
                                &nbsp;</td>
                            <td class="style21">
                                &nbsp;</td>
                            <td class="style50">
                                &nbsp;</td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style23">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style27">
                                &nbsp;</td>
                            <td class="style22" colspan="3">
                                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style24">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style27">
                                &nbsp;</td>
                            <td class="style22" colspan="3">
                                <table cellpadding="0" cellspacing="0" class="style70">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style92">
                                            &nbsp;</td>
                                        <td>
                                        </td>
                                        <td class="style76">
                                            <asp:Button ID="Butt_Close0" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Close_Click" Text="Close" 
                                                Width="65px" />
                                        </td>
                                        <td class="style77">
                                            &nbsp;</td>
                                        <td class="style75">
                                            &nbsp;</td>
                                        <td class="style71">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" style="margin-left: 0px" 
                                                Text="Submit" Width="65px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Butt_Reset" runat="server" CausesValidation="False" 
                                                Font-Names="Verdana" Font-Size="9pt" 
                                onclick="Butt_Reset_Click" Text="Reset" 
                                                Width="65px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="style24">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server">
                    <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" 
                        AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                        Width="684px" PageSize="5" ShowFooter="True" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="id" HeaderText="No" InsertVisible="False" 
            ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="NewTitle" HeaderText="Title" 
            SortExpression="NewTitle" />
                            <asp:BoundField DataField="NewsDetail" HeaderText="Details" 
            SortExpression="NewsDetail" />
                            <asp:BoundField DataField="DateCreated" HeaderText="Date" 
            SortExpression="DateCreated" />
                            <asp:BoundField DataField="status" HeaderText="Status" 
                                SortExpression="status" />
                        </Columns>
                        <FooterStyle BackColor="#B00000" ForeColor="Black" />
                        <HeaderStyle BackColor="#B00000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:Button ID="Butt_Close" runat="server" CausesValidation="False" 
                        Font-Names="Verdana" Font-Size="9pt" onclick="Butt_Close_Click" Text="Close" 
                        Width="65px" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConflictDetection="CompareAllValues" 
    ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
    DeleteCommand="DELETE FROM [tbl_News] WHERE [id] = @original_id AND (([NewTitle] = @original_NewTitle) OR ([NewTitle] IS NULL AND @original_NewTitle IS NULL)) AND (([NewsDetail] = @original_NewsDetail) OR ([NewsDetail] IS NULL AND @original_NewsDetail IS NULL)) AND (([DateCreated] = @original_DateCreated) OR ([DateCreated] IS NULL AND @original_DateCreated IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL))" 
    InsertCommand="INSERT INTO [tbl_News] ([NewTitle], [NewsDetail], [DateCreated], [status]) VALUES (@NewTitle, @NewsDetail, @DateCreated, @status)" 
    OldValuesParameterFormatString="original_{0}" 
    SelectCommand="SELECT [id], [NewTitle], [NewsDetail], [DateCreated], [status] FROM [tbl_News]" 
    
                        
                        UpdateCommand="UPDATE [tbl_News] SET [NewTitle] = @NewTitle, [NewsDetail] = @NewsDetail, [DateCreated] = @DateCreated, [status] = @status WHERE [id] = @original_id AND (([NewTitle] = @original_NewTitle) OR ([NewTitle] IS NULL AND @original_NewTitle IS NULL)) AND (([NewsDetail] = @original_NewsDetail) OR ([NewsDetail] IS NULL AND @original_NewsDetail IS NULL)) AND (([DateCreated] = @original_DateCreated) OR ([DateCreated] IS NULL AND @original_DateCreated IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_id" Type="Int64" />
                            <asp:Parameter Name="original_NewTitle" Type="String" />
                            <asp:Parameter Name="original_NewsDetail" Type="String" />
                            <asp:Parameter Name="original_DateCreated" Type="DateTime" />
                            <asp:Parameter Name="original_status" Type="Int64" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="NewTitle" Type="String" />
                            <asp:Parameter Name="NewsDetail" Type="String" />
                            <asp:Parameter Name="DateCreated" Type="DateTime" />
                            <asp:Parameter Name="status" Type="Int64" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="NewTitle" Type="String" />
                            <asp:Parameter Name="NewsDetail" Type="String" />
                            <asp:Parameter Name="DateCreated" Type="DateTime" />
                            <asp:Parameter Name="status" Type="Int64" />
                            <asp:Parameter Name="original_id" Type="Int64" />
                            <asp:Parameter Name="original_NewTitle" Type="String" />
                            <asp:Parameter Name="original_NewsDetail" Type="String" />
                            <asp:Parameter Name="original_DateCreated" Type="DateTime" />
                            <asp:Parameter Name="original_status" Type="Int64" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>



