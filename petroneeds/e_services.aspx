<%@ Page Title="Petroneeds Services International :: E-Services" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="e_services.aspx.cs" Inherits="e_services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            width: 140%;
        }
        .style14
        {
            height: 18px;
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
    <table cellpadding="0" class="style13">
        <tr>
            <td colspan="2" width="10">
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_6.gif" />
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                HR Services</td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                -
                <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/login.aspx">Leave Request</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                - 
                <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/login.aspx">Salary Advance</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                - 
                <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/login.aspx">Recruitment</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                - 
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/login.aspx">Salary Slip</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10" class="style14">
                </td>
            <td class="style14">
                </td>
            <td width="10" class="style14">
                </td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                Administration</td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                -
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/login.aspx">Travel &amp; Migration</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                - 
                <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/login.aspx">Travel Request</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                -
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/login.aspx">Function Request Information</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                -
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/login.aspx">Stationery Request</asp:LinkButton>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="10">
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
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_11.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_12.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_013.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
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




