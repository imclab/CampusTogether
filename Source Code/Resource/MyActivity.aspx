<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="MyActivity.aspx.cs" Inherits="Resource_MyActivity" Title="My Activity" %>

<asp:Content ID = "Content1" runat = "server" ContentPlaceHolderID = "ContentHolder1"> 

         <table>
        <tr>
        
     <td>   
        
         
                    <asp:GridView ID="Activity" runat="server" AllowPaging="True" 
                        AllowSorting="True" CellPadding="2" EmptyDataText="No Activity" 
                         PageSize="5" Width="650px" 
                        BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
              OnPageIndexChanging="ActivityPageChange"
               OnSorting="ActivitySort"
            BorderStyle="None" HorizontalAlign="Center" 
                ForeColor="Black"    >
                        <PagerSettings Mode="NumericFirstLast" />
                        <RowStyle BackColor="#FFFFCC" />
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                            HorizontalAlign="Right" VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#00CC66" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#3A3A3A" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <AlternatingRowStyle BackColor="White" />                    </asp:GridView>
</td>
        </tr>        
<tr>
<td>


    <asp:GridView ID="RoomActivity" runat="server" 
     AllowSorting="True" CellPadding="2" EmptyDataText="No Activity" 
                         PageSize="5" Width="650px" 
                        BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
              OnPageIndexChanging="RoomActivityPageChange"
               OnSorting="RoomActivitySort"
            BorderStyle="None" HorizontalAlign="Center" 
                ForeColor="Black" AllowPaging="True"    >
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
</asp:Content> 

 
