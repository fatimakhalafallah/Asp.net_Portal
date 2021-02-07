<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application.aspx.cs" MasterPageFile="~/UsersArea/MasterPage.master"  Inherits="UsersArea_Application" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
      function ValidateCheckBoxList1(sender, args) {
          var checkBoxList = document.getElementById("<%=CheckBoxList1.ClientID %>");
          var checkboxes = checkBoxList.getElementsByTagName("input");
          var isValid = false;
          for (var i = 0; i < checkboxes.length; i++) {
              if (checkboxes[i].checked) {
                  isValid = true;
                  break;
              }
          }
          args.IsValid = isValid;
      }
</script>

    <style type="text/css">
       .style8
        {
            height: 17px;
        }
        .style9
        {
            height: 17px;
            width: 309px;
        }
        .style10
        {
        }
        .style12
        {
        }
        .style38
        {
            height: 24px;
            width: 308px;
        }
        .style39
        {
            height: 24px;
            }
        .style42
        {
            height: 23px;
        }
        .style47
        {
            height: 20px;
            width: 308px;
        }
        .style52
        {
            height: 20px;
        }
        .style57
        {
            height: 20px;
            width: 161px;
        }
        .style58
        {
            height: 17px;
            width: 161px;
        }
        .style60
        {
            height: 24px;
            width: 161px;
        }
        .style62
        {
            height: 22px;
            width: 161px;
        }
        .style63
        {
            height: 22px;
            width: 308px;
        }
        .style64
        {
            height: 22px;
        }
     
        .style69
        {
            width: 308px;
            height: 23px;
        }
        .style70
        {
            width: 308px;
        }
        .style71
        {
            width: 161px;
            height: 23px;
        }
        .style73
        {
            width: 161px;
        }
         .style74
        {
            width: 161px;
            height: 31px;
        }
        .style75
        {
            width: 308px;
            height: 31px;
        }
         </style>
</asp:Content>

<asp:Content ID="Content2" runat="server" 
contentplaceholderid="ContentPlaceHolder2">
   
 <table cellpadding="0" cellspacing="0" style="width: 674px">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/application access.PNG" />
                </b></td>
        </tr>
        <tr>
            <td class="style57">
            </td>
            <td class="style47">
            </td>
            <td class="style52">
                </td>
        </tr>
        <tr>
            <td class="style58">
                <b style="mso-bidi-font-weight: normal">
                <span style="font-size: 12.0pt; font-family: &quot;Calibri&quot;,&quot;sans-serif&quot;; mso-ascii-theme-font: minor-latin; mso-fareast-font-family: &quot;Times New Roman&quot;; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    <asp:Label ID="Label26" runat="server" Text="General" Font-Size="13px" 
                    ForeColor="Maroon" Font-Bold="False" Font-Names="Verdana"></asp:Label>
                </span></b>
            </td>
            <td class="style65">
            </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style69" rowspan="1">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style42" rowspan="1">
                </td>
        </tr>
        <tr>
            <td class="style71" rowspan="1">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style69" rowspan="1">
                            <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style42" rowspan="1">
                </td>
        </tr>
        <tr>
            <td class="style60" rowspan="1">
                <asp:Label ID="Label2" runat="server" Text="Request By" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style38" rowspan="1">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style39" rowspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style62" rowspan="1">
                <asp:Label ID="Label3" runat="server" Text="Requester ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style63" rowspan="1">
                <asp:TextBox ID="Text_Id" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style64" rowspan="1">
                &nbsp;</td>
        </tr>
         <tr>
            <td class="style62" rowspan="1">
                <asp:Label ID="Label1" runat="server" Text="Postition" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style63" rowspan="1">
                <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style64" rowspan="1">
                &nbsp;</td>
        </tr>
        
       
        <tr>
            <td rowspan="1" class="style72">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style70" rowspan="1">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="243px" BorderWidth="1px" MaxLength="50" Height="21px" 
                                ReadOnly="True"></asp:TextBox>
                <br />
            </td>
            <td rowspan="1">
                &nbsp;</td>
        </tr>
        <tr> 
          <td class="style71" rowspan="1"> 
              &nbsp;</td>
          <td>
          </td>
        </tr> 

        <tr>
        <td>
        
        
                    &nbsp;</td>
        <td>
        
        
        &nbsp;&nbsp;
                <br />
            </td>

        <td>
        
        
                &nbsp;</td>

        </tr> 
     
        <tr> 
        <td class="style73">
                <asp:Label ID="Label27" runat="server" Text="Application Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                    </td>

              <td class="style63" rowspan="1">
          
                     <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="true">
                                </asp:DropDownList>
          
                     <br />

            </td>
            
             <td class="style39" rowspan="1">
                 &nbsp;</td>


        </tr>
         <tr> 
        <td class="style73">
                    &nbsp;</td>

              <td class="style63" rowspan="1">
          
                     &nbsp;</td>

             <td class="style39" rowspan="1">
                 &nbsp;</td>


        </tr>

        <tr> 
        <td rowspan="1" class="style73">
                <asp:Label ID="Label28" runat="server" Text="Access Level" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                    </td>
                 <td rowspan="1">
                     <asp:CheckBoxList ID="CheckBoxList1" runat="server" ForeColor="Maroon">
                    <asp:ListItem Value="Senier Manager Level">Senier Manager Level</asp:ListItem>
                    <asp:ListItem Value="Manager Level">Manager Level</asp:ListItem>
                    <asp:ListItem Value="User Level">User Level</asp:ListItem>
                     </asp:CheckBoxList>
                     <br />
            </td>
                 </tr> 

       <tr> 
       
       <td class="style74">
                    &nbsp;</td>
            <td class="style75">
              


 
                &nbsp;</td> 
                                
       </tr>
        
      
       
        
            <td class="style73">
                                &nbsp;</td>
            <td class="style8">
                                <asp:Button ID="Button1" runat="server" Font-Names="Verdana" 
                                    Font-Size="9pt" onclick="Butt_Submit_Click" Text="Submit" Width="90px" 
                                    style="height: 22px" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" 
                                    Font-Names="Verdana" Font-Size="9pt" 
                    onclick="Butt_Reset_Click" Text="Reset" 
                                    Width="90px" />
                                    
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                                    ID="Label_Messages0" runat="server" Font-Names="Tahoma" Font-Size="Small" 
                    ForeColor="DarkRed" Width="339px" Height="16px"></asp:Label>
                            &nbsp;</td>
        </tr>
        <tr>
            <td class="style73">
                </td>
            <td class="style70">
                <b style="mso-bidi-font-weight: normal">
                   <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><asp:ToolkitScriptManager 
                    ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <br />
                </span></b>
            </td>
              <td class="style70">
                  &nbsp;</td>
            <td>
                
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



<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder5">
</asp:Content>

