<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Petroneeds Services International :: </title>
<meta name="Keywords" content="Petroneeds Services International,Petroneeds,Petroleum in sudan,Petroleum company in sudan,Petroneeds in Sudan" />
<meta name="description" content="Petroneeds Services International">

<link rel="icon" href="images/favicon.gif" type="gif" >

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
</style>
<script type="text/javascript">
<!--
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
</head>
<body bgcolor="#f4f2ef" background="images/bg.png" onload="MM_preloadImages('images/ico_1.png','images/ico_2.png','images/icon_3.png','images/li_01.jpg','images/li_03.jpg','images/li_02.jpg','images/li_04.jpg','images/li_05.jpg','images/li_06.jpg','images/li_07.jpg','images/li_08.jpg','images/lil_01.gif','images/lil_02.gif','images/lil_03.gif','images/lil_04.gif','images/top.png')">
<div align="center"/>
    <form id="form1" runat="server">
    <asp:AdRotator ID="AdRotator1" runat="server" />
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
        BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
        ForeColor="Black" Height="111px" NextPrevFormat="FullMonth" Width="350px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>
    </form>
</body>
</html>
