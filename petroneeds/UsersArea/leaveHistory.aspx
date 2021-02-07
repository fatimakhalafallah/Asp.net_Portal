<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master"  AutoEventWireup="true" CodeFile="leaveHistory.aspx.cs" Inherits="UsersArea_leaveHistory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../userControll/TravelDescription.ascx" tagname="TravelDescription" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">


 <div>
   <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" 
        CellPadding="2"
        onpageindexchanging="grid1_SelectedIndexChanged" AllowPaging="True" 
        BackColor="White" BorderColor="WhiteSmoke" BorderStyle="Solid" BorderWidth="2px" 
        Height="10px" Width="200px" 
        CellSpacing="2" ForeColor="Black">  
     <columns> 
       <asp:BoundField DataField="LEAVE_TYPE_NAME" HeaderText="Type LEAVE"/> 
       <asp:BoundField DataField="START_DATE" HeaderText="Start Date"/>  
       <asp:BoundField DataField="END_DATE" HeaderText="End Date"/>
        <asp:BoundField DataField="FORM_STATUS" HeaderText="LEAVE STATUS"/>
     </columns>  

     
        <emptydatatemplate>

      <div>
    <asp:Label ID="Label4" runat="server"  Font-Size="12px" ForeColor="Maroon">No data to display....</asp:Label>
    </div>
              
     </emptydatatemplate>
          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />

          <HeaderStyle BackColor="#B00000" Font-Bold="False" ForeColor="White" />

          <PagerStyle BackColor="" ForeColor="#B00000" HorizontalAlign="Center" />
          <RowStyle BackColor="" ForeColor="Black" />


          <SelectedRowStyle BackColor="#008A8C" Font-Bold="False" ForeColor="White" /> 
          <SortedAscendingCellStyle BackColor="#F1F1F1" />
          <SortedAscendingHeaderStyle BackColor="#808080" />
          <SortedDescendingCellStyle BackColor="#CAC9C9" />
          <SortedDescendingHeaderStyle BackColor="#383838" />
          
 </asp:GridView>  

     &nbsp;
     &nbsp;
     &nbsp;         
 
    </div>
   
    
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

