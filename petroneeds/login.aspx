<%@ Page Title="Petroneeds Services International :: Login Page" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            height: 30px;
        }
        .style14
        {
            text-align: left;
        }
        .style16
        {
            text-align: left;
            height: 19px;
        }
        .style18
        {
            height: 19px;
        }
        .style19
        {
            width: 53px;
        }
        .style21
        {
            text-align: left;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <span style="color: #1350c5; font-family: Tierra Blanca">
    <table border="0" cellpadding="0" cellspacing="0" style="font-size: 20px; width: 433px;
                font-family: Tahoma; height: 149px; text-align: left">
        <tr>
            <td class="style7" colspan="3">
                <asp:Image ID="Image34" runat="server" ImageUrl="~/images/ne_5.gif" />
            </td>
            <td class="style7">
            </td>
            <td class="style7" width="100">
            </td>
        </tr>
        <tr>
            <td class="style7" width="30">
            </td>
            <td class="style21">
            </td>
            <td class="style21">
            </td>
            <td class="style7">
            </td>
            <td class="style7" width="100">
            </td>
        </tr>
        <tr>
            <td width="30">
            </td>
            <td class="style14">
                <asp:Label ID="Label1" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="User Name" Width="84px" Height="18px"></asp:Label>
            </td>
            <td class="style14">
                <asp:TextBox ID="Text_User" runat="server" Width="164px"></asp:TextBox>
            </td>
            <td>
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_User" ErrorMessage="*" ForeColor="#993300"></asp:RequiredFieldValidator>
                </span>
            </td>
            <td width="100">
            </td>
        </tr>
        <tr>
            <td width="30">
            </td>
            <td class="style14">
                <asp:Label ID="Label2" runat="server" Font-Names="Corbel" Font-Size="Medium" 
                    ForeColor="#B00000" Text="Password" Width="87px" Height="21px"></asp:Label>
            </td>
            <td class="style14">
                <asp:TextBox ID="Text_Password" runat="server" TextMode="Password" 
                    Width="164px"></asp:TextBox>
            </td>
            <td>
                <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Password" ErrorMessage="*" ForeColor="#993300"></asp:RequiredFieldValidator>
                </span>
            </td>
            <td width="100">
            </td>
        </tr>
        <tr>
            <td class="style18" width="30">
            </td>
            <td class="style16">
            </td>
            <td class="style18">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                    ForeColor="DarkRed" Width="350px" Height="16px"></asp:Label>
    </span>
            </td>
            <td class="style18">
            </td>
            <td class="style18" width="100">
            </td>
        </tr>
        <tr>
            <td class="style18" width="30">
            </td>
            <td class="style16">
            </td>
            <td class="style18">
    <span style="color: #1350c5; font-family: Tierra Blanca">
                <asp:Label ID="Label4" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                    ForeColor="DarkRed" Width="350px" Height="16px"></asp:Label>
    </span>
            </td>
            <td class="style18">
            </td>
            <td class="style18" width="100">
            </td>
        </tr>
        <tr>
            <td width="30">
            </td>
            <td class="style14">
            </td>
            <td class="style14">
                <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" 
                    style="width: 128px" align="left">
                    <tr>
                        <td>
    <span style="color: #1350c5; font-family: Tierra Blanca">
                            <asp:Button ID="Butt_Log" runat="server" Font-Names="Corbel" 
                                OnClick="Button1_Click" Text="Login" />
    </span>
                        </td>
                        <td class="style19">
                            &nbsp;</td>
                        <td>
    <span style="color: #1350c5; font-family: Tierra Blanca">
                            <asp:Button ID="Butt_Back" runat="server" CausesValidation="False" 
                                Font-Names="Corbel" OnClick="Button2_Click" Text="Home" />
    </span>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
            <td width="100">
            </td>
        </tr>
    </table>
    </span>
    </asp:Content>


<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
</asp:Content>



<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <table width="995" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="124" height="25"><a href="default.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image10','','images/li_01.jpg',1)"><img src="images/li_1.jpg" name="Image10" width="124" height="25" border="0" id="Image10" title="Home" /></a></td>
          <td width="124" height="25"><a href="welcom.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image30','','images/li_09.jpg',1)"><img src="images/li_9.jpg" name="Image30" width="124" height="25" border="0" id="Image30" /></a></td>
          <td width="124" height="25"><a href="polices.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image31','','images/li_010.jpg',1)"><img src="images/li_10.jpg" name="Image31" width="124" height="25" border="0" id="Image31" /></a></td>
          <td width="124" height="25"><a href="Events.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/li_011.jpg',1)"><img src="images/li_11.jpg" name="Image32" width="124" height="25" border="0" id="Image32" /></a></td>
          <td width="124" height="25"><a href="staff.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/li_012.jpg',1)"><img src="images/li_12.jpg" name="Image33" width="124" height="25" border="0" id="Image33" /></a></td>
          <td width="124" height="25"><a href="e_services.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image34','','images/li_013.jpg',1)"><img src="images/li_13.jpg" name="Image34" width="124" height="25" border="0" id="Img1" /></a></td>
          <td width="124" height="25"><a href="vacancy.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/li_014.jpg',1)"><img src="images/li_14.jpg" name="Image35" width="124" height="25" border="0" id="Img2" /></a></td>
          
          <td width="124" height="25" bgcolor="#B00000" style="width: 248px"><a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Img3','','images/li_020.jpg',1)">
              <img src="images/li_020.jpg" name="Image44" width="126" height="25" border="0" 
                  id="Img3" /></a></td>
        </tr>
      </table>
</asp:Content>




