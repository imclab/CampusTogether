<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNotice.aspx.cs" Inherits="NoticeContent_AddNotice" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table style="width: 100%; height: 235px;">
        <tr>
            <td style="width: 60px">
                <b>Subject</b></td>
            <td align="left">
                <asp:TextBox ID="T_Sub" runat="server" MaxLength="25" Width="364px" style =" text-align : left;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="T_Sub" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 60px" valign="top">
                <b>Body</b></td>
            <td align="left">
                <asp:TextBox ID="T_Body" runat="server" Height="151px" TextMode="MultiLine" 
                    Width="364px" style =" text-align : left;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="T_Body" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 60px">
                &nbsp;</td>
            <td colspan="2" align="left">
&nbsp;<asp:Button ID="B_Submit" runat="server" onclick="B_Submit_Click" 
                    Text="Submit" />
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="B_Clear" runat="server" onclick="B_Clear_Click" Text="Clear" />
            </td>
        </tr>
        
    </table>
    <script type ="text/javascript">
    function addFileUpload()
    {
        if(!document.getElementById || !document.createElement)        
            return false;
        var uploadArea = document.getElementById("upload-area");
        if(!uploadArea)
            return;
        
        var newline = document.createElement("br");
        uploadArea.appendChild(newline);
        
        var newUpload = document.createElement("input");
        newUpload.type = "file";
        newUpload.size = "60";
        
        if(!addFileUpload.lastAssignedId)
            addFileUpload.lastAssignedId = 100;
            
        newUpload.setAttribute("id","FileField" + addFileUpload.lastAssignedId);
        newUpload.setAttribute("name","FileField" + addFileUpload.lastAssignedId);
        uploadArea.appendChild(newUpload);
        addFileUpload.lastAssignedId++;
    }
    </script>
</asp:Content>

