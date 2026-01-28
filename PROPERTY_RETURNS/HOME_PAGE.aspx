<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HOME_PAGE.aspx.cs" Inherits="PROPERTY_RETURNS.HOME_PAGE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<%--<meta http-equiv="X-UA-Compatible" content="IE=edge" />--%>
 <link href="Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style-light.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <%--<script src="Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>--%>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <%--<script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/jquery-2.1.1.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/jquery-ui-1.10.3.min.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-wizard.min.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#RadioDiv input').click(function () {
            $("#info").text('*' + $("#RadioDiv input:radio:checked").next().text());
//            $("#cmdSetValue").val("Go to : " + $("#RadioDiv input:radio:checked").next().text());
        });

        $("#cmdsetvalue").click(function () {
            var url = $("#RadioDiv input:radio:checked").val()
            $(location).attr('href', url);
        });

    });
 
</script>

    <%--<label style="font-weight:bold; color: #000000; font-size: large;">  Select Your Option :  </label>--%>
   <%--<div style="border-color: #e7e7e7; background-color: #f9f9f9;">--%>
    <%--<fieldset style="width:99%;">--%>
    <%--<legend style="font-family: Arial, Helvetica, sans-serif;color: #808080;">Welcome <%=Session["name"] %>, Please Select Your Option:</legend>--%>
    <h4>Welcome <%=Session["name"] %>, Please Select Your Option:</h4>
    <table border="1" width="100%"  bordercolorlight="#C0C0C0" cellspacing="0" cellpadding="0" bordercolordark="#C0C0C0" style="border-collapse: collapse" >
    <tr><td>
    <div>
    <div  id="RadioDiv" class="panel-body">
        <fieldset style="width:99% !important;">
        <legend>Holding Related Options</legend>
        <asp:RadioButton ID="RadioButton10" runat="server" Value="/PROPERTY_RETURNS/DEPENDENTFORM1/DEPENDENTFORM1_ENTRY.aspx" Text="Enter Form1 Details" GroupName="GP1"/><br>
        <asp:RadioButton ID="RadioButton1" runat="server" value="/PROPERTY_RETURNS/HOLDING/HOLDING.aspx" Text="Enter & Save Holdings as on 01.08.2014 (As per Lokpal & Lokayuktas act 2013)" GroupName="GP1"/><br>
        <asp:RadioButton ID="RadioButton2" runat="server" Value="/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SAVED_HOLDINGS.aspx" Text="View and Print Saved Holdings as on 01.08.2014" GroupName="GP1"/><br>
        <asp:RadioButton ID="RadioButton3" runat="server" Value="/PROPERTY_RETURNS/REPORTS_ASPX/SUBMIT_SAVED_HOLDINGS.aspx" Text="View and Submit Holdings as on 01.08.2014" GroupName="GP1"/><br>
        <asp:RadioButton ID="RadioButton4" runat="server" Value="/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SUBMITTED_HOLDINGS.aspx" Text="Print Submitted Holdings as on 01.08.2014" GroupName="GP1"/><br>
        
        <%--<asp:RadioButton ID="RadioButton11" runat="server" Value="/PROPERTY_RETURNS/FORMS/VIEW_SUBMIT_HOLDINGS.aspx" Text="Print Form 2" GroupName="GP1"/>--%>
        <%--<asp:RadioButton ID="RadioButton12" runat="server" Value="/PROPERTY_RETURNS/REPORTS_ASPX/PRINT_SAVED_HOLDINGS.aspx" Text="Print Form 1" GroupName="GP1"/>--%>
    </fieldset>
        <br />
        <br />
        <fieldset style="width:99% !important;">
        <legend>Transaction Related Options</legend>
        <asp:RadioButton ID="RadioButton5" runat="server" Value="/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx" Text="Enter Transactions done between 01.08.2014 To 31.03.2015" GroupName="GP1" Enabled="False" /><br>
        <asp:RadioButton ID="RadioButton6" runat="server" Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_HOLDINGS.aspx" Text="View and Print Saved Transactions" GroupName="GP1" Enabled="False" /><br>
        <asp:RadioButton ID="RadioButton7" runat="server" Value="/PROPERTY_RETURNS/FINAL_SUBMIT/ALL_TRN_SUBMIT.aspx" Text="View and Submit Transactions" GroupName="GP1" Enabled="False" /><br>
        <asp:RadioButton ID="RadioButton8" runat="server" Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_HOLDINGS.aspx" Text="Print Submitted Transactions" GroupName="GP1" Enabled="False" /><br>
    </fieldset>
        <br />
        <br />
        <fieldset style="width:99% !important;">
        <legend>Holdings and Transactions/Corrections Thereafter</legend>
        <asp:RadioButton ID="RadioButton9" runat="server" Value="/PROPERTY_RETURNS/FORMS/RP_SUBMITTED_TRNHOLD.aspx" Text="Print Submitted Holdings with transactions/correction thereafter" GroupName="GP1" Enabled="False" />
    </fieldset>
    </div>
      <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="/PROPERTY_RETURNS/HOLDING/HOLDING.aspx" Text="Enter Holdings as on 01.08.2014(As per Lokpal & Lokayuktas act 2013) "></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx" Text="Enter Transactions done between 01.01.2014 To 31.03.2015 "></asp:ListItem>
             <asp:ListItem Value="/PROPERTY_RETURNS/HOLDING/HOLDING.aspx" Text="Enter Holdings as on 31.08.2014(As per Lokpal & Lokayuktas act 2013)"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/FINAL_SUBMIT/ALL_TRN_SUBMIT.aspx" Text="Submit Transactions(Final)"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_TRANSACTION.aspx" Text="View Submitted Transactions"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_REVIEW.aspx" Text="View and Submit Returns"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/PRINT.aspx" Text="Print Submitted Holdings as on 31.08.2014"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/PRINT.aspx" Text="Print Submitted Holdings with correction entries made till 30.04.2015"></asp:ListItem>
            <asp:ListItem Value="/PROPERTY_RETURNS/DEPENDENTFORM1/DEPENDENTFORM1_ENTRY.aspx" Text="Enter Form1 Details"></asp:ListItem>
        </asp:RadioButtonList>--%>
  
    
    </div>
    <div id="info" style="font-weight:bold; height: 30px; color: #808080; font-size: medium; font-family: Arial, Helvetica, sans-serif;"></div> 
    <div class="panel-footer">
        <br />
        <span id="cmdsetvalue" Class="btn btn-success width300">Go</span>
        
    </div>
    </td>
	</tr>
</table>

</asp:Content>
