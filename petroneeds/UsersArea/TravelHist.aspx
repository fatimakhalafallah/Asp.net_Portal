<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="MasterPage.master"  CodeFile="TravelHist.aspx.cs" Inherits="UsersArea_TravelHist" %>



<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
                               
     
        <asp:GridView ID="grid1" EmptyDataText="No data to display" runat="server" AutoGenerateColumns="False" 
        CellPadding="1"
        onpageindexchanging="grid1_SelectedIndexChanged" AllowPaging="True" 
        Height="3px" Width="200px"
        onselectedindexchanged="grid1_SelectedIndexChanged1" ForeColor="#333333" 
            GridLines="None">  

                <AlternatingRowStyle BackColor="White" />
     <columns> 
       <asp:BoundField DataField="TRF_NO" HeaderText="RNO"/> 
       <asp:BoundField DataField="TRAVELER_NAME" HeaderText="Name"/> 
       <asp:BoundField DataField="PURPOSE" HeaderText="Purpose"/> 
       <asp:BoundField DataField="CITY_FROM" HeaderText="First DE"/>  
       <asp:BoundField DataField="FROM_DATE" HeaderText="Date"/>
       <asp:BoundField DataField="CITY_TO" HeaderText="Last DE"/>
       <asp:BoundField DataField="TO_DATE" HeaderText="Date"/> 
       <asp:BoundField DataField="FORM_STATUS" HeaderText="Status"/> 
       <asp:CommandField SelectText="Print Reuest..." ShowSelectButton="True"/>           
     </columns>  

   

          <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />

          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
        
 </asp:GridView> 
 
 <tabel>
 <tr>
 <td>
 &nbsp;
 </td>
 <td>
 
 </td>
 </tr>
 </tabel>
   
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















