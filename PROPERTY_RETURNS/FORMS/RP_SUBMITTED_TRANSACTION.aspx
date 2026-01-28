<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RP_SUBMITTED_TRANSACTION.aspx.cs" Inherits="PROPERTY_RETURNS.FORMS.RP_SUBMITTED_TRANSACTION" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" style="margin-top:25px;">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" ReportSourceID="CrystalReportSource1" PageZoomFactor="70" 
        DisplayStatusbar="False" EnableToolTips="False" HasDrilldownTabs="False" 
        HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" 
        ToolPanelView="None"   />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="REPORTS\MAIN_REPORT_REVIEW.rpt">
        </Report>
    </CR:CrystalReportSource>
  </asp:Panel>
</asp:Content>
