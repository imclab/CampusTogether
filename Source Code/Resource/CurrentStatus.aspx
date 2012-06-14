<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="CurrentStatus.aspx.cs" Inherits="Resource_CurrentStatus" Title="Current Status" %>


<asp:Content ID = "Content1" runat = "server" ContentPlaceHolderID = "ContentHolder1"> 

    
                 
            <%-- <asp:GridView ID="CurrentStatus" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="TransID" 
                        EmptyDataText="There are no data records to display." 
                         Height="137px" style="margin-top: 0px">
                        <Columns>
                            <asp:BoundField DataField="TransID" HeaderText="TransID" 
                                SortExpression="TransID" />
                    
                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" 
                                SortExpression="StudentID" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                                SortExpression="Quantity" />
               <asp:BoundField DataField="Name" HeaderText="Name" 
                                SortExpression="Name" />
                    <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" 
                                SortExpression="IssueDate" />
               
                    <asp:BoundField DataField="TentativeReturnDate" HeaderText="TentativeReturnDate" 
                            SortExpression="TentativeReturnDate" />
                   <asp:TemplateField HeaderText="FacultyApproval" 
                                SortExpression="FacultyApproval">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Format(Eval("FacultyApproval")) %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Format(Eval("FacultyApproval")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="AdminApproval" 
                                SortExpression="AdminApproval">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Format(Eval("AdminApproval")) %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Format(Eval("AdminApproval")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
 <asp:BoundField DataField="Purpose" HeaderText="Purpose" 
                            SortExpression="Purpose" />
                        </Columns>
                    </asp:GridView>--%>
             
             
             
             <table>
         
           <tr>
         <td style="height: 159px">
                    <asp:GridView ID="CurrStatus" runat="server" AllowPaging="True" 
                        AllowSorting="True"  
                        PageSize="5" EmptyDataText="No Recent Activity" Width="548px"
                        BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
            OnPageIndexChanging="GridView2_PageIndexChanging"
             OnSorting="GridView2_Sorting"
            BorderStyle="None" HorizontalAlign="Center"   
                ForeColor="Black" Height="124px"    >
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
             
             
             
                 <asp:GridView ID="RoomStatus" runat="server" Width="554px"
                 BackColor="#FFFF99" BorderColor="#DEDFDE" BorderWidth="1px" 
            OnPageIndexChanging="RoomStatus_PageIndexChanging"
             OnSorting="RoomStatus_Sorting"
            BorderStyle="None" HorizontalAlign="Center"   
                ForeColor="Black" Height="124px" AllowPaging="True" PageSize="5"    >
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

 