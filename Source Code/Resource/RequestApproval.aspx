 <%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="RequestApproval.aspx.cs" Inherits="Resource_RequestApproval" Title="Request-Approval" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
     
    <div style="height: 1086px">
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    
<br />
   
        <table style="width: 19%; height: 427px;">
            <tr>
                <td>
    <p style="font-weight:bold">Resources</p> <br />
        <asp:GridView ID="Res" runat="server"
        OnRowCommand="grid_RowCommandHandler" onselectedindexchanged="grid_SelectedIndexChanged1" 
        CellPadding="4" EmptyDataText="No Entries to display"
        GridLines="Vertical" PageSize="5"
        BackColor="#FFFFCC" BorderColor="#DEDFDE" BorderWidth="1px" 
      OnPageIndexChanging="gridPageChange"
       OnSorting="gridSort"
            BorderStyle="None" HorizontalAlign="Left"   
                ForeColor="Black" AllowPaging="True" 
             Width="592px" Height="95px"    >
                        <PagerSettings Mode="NumericFirstLast" />
                        <RowStyle BackColor="#FFFFCC" />
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                            HorizontalAlign="Right" VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#00CC66" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#3A3A3A" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle HorizontalAlign="Right" VerticalAlign="Top" Width="200px" />
                        <AlternatingRowStyle BackColor="White" />
        
            
</asp:GridView>
    

                </td>
            </tr>
            <tr>
                <td >
    <p style="font-weight:bold">Rooms</p> <br />

<asp:GridView ID="rooms" runat="server" OnRowCommand="room_RowCommandHandler" 
        CellPadding="4" DataKeyNames="TransID" 
        EmptyDataText="No requests for Approval"  
        GridLines="Vertical" Width="605px" AllowPaging="True" 
        PageSize="5" BackColor="#FFFFCC" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None" HorizontalAlign="Left"  
                ForeColor="Black" Height="143px"   
             OnPageIndexChanging="roomsPageChange"
              OnSorting="roomsSort"
            
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
            <asp:ButtonField CommandName="Reject" Text="Reject" />
            <asp:ButtonField CommandName="Approve" Text="Approve" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
        
    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td >
   <p style="font-weight:bold">Approved</p> <br />
    <asp:GridView ID="Approved" runat="server"  CellPadding="4" 
        EmptyDataText="No Entries To Display"  GridLines="Vertical" 
      BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None"   
                ForeColor="Black"  Width="606px" Height="98px" AllowPaging="True" 
        AllowSorting="True" HorizontalAlign="Left" PageSize="5" 
OnPageIndexChanging="ApprovedPageChange"
              OnSorting="ApprovedSort"
        
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
    </asp:GridView>


   
                </td>
            </tr>
      <tr>
      <td>
      
      
          <asp:GridView ID="ApprovedRoom" runat="server" 
          BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None"   
                ForeColor="Black"  Width="606px" Height="98px" AllowPaging="True" 
        AllowSorting="True" HorizontalAlign="Left" PageSize="5" 
OnPageIndexChanging="ApprovedRoomPageChange"
              OnSorting="ApprovedRoomSort"
        
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
          </asp:GridView>
      
      
      </td>
      
      
      
      </tr>
      
        </table>


   
        </div>
</asp:Content>

