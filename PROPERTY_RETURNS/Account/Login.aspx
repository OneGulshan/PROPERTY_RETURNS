<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROPERTY_RETURNS.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title></title>
    <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/CustomeSite.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/select2.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.gritter.min.js" type="text/javascript"></script>
    <script src="../Scripts/modernizr.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowCallSuccessMessage() {
            $.gritter.add({
                title: 'Success',
                text: 'Data Saved Successfully',
                class_name: 'growl-success gritter-center',
                sticky: false,
                time: '2000',
                after_close: function () {
                    // setTimeout($(location).attr('href', '../HOME_PAGE_NEW.aspx'), 100000);
                }
            });
            return false;
        }

        function ShowCallErrorMessage() {
            $.gritter.add({
                title: 'Error',
                text: 'Invalid User ID / Password',
                class_name: 'growl-error gritter-center',
                sticky: false,
                time: '2000'
            });

            return false;
        }
    </script>
    <style type="text/css">
        .captcha-image {
            border: 1px solid #d9d9d9;
            border-radius: 4px;
            background-color:lightgoldenrodyellow; /*#f9f9f9;*/
            box-shadow: 0 1px 3px rgba(0,0,0,0.1);
            padding: 3px;
            width: 160px;
            height: 40px;
            display: inline-block;
        }
    </style>
</head>
<body class="signin">


    <div class="panel panel-signin">
        <form id="formLogin" runat="server">

            <asp:Panel ID="loginPanelBody" runat="server" CssClass="panel-body">
                <div class="logo text-center">
                    <img src="../Images/ntpc_logo.jpg" alt="NTPC Logo" style="height: 91px; width: 187px" />
                </div>
                <p style="color: Green; font-size: small">
                    <marquee direction="left" width="99%">User Id is six(6) digit Employee Number and Password is your AD Password </marquee>
                </p>
                <h4 class="text-center mb5">NTPC PROPERTY RETURNS APPLICATION</h4>

                <p class="text-center">
                    Sign in to your account with AD Credentials
                </p>
                <asp:Panel ID="pnlLoginInputs" runat="server">
                    <div class="mb30"></div>
                    <fieldset>
                        <span class="failureNotification">
                            <asp:Literal ID="failureText" runat="server"></asp:Literal>
                        </span>
                        <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                            ValidationGroup="LoginUserValidationGroup" />
                        <telerik:RadScriptManager ID="Radscriptmanager1" runat="server"
                            EnablePageMethods="True">
                        </telerik:RadScriptManager>
                        <div class="text-center">

                            <table>
                                <tr style="height:40Px;">
                                    <td width="50%"align="right" style="font-family: Arial;width:100%;">User ID :</td>
                                    <td width="50%"align="left">
                                        <telerik:RadTextBox ID="txtUserName" runat="server" TabIndex="1" autocomplete="off" CssClass="form-control"></telerik:RadTextBox></td>
                                </tr>

                                <tr style="height: 40px;">
                                    <td align="right" width="50%" style="font-family: Arial;">Password :</td>
                                    <td width="50%" align="left">
                                        <telerik:RadTextBox ID="txtPassword" runat="server" TabIndex="2" TextMode="Password" autocomplete="off">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <!-- CAPTCHA Image -->
                                    <td align="right" width="25%" style="font-family: Arial;">Captcha : </td>
                                    <td width="50%" align="left">
                                        <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/Account/CaptchaImage.aspx" CssClass="captcha-image" />
                                    </td>
                                    <!-- Refresh CAPTCHA -->
                                    <td width="25%" align="left">
                                        <asp:LinkButton ID="lnkRefreshCaptcha" runat="server" OnClick="lnkRefreshCaptcha_Click">Refresh</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr style="height: 35px;">
                                    <td align="right" width="50%" style="font-family: Arial;">Input Captcha : </td>
                                    <td width="50%" align="left">
                                        <!-- CAPTCHA Input -->
                                        <telerik:RadTextBox ID="txtCaptcha" runat="server"></telerik:RadTextBox>
                                    </td>
                                </tr>

                            </table>
                        </div>
                    </fieldset>
                    <div class="mb30"></div>
                    <div class="clearfix">
                        <div class="pull-right">
                            <asp:Button ID="btnLogin" runat="server" Text="Log In"
                                ValidationGroup="LoginUserValidationGroup" class="btn btn-success" OnClick="LoginButton_Click" />
                        </div>
                    </div>
                     <div class="mb30"></div>
                    <div align="left">
                        <%-- <a href="https://mapp.ntpc.co.in/CCAuth/authenticate/Forgotpassword" target="_blank">Reset Password</a>--%>
                        <a href="https://passwordreset.microsoftonline.com/passwordreset#!/" target="_blank">Reset AD Password</a>
                    </div>

                </asp:Panel>
                <!-- OTP Verification Panel -->
                <asp:Panel ID="pnlOtpVerification" runat="server" Visible="false" CssClass="otp-panel">
                    <div class="mb30"></div>
                    <table>
                        <tr style="height: 35px;">
                            <td align="right" width="50%" style="font-family: Arial;">Enter OTP:</td>
                            <td width="50%" align="left">
                                <telerik:RadTextBox ID="txtOtp" runat="server" TabIndex="4" autocomplete="off"></telerik:RadTextBox>
                            </td>
                        </tr>
                        
                        <tr style="height: 35px;">
                            <td><div class="mb30"></div></td>
                            <td>
                                <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP" CssClass="btn btn-primary" OnClick="btnVerifyOtp_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

            <asp:Label ID="lblcatch" runat="server"></asp:Label>
            <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button ID="btnLogout" runat="server" Text="Log Out" Visible="false"
                ValidationGroup="LoginUserValidationGroup" class="btn btn-link" OnClick="btnLogout_Click" />
        </form>
    </div>
</body>
</html>
