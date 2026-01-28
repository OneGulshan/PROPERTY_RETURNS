<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SELECTED_DATE_EXTRA_INCOME.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS_ASPX.SELECTED_DATE_EXTRA_INCOME" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

  <%--  <link href="../Scripts/StyleSheet.css" rel="stylesheet" />--%>
    <script src="../Scripts/jquery-1.11.0.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    
    <asp:Panel ID="pnlFV" runat="server">
    <div style="font-family: verdana; font-size: small">
        <table>
            <tr>
                <td>
                    <fieldset style="height: 350px; width: 900px; vertical-align: top">
                        <legend>Print Other Income Details</legend>
                        <div id="container">
        <div id="main1Wrap">
            <div class="empHomeWrap">
                <div class="strip">
                    <div class="stripText">
                        <center><b>My  Extra Income APR </b></center>
                    </div>
                </div>
                <div class="selectDateFormArea">
                    <h2>
                        <asp:Label ID="welcomeText" runat="server" Text="" CssClass="selectDateCss"></asp:Label>
                    </h2>
                    <div style="margin-top: 10px; text-align: left">

                        <table style="text-align: left">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="selectionDate" runat="server" Text="Select APR Year: " CssClass="selectDateCss"></asp:Label>

                                    <%--<td valign="top">
                                            <div style="margin-left:15px;"><asp:TextBox ID="date1" runat="server"></asp:TextBox></div>                                        
                                        </td>
                                    --%>
                                    <%-- <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Culture="en-US" 
                                            Calendar-ShowDayCellToolTips="false">
                                        <Calendar ID="Calendar1" runat="server" ></Calendar>
                                        <DateInput ID="date1" DisplayDateFormat="d/M/yyyy" DateFormat="d/M/yyyy" runat="server"></DateInput>
                           <DatePopupButton ImageUrl="Images/Calendar.png" ToolTip="" HoverImageUrl ="Images/Calendar.png"/>

                        </telerik:RadDatePicker>--%>
                                    <%
                                        
                                     %>
                                    
                                </td>
                                <td align="left">

                                    <asp:DropDownList ID="DDL_Date" runat="server" DataSourceID="SqlDataSource1" DataTextField="showholdingdt" DataValueField="HOLDINGDT" Width="240px">
                                        <asp:ListItem Selected="True" Text="--Select Holding Year --" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <%-- </td>--%>
                            </tr>
                            <%--<tr>
                                  <td style="text-align:left" align="left" class="style1">
                                   <asp:Label ID="Label1" runat="server" Text="Select Location:" CssClass="selectDateCss"></asp:Label>
                                   </td>
                                   <td>
                                            <telerik:RadComboBox ID="rcb_location" runat="server" 
                                                EmptyMessage="Select Location" Width="350px">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="CC-SCOPE" Value="CC" />
                                                    <telerik:RadComboBoxItem runat="server" Text="CC-EOC" Value="EOC" />
                                                </Items>
                                            </telerik:RadComboBox>
                                  
                                    </td>                
                                  
                                        </tr>--%>
                        </table>


                        <asp:Label ID="lblerr" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                    </div>



                    <asp:Button ID="submit" runat="server" CssClass="nextButton" Text="Next" OnClick="submit_Click" />
                </div>
                <br />
                <br />
                <br />

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                    SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT
                    FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where status='A' order by holdingdt desc"></asp:SqlDataSource>
                <br />
                <br />
                <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                        SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt = '1900-08-01' "></asp:SqlDataSource>--%>
                <div style="background-color:lightgreen;">

                    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333">
                        
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>--%>
                    
                </div>
            </div>

        </div>


    </div>
                        <br />
                        <br />
                         
                       
                    </fieldset>
                </td>
                
            </tr>
        </table>
       
    </div>
    <div>
            
         



         
        </div>
    <%--</fieldset>--%>
    <fieldset style="font-family: verdana; font-size: medium; font-weight: bold;" runat="server" id="fd_print" visible="false">
        <legend>Other Income Details</legend>
        <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" skin="Office2007"
                Width="940px" Height="400px" OnItemDataBound="RG_TRN_ItemDataBound">
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
    </fieldset>
</asp:Panel>








    

    <div id="footer">
    </div>

</asp:Content>