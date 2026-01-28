<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excep_dtl.aspx.cs" Inherits="PROPERTY_RETURNS.FORMS.excep_dtl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
    <telerik:RadScriptManager ID="Radscriptmanager2" runat="server" ></telerik:RadScriptManager>
    <fieldset style="vertical-align:top;">
      <legend style="font-weight:bold; font-family:Calibri;"> Details of Property Returns for Empno. <asp:Label ID="lblemp" runat="server" Text="" style="font-weight:bold;"></asp:Label>:</legend>
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" DataSourceID="SqlDataSource1" GridLines="None" AutoGenerateColumns="False" style="align-content:center">

<MasterTableView DataSourceID="SqlDataSource1" Name="excep">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="PERNR" FilterControlAltText="Filter PERNR column" HeaderText="EMPNO" SortExpression="PERNR" UniqueName="PERNR">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NAME" FilterControlAltText="Filter NAME column" HeaderText="NAME" ReadOnly="True" SortExpression="NAME" UniqueName="NAME">
             <HeaderStyle Width="80px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="project" FilterControlAltText="Filter project column" HeaderText="LOCATION" SortExpression="project" UniqueName="project">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="YEAR" DataType="System.Int32" FilterControlAltText="Filter YEAR column" HeaderText="YEAR" SortExpression="YEAR" UniqueName="YEAR">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="IM1" DataType="System.Decimal" FilterControlAltText="Filter IM1 column" HeaderText="IMMOVALBLE Prev" SortExpression="IM1" UniqueName="IM1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="IM2" DataType="System.Decimal" FilterControlAltText="Filter IM2 column" HeaderText="IMMOVALBLE Curr" SortExpression="IM2" UniqueName="IM2" DataFormatString="{0:#,##,##0.00}">
      </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="M1" DataType="System.Decimal" FilterControlAltText="Filter M1 column" HeaderText="MOVALBLE Prev" SortExpression="M1" UniqueName="M1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="M2" DataType="System.Decimal" FilterControlAltText="Filter M2 column" HeaderText="MOVALBLE Curr" SortExpression="M2" UniqueName="M2" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
              
        <telerik:GridBoundColumn DataField="G1" DataType="System.Decimal" FilterControlAltText="Filter G1 column" HeaderText="GOLD Prev" SortExpression="G1" UniqueName="G1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="G2" DataType="System.Decimal" FilterControlAltText="Filter G2 column" HeaderText="GOLD Curr" SortExpression="G2" UniqueName="G2" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="S1" DataType="System.Decimal" FilterControlAltText="Filter S1 column" HeaderText="SILVER Prev" SortExpression="S1" UniqueName="S1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="S2" DataType="System.Decimal" FilterControlAltText="Filter S2 column" HeaderText="SILVER Curr" SortExpression="S2" UniqueName="S2" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="P1" DataType="System.Decimal" FilterControlAltText="Filter P1 column" HeaderText="PRECIOUS METALS Prev" SortExpression="P1" UniqueName="P1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="P2" DataType="System.Decimal" FilterControlAltText="Filter P2 column" HeaderText="PRECIOUS METALS Curr" SortExpression="P2" UniqueName="P2" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="L1" DataType="System.Decimal" FilterControlAltText="Filter L1 column" HeaderText="LIABILITY Prev" SortExpression="L1" UniqueName="L1" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="L2" DataType="System.Decimal" FilterControlAltText="Filter L2 column" HeaderText="LIABILITY Curr" SortExpression="L2" UniqueName="L2" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DPR" DataType="System.Decimal" FilterControlAltText="Filter DPR column" HeaderText="DPR" SortExpression="DPR" UniqueName="DPR" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NETPAY" DataType="System.Decimal" FilterControlAltText="Filter NETPAY column" HeaderText="NETPAY" SortExpression="NETPAY" UniqueName="NETPAY" DataFormatString="{0:#,##,##0.00}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="EXP_FLAG" FilterControlAltText="Filter EXP_FLAG column" HeaderText="EXP_FLAG" SortExpression="EXP_FLAG" UniqueName="EXP_FLAG" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column" HeaderText="STATUS" SortExpression="STATUS" UniqueName="STATUS" Display="false">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

        </telerik:RadGrid>
        </fieldset>
    </div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PRConnectionString %>" 
        SelectCommand="SELECT  a.[PERNR],firstname+' '+lastname as NAME,project ,[YEAR],[IM1],[IM2],[G1],[G2],[S1],[S2],[P1],[P2],[M1],[M2],[L1],[L2],[DPR],[NETPAY],[EXP_FLAG],[STATUS]  FROM [PROP_RETURNS].[dbo].[M_EXCEPTION_ALL] a,[ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] b  where a.year=@year and a.pernr=@pernr  and a.PERNR=b.pernr">
        <SelectParameters>
            <asp:Parameter Name="pernr" />
            <asp:Parameter Name="year" />
        </SelectParameters>
    </asp:SqlDataSource>
</body>
</html>
