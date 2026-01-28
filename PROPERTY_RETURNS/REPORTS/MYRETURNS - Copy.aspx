<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MYRETURNS.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS.MYRETURNS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" type="text/css" href="Scripts/StyleSheet.css" />
    <script src="../Scripts/jquery-1.11.0.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 251px;
        }
    </style>
        

        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000" 
        Text="All Property Returns Submitted By You Order by Holding Date, Property Type, and Status "></asp:Label>
    <div>
        <table class="auto-style2">
            <tr>
                <td style="width: 15%">        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#003366" 
        Text="Select Date" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Date" runat="server" DataSourceID="SqlDataSource1" DataTextField="showholdingdt" DataValueField="HOLDINGDT" Width="240px">
                        <asp:ListItem Selected ="True" Text ="--Select Holding Year --" Value =""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                    SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT
                    FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] order by holdingdt desc"></asp:SqlDataSource>
</asp:Content>
