<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRINTONLY_SUBMITTED_TRNS.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS_ASPX.PRINTONLY_SUBMITTED_TRNS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style-light.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap-wizard.min.js" type="text/javascript"></script>
    <style>
    body {
        height: 850px;
        width: 800px;
        /* to centre page on screen*/
    margin-top: 0px;
    margin-bottom: 150px;
    margin-right: auto;
    margin-left: auto;
    }
     .style1
        {
            text-align: left;
        }
        #printablediv
        {
        }
        .style3
        {
            color: #000000;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 30%;
        }
        .style6
        {
            width: 30%;
        }
    </style>
   <style media="print">

                .MyCssClass thead
                {
                    display: table-header-group;
                }

    </style>

<script type = "text/javascript">
    function printDiv(divID) {

        //Get the HTML of div
        var divElements = document.getElementById(divID).innerHTML;
        //Get the HTML of whole page
        var oldPage = document.body.innerHTML;

        //Reset the page's HTML with div's HTML only
        document.body.innerHTML =
              "<html><head></head><body>" +
              divElements + "</body>";

        //Print Page
        window.print();

        //Restore orignal HTML
        document.body.innerHTML = oldPage;
    }

    function OnClose() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.HideModalDiv();
        }
    }
    window.onunload = OnClose;
</script>

</head>
<body onload="javascript:printDiv('printablediv')">

    <form id="form1" runat="server">
   <div style="text-align:right">
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="javascript:printDiv('printablediv')" />
    </div>
    <div class="tab-content">
    <div  id="printablediv" style="background-color: #FFFFFF">
    <asp:Panel ID="pnl_form0" runat="server" ClientIDMode="static">
                <table border="0" width="100%" cellpadding="0">
                    
                    <tr>
                        <td>
                            <p align="center"><br />
                                <b><font size="3">Return of Assets and Liabilities on First Appointment or as on the 
                                    <asp:Label ID="lblhldt" runat="server" Font-Underline="True"></asp:Label></font><br>
                                    (Under Sec 44 of the Lokpal and Lokayuktas Act, 2013)</b><br /></td>
                    </tr>
                    <tr>
                        <td>
                            1. Name of the Public Servant in full
                            <asp:Label ID="lblempname" runat="server" Font-Underline="True"></asp:Label>
                            <br>
                            &nbsp;&nbsp;&nbsp;&nbsp;(in block letters)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. (a) Present public position held
                            <asp:Label ID="lblppheld" runat="server" Font-Underline="True"></asp:Label>
                            <br>
                            &nbsp;&nbsp;&nbsp;&nbsp;(Designation, name and address Of organization)
                            <asp:Label ID="lblorgn0" runat="server" Font-Underline="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;(b) Service to which belongs …………………………………...............…………..<br>
                            &nbsp;&nbsp;&nbsp;&nbsp;(if applicable)<br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Declaration:<br>
                            <br>
                            I hereby declare that the return enclosed namely, Forms I to IV are complete, true
                            and correct to the best of my knowledge and belief, in respect of information due
                            to be furnished by me under the provisions of section 44 of the Lokpal and Lokayuktas
                            Act, 2013.<br>
                            <br>
                           <%-- <br />
                            Date&nbsp;&nbsp; ……………….<div style='text-align:right;'> Signature&nbsp;&nbsp; ……………………</div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            *In case of first appointment please indicate date of appointment.<br>
                            <br>
                            ------------------------------------------------------------------------------
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Note1: This return shall contain particulars of all assets and liabilities of the
                            public servant either in his / her own name or in the name of any other person.
                            The return should include details in respect of assets / liabilities of spouse and
                            dependent children as provided in Section 44(2) of the Lokpal and Lokayuktas Act,
                            2013.<br>
                            (Section 44(2): A public servant shall, within a period of thirty days from the
                            date on which he makes and subscribes an oath or affirmation to enter upon his office,
                            furnish to the competent authority the information relating to:<br>
                            (a) the assets of which he, his spouse and his dependent children are, jointly or
                            severally, owners or beneficiaries.<br>
                            (b) His liabilities and that of his spouse and his dependent children.
                            <br><br />
                            Note2. If a public servant is a member of Hindu Undivided Family with co-parcenary
                            rights in the properties of the family either as a 'Karta' or as a member, he should
                            indicate in the return in the Form No.III the value of his share in such property
                            and where it is not possible to indicate the exact value of such share, its approximate
                            value. Suitable explanatory notes may be added wherever necessary.<br><br />
                            Note3 &quot;dependent children&quot; means sons and daughters who have no separate
                            means of earning and are wholly dependent on the public servant for their livelihood.
                            (Explanation below Section 44(3) of Lokpal and Lokayuktas Act, 2013).
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="page-break-after: always;"></div>
     <asp:Panel ID="pnl_form1" runat="server">
        <div align="center">
            <span class="style3">FORM NO. I<br />
                Details of Public Servent, his / her spouse and dependent children </span>
        </div>
        <asp:GridView ID="gv_form1" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="15" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style3" EmptyDataText="Nil">
            <Columns>
                <asp:TemplateField HeaderText="S No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO"
                    Visible="false" />
                <asp:BoundField DataField="PERNR" HeaderText="PERNR" ReadOnly="True" SortExpression="PERNR"
                    Visible="false" />
                <asp:BoundField DataField="SUBTY" HeaderText="SUBTY" ReadOnly="True" SortExpression="SUBTY"
                    Visible="false" />
                <asp:BoundField DataField="OBJPS" HeaderText="OBJPS" ReadOnly="True" SortExpression="OBJPS"
                    Visible="false" />
                <asp:BoundField DataField="EMPNAME" HeaderText="EMPNAME" ReadOnly="True" SortExpression="EMPNAME" />
                <asp:BoundField DataField="RELATION" HeaderText="RELATION" ReadOnly="True" SortExpression="RELATION" />
               <asp:BoundField DataField="ppheld" HeaderText="Public Position held ( if any )" ReadOnly="True" SortExpression="ppheld" />
                <asp:BoundField DataField="return1" HeaderText="Whether return being filed by him/ her, separately" ReadOnly="True" SortExpression="return1" />
            </Columns>
        </asp:GridView>
        <br />
                     *Declared by employee as "Not dependent children" wrt Property Returns.<br />
As per the explanation given under Sec. 44 of the Lokpal & Lokayukta Act, the definition regarding declaration of assets is as under:
For the purpose of this Sec., “dependent children” means sons and daughters who have no separate means of earning and are wholly dependent on the public servant for their livelihood.

        </asp:Panel> 
        <div style="page-break-after: always;">
        </div>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <asp:Panel ID="pnl_form3" runat="server">
        <div align="center">
            <span class="style3">FORM NO. III<br />
                Statement of imovable property on first appointment or as on 
                <asp:Label ID="hlddt2" runat="server" Text="" Font-Underline="True"></asp:Label><br />
                (e.g. Lands, House, Shops, Other Buildings etc.)<br />
                [ Held by Public Servernt, his/her spouse and dependent children ] </span>
        </div>
        <div class="MyCssClass">
        <asp:GridView ID="gv_form3" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="1" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
            HeaderStyle-VerticalAlign="Top" Font-Size="Smaller" EmptyDataText="Nil" OnRowDataBound="gv_form3_OnRowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="S No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:BoundField DataField="ASCATDESC" HeaderText="Description of property ( Land / House / Flat / Shop / Industrial etc."
                    ReadOnly="True" SortExpression="ASCATDESC" Visible="True" HeaderStyle-Width="50px"
                    ItemStyle-Width="50px" />
                <asp:BoundField DataField="Address" HeaderText="Precise Location ( Name of District, Division Taluk and Village in which the property is situated and also its distinctive number etc.)"
                    ReadOnly="True" SortExpression="Address" Visible="True" HeaderStyle-Width="80px"
                    ItemStyle-Width="80px" />
                <asp:BoundField DataField="qty_unit" HeaderText="Area of land ( In case of land and buildings )"
                    ReadOnly="True" SortExpression="qty_unit" Visible="True" />
                <asp:BoundField DataField="Description" HeaderText="Nature of land in case of landed property"
                    ReadOnly="True" SortExpression="Description" Visible="True" />
                <asp:BoundField DataField="SHRPC" HeaderText="Extent of interest" ReadOnly="True"
                    SortExpression="SHRPC" Visible="True" />
                <asp:BoundField DataField="EMPNAME" HeaderText="If not in name of public servernt, state in whose name held and his/her relationship, if any to the public servent"
                    ReadOnly="True" SortExpression="EMPNAME" Visible="True" />
                <asp:BoundField DataField="ACQDT" HeaderText="Date of acquisition" ReadOnly="True"
                    SortExpression="ACQDT" Visible="True" />
                <asp:BoundField DataField="acdsourcedesc" HeaderText="How acquired (whether by purchase, mortgage, lease, inheritance, gift or otherwise) and name with details of persons from whom acquired (address and connection of the Government servent, if any with the person / persons concerned) (Please see note 1 below) and cost of acquisition"
                    ReadOnly="True" SortExpression="acdsourcedesc" Visible="True" />
                <asp:BoundField DataField="CURVAL" HeaderText="Present value of the property ( If exact value is not known, approx value may be indicated )"
                    ReadOnly="True" SortExpression="CUR_VAL" Visible="True" />
                <asp:BoundField DataField="ANINCM" HeaderText="Total annual income from the property "
                    ReadOnly="True" SortExpression="ANINCM" Visible="True" />
                <asp:BoundField DataField="REMARKS" HeaderText="Remarks " ReadOnly="True" SortExpression="REMARKS"
                    Visible="True" />
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <span class="style3">Note(1): For purpose of Column 9, the term "lease" would mean a
            lease of immovable property from year to year or for any term exceeding one year
            or reserving a yearly rent. Where, however, the lease of immovable property is obtained
            from person having official dealings with the Government servent, such a lease should
            be shown in this Column irrespective of the term of lease, whether it is short term
            or long term, and the periodicity of the payment of rent. </span>
        </asp:Panel>
        <div style="page-break-after: always;">
        </div>
        <asp:Panel ID="pnl_form4" runat="server">
        <div align="center">
            <span class="style3">FORM NO. IV<br />
            Statement of Debts and Other Liabilities on first appointment or as on 
            <asp:Label ID="hlddt3" runat="server" Text="" Font-Underline="True"></asp:Label>
        </div>
        <asp:GridView ID="gv_form4" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="15" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style3"
            HeaderStyle-VerticalAlign="Top" EmptyDataText="Nil">
            <Columns>
                <asp:TemplateField HeaderText="S No">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label3" runat="server" Text="*"></asp:Label>--%>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:BoundField DataField="EMPNAME" HeaderText="Income Owner (Self/spouse or dependent children)"
                    ReadOnly="True" SortExpression="EMPNAME" Visible="True" />
                   
                 <asp:BoundField DataField="nature_amt" HeaderText="Nature of amount"
                    ReadOnly="True" SortExpression="nature_amt" Visible="True" />
               <asp:BoundField DataField="Acq_Remarks"  HeaderText="Source of Funding" ReadOnly="True" SortExpression="Acq_Remarks" />
                <asp:BoundField DataField="ANINCM" HeaderText="Amount earned during the period "
                    ReadOnly="True" SortExpression="ANINCM" Visible="True" />
               <asp:BoundField DataField="REMARKS"    HeaderText="REMARKS" ReadOnly="True" />
            </Columns>
        </asp:GridView>
        <br />
        Note1: Individual items of loans not exceeding two months basic pay (where applicable)
        and Rs. 1.00 lakh in other cases need not be included.
        <br />
        Note2: The statement should include various loans and advances (exceeding in value
        in Note 1) taken from banks, companies, financial institutions, Central / State
        Government and from individuals.
        </asp:Panel>
        <div style="position: fixed;bottom: 0;">
            <table class="style4">
                <tr>
                    <td class="style6">
                        Date</td>
                    <td class="style5">
                        Printed On :
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        Signature ____________</td>
                </tr>
            </table>
            <br /><hr style="background-color: #000000" />
        </div>
       <div style="position: fixed;top: 0;">
        <u>Emp No: 
            <asp:Label ID="lblempno" runat="server" Text=""></asp:Label></u>
        </div>
    </div>
    </div>
    <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
