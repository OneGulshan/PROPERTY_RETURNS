<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EXP_REPORT1.aspx.cs" Inherits="PROPERTY_RETURNS.FORMS.EXP_REPORT1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type="text/javascript">
    function showexcepdtl(pernr, year) {
        empstr = "00000000" + pernr;
        var empno=empstr.substring(empstr.length - 8, empstr.length);
     //   alert("pernr:" + empno + ",year:" + year);
        var oWnd = radopen("excep_dtl.aspx?pernr=" + empno + "&year=" + year, "RadWindow1");
        popUpObj.focus();
        LoadModalDiv();
        return false;
    }
    function LoadModalDiv() {
        var bcgDiv = document.getElementById("divBackground");
        bcgDiv.style.display = "block";
    }
    function HideModalDiv() {
        var bcgDiv = document.getElementById("divBackground");
        bcgDiv.style.display = "none";
    }
    function setCustomPosition(sender, args) {
        sender.moveTo(sender.get_left(), sender.get_top());
    }
    </script>
        </telerik:RadCodeBlock>
    <div style="font-family: verdana; font-size: small;">
    <fieldset style="height: 800px; width: 960px;">
        <legend>Exception Report of PR scruitiny for the year:<%=Session["year"] %></legend>
        <div style="border: thin solid #C0C0C0">
        <br />
        <table border="0" width="100%" cellspacing="4" cellpadding="2">

            <tr>
                <td>
                    <asp:Label ID="Label1" Text="PA:" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="rcb_pa" runat="server" DataSourceID="SqlDataSource_PA" DataTextField="PROJECT" DataValueField="PA" AutoPostBack="True"
                        Filter="Contains"  MarkFirstMatch="True"   AllowCustomText="true" EmptyMessage="Select PA"
                         OnClientKeyPressing="(function(sender, e){ if (!sender.get_dropDownVisible()) sender.showDropDown(); })" 
                        onselectedindexchanged="rcb_pa_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
            
                <td>
                    <asp:Label ID="Label2" Text="PSA:" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="rcb_psa" runat="server" DataSourceID="SqlDataSource_PSA" DataTextField="LOCATION" DataValueField="PSA"
                         AutoPostBack="True" Filter="Contains" EmptyMessage="Select PSA"
                         MarkFirstMatch="True"  AllowCustomText="true"
                         OnClientKeyPressing="(function(sender, e){ if (!sender.get_dropDownVisible()) sender.showDropDown(); })" 
                        onselectedindexchanged="rcb_psa_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
            
                <td>
                    <asp:Label ID="Label3" Text="Emp No/Name:" runat="server"></asp:Label>
                </td>
                <td>
                  <telerik:RadComboBox ID="rcb_empno" runat="server" CssClass="txtclass" DataSourceID="SqlDataSource_EMP" 
            DataTextField="EMPNAME" DataValueField="PERNR" Filter="Contains"  AllowCustomText="true"
            MarkFirstMatch="True" EmptyMessage="Select Employee"
            OnClientKeyPressing="(function(sender, e){ if (!sender.get_dropDownVisible()) sender.showDropDown(); })" 
            onselectedindexchanged="rcb_emp_SelectedIndexChanged" Sort="Ascending" 
            TabIndex="2">
        </telerik:RadComboBox>
        </td>
        
        
            </tr>
            <tr>

             <td>
                    <asp:Label ID="Label5" Text="Emp Nos (Multiple):" runat="server"></asp:Label>
                </td>
            <td>
            <asp:TextBox ID="TxtMultiEmp" runat="server" TextMode="MultiLine" 
                    ontextchanged="TxtMultiEmp_TextChanged"></asp:TextBox>
            
            </td>
           <%-- <td>
                    <asp:Label ID="Label4" Text="Status:" runat="server"></asp:Label>
                </td>--%>
            <td colspan="3">

       <%-- <telerik:RadComboBox ID="rcb_status" runat="server" EmptyMessage="Submitted"
                                Width="80px"  Visible="false"
                    OnSelectedIndexChanged="rcb_status_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="All" Value="%" />
                                    <telerik:RadComboBoxItem runat="server" Text="Submitted" Value="HG" />
                                    <telerik:RadComboBoxItem runat="server" Text="Saved" Value="HV" />

                                </Items>
                            </telerik:RadComboBox>--%>
               &nbsp;Scruitiny Year:<telerik:RadComboBox ID="rcb_hlddt" Runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="holdingdt_display" 
                    DataValueField="holdingdt">
                </telerik:RadComboBox>
               <telerik:RadButton ID="BtnSubmit" runat="server" Text="Submit" 
                    onclick="BtnSubmit_Click"  AutoPostBack="true">
            </telerik:RadButton>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PRConnectionString %>" 
                    SelectCommand="SELECT distinct convert(int,year(holdingdt)) as holdingdt_display,convert(varchar,holdingdt,120) as holdingdt FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where convert(int,year(holdingdt))>=2015">
                </asp:SqlDataSource>
                </td>
            </tr>
            
            
            </table>
            <br />
            </div>
            <div style="border: thin solid #C0C0C0">
            <table border="0" width="100%" cellspacing="4" cellpadding="2">

            <tr>
                <td>

             <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" style="height: 600px; width: 950px;"
        OnNeedDataSource="RadGrid1_OnNeedDataSource" EnableViewState="true" Skin="Office2007" OnItemDataBound="RadGrid1_ItemDataBound" AllowSorting="true" 
        Width="940px" AutoGenerateColumns="false">
        <ClientSettings Selecting-AllowRowSelect="true" Scrolling-AllowScroll="true">
            <Selecting AllowRowSelect="True"></Selecting>
            <Scrolling AllowScroll="True" />
        </ClientSettings>
         <GroupingSettings CaseSensitive="false" />
        <MasterTableView AutoGenerateColumns="False" EditMode="InPlace" DataKeyNames="pernr">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
          <%--  <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>--%>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S No." UniqueName="RowNumber">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblRowNumber" Width="32px" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>

                    </ItemTemplate>
                     <FilterTemplate> 
                            Clear Filter
                        <asp:ImageButton ID="btnShowAll" runat="server" ImageUrl="~/Images/FilterCancel.gif" AlternateText="Show All"
                            ToolTip="Show All" OnClick="btnShowAll_Click" Style="vertical-align: middle" />
                    </FilterTemplate>
<HeaderStyle Width="20px"></HeaderStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="PERNR" FilterControlAltText="Filter PERNR column"
                    HeaderText="Emp No" ReadOnly="True" SortExpression="PERNR" UniqueName="PERNR" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="30px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="YEAR" FilterControlAltText="Filter YEAR column"
                    HeaderText="Year" ReadOnly="True" SortExpression="YEAR" UniqueName="YEAR" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true" Display="false">
                    <HeaderStyle Width="30px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMPNAME" FilterControlAltText="Filter EMPNAME column"
                    HeaderText="Emp Name" ReadOnly="True" SortExpression="EMPNAME" UniqueName="EMPNAME" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="130px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Project" FilterControlAltText="Filter Project column"
                    HeaderText="Project" ReadOnly="True" SortExpression="Project" UniqueName="Project" AllowFiltering="false" ShowFilterIcon="false">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Location" FilterControlAltText="Filter Location column"
                    HeaderText="Location" ReadOnly="True" SortExpression="Location" UniqueName="Location" AllowFiltering="false" ShowFilterIcon="false">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Dept" FilterControlAltText="Filter Dept column"
                    HeaderText="Department" ReadOnly="True" SortExpression="Dept" UniqueName="Dept" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="100px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Grade" FilterControlAltText="Filter Grade column"
                    HeaderText="Grade" ReadOnly="True" SortExpression="Grade" UniqueName="Grade" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column"
                    HeaderText="STATUS" ReadOnly="True" SortExpression="STATUS" UniqueName="STATUS" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true" Visible="false">
                    <HeaderStyle Width="25px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DPR" FilterControlAltText="Filter DPR column" DataType="System.Decimal" DataFormatString="{0:#,##,##0.00}"
                    HeaderText="DPR" ReadOnly="True" SortExpression="DPR" UniqueName="DPR" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="NETPAY" FilterControlAltText="Filter NETPAY column" DataType="System.Decimal" DataFormatString="{0:#,##,##0.00}"
                    HeaderText="Net Salary" ReadOnly="True" SortExpression="NETPAY" UniqueName="NETPAY" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn DataField="dprdiff" FilterControlAltText="Filter dprdiff column" DataType="System.Decimal" DataFormatString="{0:#,##,##0.00}"
                    HeaderText="Addition over 75% of Net Salary" ReadOnly="True" SortExpression="dprdiff" UniqueName="dprdiff" ShowFilterIcon="false" CurrentFilterFunction="Contains"  AutoPostBackOnFilter="true">
                    <HeaderStyle Width="50px" />
                </telerik:GridBoundColumn>

                 <telerik:GridTemplateColumn FilterControlAltText="Filter excep column" AllowFiltering="false" ShowFilterIcon="false"
                    HeaderText="Exception Details" UniqueName="excep">

                    <ItemTemplate>
                        <asp:HyperLink ID="Imgexcep" runat="server"  Text="&lt;img src='../Images/appdtl.png' alt='' border='0'/&gt;" onclick='<%# "javascript:showexcepdtl(" + "&#39;" + Eval("PERNR") + "&#39;," + "&#39;" + Eval("YEAR") + "&#39;);" %>  ' style="cursor:pointer; " ></asp:HyperLink>
                    <%--<asp:HyperLink ID="Imgexcep" runat="server"  Text="&lt;img src='Images/appdtl.png' alt='Excep Dtl' border='0'/&gt;" onclick='<%# "javascript:showexcepdtl(" + "&#39;" + Eval("PERNR") + "&#39;);" %>  ' style="cursor:pointer; " ></asp:HyperLink>--%>

                    <%--    <asp:ImageButton ID="Imgsess" runat="server" ImageUrl="~/Images/dtl.png" CommandArgument='<%# Eval("emp_no") %>'  OnClientClick='<%# System.String.Format("javascript:showtripdtl(\"{0}\");return false", Eval("emp_no")) %>' /> --%>
                        <%--OnClientClick='<%# System.String.Format("showtripdtl(this, \"{0}\");return false", Eval("emp_no")) %>' />--%>
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </telerik:GridTemplateColumn>  

                 <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" ShowFilterIcon="false"
                    HeaderText="View Details" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/Viewicon.png" CommandArgument='<%#Container.ItemIndex%>' OnCommand="ImageButton1_Click" />
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </telerik:GridTemplateColumn>
                <%--<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" ShowFilterIcon="false"
                    HeaderText="Details" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/view.jpg" CommandArgument='<%#Container.ItemIndex%>' OnCommand="ImageButton1_Click" />
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </telerik:GridTemplateColumn>--%>
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
<telerik:radwindowmanager ID="RadWindowManager1" RenderMode="Lightweight"    
                                  EnableShadow="true"  VisibleStatusbar="false" 
        Skin="Forest" VisibleTitlebar="true" CenterIfModal="false"
                                  Behaviors="Close, Move, Resize"  DestroyOnClose="true"
                                  runat="server" Width="800" Height="400">
        <Windows>
            <telerik:radwindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" 

Title="Exception_details">
            </telerik:radwindow>
             </Windows>
    </telerik:radwindowmanager>


                    

             


                </td>
                </tr>
                </table>
            
            </div>
             <asp:Panel ID="epanel" runat="server">
                        </asp:Panel>
                        <asp:Label ID="ps" runat="server" ForeColor="Red" Text="* Only employees who have submitted returns for both the years concerned are listed in the report"></asp:Label>
            </fieldset>
            <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PRConnectionString %>" 
            SelectCommand="SP_GENERAL_REPORT1" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="PERNR" Type="String" />
                </SelectParameters>
        </asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource_PA" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ERPConnectionString %>" 
        SelectCommand="SELECT top 1 '%' as PA,'  All' as PROJECT FROM [EMPMASTER] union all  SELECT distinct [PA], [PROJECT] FROM [EMPMASTER] where PA <>'' and PROJECT <> '' order by PROJECT "></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource_PSA" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ERPConnectionString %>" 
        SelectCommand="SELECT top 1 '%' as PSA,'  All' as Location FROM [EMPMASTER] union all SELECT distinct [PSA], [LOCATION] FROM [EMPMASTER] WHERE PA=@PA and PSA <> '' and LOCATION <> '' order by LOCATION">
        <SelectParameters>
        <asp:Parameter Name="PA"  Type="String"/>
        </SelectParameters>
        </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource_EMP" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ERPConnectionString %>" 
        SelectCommand="SELECT top 1 '%' as PERNR,'  All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER] WHERE PA=@PA AND PSA=@PSA order by empname">
        <SelectParameters>
        <asp:Parameter Name="PA"  Type="String"/>
        <asp:Parameter Name="PSA"  Type="String"/>
        </SelectParameters>
        
        </asp:SqlDataSource>
            </div>
           
            
</asp:Content>
