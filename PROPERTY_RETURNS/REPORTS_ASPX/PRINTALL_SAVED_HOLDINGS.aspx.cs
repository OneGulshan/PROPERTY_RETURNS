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
    public partial class PRINTALL_SAVED_HOLDINGS : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        DataTable dt_dep = new DataTable();
        DataTable dt1 = new DataTable();
        public DataTable dt_hdt = new DataTable();
        DateTime holddt=System.DateTime.Now;
        DataTable dt_check = new DataTable();
        DataTable dt_check_li = new DataTable();
        DataTable dt_check_mo = new DataTable();
        String gv_holdingdt = "";
        private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        public string Method = "post";
        public string FormName = "form1";
        public string Url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            //gv_holdingdt = Convert.ToDateTime(Session["getDate"].ToString()).ToString("MM-dd-yyyy"); 
            gv_holdingdt = Convert.ToDateTime(Session["getDate"]).ToString(); 
            lblhlddt_hidden.Text = gv_holdingdt;
            SqlCommand cmd_gettrn = null;
            SqlCommand chk_submit = null;
            SqlDataAdapter ad = new SqlDataAdapter();
           // Label1.Text = "View and Print Saved Holdings for Holding Date : " + Convert.ToDateTime(gv_holdingdt).ToString("dd/MM/yyyy");
            Label1.Text = "View and Print Saved Holdings for Holding Date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
           
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
                Panel222.Visible = false;
                Label lb_info = new Label();
                lb_info.ForeColor = System.Drawing.Color.Red;
                HyperLink hpr1 = new HyperLink();
                hpr1.Text = "Go back to home page";
                hpr1.NavigateUrl = "/PROPERTY_RETURNS/HOME_PAGE_NEW.aspx";
                lb_info.Text = "Holdings are already submitted. You can print submitted holdings.";
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
                        //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = gv_holdingdt;
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

                        lblhldt.Text=Convert.ToDateTime(gv_holdingdt).ToString("dd/MM/yyyy");
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
                            string[] selectedColumns_inv = new[] { "Description", "AMOUNT", "Acq_Source", "REMARKS" };
                            string[] selectedColumns_motor = new[] { "Description", "Details", "Identification_No", "AMOUNT", "Acq_Source", "REMARKS" };
                            string[] selectedColumns_jewel = new[] { "Description", "QTY", "Unit", "AMOUNT", "Acq_Source", "REMARKS" };





                            dt.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt);

                            DataTable dt_temp = new DataTable();
                            dt_temp.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "02";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt_temp);

                            foreach (DataRow dr in dt_temp.Rows)
                            {
                                dt.Rows.Add(dr.ItemArray);
                            }
                            dt_temp.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "09";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt_temp);

                            foreach (DataRow dr in dt_temp.Rows)
                            {
                                dt.Rows.Add(dr.ItemArray);
                            }

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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                            ad.SelectCommand = cmd_gettrn;
                            ad.Fill(dt);
                            dt1.Clear();
                            dt1 = new DataView(dt).ToTable(false, selectedColumns_inv);
                            gv_insu.DataSource = dt1;
                            gv_insu.DataBind();

                            dt.Clear();
                            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
                            cmd_gettrn.CommandType = CommandType.StoredProcedure;
                            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = empno_dep;
                            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
                            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "07";
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
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
                            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
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
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form3.DataSource = dt;
                        gv_form3.DataBind();


                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI_FOR_REPORT", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form4.DataSource = dt;
                        gv_form4.DataBind();


                        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FV", con);

                        dt.Clear();
                        cmd_gettrn.CommandType = CommandType.StoredProcedure;
                        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_HO_SV";
                        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getdate"]).ToString("MM-dd-yyyy");
                        ad.SelectCommand = cmd_gettrn;
                        ad.Fill(dt);
                        gv_form5.DataSource = dt;
                        gv_form5.DataBind();
                        
                        
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PRINTONLY_SAVED_HOLDINGS.aspx");
            //gv_holdingdt = lblhlddt_hidden.Text;
            //PRINTALL_SAVED_HOLDINGS myremotepost = new PRINTALL_SAVED_HOLDINGS();
            //myremotepost.Url = "/PROPERTY_RETURNSREPORTS_ASPX/PRINTONLY_SAVED_HOLDINGS.aspx";
            //myremotepost.Add("holdingdt", gv_holdingdt);
            //myremotepost.Post();
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
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }


        public void Post()
        {
            System.Web.HttpContext.Current.Response.Clear();

            System.Web.HttpContext.Current.Response.Write("<html><head>");

            System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));

            System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));

            for (int i = 0; i < Inputs.Keys.Count; i++)
            {

                System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\" size=\"0\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                string abc = Inputs[Inputs.Keys[i]];

            }
            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body></html>");
            System.Web.HttpContext.Current.Response.End();
        }
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
        }
       
    }
}