<%@ Page Title="User Authorization Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAuth.aspx.cs" Inherits="PROPERTY_RETURNS.FORMS.UserAuth" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/bootstrap.min.5.3.3.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="border: thin solid #C0C0C0; padding: 10px;">
        <h3 class="text-center" style="color: darkblue">User Authorization Entry</h3>
        <hr />
        <asp:Panel ID="pnlAddForm" runat="server" CssClass="mb-3" Style="margin-bottom: 20px;">
            <div class="container-fluid">
                <asp:HiddenField ID="txtId" runat="server" />
                <div class="row mb-3">
                    <div class="col-md-2">
                        <asp:Label runat="server" Text="Employee:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadComboBox ID="ddlEmployee" runat="server" AutoPostBack="true"
                            Filter="Contains" MarkFirstMatch="True" AllowCustomText="true" EmptyMessage="Select Employee"
                            OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"
                            Width="100%" />
                    </div>

                    <div class="col-md-2">
                        <asp:Label runat="server" Text="EmpPlant:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadTextBox ID="txtPlant" runat="server" ReadOnly="true" Width="100%" CssClass="form-control bg-light" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-2">
                        <asp:Label runat="server" Text="EmpPA:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadTextBox ID="txtPa" runat="server" ReadOnly="true" Width="100%" CssClass="form-control bg-light" />
                    </div>

                    <div class="col-md-2">
                        <asp:Label runat="server" Text="EmpPSA:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadTextBox ID="txtPsa" runat="server" ReadOnly="true" Width="100%" CssClass="form-control bg-light" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-2">
                        <asp:Label runat="server" Text="AuthPA:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadComboBox ID="ddlAuthPa" runat="server"
                            CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                            Filter="Contains" MarkFirstMatch="True" AllowCustomText="true" EmptyMessage="Select PA"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlAuthPa_SelectedIndexChanged"
                            Width="100%" />
                    </div>

                    <div class="col-md-2">
                        <asp:Label runat="server" Text="AuthPSA:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadComboBox ID="ddlAuthPsa" runat="server"
                            CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                            Filter="Contains" MarkFirstMatch="True" AllowCustomText="true" EmptyMessage="Select PSA"
                            Width="100%" />
                    </div>
                </div>

                <div class="row mb-3" style="display:none;">
                    <div class="col-md-2">
                        <asp:Label runat="server" Text="EmpRole:" CssClass="form-label fw-bold" />
                    </div>
                    <div class="col-md-4">
                        <telerik:RadComboBox ID="ddlEmpRole" runat="server" Width="100%" >
                            <Items>
                                <telerik:RadComboBoxItem Text="Admin" Value="A" />
                                <telerik:RadComboBoxItem Text="User" Value="S" />
                            </Items>
                        </telerik:RadComboBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnAdd" runat="server" Text="Save & Update" CssClass="btn btn-success"
                        OnClick="btnAdd_Click" />
                </div>
            </div>
        </asp:Panel>
        <hr />
        <telerik:RadGrid ID="RadGridUserAuth" runat="server"
            AutoGenerateColumns="False"
            OnNeedDataSource="RadGridUserAuth_NeedDataSource"
            OnItemCommand="RadGridUserAuth_ItemCommand"
            OnItemDataBound="RadGridUserAuth_ItemDataBound"
            AllowSorting="True"
            AllowPaging="True"
            PageSize="20"
            Width="100%"
            Skin="Office2007">
            <MasterTableView DataKeyNames="ID" EditMode="InPlace">
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="Select" UniqueName="SelectColumn">
                        <HeaderStyle Width="60px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true"
                                OnCheckedChanged="chkSelect_CheckedChanged"
                                ToolTip='<%# Eval("ID") %>' Width="10%" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="EMPNAME" UniqueName="EMPNAME" />
                    <telerik:GridBoundColumn DataField="PLANT" HeaderText="PLANT" UniqueName="PLANT" />
                    <telerik:GridBoundColumn DataField="PA" HeaderText="PA" UniqueName="PA" />
                    <telerik:GridBoundColumn DataField="PSA" HeaderText="PSA" UniqueName="PSA" />
                    <telerik:GridBoundColumn DataField="ROLE" HeaderText="ROLE" UniqueName="ROLE" HeaderStyle-Width="50px" />
                    <%--                    <telerik:GridBoundColumn DataField="STATUS" HeaderText="STATUS" UniqueName="STATUS" />--%>

                    <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" />--%>
                    <telerik:GridButtonColumn ConfirmText="Are you sure to delete this record?"
                        ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete"
                        ButtonType="ImageButton"
                        CommandName="Delete"
                        Text="Delete" />
                </Columns>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="False" UseStaticHeaders="True" />
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
        </telerik:RadGrid>

        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" VisibleStatusbar="false"
            Skin="Forest" Modal="true" Width="600" Height="400" />
    </div>
</asp:Content>
