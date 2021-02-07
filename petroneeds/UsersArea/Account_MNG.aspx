<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_MNG.aspx.cs" Inherits="UsersArea_Account_MNG" MasterPageFile="~/UsersArea/MasterPage.master" %>



<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
                               
      <asp:GridView ID="grid1" EmptyDataText="No data to display" runat="server" AutoGenerateColumns="False" 
        onpageindexchanging="grid1_SelectedIndexChanged" AllowPaging="True"
        BackColor="White" BorderColor="#f7f7f7"  Width="595px"  DataKeyNames="FORM_NO" style="margin-top: 7px" 
        onselectedindexchanged="grid1_SelectedIndexChanged1" CellPadding="3" ShowHeaderWhenEmpty="True" CellSpacing="1" ForeColor="#B00000" 
       > 
         <AlternatingRowStyle BackColor="White" /> 
       <columns>               
       <asp:BoundField DataField="FORM_NO" HeaderText="Form No"  SortExpression="FORM NO"/> 
       <asp:BoundField DataField="FORM_DATE" HeaderText="Form Date"/> 
       <asp:BoundField DataField="REQUEST_USER" HeaderText="Requester Name"/>  
       <asp:BoundField DataField="USER_FULL_NAME" HeaderText="New User"/>
       <asp:BoundField DataField="USER_DEPARTMENT" HeaderText="User Dep"/>   
       <asp:BoundField DataField="ACCOUNT_TYPE" HeaderText="Account Type"/>  
       <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Assgin To"/> 
       <asp:BoundField DataField="FORM_STATUS" HeaderText="Status"/>       
       </columns>   
       <FooterStyle BackColor="#B00000" Font-Bold="True" Font-Size="12px" 
         ForeColor="White" />
       <HeaderStyle BackColor="#B00000" BorderColor="#B00000" BorderStyle="Solid" 
        Font-Bold="True" Font-Size="12px" ForeColor="#808080" />
        <PagerStyle BackColor="#B00000" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFE1E6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFFAFB" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
      
                   
 </asp:GridView>  
      <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;         
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
