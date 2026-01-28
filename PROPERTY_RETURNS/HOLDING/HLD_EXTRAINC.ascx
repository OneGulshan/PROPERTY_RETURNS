<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HLD_EXTRAINC.ascx.cs" Inherits="PROPERTY_RETURNS.HOLDING.HLD_EXTRAINC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="../Styles/select2.css" rel="stylesheet" type="text/css" />
<link href="../Styles/CustomeSite.css" rel="stylesheet" type="text/css" />
<link href="../Scripts/jquery.gritter.css" rel="stylesheet" type="text/css" />
<link href="../Scripts/dhtmlxcombo.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
<script src="../Scripts/select2.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.gritter.min.js" type="text/javascript"></script>
<script src="../Scripts/dhtmlxcommon.js" type="text/javascript"></script>
<script src="../Scripts/dhtmlxcombo.js" type="text/javascript"></script>
<style>
    .tooltip {
        position: relative;
        display: inline-block;
        border-bottom: 1px dotted black;
        top: 0px;
        left: 1px;
        height: 15px;
    }

        .tooltip .tooltiptext {
            visibility: hidden;
            width: 250px;
            background-color: GREEN;
            color: #FFFFFF;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            /* Position the tooltip */
            position: absolute;
            z-index: 1;
        }

        .tooltip:hover .tooltiptext {
            visibility: visible;
        }
</style>
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%>
<%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
                <div class="col-xs-5" style="border-right: 1px solid #c7c7c7;"></div>
                <legend>Manage Transaction Details</legend>--%>
<br />
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label><asp:Label ID="lbl_refno" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Label ID="lbl_action_t" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Panel ID="pnlFV" runat="server">
    <div style="font-family: verdana; font-size: small;">
        <table>
            <tr>
                <td>
                    <fieldset style="height: 200px; width: 400px; vertical-align: top">
                        <legend>Extra Income Details</legend>
                        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse; height: 145px; width: 101%;"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" Text="Source of Extra Income" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RadComboBox1" runat="server" EmptyMessage="-please select acquition source-">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Maturity of Fixed Deposit" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Maturity of Insurance Policy " Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Capital Gain on Share / Mutual Fund" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="Sale of Immovable Property" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="Maturity of postal scheme" Value="4" />
                                            <telerik:RadComboBoxItem runat="server" Text="Maturity of bond/Debentures" Value="5" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on PPF amounts" Value="6" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on bank accounts including RD" Value="7" />
                                            <telerik:RadComboBoxItem runat="server" Text="Sale of Vehicle" Value="8" />
                                            <telerik:RadComboBoxItem runat="server" Text="Sale of Gold/Silver/Diamond/Composite Items" Value="9" />
                                            <telerik:RadComboBoxItem runat="server" Text="Others " Value="10" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <%-- <telerik:RadComboBox ID="source" runat="server" >
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Savings" Value="Savings" />
                            <telerik:RadComboBoxItem runat="server" Text="Gift" Value="Gift" />
                            <telerik:RadComboBoxItem runat="server" Text="Loans" Value="Loans" />
                            <telerik:RadComboBoxItem runat="server" Text="Others" Value="Others" />
                        </Items>
                    </telerik:RadComboBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" Text="Detail of Immovable Property" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBox3" runat="server" Height="40px" HtmlEncode="true" NullDisplayText=" " Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Other Fund Source (if any)"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBox1" runat="server" HtmlEncode="false" Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" Text="Remarks (if any)" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBox2" runat="server" Height="40px" Width="155px" HtmlEncode="true"
                                        NullDisplayText=" ">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>

                        </table>
                        <br />
                        <telerik:RadButton ID="RadButton1" runat="server" Text="Add New" OnClick="rb_addnew_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="RadButton2" runat="server" Text="Save Draft" OnClick="rb_save_Click">
                        </telerik:RadButton>
                        <%-- <telerik:RadButton ID="rb_submit" runat="server" Text="Submit" OnClick="rb_submit_Click"  >
            </telerik:RadButton>--%>
                        <telerik:RadButton ID="RadButton3" runat="server" Text="Delete Entry" OnClick="rb_reject_Click" Visible="false">
                        </telerik:RadButton>
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                    </fieldset>
                </td>
                
            </tr>
        </table>
        <br />
        Note:Please Enter Details of Extra Income only.
    </div>
    <%--</fieldset>--%>
    <fieldset style="height: 300px; font-family: verdana; font-size: medium; font-weight: bold;">
        <legend>Extra Income Details</legend>
        <%--<telerik:RadButton ID="btnToggle" runat="server" ToggleType="Radio" Checked="True"
            ButtonType="StandardButton" GroupName="StandardButton" Visible="false"
            OnClick="btnToggle_Click">
        </telerik:RadButton>--%>
        <%--<telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="False"
            GroupName="StandardButton" ButtonType="StandardButton" Visible="false"
            AutoPostBack="True" OnClick="btnToggle1_Click">
        </telerik:RadButton>--%>
        
    </fieldset>
</asp:Panel>
<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>