<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="R_FORM1.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS_ASPX.R_FORM1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
        .style2
        {
            width: 100%;
        }
        #printablediv
        {
            
        }
        .style3
        {
            color: #000000;
            ;
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
    <div id="printablediv">
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
                <asp:TemplateField HeaderText="Public Position held ( if any ) "></asp:TemplateField>
                <asp:TemplateField HeaderText="Whether return being filed by him/ her, separately">
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="style1">
            <br class="style3" />
            <span class="style3">* Add more rows, if necessary.
                <br />
                <br />
        </div>
        <div style="page-break-after: always;">
        </div>
        <%--<asp:GridView ID="gv_cash" runat="server" AutoGenerateColumns="False" ShowHeader="False"
            Width="100%" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gv_insu" runat="server" AutoGenerateColumns="False" Width="100%"
            Style="text-align: left" ShowHeader="False" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gv_loan" runat="server" AutoGenerateColumns="False" Width="100%"
            Style="text-align: left" ShowHeader="False" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gv_motor" runat="server" AutoGenerateColumns="False" Width="100%"
            Style="text-align: left" ShowHeader="False" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gv_jewel" runat="server" AutoGenerateColumns="False" Width="100%"
            Style="text-align: left" ShowHeader="False" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>
       
        <asp:GridView ID="gv_other" runat="server" AutoGenerateColumns="False" Width="100%"
            Style="text-align: left" ShowHeader="False" EmptyDataText="Nil">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
            </Columns>
        </asp:GridView>--%>
       
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="javascript:printDiv('printablediv')" />
</asp:Content>
