<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PRINT_SAVED_HOLDINGS.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS_ASPX.PRINT_SAVED_HOLDINGS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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
            width: 341px;
        }
        .style6
        {
            width: 253px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
    <div id="printablediv" style="background-color: #FFFFFF">
    <asp:Panel ID="pnl_form1" runat="server">
        <div align="center">
            <span class="style3">FORM NO. I<br />
                Details of Public Servent, his / her spouse and dependent children </span>
        </div>
        <asp:GridView ID="gv_form1" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="15" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style3">
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
        <div class="style1">
            <br class="style3" />
            <span class="style3">* Add more rows, if necessary.
                <br />
                <br />
        </div>
        </asp:Panel> 
        <div style="page-break-after: always;">
        </div>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
        <asp:Panel ID="pnl_form3" runat="server">
        <div align="center">
            <span class="style3">FORM NO. III<br />
                Statement of imovable property on first appointment or as on 31st March, 20 .....<br />
                (e.g. Lands, House, Shops, Other Buildings etc.)<br />
                [ Held by Public Servernt, his/her spouse and dependent children ] </span>
        </div>
        <asp:GridView ID="gv_form3" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="15" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style3"
            HeaderStyle-VerticalAlign="Top" Font-Size="Smaller">
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
                <asp:BoundField DataField="TRNDT" HeaderText="Date of acquisition" ReadOnly="True"
                    SortExpression="TRNDT" Visible="True" />
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
        </div>
        <asp:GridView ID="gv_form4" runat="server" AutoGenerateColumns="False" Width="100%"
            CellPadding="15" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style3"
            HeaderStyle-VerticalAlign="Top">
            <Columns>
                <asp:TemplateField HeaderText="S No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:BoundField DataField="EMPNAME" HeaderText="Debtor (Self/spouse or dependent children)"
                    ReadOnly="True" SortExpression="EMPNAME" Visible="True" />
                <asp:BoundField DataField="creditor" HeaderText="Name and Address of Creditor" ReadOnly="True"
                    SortExpression="creditor" Visible="True" />
                 <asp:BoundField DataField="CURVAL"  HeaderText="Paid Amount" ReadOnly="True" SortExpression="CURVAL" />
                 <asp:BoundField DataField="Acq_Source"  HeaderText="Source of Funding" ReadOnly="True" SortExpression="Acq_Source" />
                <asp:BoundField DataField="nature_amt" HeaderText="Nature of debt / liability and amount"
                    ReadOnly="True" SortExpression="nature_amt" Visible="True" />
                <asp:BoundField DataField="REMARKS" HeaderText="Remarks " ReadOnly="True" SortExpression="REMARKS"
                    Visible="True" />
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
                    <td>
                        Signature __________________________________________</td>
                </tr>
            </table>
            <br /><hr style="background-color: #000000" />
        </div>
        <div style="position: fixed;top: 0;">
        Provisional Print
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="javascript:printDiv('printablediv')" />
</asp:Content>
