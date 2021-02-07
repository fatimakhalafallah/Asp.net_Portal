<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UsersArea/MasterPage.master" CodeFile="VehicleRequest.aspx.cs" Inherits="UsersArea_VehicleRequest" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style7
        {
            width: 186px;
        }
        .style8
        {
            text-align: left;
            height: 19px;
        }
        .style9
        {
            width: 150px;
            height: 225px;
        }
        .style11
        {
            width: 124px;
            text-align: left;
            height: 19px;
        }
        .style12
        {
        width: 104px;
    }
        .style27
        {
            height: 23px;
            width: 124px;
        }
        .style28
        {
            height: 23px;
            width: 168px;
        }
        .style29
        {
        }
        .style45
        {
            text-align: left;
        }
        .style48
        {
            text-align: left;
            vertical-align: text-top;
            width: 168px;
            height: 19px;
        }
        .style49
        {
            width: 168px;
        }
        .style51
        {
            width: 91px;
            height: 22px;
        }
        .style53
        {
            width: 32px;
            height: 22px;
        }
        .style55
        {
            height: 23px;
        }
        .style56
        {
            width: 124px;
        }
        .style57
        {
            width: 69px;
            height: 22px;
        }
        .style59
        {
            width: 31px;
            height: 22px;
        }
        .style60
        {
            width: 124px;
            height: 9px;
        }
        .style61
        {
            width: 168px;
            height: 9px;
        }
        .style62
        {
            height: 9px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table cellpadding="0" cellspacing="0" width="600px">
        <tr>
            <td colspan="3">
                <b style="mso-bidi-font-weight:normal">
                <asp:Image ID="Image18" runat="server" ImageUrl="~/images/VehicelRequest.PNG" 
                    ImageAlign="Left" Height="36px" Width="469px" />
                </b></td>
        </tr>
        <tr>
            
                  
       <td colspan=3>
           <br />
       </td>
         
             
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label16" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Num" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style29" rowspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label14" runat="server" Text="Date" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="140px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label2" runat="server" Text="Employee Name" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Name" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="320px" BorderWidth="1px" MaxLength="50" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Text_Name" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label3" runat="server" Text="Employee ID" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style28">
                <asp:TextBox ID="Text_Id" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="92px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Text_Id" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:Label ID="Label4" runat="server" Text="Position" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="Text_Position" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="300px" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                <asp:Label ID="Label5" runat="server" Text="Department" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="Text_Department" runat="server" BorderColor="#B00000" 
                    BorderStyle="Outset" Width="200px" BorderWidth="1px" Height="20px" 
                    ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
       <tr>
       <td>
       </td>

       <td>
       
           <br />
           <br />
       
       </td>
       
       
       </tr>
       <tr>
       <td>
                <asp:Label ID="Label17" runat="server" Text="Destination" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
       </td>
       <td>
       
                    <asp:TextBox ID="Text_DEST" runat="server" BorderColor="#B00000" 
                    BorderStyle="Inset" Width="320px" BorderWidth="1px" 
               TextMode="MultiLine"></asp:TextBox>
       
       </td>
       <td>
       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="Text_DEST" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
       
       </td>
       
       </tr>
       <tr>
       <td>
       
                <asp:Label ID="Label18" runat="server" Text="Purpose" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
       
       </td>
       <td>
       
       
                    <asp:TextBox ID="Text_PURPSE" runat="server" BorderColor="#B00000" 
                    BorderStyle="Inset" Width="320px" BorderWidth="1px" 
               TextMode="MultiLine"></asp:TextBox>
       
       
       </td>
       <td>
       
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="Text_PURPSE" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
       
       </td>

       </tr>
        <tr>
            <td class="style56">
       
                <asp:Label ID="Label19" runat="server" Text="Departure Time" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
       
            </td>
            <td class="style10" colspan="2">
                <table style="width: 457px">
                    <tr>
                        <td class="style57">
                    <asp:Label ID="Label10" runat="server" Text="Day" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style59">
                <asp:TextBox ID="Date" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="125px" BorderWidth="1px" AutoPostBack="True" Height="16px" 
                                ></asp:TextBox>
                            <asp:CalendarExtender ID="Text_from_CalendarExtender" runat="server" 
                                TargetControlID="Date" Format="dd-MMMM-yyyy">
                            </asp:CalendarExtender>
                        </td>
                        
                        <td class="style53">
                    <asp:Label ID="Label20" runat="server" Text="Time" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="style51">
                <asp:TextBox ID="Text_time" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="58px" BorderWidth="1px" style="margin-left: 0px" 
                                Height="16px"></asp:TextBox>
                            </td>
                            <td>
                              <asp:maskededitextender ID="MaskedEditExtender1" TargetControlID="Text_time"
                                Mask="99:99"
                                MaskType="Time"
                                AcceptAMPM="true"
                                CultureName="en-us"
                                MessageValidatorTip="true"
                                runat="server">
                             </asp:maskededitextender>

                            </td>
                            <td>
                            
                            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="Date" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
       
                            
                            </td>
                            <td>
                            
                            
                            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="Text_time" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
       
                            
                            
                            </td>
                    </tr>
                    </table>
                </td>
        </tr>
        <tr>
            <td class="style27">
                    &nbsp;</td>
            <td class="style28">
                    &nbsp;</td>
            <td class="style55">
                </td>
        </tr>
        <tr>
            <td class="style27">
                    <asp:Label ID="Label15" runat="server" Text="Approximate Duration" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
            </td>
            <td class="style49">
                <asp:TextBox ID="Text_DU" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="95px" BorderWidth="1px">  </asp:TextBox>
                </td>
            <td class="style29">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                     ControlToValidate="Text_DU" ErrorMessage="*" ForeColor="#CC0000" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>

                    
                </td>
        </tr>
        <tr>
            <td class="style11">
                    </td>
            <td class="style48">
                    </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style45">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                <asp:Button ID="Butt_Submit" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Submit" onclick="Butt_Submit_Click" Width="65px" 
                    style="height: 22px" />
&nbsp;<asp:Button ID="Butt_Reset" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Reset" CausesValidation="False" onclick="Butt_Reset_Click" 
                    Width="65px" />
                <b style="mso-bidi-font-weight:normal">
                <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-theme-font:
minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;mso-ansi-language:EN-US;
mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
                &nbsp;<asp:Button ID="Butt_Return" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    Text="Return" CausesValidation="False" 
                    Width="65px" onclick="Butt_Return_Click" />
                &nbsp;<asp:ToolkitScriptManager 
                    ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                </span></b>
            </td>
            <td>
               </td>
        </tr>
        <tr>
            <td class="style60">
                </td>
            <td class="style61">
                </td>
            <td class="style62">
                </td>
        </tr>
        <tr>
            <td class="style56">
                &nbsp;</td>
            <td class="style49">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder5">
    <table cellpadding="0" cellspacing="0" class="style9">
    <tr>
        <td valign="top">
                <table cellpadding="0" cellspacing="0" class="style37">
                    <tr>
                        <td class="style43" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style38" colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="NOTE:" Font-Size="14px" 
                    ForeColor="Red"></asp:Label>
                           <asp:Label ID="Label6" runat="server" Text="VR must be submitted before one hour from the trip time for trip inside Khartoum, and before one working day for long distance missions.
" Font-Size="14px" 
                    ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style36" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="style41">
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style41">
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style41">
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style41">
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style42">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style42">
                            </td>
                        <td>
                            </td>
                    </tr>
                </table>
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


















