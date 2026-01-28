<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROPERTY_RETURNS.Login" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/CustomeSite.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/select2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
<!--    <script src="http://tomcat.ntpc.co.in:8080/EPSSO/js/jquery-1.10.2.min.js"></script> -->
    <script src="../Scripts/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/modernizr.min.js" type="text/javascript"></script>   
    <script src="../Scripts/select2.min.js" type="text/javascript"></script>
    <script src="../Scripts/custom.js" type="text/javascript"></script>
	<script src="http://tomcat.ntpc.co.in:8080/EPSSO/js/cookieChecker.js"></script>
    <title></title>
</head>
<body class="signin" style="left: 50%; top: 10%; position: absolute; margin-left: -700px;">
<script>
//    if (!checkCookie())
//        redirect();		
</script>

   
        <div class="panel panel-signin"> 
            <form method="post"  id="formLogin"  runat="server">
            <asp:Panel ID="loginPanelBody" runat="server" CssClass="panel-body">           
                    <div class="logo text-center">
                          <img src="../Images/ntpc_logo.jpg" alt="NTPC Logo" style="height: 91px; width: 187px" />
                    </div>
                    <h4 class="text-center mb5">Property Return Application</h4>
                    
                    <p class="text-center">Sign in to your account</p>
                    
                    <div class="mb30"></div>
                    <fieldset>
                    <span class="failureNotification">
                        <asp:Literal ID="failureText" runat="server"></asp:Literal>
                    </span>                    
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="LoginUserValidationGroup"/>
                         <telerik:RadScriptManager ID="Radscriptmanager1" runat="server" EnablePageMethods="true"></telerik:RadScriptManager>
                         <div class ="text-center" >
                                <table>
                                <tr style="height:35px;">
                                <td align="right" width="50%" style="font-family: Arial;">User ID :</td>
                                <td width="50%" align="left"><telerik:RadTextBox ID="txtUserName" runat="server" TabIndex="1"></telerik:RadTextBox></td>
                                </tr>
                                <tr style="height:35px;">
                                <td align="right" width="50%" style="font-family: Arial;">Password :</td>
                                <td width="50%" align="left"><telerik:RadTextBox ID="txtPassword" runat="server" TabIndex="2" TextMode="Password"></telerik:RadTextBox></td>
                                </tr>
                                </table>
                                 
                                    <%--<asp:TextBox ID="empno" runat="server" CssClass="textboxStyle" 
                                        placeholder="Enter Your EmpNo" TabIndex="1"></asp:TextBox>
                                    <br />
                                   <%-- <asp:TextBox ID="password" runat="server" CssClass="textboxStyle" 
                                        placeholder="Enter Your Password"  TextMode ="password" TabIndex="2"></asp:TextBox>--%>
                                 
                                 </div>

                                 </fieldset>

                   <%--  <p>    
                        <%--<asp:Label ID="lblUserName" runat="server" AssociatedControlID="txtUserName" CssClass="control-label">Email/Mobile : </asp:Label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Id"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" 
                            CssClass="failureNotification" ErrorMessage="User Id is required." ToolTip="User Id is required." 
                            ValidationGroup="LoginUserValidationGroup">&nbsp;</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <%--<asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password : </asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" 
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                ValidationGroup="LoginUserValidationGroup">&nbsp;</asp:RequiredFieldValidator>
                    </p>          --%>
                     <div class="mb30"></div>
                     <div class="clearfix">
                        <div class="pull-right">
                            <asp:Button ID="btnLogin" runat="server" Text="Log In" 
                                ValidationGroup="LoginUserValidationGroup" class="btn btn-success" onclick="btnLogin_Click"/>
                        </div>
                    </div>
                     <div class="mb30"></div>
                    <div class="text-center">
                        <p>
                            <%--<asp:HyperLink NavigateUrl="~/Account/ForgotPassword.aspx" Target="_blank" runat="server"  Text="Forgot Password?"></asp:HyperLink>--%>
                            <%--<a href="ForgotPassword.aspx">Change Password</a>--%>
                        </p>
                    </div>                      
                                    
                </asp:Panel>
                
            <%--<asp:Panel ID="loginPanelFooter" runat="server" class="panel-footer">           
                    <div class="logo text-center">
                          <img src="../Images/NESCL_Logo.png" alt="NESCL Logo" />
                    </div>                    
                    <h4 class="text-center mb5">Project Monitoring System</h4>
                    <p class="text-center control-label">Select Project & Proceed</p>
                    <asp:DropDownList ID="ddlProjects" runat="server" style="width:317px"></asp:DropDownList><br /><br />
                    <div class="clearfix">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-default pull-left" onclick="btnCancel_Click"/>
                        <asp:Button ID="btnProceed" runat="server" Text="Proceed" class="btn btn-primary pull-right" onclick="btnProceed_Click"/>
                    </div>
                </asp:Panel>--%>
               
            </form>
        </div>            
   
</body>
</html>
