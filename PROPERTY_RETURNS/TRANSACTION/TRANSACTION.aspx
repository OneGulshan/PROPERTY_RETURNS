<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TRANSACTION.aspx.cs" Inherits="PROPERTY_RETURNS.TRANSACTION" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="TRN_IMMOVABLE.ascx" TagName="TRN_IMMOVABLE" TagPrefix="uc" %>
<%@ Register Src="TRN_MOVABLE.ascx" TagName="TRN_MOVABLE" TagPrefix="uc" %>
<%@ Register Src="TRN_LIABILITY.ascx" TagName="TRN_LIABILITY" TagPrefix="uc" %>
<%@ Register Src="TRN_FOREIGN.ascx" TagName="TRN_FOREIGN" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblhlddt" runat="server" Font-Size="X-Large" ForeColor="#990033"></asp:Label>
<asp:Label ID="lblhlddt_hidden" runat="server" Visible="False"></asp:Label><br />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" Skin="Office2007" />
    <div class="demo-container no-bg">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" Align="Justify" AutoPostBack="True"
            MultiPageID="RadMultiPage1" SelectedIndex="1" 
            ontabclick="RadTabStrip1_TabClick">
            <Tabs>
                <telerik:RadTab Text="IMMOVABLE" SelectedIndex="0" Selected="true">
                </telerik:RadTab>
                <telerik:RadTab Text="MOVABLE" SelectedIndex="1" >
                </telerik:RadTab>
                <telerik:RadTab Text="LIABILITY" SelectedIndex="2" >
                </telerik:RadTab>
                <telerik:RadTab Text="FOREIGN VISITS" SelectedIndex="3" Visible="false" >
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" >
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView1" >
                <div class="contentWrapper">
                    <uc:TRN_IMMOVABLE ID="TRN_IMMOVABLE" runat="server" />
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView2" SelectedIndex="1" >
                
                <div class="contentWrapper">
                    
                    <uc:TRN_MOVABLE ID="TRN_MOVABLE" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView3" CssClass="RadPageView3" SelectedIndex="2" >
                
                <div class="contentWrapper">
                    
                    <uc:TRN_LIABILITY ID="TRN_LIABILITY" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView4" CssClass="RadPageView4" SelectedIndex="3" >
                
                <div class="contentWrapper">
                    
                    <uc:TRN_FOREIGN ID="TRN_FOREIGN" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
        <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>

</asp:Content>
