<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ALL_TRN_SUBMIT.aspx.cs" Inherits="PROPERTY_RETURNS.FINAL_SUBMIT.ALL_TRN_SUBMIT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
          //<![CDATA[

    //Standard Window.confirm
    function StandardConfirm(sender, args) {
        args.set_cancel(!window.confirm("Are you sure, you want to Final Submit all Transactions (Once submitted, no changes can be made) ?"));
    }
          //]]>
    </script>
 <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" Skin="Office2007" />
  <asp:Label runat="server" ID="lblcaption" 
        Text="Final Submit All Saved Transactions" 
        style="color: #CC0000; font-weight: 700"></asp:Label>
<fieldset style="height: 350px;">
        <legend>Saved Transactions-Immovable Property</legend>
   <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0"
       Width="890px" >
        <ClientSettings Scrolling-AllowScroll="true">
            <Scrolling AllowScroll="True"/>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false" HeaderStyle-Width="20">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                    HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="Dep. Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No" HeaderStyle-Width="30"
                    Visible="True">
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
                    HeaderText="Description" ReadOnly="True" SortExpression="Description" UniqueName="Description" HeaderStyle-Width="20"
                    Visible="True">
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
                    HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                    HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                    HeaderText="Acq_Remarks" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                    HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address" HeaderStyle-Width="40"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                    HeaderText="Trn Amount" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SHRPC" FilterControlAltText="Filter SHRPC column"
                    HeaderText="SHRPC" ReadOnly="True" SortExpression="SHRPC" UniqueName="SHRPC"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="COOWNER" FilterControlAltText="Filter COOWNER column"
                    HeaderText="COOWNER" ReadOnly="True" SortExpression="COOWNER" UniqueName="COOWNER"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ADDLINE1" FilterControlAltText="Filter ADDLINE1 column"
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
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UNIT" FilterControlAltText="Filter UNIT column"
                    HeaderText="UNIT" ReadOnly="True" SortExpression="UNIT" UniqueName="UNIT" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                    HeaderText="QTY" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRNAMT" FilterControlAltText="Filter TRNAMT column"
                    HeaderText="TRNAMT" ReadOnly="True" SortExpression="TRNAMT" UniqueName="TRNAMT"
                    Visible="False">
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
                <telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                    HeaderText="OBJECTID" ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
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
                <%--<telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton" UniqueName="Select"
                    ImageUrl="../Images/edit_32.png" HeaderText="Manage">
                </telerik:GridButtonColumn>--%>
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
    <fieldset style="height: 350px;">
        <legend>Saved Transactions-Movable Property</legend>
   <telerik:RadGrid ID="RG_TRN_MO" runat="server" CellSpacing="0"
       Width="890px" >
        <ClientSettings Scrolling-AllowScroll="true">
            <Scrolling AllowScroll="True"/>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false" HeaderStyle-Width="20">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                    HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="Dep. Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No" HeaderStyle-Width="30"
                    Visible="True">
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
                    HeaderText="Description" ReadOnly="True" SortExpression="Description" UniqueName="Description" HeaderStyle-Width="20"
                    Visible="True">
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
                    HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                    HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                    HeaderText="Acq_Remarks" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                    HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address" HeaderStyle-Width="40"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                    HeaderText="Account No" ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
                    Visible="True">
                </telerik:GridBoundColumn>
                
                    <telerik:GridBoundColumn DataField="IDDESC" FilterControlAltText="Filter IDDESC column"
                    HeaderText="Name" ReadOnly="True" SortExpression="IDDESC" UniqueName="IDDESC"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                    HeaderText="Qty" ReadOnly="True" SortExpression="QTY" UniqueName="QTY">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRNAMT" FilterControlAltText="Filter TRNAMT column"
                    HeaderText="TRNAMT" ReadOnly="True" SortExpression="TRNAMT" UniqueName="TRNAMT"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                    HeaderText="Trn Amount" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
                    Visible="True">
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
                        </telerik:GridEditCommandColumn>
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
    <fieldset style="height: 350px;">
        <legend>Saved Transactions-Liability</legend>
   <telerik:RadGrid ID="RG_TRN_LI" runat="server" CellSpacing="0"
       Width="890px" >
        <ClientSettings Scrolling-AllowScroll="true">
            <Scrolling AllowScroll="True"/>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="Ref_No">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber" AllowFiltering="false" HeaderStyle-Width="20">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRowNumber" Width="30px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="EMPNO" FilterControlAltText="Filter EMPNO column"
                    HeaderText="EMPNO" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNO"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="Dep. Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No" HeaderStyle-Width="30"
                    Visible="True">
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
                    HeaderText="Description" ReadOnly="True" SortExpression="Description" UniqueName="Description" HeaderStyle-Width="20"
                    Visible="True">
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
                    HeaderText="Txn Type" ReadOnly="True" SortExpression="Txn_Type" UniqueName="Txn_Type" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="ACQSRC" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Source" FilterControlAltText="Filter Acq_Source column"
                    HeaderText="Acq Source" ReadOnly="True" SortExpression="Acq_Source" UniqueName="Acq_Source" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Acq_Remarks" FilterControlAltText="Filter Acq_Remarks column"
                    HeaderText="Acq_Remarks" ReadOnly="True" SortExpression="Acq_Remarks" UniqueName="Acq_Remarks"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                    HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address" HeaderStyle-Width="40"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                    HeaderText="Account No" ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
                    Visible="True">
                </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IDDESC" FilterControlAltText="Filter IDDESC column"
                    HeaderText="Name" ReadOnly="True" SortExpression="IDDESC" UniqueName="IDDESC"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column"
                    HeaderText="Qty" ReadOnly="True" SortExpression="QTY" UniqueName="QTY" Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                    HeaderText="Trn Amount" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
                    Visible="True">
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
                 <telerik:GridBoundColumn DataField="TRN_PERIOD" FilterControlAltText="Filter TRN_PERIOD column"
                    HeaderText="TRN_PERIOD" ReadOnly="True" SortExpression="TRN_PERIOD" UniqueName="TRN_PERIOD"
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
                <%--<telerik:GridEditCommandColumn ButtonType="ImageButton" HeaderText="Edit" 
                            UniqueName="EditCommandColumn">
                            <HeaderStyle Width="32px" />
                        </telerik:GridEditCommandColumn>--%>
                <telerik:GridButtonColumn CommandName="Select" ButtonType="ImageButton" UniqueName="Select"
                    ImageUrl="../Images/edit_32.png" HeaderText="View">
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
    <telerik:RadButton ID="rbt_submit" runat="server" Text="Submit Transactions" 
            onclick="rbt_submit_Click" OnClientClicking="StandardConfirm">
    </telerik:RadButton>
</asp:Content>
