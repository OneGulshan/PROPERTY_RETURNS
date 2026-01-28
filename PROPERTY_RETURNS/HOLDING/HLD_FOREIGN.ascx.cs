using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS.HOLDING
{
    public partial class HLD_FOREIGN : System.Web.UI.UserControl
    {
         string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dtf = new DataTable();
        static DataTable dt_depf = new DataTable();
        static DataTable dt_indf = new DataTable();
        static DataTable dt_empf = new DataTable();
        GLB_FNS obj_gl = new GLB_FNS();
        static char action;
        String parent_holddt = "";
        public DateTime hld_dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            {
                if (!IsPostBack)
                {
                    dt_depf.Clear();
                    dt_indf.Clear();
                    dt_empf.Clear();  
                        parent_holddt = Session["getDate"].ToString();
                        rdp_hlddt.SelectedDate = Convert.ToDateTime(parent_holddt);
                        rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                        lblcatch.Text = "";
                        action = 'A';
                        //   bind_grid();
                        lbl_action.Text = "Add New Transaction";
                        Session["action_t"] = "ADD_NEW_HOLDING";
                        lbl_action_t.Text = "ADD_NEW_HOLDING";
                        rb_addnew.Visible = false;
                        rb_reject.Visible = false;
                        using (SqlConnection con = new SqlConnection(ConnectionString))
                        {
                            try
                            {
                                // SqlConnection con = null;
                                // con = new SqlConnection(ConnectionString);
                                SqlCommand cmd_getdep = null;
                                SqlCommand cmd_getind = null;
                                if (con.State != ConnectionState.Open)
                                {
                                    con.Close();
                                    con.Open();
                                }
                                cmd_getdep = new SqlCommand("SP_GET_DEP_PARAMS", con);
                                cmd_getind = new SqlCommand("SP_GET_IND_PARAMS", con);
                                SqlDataAdapter ad_depf = new SqlDataAdapter();
                                SqlDataAdapter ad_indf = new SqlDataAdapter();
                                cmd_getdep.CommandType = CommandType.StoredProcedure;
                                cmd_getind.CommandType = CommandType.StoredProcedure;
                                ad_depf.SelectCommand = cmd_getdep;
                                ad_indf.SelectCommand = cmd_getind;
                                ad_depf.Fill(dt_depf);
                                ad_indf.Fill(dt_indf);

                                dt_empf.Clear();
                                SqlCommand cmd_getemp = null;
                                cmd_getemp = new SqlCommand("SP_GET_EMP_DETAILS", con);
                                cmd_getemp.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                                SqlDataAdapter ad_empf = new SqlDataAdapter();
                                cmd_getemp.CommandType = CommandType.StoredProcedure;
                                ad_empf.SelectCommand = cmd_getemp;
                                ad_empf.Fill(dt_empf);

                                rcb_EMP.DataSource = dt_empf;
                                rcb_EMP.DataTextField = "EMPNAME";
                                rcb_EMP.DataValueField = "EMPNO";
                                rcb_EMP.DataBind();
                                var rows_acqsrc = from row in dt_indf.AsEnumerable()
                                                  where row.Field<string>("PARAMTYPE").Trim() == "ACQSRC"
                                                  select row;
                                DataView view_acqsrcf = rows_acqsrc.AsDataView();
                                DataTable distinctValues_acqsrcf = view_acqsrcf.ToTable(true, "PARAMCD", "PARAMDESC");
                                rcb_acqsrc.DataSource = distinctValues_acqsrcf;
                                rcb_acqsrc.DataTextField = "PARAMDESC";
                                rcb_acqsrc.DataValueField = "PARAMCD";
                                rcb_acqsrc.DataBind();
                             //   view_acqsrc.Dispose();

                                var rows_country = from row in dt_indf.AsEnumerable()
                                                   where row.Field<string>("PARAMTYPE").Trim() == "COUNTRY"
                                                   select row;
                                DataView view_countryf = rows_country.AsDataView();
                                DataTable distinctValues_countryf = view_countryf.ToTable(true, "PARAMCD", "PARAMDESC");
                                rcb_country.DataSource = distinctValues_countryf;
                                rcb_country.DataTextField = "PARAMDESC";
                                rcb_country.DataValueField = "PARAMCD";
                                rcb_country.DataBind();
                            }
                            catch (Exception ex)
                            {
                                //Handle exception, perhaps log it and do the needful
                                fndisplay(ex.Message);
                            }
                         //   con.Close();
                        }
                        //view_country.Dispose();
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
        }
        protected void RG_TRN_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            //SqlCommand cmd_gettrn = null;

            //con.Open();

            //cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
            //SqlDataAdapter ad = new SqlDataAdapter();

            //cmd_gettrn.CommandType = CommandType.StoredProcedure;
            //cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = "00009766";

            //ad.SelectCommand = cmd_gettrn;
            //DataTable dt = new DataTable();
            //ad.Fill(dt);
            //RG_TRN.DataSource = dt;
            //RG_TRN.DataBind();
            if (e.Item.IsInEditMode)
            {


            }

        }


        protected void bind_grid()
        {
            string l_type = "";
            hld_dt = Convert.ToDateTime(Session["getDate"].ToString());
            dtf.Clear();
            if (chk_holding() == "HV")
                l_type = "FV_TR_SA";
            if (chk_holding() == "HG")
                l_type = "FV_TR_SU";
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE1", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString(); 
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = l_type;
           // cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");
            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.DateTime).Value = hld_dt;
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dtf);
            RG_TRN.DataSource = dtf;
            RG_TRN.DataBind();
        }

        protected void RG_TRN_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RG_TRN.DataSource = dtf;
            //RG_TRN.Rebind();
        }

        protected void RG_TRN_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var dataItem = RG_TRN.SelectedItems[0] as GridDataItem;
            if (dataItem != null)
            {
                //lbl_action.Text = "Update Transaction : " + dataItem["ref_no"].Text;
                
                //var name = dataItem["ProductName"].Text; 
                rb_addnew.Visible = true;
                rb_reject.Visible = true;
                lbl_refno.Text = dataItem["ref_no"].Text;

                rcb_EMP.SelectedValue = dataItem["EMPNO"].Text;
                rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                //var rows_country = from row in dt_ind.AsEnumerable()
                //                   where row.Field<string>("PARAMTYPE").Trim() == "COUNTRY"
                //                   select row;
                //DataView view_country = rows_country.AsDataView();
                //DataTable distinctValues_country = view_country.ToTable(true, "PARAMCD", "PARAMDESC");
                //rcb_country.DataSource = distinctValues_country;
                //rcb_country.DataTextField = "PARAMDESC";
                //rcb_country.DataValueField = "PARAMCD";
                //rcb_country.DataBind();
                rcb_country.SelectedValue= dataItem["FV_COUNTRIES"].Text;
                rcb_country.DataBind();
                //visited_countries.Text = dataItem["FV_COUNTRIES"].Text;
                duration.Text = dataItem["FV_DURATION"].Text;
                rcb_acqsrc.SelectedValue = dataItem["ACQSRC"].Text;
                rtb_othres.Text = dataItem["ACQDESC"].Text.Trim().Replace("&nbsp;", "");
                rtb_remarks.Text = dataItem["REMARKS"].Text.Trim().Replace("&nbsp;", "");
                purpose.Text= dataItem["FV_VISIT_PURPOSE"].Text.Trim().Replace("&nbsp;", "");
                rtb_expinc.Text= dataItem["FV_EXP_INCUR"].Text.Trim().Replace("&nbsp;", "");
                // RadDatePicker1.SelectedDate =Convert.ToDateTime(( Convert.ToDateTime(dataItem["FV_START_DATE"].Text).ToString("MM/dd/yyyy")));                                   
                // 
                //  String dt=dataItem["FV_START_DATE"].Text.Substring(3, 2) + "/" + dataItem["FV_START_DATE"].Text.Substring(0, 2) + "/" + dataItem["FV_START_DATE"].Text.Substring(6, 4);
                //  RadDatePicker1.SelectedDate = Convert.ToDateTime(dt);
                RadDatePicker1.SelectedDate = DateTime.ParseExact(dataItem["FV_START_DATE"].Text, "dd/MM/yyyy", null);
                RadDatePicker2.SelectedDate = DateTime.ParseExact(dataItem["FV_END_DATE"].Text, "dd/MM/yyyy", null);
                string status = dataItem["STATUS"].Text.Trim().Replace("&nbsp;", "");
                if (status == "HG")
                {
                    lbl_action.Text = "Transaction is submitted : " + dataItem["ref_no"].Text;
                    rcb_EMP.Enabled = false;
                    Session["action_t"] = "SUBMITTED_TRANSACTION";
                    lbl_action_t.Text = "SUBMITTED_TRANSACTION";
                  //  visited_countries.Enabled = false;
                    rcb_country.Enabled = false;
                    RadDatePicker1.Enabled = false;
                    duration.Enabled = false;
                    rcb_acqsrc.Enabled = false;
                    rtb_othres.Enabled = false;
                    rtb_remarks.Enabled = false;
                    rb_save.Visible = false;
                    purpose.Enabled = false;
                    rtb_expinc.Enabled = false;
                }
                else if (status == "HV")
                {
                    lbl_action.Text = "Update Transaction : " + dataItem["ref_no"].Text;
                    action = 'U';
                    rcb_EMP.Enabled = true;
                    rcb_country.Enabled = true;
                    //visited_countries.Enabled = true;
                    RadDatePicker1.Enabled = true;
                    duration.Enabled = true;
                    rcb_acqsrc.Enabled = true;
                    rtb_othres.Enabled = true;
                    rtb_remarks.Enabled = true;
                    purpose.Enabled = true;
                    rtb_expinc.Enabled = true;
                    rb_save.Visible = true;
                    Session["action_t"] = "SAVED_HOLDING";
                    lbl_action_t.Text = "SAVED_HOLDING";
                    rb_addnew.Visible = true;
                   
                }
                //if (status == "HG")
                //{
                //    Session["action_t"] = "PRE_SUBMITTED_HOLDING";
                //    lbl_action_t.Text = "PRE_SUBMITTED_HOLDING";
                //}
                
            }
        }
        protected void rb_addnew_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);

        }

        protected void rb_update_Click(object sender, EventArgs e)
        {
            lbl_action.Text = "Update Transaction :";
            action = 'U';
        }

        protected void rb_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_action.Text.Contains("Update Transaction") && action == 'U')
                {
                    SqlConnection con = null;
                            con = new SqlConnection(ConnectionString);
                            SqlCommand cmd_inttrn = null;

                            con.Open();

                            cmd_inttrn = new SqlCommand("SP_UPDATE_TRANSACTION_EMPLOYEE", con);

                            cmd_inttrn.CommandType = CommandType.StoredProcedure;
                            cmd_inttrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = lbl_refno.Text;
                            cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                            cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                            cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                            cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";
                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value ="";
                            cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                            cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                            cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                            cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                            cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                            cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value ="";
                            cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                            //cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value =visited_countries.Text;
                            cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;
                            cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.Date).Value = RadDatePicker2.SelectedDate;
                            cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                            cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                            
                            cmd_inttrn.Parameters.Add("@FV_VISIT_PURPOSE", SqlDbType.VarChar).Value = purpose.Text;
                            cmd_inttrn.Parameters.Add("@FV_EXP_INCUR", SqlDbType.VarChar).Value = rtb_expinc.Text;
                    
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                            cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;

                            //-----Below code is integrated to handle new others field -------------------
                            //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                            cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = ""; // Insert asttype others details
                            cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = ""; // insert other sources information

                            //-----------------Code Ends----------------------------


                            cmd_inttrn.ExecuteNonQuery();
                            bind_grid();
                        }
                       
                else if (lbl_action.Text.Contains("Add New Transaction") && action == 'A')
                {
                    string error_tag;
                    rb_addnew.Visible = false;
                    if (rcb_EMP.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Select Visitor (Relation)");
                    }
                    
                    
                    else if (rcb_acqsrc.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Select Source of Fund");
                    }

                    //else if (visited_countries.Text.ToString().Trim() == "")
                    else if (rcb_country.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Visited Counties");
                    }
                    else if (RadDatePicker1.SelectedDate.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Visit Start date");
                    }
                    else if (duration.Text.ToString().Trim() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Duration");
                    }

                    else if (rtb_expinc.Text.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Expenditure Incurred Amount");
                    }
                    else if (obj_gl.FnValidateFloat(rtb_expinc.Text.ToString().Trim()) == 0 && rtb_expinc.Text.Trim() != "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Expenditure Amount should be in decimal");
                    }

                    else
                    {

                        error_tag = "";
                       
                            
                            SqlConnection con = null;
                            con = new SqlConnection(ConnectionString);
                            SqlCommand cmd_inttrn = null;

                            con.Open();

                            cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE", con);

                            cmd_inttrn.CommandType = CommandType.StoredProcedure;
                            cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                          //  cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = DateTime.Now.Date;
                            cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                            cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                            cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";
                            cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                            cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                            cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                            cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                            cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                            cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                            cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                           // cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = visited_countries.Text;
                            cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                            cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;
                            cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.Date).Value = RadDatePicker2.SelectedDate;
                            cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text; 
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                            cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                            cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                        //-----Below code is integrated to handle new others field -------------------
                           cmd_inttrn.Parameters.Add("@FV_VISIT_PURPOSE", SqlDbType.VarChar).Value = purpose.Text;
                           cmd_inttrn.Parameters.Add("@FV_EXP_INCUR", SqlDbType.VarChar).Value = rtb_expinc.Text;

                        //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                        cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = ""; // Insert asttype others details
                            cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = ""; // insert other sources information

                            //-----------------Code Ends----------------------------

                            cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                            cmd_inttrn.ExecuteNonQuery();
                            bind_grid();
                        }

                    }
                
            }
            catch (Exception ex)
            {
                FnDisplayMessage(ex.Message);
            }
        }
        protected void rb_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_action.Text.Contains("Update Transaction") && action == 'U')
                {
                    SqlConnection con = null;
                    con = new SqlConnection(ConnectionString);
                    SqlCommand cmd_inttrn = null;

                    con.Open();

                    cmd_inttrn = new SqlCommand("SP_UPDATE_TRANSACTION_EMPLOYEE", con);

                    cmd_inttrn.CommandType = CommandType.StoredProcedure;
                  //  cmd_inttrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = lbl_refno.Text;
                    cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                    cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                    cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                    cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                    cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                    cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";
                    cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                    cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                    cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                    cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                    cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                    cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                    cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                   // cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = visited_countries.Text;
                    cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                    cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;
                    cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.Date).Value = RadDatePicker2.SelectedDate;
                    cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                    cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                    //-----Below code is integrated to handle new others field -------------------
                    cmd_inttrn.Parameters.Add("@FV_VISIT_PURPOSE", SqlDbType.VarChar).Value = purpose.Text;
                    cmd_inttrn.Parameters.Add("@FV_EXP_INCUR", SqlDbType.VarChar).Value = rtb_expinc.Text;
                    //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                    cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = ""; // Insert asttype others details
                    cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = ""; // insert other sources information

                    //-----------------Code Ends----------------------------

                    cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd_inttrn.ExecuteNonQuery();
                    bind_grid();
                }

                else if (lbl_action.Text.Contains("Add New Transaction") && action == 'A')
                {
                    string error_tag;
                    if (rcb_EMP.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Select Dependent");
                    }


                    else if (rcb_acqsrc.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Select Acquisition Source");
                    }

                    else if (rcb_country.SelectedValue.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Visited Counties");
                    }
                    else if (RadDatePicker1.SelectedDate.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Visit Start date");
                    }
                    else if (duration.Text.ToString().Trim() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Duration");
                    }
                    else if (rtb_expinc.Text.ToString() == "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Enter Expenditure Incurred Amount");
                    }
                    else if (obj_gl.FnValidateFloat(rtb_expinc.Text.ToString().Trim()) == 0 && rtb_expinc.Text.Trim() != "")
                    {
                        error_tag = "E";
                        FnDisplayMessage("Expenditure Amount should be in decimal");
                    }
                    else
                    {

                        error_tag = "";


                        SqlConnection con = null;
                        con = new SqlConnection(ConnectionString);
                        SqlCommand cmd_inttrn = null;

                        con.Open();

                        cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE", con);

                        cmd_inttrn.CommandType = CommandType.StoredProcedure;
                        cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                        cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                        cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                        cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                        cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                        cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "03";
                        cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = rcb_acqsrc.SelectedValue.ToString();
                        cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = rtb_othres.Text;
                        cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "HV";
                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                        cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                        cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;
                        cmd_inttrn.Parameters.Add("@FV_END_DATE", SqlDbType.Date).Value = RadDatePicker2.SelectedDate;
                        cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                        cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";

                        //-----Below code is integrated to handle new others field -------------------

                        cmd_inttrn.Parameters.Add("@FV_VISIT_PURPOSE", SqlDbType.VarChar).Value = purpose.Text;
                        cmd_inttrn.Parameters.Add("@FV_EXP_INCUR", SqlDbType.VarChar).Value = rtb_expinc.Text;

                        //----Code integrated by Saurabh Sangat on 17.03.20122--------------------------------------------------
                        cmd_inttrn.Parameters.Add("@ASCAT_OTHDESC", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@ASTYPE_OTHDESC", SqlDbType.VarChar).Value = ""; // Insert asttype others details
                        cmd_inttrn.Parameters.Add("@ACQ_SOURCE_OTHDESC", SqlDbType.VarChar).Value = ""; // insert other sources information

                        //-----------------Code Ends----------------------------

                        cmd_inttrn.Parameters.Add("@CONSVAL", SqlDbType.VarChar).Value = DBNull.Value;
                        cmd_inttrn.ExecuteNonQuery();
                        bind_grid();
                    }

                }

            }
            catch (Exception ex)
            {
                FnDisplayMessage(ex.Message);
            }
        }
        protected void btnToggle_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE1", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_TR_SA";
            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dtf);
            RG_TRN.DataSource = dtf;
            RG_TRN.DataBind();
        }

        protected void btnToggle1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE1", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_TR_SU";
            cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dtf);
            RG_TRN.DataSource = dtf;
            RG_TRN.DataBind();

            foreach (GridDataItem dataitem in RG_TRN.MasterTableView.Items)
            {
                string status = dataitem["STATUS"].Text.Trim().Replace("&nbsp;", "");
                if (status == "SG")
                {
                    (dataitem["Select"].Controls[0] as ImageButton).ImageUrl = "~/Images/Viewicon.png";

                    //dataitem.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
        //+++ Fn to display message
        private void FnDisplayMessage(string text)
        {
            epanel.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

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
                    //HLD_LIABILITY myremotepost = new HLD_LIABILITY();
                    //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                    //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                    //myremotepost.Post();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.ToString());
                }
            }
        }
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
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
                    DataTable dt_forf = new DataTable();
                    SqlDataAdapter ad_forf = new SqlDataAdapter();
                    ad_forf.SelectCommand = cmd_getst;
                    ad_forf.Fill(dt_forf);

                    if (dt_forf.Rows.Count > 0)
                    {
                        Status_HV = "";
                        Status_HG = "";
                        Status_SV = "";

                        DataView view = new DataView(dt_forf);
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
                            pnlFV.Enabled = false;
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
                            pnlFV.Enabled = true;
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
                            pnlFV.Enabled = true;
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
                        pnlFV.Enabled = true;
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
    }
}