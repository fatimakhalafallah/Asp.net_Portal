﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vacancy.aspx.cs" Inherits="_vacancy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>PSI :: Vacancy</title>
<meta name="Keywords" content="Petroneeds Services International,Petroneeds,Petroleum in sudan,Petroleum company in sudan,Petroneeds in Sudan" />
<meta name="description" content="Petroneeds Services International" />
<link rel="icon" href="images/favicon.gif" type="gif" />
<style>
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
}
body,td,th {
	font-family: Verdana;
	font-size: 14px;
}
a {
	font-family: Verdana;
	font-size: 13px;
}
a:link {
	color: #6c6459;
	text-decoration: none;
        text-align: left;
    }
a:visited {
	text-decoration: none;
	color: #6c6459;
}
a:hover {
	text-decoration: underline;
	color: #B00000;
}
a:active {
	text-decoration: none;
	color: #6c6459;
}
.style9 {
	color: #B40000;
	font-size: 15px;
}
.style5 {
	color: #b00000;
	font-size: 13px;
}
.style1 {
	color: #6c6459;
	font-size: 12px;
}
</style>
<script type="text/javascript">
<!--
    function mmLoadMenus() {
        if (window.mm_menu_0919141313_0) return;
        window.mm_menu_0919141313_0 = new Menu("root", 207, 25, "Verdana", 13, "#F4F2EF", "#B00000", "#B00000", "#F4F2EF", "left", "middle", 2, 1, 100, -5, 7, true, false, true, 0, true, false);
        mm_menu_0919141313_0.addMenuItem("Manpower&nbsp;Supply", "location='manpower.html'");
        mm_menu_0919141313_0.addMenuItem("Project&nbsp;Management&nbsp;Services", "location='projectMangement.html'");
        mm_menu_0919141313_0.addMenuItem("Drilling&nbsp;&&nbsp;Petroleum&nbsp;Services", "location='drilling.html'");
        mm_menu_0919141313_0.addMenuItem("Supply&nbsp;Chain&nbsp;Management", "location='supplyChain.html'");
        mm_menu_0919141313_0.addMenuItem("Oil&nbsp;Field", "location='oilField.html'");
        mm_menu_0919141313_0.addMenuItem("Workshop&nbsp;&&nbsp;Maintenance", "location='workShop.html'");
        mm_menu_0919141313_0.hideOnMouseOut = true;
        mm_menu_0919141313_0.bgColor = '#555555';
        mm_menu_0919141313_0.menuBorder = 1;
        mm_menu_0919141313_0.menuLiteBgColor = '#FFFFFF';
        mm_menu_0919141313_0.menuBorderBgColor = '#777777';
        window.mm_menu_0919142323_0 = new Menu("root", 184, 25, "Verdana", 13, "#F4F2EF", "#B00000", "#B00000", "#F4F2EF", "left", "middle", 2, 1, 100, -5, 7, true, false, true, 0, true, false);
        mm_menu_0919142323_0.addMenuItem("Overview", "location='overview.html'");
        mm_menu_0919142323_0.addMenuItem("Welcome", "location='welcome.html'");
        mm_menu_0919142323_0.addMenuItem("Mision,&nbsp;Vision&nbsp;and&nbsp;Values", "location='about_m_v_v.html'");
        mm_menu_0919142323_0.addMenuItem("Organization&nbsp;Structure", "location='orgatructure.html'");
        mm_menu_0919142323_0.hideOnMouseOut = true;
        mm_menu_0919142323_0.bgColor = '#555555';
        mm_menu_0919142323_0.menuBorder = 1;
        mm_menu_0919142323_0.menuLiteBgColor = '#FFFFFF';
        mm_menu_0919142323_0.menuBorderBgColor = '#777777';
        window.mm_menu_0919142655_0 = new Menu("root", 124, 25, "Verdana", 13, "#F4F2EF", "#B00000", "#B00000", "#F4F2EF", "left", "middle", 2, 1, 100, -5, 7, true, false, true, 0, false, false);
        mm_menu_0919142655_0.addMenuItem("News", "location='news.aspx'");
        mm_menu_0919142655_0.addMenuItem("Vacancy", "location='vacancy.aspx'");
        mm_menu_0919142655_0.hideOnMouseOut = true;
        mm_menu_0919142655_0.bgColor = '#555555';
        mm_menu_0919142655_0.menuBorder = 1;
        mm_menu_0919142655_0.menuLiteBgColor = '#FFFFFF';
        mm_menu_0919142655_0.menuBorderBgColor = '#777777';

        window.mm_menu_0919141314_0 = new Menu("root", 95, 25, "Verdana", 13, "#F4F2EF", "#B00000", "#B00000", "#F4F2EF", "left", "middle", 2, 1, 100, -5, 7, true, false, true, 0, true, false);
        mm_menu_0919141314_0.addMenuItem("HSE", "location='hse.html'");
        mm_menu_0919141314_0.addMenuItem("QHSE", "location='Qhse.html'");
        mm_menu_0919141314_0.addMenuItem("Community", "location='community_Safety.html'");
        mm_menu_0919141314_0.hideOnMouseOut = true;
        mm_menu_0919141314_0.bgColor = '#555555';
        mm_menu_0919141314_0.menuBorder = 1;
        mm_menu_0919141314_0.menuLiteBgColor = '#FFFFFF';
        mm_menu_0919141314_0.menuBorderBgColor = '#777777';

        mm_menu_0919141314_0.writeMenus();
    } // mmLoadMenus()

    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
        }
    }
    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }

    function MM_popupMsg(msg) { //v1.0
        alert(msg);
    }
    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
//-->
</script>
<script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
<script language="JavaScript" src="mm_menu.js"></script>
</head>

<body bgcolor="#f4f2ef" background="images/bg.png" onload="MM_preloadImages('images/ico_1.png','images/ico_2.png','images/icon_3.png','images/lil_01.gif','images/lil_02.gif','images/lil_03.gif','images/top.png','images/li_01.jpg','images/li_03.jpg','images/li_06.jpg','images/li_08.jpg','images/li_09.jpg','images/li_011.jpg','images/li_02.jpg','images/li_010.jpg','images/lil_019.gif')">
<script language="JavaScript1.2">mmLoadMenus();</script>
<div align="center">
  <table width="995" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="235"><img src="images/upline.png" width="235" height="10" /></td>
      <td><img src="images/upline.png" width="495" height="10" /></td>
      <td width="250"><img src="images/upline.png" width="250" height="10" /></td>
    </tr>
    <tr>
      <td height="80" colspan="2" valign="bottom" bgcolor="#FFFFFF"><div align="left">
        <table width="745" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="90"><div align="right"><img src="images/logo.gif" width="76" height="73" onclick="MM_popupMsg('Petroneeds Services International')" /></div></td>
            <td width="632"><img src="images/coName2.gif" width="632" height="80" /></td>
          </tr>
        </table>
      </div></td>
      <td width="250" height="80" valign="top" bgcolor="#FFFFFF"><table width="250" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="94" height="42" valign="bottom">&nbsp;</td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image1','','images/ico_1.png',1)"><img src="images/ico_1.png" alt="Home" name="Image1" width="52" height="40" border="0" id="Image1" title="Home" /></a></div></td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','images/ico_2.png',1)"><img src="images/ico_2.png" alt="E-mail" name="Image2" width="52" height="40" border="0" id="Image2" title="E-mail" /></a></div></td>
          <td width="52" height="42" valign="bottom"><div align="center"><a href="login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image3','','images/icon_3.png',1)"><img src="images/icon_3.png" alt="Login" name="Image3" width="52" height="40" border="0" id="Image3" title="Login" /></a></div></td>
        </tr>
      </table></td>
    </tr>
    <td></td>
    <tr>
      <td height="150" colspan="3" bgcolor="#FFFFFF"><table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="150"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="995" height="150">
            <param name="movie" value="images/head.swf" />
            <param name="quality" value="high" />
            <embed src="images/head.swf" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="995" height="150"></embed>
          </object></td>
        </tr>
      </table></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="124" height="20"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_1.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="20"><a href="about.html" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image11','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image11" width="124" height="25" border="0" id="Image11" title="Company" onmouseover="MM_showMenu(window.mm_menu_0919142323_0,0,26,null,'Image11')" onmouseout="MM_startTimeout();" /></a></td>
          <td width="124" height="20"><a href="milestones.html" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image41','','images/li_02.jpg',1)"><img src="images/li_2.jpg" name="Image41" width="124" height="25" border="0" id="Image41" title="About us" /></a></td>
          <td width="124" height="20"><a href="services.html" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image12','','images/li_03.jpg',1)"><img src="images/li_3.jpg" name="Image12" width="124" height="25" border="0" id="Image12" title="Services" onmouseover="MM_showMenu(window.mm_menu_0919141313_0,0,26,null,'Image12')" onmouseout="MM_startTimeout();" /></a></td>
          <td width="124" height="20"><a href="news.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image13','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image13" width="124" height="25" border="0" id="Image13" title="News" onmouseout="MM_startTimeout();" /></a></td>
          <td width="124" height="20"><a href="community_Safety.html" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image15','','images/li_06.jpg',1)"><img src="images/li_6.jpg" name="Image15" width="124" height="25" border="0" id="Image15" title="Community &amp; Safety" onmouseover="MM_showMenu(window.mm_menu_0919141314_0,0,26,null,'Image15')" onmouseout="MM_startTimeout();"  /></a></td>
          <td width="124" height="20"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image42','','images/li_011.jpg',1)">
              <img src="images/li_011.jpg" name="Image42" width="124" height="25" border="0" 
                  id="Image42" title="Vacancy" /></a></td>
          <td width="124" height="20" bgcolor="#B00000"><a href="contact.html" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image17','','images/li_08.jpg',1)"><img src="images/li_8.jpg" name="Image17" width="127" height="25" border="0" id="Image17" title="Contact Us" /></a></td>
        </tr>
      </table></td>
    </tr>
    <tr>
      <td bgcolor="#FFFFFF">&nbsp;</td>
      <td bgcolor="#FFFFFF">&nbsp;</td>
      <td bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td bgcolor="#FFFFFF">&nbsp;</td>
      <td bgcolor="#FFFFFF" class="style9"><div align="left">Vacancy:</div></td>
      <td bgcolor="#FFFFFF"><div align="left"></div></td>
    </tr>
    <tr>
      <td width="235" bgcolor="#FFFFFF">&nbsp;</td>
      <td colspan="2" bgcolor="#FFFFFF"><div align="left"><img src="images/line.jpg" width="500" height="2" /></div></td>
    </tr>
    <tr>
      <td width="235" valign="top" bgcolor="#FFFFFF"><table width="235" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
        
        
        <tr>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
        </tr>
        
        
      </table></td>
      <td width="510" valign="top" bgcolor="#FFFFFF"><table width="510" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td width="500">&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
      </table></td>
      <td width="250" valign="top" bgcolor="#FFFFFF"><table width="250" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
        <tr>
          <td width="5">&nbsp;</td>
          <td>&nbsp;</td>
          <td width="5">&nbsp;</td>
        </tr>
      </table></td>
    </tr>
    <tr>
      <td width="235" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="510" bgcolor="#FFFFFF">&nbsp;</td>
      <td width="250" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><img src="images/line.jpg" width="995" height="5" /></td>
    </tr>
    <tr>
      <td height="130" colspan="3" bgcolor="#F4F2EF"><table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><span class="style5">Company</span></div></td>
          <td width="20">&nbsp;</td>
          <td width="230" class="style5"><div align="left">Core Business</div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style5"><div align="left">Events</div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style5"><div align="left">Corporate</div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style5"><div align="left">Contact Us</div></td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><a href="about.html">About Us</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="manpower.html">Manpower Supply</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style7"><div align="left"><a href="news.aspx">News</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="150"><div align="left"><a href="hse.html">HSE</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style7"><div align="left"><a href="contact.html">Contact Us</a></div></td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><a href="overview.html">Overview</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="projectMangement.html">Project Management Services</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170" class="style7"><div align="left"><a href="vacancy.aspx">Vacancy</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="150"><div align="left"><a href="qhse.html">QHSE</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><a href="welcome.html">Welcome</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="drilling.html">Drilling &amp; Petroleum  Services</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170"><div align="left"></div></td>
          <td width="20">&nbsp;</td>
          <td width="170"><div align="left"><a href="community_Safety.html"><span class="style1">Community</span></a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><a href="about_m_v_v.html">Mision, Vision &amp; Values</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="supplyChain.html">Supply Chain  Management</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"><a href="orgatructure.html">Organization Structure</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="oilField.html">Oil Field</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"></div></td>
          <td width="20">&nbsp;</td>
          <td width="230"><div align="left"><a href="workShop.html">Workshop &amp; Maintenance</a></div></td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
        </tr>
        <tr>
          <td width="20">&nbsp;</td>
          <td width="155"><div align="left"></div></td>
          <td width="20">&nbsp;</td>
          <td width="230">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170">&nbsp;</td>
          <td width="20">&nbsp;</td>
          <td width="170"><div align="right"><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image22','','images/top.png',1)"></a><img src="images/logo.png" width="27" height="26" title="Petroneeds Services International" /></div></td>
        </tr>
        <tr>
          <td colspan="10"><div align="center" class="style1">Copyright © 1997 - 2013 Petroneeds Services International (PSI). All Rights Reserved. </div></td>
        </tr>
      </table></td>
    </tr>
  </table>
</div>
    
    </div>
    </form>
</body>
</html>
