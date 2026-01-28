<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chkuid.aspx.cs" Inherits="PROPERTY_RETURNS.Account.chkuid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
 <%--   <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/CustomeSite.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/select2.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>

    <script src="../Scripts/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/modernizr.min.js" type="text/javascript"></script>   
    <script src="../Scripts/select2.min.js" type="text/javascript"></script>
    <script src="../Scripts/custom.js" type="text/javascript"></script>--%>
    <%--<script src="http://tomcat.ntpc.co.in:8080/EPSSO/js/jquery-1.10.2.min.js"></script>--%> 
    <%--<script src="https://teamup.ntpclakshya.co.in:8443/EPSSOPRD/js/cookieChecker.js"></script>
    <script src="https://teamup.ntpclakshya.co.in:8443/EPSSOPRD/js/jquery-1.10.2.min.js"></script>--%>

    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="https://teamup.ntpclakshya.co.in:9443/EPSSOPRD/js/cookieChecker.js"></script>
	<%--<script src="http://tomcat.ntpc.co.in:8080/EPSSO/js/cookieChecker.js"></script>--%>
    


</head>
<body>
<script>
    if (!checkCookie())
        redirect();		
</script>
    <form id="form1" runat="server">
    <div>
         <asp:Label ID="Label1" runat="server" Text="Label" visible="false">
         </asp:Label><asp:Label ID="Label2" runat="server" Text="Label" visible="false"></asp:Label>
    </div>
    <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
