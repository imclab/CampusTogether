<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gate.aspx.cs" Inherits="GateEntry_Gate" Title="Gate Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">    
    <table width="670" id = "table">
                <tr>
                    <td rowspan="3" style="text-align: left; width: 163px;" align="center" 
                        valign="middle">
                        <asp:Label ID="L_ID" runat="server" Text="ID" style="font-weight: 700"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="T_ID" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td style="text-align: left; width: 113px;">
                        <asp:Label ID="DateLabel" runat="server" Text="Date"></asp:Label>
                    </td>
                    
                    <td align="right">
                        &nbsp;</td>
                    <td align="right" valign="top">
                        <asp:Button ID="B_Pdf" runat="server" onclick="Button1_Click" 
                            Text="Create Report" BackColor="Olive" Font-Bold="True" ForeColor="White" 
                            Width="105px" Enabled="False" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 113px;">
                        <asp:Label ID="Label1" runat="server" Text="From" style="font-weight: 700"></asp:Label>
&nbsp;
                        <asp:TextBox ID="T_Df" runat="server" Width="75px"></asp:TextBox>
&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                            PopupPosition="Right" TargetControlID="T_Df" Format="dd-MM-yyyy">
                        </ajaxtoolkit:calendarextender>
                    </td>
                    
                    <td style="text-align: center">
                        <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                            Text="Select Register"></asp:Label>
                        <br />
                        <asp:DropDownList ID="D_Register" runat="server" style="text-align: center" 
                            onselectedindexchanged="D_Register_SelectedIndexChanged" Height="23px" 
                            Width="105px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center" id = "chutiya">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left; width: 113px;">
                        <asp:Label ID="Label2" runat="server" Text="To" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="T_Dt" runat="server" Width="75px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="T_Df" ControlToValidate="T_Dt" ErrorMessage="InValid Date" 
                            Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date"></asp:CompareValidator>
&nbsp;<ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" 
                            PopupPosition="Right" TargetControlID="T_Dt" Format="dd-MM-yyyy">
                        </ajaxtoolkit:calendarextender>
                        </td>                    
                    <td style="text-align: center">
                        <asp:Button ID="B_Search" runat="server" onclick="B_Search_Click" 
                            Text="Search" />
                    </td>
                    <td style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align ="left" >                        
                            <asp:GridView ID="GateData" runat="server" ForeColor="#333333" 
                                GridLines="Vertical" Width="521px"
                                 AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gridView_PageIndexChanging" 
                                 OnSorting="gridView_Sorting" PageSize="15" 
                                SelectedIndex="0">                            
                            
                            <PagerSettings Mode="Numeric" />                            
                            <RowStyle BackColor="#EFF3FB" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            
                            <br />                        
                    </td>
                    <td align ="left" >                        
                            &nbsp;</td>
                </tr>
            </table>   
</asp:Content>

