﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:xml ID="Xml1" TransformSource="MyStyle.xsl" runat=server>
    <clients>
        <name>Frank Miller</name>
        <name>Judy Lew</name>
    </clients>
    </asp:xml>
    </div>
    </form>
</body>
</html>
