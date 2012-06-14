<%@ Page Title = "Home Page" Language="C#" MasterPageFile ="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID = "Content1" runat = "server" ContentPlaceHolderID = "MainContentPlaceHolder"> 

    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
    </p>
   <table style="width: 639px; height: 187px">
   <tr>
   <td style="width: 184px">
   
       <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Resource" 
           Height="95px" ImageAlign="Right" ImageUrl="~/images/resource.jpg" 
           onclick="ImageButton1_Click" Width="126px" />
   
   </td>
   <td style="width: 202px">
   
       <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Notice" 
           Height="93px" ImageAlign="Right" ImageUrl="~/images/noticeboard.gif" 
           onclick="ImageButton2_Click" Width="106px" />
   
   </td>
   <td style="width: 214px">
   
   
       <asp:ImageButton ID="ImageButton3" runat="server" Height="82px" 
           ImageAlign="Right" ImageUrl="~/images/gate.jpg" onclick="ImageButton3_Click" 
           Width="105px" />
   
   
   </td>
   </tr>
   
   
   </table>
   
   
   
   <div style="border-style:hidden; float:left; width: 550px; height: 175px;">
     <h2 style="color:Red;">Updates</h2> 
       
     <asp:BulletedList ID="B_Update" runat="server" /> 
   
   </div>


</asp:Content>  

