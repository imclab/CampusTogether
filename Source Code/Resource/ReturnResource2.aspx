<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="ReturnResource2.aspx.cs" Inherits="Resource_ReturnResource2" Title="Return Resource" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <p>
  
      <asp:Label ID="Status" runat="server"></asp:Label>
  
  </p>
  
    <asp:GridView ID="CurrentlyIssued" runat="server" 
        EmptyDataText="No entires for this id." AllowPaging="True" 
        AllowSorting="True" DataKeyNames="TransID" Height="69px" Width="675px" 
         BackColor="#FFFFCC" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None" HorizontalAlign="Left"  
                ForeColor="Black"   
             OnPageIndexChanging="CurrentlyIssuedPageChange"
              OnSorting="CurrentlyIssuedSort" onselectedindexchanged="CurrentlyIssued_SelectedIndexChanged1"
            
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
            <asp:CommandField SelectText="Return" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>

