using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;


using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PROPERTY_RETURNS.REPORTS_ASPX
{
    public partial class R_FORM1 : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        DataTable dt_dep = new DataTable();
        DataTable dt1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_DEPENDENTS", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            dt_dep.Clear();
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt_dep);
            gv_form1.DataSource = dt_dep;
            gv_form1.DataBind();

            foreach (DataRow row in dt_dep.Rows)
            {
                string empno_dep = row["PERNR"].ToString() + row["SUBTY"].ToString()+row["OBJPS"].ToString();
                string empdep_name = row["EMPNAME"].ToString();

                GridView gv_cash = new GridView();
                GridView gv_insu = new GridView();
                GridView gv_loan = new GridView();
                GridView gv_motor = new GridView();
                GridView gv_jewel = new GridView();
                GridView gv_other = new GridView();

                gv_cash.EmptyDataText = "Nil";
                gv_insu.EmptyDataText = "Nil";
                gv_loan.EmptyDataText = "Nil";
                gv_motor.EmptyDataText = "Nil";
                gv_jewel.EmptyDataText = "Nil";
                gv_other.EmptyDataText = "Nil";

                gv_cash.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                gv_insu.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                gv_loan.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                gv_motor.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                gv_jewel.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                gv_other.Width = System.Web.UI.WebControls.Unit.Percentage(100);

                gv_cash.ShowHeader = false;
                gv_insu.ShowHeader = false;
                gv_loan.ShowHeader = false;
                gv_motor.ShowHeader = false;
                gv_jewel.ShowHeader = false;
                gv_other.ShowHeader = false;
                
                string[] selectedColumns = new[] { "Description", "TRNAMT", "REMARKS" };
                string[] selectedColumns_motor = new[] { "Description","IDDESC","OBJECTID","TRNAMT", "REMARKS" };
                string[] selectedColumns_jewel = new[] { "Description", "QTY", "UNIT", "TRNAMT", "REMARKS" };
                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);
                dt1.Clear();
                dt1 = new DataView(dt).ToTable(false, selectedColumns);
                gv_cash.DataSource = dt1;
                gv_cash.DataBind();


                
                

                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "03";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);                
                dt1.Clear();          
                dt1 = new DataView(dt).ToTable(false, selectedColumns);
                gv_insu.DataSource = dt1;
                gv_insu.DataBind();

                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "07";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);
                dt1.Clear();
                dt1 = new DataView(dt).ToTable(false, selectedColumns);
                gv_loan.DataSource = dt1;
                gv_loan.DataBind();

                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "05";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);
                dt1.Clear();
                dt1 = new DataView(dt).ToTable(false, selectedColumns_motor);
                gv_motor.DataSource = dt1;
                gv_motor.DataBind();

                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "04";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);
                dt1.Clear();
                dt1 = new DataView(dt).ToTable(false, selectedColumns_jewel);
                gv_jewel.DataSource = dt1;
                gv_jewel.DataBind();

                dt.Clear();
                cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                cmd_gettrn.CommandType = CommandType.StoredProcedure;
                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "08";
                ad.SelectCommand = cmd_gettrn;
                ad.Fill(dt);
                dt1.Clear();
                dt1 = new DataView(dt).ToTable(false, selectedColumns);
                gv_other.DataSource = dt1;
                gv_other.DataBind();

                Panel1.Controls.Add(new LiteralControl("<div style='page-break-after: always;'></div>"));
                Panel1.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=0 >"));
                Panel1.Controls.Add(new LiteralControl("<tr>"));
                Panel1.Controls.Add(new LiteralControl("<td colspan=3><div align=center>FORM NO. II"));
                Panel1.Controls.Add(new LiteralControl("<br /> "));
                Panel1.Controls.Add(new LiteralControl("Statement of movable property on first appointment or as on 31st March, 20 ....."));
                Panel1.Controls.Add(new LiteralControl("<br />"));
                Panel1.Controls.Add(new LiteralControl("(Use separate sheets for self, spouse and each dependent child)"));
                Panel1.Controls.Add(new LiteralControl("<br />"));
                Panel1.Controls.Add(new LiteralControl("Name of Public servant / spouse / dependent child : " + empdep_name + "</div>"));
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' width=5% >SNo.</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' colspan=2>Description</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(i)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'  colspan=2><strong>Cash and bank balance</strong>"));
                Panel1.Controls.Add(gv_cash);
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(ii)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' colspan=2>"));
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl("<strong>Insurance (premia paid)</strong><span></div>"));
                Panel1.Controls.Add(gv_insu);
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(iii)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' colspan=2>"));
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl(" <span><strong>Personal loans/advances given to any person or "));
                Panel1.Controls.Add(new LiteralControl("entity including firm,company,trust etc. and other receivables from debtors and"));
                Panel1.Controls.Add(new LiteralControl("the amount (exceeding two months basic pay or Ruppees one lakh as the case may be )</strong></div>"));
                Panel1.Controls.Add(gv_loan);
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(iv)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'  colspan=2>"));
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl("<strong>Motor Vehicles<br /></strong>"));
                Panel1.Controls.Add(new LiteralControl("(Details of Make, Registration number, year of purchase and amount paid)</strong></div>"));
                Panel1.Controls.Add(gv_motor);
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(v)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' colspan=2  text-align: left >"));
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl("<strong>Jewellery"));
                Panel1.Controls.Add(new LiteralControl("<br />"));
                Panel1.Controls.Add(new LiteralControl("[Give details of approximate weight (plus or minus 10 gms in respect of gold and "));
                Panel1.Controls.Add(new LiteralControl("precious stones; plus or minus 100gms. in respect of silver)]"));
                Panel1.Controls.Add(new LiteralControl("</strong>"));
                Panel1.Controls.Add(gv_jewel);
                Panel1.Controls.Add(new LiteralControl("</div>"));
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("<tr style='border:1px solid #333333;'>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;'>(vi)</td>"));
                Panel1.Controls.Add(new LiteralControl("<td style='border:1px solid #333333;' colspan=2>"));
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl("<span><strong>Any other assets (Give details of movable assets "));
                Panel1.Controls.Add(new LiteralControl("not covered in (i) to (v) above) </strong>"));
                Panel1.Controls.Add(new LiteralControl("</div>"));
                Panel1.Controls.Add(gv_other);
                Panel1.Controls.Add(new LiteralControl("<div >"));
                Panel1.Controls.Add(new LiteralControl("<strong>[Indicate the details of an asset, only if the total current value of "));
                Panel1.Controls.Add(new LiteralControl("any particular asset in any particular category (e.g. furniture, fixture, "));
                Panel1.Controls.Add(new LiteralControl("electronic equipments etc.) exceeds two months basic pay or Rs. 1.00 lakh, as "));
                Panel1.Controls.Add(new LiteralControl("the case may be] </strong>"));
                Panel1.Controls.Add(new LiteralControl("</div>"));
                Panel1.Controls.Add(new LiteralControl("</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("<tr>"));
                Panel1.Controls.Add(new LiteralControl("<td colspan=3>*Details of deposits in foreign Bank(s) to be given"));
                Panel1.Controls.Add(new LiteralControl("separately.<br />"));
                Panel1.Controls.Add(new LiteralControl("**Investments above Rs 2 lakhs to be reported individually. Investments below"));
                Panel1.Controls.Add(new LiteralControl("Rs. 2 lakhs may be reported together.<br />"));
                Panel1.Controls.Add(new LiteralControl("***Value indicated in the first return need not be revised in the subsequent "));
                Panel1.Controls.Add(new LiteralControl("returns as long as no new comosite item had been acuired or no existing items "));
                Panel1.Controls.Add(new LiteralControl("had been desposed off, during the relevant year.</td>"));
                Panel1.Controls.Add(new LiteralControl("</tr>"));
                Panel1.Controls.Add(new LiteralControl("</table>"));
                Panel1.Controls.Add(new LiteralControl("<br /> "));
                Panel1.Controls.Add(new LiteralControl("<br /> "));
                
            }
        }
        
    }
}