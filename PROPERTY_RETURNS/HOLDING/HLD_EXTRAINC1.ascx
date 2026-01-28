<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HLD_EXTRAINC1.ascx.cs" Inherits="PROPERTY_RETURNS.HOLDING.HLD_EXTRAINC1" %>
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
        z-index: 99999999;
    }

        .tooltip .tooltiptext {
            visibility: hidden;
            width: 250px;
           background-color: #000000;
            color: #FFFFFF;
            text-align: center;
            font-family :Verdana ;
            font-size :medium ;
            border-radius: 6px;
            padding: 5px 0;
            /* Position the tooltip */
            position: absolute;
            z-index: 1;
            text-align: left;
        }

        .tooltip:hover .tooltiptext {
            visibility: visible;
        }
.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.1.411.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.1.411.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}
    .auto-style1 {
        width: 100%;
        border-style: none;
        border-color: inherit;
        border-width: 0;
        margin: 0;
        padding: 0;
    }
    .auto-style2 {
        width: 100%;
        vertical-align: middle;
    }
    .auto-style3 {
        position: relative;
        z-index: 2;
        text-decoration: none;
        margin: 0 2px;
    }
</style>
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%><%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
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
                    <fieldset style="height: 350px; width: 400px; vertical-align: top">
                        <legend>Other Income Details</legend>
                        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse; height: 170px; width: 101%;"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                            <tr>
                                <td >
                                    <div class="tooltip">
                                        <asp:Image ID="Image8" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="tooltiptext" style="position: fixed; z-index: auto; top: 60%; left: 40%;">**Select Name of the Other Income Owner</span>
                                    </div>

                                </td>
                                <td  style="width: 90%">

                                    <asp:Label ID="Label2" runat="server" Text="Name Of Income Owner" Width="100%"></asp:Label>
                                </td>
                                <td style="width: 40%">
                                    <asp:Label ID="lbl_cummu_req" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    &nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label1" runat="server" Text="Source of Other Income"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadComboBox ID="ddl_Acq_Source" runat="server" AutoPostBack="true" EmptyMessage="-please select acquition source-" OnSelectedIndexChanged="ddl_Acq_Source_OnSelectedIndexChanged" ZIndex="90000">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on Maturity of Fixed Deposit" Value="01" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on Maturity of Insurance Policy " Value="02" />
                                            <telerik:RadComboBoxItem runat="server" Text="Capital Gain on Share / Mutual Fund" Value="03" />
                                            <telerik:RadComboBoxItem runat="server" Text="Sale of Immovable Property" Value="04" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on Maturity of Postal Scheme" Value="05" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on Maturity of Bond/Debentures" Value="06" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on PPF amounts" Value="07" />
                                            <telerik:RadComboBoxItem runat="server" Text="Interest on bank accounts including RD" Value="08" />
                                            <telerik:RadComboBoxItem runat="server" Text="Sale of Vehicle" Value="09" />
                                            <telerik:RadComboBoxItem runat="server" Text="Gain in Sale of Gold/Silver/Diamond/Composite Items" Value="10" />
                                            <telerik:RadComboBoxItem runat="server" Text="Others " Value="11" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label6" runat="server" Text="Date of Acquisition"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="lbl_cummu_req0" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadDatePicker ID="rdp_acqdt" runat="server">
                                        <DateInput DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="lbl_details" runat="server" Text="Details of Other" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadTextBox ID="txt_details" runat="server" Height="40px" HtmlEncode="true" NullDisplayText=" " Visible="False" Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label4" runat="server" Text="Amount in Rs."></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadTextBox ID="txt_Amt" runat="server" HtmlEncode="false" Width="155px" OnTextChanged="txt_Amt_TextChanged" AutoPostBack="True">
                                    </telerik:RadTextBox>
                                    <br />
                                            <asp:Label ID="lbl_amt_value" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                            <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks (if any)"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                    <telerik:RadTextBox ID="rtb_remarks" runat="server" Height="40px" HtmlEncode="true" NullDisplayText=" " Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    &nbsp;</td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="Label23" runat="server" Text="Holding Date" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 45%">
                                     <telerik:RadDatePicker ID="rdp_trndt" runat="server" Visible="False">
                                        <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                    <br />
                                    <telerik:RadDatePicker ID="rdp_hlddt" runat="server" Enabled="False" Style="font-weight: 700" Visible="False">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>

                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                            </tr>


                        </table>
                        <br />
                        <br />
                         <telerik:RadButton ID="rb_addnew" runat="server" Text="Add New" OnClick="rb_addnew_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="rb_save" runat="server" Text="Save Draft" OnClick="rb_save_Click">
                                    </telerik:RadButton>
                                    <%--<telerik:RadButton ID="rb_submit" runat="server" Text="Submit" OnClick="rb_submit_Click" Visible=false>
                                </telerik:RadButton>--%>
                                    <telerik:RadButton ID="rb_reject" runat="server" Text="Delete Entry" OnClick="rb_reject_Click"
                                        Visible="false">
                                    </telerik:RadButton>
                        <asp:Panel ID="epanel" runat="server">
                                        
                                    </asp:Panel>
                    </fieldset>
                </td>
                
            </tr>
        </table>
        <br />
        <br />
        Note:Please Enter Details of Other Income only.
    </div>
    <div>
            
           <%-- <telerik:RadWindow ID="modalPopup" runat="server" Width="250px" Height="100px"  Modal="true"  EnableShadow="true" VisibleOnPageLoad="True"  >
                <ContentTemplate>
                  
                    <p style="text-align: center;">
                    verfication is Under Process.
                    </p>
                     <p style="text-align: center;">
                    <img src="Images/Processing.gif" /></p>

                      <telerik:RadButton ID="RadButton1" Text="Show the dialog" runat="server" />
                </ContentTemplate>
            </telerik:RadWindow>--%>


            <%--<telerik:RadWindow ID="RadWindow2" runat="server" Width="550px" Height="100px"  VisibleTitlebar="false"  Modal="true" VisibleStatusbar="false"  EnableShadow="true"  >
                <ContentTemplate>
                  
                    <p style="text-align: center;">
                 here i am ....
                    </p>
                     <p style="text-align: center;">
                    <img src="Images/Processing.gif" /></p>
                </ContentTemplate>
            </telerik:RadWindow>

            <telerik:RadButton ID="rbShowDialog" Text="Show the dialog" runat="server" />--%>



         
        </div>
    <%--</fieldset>--%>
    <fieldset>
        <legend>Other Income Details</legend>
        <div  align="left">
            <telerik:RadButton ID="btnToggle3" runat="server" ToggleType="Radio" Checked="False"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle3_Click"
                Visible="false">
                <%--<ToggleStates>
        <telerik:RadButtonToggleState Text="Previous Window Holdings" PrimaryIconCssClass="rbToggleRadioChecked" />
        <telerik:RadButtonToggleState Text="Previous Window Holdings" PrimaryIconCssClass="rbToggleRadio" />
    </ToggleStates>--%>
            </telerik:RadButton>
            <telerik:RadButton ID="btnToggle2" runat="server" ToggleType="Radio" Checked="False"
                Text="Convert Submitted Transactions to Holding" GroupName="StandardButton" ButtonType="StandardButton"
                AutoPostBack="True" OnClick="btnToggle2_Click" Visible="false">
                <%--<ToggleStates>
                    <telerik:RadButtonToggleState Text="Convert Submitted Transactions to Holding" PrimaryIconCssClass="rbToggleRadioChecked"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="Convert Submitted Transactions to Holding" PrimaryIconCssClass="rbToggleRadio"></telerik:RadButtonToggleState>
                </ToggleStates>--%>
            </telerik:RadButton>
            <telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="True"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle1_Click">
                <%--<ToggleStates>
        <telerik:RadButtonToggleState Text="Saved Holdings" PrimaryIconCssClass="rbToggleRadioChecked" />
        <telerik:RadButtonToggleState Text="Saved HOldings" PrimaryIconCssClass="rbToggleRadio" />
    </ToggleStates>--%>
            </telerik:RadButton>
            <telerik:RadButton ID="btnToggle4" runat="server" ToggleType="Radio" Checked="False"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle4_Click"
                Visible="false" style="top: 0px; left: -422px; width: 26px">
                <%-- <ToggleStates>
        <telerik:RadButtonToggleState Text="Submitted Holdings" PrimaryIconCssClass="rbToggleRadioChecked" />
        <telerik:RadButtonToggleState Text="Submitted Holdings" PrimaryIconCssClass="rbToggleRadio" />
    </ToggleStates>--%>
            </telerik:RadButton>
            <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
                OnNeedDataSource="RG_TRN_OnNeedDataSource" OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged"
               >
                <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" Scrolling-AllowScroll="true">
                    <Selecting AllowRowSelect="True"></Selecting>
                    <Scrolling AllowScroll="True" />
                    <ClientEvents OnRowSelected="RowSelected" />
                    <ClientEvents OnRowClick="RowClick" />

                </ClientSettings>
                <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false"
                            HeaderStyle-Width="20">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                            HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO" HeaderStyle-Width="20"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                            HeaderText="Income Owner" ReadOnly="True" SortExpression="EMPNAME" UniqueName="EMPNAME"
                            HeaderStyle-Width="20" Visible="True">
                            <HeaderStyle Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PRPYEAR" FilterControlAltText="Filter PRPYEAR column"
                            HeaderText="YEAR" ReadOnly="True" SortExpression="PRPYEAR" UniqueName="PRPYEAR"
                            HeaderStyle-Width="30" Visible="False">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="DECDT" FilterControlAltText="Filter DECDT column"
                            HeaderText="DECLARATION DATE" ReadOnly="True" SortExpression="DECDT" UniqueName="DECDT"
                            HeaderStyle-Width="30" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TRNDT" FilterControlAltText="Filter TRNDT column"
                            HeaderText="TRANSACTION DATE" ReadOnly="True" SortExpression="TRNDT" UniqueName="TRNDT"
                            Visible="false">
                            </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                            HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No"
                            HeaderStyle-Width="30" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ASTYPE" FilterControlAltText="Filter ASTYPE column"
                            HeaderText="ASTYPE" ReadOnly="True" SortExpression="ASTYPE" UniqueName="ASTYPE"
                            Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ASCAT" FilterControlAltText="Filter ASCAT column"
                            HeaderText="ASCAT" ReadOnly="True" SortExpression="ASCAT" UniqueName="ASCAT"
                            Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                            HeaderText="Type of Income" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                            HeaderStyle-Width="20" Visible="True">
                            <HeaderStyle Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TRNTYP" FilterControlAltText="Filter TRNTYP column"
                            HeaderText="TRNTYP" ReadOnly="True" SortExpression="TRNTYP" UniqueName="TRNTYP"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        
                        
                        <telerik:GridBoundColumn DataField="Txn_Type" FilterControlAltText="Filter Txn_Type column"
                            HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type"
                            HeaderStyle-Width="20" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                            HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                            HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source"
                            HeaderStyle-Width="20" Visible="false">
                            <HeaderStyle Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                            HeaderText="Acq_Remarks" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                            HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address"
                            HeaderStyle-Width="40" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                            HeaderText="Identification No" ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
                            Visible="false">
                            <HeaderStyle Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDDESC" FilterControlAltText="Filter IDDESC column"
                            HeaderText="Details" ReadOnly="True" SortExpression="IDDESC" UniqueName="IDDESC"
                            Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                            HeaderText="Qty" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="false">
                        </telerik:GridBoundColumn>
                       
                        <telerik:GridBoundColumn DataField="TRNAMT" FilterControlAltText="Filter TRNAMT column"
                            HeaderText="Amount earned during the period" ReadOnly="True" SortExpression="TRNAMT" UniqueName="TRNAMT"
                            Visible="True">
                            <HeaderStyle Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                            HeaderText="Qüantity" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SHRPC" FilterControlAltText="Filter SHRPC column"
                            HeaderText="SHRPC" ReadOnly="True" SortExpression="SHRPC" UniqueName="SHRPC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="COOWNER" FilterControlAltText="Filter COOWNER column"
                            HeaderText="COOWNER" ReadOnly="True" SortExpression="COOWNER" UniqueName="COOWNER"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <%-- <telerik:GridBoundColumn DataField="ADDLINE1" FilterControlAltText="Filter ADDLINE1 column"
                    HeaderText="ADDLINE1" ReadOnly="True" SortExpression="ADDLINE1" UniqueName="ADDLINE1"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ADDLINE2" FilterControlAltText="Filter ADDLINE2 column"
                    HeaderText="ADDLINE2" ReadOnly="True" SortExpression="ADDLINE2" UniqueName="ADDLINE2"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CITY" FilterControlAltText="Filter CITY column"
                    HeaderText="CITY" ReadOnly="True" SortExpression="CITY" UniqueName="CITY" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="STATE" FilterControlAltText="Filter STATE column"
                    HeaderText="STATE" ReadOnly="True" SortExpression="STATE" UniqueName="STATE"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="POSTCODE" FilterControlAltText="Filter POSTCODE column"
                    HeaderText="POSTCODE" ReadOnly="True" SortExpression="POSTCODE" UniqueName="POSTCODE"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="COUNTRY" FilterControlAltText="Filter COUNTRY column"
                    HeaderText="COUNTRY" ReadOnly="True" SortExpression="COUNTRY" UniqueName="COUNTRY"
                    Visible="False">
                </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="UNIT" FilterControlAltText="Filter UNIT column"
                            HeaderText="UNIT" ReadOnly="True" SortExpression="UNIT" UniqueName="UNIT" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CURVAL" FilterControlAltText="Filter CURVAL column"
                            HeaderText="CURVAL" ReadOnly="True" SortExpression="CURVAL" UniqueName="CURVAL"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ANINCM" FilterControlAltText="Filter ANINCM column"
                            HeaderText="ANINCM" ReadOnly="True" SortExpression="ANINCM" UniqueName="ANINCM"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REMARKS" FilterControlAltText="Filter REMARKS column"
                            HeaderText="Remarks" ReadOnly="True" SortExpression="REMARKS" UniqueName="REMARKS" HeaderStyle-Width="200px"
                            Visible="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column"
                            HeaderText="STATUS" ReadOnly="True" SortExpression="STATUS" UniqueName="STATUS"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TRN_PERIOD" FilterControlAltText="Filter TRN_PERIOD column"
                            HeaderText="TRN_PERIOD" ReadOnly="True" SortExpression="TRN_PERIOD" UniqueName="TRN_PERIOD"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACQDT" FilterControlAltText="Filter ACQDT column"
                            HeaderText="Acquistion Date" ReadOnly="True" SortExpression="ACQDT" UniqueName="ACQDT"
                            Visible="false">
                          </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ASCAT" FilterControlAltText="Filter ASCAT column"
                            HeaderText="ASCAT" ReadOnly="True" SortExpression="ASCAT" UniqueName="ASCAT"
                            Visible="false">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="ASCAT_OTHDESC" FilterControlAltText="Filter ASCAT_OTHDESC column"
                            HeaderText="ASCAT_OTHDESC" ReadOnly="True" SortExpression="ASCAT_OTHDESC" UniqueName="ASCAT_OTHDESC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="ASTYPE_OTHDESC" FilterControlAltText="Filter ASTYPE_OTHDESC column"
                            HeaderText="ASTYPE_OTHDESC" ReadOnly="True" SortExpression="ASTYPE_OTHDESC" UniqueName="ASTYPE_OTHDESC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="ACQ_SOURCE_OTHDESC" FilterControlAltText="Filter ACQ_SOURCE_OTHDESC column"
                            HeaderText="ACQ_SOURCE_OTHDESC" ReadOnly="True" SortExpression="ACQ_SOURCE_OTHDESC" UniqueName="ACQ_SOURCE_OTHDESC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CONSVAL" FilterControlAltText="Filter CONSVAL column"
                            HeaderText="CONSVAL" ReadOnly="True" SortExpression="CONSVAL" UniqueName="ACQ_SOURCE_OTHDESC"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    HeaderText="Edit" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/edit_32.png" onclick="ImageButton1_Click" />
                    </ItemTemplate>

                </telerik:GridTemplateColumn>--%>
                        <%-- <telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderText="Edit" 
                            UniqueName="EditCommandColumn">
                            <HeaderStyle Width="32px" />
                        </telerik:GridEditCommandColumn>--%>
                       
                        <%--<telerik:GridButtonColumn CommandName="Deselect" ButtonType="ImageButton" UniqueName="Deselect" ImageUrl="/Images/deselect.png" HeaderText="DeSelect">
                </telerik:GridButtonColumn>--%>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <span style="text-align:left; color:red;">
             1.	Total of other Income for the period (01.04.2024 to 31.12.2024): Rs. <asp:Label ID="lbltotinc1" runat="server" Text=""></asp:Label> /- <br />
            2.	Total of other Income for the period (01.01.2025 to 31.12.2025): Rs. <asp:Label ID="lbltotinc2" runat="server" Text=""></asp:Label>/-<br />
This above data should be reflected in the subsequent forms with remarks that for older records other than 31.12.2024,  shall be taken from the submitted forms) 
        </span>
        </div>
        
    </fieldset>
    
           

</asp:Panel>
<script>
    function RowClick(sender, eventArgs) {
        //alert("Click on row instance: " + eventArgs.get_itemIndexHierarchical());
        index = eventArgs.get_itemIndexHierarchical();
        var grid = $find("<%=RG_TRN.ClientID %>");
        var MasterTable = grid.get_masterTableView();

        var Row = MasterTable.get_dataItems()[index];
        var cell = MasterTable.getCellByColumnUniqueName(Row, "TRNAMT");
        //alert(cell.innerHTML)
    }
</script>
<script type="text/javascript">

    function RowSelected(sender, eventArgs) {

    }


</script>
<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>