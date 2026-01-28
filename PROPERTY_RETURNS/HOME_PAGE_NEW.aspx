<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HOME_PAGE_NEW.aspx.cs" Inherits="PROPERTY_RETURNS.HOME_PAGE_NEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <link href="Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style-light.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
   
    <style type="text/css">
        .style1
        {
            color: #CC0000;
        }
    </style>
   
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

            $(function () {
                $("#txtDate").datepicker();
            });

        });


    </script>
   
    <h4>
        Welcome
        <%=Session["name"] %>, Please Select Your Option:</h4>
        <br />
        
    
     <fieldset style="width:100%"><legend><span class="style1">Current Status : ( <asp:Label ID="cstatus" 
            runat="server" Font-Size="Small" Text=""></asp:Label> )</span></legend>
   <div style="text-align: center; vertical-align: middle; height: 100%;">

   
          <table border="0" width="100%"  cellspacing="10" cellpadding="10" 
         style="border-collapse: collapse; text-align:center">
        <tr>
            <td>
                    <asp:Label ID="lblhld" runat="server" Text="Holding Related Options"></asp:Label><br />
                <asp:Button ID="RadioButton10" runat="server" Value="~/PROPERTY_RETURNS/DEPENDENTFORM1/DEPENDENTFORM1_ENTRY.aspx"
                    Text="Enter Form1 Details" Width="50%"   Enabled="False"
                    OnClick="RadioButton10_Click" CssClass="btn btn-info width300 " 
                    style="font-size: medium;   text-align:center" />
            </td>
        </tr>
       <hr />

        <tr>
            <td>
                <asp:Button ID="RadioButton1" runat="server" 
                    value="/PROPERTY_RETURNS/HOLDING/HOLDING.aspx" Enabled="False"
                    Text="Enter,Modify & Save Holdings" Width="50%" 
                    CssClass="btn btn-info width300 " 
                   style="font-size: medium;  text-align:center" onclick="RadioButton1_Click"/>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <%--<tr>
            <td>
                <asp:Button ID="RadioButton11" runat="server" 
                    Value="/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SAVED_HOLDINGS.aspx" Enabled="False"
                    Text="View, Print and Submit Saved Holdings_Prev" Width="50%" 
                    CssClass="btn btn-info width300 " 
                    style="font-size: medium; color: #000000;  text-align:center" onclick="RadioButton11_Click" Visible ="false"/>
            </td>
        </tr>--%>
       
       <%-- <tr>
            <td>
                &nbsp;</td>
        </tr>--%>
       
        <tr>
            <td>
                <asp:Button ID="RadioButton3" runat="server" 
                    Value="/PROPERTY_RETURNS/REPORTS_ASPX/SUBMIT_SAVED_HOLDINGS.aspx" Enabled="False"
                    Text="View, Print and Submit Saved Holdings" Width="50%" 
                    CssClass="btn btn-info width300 " 
                    style="font-size: medium;   text-align:center" onclick="RadioButton3_Click" Visible="True"/>
            </td>
        </tr>
      <%--  <tr>
            <td>
                &nbsp;</td>
        </tr>--%>
       
        <tr>
            <td>
                <%--<asp:Button ID="RadioButton4" runat="server" 
                    Value="/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SUBMITTED_HOLDINGS.aspx" Enabled="False"
                    Text="Print Submitted Holdings" Width="50%" 
                    CssClass="btn btn-info width300 " 
                    style="font-size: medium; color: #000000;  text-align:center" onclick="RadioButton4_Click"/>--%>
                <asp:Button ID="RadioButton4" runat="server" 
                    Value="~/REPORTS/MYRETURNS.aspx" Enabled="False"
                    Text="Print Submitted Holdings" Width="50%" 
                    CssClass="btn btn-info width300 " 
                    style="font-size: medium;   text-align:center" onclick="RadioButton4_Click"/>
            </td>
        </tr>
           <%--  <tr>
            <td>
                &nbsp;</td>
        </tr>  --%>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" 
                    Value="" Enabled="True"
                    Text="Print Submitted Extra Income Details" Width="50%" 
                    CssClass="btn btn-info width300 " 
                    style="font-size: medium;   text-align:center" onclick="ExtraIncome_Click"/>
            </td>
        </tr>
        <tr>
            <td><br />
                <asp:Label ID="lbltrn" runat="server" Text="Transaction Related Options" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RadioButton5" runat="server" 
                    Value="/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx" Enabled="False"
                    Text="Enter Transactions" Width="70%" onclick="RadioButton5_Click" 
                    CssClass="btn btn-warning width300 " style="font-size: medium; color: #000000;  text-align:center" Visible="False"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RadioButton6" runat="server" Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_HOLDINGS.aspx" 
                    Text="View & Print Saved Transactions" Enabled="False" Width="70%" 
                    CssClass="btn btn-warning width300 " style="font-size: medium;   text-align:center" 
                    onclick="RadioButton6_Click" Visible="False"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RadioButton7" runat="server" Value="/PROPERTY_RETURNS/FINAL_SUBMIT/ALL_TRN_SUBMIT.aspx" 
                    Text="View and Submit Transactions" Enabled="False" Width="70%"  Visible="False"
                    CssClass="btn btn-warning width300 " style="font-size: medium;   text-align:center" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RadioButton8" runat="server" Value="/PROPERTY_RETURNS/FORMS/MAIN_REPORT_HOLDINGS.aspx"
                    Text="Print Submitted Transactions" Enabled="False" Width="70%" Visible="False"
                    CssClass="btn btn-warning width300 " style="font-size: medium; color: #000000;  text-align:center" />
            </td>
        </tr>
        <tr>
            <td>
             <asp:Label ID="lblhldtrn" runat="server" Text="Holdings and Transactions/Corrections Thereafter" Visible="False"></asp:Label>
              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="RadioButton9" runat="server" Value="/PROPERTY_RETURNS/FORMS/PRINTONLY_HOLDINGD_TRNS_BOTH.aspx" 
                    Text="Print Submitted Holdings and Transactions" Enabled="False" Width="70%" 
                    CssClass="btn btn-success width300 " 
                   style="font-size: medium; color: #000000;  text-align:center" onclick="RadioButton9_Click" Visible="False"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="lblcatch" runat="server"></asp:Label>
                    <asp:Label ID="lblerr" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
   
       </div>
        </fieldset>
</asp:Content>
