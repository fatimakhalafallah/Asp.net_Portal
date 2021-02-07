<%@ Page Title="Function Request Information" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="FunctionRequest.aspx.cs" Inherits="FunctionRequest"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 117%;
        }
        .style37
        {
        height: 17px;
        width: 89px;
    }
        .style38
        {
            width: 127px;
            height: 17px;
        }
        .style42
        {
            height: 25px;
        }
        .style43
        {
        height: 25px;
        width: 89px;
    }
        .style49
        {
            height: 25px;
        }
        .style54
        {
            width: 127px;
        }
        .style55
        {
            width: 127px;
            height: 40px;
        }
        .style56
        {
            height: 40px;
            width: 89px;
        }
        .style57
        {
            height: 40px;
        }
        .style59
        {
            width: 584px;
            border-collapse: collapse;
        }
        .style61
        {
        width: 87px;
        height: 25px;
    }
        .style62
        {
            width: 127px;
            height: 25px;
        }
        .style63
        {
        width: 105px;
        height: 25px;
    }
        .style67
    {
        width: 127px;
        height: 20px;
    }
    .style68
    {
        height: 20px;
        width: 89px;
    }
    .style69
    {
        height: 20px;
    }
        .style70
        {
            width: 300px;
        }
        .style71
        {
            width: 92px;
        }
        .style72
        {
            width: 10px;
        }
        .style73
        {
            width: 56px;
        }
    .style74
    {
        height: 25px;
        width: 91px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" class="style7">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/na_8.gif" />
                </b></td>
        </tr>
        <tr>
            <td class="style67">
            </td>
            <td class="style68">
            </td>
            <td class="style69">
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
               
</script><asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px"></asp:TextBox>
            </td>
            <td class="style49">
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px"></asp:TextBox>
                <asp:CalendarExtender ID="Text_Date_CalendarExtender" runat="server" 
                    TargetControlID="Text_Date" ClearTime="false" Format="dd-MMMM-yyyy">
                </asp:CalendarExtender>
            </td>
            <td class="style49">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Num" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    Height="21px"></asp:TextBox>
            </td>
            <td class="style49">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="Text_Department" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label2" runat="server" Text="Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    Height="21px"></asp:TextBox>
            </td>
            <td class="style49">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Name" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label17" runat="server" Text="No.Of Guest" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_No_Guest" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="83px" BorderWidth="1px" MaxLength="50" 
                    Height="21px"></asp:TextBox>
            </td>
            <td class="style49">
            </td>
        </tr>
        <tr>
            <td class="style55">
                <asp:Label ID="Label18" runat="server" Text="Function Location" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style56">
                <asp:TextBox ID="Text_Location" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="100" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style57">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="Text_Location" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label19" runat="server" Text="Purpose of Function" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Purpose" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="Label_Charactor" runat="server" Text="Less Than 1000 Character" Font-Size="10px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
            <td class="style49">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="Text_Purpose" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style42" colspan="2">
                <table cellpadding="0" class="style59">
                    <tr>
                        <td class="style61">
                            <asp:Label ID="Label24" runat="server" Text="Starting Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style63">
                            <asp:TextBox ID="Text_Strat_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px"></asp:TextBox>

                            <asp:CalendarExtender ID="Text_Strat_Date_CalendarExtender" runat="server" 
                                TargetControlID="Text_Strat_Date" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>

                        </td>
                        <td class="style42">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="Text_Strat_Date" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style74">
                            <asp:Label ID="Label20" runat="server" Text="Starting Time" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style42">
                            <asp:TextBox ID="Text_Strat" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ForeColor="Gray">hh:mm</asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="Text_Strat" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True" InitialValue="hh:mm"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style42">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Names="Tahoma" 
                                Font-Size="11px" RepeatDirection="Horizontal" Width="76px">
                                <asp:ListItem Selected="True" Value="1">AM</asp:ListItem>
                                <asp:ListItem Value="2">PM</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style61">
                            <asp:Label ID="Label25" runat="server" Text="Ending Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style63">
                            <asp:TextBox ID="Text_End_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" 
                                style="margin-bottom: 0px"></asp:TextBox>
                            <asp:CalendarExtender ID="Text_End_Date_CalendarExtender" runat="server" 
                                TargetControlID="Text_End_Date" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>

                        </td>
                        <td class="style42">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="Text_End_Date" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style74">
                            <asp:Label ID="Label21" runat="server" Text="Ending Time" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style42">
                            <asp:TextBox ID="Text_End" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" 
                                style="margin-bottom: 0px" ForeColor="Gray">hh:mm</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="Text_End" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True" InitialValue="hh:mm"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Names="Tahoma" 
                                Font-Size="11px" RepeatDirection="Horizontal" Width="76px">
                                <asp:ListItem Selected="True" Value="1">AM</asp:ListItem>
                                <asp:ListItem Value="2">PM</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    </table>
            </td>
            <td class="style49">
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label22" runat="server" Text="Arrangements" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Arrangements" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    TextMode="MultiLine" Height="51px"></asp:TextBox>
            </td>
            <td class="style49">
            </td>
        </tr>
        <tr>
            <td class="style62">
                <asp:Label ID="Label23" runat="server" Text="Request By" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style43">
                <asp:TextBox ID="Text_Request_By" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="291px" BorderWidth="1px" MaxLength="50" 
                    Height="20px"></asp:TextBox>
            </td>
            <td class="style49">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_Request_By" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style54">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style38">
            </td>
            <td class="style37">
                <asp:Label ID="Label_Messages" runat="server" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style54">
            </td>
            <td class="style37">
                <table cellpadding="0" cellspacing="0" class="style70">
                    <tr>
                        <td class="style71">
                            &nbsp;</td>
                        <td class="style73">
                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Submit" onclick="Butt_Submit_Click" Width="65px" style="margin-left: 0px" />
                        </td>
                        <td class="style72">
                            &nbsp;</td>
                        <td>
                <asp:Button ID="Butt_Reset" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Reset" CausesValidation="False" onclick="Butt_Reset_Click" 
                    Width="65px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style54">
                &nbsp;</td>
            <td class="style37">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PetroneedsConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:PetroneedsConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DEP_NAME, DEP_NO FROM MP.DEPARTMENTS">
                </asp:SqlDataSource>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
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



