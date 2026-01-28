<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HLD_FOREIGN.ascx.cs" Inherits="PROPERTY_RETURNS.HOLDING.HLD_FOREIGN" %>
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
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label><asp:Label ID="lbl_refno" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Label ID="lbl_action_t" Text="" Visible="false"  runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Panel ID="pnlFV" runat="server">
<div style="font-family: verdana; font-size: small;">
<table>
<tr>
<td>
    <fieldset style="height: 200px; width: 400px; vertical-align:top">
        <legend>Visit Details</legend>
        <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse"
         bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
          <%--  <tr>
                <td>
                    <asp:Label ID="lbl_vrefno" Text="Reference No : " runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Style="font-size: x-small"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label4" Text="Visitor (Relation)" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                </td>
                <td>
                   <%-- <telerik:RadComboBox ID="relation" runat="server" >
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Employee (Self)" Value="Employee (Self)" />
                            <telerik:RadComboBoxItem runat="server" Text="Spouse" Value="Spouse" />
                            <telerik:RadComboBoxItem runat="server" Text="Son" Value="Son" />
                            <telerik:RadComboBoxItem runat="server" Text="Daughter" Value="Daughter" />
                            <telerik:RadComboBoxItem runat="server" Text="Father" Value="Father" />
                            <telerik:RadComboBoxItem runat="server" Text="Mother" Value="Mother" />
                        </Items>
                    </telerik:RadComboBox>--%>
                     <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-" Width="250px">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_vastcat" Text="Visited Countries" runat="server"></asp:Label>
                </td>
                  <td>
                      <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                </td>
                  <td>

                   <telerik:RadComboBox ID="rcb_country" runat="server" 
                        EmptyMessage="-please select country-" Width="250px" ZIndex="900000">
                    </telerik:RadComboBox>
                    <%--<telerik:RadTextBox ID="visited_countries" runat="server" Width="160px">
                    </telerik:RadTextBox>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" Text="Start Date" runat="server">

                    </asp:Label>
                </td>
                  <td>
                      <asp:Label ID="lbl_cummu_req5" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                </td>
                  <td>
                  <telerik:RadDatePicker ID="RadDatePicker1" runat="server" 
                          Height="22px" Width="187px">
        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

        <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server" Height="22px"> 
            </DateInput> 

        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label19b" Text="End Date" runat="server"></asp:Label>
                </td>
                  <td>
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                 </td>
                  <td>
                  <telerik:RadDatePicker ID="RadDatePicker2" runat="server" 
                          Height="22px" Width="187px">
        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

        <DateInput ID="DateInput4" DateFormat="dd/MM/yyyy" runat="server" Height="22px"> 
            </DateInput> 

        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label20" Text="Duration (In days)" runat="server"></asp:Label>
                </td>
                  <td>
                      <asp:Label ID="Label24" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                 </td>
                  <td>
                    <telerik:RadTextBox ID="duration" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
            </tr>


             <tr>
                <td>
                    <asp:Label ID="Label7" Text="Purpose of Visit" runat="server"></asp:Label>
                </td>
                  <td>
                      <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                 </td>
                  <td>
                    <telerik:RadTextBox ID="purpose" runat="server" Height="40px" Width="250px" HtmlEncode="true"
                        NullDisplayText=" ">
                    </telerik:RadTextBox>
                </td>
            </tr>  



            <tr>
                <td colspan="2">
                
                    <asp:Label ID="Label23" Text="Holding Date" runat="server" Visible="False" 
                        ></asp:Label>
                </td>
                <td>
                   <telerik:RadDatePicker ID="rdp_trndt" runat="server"  Visible="False">
                    <DateInput ID="DateInput2" DateFormat="dd/MM/yyyy" runat="server">
                    </DateInput>
                 </telerik:RadDatePicker>
                 <telerik:RadDatePicker ID="rdp_hlddt" runat="server" Enabled="False"  Width="120px"
                        style="font-weight: 700" Visible="False">
                    <DateInput ID="DateInput3" DateFormat="dd/MM/yyyy" runat="server"> 
                    </DateInput>
                    </telerik:RadDatePicker>
                   
                   </td>
            </tr>
           
         
         
        
           
        </table>
    </fieldset>
    </td>
    <td>
    <fieldset style="height: 200px; width: 400px; vertical-align:top">
        <legend>Misc Details</legend>
        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse;"
            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
              <tr>
                <td>
                    <asp:Label ID="Label2" Text="Source of Fund" runat="server"></asp:Label>
                </td>
                  <td>
                      <asp:Label ID="Label25" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                  </td>
                <td>
                    <telerik:RadComboBox ID="rcb_acqsrc" runat="server" EmptyMessage="-please select acquition source-" ZIndex="90000">
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
                <td colspan="2">
                    <asp:Label ID="Label11" Text="Other Fund Source (if any)" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="rtb_othres" runat="server" Width="155px" HtmlEncode="false">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label9" Text="Expenditure Incurred" runat="server"></asp:Label>
                </td>
                <td>
                      <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                  </td>
                <td>
                    <telerik:RadTextBox ID="rtb_expinc" runat="server" Width="155px" EmptyMessage="-please enter Incurred Expenditure-">
                    </telerik:RadTextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" Text="Remarks" runat="server"></asp:Label>
                </td>
                <td>
                   <telerik:RadTextBox ID="rtb_remarks" runat="server" Height="40px" Width="155px" HtmlEncode="true"
                        NullDisplayText=" ">
                    </telerik:RadTextBox>
                </td>
            </tr>
            
        </table>
          <br />
            <telerik:RadButton ID="rb_addnew" runat="server" Text="Add New" OnClick="rb_addnew_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="rb_save" runat="server" Text="Save Draft" OnClick="rb_save_Click">
            </telerik:RadButton>
           <%-- <telerik:RadButton ID="rb_submit" runat="server" Text="Submit" OnClick="rb_submit_Click"  >
            </telerik:RadButton>--%>
            <telerik:RadButton ID="rb_reject" runat="server" Text="Delete Entry" OnClick="rb_reject_Click" Visible="false">
            </telerik:RadButton>
             <asp:Panel ID="epanel" runat="server">
            
        </asp:Panel>
    </fieldset>
    </td>
    </tr>
    </table>
     <br />
Note:Please Enter Details of Personal Foreign visits only.
</div>
<%--</fieldset>--%>
<fieldset style="height: 300px; font-family: verdana; font-size: medium; font-weight: bold;">
    <legend>Foreign Visit Details</legend>
     <telerik:RadButton ID="btnToggle" runat="server" ToggleType="Radio" Checked="True" 
        ButtonType="StandardButton" GroupName="StandardButton" Visible="false"
        onclick="btnToggle_Click">
</telerik:RadButton>
 <telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="False"
                GroupName="StandardButton" ButtonType="StandardButton" Visible="false"
        AutoPostBack="True" onclick="btnToggle1_Click">
</telerik:RadButton>
    <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
        OnNeedDataSource="RG_TRN_OnNeedDataSource" GridLines="None" OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged">
         <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" Scrolling-AllowScroll="true">
            <Selecting AllowRowSelect="True"></Selecting>
            <Scrolling AllowScroll="True"/>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="REFNO" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                    HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="EMPNAME" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME"
                    Visible="True">
                </telerik:GridBoundColumn>
               
                
                <telerik:GridBoundColumn DataField="FV_COUNTRIES" FilterControlAltText="Filter FV_COUNTRIES column"
                    HeaderText="COUNTRIES" ReadOnly="True" SortExpression="FV_COUNTRIES" UniqueName="FV_COUNTRIES"
                     Display="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FV_COUNTRIES_NAME" FilterControlAltText="Filter FV_COUNTRIES_NAME column"
                    HeaderText="COUNTRIES" ReadOnly="True" SortExpression="FV_COUNTRIES_NAME" UniqueName="FV_COUNTRIES_NAME"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FV_START_DATE" FilterControlAltText="Filter FV_START_DATE column"
                    HeaderText="START DATE" ReadOnly="True" SortExpression="FV_START_DATE" UniqueName="FV_START_DATE" DataFormatString="{0:dd/MM/yyyy}"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FV_END_DATE" FilterControlAltText="Filter FV_END_DATE column"
                    HeaderText="END DATE" ReadOnly="True" SortExpression="FV_END_DATE" UniqueName="FV_END_DATE" DataFormatString="{0:dd/MM/yyyy}"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="FV_VISIT_PURPOSE" FilterControlAltText="Filter FV_VISIT_PURPOSE column"
                    HeaderText="PURPOSE OF VISIT" ReadOnly="True" SortExpression="FV_VISIT_PURPOSE" UniqueName="FV_VISIT_PURPOSE"
                    Visible="True">
                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn DataField="FV_EXP_INCUR" FilterControlAltText="Filter FV_EXP_INCUR column"
                    HeaderText="EXPENDITURE INCURRED" ReadOnly="True" SortExpression="FV_EXP_INCUR" UniqueName="FV_EXP_INCUR"
                    Visible="True">
                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn DataField="FV_DURATION" FilterControlAltText="Filter FV_DURATION column"
                    HeaderText="DURATION" ReadOnly="True" SortExpression="FV_DURATION" UniqueName="FV_DURATION"
                    Visible="True">
                </telerik:GridBoundColumn>
             
               
                   <telerik:GridBoundColumn DataField="REMARKS" FilterControlAltText="Filter REMARKS column"
                    HeaderText="REMARKS" ReadOnly="True" SortExpression="REMARKS" UniqueName="REMARKS"
                    Visible="True">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                     </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="ACQDESC" FilterControlAltText="Filter ACQDESC column"
                    HeaderText="ACQDESC" ReadOnly="True" SortExpression="ACQDESC" UniqueName="ACQDESC"
                    Visible="False">
                     </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column"
                    HeaderText="STATUS" ReadOnly="True" SortExpression="STATUS" UniqueName="STATUS"
                     Display="false">
                </telerik:GridBoundColumn>
               
                
                <%--<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    HeaderText="Edit" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/edit_32.png" onclick="ImageButton1_Click" />
                    </ItemTemplate>

                </telerik:GridTemplateColumn>--%>
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
</asp:Panel>
<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
