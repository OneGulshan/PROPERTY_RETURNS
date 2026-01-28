<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TRN_FOREIGN.ascx.cs" Inherits="PROPERTY_RETURNS.TRN_FOREIGN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%>
<%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
                <div class="col-xs-5" style="border-right: 1px solid #c7c7c7;"></div>
                <legend>Manage Transaction Details</legend>--%>
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<div style="font-family: verdana; font-size: small;">
    <fieldset style="height: 160px; width: 400px;">
        <legend>Visit Details</legend>
        <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse" bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
            <tr>
                <td>
                    <asp:Label ID="lbl_vrefno" Text="Reference No : " runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_refno" runat="server" Style="font-size: x-small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" Text="Visitor (Relation): " runat="server"></asp:Label>
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
                     <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_vastcat" Text="Visited Countries" runat="server"></asp:Label>
                </td>
                  <td>
                    <telerik:RadTextBox ID="visited_countries" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" Text="Start Date" runat="server"></asp:Label>
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
                    <asp:Label ID="Label20" Text="Duration (In days)" runat="server"></asp:Label>
                </td>
                  <td>
                    <telerik:RadTextBox ID="duration" runat="server" Width="160px">
                    </telerik:RadTextBox>
                </td>
            </tr>
          
           
          
            
        
           
        </table>
    </fieldset>
    <fieldset style="height: 160px; width: 400px;">
        <legend>Misc Details</legend>
        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse; height: 145px; width: 101%;"
            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
              <tr>
                <td>
                    <asp:Label ID="Label1" Text="Source of Fund" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="rcb_acqsrc" runat="server" EmptyMessage="-please select acquition source-">
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
                    <asp:Label ID="Label11" Text="Other Fund Source (if any)" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="rtb_othres" runat="server" Width="155px" HtmlEncode="false">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" Text="Remarks" runat="server"></asp:Label>
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
            <telerik:RadButton ID="rb_submit" runat="server" Text="Submit" OnClick="rb_submit_Click"  >
            </telerik:RadButton>
             <asp:Panel ID="epanel" runat="server">
            
        </asp:Panel>
    </fieldset>
    
</div>
<%--</fieldset>--%>
<fieldset style="height: 300px; font-family: verdana; font-size: medium; font-weight: bold;">
    <legend>Transaction Details</legend>
     <telerik:RadButton ID="btnToggle" runat="server" ToggleType="Radio" Checked="True" 
        ButtonType="StandardButton" GroupName="StandardButton" 
        onclick="btnToggle_Click">
    <ToggleStates>
        <telerik:RadButtonToggleState Text="Saved Transactions" PrimaryIconCssClass="rbToggleRadioChecked" />
        <telerik:RadButtonToggleState Text="Saved Transactions" PrimaryIconCssClass="rbToggleRadio" />
    </ToggleStates>
</telerik:RadButton>
 <telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="False"
                GroupName="StandardButton" ButtonType="StandardButton" 
        AutoPostBack="True" onclick="btnToggle1_Click">
                <ToggleStates>
                    <telerik:RadButtonToggleState Text="Submitted Transactions" PrimaryIconCssClass="rbToggleRadioChecked"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="Submitted Transactions" PrimaryIconCssClass="rbToggleRadio"></telerik:RadButtonToggleState>
                </ToggleStates>
</telerik:RadButton>
    <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
        OnNeedDataSource="RG_TRN_OnNeedDataSource" GridLines="None" OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged">
        <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">
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
                    HeaderText="Ref_No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No"
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
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FV_START_DATE" FilterControlAltText="Filter FV_START_DATE column"
                    HeaderText="START DATE" ReadOnly="True" SortExpression="FV_START_DATE" UniqueName="FV_START_DATE" DataFormatString="{0:dd/MM/yyyy}"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="FV_DURATION" FilterControlAltText="Filter FV_DURATION column"
                    HeaderText="DURATION" ReadOnly="True" SortExpression="FV_DURATION" UniqueName="FV_DURATION"
                    Visible="True">
                </telerik:GridBoundColumn>
             
               
                   <telerik:GridBoundColumn DataField="Remarks" FilterControlAltText="Filter Remarks column"
                    HeaderText="Remarks" ReadOnly="True" SortExpression="Remarks" UniqueName="Remarks"
                    Visible="True">
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                     </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column"
                    HeaderText="STATUS" ReadOnly="True" SortExpression="STATUS" UniqueName="STATUS"
                    Visible="False">
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
<%-- </ContentTemplate>
    <Triggers>

                <asp:AsyncPostBackTrigger ControlID="btnsubmit" />
            </Triggers>
</asp:UpdatePanel>--%>

