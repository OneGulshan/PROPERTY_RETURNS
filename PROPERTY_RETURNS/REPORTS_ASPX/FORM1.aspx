<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FORM1.aspx.cs" Inherits="PROPERTY_RETURNS.REPORTS_ASPX.FORM1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" width="100%" bordercolorlight="#000000" bordercolordark="#000000" style="border-collapse: collapse" >
	<tr>
		<td colspan="3">FORM NO. II
        <br />
        Statement of movable property on first appointment or as on 31st March, 20 .....
        <br />
        (Use separate sheets for self, spouse and each dependent child)
        <br />
        Name of Public servant / spouse / dependent child
        </td>
		
	</tr>
	<tr>
		<td class="style4">SNo.</td>
		<td colspan="2">Description</td>
	</tr>
	<tr>
		<td class="style4">(i)</td>
		<td style="text-align: left" colspan="2"><strong>Cash and bank balance</strong>
        <asp:GridView ID="gv_cash" 
                runat="server" AutoGenerateColumns="False" ShowHeader="False"
                Width="100%">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
           
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        </td>
	</tr>
	<tr>
		<td class="style4">(ii)</td>
		<td colspan="2">
            <div class="style1">
                <strong>Insurance (premia paid)</strong><span class="style3"></div>
            <asp:GridView ID="gv_insu" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" style="text-align: left" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
              
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        

        </td>
	</tr>
	<tr>
		<td class="style4">(iii)</td>
		<td colspan="2">
            <div class="style1">
                <span class="style3"><strong>Personal loans/advances given to any person or 
                entity including firm,company,trust etc. and other receivables from debtors and 
                the amount (exceeding two months basic pay or Ruppees one lakh as the case may 
                be )</strong></div>
            <asp:GridView ID="gv_loan" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" style="text-align: left" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
              
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        

        

        </td>
	</tr>
	<tr>
		<td class="style4">(iv)</td>
		<td class="style5" colspan="2">
            <div class="style1">
                <strong>Motor Vehicles<br />
&nbsp;(Details of Make, Registration number, year of purchase and amount paid)</strong></div>
            <asp:GridView ID="gv_motor" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" style="text-align: left" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
              
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        

        

        </td>
	</tr>
	<tr>
		<td class="style4">(v)</td>
		<td colspan="2"  text-align: left" class="style1">
            <div class="style1">
                <strong>Jewellery
            <br />
            [Give details of approximate weight (plus or minus 10 gms in respect of gold and 
            precious stones; plus or minus 100gms. in respect of silver)]
            </strong>
            </div>
            
            <asp:GridView ID="gv_jewel" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" style="text-align: left" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
              
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        

        

        

        </td>
	</tr>
	<tr>
		<td class="style4">(vi)</td>
		<td colspan="2">
            <div class="style1">
                <span class="style3"><strong>Any other assets (Give details of movable assets 
                not covered in (i) to (v) above) </strong>
            </div>
            
            <asp:GridView ID="gv_other" 
                runat="server" AutoGenerateColumns="False" 
                Width="100%" style="text-align: left" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
              
                <asp:BoundField DataField="TRNAMT" HeaderText="TRNAMT" 
                    SortExpression="TRNAMT" />
                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                    SortExpression="REMARKS" />  
            </Columns>
            </asp:GridView>
        

        

        

            <div class="style1">
                <strong>[Indicate the details of an asset, only if the total current value of 
                any particular asset in any particular category (e.g. furniture, fixture, 
                electronic equipments etc.) exceeds two months basic pay or Rs. 1.00 lakh, as 
                the case may be] </strong>

            </div>
        </td>
	</tr>
	<tr>
		<td class="style1" colspan="3">*Details of deposits in foreign Bank(s) to be given 
            separately.<br />
            **Investments above Rs 2 lakhs to be reported individually. Investments below 
            Rs. 2 lakhs may be reported together.<br />
            ***Value indicated in the first return need not be revised in the subsequent 
            returns as long as no new comosite item had been acuired or no existing items 
            had been desposed off, during the relevant year.</td>
	</tr>
	<tr>
		<td class="style6" colspan="3">&nbsp;</td>
	</tr>
	<tr>
		<td class="style6" colspan="3"></td>
	</tr>
	<tr>
		<td class="style4">&nbsp;</td>
		<td>&nbsp;</td>
		<td></span></td>
	</tr>
</table>
    </div>
    </form>
</body>
</html>
