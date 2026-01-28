using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Globalization;
using System.Text.RegularExpressions;

using System.Configuration;
using System.Drawing;
namespace PROPERTY_RETURNS.HOLDING
{
    public partial class HLD_MOVABLE : System.Web.UI.UserControl
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        public DataTable dt_dep = new DataTable();
        public DataTable dt_ind = new DataTable();
        public DataTable dt_emp = new DataTable();
        public DataTable dt_hdt = new DataTable();
        public DataTable dt_rj = new DataTable();
        //static char action;
        //static string action_t;
        public DateTime pre_hold_dt;
        public DateTime acqdt = System.DateTime.Now;
        public DateTime today = System.DateTime.Now;
        GLB_FNS obj_gl = new GLB_FNS();
        private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        public string Method = "post";
        public string FormName = "form1";
        public string Url = "";
        String parent_holddt = "";

        public string Words_To_Rupees(Int64 rup)
        {
            string result = "";
            Int64 res;

            if (rup == 0)
            {
                result = result + ' ' + " Zero";
            }

            if ((rup / 10000000) > 0)
            {
                res = rup / 10000000;
                rup = rup % 10000000;
                result = result + ' ' + RupeesToWords(res) + " Crore";
            }
            if ((rup / 100000) > 0)
            {
                res = rup / 100000;
                rup = rup % 100000;
                result = result + ' ' + RupeesToWords(res) + " Lakh";
            }
            if ((rup / 1000) > 0)
            {
                res = rup / 1000;
                rup = rup % 1000;
                result = result + ' ' + RupeesToWords(res) + " Thousand";
            }
            if ((rup / 100) > 0)
            {
                res = rup / 100;
                rup = rup % 100;
                result = result + ' ' + RupeesToWords(res) + " Hundred";
            }
            if ((rup % 10) >= 0)
            {
                res = rup % 100;
                result = result + " " + RupeesToWords(res);
            }

            result = '(' + result + ' ' + " Rupees only)";
            return result;
        }
        public string RupeesToWords(Int64 rup)
        {
            string result = "";
            if ((rup >= 1) && (rup <= 10))
            {
                if ((rup % 10) == 1) result = "One";
                if ((rup % 10) == 2) result = "Two";
                if ((rup % 10) == 3) result = "Three";
                if ((rup % 10) == 4) result = "Four";
                if ((rup % 10) == 5) result = "Five";
                if ((rup % 10) == 6) result = "Six";
                if ((rup % 10) == 7) result = "Seven";
                if ((rup % 10) == 8) result = "Eight";
                if ((rup % 10) == 9) result = "Nine";
                if ((rup % 10) == 0) result = "Ten";
            }
            if (rup > 9 && rup < 20)
            {
                if (rup == 11) result = "Eleven";
                if (rup == 12) result = "Twelve";
                if (rup == 13) result = "Thirteen";
                if (rup == 14) result = "Forteen";
                if (rup == 15) result = "Fifteen";
                if (rup == 16) result = "Sixteen";
                if (rup == 17) result = "Seventeen";
                if (rup == 18) result = "Eighteen";
                if (rup == 19) result = "Nineteen";
            }
            if (rup >= 20 && (rup / 10) == 2 && (rup % 10) == 0) result = "Twenty";
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) == 0) result = "Thirty";
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) == 0) result = "Forty";
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) == 0) result = "Fifty";
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) == 0) result = "Sixty";
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) == 0) result = "Seventy";
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) == 0) result = "Eighty";
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) == 0) result = "Ninty";

            if (rup > 20 && (rup / 10) == 2 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Twenty One";
                if ((rup % 10) == 2) result = "Twenty Two";
                if ((rup % 10) == 3) result = "Twenty Three";
                if ((rup % 10) == 4) result = "Twenty Four";
                if ((rup % 10) == 5) result = "Twenty Five";
                if ((rup % 10) == 6) result = "Twenty Six";
                if ((rup % 10) == 7) result = "Twenty Seven";
                if ((rup % 10) == 8) result = "Twenty Eight";
                if ((rup % 10) == 9) result = "Twenty Nine";
            }
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Thirty One";
                if ((rup % 10) == 2) result = "Thirty Two";
                if ((rup % 10) == 3) result = "Thirty Three";
                if ((rup % 10) == 4) result = "Thirty Four";
                if ((rup % 10) == 5) result = "Thirty Five";
                if ((rup % 10) == 6) result = "Thirty Six";
                if ((rup % 10) == 7) result = "Thirty Seven";
                if ((rup % 10) == 8) result = "Thirty Eight";
                if ((rup % 10) == 9) result = "Thirty Nine";
            }
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Forty One";
                if ((rup % 10) == 2) result = "Forty Two";
                if ((rup % 10) == 3) result = "Forty Three";
                if ((rup % 10) == 4) result = "Forty Four";
                if ((rup % 10) == 5) result = "Forty Five";
                if ((rup % 10) == 6) result = "Forty Six";
                if ((rup % 10) == 7) result = "Forty Seven";
                if ((rup % 10) == 8) result = "Forty Eight";
                if ((rup % 10) == 9) result = "Forty Nine";
            }
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Fifty One";
                if ((rup % 10) == 2) result = "Fifty Two";
                if ((rup % 10) == 3) result = "Fifty Three";
                if ((rup % 10) == 4) result = "Fifty Four";
                if ((rup % 10) == 5) result = "Fifty Five";
                if ((rup % 10) == 6) result = "Fifty Six";
                if ((rup % 10) == 7) result = "Fifty Seven";
                if ((rup % 10) == 8) result = "Fifty Eight";
                if ((rup % 10) == 9) result = "Fifty Nine";
            }
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Sixty One";
                if ((rup % 10) == 2) result = "Sixty Two";
                if ((rup % 10) == 3) result = "Sixty Three";
                if ((rup % 10) == 4) result = "Sixty Four";
                if ((rup % 10) == 5) result = "Sixty Five";
                if ((rup % 10) == 6) result = "Sixty Six";
                if ((rup % 10) == 7) result = "Sixty Seven";
                if ((rup % 10) == 8) result = "Sixty Eight";
                if ((rup % 10) == 9) result = "Sixty Nine";
            }
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Seventy One";
                if ((rup % 10) == 2) result = "Seventy Two";
                if ((rup % 10) == 3) result = "Seventy Three";
                if ((rup % 10) == 4) result = "Seventy Four";
                if ((rup % 10) == 5) result = "Seventy Five";
                if ((rup % 10) == 6) result = "Seventy Six";
                if ((rup % 10) == 7) result = "Seventy Seven";
                if ((rup % 10) == 8) result = "Seventy Eight";
                if ((rup % 10) == 9) result = "Seventy Nine";
            }
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Eighty One";
                if ((rup % 10) == 2) result = "Eighty Two";
                if ((rup % 10) == 3) result = "Eighty Three";
                if ((rup % 10) == 4) result = "Eighty Four";
                if ((rup % 10) == 5) result = "Eighty Five";
                if ((rup % 10) == 6) result = "Eighty Six";
                if ((rup % 10) == 7) result = "Eighty Seven";
                if ((rup % 10) == 8) result = "Eighty Eight";
                if ((rup % 10) == 9) result = "Eighty Nine";
            }
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Ninty One";
                if ((rup % 10) == 2) result = "Ninty Two";
                if ((rup % 10) == 3) result = "Ninty Three";
                if ((rup % 10) == 4) result = "Ninty Four";
                if ((rup % 10) == 5) result = "Ninty Five";
                if ((rup % 10) == 6) result = "Ninty Six";
                if ((rup % 10) == 7) result = "Ninty Seven";
                if ((rup % 10) == 8) result = "Ninty Eight";
                if ((rup % 10) == 9) result = "Ninty Nine";
            }

            return result;
        }

        private string Convert_To_Indian_Currency_System(string value)
        {
            try
            {
                string return_value = value;
                var var = Convert.ToDouble(return_value);
                double double_Value = Convert.ToDouble(var);
                CultureInfo cultureInfo = new CultureInfo("en-IN");
                return_value = string.Format(cultureInfo, "{0:C}", double_Value);
                return return_value;

            }
            catch
            {
                return "";
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            parent_holddt = Session["getDate"].ToString();
            rdp_hlddt.SelectedDate = Convert.ToDateTime(parent_holddt);
            rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
            if (!IsPostBack)
            {

                dt_dep.Clear();
                dt_ind.Clear();
                dt_emp.Clear();
                dt_hdt.Clear();
                //action = 'A';
                Session["action_t"] = "ADD_NEW_HOLDING";
                lbl_action_t.Text = "ADD_NEW_HOLDING";
                //  bind_grid();
                rb_addnew.Visible = false;
                rb_reject.Visible = false;
                lbl_refno.Text = "";
                lbl_action.Text = "Add New Holding";
                //SqlConnection con = null;
                //con = new SqlConnection(ConnectionString);
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd_getdep = null;
                        SqlCommand cmd_getind = null;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        cmd_getdep = new SqlCommand("SP_GET_DEP_PARAMS", con);
                        cmd_getind = new SqlCommand("SP_GET_IND_PARAMS", con);
                        SqlDataAdapter ad_dep = new SqlDataAdapter();
                        SqlDataAdapter ad_ind = new SqlDataAdapter();
                        cmd_getdep.CommandType = CommandType.StoredProcedure;
                        cmd_getind.CommandType = CommandType.StoredProcedure;
                        ad_dep.SelectCommand = cmd_getdep;
                        ad_ind.SelectCommand = cmd_getind;
                        ad_dep.Fill(dt_dep);
                        ad_ind.Fill(dt_ind);

                        dt_emp.Clear();
                        SqlCommand cmd_getemp = null;
                        cmd_getemp = new SqlCommand("SP_GET_EMP_DETAILS", con);
                        cmd_getemp.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        SqlDataAdapter ad_emp = new SqlDataAdapter();
                        cmd_getemp.CommandType = CommandType.StoredProcedure;
                        ad_emp.SelectCommand = cmd_getemp;
                        ad_emp.Fill(dt_emp);
                        rcb_EMP.DataSource = dt_emp;
                        rcb_EMP.DataTextField = "EMPNAME";
                        rcb_EMP.DataValueField = "EMPNO";
                        rcb_EMP.DataBind();

                        //SqlCommand cmd_gethdt = null;
                        //cmd_gethdt = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
                        //cmd_gethdt.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        //cmd_gethdt.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "DT_HO";
                        //SqlDataAdapter ad_hdt = new SqlDataAdapter();
                        //cmd_gethdt.CommandType = CommandType.StoredProcedure;
                        //ad_hdt.SelectCommand = cmd_gethdt;
                        //ad_hdt.Fill(dt_hdt);
                        //if (dt_hdt.Rows.Count > 0)
                        //{
                        //    rdp_hlddt.SelectedDate = Convert.ToDateTime(dt_hdt.Rows[0].Field<DateTime>("HOLDINGDT").ToString());
                        //    pre_hold_dt = Convert.ToDateTime(dt_hdt.Rows[0].Field<DateTime>("PRE_HOLDING_DT").ToString());
                        //    rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                        //}
                        parent_holddt = Session["getDate"].ToString();
                        rdp_hlddt.SelectedDate = Convert.ToDateTime(parent_holddt);
                        rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                        //((Label)(Parent.FindControl("lblhlddt_hidden"))).Text = rdp_hlddt.SelectedDate.ToString();
                        //((Label)(Parent.FindControl("lblhlddt"))).Text = "Enter Holding Details for Holding Date : " + Convert.ToDateTime(rdp_hlddt.SelectedDate.ToString()).ToString("dd/MM/yyyy");

                        //btnToggle1.Text = "Saved Holdings as On " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //btnToggle4.Text = "Final Submitted Holdings as On " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //btnToggle3.Text = "Carry Forward Holdings of " + Convert.ToDateTime(pre_hold_dt).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        rcb_EMP.DataSource = dt_emp;
                        rcb_EMP.DataTextField = "EMPNAME";
                        rcb_EMP.DataValueField = "EMPNO";
                        rcb_EMP.DataBind();

                        var rows_ascat = from row in dt_dep.AsEnumerable()
                                         where row.Field<string>("PRPTYPE").Trim() == "MO"
                                         select row;
                        DataView view_ascat = rows_ascat.AsDataView();
                        DataTable distinctValues_ascat = view_ascat.ToTable(true, "ASCAT", "ASCATDESC");
                        rcb_astcat.DataSource = distinctValues_ascat;
                        rcb_astcat.DataTextField = "ASCATDESC";
                        rcb_astcat.DataValueField = "ASCAT";
                        rcb_astcat.DataBind();

                        var rows_asttype = from row in dt_dep.AsEnumerable()
                                           where row.Field<string>("PRPTYPE").Trim() == "MO"
                                           && row.Field<string>("ASCAT").Trim() == view_ascat[0][2].ToString()
                                           select row;
                        DataView view_asttype = rows_asttype.AsDataView();
                        DataTable distinctValues_asttype = view_asttype.ToTable(true, "ASTYPE", "ASTYPEDESC");
                        rcb_asttype.DataSource = distinctValues_asttype;
                        rcb_asttype.DataTextField = "ASTYPEDESC";
                        rcb_asttype.DataValueField = "ASTYPE";
                        rcb_asttype.DataBind();

                        var rows_trntype = from row in dt_dep.AsEnumerable()
                                           where row.Field<string>("PRPTYPE").Trim() == "MO"
                                           && row.Field<string>("ASCAT").Trim() == view_ascat[0][2].ToString()
                                           && row.Field<string>("ASTYPE").Trim() == view_asttype[0][4].ToString()
                                           && row.Field<string>("TRNTYP").Trim() == "03"
                                           select row;
                        DataView view_trntype = rows_trntype.AsDataView();
                        DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

                        rcb_trntype.DataSource = distinctValues_trntype;
                        rcb_trntype.DataTextField = "TRNTYPDESC";
                        rcb_trntype.DataValueField = "TRNTYP";
                        rcb_trntype.DataBind();

                        var rows_acqsrc = from row in dt_ind.AsEnumerable()
                                          where row.Field<string>("PARAMTYPE").Trim() == "ACQSRC"
                                          select row;
                        DataView view_acqsrc = rows_acqsrc.AsDataView();
                        DataTable distinctValues_acqsrc = view_acqsrc.ToTable(true, "PARAMCD", "PARAMDESC");
                        rcb_acqsrc.DataSource = distinctValues_acqsrc;
                        rcb_acqsrc.DataTextField = "PARAMDESC";
                        rcb_acqsrc.DataValueField = "PARAMCD";
                        rcb_acqsrc.DataBind();

                        //var rows_unit = from row in dt_ind.AsEnumerable()
                        //                where row.Field<string>("PARAMTYPE").Trim() == "UNIT"
                        //                select row;
                        //DataView view_unit = rows_unit.AsDataView();
                        //DataTable distinctValues_unit = view_unit.ToTable(true, "PARAMCD", "PARAMDESC");
                        //rcb_unit.DataSource = distinctValues_unit;
                        //rcb_unit.DataTextField = "PARAMDESC";
                        //rcb_unit.DataValueField = "PARAMCD";
                        //rcb_unit.DataBind();
                        //var rows_unit = from row in dt_ind.AsEnumerable()
                        //                where row.Field<string>("PARAMTYPE_NEW").Trim() == "UNIT_Q"
                        //                select row;
                        //DataView view_unit = rows_unit.AsDataView();
                        //DataTable distinctValues_unit = view_unit.ToTable(true, "PARAMCD", "PARAMDESC");
                        //rcb_unit.DataSource = distinctValues_unit;
                        //rcb_unit.DataTextField = "PARAMDESC";
                        //rcb_unit.DataValueField = "PARAMCD";
                        //rcb_unit.DataBind();



                        //con.Close();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
                if (chk_holding() == "HV")
                {
                    btnToggle1.Text = "Saved Holdings as On " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (chk_holding() == "HG")
                {
                    btnToggle1.Text = "Final Submitted Holdings as On " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                bind_grid();
            }
        }

        protected void rcb_unit_DataBound(object sender, EventArgs e)
        {
            var combo = (RadComboBox)sender;
        }

        protected void RG_TRN_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.IsInEditMode)
            {
            }

        }

        protected void bind_grid()
        {
            string no_records_now = "";
            string holdingdtpre = "";
            string l_type = "";
            dt.Clear();
            if (chk_holding() == "HV")
                l_type = "MO_HO_SV";
            if (chk_holding() == "HG")
                l_type = "MO_HO_SG";
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = l_type;
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        RG_TRN.DataSource = dt;
                        RG_TRN.DataBind();
                      //  populatesapdata();
                    }
                    else
                    {
                        no_records_now = check_records();
                        //no_records_now = "Y";
                    }
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            //if (no_records_now == "Y")
            //{
            //    using (SqlConnection con = new SqlConnection(ConnectionString))
            //    {
            //        try
            //        {

            //            SqlCommand cmd_getdep = null;
            //            SqlCommand cmd_getind = null;
            //            if (con.State != ConnectionState.Open)
            //            {
            //                con.Close();
            //                con.Open();
            //            }

            //            SqlCommand cmd_getst = null;
            //            cmd_getst = new SqlCommand("SELECT MAX(holdingdt) as holdingdt FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] WHERE holdingdt NOT IN (SELECT MAX(holdingdt) FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE]) and holdingdt < '" + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy") + "'", con);
            //            DataTable dt_for = new DataTable();
            //            SqlDataAdapter ad_for = new SqlDataAdapter();
            //            ad_for.SelectCommand = cmd_getst;
            //            ad_for.Fill(dt_for);

            //            if (dt_for.Rows.Count > 0)
            //            {
            //                foreach (DataRow row in dt_for.Rows)
            //                {
            //                    holdingdtpre = row["holdingdt"].ToString();
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //Handle exception, perhaps log it and do the needful
            //            fndisplay(ex.Message);
            //        }
            //    }

            //    if (holdingdtpre != "")
            //    {
            //        using (SqlConnection con = new SqlConnection(ConnectionString))
            //        {
            //            try
            //            {
            //                SqlCommand cmd_gettrn = null;

            //                if (con.State != ConnectionState.Open)
            //                {
            //                    con.Close();
            //                    con.Open();
            //                }


            //                cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
            //                SqlDataAdapter ad = new SqlDataAdapter();

            //                cmd_gettrn.CommandType = CommandType.StoredProcedure;
            //                cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            //                cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
            //                cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(holdingdtpre).ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //                //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(holdingdtpre).ToString("MM-dd-yyyy");
            //                //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = holdingdtpre;
            //                ad.SelectCommand = cmd_gettrn;
            //                ad.Fill(dt);
            //                if (dt.Rows.Count > 0)
            //                {
            //                    foreach (DataRow row in dt.Rows)
            //                    {
            //                        row["Ref_No"] = "To be generated";
            //                    }
            //                    //RG_TRN.DataSource = dt;
            //                    //RG_TRN.DataBind();

            //                    //carryforward();
            //                }
            //                //con.Close();
            //            }
            //            catch (Exception ex)
            //            {
            //                //Handle exception, perhaps log it and do the needful
            //                fndisplay(ex.Message);
            //            }

            //        }


            //        //using (SqlConnection con = new SqlConnection(ConnectionString))
            //        //{
            //        //    try
            //        //    {
            //        //        SqlCommand cmd_gettrn = null;

            //        //        if (con.State != ConnectionState.Open)
            //        //        {
            //        //            con.Close();
            //        //            con.Open();
            //        //        }

            //        //        DataTable dt2 = new DataTable();
            //        //        cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
            //        //        SqlDataAdapter ad = new SqlDataAdapter();

            //        //        cmd_gettrn.CommandType = CommandType.StoredProcedure;
            //        //        cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            //        //        cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_TR_SA";
            //        //        //  cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(holdingdtpre).ToString("MM-dd-yyyy"); ;
            //        //        //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = holdingdtpre;
            //        //        cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(holdingdtpre).ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //        //        ad.SelectCommand = cmd_gettrn;
            //        //        ad.Fill(dt2);
            //        //        if (dt2.Rows.Count > 0)
            //        //        {
            //        //            foreach (DataRow row in dt2.Rows)
            //        //            {
            //        //                row["Ref_No"] = "To be generated";
            //        //                dt.Rows.Add(row);
            //        //            }

            //        //        }


            //        //        //con.Close();
            //        //    }
            //        //    catch (Exception ex)
            //        //    {
            //        //        //Handle exception, perhaps log it and do the needful
            //        //        fndisplay(ex.Message);
            //        //    }

            //        //} Commented by Manjeet on 24.03.2022


            //        if (dt.Rows.Count > 0)
            //        {
            //            RG_TRN.DataSource = dt;
            //            RG_TRN.DataBind();
            //          //  carryforward();
            //          //  populatesapdata();
            //        }
            //    }
               
            //}
        }

        protected void RG_TRN_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RG_TRN.DataSource = dt;
            //RG_TRN.Rebind();
        }

        protected void RG_TRN_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var dataItem = RG_TRN.SelectedItems[0] as GridDataItem;

            if (dataItem != null)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd_getdep = null;
                        SqlCommand cmd_getind = null;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }

                        cmd_getdep = new SqlCommand("SP_GET_DEP_PARAMS", con);
                        cmd_getind = new SqlCommand("SP_GET_IND_PARAMS", con);
                        SqlDataAdapter ad_dep = new SqlDataAdapter();
                        SqlDataAdapter ad_ind = new SqlDataAdapter();
                        cmd_getdep.CommandType = CommandType.StoredProcedure;
                        cmd_getind.CommandType = CommandType.StoredProcedure;
                        ad_dep.SelectCommand = cmd_getdep;
                        ad_ind.SelectCommand = cmd_getind;
                        ad_dep.Fill(dt_dep);
                        ad_ind.Fill(dt_ind);
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }

                rb_addnew.Visible = true;
                rb_reject.Visible = true;
                lbl_action.Text = "Update Holding : " + dataItem["ref_no"].Text;
                //action = 'U';
                lbl_refno.Text = dataItem["ref_no"].Text;
                rcb_EMP.SelectedValue = dataItem["EMPNO"].Text;

                rcb_astcat.SelectedValue = dataItem["ASCAT"].Text;

                var rows_asttype = from row in dt_dep.AsEnumerable()
                                   where row.Field<string>("PRPTYPE").Trim() == "MO"
                                   && row.Field<string>("ASCAT").Trim() == dataItem["ASCAT"].Text
                                   select row;
                DataView view_asttype = rows_asttype.AsDataView();
                DataTable distinctValues_asttype = view_asttype.ToTable(true, "ASTYPE", "ASTYPEDESC");
                rcb_asttype.DataSource = distinctValues_asttype;
                rcb_asttype.DataTextField = "ASTYPEDESC";
                rcb_asttype.DataValueField = "ASTYPE";
                rcb_asttype.DataBind();
                rcb_asttype.SelectedValue = dataItem["ASTYPE"].Text;

                var rows_trntype = from row in dt_dep.AsEnumerable()
                                   where row.Field<string>("PRPTYPE").Trim() == "MO"
                                   && row.Field<string>("ASCAT").Trim() == dataItem["ASCAT"].Text
                                   && row.Field<string>("ASTYPE").Trim() == dataItem["ASTYPE"].Text
                                   && row.Field<string>("TRNTYP").Trim() == "03"
                                   select row;
                DataView view_trntype = rows_trntype.AsDataView();
                DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");
                rcb_trntype.DataSource = distinctValues_trntype;
                rcb_trntype.DataTextField = "TRNTYPDESC";
                rcb_trntype.DataValueField = "TRNTYP";
                rcb_trntype.DataBind();
                rcb_trntype.SelectedValue = "03";

                rcb_acqsrc.SelectedValue = dataItem["ACQSRC"].Text;
                rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                rtb_othres.Text = dataItem["Acq_Remarks"].Text.Replace("&nbsp;", "");
                rtb_qty.Text = dataItem["QTY"].Text.Replace("&nbsp;", "");

                if (rcb_asttype.SelectedItem .Text .Contains("OTHER"))
                {
                    txtbx_others.Visible = true;
                    lbl_others.Visible = true;

                    if (dataItem["ASTYPE_OTHDESC"].Text=="")
                    {
                        txtbx_others.Text = dataItem["ASTYPE_OTHDESC"].Text.Replace("&nbsp;", "");
                    }
                    else
                    {
                        txtbx_others.Text = dataItem["ASTYPE_OTHDESC"].Text;
                    }
                     
                }
                else
                {
                    txtbx_others.Visible = false;
                    lbl_others.Visible = false;

                }

                if (rcb_acqsrc.SelectedValue == "OT")
                {
                    rtb_othres.Visible = true;
                    Lbl_oth.Visible = true;
                  //  rtb_othres.Text = dataItem["ACQ_SOURCE_OTHDESC"].Text;
                }
                else
                {
                    rtb_othres.Visible = false;
                    Lbl_oth.Visible = false;
                }
                //--------------------- ++ Code Starts ++ ------------------------------------------------------------------------
                rtb_amt.Text = dataItem["TRNAMT"].Text.Replace("&nbsp;", "");  // Populated from database

                //Converting value to words
                if (rtb_amt.Text=="")
                {
                    rtb_amt.Text = "";
                }
                else
                {
                    try
                    {
                        decimal d1 = decimal.Parse(rtb_amt.Text);

                        int val1 = Decimal.ToInt32(d1);
                        lbl_pur_value.Text = Words_To_Rupees(val1);
                    }
                    catch (FormatException)
                    {
                        lbl_pur_value.Text = "Enter digits only";
                    }

                    rtb_amt.Text = Convert_To_Indian_Currency_System(rtb_amt.Text);
                }

                
                //--------------------- -- Code Ends -- -------------------------------------------------------------------------


                //--------------------- ++ Code Starts ++ ------------------------------------------------------------------------
                rtb_ann_in.Text = dataItem["ANINCM"].Text.Replace("&nbsp;", "");  // Populated from database


                if (rtb_ann_in.Text != "")
                {

                    //Converting value to words
                    decimal d2 = decimal.Parse(rtb_ann_in.Text);
                    try
                    {
                        int val2 = Decimal.ToInt32(d2);
                        lbl_sum_value.Text = Words_To_Rupees(val2);
                    }
                    catch (FormatException)
                    {
                        lbl_sum_value.Text = "Enter digits only";
                    }

                    rtb_ann_in.Text = Convert_To_Indian_Currency_System(rtb_ann_in.Text);
                }


                //--------------------- -- Code Ends -- -------------------------------------------------------------------------

                rtb_remarks.Text = dataItem["REMARKS"].Text.Replace("&nbsp;", "");
                rtb_refno.Text = dataItem["OBJECTID"].Text.Replace("&nbsp;", "");
                rtb_refdesc.Text = dataItem["IDDESC"].Text.Replace("&nbsp;", "");
                if (dataItem["ACQDT"].Text.Replace("&nbsp;", "") == "")
                {
                    rdp_acqdt.Clear();
                }
                else
                {
                    rdp_acqdt.SelectedDate = Convert.ToDateTime(dataItem["ACQDT"].Text.Replace("&nbsp;", ""));
                }

                string status = dataItem["STATUS"].Text.Trim().Replace("&nbsp;", "");
                string trn_period = dataItem["TRN_PERIOD"].Text.Trim().Replace("&nbsp;", "");
                rcb_unit.SelectedValue = dataItem["UNIT"].Text;

                if (dataItem["ASCAT"].Text == "04" && (dataItem["ASTYPE"].Text == "01" || dataItem["ASTYPE"].Text == "02"))
                {
                    rtb_qty.Visible = true;
                    rcb_unit.Visible = true;
                    Label18.Visible = true;
                    Lblqty.Visible = true;
                }
                else
                {
                    rcb_unit.SelectedValue = "00";
                    rtb_qty.Visible = false;
                    rcb_unit.Visible = false;
                    Label18.Visible = false;
                    Lblqty.Visible = false;
                }
                //


                if (dataItem["ASCAT"].Text == "03" && (dataItem["ASTYPE"].Text == "01" || dataItem["ASTYPE"].Text == "02"))
                {
                    rtb_ann_in.Visible = true;
                    //rcb_unit.Visible = true;
                    Label19.Text = "Yearly Premium Paid";
                    Label20.Visible = true;
                    lbl_sum_value.Visible = true;
                    //Lblqty.Visible = true;
                }
                else
                {
                    // rcb_unit.SelectedValue = "00";
                    // rtb_qty.Visible = false;
                    // rcb_unit.Visible = false;
                    Label19.Text = "Purchase Value/Outstanding Balance";
                    Label20.Visible = false;
                    rtb_ann_in.Visible = false;
                    lbl_sum_value.Visible = false;
                }

                if (status == "HV")
                {
                    Session["action_t"] = "SAVED_HOLDING";
                    lbl_action_t.Text = "SAVED_HOLDING";
                    rb_addnew.Visible = true;
                }
                if (status == "HG" && trn_period == "PRE")
                {
                    Session["action_t"] = "PRE_SUBMITTED_HOLDING";
                    lbl_action_t.Text = "PRE_SUBMITTED_HOLDING";
                }
                if (status == "SG")
                {
                    Session["action_t"] = "SUBMITTED_TRANSACTION";
                    lbl_action_t.Text = "SUBMITTED_TRANSACTION";
                }
            }
        }

        protected void rb_addnew_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
            //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
            //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
            //myremotepost.Post();

        }

        protected void rb_update_Click(object sender, EventArgs e)
        {
            lbl_action.Text = "Update Transaction :";
            //action = 'U';
        }

        protected void rb_save_Click(object sender, EventArgs e)
        {
            today = System.DateTime.Now;
            try
            {
                string error_tag;
                if (rcb_EMP.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Name Of Property Owner");
                }
                else if (rcb_astcat.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Description Of Property");
                }
                else if (rcb_asttype.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Asset Type");
                }
                //else if ((rcb_astcat.SelectedValue.ToString() == "08" || rcb_asttype.SelectedValue.ToString() == "01") && txtbx_others.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Asset type (Others) details");
                //}

                //else if ((rcb_astcat.SelectedValue.ToString() == "03" || rcb_asttype.SelectedValue.ToString() == "09") && txtbx_others.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Asset type (Others) details");
                //}

                //else if ((rcb_astcat.SelectedValue.ToString() == "02" || rcb_asttype.SelectedValue.ToString() == "08") && txtbx_others.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Asset type (Others) details");
                //}

                // This code is written to handle Deposit in Bank A/c (Foreign and India)

             


                //---------------------------------------------------------


                else if (rcb_trntype.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Transaction Type");
                }
              
                else if (rcb_acqsrc.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Acquisition Source");
                }

                //else if (rcb_acqsrc.SelectedValue.ToString() == "OT" && rtb_othres .Text .ToString () == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Acquisition Source (Others) details");
                //}
                
                else if (rdp_acqdt.SelectedDate.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Acquisition Date");
                }
                else if (rtb_amt.Text.Trim().ToString() == "") // Mandatory Field
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Purchase Value/Outstanding Value");
                }

                //---------------------Code disabled by Saurabh 25.03.2022 // No need to make it a mandatory field.
                //else if (rcb_astcat.SelectedValue.ToString() == "04" && rcb_asttype.SelectedValue.ToString() == "01" && rtb_qty.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Quantity for Gold");
                //}
                //else if (rcb_astcat.SelectedValue.ToString() == "04" && rcb_asttype.SelectedValue.ToString() == "02" && rtb_qty.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Quantity for Silver");
                //}
                    //------------------------------------------------------------------------------------------------------------


                else if (rcb_astcat.SelectedValue.ToString() == "04" && rcb_asttype.SelectedValue.ToString() == "03" && rtb_amt.Text.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Amount for Precious Items/Metals");
                }
                else if (rcb_astcat.SelectedValue.ToString() == "04" && rcb_asttype.SelectedValue.ToString() == "04" && rtb_amt.Text.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Purchase Value for Composite Items");
                }
                else if (rcb_astcat.SelectedValue.ToString() != "04" && rtb_amt.Text.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Purchase Value");
                }
                //else if (rcb_unit.SelectedValue.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Select Unit");
                //}
                    //to be checked
                //else if (rcb_astcat.SelectedValue.ToString() == "03" && rcb_asttype.SelectedValue.ToString() == "01" && txt_cumu.Text.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Cumulative Value");
                //}
                else if (obj_gl.FnValidateFloat(txt_cumu.Text.Trim().ToString()) == 0 && txt_cumu.Text.Trim().ToString() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage(" Cumulative Value should be in digits/decimal");
                }
                else if (obj_gl.FnValidateFloat(rtb_amt.Text.Trim().ToString()) == 0 && rtb_amt.Text.Trim().ToString() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage(" Purchase Value/Premium Paid should be in decimal");
                }
                else if (obj_gl.FnValidateFloat(rtb_ann_in.Text.ToString().Trim()) == 0 && rtb_ann_in.Text.Trim() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Property Annual Income should be in decimal");
                }
                else if (obj_gl.FnValidateFloat(rtb_qty.Text.ToString().Trim()) == 0 && rtb_qty.Text.Trim() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Quantity should be in decimal");
                }
                else if (rtb_qty.Text.Trim() != "" && rcb_unit.SelectedValue.ToString().Trim().Replace("&nb", "") == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Unit for Quantity");
                }
                //else if (rdp_acqdt.SelectedDate.ToString() == "")
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Enter Acquisition Date");
                //}
                else if (rdp_acqdt.SelectedDate.ToString() != "" && rdp_acqdt.SelectedDate > today)
                {
                    error_tag = "E";
                    FnDisplayMessage("Acquisition Date can not be greater then today");
                }
                //else if (rdp_acqdt.SelectedDate < Convert.ToDateTime(Session["period_from"].ToString()))
                //{
                //    error_tag = "E";
                //    FnDisplayMessage("Acquisition Date can not me less then : " + Convert.ToDateTime(Session["period_from"]).ToString("dd/MM/yyyy"));
                //}
                else if (rdp_acqdt.SelectedDate > Convert.ToDateTime(Session["period_to"].ToString()))
                {
                    error_tag = "E";
                    FnDisplayMessage("Acquisition Date can not be greater then : " + Convert.ToDateTime(Session["period_to"]).ToString("dd/MM/yyyy"));
                }
                else
                {
                    error_tag = "";
                    acqdt = Convert.ToDateTime(rdp_acqdt.SelectedDate);
                    if (lbl_action_t.Text == "SAVED_HOLDING")
                    {
                        //SqlConnection con = null;
                        //con = new SqlConnection(ConnectionString);
                        using (SqlConnection con = new SqlConnection(ConnectionString))
                        {
                            try
                            {
                                SqlCommand cmd_inttrn = null;

                                if (con.State != ConnectionState.Open)
                                {
                                    con.Close();
                                    con.Open();
                                }

                                cmd_inttrn = new SqlCommand("SP_UPDATE_TRANSACTION_EMPLOYEE", con);
                                cmd_inttrn.CommandType = CommandType.StoredProcedure;
                                cmd_inttrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = lbl_refno.Text;
                                cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "MO";
                                cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();


                                //cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";


                                //-------------------Below code is integrated to handle Indian Currency Value in the fields by Saurabh Sangat on 19.03.3022
                                //----------------------Code Starts--------------------------------------
                                Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                                string update_rtb_amt = rtb_amt.Text;
                                update_rtb_amt = charsToDestroy.Replace(update_rtb_amt, "");
                                if (rtb_amt.Text.Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = DBNull.Value; ;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_amt);
                                }

                                cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;


                                string update_rtb_ann_in = rtb_ann_in.Text;
                                update_rtb_ann_in = charsToDestroy.Replace(update_rtb_ann_in, "");
                                if (rtb_ann_in.Text.Trim().ToString() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_ann_in);
                                }

                                string update_txt_cumu = txt_cumu.Text;
                                update_txt_cumu = charsToDestroy.Replace(update_txt_cumu, "");
                                if (txt_cumu.Text.Trim().ToString() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = Convert.ToDecimal(update_txt_cumu);
                                }
                                //---------------------------Code ends----------------------------------------
                                 
                                cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                                if (rtb_qty.Text.Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_qty.Text);
                                }
                                if (rcb_unit.SelectedValue.ToString().Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "00";
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = rcb_unit.SelectedValue.ToString();
                                }
                                cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                                if (rdp_acqdt.SelectedDate.ToString().Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                }
                                cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                                cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                                //-----Below code is integrated to handle new others field -------------------
                                //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                                cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = txt_desc_oth.Text.Trim();
                                cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = txtbx_others.Text.Trim(); // Insert asttype others details
                                cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = rtb_othres.Text.Trim(); // insert other sources information

                                //-----------------Code Ends----------------------------


                                cmd_inttrn.ExecuteNonQuery();

                                Response.Redirect(Request.RawUrl);
                                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                                //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                                //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                //myremotepost.Post();
                                //con.Close();
                            }
                            catch (Exception ex)
                            {
                                //Handle exception, perhaps log it and do the needful
                                fndisplay(ex.Message);
                            }
                        }
                    }
                    else if (lbl_action_t.Text == "SUBMITTED_TRANSACTION" || lbl_action_t.Text == "ADD_NEW_HOLDING")
                    {
                        rb_addnew.Visible = false;
                        if (error_tag == "")
                        {
                            //SqlConnection con = null;
                            //con = new SqlConnection(ConnectionString);
                            using (SqlConnection con = new SqlConnection(ConnectionString))
                            {
                                try
                                {
                                    SqlCommand cmd_inttrn = null;

                                    if (con.State != ConnectionState.Open)
                                    {
                                        con.Close();
                                        con.Open();
                                    }

                                    cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE", con);

                                    cmd_inttrn.CommandType = CommandType.StoredProcedure;

                                    cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                    cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                    cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "MO";
                                    cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();

                                   // cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";


                                    //-------------------Below code is integrated to handle Indian Currency Value in the fields by Saurabh Sangat on 19.03.3022
                                    //----------------------Code Starts--------------------------------------
                                    Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                                    string update_rtb_amt = rtb_amt.Text;
                                    update_rtb_amt = charsToDestroy.Replace(update_rtb_amt, "");
                                    if (rtb_amt.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = DBNull.Value; ;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_amt);
                                    }

                                    cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;


                                    string update_rtb_ann_in = rtb_ann_in.Text;
                                    update_rtb_ann_in = charsToDestroy.Replace(update_rtb_ann_in, "");
                                    if (rtb_ann_in.Text.Trim().ToString() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_ann_in);
                                    }

                                    string update_txt_cumu = txt_cumu.Text;
                                    update_txt_cumu = charsToDestroy.Replace(update_txt_cumu, "");
                                    if (txt_cumu.Text.Trim().ToString() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = Convert.ToDecimal(update_txt_cumu);
                                    }
                                    //---------------------------Code ends----------------------------------------

                                    cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                    cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                    cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                                    if (rtb_qty.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_qty.Text);
                                    }
                                    if (rcb_unit.SelectedValue.ToString().Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "00";
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = rcb_unit.SelectedValue.ToString();
                                    }
                                    cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                                    if (rdp_acqdt.SelectedDate.ToString().Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                    }
                                    cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                                    cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                    cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                    cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                    cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";
                                    //-----Below code is integrated to handle new others field -------------------
                                    //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                                    cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = txt_desc_oth.Text.Trim();
                                    cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = txtbx_others.Text.Trim(); // Insert asttype others details
                                    cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = rtb_othres.Text.Trim(); // insert other sources information

                                    //-----------------Code Ends----------------------------


                                    cmd_inttrn.ExecuteNonQuery();
                                    Response.Redirect(Request.RawUrl);
                                    //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                                    //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                                    //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                    //myremotepost.Post();
                                    //con.Close();
                                }
                                catch (Exception ex)
                                {
                                    //Handle exception, perhaps log it and do the needful
                                    fndisplay(ex.Message);
                                }
                            }

                        }
                        else if (lbl_action_t.Text == "PRE_SUBMITTED_HOLDING")
                        {
                            rb_addnew.Visible = false;
                            if (error_tag == "")
                            {
                                //SqlConnection con = null;
                                //con = new SqlConnection(ConnectionString);
                                using (SqlConnection con = new SqlConnection(ConnectionString))
                                {
                                    try
                                    {
                                        SqlCommand cmd_inttrn = null;

                                        if (con.State != ConnectionState.Open)
                                        {
                                            con.Close();
                                            con.Open();
                                        }

                                        cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE", con);

                                        cmd_inttrn.CommandType = CommandType.StoredProcedure;
                                        cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                        cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "MO";
                                        cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                        cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();

                                       // cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                        cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";


                                        //-------------------Below code is integrated to handle Indian Currency Value in the fields by Saurabh Sangat on 19.03.3022
                                        //----------------------Code Starts--------------------------------------
                                        Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                                        string update_rtb_amt = rtb_amt.Text;
                                        update_rtb_amt = charsToDestroy.Replace(update_rtb_amt, "");
                                        if (rtb_amt.Text.Trim() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = DBNull.Value; ;
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_amt);
                                        }

                                        cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;


                                        string update_rtb_ann_in = rtb_ann_in.Text;
                                        update_rtb_ann_in = charsToDestroy.Replace(update_rtb_ann_in, "");
                                        if (rtb_ann_in.Text.Trim().ToString() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal(update_rtb_ann_in);
                                        }

                                        string update_txt_cumu = txt_cumu.Text;
                                        update_txt_cumu = charsToDestroy.Replace(update_txt_cumu, "");
                                        if (txt_cumu.Text.Trim().ToString() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = Convert.ToDecimal(update_txt_cumu);
                                        }
                                        //---------------------------Code ends----------------------------------------

                                        cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                        cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                        cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                        cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                                        if (rtb_qty.Text.Trim() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_qty.Text);
                                        }
                                        if (rcb_unit.SelectedValue.ToString().Trim() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "00";
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = rcb_unit.SelectedValue.ToString();
                                        }
                                        cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                                        cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                                        if (rdp_acqdt.SelectedDate.ToString().Trim() == "")
                                        {
                                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                        }
                                        cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                        cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                        cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                        cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                                        //-----Below code is integrated to handle new others field -------------------
                                        //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                                        cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = txt_desc_oth.Text.Trim();
                                        cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = txtbx_others.Text.Trim(); // Insert asttype others details
                                        cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = rtb_othres.Text.Trim(); // insert other sources information

                                        //-----------------Code Ends----------------------------

                                        cmd_inttrn.ExecuteNonQuery();
                                        Response.Redirect(Request.RawUrl);
                                        //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                                        //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                                        //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                        //myremotepost.Post();
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
                    }
                }

            }
            catch (Exception ex)
            {
                FnDisplayMessage(ex.Message);
            }
        }

        //+++ Fn to display message
        private void FnDisplayMessage(string text)
        {
            epanel.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        protected void rcb_astcat_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            lbl_cummu.Visible = false;
            lbl_cummu_req.Visible = false;
            txt_cumu.Visible = false;
            lbl_cumu_val.Visible = false;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_getdep = null;
                    SqlCommand cmd_getind = null;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    cmd_getdep = new SqlCommand("SP_GET_DEP_PARAMS", con);
                    cmd_getind = new SqlCommand("SP_GET_IND_PARAMS", con);
                    SqlDataAdapter ad_dep = new SqlDataAdapter();
                    SqlDataAdapter ad_ind = new SqlDataAdapter();
                    cmd_getdep.CommandType = CommandType.StoredProcedure;
                    cmd_getind.CommandType = CommandType.StoredProcedure;
                    ad_dep.SelectCommand = cmd_getdep;
                    ad_ind.SelectCommand = cmd_getind;
                    ad_dep.Fill(dt_dep);
                    ad_ind.Fill(dt_ind);
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }


            var rows_asttype = from row in dt_dep.AsEnumerable()
                               where row.Field<string>("PRPTYPE").Trim() == "MO"
                               && row.Field<string>("ASCAT").Trim() == rcb_astcat.SelectedValue.ToString()
                               select row;
            DataView view_asttype = rows_asttype.AsDataView();
            DataTable distinctValues_asttype = view_asttype.ToTable(true, "ASTYPE", "ASTYPEDESC");
            rcb_asttype.DataSource = distinctValues_asttype;
            rcb_asttype.DataTextField = "ASTYPEDESC";
            rcb_asttype.DataValueField = "ASTYPE";
            rcb_asttype.DataBind();
            rcb_asttype.SelectedValue = view_asttype[0][4].ToString();

            var rows_trntype = from row in dt_dep.AsEnumerable()
                               where row.Field<string>("PRPTYPE").Trim() == "MO"
                               && row.Field<string>("ASCAT").Trim() == rcb_astcat.SelectedValue.ToString()
                               && row.Field<string>("ASTYPE").Trim() == view_asttype[0][4].ToString()
                               && row.Field<string>("TRNTYP").Trim() == "03"
                               select row;
            DataView view_trntype = rows_trntype.AsDataView();
            DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

            rcb_trntype.DataSource = distinctValues_trntype;
            rcb_trntype.DataTextField = "TRNTYPDESC";
            rcb_trntype.DataValueField = "TRNTYP";
            rcb_trntype.DataBind();
            rcb_trntype.SelectedValue = "03";



          

           
            if (rcb_astcat.SelectedValue.ToString() == "04" && (view_asttype[0][4].ToString() == "01" || view_asttype[0][4].ToString() == "02"))
            {
                rtb_qty.Visible = true;
                rcb_unit.Visible = true;
                Label18.Visible = true;
                Lblqty.Visible = true;
            }
            else
            {
                rcb_unit.SelectedValue = "00";
                rtb_qty.Visible = false;
                rcb_unit.Visible = false;
                Label18.Visible = false;
                Lblqty.Visible = false;
            }
            //
            if (rcb_astcat.SelectedValue.ToString() == "03" && (view_asttype[0][4].ToString() == "01" || view_asttype[0][4].ToString() == "02"))
            {
                rtb_ann_in.Visible = true;
                //rcb_unit.Visible = true;
                Label19.Text = "Yearly Premium Paid";
                Label20.Visible = true;
                //Lblqty.Visible = true;
            }
            else
            {
                // rcb_unit.SelectedValue = "00";
                // rtb_qty.Visible = false;
                // rcb_unit.Visible = false;
                Label19.Text = "Purchase Value/Outstanding Balance";
                Label20.Visible = false;
                rtb_ann_in.Visible = false;
            }
            if (rcb_astcat.SelectedValue.ToString() == "01")
            {
                rcb_asttype.Enabled = false;
            }
            else
            {
                rcb_asttype.Enabled = true;

            }
            if (rcb_astcat.SelectedValue.ToString() == "08")
            {
               //lbl_desc_oth.Visible   = true;
               //txt_desc_oth.Visible= true;
            }
            else
            {
                lbl_others.Visible = false;
                txtbx_others.Visible = false;
               // lbl_desc_oth.Visible = false;
                //txt_desc_oth.Visible = false;

            }
           
            if (rcb_asttype.Items.Count < 2) // Integrated by Saurabh Sangat 22.02.2022
            {
                rcb_asttype.Enabled = false;
            }
            else
            {
                rcb_asttype.Enabled = true;

            }

        }

        protected void rcb_asttype_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_getdep = null;
                    SqlCommand cmd_getind = null;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    cmd_getdep = new SqlCommand("SP_GET_DEP_PARAMS", con);
                    cmd_getind = new SqlCommand("SP_GET_IND_PARAMS", con);
                    SqlDataAdapter ad_dep = new SqlDataAdapter();
                    SqlDataAdapter ad_ind = new SqlDataAdapter();
                    cmd_getdep.CommandType = CommandType.StoredProcedure;
                    cmd_getind.CommandType = CommandType.StoredProcedure;
                    ad_dep.SelectCommand = cmd_getdep;
                    ad_ind.SelectCommand = cmd_getind;
                    ad_dep.Fill(dt_dep);
                    ad_ind.Fill(dt_ind);
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            var rows_trntype = from row in dt_dep.AsEnumerable()
                               where row.Field<string>("PRPTYPE").Trim() == "MO"
                               && row.Field<string>("ASCAT").Trim() == rcb_astcat.SelectedValue.ToString()
                               && row.Field<string>("ASTYPE").Trim() == rcb_asttype.SelectedValue.ToString()
                               && row.Field<string>("TRNTYP").Trim() == "03"
                               select row;
            DataView view_trntype = rows_trntype.AsDataView();
            DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

            rcb_trntype.DataSource = distinctValues_trntype;
            rcb_trntype.DataTextField = "TRNTYPDESC";
            rcb_trntype.DataValueField = "TRNTYP";
            rcb_trntype.DataBind();
            rcb_trntype.SelectedValue = "03";


            if (rcb_astcat.SelectedValue.ToString() == "02" && (rcb_asttype.SelectedValue.ToString() == "01" || rcb_asttype.SelectedValue.ToString() == "02"))
            {
                //error_tag = "E";
                FnDisplayMessage("DEPOSITS IN BANK A/C-INDIA / DEPOSITS IN BANK A/C-FOREIGN cannot be saved under DEPOSITS head.It is available under balance head.");
            }

            if (rcb_astcat.SelectedValue.ToString() == "04" && (rcb_asttype.SelectedValue.ToString() == "01" || rcb_asttype.SelectedValue.ToString() == "02"))
            {
                rtb_qty.Visible = true;
                rcb_unit.Visible = true;
                Label18.Visible = true;
                Lblqty.Visible = true;
                //Lblqty_star.Visible = true;
            }
            else
            {
                rcb_unit.SelectedValue = "00";
                rtb_qty.Visible = false;
                rcb_unit.Visible = false;
                Label18.Visible = false;
                Lblqty.Visible = false;
                //Lblqty_star.Visible  = false;
            }
            if (rcb_astcat.SelectedValue.ToString() == "03" && (rcb_asttype.SelectedValue.ToString() == "01" || rcb_asttype.SelectedValue.ToString() == "02"))
            {
                rtb_ann_in.Visible = true;
                //rcb_unit.Visible = true;
                Label19.Text = "Yearly Premium Paid";
                Label20.Visible = true;
                //Lblqty.Visible = true;
            }
            else
            {
                // rcb_unit.SelectedValue = "00";
                // rtb_qty.Visible = false;
                // rcb_unit.Visible = false;
                Label19.Text = "Purchase Value/Outstanding Value ";
                Label20.Visible = false;
                rtb_ann_in.Visible = false;
            }
            if ((rcb_astcat.SelectedValue.ToString() == "08" && rcb_asttype.SelectedValue.ToString() == "01") || (rcb_astcat.SelectedValue.ToString() == "03" && rcb_asttype.SelectedValue.ToString() == "09") || (rcb_astcat.SelectedValue.ToString() == "02" && rcb_asttype.SelectedValue.ToString() == "08"))
            {
                lbl_others.Visible = true;
                txtbx_others.Visible = true;

            }
            else
            {
                lbl_others.Visible = false;
                txtbx_others.Visible = false;
            }


            if (rcb_astcat.SelectedValue.ToString() == "03" && rcb_asttype.SelectedValue.ToString() == "01")
            {
                lbl_cummu.Visible = true;
                lbl_cummu_req.Visible = true;
                txt_cumu.Visible = true;
                lbl_cumu_val.Visible = true;

            }
            else
            {
                lbl_cummu.Visible = false;
                lbl_cummu_req.Visible = false;
                txt_cumu.Visible = false;
                lbl_cumu_val.Visible = false;
            }

        
            if (rcb_asttype.Items.Count < 2) // Integrated by Saurabh Sangat 22.02.2022
            {
                rcb_asttype.Enabled = false;
            }
            else
            {
                rcb_asttype.Enabled = true;

            }


        }

        protected void btnToggle1_Click(object sender, EventArgs e)
        {
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
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    RG_TRN.DataSource = dt;
                    RG_TRN.DataBind();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void btnToggle2_Click(object sender, EventArgs e)
        {
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_TR_SU_HO";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    RG_TRN.DataSource = dt;
                    RG_TRN.DataBind();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void btnToggle3_Click(object sender, EventArgs e)
        {
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG_P";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    RG_TRN.DataSource = dt;
                    RG_TRN.DataBind();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void btnToggle4_Click(object sender, EventArgs e)
        {
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    RG_TRN.DataSource = dt;
                    RG_TRN.DataBind();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void rb_submit_Click(object sender, EventArgs e)
        {

        }


        //+++ Fn to display message
        protected void rb_reject_Click(object sender, EventArgs e)
        {
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_uptrn = null;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                    cmd_uptrn.CommandType = CommandType.StoredProcedure;
                    cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = lbl_refno.Text;
                    cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "RJ";
                    cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                    cmd_uptrn.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.RawUrl);
                    //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                    //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                    //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                    //myremotepost.Post();
                    //con.Close();
                }

                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void rcb_acqsrc_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcb_acqsrc.SelectedValue != "OT")
            {
                Lbl_oth.Visible = false;
                rtb_othres.Visible = false;
            }
            else
            {
                Lbl_oth.Visible = true;
                rtb_othres.Visible = true;
            }
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

        protected void carryforward()
        {
            int p = 0;
            foreach (GridDataItem dataItem in RG_TRN.Items)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd_inttrn = null;

                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }


                        cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE", con);

                        cmd_inttrn.CommandType = CommandType.StoredProcedure;

                        cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = dataItem["EMPNO"].Text.ToString();
                        cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                        cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "MO";
                        cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = dataItem["ASCAT"].Text.ToString();
                        cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = dataItem["ASTYPE"].Text.ToString();
                        cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";

                        if (dataItem["Trn_Amount"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = DBNull.Value; ;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(dataItem["Trn_Amount"].Text.ToString());
                        }
                        if (dataItem["CURVAL"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = Convert.ToDecimal(dataItem["CURVAL"].Text.ToString().Replace("&nbsp;", ""));
                        }
                        if (dataItem["ANINCM"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal(dataItem["ANINCM"].Text.ToString().Replace("&nbsp;", ""));
                        }
                        if (dataItem["CONSVAL"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = Convert.ToDecimal(dataItem["CONSVAL"].Text.ToString());
                        }
                        cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = dataItem["OBJECTID"].Text.ToString().Replace("&nbsp;", "");
                        cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = dataItem["IDDESC"].Text.ToString().Replace("&nbsp;", "");
                        cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                        if (dataItem["QTY"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal(dataItem["QTY"].Text.ToString());
                        }
                        if (dataItem["UNIT"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "00";
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = dataItem["UNIT"].Text.ToString();
                        }
                        cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = dataItem["ACQSRC"].Text.ToString().Replace("&nbsp;", "");
                        cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = dataItem["Acq_Remarks"].Text.ToString().Replace("&nbsp;", "");
                        if (dataItem["ACQDT"].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                        {
                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = dataItem["ACQDT"].Text.ToString();
                        }
                        cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = dataItem["REMARKS"].Text.ToString();
                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                        cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                        cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                        //-----Below code is integrated to handle new others field -------------------
                        //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                        cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = dataItem["ASCAT_OTHDESC"].Text.ToString().Replace("&nbsp;", "");
                        cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = dataItem["ASTYPE_OTHDESC"].Text.ToString().Replace("&nbsp;", ""); // Insert asttype others details
                        cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = dataItem["ACQ_SOURCE_OTHDESC"].Text.ToString().Replace("&nbsp;", ""); // insert other sources information

                        //-----------------Code Ends----------------------------


                        p = cmd_inttrn.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }
            //if (p == 0)
            //{
        //    bind_grid();
            //}
            //HLD_IMMOVABLE myremotepost = new HLD_IMMOVABLE();
            //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
            //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
            //myremotepost.Post();
            //con.Close();
        }
        protected void populatesapdata()
        {
            int sap = 0;
           
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand cmd_inssap = null;

                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }


                        cmd_inssap = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE_SAP", con);

                        cmd_inssap.CommandType = CommandType.StoredProcedure;


                        cmd_inssap.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //    cmd_inssap.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = l_type;
                        cmd_inssap.Parameters.Add("@TRNDT", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("yyyy-MM-dd");
                        
                      //  cmd_inssap.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["empno"];
                      //  cmd_inssap.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Session["getDate"];

                        //-----------------Code Ends----------------------------


                        sap = cmd_inssap.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
          
        }
        protected string check_records()
        {
            dt_rj.Clear();
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection conrj = new SqlConnection(ConnectionString))
            {
                try
                {

                    SqlCommand cmd_getrj = null;

                    if (conrj.State != ConnectionState.Open)
                    {
                        conrj.Close();
                        conrj.Open();
                    }

                    cmd_getrj = new SqlCommand("SP_GET_REJECTED_TRANSACTION", conrj);
                    SqlDataAdapter adrj = new SqlDataAdapter();

                    cmd_getrj.CommandType = CommandType.StoredProcedure;
                    cmd_getrj.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_getrj.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");
                    adrj.SelectCommand = cmd_getrj;
                    adrj.Fill(dt_rj);
                    if (dt_rj.Rows.Count > 0)
                    {
                        return "N";

                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.ToString());
                }
            }
            return "Y";
        }
        protected string chk_holding()
        {
            string holdingdtnext = "";
            String Status_HV = "";
            String Status_HG = "";
            String Status_SV = "";
            string l_status = "";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    SqlCommand cmd_getst = null;
                    //cmd_getst = new SqlCommand("select status from T_PROPRETURNS where trndt='" + Session["getDate"].ToString() + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                    cmd_getst = new SqlCommand("select status from T_PROPRETURNS where status <> 'RJ' and trndt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                    DataTable dt_for = new DataTable();
                    SqlDataAdapter ad_for = new SqlDataAdapter();
                    ad_for.SelectCommand = cmd_getst;
                    ad_for.Fill(dt_for);

                    if (dt_for.Rows.Count > 0)
                    {
                        Status_HV = "";
                        Status_HG = "";
                        Status_SV = "";

                        DataView view = new DataView(dt_for);
                        DataTable distinctValues = view.ToTable(true, "status");

                        foreach (DataRow row in distinctValues.Rows)
                        {
                            if (row["status"].ToString() == "HV")
                            {
                                Status_HV = "Y";
                                l_status = "HV";
                            }
                            if (row["status"].ToString() == "HG")
                            {
                                Status_HG = "Y";
                                l_status = "HG";
                            }
                            if (row["status"].ToString() == "SV")
                            {
                                Status_SV = "Y";
                                l_status = "SV";
                            }
                            //if (row["status"].ToString() == "RJ")
                            //{
                            //    Status_HV = "Y";
                            //}
                        }

                        if (Status_HG == "Y")
                        {
                            pnlMO.Enabled = false;
                            //RadioButton10.Enabled = false;
                            //RadioButton11.Enabled = false;
                            //RadioButton1.Enabled = false;
                            ////RadioButton2.Enabled = false;
                            //RadioButton3.Enabled = false;
                            //RadioButton4.Enabled = true;
                            ////Commented By Manjeet
                            ////RadioButton5.Enabled = true;
                            ////RadioButton6.Enabled = true;
                            //// End Comment
                            //RadioButton7.Enabled = true;
                            //RadioButton8.Enabled = true;
                            //RadioButton9.Enabled = true;

                            //cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been submitted.";
                        }
                        else if (Status_HV == "Y")
                        {
                            pnlMO.Enabled = true;
                            //RadioButton10.Enabled = true;
                            //RadioButton11.Enabled = true;
                            //RadioButton1.Enabled = true;
                            ////RadioButton2.Enabled = true;
                            //RadioButton3.Enabled = true;
                            //RadioButton4.Enabled = true;

                            //RadioButton5.Enabled = false;
                            //RadioButton6.Enabled = false;
                            //RadioButton7.Enabled = false;
                            //RadioButton8.Enabled = false;
                            //RadioButton9.Enabled = false;

                            //cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been draft saved only.";
                        }
                        else if (Status_SV == "Y")
                        {
                            pnlMO.Enabled = true;
                            //RadioButton10.Enabled = false;
                            //RadioButton11.Enabled = false;
                            //RadioButton1.Enabled = false;
                            ////RadioButton2.Enabled = false;
                            //RadioButton3.Enabled = false;
                            //RadioButton4.Enabled = true;

                            //RadioButton5.Enabled = true;
                            //RadioButton6.Enabled = true;
                            //RadioButton7.Enabled = true;
                            //RadioButton8.Enabled = true;
                            //RadioButton9.Enabled = true;

                            //cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been submitted. Some transactions also entered";
                        }
                    }
                    else
                    {
                        pnlMO.Enabled = true;
                        //RadioButton10.Enabled = true;
                        //RadioButton11.Enabled = true;
                        //RadioButton1.Enabled = true;
                        ////RadioButton2.Enabled = true;
                        //RadioButton3.Enabled = true;
                        //RadioButton4.Enabled = true;

                        //RadioButton5.Enabled = false;
                        //RadioButton6.Enabled = false;
                        //RadioButton7.Enabled = false;
                        //RadioButton8.Enabled = false;
                        //RadioButton9.Enabled = false;
                        //cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " are not entered yet.";
                    }


                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
                return l_status;
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

                    SqlCommand cmd_getst = null;
                    cmd_getst = new SqlCommand("SELECT Top 1 holdingdt FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt > '" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' order by holdingdt", con);
                    DataTable dt_for1 = new DataTable();
                    SqlDataAdapter ad_for = new SqlDataAdapter();
                    ad_for.SelectCommand = cmd_getst;
                    ad_for.Fill(dt_for1);

                    if (dt_for1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt_for1.Rows)
                        {
                            holdingdtnext = row["holdingdt"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            if (holdingdtnext != null && holdingdtnext != "")
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

                        SqlCommand cmd_getst = null;
                        //lblhld.Text = holdingdtnext;
                        cmd_getst = new SqlCommand("select status from T_PROPRETURNS where status <> 'RJ' and trndt='" + Convert.ToDateTime(holdingdtnext).ToString("MM-dd-yyyy") + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                        DataTable dt_for2 = new DataTable();
                        SqlDataAdapter ad_for = new SqlDataAdapter();
                        ad_for.SelectCommand = cmd_getst;
                        ad_for.Fill(dt_for2);

                        if (dt_for2.Rows.Count > 0)
                        {

                            //RadioButton5.Enabled = false;
                            //RadioButton6.Enabled = false;
                            //RadioButton7.Enabled = false;
                            //RadioButton8.Enabled = false;
                            //RadioButton9.Enabled = true;
                            //  cstatus.Text = "Holdings for next holding date : " + Convert.ToDateTime(holdingdtnext).ToString("dd/MM/yyyy") + " had been entered, so no transactions can be entered.";
                        }
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }

        }

        protected void rtb_amt_TextChanged(object sender, System.EventArgs e)
        {
            string moneyString = "";
            try
            {
                //Converting value to words
                string value = rtb_amt.Text;
                //alert(value);

                Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                moneyString = charsToDestroy.Replace(value, "");

                decimal d1 = decimal.Parse(moneyString);
                int val1 = Decimal.ToInt32(d1);
                lbl_pur_value.Text = Words_To_Rupees(val1);
            }
            catch (FormatException)
            {
                lbl_pur_value.Text = "Enter digits only";
            }

            //Converting value to Indian currency System
            rtb_amt.Text = Convert_To_Indian_Currency_System(moneyString);

            //--------------------- -- Code Ends -- -------------------------------------------------------------------------
        }
        protected void txt_cumu_TextChanged(object sender, System.EventArgs e)
        {
            string moneyString = "";
            try
            {
                //Converting value to words
                string value = txt_cumu.Text;
                //alert(value);

                Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                moneyString = charsToDestroy.Replace(value, "");

                decimal d1 = decimal.Parse(moneyString);
                int val1 = Decimal.ToInt32(d1);
                lbl_cumu_val.Text = Words_To_Rupees(val1);
            }
            catch (FormatException)
            {
                lbl_cumu_val.Text = "Enter digits only";
            }

            //Converting value to Indian currency System
            txt_cumu.Text = Convert_To_Indian_Currency_System(moneyString);

            //--------------------- -- Code Ends -- -------------------------------------------------------------------------
        }
        protected void rtb_ann_in_TextChanged(object sender, System.EventArgs e)
        {
            string moneyString = "";
            try
            {
                //Converting value to words
                string value = rtb_ann_in.Text;
                //alert(value);

                Regex charsToDestroy = new Regex(@"[^\d|\.\-]");

                 moneyString = charsToDestroy.Replace(value, "");

                decimal d1 = decimal.Parse(moneyString);
                int val1 = Decimal.ToInt32(d1);
                lbl_sum_value.Text = Words_To_Rupees(val1);
            }
            catch (FormatException)
            {
                lbl_sum_value.Text = "invalid";
            }

            //Converting value to Indian currency System
            rtb_ann_in.Text = Convert_To_Indian_Currency_System(moneyString);

            //--------------------- -- Code Ends -- -------------------------------------------------------------------------
        }


        //------------------------Below code will be used to bind dropdown list 
        //protected void BindAssetCategory()
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
        //            rcb_astcat.Items.Clear();
        //            rcb_astcat.Items.Add("Select Asset Category");

        //            string com = "Select distinct(ASCAT), (ASCATDESC)  from [PROP_RETURNS].[dbo].[M_DEPPARAMS] WHERE PRPTYPE='IM' order by ASCATDESC";
        //            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        //            DataTable dt = new DataTable();
        //            adpt.Fill(dt);
        //            rcb_astcat.DataSource = dt;
        //            rcb_astcat.DataBind();
        //            rcb_astcat.DataTextField = "ASCATDESC";
        //            rcb_astcat.DataValueField = "ASCAT";
        //            rcb_astcat.DataBind();

        //        }
        //        catch (Exception ex)
        //        {
        //            Handle exception, perhaps log it and do the needful
        //            fndisplay(ex.Message);
        //        }
        //    }

     //    BindAssetType();

        //}

        //protected void BindAssetType()
        //{
        //    rcb_asttype.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;


        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select distinct(ASTYPE), (ASTYPEDESC)  from [PROP_RETURNS].[dbo].[M_DEPPARAMS] WHERE PRPTYPE='IM' and ASCAT = '" + rcb_astcat.SelectedValue + "' order by ASTYPEDESC";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_asttype.DataSource = dt;
        //    rcb_asttype.DataBind();
        //    rcb_asttype.DataTextField = "ASTYPEDESC";
        //    rcb_asttype.DataValueField = "ASTYPE";
        //    rcb_asttype.DataBind();

        //    rcb_asttype.SelectedIndex = 0;
        //    if (rcb_asttype.Items.Count < 2) // Integrated by Saurabh Sangat 22.02.2022
        //    {

        //        rcb_asttype.Enabled = false;
        //    }
        //    else
        //    {
        //        rcb_asttype.Enabled = true;

        //    }

        //    Authorize();

        //    ASTYPE, ASTYPEDESC,

        //}

        //protected void BindAcqusitionSource()
        //{
        //    rcb_acqsrc.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;

        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select PARAMCD, (PARAMDESC)  from [PROP_RETURNS].[dbo].[M_INDPARAMS] WHERE PARAMTYPE='ACQSRC' order by PARAMDESC";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_acqsrc.DataSource = dt;
        //    rcb_acqsrc.DataBind();
        //    rcb_acqsrc.DataTextField = "PARAMDESC";
        //    rcb_acqsrc.DataValueField = "PARAMCD";
        //    rcb_acqsrc.DataBind();

        //    ASTYPE, ASTYPEDESC,

        //}
        //protected void BindTransactionType()
        //{
        //    rcb_asttype.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;


        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select distinct(ASTYPE), (ASTYPEDESC)  from [PROP_RETURNS].[dbo].[M_DEPPARAMS] WHERE PRPTYPE='LI' and ASCAT = '" + rcb_astcat.SelectedValue + "' order by ASTYPEDESC";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_asttype.DataSource = dt;
        //    rcb_asttype.DataBind();
        //    rcb_asttype.DataTextField = "ASTYPEDESC";
        //    rcb_asttype.DataValueField = "ASTYPE";
        //    rcb_asttype.DataBind();

        //    ASTYPE, ASTYPEDESC,

        //}
        //protected void BindCountry()
        //{
        //    rcb_country.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;


        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select PARAMCD, PARAMDESC  from [PROP_RETURNS].[dbo].[M_INDPARAMS] WHERE PARAMTYPE='COUNTRY' order by PARAMDESC";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_country.DataSource = dt;
        //    rcb_country.DataBind();
        //    rcb_country.DataTextField = "PARAMDESC";
        //    rcb_country.DataValueField = "PARAMCD";
        //    rcb_country.DataBind();

        //    rcb_country.SelectedValue = "STATE_IN";

        //    BindState();

        //    ASTYPE, ASTYPEDESC,

        //}
        //protected void BindState()
        //{
        //    rcb_state.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;


        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select PARAMCD, PARAMDESC  from [PROP_RETURNS].[dbo].[M_INDPARAMS] WHERE PARAMTYPE= '" + rcb_country.SelectedValue + "' order by PARAMDESC";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_state.DataSource = dt;
        //    rcb_state.DataBind();
        //    rcb_state.DataTextField = "PARAMDESC";
        //    rcb_state.DataValueField = "PARAMCD";
        //    rcb_state.DataBind();

        //    ASTYPE, ASTYPEDESC,

        //}
        //protected void BindUnit()
        //{
        //    rcb_unit.Items.Clear();
        //     rcb_astcat.Items.Add("Select Asset Category");
        //    string strcon;
        //    strcon = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;


        //    SqlConnection conn = new SqlConnection(strcon);
        //    string com = "Select PARAMCD, PARAMDESC  from [PROP_RETURNS].[dbo].[M_INDPARAMS] WHERE PARAMTYPE_NEW='UNIT_L' order by PARAMDESC ";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    rcb_unit.DataSource = dt;
        //    rcb_unit.DataBind();
        //    rcb_unit.DataTextField = "PARAMDESC";
        //    rcb_unit.DataValueField = "PARAMCD";
        //    rcb_unit.DataBind();

        //    ASTYPE, ASTYPEDESC,

        //}

        //private void Authorize()
        //{
        //    try
        //    {

        //        if (rcb_astcat.SelectedValue == "02")
        //        {
        //            rcb_asttype.Enabled = false;
        //        }
        //        else
        //        {
        //            rcb_asttype.Enabled = true;
        //        }




        //        if (rcb_astcat.SelectedValue == "05")
        //        {
        //            rcb_asttype.SelectedValue = "01";
        //            rcb_asttype.Enabled = false;
        //            lbl_others.Visible = true;
        //            txtbx_others_asttype.Visible = true;
        //            img_others.Visible = true;

        //        }
        //        else
        //        {
        //            rcb_asttype.SelectedValue = "01";
        //            rcb_asttype.Enabled = true;
        //            lbl_others.Visible = false;
        //            txtbx_others_asttype.Visible = false;
        //            img_others.Visible = false;
        //        }



        //    }
        //    catch
        //    {
        //    }
        //}

        //---------------------------Code Ends-----------------------
    }
}