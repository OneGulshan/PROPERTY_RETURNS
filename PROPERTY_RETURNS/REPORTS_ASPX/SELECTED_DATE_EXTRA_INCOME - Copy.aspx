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
    <style type="text/css">
        .style1 {
            width: 251px;
        }
    </style>
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
                    FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] order by holdingdt desc"></asp:SqlDataSource>
                <br />
                <br />
                <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                        SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt = '1900-08-01' "></asp:SqlDataSource>--%>
                <div style="background-color:lightgreen;">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333">
                        
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
                    </asp:GridView>
                </div>
            </div>

        </div>


    </div>

    <div id="footer">
    </div>

</asp:Content>
