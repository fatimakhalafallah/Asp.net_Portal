<%@ Page Title="Function Request :: Approval Area" Language="C#" MasterPageFile="~/UsersArea/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_FunctionRequest.aspx.cs" Inherits="UsersArea_Admin_FunctionRequest" %>

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
            width: 42%;
        }
        .style33
        {
            width: 16px;
        }
        .style34
        {
            width: 76px;
        }
        .style35
        {
            width: 57px;
        }
        .style36
        {
            width: 48px;
        }
        .style37
        {
            width: 8px;
        }
        .style38
        {
        }
        .style39
        {
            width: 123px;
            height: 25px;
        }
        .style40
        {
            height: 18px;
        }
        .style41
        {
            width: 8px;
            height: 25px;
        }
        .style42
        {
            height: 25px;
        }
         .style43
        {
           text-align:center;
        }
        .style44
        {
            height: 17px;
        }
        </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_8.gif" />
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
                    onrowcreated="GridView1_RowCreated" DataKeyNames="REQUEST_NO" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" PageIndex="1">
                    <Columns>
                        <asp:BoundField DataField="REQUEST_NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="REQUEST_NO">
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_USER" FooterText="User No" 
                            HeaderText="User No">
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RQUESTDATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="RQUESTDATE" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" SortExpression="DEP_NAME" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Name" HeaderText="Name" 
                            SortExpression="EMPLOYEE_NAME" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="12px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="12px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Verdana" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" BorderStyle="None" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11" colspan="3">
                <asp:GridView ID="GridView2" runat="server" Width="600px" AllowPaging="True" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView2_PageIndexChanging" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" 
                    onrowcreated="GridView2_RowCreated" DataKeyNames="REQUEST_NO" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageIndex="1">
                    <Columns>
                        <asp:BoundField DataField="REQUEST_NO" FooterText="Form No" HeaderText="Form No" 
                            SortExpression="REQUEST_NO">
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_USER" FooterText="User No" 
                            HeaderText="User No">
                        <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RQUESTDATE" FooterText="Date" HeaderText="Date" 
                            SortExpression="RQUESTDATE" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" 
                            HeaderText="Department" SortExpression="DEP_NAME" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Name" HeaderText="Name" 
                            SortExpression="EMPLOYEE_NAME" >
                            <ControlStyle Font-Size="12px" />
                        <FooterStyle Font-Size="12px" />
                        <HeaderStyle Font-Size="12px" />
                        <ItemStyle Font-Size="11px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Show Details ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="12px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="12px" 
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
                <asp:TextBox ID="TextBox3" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12" colspan="3" rowspan="2">
                <asp:Panel ID="Panel1" runat="server" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="style7" width="600px">
                        <tr>
                            <td class="style19" colspan="2">
                                Function Request Details:</td>
                            <td class="style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="style28">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label26" runat="server" Text="Request Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_ReqNum" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                            </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label27" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Request Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_ReqDate" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                            </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label28" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Start Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_startDate" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label29" runat="server" Text="End Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_EndDate" runat="server" BorderColor="#B00000" 
                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label30" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Department"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                               </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label31" runat="server" Font-Size="12px" ForeColor="Maroon">Name</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_Emp_Name" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style33">
                            </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label32" runat="server" Font-Size="12px" ForeColor="Maroon">Time (From)</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_From" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label34" runat="server" Font-Size="12px" ForeColor="Maroon">Time (End)</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_To" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label35" runat="server" Font-Size="12px" ForeColor="Maroon">Location</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_Location" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label36" runat="server" Font-Size="12px" ForeColor="Maroon">Purpose</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_PURPOSE" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label37" runat="server" Font-Size="12px" ForeColor="Maroon">Arrangment</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_ARRANGMENTS" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label38" runat="server" Font-Size="12px" ForeColor="Maroon">Send Date</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_SendDate" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label39" runat="server" Font-Size="12px" ForeColor="Maroon">Created Date</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_Created_Date" runat="server" BorderColor="#B00000" 
                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style40">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label33" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Comment"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Text_Comments" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                    Width="346px"></asp:TextBox>
                            </td>
                            <td class="style18">
                            </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="style18">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td class="style43">
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
                            <td class="style39">
                                </td>
                            <td class="style42">
                            </td>
                            <td class="style41">
                                </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                &nbsp;</td>
                            <td>
                                <table cellpadding="0" cellspacing="0" class="style32">
                                    <tr>
                                        <td class="style34">
                                            &nbsp;</td>
                                        <td class="style36">
                                            &nbsp;</td>
                                        <td class="style35">
                                            <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" 
                                                Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" />
                                        </td>
                                        <td>
                                            </td>
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
                            <td class="style44">
                            </td>
                            <td class="style44">
                            </td>
                            <td class="style44">
                            </td>
                        </tr>
                        <tr>
                            <td class="style38" colspan="3">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Width="600px">
                                    <table cellpadding="0" cellspacing="0" class="style7" width="600px">
                                        <tr>
                                            <td class="style19" colspan="2">
                                                Function Request Details:</td>
                                            <td class="style8">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td class="style28">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label40" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="Request Number"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_ReqNum0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label41" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="Request Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_ReqDate0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label42" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="Start Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_startDate0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" MaxLength="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label43" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_EndDate0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label44" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="Department"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_Department0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label45" runat="server" Font-Size="12px" ForeColor="Maroon">Name</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_Emp_Name0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style33">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label46" runat="server" Font-Size="12px" ForeColor="Maroon">Time (From)</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_From0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label47" runat="server" Font-Size="12px" ForeColor="Maroon">Time (End)</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_To0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label48" runat="server" Font-Size="12px" ForeColor="Maroon">Location</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_Location0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label49" runat="server" Font-Size="12px" ForeColor="Maroon">Purpose</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_PURPOSE0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label50" runat="server" Font-Size="12px" ForeColor="Maroon">Arrangment</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_ARRANGMENTS0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label51" runat="server" Font-Size="12px" ForeColor="Maroon">Send Date</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_SendDate0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label52" runat="server" Font-Size="12px" ForeColor="Maroon">Created Date</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_Created_Date0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="None" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="style40">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                <asp:Label ID="Label53" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                                    Text="Comment"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Text_Comments0" runat="server" BorderColor="#B00000" 
                                                    BorderStyle="Inset" BorderWidth="1px" Height="67px" TextMode="MultiLine" 
                                                    Width="346px"></asp:TextBox>
                                            </td>
                                            <td class="style18">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td class="style18">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="style43">
                                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                                    Font-Names="Tahoma" Font-Overline="False" Font-Size="13px" 
                                                    Font-Strikeout="False" Font-Underline="False" Height="25px" 
                                                    onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                                                    RepeatDirection="Horizontal" Width="194px">
                                                </asp:RadioButtonList>
                                                <asp:Label ID="Label_Message2" runat="server" Font-Size="Small" 
                                                    ForeColor="#CC0000" ondatabinding="RadioButtonList1_SelectedIndexChanged" 
                                                    Visible="False"></asp:Label>
                                            </td>
                                            <td class="style37">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style39">
                                            </td>
                                            <td class="style42">
                                            </td>
                                            <td class="style41">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style38">
                                                &nbsp;</td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" class="style32">
                                                    <tr>
                                                        <td class="style34">
                                                            &nbsp;</td>
                                                        <td class="style36">
                                                            &nbsp;</td>
                                                        <td class="style35">
                                                            <asp:Button ID="Butt_Submit0" runat="server" Font-Names="Verdana" 
                                                                Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="65px" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Butt_Reset0" runat="server" CausesValidation="False" 
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



