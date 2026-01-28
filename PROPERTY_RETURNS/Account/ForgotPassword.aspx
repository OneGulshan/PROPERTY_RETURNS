<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="PROPERTY_RETURNS.Account.ForgotPassword" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/CustomeSite.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/select2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/modernizr.min.js" type="text/javascript"></script>   
    <script src="../Scripts/select2.min.js" type="text/javascript"></script>
    <script src="../Scripts/custom.js" type="text/javascript"></script>
  
</head>
<body class="signin" style="left: 50%; top: 10%; position: absolute; margin-left: -700px;">
    

    <form id="form1" runat="server">
    
      
    <div class="panel panel-signin"> 
            
            <asp:Panel ID="loginPanelBody" runat="server" CssClass="panel-body">           
                    <div class="logo text-center">
                          <img src="../Images/ntpc_logo.jpg" alt="NTPC Logo" style="height: 91px; width: 187px" />
                    </div>
                    <h4 class="text-center mb5">Property Return Application</h4>
                     <p class="text-center">Change your Password</p>
                    <div class="mb30"></div>
    
     
     <p>
                        <%--<asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password : </asp:Label>--%>
                        <asp:TextBox ID="uid" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </p>                     <p>
                        <%--<asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password : </asp:Label>--%>
                        <asp:TextBox ID="oldP" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </p>
                         <p>
                        <%--<asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password : </asp:Label>--%>
                        <asp:TextBox ID="newP" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </p>
                         <p>
                        <%--<asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password : </asp:Label>--%>
                        <asp:TextBox ID="repP" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </p>
    <%--<table>
    

                        <tr>
                                <td align="right" width="50%" 
                                         class="style1">User Id :</td>
                                <td width="50%" align="left" class="style1"><telerik:RadTextBox ID="uid" runat="server" TabIndex="1" CssClass="form-control"></telerik:RadTextBox></td>
                                </tr>
                                <tr>
                                <td align="right" width="50%" 
                                        class="style1">Existing Password :</td>
                                <td width="50%" align="left" class="style1"><telerik:RadTextBox ID="oldP" runat="server" TabIndex="1" TextMode="Password" CssClass="form-control"></telerik:RadTextBox></td>
                                </tr>
                                
                                <tr>
                                <td align="right" width="50%">New Password :</td>
                                <td width="50%" align="left"><telerik:RadTextBox ID="newP" runat="server" TabIndex="2" TextMode="Password" CssClass="form-control"></telerik:RadTextBox></td>
                                </tr>
                                <tr>
                                <td align="right" width="50%" >Repeat New Password :</td>
                                <td width="50%" align="left"><telerik:RadTextBox ID="repP" runat="server" TabIndex="3" TextMode="Password" CssClass="form-control"></telerik:RadTextBox></td>
                                </tr>
                                <tr style="height:50px">
                                            <td>
                                               <%-- <asp:Button ID="chngForgetPass" runat="server" CssClass="addButton1" 
                                                    Text="Change/Forgot Password" OnClick="chngForgetPass_Click" TabIndex="0" />
                                            </td>
                                            </tr>                                       
                                            </table>--%>
                                              <div class="clearfix">
                        <div class="pull-right">
                         <asp:Button ID="Button1" runat="server" Text="Change Password" 
                                ValidationGroup="LoginUserValidationGroup" class="btn btn-success" onclick="submit_Click"/>
                                               
                                            
                                </div>
                                </div>
                                 <div class="text-center">
                                
                                <a href="Login.aspx">Back To Login</a>
    </div>
    
    </asp:Panel>
    </div>
    
    </form>

</body>

</html>
