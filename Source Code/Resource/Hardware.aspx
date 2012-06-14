<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="Hardware.aspx.cs" Inherits="Resource_Hardware" Title="Lab Resources" %>
<asp:Content ID = "Content1" runat = "server" ContentPlaceHolderID = "ContentHolder1"> 
    <asp:Label ID="status" Runat="server" ForeColor="red" />
    <p>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" Width="74px" 
            onclick="Search_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Show" runat="server" Text="ShowAll" onclick="Show_Click" />
    
    </p>
    <br />    
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" 
                        DataKeyNames="Name,Issued,Total,ID"  
                        EmptyDataText="There are no data records to display." Height="61px" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" CellPadding="4" 
                         GridLines="Vertical" Caption="Available Resources" CaptionAlign="Top" 
            OnPageIndexChanging="GridView1PageChange"
             OnSorting="GridView1Sort"
           
            BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None" HorizontalAlign="Center"  AllowSorting="True" 
                ForeColor="Black" Width="683px"    >
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
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                SortExpression="ID" />
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                            <asp:BoundField DataField="Issued" HeaderText="Issued" 
                                SortExpression="Issued" />
                            <asp:CommandField SelectText="Request" ShowSelectButton="True" ButtonType ="Button" 
                            ControlStyle-BackColor =Olive ControlStyle-Font-Bold =true >
<ControlStyle BackColor="Olive" Font-Bold="True"></ControlStyle>
                            </asp:CommandField>
                        </Columns>
                        
                    </asp:GridView>
                    &nbsp;<br />
    
</asp:Content>  
  



