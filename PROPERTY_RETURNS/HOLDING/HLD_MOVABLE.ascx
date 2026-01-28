<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HLD_MOVABLE.ascx.cs"
    Inherits="PROPERTY_RETURNS.HOLDING.HLD_MOVABLE" %>
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
<script type="text/javascript" src="JavaScript1.js"></script>
<%--// Call the function toWordsconver(number) passing a number to it: --%>


<style>
    .tooltip {
        position: relative;
        display: inline-block;
        /*border-bottom: 1px dotted black;*/
        top: 0px;
        left: 1px;
        height: 15px;
        z-index: 99999999;
    }

        .tooltip .mo_tooltiptext {
            visibility: hidden;
            width: 300px;
            background-color: #000000;
            color: #FFFFFF;
            text-align: left;
            font-family :Verdana ;
            font-size :medium ;
            /*border-radius: 6px;*/
            padding: 5px 0;
            /* Position the tooltip */
            position: absolute;
            z-index: 9999999;
        }

        .tooltip:hover .mo_tooltiptext {
            visibility: visible;
        }

    </style>
<style>
    .tooltiptable {
        position: relative;
        display: inline-block;
        /*border: 1px solid black;*/
        /*border-bottom: 1px dotted black;*/
        top: 0px;
        left: 1px;
        height: 15px;
        z-index :9999999999
    }

        .tooltiptable .mo_tooltiptabletext {
            visibility: hidden;
            width: 550px;
            background-color: #000000;
            font-weight: bold;
            color: #FFFFFF;
            text-align: left;
            font-family :Verdana ;
            font-size :14px  ;
            border-radius: 6px;
            padding: 5px 0;
            /* Position the tooltip */
            position: absolute;
            z-index: 9999999;
        }

        .tooltiptable:hover .mo_tooltiptabletext {
            visibility: visible;
        }

    .auto-style4 {
        width: 4%;
    }

    .auto-style6 {
        width: 33%;
    }

    .auto-style7 {
        width: 242px;
    }
    .auto-style9 {
        width: 242px;
        height: 42px;
    }
</style>
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%><%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
                <div class="col-xs-5" style="border-right: 1px solid #c7c7c7;"></div>
                <legend>Manage Transaction Details</legend>--%>
<br />
<div style="border: .1px solid #008080; color: #FFFFFF; font-weight: normal; font-size: small; background-color: #3a4f63; font-family: Verdana;">
                            Note : Data pertaining to PF/VPF & NDCPS as on 31st March have been fetched from SAP data base. Employees are requested to verify the amount at their end before submission. 
                        </div>
<hr />
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label><asp:Label
    ID="lbl_refno" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Label ID="lbl_action_t" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Panel ID="pnlMO" runat="server">
    
    <fieldset style="height: 90%; width: 90%;">
          
        <legend>Holding Details</legend>

        <div style="font-family: verdana; font-size: small;">

            <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse; vertical-align: top;">
                <%--<div class="col-xs-5" style="border-right:1px solid #c7c7c7;">--%>
                <tr style="vertical-align: top; text-align: left">
                    <td style="border-right-color: #C0C0C0; border-right-style: solid; border-right-width: thin;">
                        <table border="0" cellspacing="2" cellpadding="2" style="vertical-align: top; width: 101%;">
                            <%--<div class="col-xs-5" style="border-right:1px solid #c7c7c7;">--%>
                            <tr>
                                <td class="auto-style4">
                                    <div class="tooltip">
                                        <asp:Image ID="Image8" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="mo_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Select the Name of the Property Owner</span>
                                    </div>

                                </td>
                                <td class="auto-style6">

                                    <asp:Label ID="Label4" runat="server" Text="Name Of Property Owner"></asp:Label>
                                    
                                </td>
                                <td class="auto-style6"><asp:Label ID="lbl_cummu_req0" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label></td>
                                <td style="width: 45%">
                                    <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <div class="tooltip">
                                        <asp:Image ID="Image5" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <table class="mo_tooltiptext" style="vertical-align: top; text-align: left; position: fixed; z-index: auto; top: 20%; left: 40%">
                                            <tr>
                                                <td>**Select the type of property from drop down</td>
                                            </tr>
                                            <tr>
                                                <td>** Cash In Hands = Hard Cash</td>
                                            </tr>
                                        </table>

                                    </div>
                                </td>
                                <td class="auto-style6">

                                    <asp:Label ID="lbl_vastcat" Text="Description Of Property" runat="server"></asp:Label>

                                </td>

                                <td class="auto-style6">
                                    <asp:Label ID="lbl_cummu_req1" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>

                                <td>
                                    <telerik:RadComboBox ID="rcb_astcat" runat="server" EmptyMessage="-please select asset cat-"
                                        AutoPostBack="True" OnSelectedIndexChanged="rcb_astcat_SelectedIndexChanged" ZIndex="90000"></telerik:RadComboBox>

                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style4">
                                     
                                </td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="lbl_desc_oth" runat="server" Text="Details of Others" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_desc_oth" runat="server" Height="60px" HtmlEncode="false" Visible="False" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <div class="tooltip">
                                        <asp:Image ID="Image3" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />

                                        <span class="mo_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Select the sub type of selected property from the drop down
     
                                        </span>
                                    </div>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label1" runat="server" Text="Asset Type"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="lbl_cummu_req2" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_asttype" runat="server" AutoPostBack="True" EmptyMessage="-please select asset type-" OnSelectedIndexChanged="rcb_asttype_SelectedIndexChanged"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="vertical-align: top">
                                    <div class="tooltip">
                                        <asp:Image ID="img_others" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Visible="False" Width="16px" />
                                        <span class="mo_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">If Other is selected, then enter description of others </span>
                                    </div>
                                </td>
                                <td class="auto-style6" style="vertical-align: top" colspan="2">
                                    <asp:Label ID="lbl_others" runat="server" Text="Details of Others" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtbx_others" runat="server" Height="60px" HtmlEncode="false" Visible="False" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                     <div class="tooltip">
                                        <asp:Image ID="Image7" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="mo_tooltiptext" style="position: fixed; z-index: auto; top:20%; left: 40%;">**Select the source of acquisition of property from drop down</span>
                                    </div>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label13" runat="server" Text="Source of Acquisition"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="lbl_cummu_req3" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_acqsrc" runat="server" AutoPostBack="true" EmptyMessage="-please select acquition source-" OnSelectedIndexChanged="rcb_acqsrc_SelectedIndexChanged"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Lbl_oth" runat="server" HtmlEncode="false" Text="Details of Other Sources " Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:Label ID="lbl_cummu_req4" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_othres" runat="server" HtmlEncode="false" Visible="False" Width="155px" Height="60px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label5" runat="server" Text="Date of Acquisition"></asp:Label>
                                    
                                </td>
                                <td class="auto-style6"><asp:Label ID="lbl_cummu_req5" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                    </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_acqdt" runat="server">
                                        <DateInput DateFormat="dd/MM/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="Label3" runat="server" Enabled="False" Text="Transaction Type" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_cummu_req6" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_trntype" runat="server" EmptyMessage="-please select trn type-" Enabled="False" Visible="False"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style6" colspan="2">
                                    <asp:Label ID="Label23" runat="server" Text="Holding Date" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_trndt" runat="server" Visible="False"><DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy"></DateInput></telerik:RadDatePicker>
                                    <br />
                                    <telerik:RadDatePicker ID="rdp_hlddt" runat="server" Enabled="False" Style="font-weight: 700" Visible="False"><DateInput runat="server" DateFormat="dd/MM/yyyy"></DateInput></telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <%--  </div>
                <div class="col-xs-5">--%>
                        <table border="0" width="50%" cellspacing="4" cellpadding="2" style="border-collapse: collapse"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                            <tr>
                                    <td style="vertical-align: top">
                                        &nbsp;</td>
                                    <td style="vertical-align: top" colspan="2">
                                        <asp:Label ID="LblVar1" runat="server" Text="Account/ Policy/ Vehicle  Reg. No/ Folio No./ Any Other Identification No." Width="270px"></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <telerik:RadTextBox ID="rtb_refno" runat="server" Width="155px" HtmlEncode="false"></telerik:RadTextBox>


                                    </td>
                            </tr>
                            <tr>
                               <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top" colspan="2"><br />
                                    <asp:Label ID="LblVar2" runat="server" Text="Details" Width="130px"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadTextBox ID="rtb_refdesc" runat="server" Width="155px" HtmlEncode="false" Height="60px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                              <td style="vertical-align: top">
                                   <div class="tooltiptable">
                                        <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <table class="mo_tooltiptabletext " style="padding: 0px; margin: 0px; border-style: solid; border-width: .5px; position: fixed; z-index: 9999999999; top:20%; left: 40%;">
                                            <tr>
                                                <td style="width :10%">Sno</td>
                                                <td>Type of Property</td>
                                                <td>Description</td>
                                            </tr>
                                            <tr>
                                                <td>1</td>
                                                <td>PPF, Fixed Deposits (FD) & Recurring Deposits (RD)</td>
                                                <td>The outstanding balance including interest in PPF and RD accounts as on 31st March is required to be declared.
                                                  Deposited amount is required to be declared in case of FD.</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>Share, IPO & mutual fund</td>
                                                <td>The purchased value of shares, IPOs, or mutual funds is required to be declared 
                                                 (Note: Current market valued need not be declared).</td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>NSS, Govt. securities, bond, debenture, or in any postal schemes</td>
                                                <td>The only actual invested amount in all mentioned scheme
                                                  is required to be declared</td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>Insurance Policy</td>
                                                <td>The annual premium paid, and cumulative premium paid till 31st March 
                                                 is required to be declared in relevant cell of declaration form</td>
                                            </tr>
                                        </table>

                                    </div>

                              </td>
                                   <td style="vertical-align: top">
                                        <asp:Label ID="Label19" runat="server" Text="Purchase Value/Outstanding Balance(In Rs.)"></asp:Label>
                                        <td style="vertical-align: top">
                                            <asp:Label ID="lbl_cummu_req7" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                            <td class="auto-style9">
                                                <telerik:RadTextBox ID="rtb_amt" runat="server" AutoPostBack="True" OnTextChanged="rtb_amt_TextChanged" Style="z-index: 0" Width="155px">
                                                </telerik:RadTextBox>
                                                <br />
                                                <asp:Label ID="lbl_pur_value" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                                <br />
                                            </td>
                                        </td>
                                    </td>

                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top">
                                    <asp:Label ID="lbl_cummu" runat="server" Text="Cumm. Premium Paid" Visible="False"></asp:Label>
                                </td>
                                <td style="vertical-align: top">
                                    <asp:Label ID="lbl_cummu_req" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadTextBox ID="txt_cumu" runat="server" AutoPostBack="True" OnTextChanged="txt_cumu_TextChanged" Width="155px" Visible="False"></telerik:RadTextBox>
                                    <br />
                                            <asp:Label ID="lbl_cumu_val" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                            <br />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top" colspan="2">
                                    <asp:Label ID="Lblqty" runat="server" Text="Quantity (in grams)" Visible="False"></asp:Label>
                                    <%--<asp:Label ID="Lblqty_star" runat="server" Text="*" Visible="False" Font-Bold="True" ForeColor="#CC3300"></asp:Label>--%>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadTextBox ID="rtb_qty" runat="server" Visible="false" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top" colspan="2">
                                    <asp:Label ID="Label18" runat="server" Text="Unit of Qty" Visible="false"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadComboBox ID="rcb_unit" runat="server" EmptyMessage="-please select unit-" Visible="false" Width="155px"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                               <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top" colspan="2">
                                    <asp:Label ID="Label20" runat="server" Text="Maturity Value/Sum Assured" Visible="false"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadTextBox ID="rtb_ann_in" runat="server" AutoPostBack="True" OnTextChanged="rtb_ann_in_TextChanged" Visible="false" Width="155px"></telerik:RadTextBox>
                                    <br />
                                    <asp:Label ID="lbl_sum_value" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                               <td style="vertical-align: top">
                                    &nbsp;</td>
                                <td style="vertical-align: top" colspan="2">
                                    <asp:Label ID="Label22" runat="server" Text="Remarks"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <telerik:RadTextBox ID="rtb_remarks" runat="server" Height="40px" HtmlEncode="true" NullDisplayText=" " Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="vertical-align: top">
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rtb_amt" ErrorMessage="Purchase Value/Outstanding Value cannot be blank" ForeColor="#CC3300" EnableViewState="False"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <telerik:RadButton ID="rb_addnew" runat="server" Text="Add New" OnClick="rb_addnew_Click"></telerik:RadButton>
                                    <telerik:RadButton ID="rb_save" runat="server" Text="Save Draft" OnClick="rb_save_Click" Style="z-index: 0"></telerik:RadButton>
                                    <%--<telerik:RadButton ID="rb_submit" runat="server" Text="Submit" OnClick="rb_submit_Click" Visible=false>
                                </telerik:RadButton>--%>
                                    <telerik:RadButton ID="rb_reject" runat="server" Text="Delete Entry" OnClick="rb_reject_Click"
                                        Visible="false"></telerik:RadButton>
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
                      
                        
                        <div>
                            Note: Details of deposits in foreign Bank(s) to be given separately.<br />
                            Investments above Rs 2 lakhs to be reported individually. Investments below Rs. 2 lakhs may be reported together.<br />
                            Value indicated in the first return need not be revised in the subsequent returns as long as no new composite item had been acquired or no existing items had been desposed off, during the relevant year.
                        </div>

                    </td>
                </tr>
            </table>
        </div>
    </fieldset>



    <fieldset style="height: 90%; width: 90%; font-family: verdana; font-size: small; font-weight: bold;">
        <legend id="lg_dtl">Holding Details</legend>
        <div>
            <telerik:RadButton ID="btnToggle3" runat="server" ToggleType="Radio" Checked="False"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle3_Click"
                Visible="false"></telerik:RadButton>
            <telerik:RadButton ID="btnToggle2" runat="server" ToggleType="Radio" Checked="False"
                Text="Convert Submitted Transactions to Holding" GroupName="StandardButton" ButtonType="StandardButton"
                AutoPostBack="True" OnClick="btnToggle2_Click" Visible="false"></telerik:RadButton>
            <telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="True"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle1_Click"></telerik:RadButton>
            <telerik:RadButton ID="btnToggle4" runat="server" ToggleType="Radio" Checked="False"
                ButtonType="StandardButton" GroupName="StandardButton" OnClick="btnToggle4_Click"
                Visible="false" style="top: 0px; left: -422px; width: 26px"></telerik:RadButton>
            <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
                OnNeedDataSource="RG_TRN_OnNeedDataSource" OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged"
                Width="940px"><ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" Scrolling-AllowScroll="true"><Selecting AllowRowSelect="True"></Selecting><Scrolling AllowScroll="True" /><ClientEvents OnRowSelected="RowSelected" /><ClientEvents OnRowClick="RowClick" /></ClientSettings><MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No"><CommandItemSettings ExportToPdfText="Export to PDF" /><RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn><ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn><Columns><telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false"
                            HeaderStyle-Width="20"><ItemTemplate><asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label></ItemTemplate></telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                            HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                            HeaderText="Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME"
                            HeaderStyle-Width="20" Visible="True"><HeaderStyle Width="150px" /></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                            HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No"
                            HeaderStyle-Width="30" Visible="True"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ASTYPE" FilterControlAltText="Filter ASTYPE column"
                            HeaderText="ASTYPE" ReadOnly="True" SortExpression="ASTYPE" UniqueName="ASTYPE"
                            Visible="false"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ASCAT" FilterControlAltText="Filter ASCAT column"
                            HeaderText="ASCAT" ReadOnly="True" SortExpression="ASCAT" UniqueName="ASCAT"
                            Visible="false"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter Description column"
                            HeaderText="Description" ReadOnly="True" SortExpression="Description" UniqueName="Description"
                            HeaderStyle-Width="20" Visible="True"><HeaderStyle Width="150px" /></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="TRNTYP" FilterControlAltText="Filter TRNTYP column"
                            HeaderText="TRNTYP" ReadOnly="True" SortExpression="TRNTYP" UniqueName="TRNTYP"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="TRNDT" FilterControlAltText="Filter TRNDT column"
                            HeaderText="TRNDT" ReadOnly="True" SortExpression="TRNDT" UniqueName="TRNDT"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Txn_Type" FilterControlAltText="Filter Txn_Type column"
                            HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type"
                            HeaderStyle-Width="20" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                            HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                            HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source"
                            HeaderStyle-Width="20" Visible="True"><HeaderStyle Width="100px" /></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                            HeaderText="Acq_Remarks" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                            HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address"
                            HeaderStyle-Width="40" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                            HeaderText="Identification No" ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
                            Visible="True"><HeaderStyle Width="50px" /></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="IDDESC" FilterControlAltText="Filter IDDESC column"
                            HeaderText="Details" ReadOnly="True" SortExpression="IDDESC" UniqueName="IDDESC"
                            Visible="True"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                            HeaderText="Qty" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="false"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="TRNAMT" FilterControlAltText="Filter TRNAMT column"
                            HeaderText="Amount" ReadOnly="True" SortExpression="TRNAMT" UniqueName="TRNAMT"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                            HeaderText="Purchase Amount" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
                            Visible="True"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                            HeaderText="Qüantity" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="false"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="SHRPC" FilterControlAltText="Filter SHRPC column"
                            HeaderText="SHRPC" ReadOnly="True" SortExpression="SHRPC" UniqueName="SHRPC"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="COOWNER" FilterControlAltText="Filter COOWNER column"
                            HeaderText="COOWNER" ReadOnly="True" SortExpression="COOWNER" UniqueName="COOWNER"
                            Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="UNIT" FilterControlAltText="Filter UNIT column" HeaderText="UNIT" ReadOnly="True" SortExpression="UNIT" UniqueName="UNIT" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="CURVAL" FilterControlAltText="Filter CURVAL column" HeaderText="CURVAL" ReadOnly="True" SortExpression="CURVAL" UniqueName="CURVAL" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ANINCM" FilterControlAltText="Filter ANINCM column" HeaderText="ANINCM" ReadOnly="True" SortExpression="ANINCM" UniqueName="ANINCM" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="REMARKS" FilterControlAltText="Filter REMARKS column" HeaderText="Remarks" ReadOnly="True" SortExpression="REMARKS" UniqueName="REMARKS" Visible="True"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column" HeaderText="STATUS" ReadOnly="True" SortExpression="STATUS" UniqueName="STATUS" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="TRN_PERIOD" FilterControlAltText="Filter TRN_PERIOD column" HeaderText="TRN_PERIOD" ReadOnly="True" SortExpression="TRN_PERIOD" UniqueName="TRN_PERIOD" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ACQDT" FilterControlAltText="Filter ACQDT column" HeaderText="ACQDT" ReadOnly="True" SortExpression="ACQDT" UniqueName="ACQDT" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ASCAT_OTHDESC" FilterControlAltText="Filter ASCAT_OTHDESC column" HeaderText="ASCAT_OTHDESC" ReadOnly="True" SortExpression="ASCAT_OTHDESC" UniqueName="ASCAT_OTHDESC" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ASTYPE_OTHDESC" FilterControlAltText="Filter ASTYPE_OTHDESC column" HeaderText="ASTYPE_OTHDESC" ReadOnly="True" SortExpression="ASTYPE_OTHDESC" UniqueName="ASTYPE_OTHDESC" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="ACQ_SOURCE_OTHDESC" FilterControlAltText="Filter ACQ_SOURCE_OTHDESC column" HeaderText="ACQ_SOURCE_OTHDESC" ReadOnly="True" SortExpression="ACQ_SOURCE_OTHDESC" UniqueName="ACQ_SOURCE_OTHDESC" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn DataField="CONSVAL" FilterControlAltText="Filter CONSVAL column" HeaderText="CONSVAL" ReadOnly="True" SortExpression="CONSVAL" UniqueName="ACQ_SOURCE_OTHDESC" Visible="False"></telerik:GridBoundColumn><%-- <telerik:GridBoundColumn DataField="ADDLINE1" FilterControlAltText="Filter ADDLINE1 column"
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
                </telerik:GridBoundColumn>--%><telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Select" HeaderText="Edit" ImageUrl="../Images/edit_32.png" UniqueName="Select"></telerik:GridButtonColumn><%--<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    HeaderText="Edit" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/edit_32.png" onclick="ImageButton1_Click" />
                    </ItemTemplate>

                </telerik:GridTemplateColumn>--%></Columns><EditFormSettings><EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn></EditFormSettings></MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu><HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu></telerik:RadGrid>
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
        var cell = MasterTable.getCellByColumnUniqueName(Row, "Trn_Amount");
        //alert(cell.innerHTML)
    }
</script>
<script type="text/javascript">

    function RowSelected(sender, eventArgs) {

    }


</script>

<script>
    function convertNumberToWords(amount) {
        var words = new Array();
        words[0] = '';
        words[1] = 'One';
        words[2] = 'Two';
        words[3] = 'Three';
        words[4] = 'Four';
        words[5] = 'Five';
        words[6] = 'Six';
        words[7] = 'Seven';
        words[8] = 'Eight';
        words[9] = 'Nine';
        words[10] = 'Ten';
        words[11] = 'Eleven';
        words[12] = 'Twelve';
        words[13] = 'Thirteen';
        words[14] = 'Fourteen';
        words[15] = 'Fifteen';
        words[16] = 'Sixteen';
        words[17] = 'Seventeen';
        words[18] = 'Eighteen';
        words[19] = 'Nineteen';
        words[20] = 'Twenty';
        words[30] = 'Thirty';
        words[40] = 'Forty';
        words[50] = 'Fifty';
        words[60] = 'Sixty';
        words[70] = 'Seventy';
        words[80] = 'Eighty';
        words[90] = 'Ninety';
        amount = amount.toString();
        var atemp = amount.split(".");
        var number = atemp[0].split(",").join("");
        var n_length = number.length;
        var words_string = "";
        if (n_length <= 9) {
            var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
            var received_n_array = new Array();
            for (var i = 0; i < n_length; i++) {
                received_n_array[i] = number.substr(i, 1);
            }
            for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
                n_array[i] = received_n_array[j];
            }
            for (var i = 0, j = 1; i < 9; i++, j++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    if (n_array[i] == 1) {
                        n_array[j] = 10 + parseInt(n_array[j]);
                        n_array[i] = 0;
                    }
                }
            }
            value = "";
            for (var i = 0; i < 9; i++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    value = n_array[i] * 10;
                } else {
                    value = n_array[i];
                }
                if (value != 0) {
                    words_string += words[value] + " ";
                }
                if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Crores ";
                }
                if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Lakhs ";
                }
                if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Thousand ";
                }
                if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                    words_string += "Hundred and ";
                } else if (i == 6 && value != 0) {
                    words_string += "Hundred ";
                }
            }
            words_string = words_string.split("  ").join(" ");
        }
        return words_string;
    }
    Inwords += " Rupees Only";
    //alert(Inwords);
</script>

<script>
    var textBox;
    var demo = window.demo = {};
    var textBoxServerID;

    demo.load = function (sender, args) {
        textBox = sender;
        textBoxServerID = getServerId(sender.get_id());
    };
    demo.valueChanged = function (sender, args) {
        logEvent(textBoxServerID + ".OnValueChanged: Value is changed to " + args.get_newValue());
    }
</script>
<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>