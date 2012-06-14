<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddBoard.aspx.cs" Inherits="NoticeContent_AddBoard" Title="Add Notice Board" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="width: 166px">
                Name</td>
            <td align="left">
                <asp:TextBox ID="T_Name" runat="server" MaxLength="30" Width="173px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="T_Name" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">
                Moderator UserID</td>
            <td align="left">
                <asp:TextBox ID="T_Mod" runat="server" MaxLength="9" Width="173px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="T_Mod" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="T_Mod" ErrorMessage="InValid ID" 
                    ValidationExpression="^[2][0][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 166px">
                &nbsp;</td>
            <td align="left">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>

