<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HOLDING.aspx.cs" Inherits="PROPERTY_RETURNS.HOLDING.HOLDING" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="HLD_IMMOVABLE.ascx" TagName="HLD_IMMOVABLE" TagPrefix="uc" %>
<%@ Register Src="HLD_MOVABLE.ascx" TagName="HLD_MOVABLE" TagPrefix="uc" %>
<%@ Register Src="HLD_LIABILITY.ascx" TagName="HLD_LIABILITY" TagPrefix="uc" %>
<%@ Register Src="HLD_FOREIGN.ascx" TagName="HLD_FOREIGN" TagPrefix="uc" %>
<%@ Register Src="HLD_EXTRAINC1.ascx" TagName="HLD_EXTRAINC1" TagPrefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" Skin="Office2007" />
<asp:Label ID="lblhlddt" runat="server" Font-Size="X-Large" ForeColor="#990033"></asp:Label>
<asp:Label ID="lblhlddt_hidden" runat="server" Visible="False"></asp:Label><br />
    <div class="demo-container no-bg" id="main_div">
        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" Align="Justify" AutoPostBack="True"
            MultiPageID="RadMultiPage1"  
            ontabclick="RadTabStrip1_TabClick">
            <Tabs>
                <telerik:RadTab Text="IMMOVABLE" SelectedIndex="0" Selected="true">
                </telerik:RadTab>
                <telerik:RadTab Text="MOVABLE" SelectedIndex="1">
                </telerik:RadTab>
                <telerik:RadTab Text="LIABILITY" SelectedIndex="2">
                </telerik:RadTab>
                <telerik:RadTab Text="FOREIGN VISITS" SelectedIndex="3">
                </telerik:RadTab>
                <telerik:RadTab Text="OTHER INCOME" SelectedIndex="4">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" >
            <telerik:RadPageView runat="server" Height="430px" ID="RadPageView1">
                <div class="contentWrapper">
                    <uc:HLD_IMMOVABLE ID="HLD_IMMOVABLE" runat="server" />
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView2" SelectedIndex="1" >
                
                <div class="contentWrapper">
                    
                    <uc:HLD_MOVABLE ID="HLD_MOVABLE" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView3" CssClass="RadPageView3" SelectedIndex="2" >
                
                <div class="contentWrapper">
                    
                    <uc:HLD_LIABILITY ID="HLD_LIABILITY" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView4" CssClass="RadPageView4" SelectedIndex="3">
                
                <div class="contentWrapper">
                    
                    <uc:HLD_FOREIGN ID="HLD_FOREIGN" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" Height="460px" ID="RadPageView5" CssClass="RadPageView5" SelectedIndex="4">
                
                <div class="contentWrapper">
                    
                    <uc:HLD_EXTRAINC1 ID="HLD_EXTRAINC1" runat="server" />
                    
                </div>
                
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <asp:Panel ID="print_panel" runat="server">
    </asp:Panel>
    <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
</asp:Content>
