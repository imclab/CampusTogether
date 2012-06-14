<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteBoard.aspx.cs" Inherits="Notice_DeleteBoard" Title="Delete Notice Board" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="L_Name" runat="server" style="font-weight: 700" Text="Name"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="D_Name" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Name" DataValueField="Name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CampusConnectionString %>" 
                    SelectCommand="SELECT [Name] FROM [Notice_Board] ORDER BY [Name]">
                </asp:SqlDataSource>
            </td>
            <td align="left">
                <asp:Button ID="B_Delete" runat="server" Text="Delete" 
                    onclick="B_Delete_Click" />
            </td>
        </tr>        
    </table>

</asp:Content>

