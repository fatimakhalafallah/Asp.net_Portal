<%@ Page Title="Petroneeds Services International :: Staff" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="staff.aspx.cs" Inherits="staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            width: 147%;
        }
        .style14
        {
            width: 735PX;
        }
        .style15
        {
            width: 246px;
        }
        .style16
        {
            width: 11px;
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


<script type="text/javascript">
    // for check all checkbox  
    function CheckAll(Checkbox) {
        var GridVwHeaderCheckbox = document.getElementById("<%=GridView1.ClientID %>");
        for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
            GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }  
    </script>   



<link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <table border="0" cellpadding="0" cellspacing="0" class="style11">
        <tr>
            <td class="style12">
              </td>
            <td class="style12">
               </td>
        </tr>
        <tr>
            <td class="style12">
               </td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td class="style12">
               </td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td width="5" class="style12">
               </td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td width="5" class="style12">
               </td>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td width="5" class="style12">
                </td>
            <td class="style12">
               </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style13">
        <tr>
            <td class="style8">
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_3.gif" />
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="style14">
                    <tr>
                        <td class="style16">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label1" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Name" Width="50px" Height="18px"></asp:Label>
    </span>
                        </td>
                        <td class="style15">
                            <asp:TextBox ID="Text_Name" runat="server" Width="234px"></asp:TextBox>
                        </td>
                        <td>
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label2" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Department" Width="84px" Height="18px"></asp:Label>
    </span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" 
                                style="margin-left: 0px" Width="222px" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
    <span style="color: #1350c5; font-family: Tierra Blanca">
                            <asp:Button ID="Butt1_Search" runat="server" Font-Names="Corbel" 
                                OnClick="Butt1_Search_Click" Text="Search" />
    </span>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style16">
                            <br />
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label3" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Id Card" Width="50px" Height="18px"></asp:Label>
    </span>
                        </td>
                        <td class="style15">
                           <asp:TextBox ID="Text_Number" runat="server" Width="234px"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ControlToValidate="Text_Number" ErrorMessage="Insert No" 
                                        Font-Overline="False" Font-Size="10px" ForeColor="Maroon" 
                                        MaximumValue="2147483647" MinimumValue="0" SetFocusOnError="True" 
                                        Type="Integer">  </asp:RangeValidator>
                        </td>

                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                <asp:GridView ID="GridView1" runat="server" Width="735px" AllowPaging="True" 
                    AllowSorting="True" BorderWidth="0px" CellPadding="2" 
                    CellSpacing="1" EmptyDataText="No data was returned" GridLines="Horizontal" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onsorting="GridView1_Sorting" PageSize="20" ShowFooter="True" 
                    HorizontalAlign="Left" AutoGenerateColumns="False" PageIndex="1" 
                    ShowHeaderWhenEmpty="True "
                    onselectedindexchanged="GridView1_SelectedIndexChanged"
                  
                    >
                    <Columns>
                      
                  

                       <asp:BoundField DataField="EMPLOYEE_NO" FooterText="Number" HeaderText="Number" 
                            SortExpression="EMPLOYEE_NO" />
                        <asp:BoundField DataField="EMPLOYEE_NAME" FooterText="Name" HeaderText="Name" 
                            SortExpression="EMPLOYEE_NAME" />
                        <asp:BoundField DataField="JOB_NAME" FooterText="Jop Name" 
                            HeaderText="Jop Name" SortExpression="JOB_NAME" />
                        <asp:BoundField DataField="ID_CARD" FooterText="Id Card" HeaderText="Id Card" 
                            SortExpression="ID_CARD" />
                        <asp:BoundField DataField="CONTACT_PHONES" FooterText="Phone" 
                            HeaderText="Phone" SortExpression="CONTACT_PHONES" />
                        <asp:CommandField SelectText="See More ..." ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                    <HeaderStyle BackColor="#B00000" Font-Names="Verdana" Font-Size="14px" 
                        ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" 
                        Position="TopAndBottom" />
                    <PagerStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="#B00000" 
                        HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <RowStyle Font-Size="11px" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#B00000" Font-Size="13px" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            &nbsp;<asp:Label ID="lblRecord" runat="server" />
                </td>
                           
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <table width="995" border="0" cellspacing="0" cellapdding="0">
        <tr>
          <td width="124" height="25"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_1.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_11.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_012.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_13.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
          <td width="124" height="25"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/li_014.jpg',1)"><img src="images/li_14.jpg" name="Image35" width="124" height="25" border="0" id="Img2" /></a></td>
          
          <td width="124" height="25" bgcolor="#B00000" style="width: 248px"><a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Img3','','images/li_020.jpg',1)">
              <img src="images/li_20.jpg" name="Image44" width="124" height="25" border="0" 
                  id="Img3" /></a></td>
        </tr>
      </table>
</asp:Content>



