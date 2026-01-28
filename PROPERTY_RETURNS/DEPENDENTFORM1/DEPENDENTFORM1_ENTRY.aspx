<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DEPENDENTFORM1_ENTRY.aspx.cs" Inherits="PROPERTY_RETURNS.DEPENDENTFORM1.DEPENDENTFORM1_ENTRY" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/style.default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style-light.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap-wizard.min.js" type="text/javascript"></script>
    <link href="../Scripts/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.gritter.min.js" type="text/javascript"></script>
    <script src="../Scripts/modernizr.js" type="text/javascript"></script>
   <script>

       function ShowCallSuccessMessage() {
           $.gritter.add({
               title: 'Success',
               text: 'Data Saved Successfully',
               class_name: 'growl-success gritter-center',
               sticky: false,
               time: '2000',
               after_close: function () {
                   setTimeout($(location).attr('href', '../HOME_PAGE_NEW.aspx'), 100000);
               }
           });
           return false;
       }

       function ShowCallErrorMessage() {
           $.gritter.add({
               title: 'Error',
               text: 'Please Save Form-1 Details First.',
               class_name: 'growl-error gritter-center',
               sticky: false,
               time: '2000'
           });

           return false;
       }
    </script>
    <style type="text/css">
        .auto-style2 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div style="background-color: #F7F7F7;" id="tabs">
<asp:Label ID="Label1" runat="server" Text="Enter Form-1 Details" ForeColor="Red"></asp:Label><br /><br />
<asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="#990033"></asp:Label>
<asp:Label ID="lblhlddt_hidden" runat="server" Visible="False"></asp:Label><br />
<telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" OnItemDataBound="RadGridPrescriber_ItemDataBound">
<MasterTableView AutoGenerateColumns="False">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="PERNR" 
            FilterControlAltText="Filter PERNR column" HeaderText="PERNR" 
            SortExpression="PERNR" UniqueName="PERNR" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SUBTY" 
            FilterControlAltText="Filter SUBTY column" HeaderText="SUBTY" 
            SortExpression="SUBTY" UniqueName="SUBTY"  Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="OBJPS" 
            FilterControlAltText="Filter OBJPS column" HeaderText="OBJPS" 
            SortExpression="OBJPS" UniqueName="OBJPS"  Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="EMPNAME" 
            FilterControlAltText="Filter EMPNAME column" HeaderText="NAME" 
            SortExpression="EMPNAME" UniqueName="EMPNAME">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="RELATION" 
            FilterControlAltText="Filter RELATION column" HeaderText="RELATION" 
            SortExpression="RELATION" UniqueName="RELATION">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter PPOSITION column" HeaderText="*Public Position Held (if any)"  
            UniqueName="PPOSITION" HeaderTooltip="Explanation Text ">
            <ItemTemplate>
                <asp:TextBox ID="tb_pp" runat="server" Height="23px" Width="207px"></asp:TextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter RETURN column" HeaderText="**Whether Return being filed by him/her, separately" 
            UniqueName="RETURN" HeaderTooltip="Explanation Text ">
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="DESC" DataValueField="DESC" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="0" Text="Please Select"></asp:ListItem>
                </asp:DropDownList>
                <%-- <telerik:RadComboBox ID="DropDownList1" runat="server" Width="100px" DataTextField="DESC" DataValueField="DESC" DataSourceID="SqlDataSource2" AppendDataBoundItems="true">
                        <Items>
                             <telerik:RadComboBoxItem Text="Please Select" />
                        </Items>
                </telerik:RadComboBox>--%>



                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PRConnectionString %>" 
                    SelectCommand="SELECT * FROM [YESNO]"></asp:SqlDataSource>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter DEP column" 
            UniqueName="DEP"  HeaderText="***Financially Dependent" HeaderTooltip="Explanation Text ">
            <ItemTemplate>

              <%--  <telerik:RadComboBox ID="dd_DEP" runat="server" Width="100px" DataTextField="DESC" DataValueField="DESC" DataSourceID="SqlDataSource3" AppendDataBoundItems="true">
                        <Items>
                             <telerik:RadComboBoxItem Text="Please Select" />
                        </Items>
                </telerik:RadComboBox>--%>


                <asp:DropDownList ID="dd_DEP" runat="server" 
                    DataSourceID="SqlDataSource3" DataTextField="DESC" DataValueField="DESC" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="0" Text="Please Select"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PRConnectionString %>" 
                    SelectCommand="SELECT * FROM [YESNO]"></asp:SqlDataSource>
                
            </ItemTemplate>
        </telerik:GridTemplateColumn>
       <%-- <telerik:GridCheckBoxColumn FilterControlAltText="Filter DEP column" 
            HeaderText="***Financially Dependent" UniqueName="DEP" ItemStyle-CssClass="btn btn-warning width100" >
<ItemStyle CssClass="btn btn-warning width100"></ItemStyle>
        </telerik:GridCheckBoxColumn>--%>

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>
<FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
 
 <br />
 <asp:Button ID="Button1" CssClass="btn btn-success width300" runat="server" 
        Text="Save Form1 as Draft" onclick="Button1_Click" />
    <br />
 <%--<asp:Button ID="Button2" CssClass="btn btn-danger width300" runat="server" 
        Text="Final Submit Form1" onclick="Button2_Click" />--%>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="*Public Position held"></asp:Label><br />
    <span class="auto-style2">
    <strong>For Self</strong></span>: - Enter designation and name & address of the organization. For example, DGM
(Operation), NTPC Ltd.
For Spouse/children: - If spouse or children is working in any organization, enter his/her
designation, name & address of the organization. If he/she is holding a government office on
virtue of election, then enter position for which he/she has been elected.
    <br /><span class="auto-style2"><strong>For Spouse/children</strong></span>: - If spouse or children is working in any organization, enter his/her designation, name &amp; address of the organization. If he/she is holding a government office on virtue of election, then enter position for which he/she has been elected. <br /><br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="**Whether Return being filed by them separately:"></asp:Label><br />
    If the spouse or children fills the property return separately, then enter ‘Yes’ otherwise ‘No’    
    
    <br /><br />
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="***Financially Dependent"></asp:Label><br />
    As per the explanation given under Sec. 44 of the Lokpal & Lokayukta Act, the definition regarding declaration of assets is as under:<br />
 For the purpose of this Sec., “dependent children” means sons and daughters who have no separate means of earning and are wholly dependent on the public servant for their livelihood.
 </div>
    <asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
</asp:Content>
