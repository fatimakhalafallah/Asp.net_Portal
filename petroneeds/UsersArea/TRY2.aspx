<%@ Page Title="Travel Request Form (TRF)" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="TRY2.aspx.cs" Inherits="TRY2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../userControll/TravelDescription.ascx" tagname="TravelDescription" tagprefix="uc1" %>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
                               
      <asp:GridView ID="grid1" EmptyDataText="No data to display" runat="server" AutoGenerateColumns="False" 
        CellPadding="4"
        onpageindexchanging="grid1_SelectedIndexChanged" AllowPaging="True" 
        BackColor="White" BorderColor="#f7f7f7" BorderStyle="Solid" BorderWidth="3px" 
        Height="5px" Width="600px" CellSpacing="2"
        onselectedindexchanged="grid1_SelectedIndexChanged1" ForeColor="Maroon" 
       >  

     <columns> 
       <asp:BoundField DataField="TRF_NO" HeaderText=" TRAVEL RNO"/> 
       <asp:BoundField DataField="PURPOSE" HeaderText="PURPOSE"/> 
       <asp:BoundField DataField="CITY_FROM" HeaderText="FIRST DESTINATION"/>  
       <asp:BoundField DataField="FROM_DATE" HeaderText=" DATE"/>
       <asp:BoundField DataField="CITY_TO" HeaderText=" LAST DESTINATION"/>
       <asp:BoundField DataField="TO_DATE" HeaderText=" DATE"/> 
       <asp:BoundField DataField="FORM_STATUS" HeaderText="STATUS"/> 
       <asp:CommandField SelectText="Print Reuest..." ShowSelectButton="True"/>           
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
        
 </asp:GridView>  
      &nbsp;
    &nbsp;
     &nbsp;<br />
&nbsp;<table cellpadding="0" cellspacing="0" style="width: 674px">
     <tr>
     <td>
     
     </td>
     <td>
                            &nbsp;
                      &nbsp;&nbsp;&nbsp;
                                                                    
                                <br />
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















