<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="buildings.aspx.cs" Inherits="Resource_Buildings_buildings" Title="Room Allocation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <table style="width: 662px; height: 206px; margin-left: 25px;" >
        <tr>
            <td class="style11">
                Category:</td>
            <td class="style16" style="width: 347px">
                <asp:DropDownList ID="type" runat="server" Height="21px" Width="131px" 
                     
                    onselectedindexchanged="type_SelectedIndexChanged" AutoPostBack="True" 
                    >
                </asp:DropDownList>
                </td>
            <td class="style9">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style12">
                Number:</td>
            <td class="style17" style="width: 347px">
                <asp:DropDownList ID="number" runat="server" Height="16px" Width="136px" 
                    AutoPostBack="True" onselectedindexchanged="number_SelectedIndexChanged" 
                     >
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style20">
                </td>
            <td class="style21" style="width: 347px">
                 <asp:Label ID="roomno" runat="server"></asp:Label>
                 <asp:GridView ID="ttbl" runat="server" AutoGenerateColumns="False" 
                      
                     CellPadding="3" CellSpacing="1" EmptyDataText="No activity to show" 
                     GridLines="None" Width="313px" 
                     PageSize="5" BackColor="#FFFFCC" BorderColor="#DEDFDE" BorderWidth="1px" 
            BorderStyle="None" HorizontalAlign="Left"   
                ForeColor="Black" AllowPaging="True" AllowSorting="True" 
                >
                        <PagerSettings Mode="NumericFirstLast" />
                        <RowStyle BackColor="#FFFFCC" />
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                            HorizontalAlign="Right" VerticalAlign="Top" />
                        <SelectedRowStyle BackColor="#00CC66" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#3A3A3A" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle HorizontalAlign="Right" VerticalAlign="Top" Width="200px" />
                        <AlternatingRowStyle BackColor="White" />
                     
                     <Columns>
                         <asp:BoundField DataField="TimeFrom" HeaderText="From" />
                         <asp:BoundField DataField="TimeTo" HeaderText="To" />
                         <asp:BoundField DataField="Event" HeaderText="Activity" />
                     </Columns>
                     
                 
                 </asp:GridView>
                 
                 
                 
                  
                 
                 </td>
            <td class="style23" >
                <asp:Calendar ID="Calendar1" runat="server" Height="138px" 
                    onselectionchanged="Calendar1_SelectionChanged" 
                    SelectedDate="04/07/2010 13:47:04" style="margin-left: 0px" 
                     
                      >
                    <TodayDayStyle BackColor="#999966" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style24">
                Date:</td>
            <td class="style25" style="width: 347px">
                Month&nbsp;
                <asp:DropDownList ID="Month" runat="server" Height="16px" Width="70px" 
                    onselectedindexchanged="Month_SelectedIndexChanged" AutoPostBack="True">
                  
                  <asp:ListItem Text="Jan" ></asp:ListItem>
                 <asp:ListItem Text="Feb" ></asp:ListItem>
                 <asp:ListItem Text="March" ></asp:ListItem>
                 <asp:ListItem Text="April" ></asp:ListItem>               
                 <asp:ListItem Text="May" ></asp:ListItem>
                 <asp:ListItem Text="June" ></asp:ListItem>
                 <asp:ListItem Text="July" ></asp:ListItem>
                 <asp:ListItem Text="Aug" ></asp:ListItem>
                 <asp:ListItem Text="Sep" ></asp:ListItem>
                 <asp:ListItem Text="Oct" ></asp:ListItem>
                 <asp:ListItem Text="Nov" ></asp:ListItem> 
                 <asp:ListItem Text="Dec" ></asp:ListItem>

                </asp:DropDownList>
&nbsp;&nbsp;
                Year&nbsp;
                <asp:DropDownList ID="Year" runat="server" Height="16px" Width="51px">
              
              
               <asp:ListItem Text="2010"></asp:ListItem>
               <asp:ListItem Text="2011"></asp:ListItem>
               <asp:ListItem Text="2012"></asp:ListItem>
                </asp:DropDownList>
&nbsp; Day
                <asp:DropDownList ID="Day" runat="server" Height="18px" Width="46px">
                    
                </asp:DropDownList>
                &nbsp;&nbsp; </td>
            <td>
                Purpose:</td>
        </tr>
        <tr>
            <td class="style24">
                Time:</td>
            <td class="style25" style="width: 347px">
                &nbsp;&nbsp;From:
                <asp:DropDownList ID="hour" runat="server" Height="16px" Width="57px">
                  
                  <asp:ListItem Text="07"></asp:ListItem>
                  <asp:ListItem Text="08"></asp:ListItem>
                  <asp:ListItem Text="09"></asp:ListItem>
                  <asp:ListItem Text="10"></asp:ListItem>
                  <asp:ListItem Text="11"></asp:ListItem>
                  <asp:ListItem Text="12"></asp:ListItem>
                  <asp:ListItem Text="13"></asp:ListItem>
                  <asp:ListItem Text="14"></asp:ListItem>
                  <asp:ListItem Text="15"></asp:ListItem>
                  <asp:ListItem Text="16"></asp:ListItem>
                  <asp:ListItem Text="17"></asp:ListItem>
                  <asp:ListItem Text="18"></asp:ListItem>
                  <asp:ListItem Text="19"></asp:ListItem>
                  <asp:ListItem Text="20"></asp:ListItem>
                  <asp:ListItem Text="21"></asp:ListItem>
                  <asp:ListItem Text="22"></asp:ListItem>
                  
                
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="minutes" runat="server" Height="16px" Width="54px">
                
                <asp:ListItem Text="00"></asp:ListItem>
                <asp:ListItem Text="15"></asp:ListItem>
                <asp:ListItem Text="30"></asp:ListItem>
                <asp:ListItem Text="45"></asp:ListItem>
                
                </asp:DropDownList>
            &nbsp;&nbsp; To:<asp:DropDownList ID="hour2" runat="server" Height="16px" 
                    Width="54px">
                   
                  <asp:ListItem Text="07"></asp:ListItem>
                  <asp:ListItem Text="08"></asp:ListItem>
                  <asp:ListItem Text="09"></asp:ListItem>
                  <asp:ListItem Text="10"></asp:ListItem>
                  <asp:ListItem Text="11"></asp:ListItem>
                  <asp:ListItem Text="12"></asp:ListItem>
                  <asp:ListItem Text="13"></asp:ListItem>
                  <asp:ListItem Text="14"></asp:ListItem>
                  <asp:ListItem Text="15"></asp:ListItem>
                  <asp:ListItem Text="16"></asp:ListItem>
                  <asp:ListItem Text="17"></asp:ListItem>
                  <asp:ListItem Text="18"></asp:ListItem>
                  <asp:ListItem Text="19"></asp:ListItem>
                  <asp:ListItem Text="20"></asp:ListItem>
                  <asp:ListItem Text="21"></asp:ListItem>
                  <asp:ListItem Text="22"></asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="hour" 
                    ControlToValidate="hour2" ErrorMessage="*" Operator="GreaterThanEqual" 
                    SetFocusOnError="True"></asp:CompareValidator>
                &nbsp;&nbsp;
                <asp:DropDownList ID="minutes2" runat="server" Height="16px" Width="54px">
                
                <asp:ListItem Text="00"></asp:ListItem>
                <asp:ListItem Text="15"></asp:ListItem>
                <asp:ListItem Text="30"></asp:ListItem>
                <asp:ListItem Text="45"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="Purpose" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Purpose" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style24">
                &nbsp;</td>
            <td class="style25" style="width: 347px">
                <asp:Label ID="status" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Req" runat="server" Text="Request" Width="95px" 
                    onclick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Avail" runat="server" Text="Availability" Width="73px" 
                    onclick="Button2_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

