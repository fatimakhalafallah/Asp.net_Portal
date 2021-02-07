<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            width: 100%;
        }
    </style>
      <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
<script type="text/javascript">
<!--
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
        }
    }
    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }
    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
//-->
</script>
<link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <table border="0" cellpadding="0" cellspacing="0" class="style11">
        <tr>
            <td class="style12">
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
                    DataSourceID="SqlDataSource1" EmptyDataText="No data was returned" 
                    GridLines="Horizontal" SelectedIndex="1" ShowHeader="False" Width="250px" 
                    BackColor="White" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" 
                    ForeColor="Black" onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id">
                        <ItemStyle Font-Size="1px" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NewTitle" HeaderText="NewTitle" 
                            SortExpression="NewTitle" />
                        <asp:CommandField SelectText="..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#B00000" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                    SelectCommand="SELECT [id], [NewTitle] FROM [tbl_News] ORDER BY [dateCreated]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table class="style13">
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
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    CellPadding="5" CellSpacing="2" DataKeyNames="id" DataSourceID="SqlDataSource2" 
                    GridLines="None" Height="50px" Width="716px">
                    <Fields>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" ShowHeader="False" Visible="False" />
                        <asp:BoundField DataField="dateCreated" HeaderText="Date" ShowHeader="False" 
                            SortExpression="dateCreated" />
                        <asp:BoundField DataField="NewTitle" HeaderText="Title" ShowHeader="False" 
                            SortExpression="NewTitle" >
                        <ItemStyle ForeColor="#B00000" />
                        </asp:BoundField>
                        <asp:BoundField DataField="newsDetail" HeaderText="Detail" ShowHeader="False" 
                            SortExpression="newsDetail" />
                        <asp:BoundField DataField="image" HeaderText="image" ShowHeader="False" 
                            SortExpression="image" Visible="False" />
                        <asp:ImageField DataAlternateTextField="image" DataImageUrlField="image" 
                            ReadOnly="True">
                        </asp:ImageField>
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                    SelectCommand="SELECT [id], [NewTitle], [newsDetail], [dateCreated], [image] FROM [tbl_News] WHERE ([id]=@id)">
                <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="id" PropertyName="Text" Type="Int64" />
                </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="115px" Visible="False"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="124" height="25"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_01.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_011.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_12.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_13.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
          <td width="124" height="25"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/li_014.jpg',1)"><img src="images/li_14.jpg" name="Image35" width="124" height="25" border="0" id="Img2" /></a></td>
          
          <td width="124" height="25" bgcolor="#B00000" style="width: 248px"><a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Img3','','images/li_020.jpg',1)">
              <img src="images/li_20.jpg" name="Image44" width="124" height="25" border="0" 
                  id="Img3" /></a></td>
        </tr>
      </table>
</asp:Content>



