<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EQ_requestl.ascx.cs" Inherits="userControll_EQ_requestl"   className="MyUserControl" %>

<style type="text/css">

        td {
	font-family: Verdana;
	font-size: 14px;
            text-align: left;
            margin-bottom: 15px;
        }
        .style30
        {
            width: 98%;
        }
        </style>
                    <table cellpadding="0" cellspacing="0" class="style30">
                        <tr>
                            <td class="style95">
                                <asp:Label ID="Label24" runat="server" Text="Number" Font-Size="12px" 
                    ForeColor="Maroon" Visible="False"></asp:Label>
                            </td>
                            <td class="style94">
                                <asp:TextBox ID="Text_Bran_No" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="66px" BorderWidth="1px" ReadOnly="True" Visible="False"></asp:TextBox>
                            </td>
                            <td class="style89">
                            </td>
                            <td class="style90">
                            </td>
                            <td class="style42">
                            </td>
                        </tr>
                        <tr>
                            <td class="style95">
                                <asp:Label ID="Label26" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="Requested Item"></asp:Label>
                            </td>
                            <td class="style94">
                                <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="true">
                                </asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1"
                           ErrorMessage="Value Required!" Font-Size="12px" ForeColor="Maroon" InitialValue="0"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td class="style89">
                                &nbsp;</td>
                            <td class="style90">
                                &nbsp;</td>
                            <td class="style42">
                                &nbsp;</td>
                                <td class="style89">
                                &nbsp;</td>
                        </tr>
                       
                        <tr>
                            <td class="style95">
                                <asp:Label ID="Label27" runat="server" Font-Size="12px" ForeColor="Maroon" 
                                    Text="QTY"></asp:Label>
                            </td>
                            <td class="style94">
                                <asp:TextBox ID="Text_QTY" runat="server" BorderColor="#B00000" 
                                    BorderStyle="Solid" BorderWidth="1px" Height="21px" MaxLength="50" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td class="style89">
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="Text_QTY" ErrorMessage="*" Font-Size="10px" 
                                    ForeColor="Maroon" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style90">
                                </td>
                            <td class="style42">
                                </td>
                        </tr>

                        <tr>
                           <td class="style42">
                                </td>
    
                        </tr>
                        <tr>
                            <td class="style77">
                                <asp:Label ID="Label25" runat="server" Text="Justification" Font-Size="12px" 
                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style78" colspan="3">
                                <asp:TextBox ID="Text_Description" runat="server" BorderColor="#B00000" 
                    BorderStyle="Solid" Width="339px" BorderWidth="1px" Height="83px" TextMode="MultiLine" 
                                    MaxLength="20" Rows="2"></asp:TextBox>

                                <td class="style89">
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="Text_Description" ErrorMessage="*" Font-Size="10px" 
                                    ForeColor="Maroon" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            </td>
                            <td class="style78">
                            </td>
                        </tr>
                        </table>
                
