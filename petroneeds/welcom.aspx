<%@ Page Title="Petroneeds Services International :: Welcome" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="welcom.aspx.cs" Inherits="welcom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style13
    {
        width: 661px;
    }
    .style16
    {
        text-align: justify;
    }
    .style17
    {
        text-align: right;
    }
        .style18
        {
            width: 653px;
        }
        .style19
        {
            width: 510px;
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
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style13">
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style16">
            <asp:Image ID="Image34" runat="server" 
                ImageUrl="~/images/IMG-20140223-WA0006[1].jpg" />
        </td>
        <td class="style16">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style16">
            &nbsp;</td>
        <td class="style16" rowspan="3">
            <asp:Image ID="Image35" runat="server" Height="103px" 
                ImageUrl="~/images/HQ-8553.JPG" Width="90px" />
        </td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource1" Width="653px" CellPadding="5" 
                CellSpacing="2" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="MngDetails" HeaderText="MngDetails" ReadOnly="True" 
                        ShowHeader="False" SortExpression="MngDetails" />
                </Fields>
            </asp:DetailsView>
        </td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource3" Width="653px" CellPadding="5" 
                CellSpacing="2" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="MngDetails2" HeaderText="MngDetails2" 
                        ShowHeader="False" SortExpression="MngDetails2" />
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                SelectCommand="SELECT [MngDetails2] FROM [Mng_Word]"></asp:SqlDataSource>
        </td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            <asp:DetailsView ID="DetailsView4" runat="server" AutoGenerateRows="False" 
                DataSourceID="SqlDataSource4" Width="653px" CellPadding="5" 
                CellSpacing="2" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="MngDetails3" HeaderText="MngDetails3" 
                        ShowHeader="False" SortExpression="MngDetails3" />
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                SelectCommand="SELECT [MngDetails3] FROM [Mng_Word]"></asp:SqlDataSource>
        </td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            <table cellpadding="0" cellspacing="0" class="style18" width="653px">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
            <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                CellPadding="2" CellSpacing="2" DataSourceID="SqlDataSource2" Height="50px" 
                Width="150px" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="Mng" HeaderText="Mng" ShowHeader="False" 
                        SortExpression="Mng" >
                    <ItemStyle Font-Bold="True" HorizontalAlign="Justify" VerticalAlign="Bottom" />
                    </asp:BoundField>
                </Fields>
            </asp:DetailsView>
                    </td>
                </tr>
            </table>
        </td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
    <tr>
        <td width="5">
            &nbsp;</td>
        <td class="style17">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                SelectCommand="SELECT [MngDetails] FROM [Mng_Word]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:petroneedsConnectionString2 %>" 
                SelectCommand="SELECT [Mng] FROM [Mng_Word]"></asp:SqlDataSource>
        </td>
        <td class="style17">
            &nbsp;</td>
        <td width="5">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>



<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="124" height="25" bgcolor="#B00000">
                   <table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="124" height="25"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_1.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_09.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_11.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_12.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_13.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
          <td width="124" height="25"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/li_014.jpg',1)"><img src="images/li_14.jpg" name="Image35" width="124" height="25" border="0" id="Img2" /></a></td>
          
          <td width="124" height="25" bgcolor="#B00000" style="width: 248px"><a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Img3','','images/li_020.jpg',1)">
              <img src="images/li_20.jpg" name="Image44" width="124" height="25" border="0" 
                  id="Img3" /></a></td>
        </tr>
      </table>
                </td>
        </tr>
    </table>
</asp:Content>




