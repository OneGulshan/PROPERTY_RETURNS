<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TRN_MOVABLE.ascx.cs" Inherits="PROPERTY_RETURNS.TRN_MOVABLE" %>
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
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%>
<%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
                <div class="col-xs-5" style="border-right: 1px solid #c7c7c7;"></div>
                <legend>Manage Transaction Details</legend>--%>
<br />
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label><asp:Label
    ID="lbl_refno" Text="" Visible="false" runat="server" Style="font-weight: 700;
    font-size: medium"></asp:Label>
    <asp:Label ID="lbl_action_t" Text="" Visible="false"  runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
    &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label24" Text="Transaction Operation :" 
    runat="server" style="font-weight: 700"></asp:Label>
                   <telerik:RadComboBox ID="rdb_trnfor" runat="server" 
    EmptyMessage="-please select trn operation-" AutoPostBack="true"
    onselectedindexchanged="rdb_trnfor_SelectedIndexChanged">
                        <Items>
                           <telerik:RadComboBoxItem runat="server" Text="NEW DECLARATION" 
                               Value="NEW DECLARATION" />
                           <telerik:RadComboBoxItem runat="server" Text="MODIFICATION OF HOLDINGS" 
                               Value="MODIFICATION OF HOLDINGS" />
                           <telerik:RadComboBoxItem runat="server" Text="CANCELLATION OF DECLARED HOLDINGS" 
                               Value="CANCELLATION OF DECLARED HOLDINGS" />
                           <telerik:RadComboBoxItem runat="server" Text="BUY" 
                               Value="BUY" />
                                <telerik:RadComboBoxItem runat="server" Text="SELL" 
                               Value="SELL" />
                       </Items>
                    </telerik:RadComboBox>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label14" Text="Holding Ref. : " 
    runat="server" style="font-weight: 700"></asp:Label>
                
                   &nbsp;&nbsp;&nbsp;<telerik:RadComboBox ID="rdb_refholding" 
    runat="server" EmptyMessage="-please select Holding Ref.-"  AutoPostBack="true"
    onselectedindexchanged="rdb_refholding_SelectedIndexChanged">
                    </telerik:RadComboBox>
<div style="font-family: verdana; font-size: small;">
    <fieldset style="height: 360px; width: 90%;">
        <legend>Holding Details</legend>
        <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse;
            vertical-align: top;">
            <%--<div class="col-xs-5" style="border-right:1px solid #c7c7c7;">--%>
            <tr>
                <td valign="top" style="border-right-color: #C0C0C0; border-right-style: solid; border-right-width: thin;">
                    <table border="0" width="50%" cellspacing="2" cellpadding="2">
                        <%--<div class="col-xs-5" style="border-right:1px solid #c7c7c7;">--%>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" Text="Dependent Name*" runat="server" Width="131px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_vastcat" Text="Asset Category*" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_astcat" runat="server" EmptyMessage="-please select asset cat-"
                                    AutoPostBack="True" OnSelectedIndexChanged="rcb_astcat_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="Asset Type*" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_asttype" runat="server" EmptyMessage="-please select asset type-"
                                    AutoPostBack="True" OnSelectedIndexChanged="rcb_asttype_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" Text="Transaction Type*" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_trntype" runat="server" EmptyMessage="-please select trn type-">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" Text="Holding Date" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="rdp_trndt" runat="server" Visible="False">
                                    <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server">
                                    </DateInput>
                                </telerik:RadDatePicker>
                                <telerik:RadDatePicker ID="rdp_hlddt" runat="server" Enabled="False" Style="font-weight: 700">
                                    <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" Text="Acquisition Source*" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_acqsrc" runat="server" EmptyMessage="-please select acquition source-"
                                    OnSelectedIndexChanged="rcb_acqsrc_SelectedIndexChanged" AutoPostBack="true">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lbl_oth" Text="Other Sources" runat="server" HtmlEncode="false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_othres" runat="server" Width="155px" HtmlEncode="false">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" Text="Acquisition Date" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="rdp_acqdt" runat="server">
                                    <DateInput DateFormat="dd/MM/yyyy">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <%--  </div>
                <div class="col-xs-5">--%>
                    <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse"
                        bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                        <tr>
                            <td>
                                <asp:Label ID="LblVar1" Text="Account / Policy / Reg. No" runat="server" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_refno" runat="server" Width="155px" HtmlEncode="false">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblVar2" Text="Details" runat="server" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_refdesc" runat="server" Width="155px" HtmlEncode="false">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" Text="Purchase Value" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_amt" runat="server" Width="155px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblqty" Text="Quantity" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_qty" runat="server" Width="155px" Visible="false">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" Text="Unit of Qty" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcb_unit" runat="server" Visible="false" EmptyMessage="-please select unit-" Width="155px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" Text="Maturity Value/Sum Assured" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_ann_in" runat="server" Width="155px" Visible="false">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" Text="Remarks" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="rtb_remarks" runat="server" Height="40px" Width="155px" HtmlEncode="true"
                                    NullDisplayText=" ">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                            <td colspan="2">
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
            
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
            <tr>
            <td colspan="2">
            <hr />
            Note: Details of deposits in foreign Bank(s) to be given separately.<br />
            Investments above Rs 2 lakhs to be reported individually. Investments below Rs. 2 lakhs may be reported together.<br />
            Value indicated in the first return need not be revised in the subsequent returns as long as no new composite item had been acquired or no existing items had been desposed off, during the relevant year.
            </td>
            </tr>
        </table>
    </fieldset>
</div>

<fieldset style="height: 360px; font-family: verdana; font-size: small; font-weight: bold;">
    <legend id="lg_dtl">Transactions Details</legend>
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
        Visible="false">
        <%-- <ToggleStates>
        <telerik:RadButtonToggleState Text="Submitted Holdings" PrimaryIconCssClass="rbToggleRadioChecked" />
        <telerik:RadButtonToggleState Text="Submitted Holdings" PrimaryIconCssClass="rbToggleRadio" />
    </ToggleStates>--%>
    </telerik:RadButton>
    <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
        OnNeedDataSource="RG_TRN_OnNeedDataSource" OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged"
        Width="940px">
        <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" Scrolling-AllowScroll="true">
            <Selecting AllowRowSelect="True"></Selecting>
            <Scrolling AllowScroll="True" />
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
                    HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="Dep. Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME"
                    HeaderStyle-Width="20" Visible="True">
                    <HeaderStyle Width="150px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No"
                    HeaderStyle-Width="30" Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ASTYPE" FilterControlAltText="Filter ASTYPE column"
                    HeaderText="ASTYPE" ReadOnly="True" SortExpression="ASTYPE" UniqueName="ASTYPE"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ASCAT" FilterControlAltText="Filter ASCAT column"
                    HeaderText="ASCAT" ReadOnly="True" SortExpression="ASCAT" UniqueName="ASCAT"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter Description column"
                    HeaderText="Description" ReadOnly="True" SortExpression="Description" UniqueName="Description"
                    HeaderStyle-Width="20" Visible="True">
                    <HeaderStyle Width="150px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRNTYP" FilterControlAltText="Filter TRNTYP column"
                    HeaderText="TRNTYP" ReadOnly="True" SortExpression="TRNTYP" UniqueName="TRNTYP"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRNDT" FilterControlAltText="Filter TRNDT column"
                    HeaderText="TRNDT" ReadOnly="True" SortExpression="TRNDT" UniqueName="TRNDT"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Txn_Type" FilterControlAltText="Filter Txn_Type column"
                    HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type"
                    HeaderStyle-Width="20" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                    HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source"
                    HeaderStyle-Width="20" Visible="True">
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
                    Visible="True">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="IDDESC" FilterControlAltText="Filter IDDESC column"
                    HeaderText="Details" ReadOnly="True" SortExpression="IDDESC" UniqueName="IDDESC"
                    Visible="True">
                    <HeaderStyle Width="150px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                    HeaderText="Qty" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRNAMT" FilterControlAltText="Filter TRNAMT column"
                    HeaderText="Amount" ReadOnly="True" SortExpression="TRNAMT" UniqueName="TRNAMT"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                    HeaderText="Purchase Amount" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
                    Visible="True">
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
                    HeaderText="REMARKS" ReadOnly="True" SortExpression="REMARKS" UniqueName="REMARKS"
                    Visible="False">
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
                    HeaderText="ACQDT" ReadOnly="True" SortExpression="ACQDT" UniqueName="ACQDT"
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
                <telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton" UniqueName="Select"
                    ImageUrl="../Images/edit_32.png" HeaderText="Edit">
                </telerik:GridButtonColumn>
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
</fieldset>
<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
