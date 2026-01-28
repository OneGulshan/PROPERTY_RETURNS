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

using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls; 

namespace PROPERTY_RETURNS.REPORTS_ASPX
{
    public partial class SUBMIT_SAVED_HOLDINGS : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        DataTable dt_dep = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt_check = new DataTable();
        DataTable dt_check_li = new DataTable();
        DataTable dt_check_mo = new DataTable();
        public DataTable dt_hdt = new DataTable();
        DateTime holddt = System.DateTime.Now;
        String gv_holdingdt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
            lblhlddt_hidden.Text = gv_holdingdt;
            Label1.Text = "Submit Saved Holdings for Holding Date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;
            SqlCommand chk_submit = null;
            SqlDataAdapter ad = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }


                    chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FOR_REPORT", con);
                    dt_check.Clear();
                    chk_submit.CommandType = CommandType.StoredProcedure;
                    chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_HO_SG";
                    chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                    ad.SelectCommand = chk_submit;
                    ad.Fill(dt_check);
                    chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI_FOR_REPORT", con);
                    dt_check_li.Clear();
                    chk_submit.CommandType = CommandType.StoredProcedure;
                    chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                    ad.SelectCommand = chk_submit;
                    ad.Fill(dt_check_li);
                    chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
                    dt_check_mo.Clear();
                    chk_submit.CommandType = CommandType.StoredProcedure;
                    chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
                    chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                    ad.SelectCommand = chk_submit;
                    ad.Fill(dt_check_mo);
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            if (dt_check.Rows.Count > 0 || dt_check_li.Rows.Count > 0 || dt_check_mo.Rows.Count > 0)
            {
                pnl_form0.Visible = false;
                pnl_form1.Visible = false;
                Panel1.Visible = false;
                pnl_form3.Visible = false;
                pnl_form4.Visible = false;
                Label lb_info = new Label();
                lb_info.ForeColor = System.Drawing.Color.Red;
                HyperLink hpr1 = new HyperLink();
                hpr1.Text = "Go back to home page";
                hpr1.NavigateUrl = "/PROPERTY_RETURNS/HOME_PAGE_NEW.aspx";
                lb_info.Text = "Holdings are already submitted. You can not submit further for this period.";
                print_panel.Controls.Add(new LiteralControl("<br><br><br>"));
                print_panel.Controls.Add(lb_info);
                print_panel.Controls.Add(new LiteralControl("<br><br><br>"));
                print_panel.Controls.Add(hpr1);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {

                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        //SqlCommand cmd_gethdt = null;
                        //cmd_gethdt = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
                        //cmd_gethdt.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        //cmd_gethdt.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "DT_HO";
                        //SqlDataAdapter ad_hdt = new SqlDataAdapter();
                        //cmd_gethdt.CommandType = CommandType.StoredProcedure;
                        //ad_hdt.SelectCommand = cmd_gethdt;
                        //ad_hdt.Fill(dt_hdt);
                        //if (dt_hdt.Rows.Count > 0)
                        //{
                        //    holddt = Convert.ToDateTime(dt_hdt.Rows[0].Field<DateTime>("HOLDINGDT").ToString());
                        //}
                        //lblhldt.Text = holddt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //hlddt2.Text = holddt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //hlddt3.Text = holddt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        lblhldt.Text = Convert.ToDateTime(gv_holdingdt).ToString("dd/MM/yyyy");
                        hlddt2.Text = Convert.ToDateTime(gv_holdingdt).ToString("dd/MM/yyyy");
                        hlddt3.Text = Convert.ToDateTime(gv_holdingdt).ToString("dd/MM/yyyy");

                        cmd_gettrn = new SqlCommand("SP_GET_DEPENDENTS_FORM1", con);

                        dt_dep.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@HOLDDT", SqlDbType.DateTime).Value = gv_holdingdt;
                        cmd_gettrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt_dep);
                        gv_form1.DataSource = dt_dep;
                        gv_form1.DataBind();

                        var rows_dep = from row in dt_dep.AsEnumerable()
                                       where row.Field<string>("SUBTY").Trim() == ""
                                       && row.Field<string>("OBJPS").Trim() == ""
                                       && row.Field<string>("RELATION").Trim() == "SELF"
                                       select row;
                        lblempname.Text = rows_dep.First()["EMPNAME"].ToString();
                        lblppheld.Text = rows_dep.First()["DESIG"].ToString();
                        lblorgn0.Text = rows_dep.First()["ADDR"].ToString();
                        //con.Close();
                    }

                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
                foreach (DataRow row in dt_dep.Rows)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        try
                        {

                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }
                            string empno_dep = row["PERNR"].ToString() + row["SUBTY"].ToString() + row["OBJPS"].ToString();
                            string empdep_name = row["EMPNAME"].ToString();
                            string relation = row["RELATION"].ToString();

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

                            //gv_cash.ShowHeader = false;
                            //gv_insu.ShowHeader = false;
                            //gv_loan.ShowHeader = false;
                            //gv_motor.ShowHeader = false;
                            //gv_jewel.ShowHeader = false;
                            //gv_other.ShowHeader = false;

                            string[] selectedColumns = new[] { "Description", "AMOUNT", "Acq_Source", "REMARKS" };
                            string[] selectedColumns_motor = new[] { "Description", "Details", "Identification_No", "AMOUNT", "Acq_Source", "REMARKS" };
                            string[] selectedColumns_jewel = new[] { "Description", "QTY", "Unit", "AMOUNT", "Acq_Source", "REMARKS" };
                            dt.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt);

                            DataTable dt_temp = new DataTable();
                            dt_temp.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "02";
                           // cmd_gettrn.Parameters.Add("@ASCAT2", SqlDbType.VarChar).Value = "09";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt_temp);

                            foreach (DataRow dr in dt_temp.Rows)
                            {
                                dt.Rows.Add(dr.ItemArray);
                            }

                            //++++++++++++++++++++++++++++++++++++ Code Starts
                            //Author : Saurabh Sangat
                            //Date : 22.07.2022
                            //Description : To enable new ASCAT : 09 : Bank Balance : this Category was added in the new version

                            DataTable dt_temp1 = new DataTable();
                            dt_temp1.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                           // cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "02";
                             cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "09";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt_temp1);

                            foreach (DataRow dr in dt_temp1.Rows)
                            {
                                dt.Rows.Add(dr.ItemArray);
                            }
                            //-------------------------------------Code Ends

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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
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
                            Panel1.Controls.Add(new LiteralControl("Statement of movable property on first appointment or as on <u>" + hlddt2.Text + "</u>"));
                            Panel1.Controls.Add(new LiteralControl("<br />"));
                            Panel1.Controls.Add(new LiteralControl("(Use separate sheets for self, spouse and each dependent child)"));
                            Panel1.Controls.Add(new LiteralControl("<br />"));
                            Panel1.Controls.Add(new LiteralControl("Name of Public servant / spouse / dependent child : <b><u>" + empdep_name + " ( " + relation + " )</b></u></div>"));
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

                            Panel1.Controls.Add(new LiteralControl("<hr>"));
                            Panel1.Controls.Add(new LiteralControl("<div style='page-break-after: always;'></div>"));
                            //con.Close();
                        }
                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            fndisplay(ex.Message);
                        }
                    }
                }
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FOR_REPORT", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form3.DataSource = dt;
                        gv_form3.DataBind();


                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI_FOR_REPORT", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form4.DataSource = dt;
                        gv_form4.DataBind();


                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FV_FOR_REPORT", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form5.DataSource = dt;
                        gv_form5.DataBind();


                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_EX", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "EX_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form6.DataSource = dt;
                        gv_form6.DataBind();

                        //con.Close();


                        //cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FV", con);

                        //dt.Clear();
                        //cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        //cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        //cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_HO_SV";
                        //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                        //ad.SelectCommand = cmd_gettrn;
                        //ad.Fill(dt);
                        //gv_form5.DataSource = dt;
                        //gv_form5.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PRINTONLY_SAVED_HOLDINGS.aspx");   
        }
        public static void PrintWebControl(Control ctrl, string Script)
        {

            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            if (ctrl is WebControl)
            {
                Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            }
            Page pg = new Page();
            pg.EnableEventValidation = false;
            if (Script != string.Empty)
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
            }
            HtmlForm frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ctrl);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        protected void rbt_submit_Click(object sender, EventArgs e)
        {
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            DataTable dt_submit = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    dt.Clear();
                    SqlCommand chk_form1 = null;
                    //chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and CONVERT(VARCHAR(10),holdingdt,105) = left('" + holddt + "',10) ", con);
                    chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and holdingdt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' ", con);
                    ad.SelectCommand = chk_form1;
                    ad.Fill(dt);
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            if (dt.Rows.Count > 0)
            {
                //using (SqlConnection con = new SqlConnection(ConnectionString))
                //{
                //    try
                //    {
                //        if (con.State != ConnectionState.Open)
                //        {
                //            con.Close();
                //            con.Open();
                //        }

                        
                //        SqlCommand cmd_gettrn = null;
                //        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);

                //        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                //        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                //        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_HO_SV";
                //        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");

                //        ad.SelectCommand = cmd_gettrn;
                //        ad.Fill(dt_submit);

                //        //con.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        //Handle exception, perhaps log it and do the needful
                //        fndisplay(ex.Message);
                //    }
                //}

                //SqlCommand cmd_uptrn = null;
                


                //foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
                //{
                //    using (SqlConnection con = new SqlConnection(ConnectionString))
                //    {
                //        try
                //        {
                //            if (con.State != ConnectionState.Open)
                //            {
                //                con.Close();
                //                con.Open();
                //            }
                //            cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                //            cmd_uptrn.CommandType = CommandType.StoredProcedure;
                //            cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                //            cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HG";
                //            cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                //            cmd_uptrn.ExecuteNonQuery();
                //            //con.Close();
                //        }
                //        catch (Exception ex)
                //        {
                //            //Handle exception, perhaps log it and do the needful
                //            fndisplay(ex.Message);
                //        }
                //    }
                //}
               

                //submit_MO();
                //submit_LI();
                submit_form1();
                SqlCommand cmd_uptrn = null;
                gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE_NEW", con);
                        cmd_uptrn.CommandType = CommandType.StoredProcedure;
                      //  cmd_uptrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                        //cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                        cmd_uptrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_uptrn.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = gv_holdingdt;
                        cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HG";
                        cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd_uptrn.ExecuteNonQuery();
                        //con.Close();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Successmessage", "ShowCallSuccessMessage();", true);
            }
            else
            {
                Label lb_info = new Label();
                lb_info.ForeColor = System.Drawing.Color.Red;
                HyperLink hpr1 = new HyperLink();
                lb_info.Text = "Form-1 details has not been added yet, Kindly save Form-1 Details First.";
                print_panel.Controls.Add(new LiteralControl("<br><br><br>"));
                print_panel.Controls.Add(lb_info);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "ShowCallErrorMessage();", true);
            }
        }
        protected void submit_MO()
        {
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
            DataTable dt_submit = new DataTable();
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_gettrn = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");

                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt_submit);

                    //con.Close();
                }

                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            SqlCommand cmd_uptrn = null;
           


            foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                        cmd_uptrn.CommandType = CommandType.StoredProcedure;
                        cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                        cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HG";
                        cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                        
                        cmd_uptrn.ExecuteNonQuery();
                        //con.Close();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }
            
        }
        protected void submit_LI()
        {
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
            DataTable dt_submit = new DataTable();
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_gettrn = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SV";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");

                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt_submit);

                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            SqlCommand cmd_uptrn = null;
            


            foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                        cmd_uptrn.CommandType = CommandType.StoredProcedure;
                        cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                        cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HG";
                        cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd_uptrn.ExecuteNonQuery();
                        //con.Close();
                    }


                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }
            
        }
        
        protected void submit_form1()
        {
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString();
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    dt.Clear();
                    SqlCommand chk_form1 = null;
                    //chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and CONVERT(VARCHAR(10),holdingdt,105) = left('" + gv_holdingdt + "',10) and status='SV'", con);
                    chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and holdingdt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' and status='SV'", con);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = chk_form1;
                    ad.Fill(dt);
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        try
                        {

                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }
                            string PERNR = row["PERNR"].ToString().Replace("&nbsp;", "");
                            string SUBTY = row["SUBTY"].ToString().Replace("&nbsp;", "");
                            string OBJPS = row["OBJPS"].ToString().Replace("&nbsp;", "");
                            string ppheld = row["PPHELD"].ToString().Replace("&nbsp;", "");
                            string return1 = row["RERUNFILED"].ToString().Replace("&nbsp;", "");

                            SqlCommand in_form1 = null;
                            in_form1 = new SqlCommand("SP_INSERT_FORM1", con);
                            in_form1.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = PERNR;
                            in_form1.Parameters.Add("@SUBTY", SqlDbType.VarChar).Value = SUBTY;
                            in_form1.Parameters.Add("@OBJPS", SqlDbType.VarChar).Value = OBJPS;
                            in_form1.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = gv_holdingdt;
                            in_form1.Parameters.Add("@PPHELD", SqlDbType.VarChar).Value = ppheld;
                            in_form1.Parameters.Add("@RERUNFILED", SqlDbType.VarChar).Value = return1;
                            in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                            in_form1.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                            in_form1.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                            in_form1.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "UP";
                            in_form1.CommandType = CommandType.StoredProcedure;
                            in_form1.ExecuteNonQuery();
                            //con.Close();
                        }

                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            fndisplay(ex.Message);
                        }
                    }
                }
            }
            else
            {
                fndisplay("No record updated");
            }
            
        }

        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }
       
    }
}