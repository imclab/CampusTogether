<%@ Page Language="C#" MasterPageFile="~/Resource/ResourceMasterPage.master" AutoEventWireup="true" CodeFile="ReturnResource.aspx.cs" Inherits="Resource_ReturnResource" Title="Return Resource" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <p>
        Enter Issuer&#39;s ID :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="user" runat="server" Width="167px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Show Issued Items" Width="166px" />
    </p>
    </asp:Content>

