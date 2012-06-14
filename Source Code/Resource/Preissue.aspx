<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="Preissue.aspx.cs" Inherits="Resource_Preissue" Title="Issue Resource" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
   
   
    <p style="text-align: left">
        Enter the Id of the Issuer :
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Issue" runat="server" Text="Get Items" Width="169px" 
            onclick="Issue_Click" />
    </p>
    <p>
        &nbsp;</p>

</asp:Content>

