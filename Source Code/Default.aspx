<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title = "Campus Connect - One Stop solution to everything" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
<title>Campus Together</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link rel="stylesheet" type="text/css" href="default.css" />
    <style type="text/css">
        #form1
        {
            height: 306px;
            width: 694px;
        }
        .style13
        {
            font-size: large;
            font-weight: bold;
        }
        .style14
        {
            width: 456px;
        }
        .style15
        {
            color: #FF6600;
        }
        .style16
        {
            font-size: medium;
        }
        .style17
        {
            width: 456px;
            height: 25px;
        }
        .style18
        {
            color: #FF6600;
            height: 25px;
        }
        </style>
</head>
<body>
  <link rel = "shortcut icon" href = "images/pic.jpg">  
  <div id="upbg"></div>
    <div id="outer">
    <div id="header">
	</div>   
	<div id="headerExtra">
	</div>   
	<div id="headerpic"></div>
	<div id = "form11">
    <form id="form1" runat="server">	    
           <table align="right">
        <tr>
        <td><b>UserName</b>        
        <asp:TextBox ID="T_User" runat="server" style =" text-align : left;"></asp:TextBox>  
        </td>
        <td align="left">        
            <b>Password</b>
        <asp:TextBox ID="T_Pass" runat="server" TextMode="Password" Width="128px" style =" text-align : left;"></asp:TextBox>                            
        </td>
        <td>
        <asp:Button ID="B_Login" runat="server" onclick="B_Login_Click" Text="Login" 
                            Width="77px" BackColor="#999966" BorderColor="#663300" 
                Font-Bold="True" ForeColor="White" />                           
        </td>                    
        </tr>
        <tr>
        <td>
        </td>
        
        <td align ="right" >
        <asp:Label ID="L_Status" runat="server"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ErrorMessage="Empty UserName Field" ControlToValidate="T_User"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
                                 ID="RegularExpressionValidator1" runat="server" ControlToValidate="T_User" 
                                 ErrorMessage="InValid UserID"
                                 ValidationExpression="^[2][0][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"></asp:RegularExpressionValidator>
        </td></tr>
        </table>             
                 <table style="width:100%;">
                 <tr>
                 <br />
                 </tr>
                 <tr>
                 <br />
                 </tr>
                 <tr>
                 <br />
                 </tr>
                     <tr>                     
                         <td class="style17" align="left">
                             <span class="style13" style="color: #808000">Welcome to Campus Together! 
                             
                             </span>
                         </td>
                         <td class="style18" align="center">           
                             </td>
                     </tr>
                     <tr>
                     
                         <td class="style14">
                             &nbsp;</td>
                         <td class="style15">           
                                        
                         </td>
                     </tr>
                     <tr>
                         <td class="style14">
                             <b>
                             <span class="style16">One stop solution for 
                             <br />
                             </span> </b>
                             <br />
                             <b><i>Gate entry</i></b> - Facilitates systematic and fast in/out entry of 
                             students, faculty and staff with report generation .
                             <br />
                             <br />
                             <b><i>Inventory management/resource allocation</i> - </b>Facilitates students, 
                             faculty, administrators, staff to have a look at the resources reserved and 
                             available at any given time.<br />
                             <br />
                             <b><i>Access to Notices and 
                 THelps users to access various 
                             notice boards online anytime to be aware of latest around the campus.<br />
                         </td>
                         <td align="left" valign="top">               
           
                             <br />
                             <br />
                             <br />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;<br />
                             <br />
                             <br />
                             <br />
                         </td>
                     </tr>
                 </table>         
    <div id="footer">
			<div class="left">All rights reserved. © 2010 Campus Togethern | Software Engineering</div>
	</div>
    </form>	
    </div>
</div>    
</body>
</html>
