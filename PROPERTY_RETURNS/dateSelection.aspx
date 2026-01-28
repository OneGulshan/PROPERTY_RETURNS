<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dateSelection.aspx.cs" Inherits="PROPERTY_RETURNS.dateSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <%-- <link rel="stylesheet" type="text/css" href="Scripts/StyleSheet.css" />--%>
 <%--   <script src="../Scripts/jquery-1.11.0.min.js"></script>--%>

</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 251px;
        }
    </style>
    <div id="container">
        <%-- <div id="header">
            <div class="title">
                <div class="titleMainText"><b>NTPC (CC-SCOPE/EOC) Meeting Hall Booking System </b></div>
                 <div class="titleAddAccount">
                    <asp:Button ID="chngForgetPass" runat="server" CssClass="addButton" 
                     Text="Change Password" OnClick="chngForgetPass_Click" TabIndex="0" />
                      <asp:Button ID="logout" runat="server" CssClass="addButton" Text="[Logout]" OnClick="logout_Click" />
                 </div>                      
             </div>
       </div>         --%>
        <div id="main1Wrap">
            <div class="empHomeWrap">
                <div class="strip">
                    <div class="stripText">
                        <center><b>Holding Date Selection </b></center>
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
                                    <asp:Label ID="selectionDate" runat="server" Text="Select Holding Date: " CssClass="selectDateCss"></asp:Label>

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
                                </td>
                                <td align="left">

                                    <asp:DropDownList ID="DDL_Date" runat="server"
                                        Width="240px" DataSourceID="SqlDataSource1" DataTextField="showholdingdt"
                                        DataValueField="HOLDINGDT">
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                    SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT
                    FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] WHERE STATUS='A' order by holdingdt desc"
                    ></asp:SqlDataSource>
                <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRConnectionString %>"
                        SelectCommand="select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt
                    ,HOLDINGDT FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt = '1900-08-01' "></asp:SqlDataSource>--%>
            </div>
            <fieldset>
                <legend style="color: #800000">Guidelines
                </legend>
                <div style="color: #336699; font-weight: bold; font-family: legend;">
                    <p style="text-align: justify">
                        * The period of filing of property return can be changed from the menu item 'Change Holding Date'
                    </p>
                    <p style="text-align: justify">
                        * You are requested to first fill the Property Return as on 31.12.XXXX (where XXXX represent the previous calender year) in the system and submit the same.
               
                    </p>
                    <p style="text-align: justify">* You are then requested to submit the second Property Return as on 31.12.YYYY (where YYYY represent the current calender year) only after submission of first return as on 31.12.XXXX (where XXXX represents the previous calender year). 
                        All the submitted assets and liabilities of the previous period (31.12.XXXX) will automatically be carried forward and available for modification/correction. 
                        If previous return is not submitted/not entered, no carry forward will be done.</p>
                    <p style="text-align: justify">* The status of submission of Property Return made available on 'Home' screen.</p>
                    <p style="text-align: justify">
                        * The Holdings declared can be seen from 'My Returns' Menu
                    </p>
                </div>


                <%--<div style="color: #336699; font-weight: bold;">
                    <p style="text-align: justify">
                        * The period of filing of property return can be changed from the menu item 'Change Holding Date'
                    </p>
                    <p style="text-align: justify">
                        * You are requested to first fill the Property Return as on 01.08.2014 in the system and submit the same.>
               
                    </p>
                    <p style="text-align: justify">* You are then requested to submit the second Property Return as on 31.03.2015 only after submission of first return as on 01.08.2014. All the submitted assets and liabilities of the previous period (01.08.2014) will automatically be carried forward and available for modification/correction. If previous return is not submitted/not entered, no carry forward will be done.</p>
                    <p style="text-align: justify">* The status of submission of Property Return made available on 'Home' screen.</p>
                    <p style="text-align: justify">
                        * The Holdings declared can be seen from 'My Returns' Menu
                    </p>
                </div>--%>
            </fieldset>
        </div>

    </div>

    <div id="footer">
    </div>

</asp:Content>
