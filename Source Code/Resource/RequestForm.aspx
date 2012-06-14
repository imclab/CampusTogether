<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="RequestForm.aspx.cs" Inherits="Resource_RequestForm" Title="Request Form" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID = "Content1" runat = "server" ContentPlaceHolderID = "ContentHolder1"> 
    
        
        <table style="height: 473px; width: 333px;" >
            <tr>
                <td class="style11">
                    <asp:Label ID="Label1" runat="server" Text="Component"></asp:Label>
&nbsp;:</td>
                <td style="width: 359px">
                    <asp:Label ID="L_com" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
&nbsp;Quantity :
                </td>
                <td style="width: 359px">
                    <asp:DropDownList ID="DL_quan" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="DL_quan" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Date&nbsp; From :</td>
                <td style="width: 359px">
                    <asp:TextBox ID="TB_df" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="TB_df" ErrorMessage="InValid" Operator="GreaterThanEqual"></asp:CompareValidator>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID = "TB_df" Format="dd-MM-yyyy" PopupPosition="TopRight">
                    </ajaxToolkit:CalendarExtender>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TB_df" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Date To :
                </td>
                <td style="width: 359px">
                    <asp:TextBox ID="TB_dt" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" ControlToValidate="TB_dt" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TB_df" ControlToValidate="TB_dt" Display="Dynamic" 
                        ErrorMessage="CompareValidator" Operator="GreaterThan" SetFocusOnError="True">Return 
                    date should be greater</asp:CompareValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TB_dt" Format="dd-MM-yyyy" PopupPosition="TopRight">
                    </cc1:CalendarExtender>
                                    </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="Mentor" runat="server" Text="Faculty/Mentor"></asp:Label>
                </td>
                <td style="width: 359px">
                    <asp:DropDownList ID="DL_fac" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="FacultyName" DataValueField="FacultyName">
                        <asp:ListItem></asp:ListItem>
                       
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CampusConnectConnectionString %>" 
                        SelectCommand="SELECT [FacultyName] FROM [Faculty]"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="DL_fac" Display="Dynamic" ErrorMessage="*" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Purpose</td>
                <td style="width: 359px">
                    <asp:TextBox ID="TB_pur" runat="server" Height="79px" Width="185px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TB_pur" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10" colspan="2">
                    <asp:Button ID="B_Request" runat="server" onclick="request_button_Click" 
                        Text="Request" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B_Reset" runat="server" onclick="Reset_Button_Click" 
                        Text="Reset" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B_Cancel" runat="server" onclick="Cancel_Button_Click" 
                        Text="Cancel" />                    
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    
                    <asp:Label ID="L_Continue" runat="server" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="B_Continue" runat="server" Enabled="False" 
                        onclick="B_Continue_Click" Text="Issue Another" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B_Done" runat="server" onclick="B_Done_Click" 
                        Text="I'm Done" Enabled="False" Visible="False" />
                    
                </td>
            </tr>
        </table>
    
    

</asp:Content>  

