<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ServicesRequested.ascx.cs" Inherits="userControll_ServicesRequested" EnableViewState="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 300px;
    }
</style>

<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td>
            <asp:TextBox ID="TextFrom" runat="server" Width="120px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="TextFrom" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>
        </td>
        <td>
            <asp:TextBox ID="TextTo" runat="server" Width="120px"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                TargetControlID="TextTo" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>
            </td>
        <td>
            <asp:TextBox ID="TextRemark" runat="server" TextMode="MultiLine" Width="160px" 
                Height="20px"></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="TextServices" runat="server" Visible="False"></asp:TextBox>
        </td>
    </tr>
</table>








