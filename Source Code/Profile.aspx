<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Profile_Profile" Title="View Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <br />
    <table style="width: 100%;" frame="border" align="left">
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Label ID="L_Info" runat="server" style="font-weight: 700; text-align: center;" 
                Text="View Profiles Information" Visible="False" ForeColor="Olive"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left" style="width: 168px">
            <asp:Label ID="L_D1" runat="server" style="font-weight: 700" Text="ID" 
                Visible="False"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="T_ID" runat="server" Enabled="False" Visible="False"></asp:TextBox>
        </td>
        <td colspan="2" align="left">
            <asp:Button ID="B_Search" runat="server" Enabled="False" Height="21px" 
                Text="Search" Visible="False" onclick="B_Search_Click" />
            <asp:RegularExpressionValidator ID="R_Info" runat="server" 
                ControlToValidate="T_ID" ErrorMessage="InValid Search" 
                ValidationExpression="^[2][0][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="width: 168px">
            &nbsp;</td>
        <td colspan="2" align="left">
            <asp:Label ID="L_Error" runat="server"></asp:Label>
                                    </td>
    </tr>
    <tr>
        <td colspan="2" style="width: 168px">
            <asp:Image ID="I_Photo" runat="server" Height="86px" Width="86px" />
        </td>
        <td colspan="2" align="left">
            <asp:Label ID="L_Name" runat="server" ForeColor="Olive" 
                style="font-size: xx-large"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4" colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4" style="width: 160px; font-weight: bold;" align="left">
            <asp:Label ID="L_RoleL" runat="server" Text="Role"></asp:Label>
        </td>
        <td colspan="3" align="left">
            <asp:Label ID="L_Role" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4" style="width: 160px; font-weight: bold;" align="left">
            ID</td>
        <td colspan="3" align="left">
            <asp:Label ID="L_Id" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4" style="width: 160px; font-weight:bold;" align="left"> 
            <asp:Label ID="L_SexL" runat="server" Text="Sex"></asp:Label>
        </td>
        <td colspan="3" align="left">
            <asp:Label ID="L_Sex" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="left">
            <asp:Label ID="L_Extra" runat="server" style="font-weight: 700" Visible="False"></asp:Label>
        </td>
        <td align="left">
            <asp:Label ID="L_ExtraInfo" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style5" colspan="4" bgcolor="Olive" 
            
            
            
            style="font-weight: bold; font-size: large; font-style: italic; text-align: center; color: #FF6600; background-color: #FFFFFF;" 
            align="center">
            <asp:Label ID="Label1" runat="server" ForeColor="Olive" 
                Text="Laptop Information"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="font-weight: bold">
            &nbsp;</td>
        <td class="style2" style="text-align: right" align="right">
            <asp:Button ID="B_Laptop" runat="server" Enabled="False" 
                onclick="B_Laptop_Click" Text="Edit" Visible="False" />
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="font-weight: bold" align="left">            
            Serial</td>
        <td class="style2" align="left">
            <asp:TextBox ID="L_Serial" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="height: 20px; font-weight: bold;" 
            align="left">
            Brand</td>
        <td class="style2" style="height: 20px" align="left">
            <asp:TextBox ID="L_Brand" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="font-weight: bold" align="left">
            Room</td>
        <td class="style2" align="left">
            <asp:TextBox ID="L_Room" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style8" colspan="3">
        </td>
        <td class="style8">
        </td>
    </tr>    
    <tr>
        <td class="style5" colspan="4" 
            
            style="font-weight: bold; font-style: italic; color: #FF6600; text-align: center; font-size: large" 
            align="center">
            <asp:Label ID="Label2" runat="server" ForeColor="Olive" 
                Text="Vehicle Information"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="font-weight: bold">
            &nbsp;</td>
        <td class="style2" style="text-align: right" align="right">
            <asp:Button ID="B_Vehicle" runat="server" Enabled="False" 
                onclick="B_Vehicle_Click" Text="Edit" Visible="False" />
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3" style="font-weight: bold" align="left">
            Number</td>
        <td class="style2" align="left">
            <asp:TextBox ID="L_Number" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="left">
            <b>Company</b></td>
        <td align="left">
            <asp:TextBox ID="L_Company" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

