<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HLD_IMMOVABLE.ascx.cs" Inherits="PROPERTY_RETURNS.HOLDING.HLD_IMMOVABLE" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style>
    .tooltip {
        position: relative;
        display: inline-block;
        border-bottom: 1px dotted black;
        top: 0px;
        left: 1px;
        height: 15px;
        z-index: 99999999;
    }

        .tooltip .im_tooltiptext {
            visibility: hidden;
            width: 350px;
            background-color: #000000;
            color: #FFFFFF;
            text-align: left;
            font-family :Verdana ;
            font-size :medium ;
            border-radius: 6px;
            padding: 5px 0;
            /*font-weight: bold;*/
            /* Position the tooltip */
            position: absolute;
            z-index: 99999999;
            text-align: left;
        }

        .tooltip:hover .im_tooltiptext {
            visibility: visible;
        }


    .auto-style2 {
        height: 54px;
    }


    .auto-style3 {
        width: 169px;
    }
</style>
<script type="text/javascript">
    function RowClick(sender, eventArgs) {

        alert("Click on row instance: " + eventArgs.get_itemIndexHierarchical());


        document.getElementById('lbl_prop_acq_value').innerHTML = 'ok';

        var emptyBox = $find('rtb_propval');

        if (emptyBox.isEmpty()) {
            alert('Please, enter a not empty value.');
        }
        else {
            alert('Thank you!');
        }


        // var txt_box = $find("rtb_propval").get_element();
        // document.getElementById('lbl_prop_acq_value').innerHTML = 'my value';
        // document.getElementById('lbl_prop_acq_value').innerHTML = txt_box.get_value();//document.getElementById('rtb_propval').value;

        var a = ['', 'one ', 'two ', 'three ', 'four ', 'five ', 'six ', 'seven ', 'eight ', 'nine ', 'ten ', 'eleven ', 'twelve ', 'thirteen ', 'fourteen ', 'fifteen ', 'sixteen ', 'seventeen ', 'eighteen ', 'nineteen '];
        var b = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

        document.getElementById('lbl_prop_acq_value').innerHTML = inWords(document.getElementById('rtb_propval').value);

        function inWords(num) {
            if ((num = num.toString()).length > 9) return 'overflow';
            n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
            if (!n) return; var str = '';
            str += (n[1] != 0) ? (a[Number(n[1])] || b[n[1][0]] + ' ' + a[n[1][1]]) + 'crore ' : '';
            str += (n[2] != 0) ? (a[Number(n[2])] || b[n[2][0]] + ' ' + a[n[2][1]]) + 'lakh ' : '';
            str += (n[3] != 0) ? (a[Number(n[3])] || b[n[3][0]] + ' ' + a[n[3][1]]) + 'thousand ' : '';
            str += (n[4] != 0) ? (a[Number(n[4])] || b[n[4][0]] + ' ' + a[n[4][1]]) + 'hundred ' : '';
            str += (n[5] != 0) ? ((str != '') ? 'and ' : '') + (a[Number(n[5])] || b[n[5][0]] + ' ' + a[n[5][1]]) + 'only ' : '';
            return str;
        }



    }




</script>
<%--<asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>--%><%--<fieldset style="height: 250px; font-family: verdana; font-size: medium; font-weight: bold;">
                <div class="col-xs-5" style="border-right: 1px solid #c7c7c7;"></div>
                <legend>Manage Transaction Details</legend>--%>
<br />
<asp:Label ID="lbl_action" Text="" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label><asp:Label ID="lbl_refno" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Label ID="lbl_action_t" Text="" Visible="false" runat="server" Style="font-weight: 700; font-size: medium"></asp:Label>
<asp:Label ID="lblhlddt" runat="server" Font-Size="X-Large" ForeColor="#990033"></asp:Label><br />

<asp:Panel ID="pnlIM" runat="server">
    <div style="font-family: verdana; font-size: small; vertical-align: top; text-align: left;">
      <%--  <table style="width: 920px; height: 594px; text-align: left; vertical-align: top;" onload="myscript();">--%>
        <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse; vertical-align: top;">
            <tr style="text-align: left; vertical-align: top">
                <td style="text-align: left; vertical-align: top">
                    <fieldset style="height: 550px; width: 330px;">
                        <legend>Holding Details</legend>
                        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse; width: 106%; text-align: left; vertical-align: top; height: auto;"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                            <tr style="text-align: left; vertical-align: top">
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image8" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Select the Name of the Property Owner</span>
                                    </div>

                                    &nbsp;
                                </td>
                                <td  style="width: 40%">
                                    <asp:Label ID="Label4" runat="server" Text="Name Of Property Owner"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="lbl_cummu_req" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_EMP" runat="server" EmptyMessage="-please select dependent-" Width="95%">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image5" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Select the type of property from drop down</span>
                                    </div>

                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_vastcat" runat="server" Text="Description Of Property"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_astcat" runat="server"
                                        EmptyMessage="-please select asset cat-" AutoPostBack="True"
                                        OnSelectedIndexChanged="rcb_astcat_SelectedIndexChanged" Width="95%" ZIndex="90000">
                                    </telerik:RadComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image9" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**If land is selected, then select nature of land from drop down</span>
                                    </div>

                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Asset Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_asttype" runat="server"
                                        EmptyMessage="-please select asset type-" AutoPostBack="True"
                                        OnSelectedIndexChanged="rcb_asttype_SelectedIndexChanged" Width="95%" ZIndex="90000">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="img_others" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Visible="False" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**If Other is selected, then enter description of others </span>
                                    </div>

                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lbl_others" runat="server" Text="Details of Others" Visible="False"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <telerik:RadTextBox ID="txtbx_others_asttype" runat="server" Height="60px" HtmlEncode="false" Visible="False" Width="155px" TextMode="MultiLine"></telerik:RadTextBox>
                                </td>
                            </tr>




                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Date of Acquisition"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_acqdt" runat="server">
                                        <DateInput DateFormat="dd/MM/yyyy"></DateInput></telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image7" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Select the source of acquisition of property from drop down</span>
                                    </div>


                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Source of Acquisition"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req3" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_acqsrc" runat="server" AutoPostBack="true" EmptyMessage="-please select acquition source-" OnSelectedIndexChanged="rcb_acqsrc_SelectedIndexChanged" Width="95%"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Lbl_oth" runat="server" HtmlEncode="false" Text="Details of Other Sources" Visible="False"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <telerik:RadTextBox ID="rtb_othres" runat="server" Width="155px" HtmlEncode="false" Height="35px" Visible="False" TextMode="MultiLine"></telerik:RadTextBox>
                                </td>
                            </tr>



                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image11" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Mention approx. area with unit of measurement from drop down   </span>
                                    </div>

                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="Area"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req4" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_qty" runat="server" Width="155px"></telerik:RadTextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="rtb_qty" ErrorMessage="Digits/Decimal Only" ForeColor="Red" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Unit of Measurement"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req5" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_unit" runat="server" EmptyMessage="-please select unit-" Width="98%" ZIndex="90000"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image6" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**If property is shared with spouse/ dependent children, then his/her share to be entered through a separate entry 
                        **If shared with any other member, details may be mentioned in the remarks field
                                        </span>
                                    </div>

                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Ownership %"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req6" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_own" runat="server" HtmlEncode="false" Width="155px"></telerik:RadTextBox>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="rtb_own" ErrorMessage="Digits Only" ForeColor="Red" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image12" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Mention name and details of person(s)/organisation(s) from whom acquired 
                        (Address and connection of the Government servant(if any) with the 
                        person(s)/organisation(s) concerned may also mentioned)
                                        </span>
                                    </div>


                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label12" runat="server" Text="Details of person(s) from whom acquired "></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <telerik:RadTextBox ID="rtb_acqfrom" runat="server" Height="40px" HtmlEncode="true" NullDisplayText=" " TextMode="MultiLine" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label16" runat="server" Text="Ownership %" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_coown" runat="server" Width="155px" HtmlEncode="false" Visible="False"></telerik:RadTextBox>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="rtb_coown" ErrorMessage="Digits/Decimal Only" ForeColor="Red" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="tooltip">
                                        <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />

                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Mention distinctive number of property (if any)</span>
                                    </div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label11" runat="server" Text="Reg. No."></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_reg" runat="server" Width="130px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; text-align: left">&nbsp;</td>
                                <td style="vertical-align: top; text-align: left" colspan="2">
                                    <asp:Label ID="Label14" runat="server" Text="Details of Others" Visible="False"></asp:Label>
                                </td>
                                <td style="vertical-align: top; text-align: left">
                                    <telerik:RadTextBox ID="txt_others" runat="server" Width="155px" HtmlEncode="false" Height="40px" TextMode="MultiLine" Visible="False"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; text-align: left">&nbsp;</td>
                                <td style="vertical-align: top; text-align: left" colspan="2">
                                    <asp:Label ID="Label3" runat="server" Text="Transaction Type" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_cummu_req7" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_trntype" runat="server" EmptyMessage="-please select trn type-" Enabled="false" Visible="false" Width="95%"></telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td >&nbsp;</td>
                                <td colspan="2" >
                                    <asp:Label ID="Label23" runat="server" Style="font-weight: 700" Text="Holding Date" Visible="False"></asp:Label>
                                </td>
                                <td >
                                    <telerik:RadDatePicker ID="rdp_trndt" runat="server" Visible="False">
                                        <DateInput DateFormat="dd/MM/yyyy"></DateInput></telerik:RadDatePicker>
                                    <telerik:RadDatePicker ID="rdp_hlddt" runat="server" Enabled="False"
                                        Style="font-weight: 700" Visible="False">
                                        <DateInput DateFormat="dd/MM/yyyy"></DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td>
                    <fieldset style="height: 500px; width: 265px;">
                        <legend>Address Details</legend>
                        <table border="0" width="100%" cellspacing="4" cellpadding="2" style="border-collapse: collapse; height: 468px; vertical-align: top; text-align: left;"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Address/Plot no./House No/ Quarter no"></asp:Label>  <%--25.03.2022 - Heading changed - Address/ Plot no included for more clarity--%>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req10" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_addline1" runat="server" Height="30px" TextMode="MultiLine" Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label6" Text="Village / Name of Society" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_addline2" runat="server" Height="30px"
                                        Width="155px" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label7" Text="Post Office" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_city" runat="server"
                                        Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label24" Text="Taluk/Sector" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_city0" runat="server" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label25" runat="server" Text="District"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_city1" runat="server" Width="155px"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="State"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req11" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_state" runat="server" EmptyMessage="-please select state-" ExpandDirection="Up" ZIndex="90000">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req12" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_country" runat="server"
                                        EmptyMessage="-please select country-" ExpandDirection="Up" AutoPostBack="True" OnSelectedIndexChanged="rcb_country_SelectedIndexChanged" ZIndex="90000">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label8" runat="server" Text="Postcode"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtb_post" runat="server" Width="155px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td>
                    <fieldset style="height: 300px; width: 300px;">
                        <legend>Amount Details</legend>
                        <table border="0" cellspacing="4" cellpadding="2" style="border-collapse: collapse; width: 100%;"
                            bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0">

                            <tr>
                                <td style="text-align: left; vertical-align: top">
                                    <div class="tooltip">
                                        <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />

                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**The amount invested in acquiring the property including registration cost may be declared </span>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Property Acquisition Value" Width="100%"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req8" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td >
                                    <telerik:RadTextBox ID="rtb_propval" runat="server" Width="98%" OnTextChanged="rtb_propval_TextChanged" AutoPostBack="True"></telerik:RadTextBox>




                                    <asp:Label ID="lbl_rtb_propval" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Italic="True" ForeColor="#006699"></asp:Label>

                                </td>
                            </tr>


                            <tr>
                                <td style="text-align: left; vertical-align: top">

                                    <div class="tooltip">
                                        <asp:Image ID="Image3" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Mention current approx. value of the property(if available)</span>
                                    </div>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label21" runat="server" Text="Prop. Current Value"></asp:Label>
                                    (if any)</td>
                                <td >
                                    <telerik:RadTextBox ID="rtb_propcur_val" runat="server" AutoPostBack="True" OnTextChanged="rtb_propcur_val_TextChanged" Width="98%">
                                    </telerik:RadTextBox>


                                    <%--                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="rtb_propcur_val" ErrorMessage="Digits Only" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                                    <br />
                                    <asp:Label ID="lbl_prop_curr_value" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; vertical-align: top">
                                    <div class="tooltip">
                                        <asp:Image ID="Image4" runat="server" Height="16px" ImageUrl="~/Images/info.jpg" Width="16px" />
                                        <span class="im_tooltiptext" style="position: fixed; z-index: auto; top: 20%; left: 40%;">**Mention any income from the property. In case of no income mention zero</span>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Property Annual Income"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_cummu_req9" runat="server" Font-Bold="True" ForeColor="#CC3300" Text="*"></asp:Label>
                                </td>
                                <td >
                                    <telerik:RadTextBox ID="rtb_ann_in" runat="server" AutoPostBack="True" OnTextChanged="rtb_ann_in_TextChanged" Width="98%">
                                    </telerik:RadTextBox>

                                    <%--                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="rtb_ann_in" ErrorMessage="Digits Only" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                                    <br />
                                    <asp:Label ID="lbl_annu_value" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Small" ForeColor="#006699"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label22" runat="server" Text="Remarks"></asp:Label>
                                </td>
                                <td  style="vertical-align: top; text-align: left">
                                    <telerik:RadTextBox ID="rtb_remarks" runat="server" Height="40px" Width="98%" HtmlEncode="true"
                                        NullDisplayText=" " TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <telerik:RadButton ID="rb_addnew" runat="server" Text="Add New" OnClick="rb_addnew_Click"></telerik:RadButton>
                        <telerik:RadButton ID="rb_save" runat="server" Text="Save Draft" OnClick="rb_save_Click"></telerik:RadButton>
                        <telerik:RadButton ID="rb_reject" runat="server" Text="Delete Entry" OnClick="rb_reject_Click" Visible="false"></telerik:RadButton>
                        <br />
                        <br />
                        <div style='text-align: left'>
                            <asp:Panel ID="epanel" runat="server"></asp:Panel>
                        </div>
                    </fieldset>
                </td>
            </tr>

        </table>
        <div style="vertical-align: top; text-align: left">
            Note: For purpose of Cell Name "Source of Acquisition", the term "lease" would mean a lease of immovable property from year to year or for any term exceeding one year or 
    reserving a yearly rent. Where, however, the lease of immovable property is obtained from person having official dealings with the Government servent, 
    such a lease should be shown in this Column irrespective of the term of lease, whether it is short term or long term, and the periodicity of the payment of rent.
        </div>

    </div>
    <%--</fieldset>--%>
    <fieldset style="height: 90%; width: 90%; font-family: verdana; font-size: small; font-weight: bold;">
        <legend id="lg_dtl">Holding Details</legend>
        
        <div>
            <telerik:RadButton ID="btnToggle3" runat="server" ToggleType="Radio" Checked="False"
            ButtonType="StandardButton" GroupName="StandardButton"
            OnClick="btnToggle3_Click" Visible="false">
        </telerik:RadButton>
        <telerik:RadButton ID="btnToggle2" runat="server" ToggleType="Radio" Checked="False" Text="Convert Submitted Transactions to Holding"
            GroupName="StandardButton" ButtonType="StandardButton"
            AutoPostBack="True" OnClick="btnToggle2_Click" Visible="false">
        </telerik:RadButton>
        <telerik:RadButton ID="btnToggle1" runat="server" ToggleType="Radio" Checked="True"
            ButtonType="StandardButton" GroupName="StandardButton"
            OnClick="btnToggle1_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnToggle4" runat="server" ToggleType="Radio" Checked="False"
            ButtonType="StandardButton" GroupName="StandardButton"
            OnClick="btnToggle4_Click" Visible="false">
        </telerik:RadButton>
            <telerik:RadGrid ID="RG_TRN" runat="server" CellSpacing="0" OnItemDataBound="RG_TRN_ItemDataBound"
        OnNeedDataSource="RG_TRN_OnNeedDataSource" 
        OnSelectedIndexChanged="RG_TRN_OnSelectedIndexChanged" Width="940px" Height ="120px" >
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
                    HeaderText="Name" ReadOnly="True" SortExpression="EMPNO" UniqueName="EMPNAME" HeaderStyle-Width="30"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Ref_No" FilterControlAltText="Filter Ref_No column"
                    HeaderText="Ref No" ReadOnly="True" SortExpression="Ref_No" UniqueName="Ref_No" HeaderStyle-Width="30"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="ASCATDESC" FilterControlAltText="Filter ASCATDESC column"
                    HeaderText="Asset Category" ReadOnly="True" SortExpression="ASCATDESC" UniqueName="ASCATDESC" HeaderStyle-Width="20"
                    Visible="false">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter Description column"
                    HeaderText="Description of Property" ReadOnly="True" SortExpression="Description" UniqueName="Description" HeaderStyle-Width="20"
                    Visible="True">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="ASCAT" FilterControlAltText="Filter ASCAT column"
                    HeaderText="Asset Category" ReadOnly="True" SortExpression="ASCAT" UniqueName="ASCAT"
                    Visible="false">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="ASTYPE" FilterControlAltText="Filter ASTYPE column"
                    HeaderText="Asset Type" ReadOnly="True" SortExpression="ASTYPE" UniqueName="ASTYPE"
                    Visible="false">
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
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACQSRC" FilterControlAltText="Filter ACQSRC column"
                    HeaderText="Source" ReadOnly="True" SortExpression="ACQSRC" UniqueName="ACQSRC"
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
                <telerik:GridBoundColumn DataField="OBJECTID" FilterControlAltText="Filter OBJECTID column"
                    HeaderText="Reg.No." ReadOnly="True" SortExpression="OBJECTID" UniqueName="OBJECTID"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column"
                    HeaderText="Address" ReadOnly="True" SortExpression="Address" UniqueName="Address" HeaderStyle-Width="40"
                    Visible="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Trn_Amount" FilterControlAltText="Filter Trn_Amount column"
                    HeaderText="Acquisition Value" ReadOnly="True" SortExpression="Trn_Amount" UniqueName="Trn_Amount"
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
                    HeaderText="Annual Income" ReadOnly="True" SortExpression="ANINCM" UniqueName="ANINCM"
                    Visible="True">
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
                <telerik:GridBoundColumn DataField="ACQFROM" FilterControlAltText="Filter ACQFROM column"
                    HeaderText="ACQFROM" ReadOnly="True" SortExpression="ACQFROM" UniqueName="ACQFROM"
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
        </div>

    </fieldset>


</asp:Panel>

<asp:Label ID="lblcatch" runat="server" Text=""></asp:Label>
<%--<telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    HeaderText="Edit" UniqueName="TemplateColumn">

                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/edit_32.png" onclick="ImageButton1_Click" />
                    </ItemTemplate>

                </telerik:GridTemplateColumn>--%>
