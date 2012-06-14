<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="Issue.aspx.cs" Inherits="Resource_Issue" Title="Issue Resource" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    
    
    <asp:GridView ID="Issue" runat="server" DataKeyNames="TransID" 
        EmptyDataText="There are no items to be issued" 
        onselectedindexchanged="Issue_SelectedIndexChanged" Width="585px" 
        CellPadding="4"  GridLines="Vertical"  
            BackColor="#FFFFCC" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None" HorizontalAlign="Left"  
                ForeColor="Black"   
             OnPageIndexChanging="IssuePageChange"
              OnSorting="IssueSort"
            
            >
                        <PagerSettings Mode="NumericFirstLast" />
                        <RowStyle BackColor="#FFFFCC" />
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                            HorizontalAlign="Right" VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#00CC66" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#3A3A3A" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <AlternatingRowStyle BackColor="White" />
            
             
        
        <Columns>
            <asp:CommandField SelectText="Issue" ShowSelectButton="True" />
        </Columns>
        
    </asp:GridView>
    
      <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
      
    
</asp:Content>

