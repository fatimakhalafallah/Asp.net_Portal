<%@ Page language="c#" Inherits="Default.EmpDetail" CodeFile="EmpDetail.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//AR" >
<HTML>
	<HEAD>
		<title>Petroneeds Services International :: Staff Zone</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	    <style type="text/css">

a:link {
	color: #FFFFFF;
	text-decoration: none;
}
a {
	font-family: Verdana;
	font-size: 13px;
}
        td {
	font-family: Verdana;
	font-size: 14px;
            text-align: left;
            margin-bottom: 15px;
        }
            #Form1
            {
                text-align: center;
            }
            .style1
            {
                width: 100%;
            }
            .style2
            {
                width: 582px;
            }
            .style3
            {
                width: 582px;
                height: 199px;
            }
            .style4
            {
                height: 199px;
            }
        </style>
	</HEAD>
	<body topmargin="0" style="font-size: 10px; font-family: Verdana; text-align: center;">
		<form id="Form1" method="post" runat="server">
			<table runat="server" id="tblDetail">
				</table>
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td class="style3">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" 
                CellPadding="4" CellSpacing="3" ForeColor="Black" GridLines="None">
                <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <FieldHeaderStyle BackColor="#B00000" ForeColor="White" />
                <Fields>
                    <asp:BoundField DataField="EMPLOYEE_NO" HeaderText="Employee No" />
                    <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Name" />
                    <asp:BoundField DataField="DEP_NAME" HeaderText="Department" />
                    <asp:BoundField DataField="PROJ_NAME" HeaderText="Section" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="Job Name" />
                    <asp:BoundField DataField="DATE_OF_JOIN" HeaderText="Join Date" />
                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail" />
                </Fields>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            </asp:DetailsView>
		    
		                </td>
                        <td class="style4">
		    
		    <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                style="text-align: left" Width="80px" ImageAlign="Top" />
		    
		                </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" BackColor="#B00000" ForeColor="White" 
                                Height="25px" Text="Comment" Width="100px"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Font-Names="Verdana"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
            </table>
                <asp:GridView ID="GridView1" runat="server" Width="725px" 
                    BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" 
                GridLines="Horizontal" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" 
                    ShowHeaderWhenEmpty="True" DataKeyNames="EMPLOYEE_NO" PageIndex="1">
                    <Columns>
                        <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Emp No" HeaderText="Emp No" 
                            SortExpression="EMPLOYEE_NO" />
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Name" 
                            HeaderText="Name" SortExpression="EMPLOYEE_NAME" />
                        <asp:BoundField DataField="DEP_NAME" FooterText="Department" HeaderText="Department" 
                            SortExpression="DEP_NAME" />
                        <asp:BoundField DataField="DATE_OF_JOIN" FooterText="Join Date" 
                            HeaderText="Join Date" SortExpression="DATE_OF_JOIN" />
                        <asp:BoundField DataField="EMAIL" HeaderText="E-mail" SortExpression="EMAIL" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="14px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                </asp:GridView>
		    
		    <p>
                &nbsp;</p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" Height="63px" ReadOnly="True" 
                    TextMode="MultiLine" Width="363px"></asp:TextBox>
            </p>
		    
		</form>
	</body>
</HTML>
