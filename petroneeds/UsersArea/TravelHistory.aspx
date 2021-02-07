<%@ Page Title="Travel Request History (TRH)" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="TravelHistory.aspx.cs" Inherits="UsersArea_TravelHistory" %>
<%@ Register src="../userControll/TravelDescription.ascx" tagname="TravelDescription" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
         </style>
</asp:Content>

<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
            <br>
            </br>

            <td class="style57">
            </td>
            <td class="style47">
            </td>
            <td class="style52">
                </td>
    

   
            
      <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" GridLines="Vertical"
        onpageindexchanging="grid1_SelectedIndexChanged" AllowPaging="True" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        Height="262px" Width="536px" 
       >  
          <AlternatingRowStyle BackColor="" />
     <columns> 
       <asp:BoundField DataField="PURPOSE" HeaderText="PURPOSE"/> 
       <asp:BoundField DataField="CITY_FROM" HeaderText="FIRST DESTINATION"/>  
       <asp:BoundField DataField="FROM_DATE" HeaderText=" DATE"/>
       <asp:BoundField DataField="CITY_TO" HeaderText=" LAST DESTINATION"/>
       <asp:BoundField DataField="TO_DATE" HeaderText=" DATE"/>          
     </columns>  

          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />

          <HeaderStyle BackColor="#B00000" Font-Bold="True" ForeColor="White" />

          <PagerStyle BackColor="" ForeColor="#B00000" HorizontalAlign="Center" />
          <RowStyle BackColor="" ForeColor="Black" />


          <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

          
 </asp:GridView>  



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