<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="notice.aspx.cs" Inherits="NoticeContent_AddBoard" Title="Notice Board" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table style="width:100%;">
        <tr>          
            <td align="right">
    <asp:Button ID="B_Add" runat="server" Enabled="False" onclick="B_Add_Click" 
        Text="New Board" Visible="False" Width="88px" BackColor="Olive" Font-Bold="True" 
                    ForeColor="White" />
    <asp:Button ID="B_Delete" runat="server" Enabled="False" 
        onclick="B_Delete_Click" Text="Delete Board" Visible="False" Width="105px" 
                    BackColor="Olive" Font-Bold="True" ForeColor="White" />
    <asp:Button ID="B_Notice" runat="server" Enabled="False" Text="Add Notice" 
        Visible="False" Width="88px" BackColor="Olive" Font-Bold="True" ForeColor="White" />

    <asp:Button ID="B_Detail" runat="server" Text="Notice Board in Detail" onclick="B_Detail_Click" 
                    Width="168px" BackColor="Olive" Font-Bold="True" ForeColor="White" />
                <asp:DropDownList ID="D_NB" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Name" DataValueField="Name" BackColor="#99CCFF" 
                    Font-Bold="True" ForeColor="White">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CampusConnectionString %>" 
                    SelectCommand="SELECT [Name] FROM [Notice_Board] ORDER BY [Name]">
                </asp:SqlDataSource>
            </td>            
        </tr>        
    </table>
    <asp:Panel ID="P_Board" runat="server">
    </asp:Panel>    
    
</asp:Content>

