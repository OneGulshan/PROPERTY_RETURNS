using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS
{
    public partial class TRN_LIABILITY : System.Web.UI.UserControl
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        public DataTable dt_dep = new DataTable();
        public DataTable dt_ind = new DataTable();
        public DataTable dt_emp = new DataTable();
        public DataTable dt_hdt = new DataTable();
        //static char action;
        //static string action_t;
        public DateTime pre_hold_dt;
        GLB_FNS obj_gl = new GLB_FNS();
        public DateTime acqdt = System.DateTime.Now;
        private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        public string Method = "post";
        public string FormName = "form1";
        public string Url = "";
        String parent_holddt = "";
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
                Session["action_t"] = "ADD_NEW_TRANSACTION";
                lbl_action_t.Text = "ADD_NEW_TRANSACTION";
                bind_grid();
                rb_addnew.Visible = false;
                rb_reject.Visible = false;
                lbl_refno.Text = "";
                lbl_action.Text = "Add New Transaction";
                bind_rdbref();
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
                        //cmd_gethdt = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
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

                        btnToggle1.Text = "Saved Transactions of Holding Date : " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        btnToggle4.Text = "Final Submitted Holdings as On " + Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        btnToggle3.Text = "Carry Forward Holdings of " + Convert.ToDateTime(pre_hold_dt).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        rcb_EMP.DataSource = dt_emp;
                        rcb_EMP.DataTextField = "EMPNAME";
                        rcb_EMP.DataValueField = "EMPNO";
                        rcb_EMP.DataBind();

                        var rows_ascat = from row in dt_dep.AsEnumerable()
                                         where row.Field<string>("PRPTYPE").Trim() == "LI"
                                         select row;
                        DataView view_ascat = rows_ascat.AsDataView();
                        DataTable distinctValues_ascat = view_ascat.ToTable(true, "ASCAT", "ASCATDESC");
                        rcb_astcat.DataSource = distinctValues_ascat;
                        rcb_astcat.DataTextField = "ASCATDESC";
                        rcb_astcat.DataValueField = "ASCAT";
                        rcb_astcat.DataBind();

                        var rows_asttype = from row in dt_dep.AsEnumerable()
                                           where row.Field<string>("PRPTYPE").Trim() == "LI"
                                           && row.Field<string>("ASCAT").Trim() == view_ascat[0][2].ToString()
                                           select row;
                        DataView view_asttype = rows_asttype.AsDataView();
                        DataTable distinctValues_asttype = view_asttype.ToTable(true, "ASTYPE", "ASTYPEDESC");
                        rcb_asttype.DataSource = distinctValues_asttype;
                        rcb_asttype.DataTextField = "ASTYPEDESC";
                        rcb_asttype.DataValueField = "ASTYPE";
                        rcb_asttype.DataBind();

                        var rows_trntype = from row in dt_dep.AsEnumerable()
                                           where row.Field<string>("PRPTYPE").Trim() == "LI"
                                           && row.Field<string>("ASCAT").Trim() == view_ascat[0][2].ToString()
                                           && row.Field<string>("ASTYPE").Trim() == view_asttype[0][4].ToString()
                                           && row.Field<string>("TRNTYP").Trim() != "03"
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

                       

                        var rows_country = from row in dt_ind.AsEnumerable()
                                           where row.Field<string>("PARAMTYPE").Trim() == "COUNTRY"
                                           select row;
                        DataView view_country = rows_country.AsDataView();
                        DataTable distinctValues_country = view_country.ToTable(true, "PARAMCD", "PARAMDESC");
                        rcb_country.DataSource = distinctValues_country;
                        rcb_country.DataTextField = "PARAMDESC";
                        rcb_country.DataValueField = "PARAMCD";
                        rcb_country.DataBind();

                        rcb_country.SelectedValue = "STATE_IN";

                        var rows_state = from row in dt_ind.AsEnumerable()
                                         where row.Field<string>("PARAMTYPE").Trim() == rcb_country.SelectedItem.Value.ToString()
                                         select row;
                        DataView view_state = rows_state.AsDataView();
                        DataTable distinctValues_state = view_state.ToTable(true, "PARAMCD", "PARAMDESC");
                        rcb_state.DataSource = distinctValues_state;
                        rcb_state.DataTextField = "PARAMDESC";
                        rcb_state.DataValueField = "PARAMCD";
                        rcb_state.DataBind();
                        rcb_state.SelectedValue = view_state[0][1].ToString();

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

        protected void rcb_unit_DataBound(object sender, EventArgs e)
        {
            var combo = (RadComboBox)sender;
            // rcb_unit.Items.Insert(0, new RadComboBoxItem("Select Unit", string.Empty));
        }

        protected void RG_TRN_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item.IsInEditMode)
            {


            }

        }

        protected void bind_grid()
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

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_TR_SA";
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

        protected void bind_rdbref()
        {
            dt.Clear();
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);

                    dt.Columns.Add("Combined", typeof(String));
                    foreach (DataRow dr in dt.Rows)
                    {

                        dr["Combined"] = dr["EMPNAME"].ToString() + "-" + dr["ref_no"].ToString() + "-" + dr["description"].ToString() + "-" + dr["address"].ToString() + "- Rs. " + dr["trn_amount"].ToString();

                    }

                    rdb_refholding.DataTextField = "Combined";
                    rdb_refholding.DataValueField = "ref_no";
                    rdb_refholding.DataSource = dt;


                    rdb_refholding.DataBind();



                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
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
                lbl_action.Text = "Update Transaction : " + dataItem["ref_no"].Text;
                //action = 'U';
                lbl_refno.Text = dataItem["ref_no"].Text;
                rcb_EMP.SelectedValue = dataItem["EMPNO"].Text;
                rcb_astcat.SelectedValue = dataItem["ASCAT"].Text;

                var rows_asttype = from row in dt_dep.AsEnumerable()
                                   where row.Field<string>("PRPTYPE").Trim() == "LI"
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
                                   where row.Field<string>("PRPTYPE").Trim() == "LI"
                                   && row.Field<string>("ASCAT").Trim() == dataItem["ASCAT"].Text
                                   && row.Field<string>("ASTYPE").Trim() == dataItem["ASTYPE"].Text
                                   && row.Field<string>("TRNTYP").Trim() != "03"
                                   select row;
                DataView view_trntype = rows_trntype.AsDataView();
                DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

                var rows_country = from row in dt_ind.AsEnumerable()
                                   where row.Field<string>("PARAMTYPE").Trim() == "COUNTRY"
                                   select row;
                DataView view_country = rows_country.AsDataView();
                DataTable distinctValues_country = view_country.ToTable(true, "PARAMCD", "PARAMDESC");
                rcb_country.DataSource = distinctValues_country;
                rcb_country.DataTextField = "PARAMDESC";
                rcb_country.DataValueField = "PARAMCD";
                rcb_country.DataBind();

                var rows_state = from row in dt_ind.AsEnumerable()
                                 where row.Field<string>("PARAMTYPE").Trim() == dataItem["COUNTRY"].Text
                                 select row;
                DataView view_state = rows_state.AsDataView();
                DataTable distinctValues_state = view_state.ToTable(true, "PARAMCD", "PARAMDESC");
                rcb_state.DataSource = distinctValues_state;
                rcb_state.DataTextField = "PARAMDESC";
                rcb_state.DataValueField = "PARAMCD";
                rcb_state.DataBind();

                rcb_trntype.DataSource = distinctValues_trntype;
                rcb_trntype.DataTextField = "TRNTYPDESC";
                rcb_trntype.DataValueField = "TRNTYP";
                rcb_trntype.DataBind();
                rcb_trntype.SelectedValue = dataItem["TRNTYP"].Text.Replace("&nbsp;", ""); ;
                rcb_acqsrc.SelectedValue = dataItem["ACQSRC"].Text;
                rdp_trndt.SelectedDate = rdp_hlddt.SelectedDate;
                rtb_othres.Text = dataItem["Acq_Remarks"].Text.Replace("&nbsp;", "");
                rtb_amt.Text = dataItem["TRNAMT"].Text.Replace("&nbsp;", "");
                rtb_balamt.Text = dataItem["BALAMT"].Text.Replace("&nbsp;", "");
                rtb_intrate.Text = dataItem["INTRATE"].Text.Replace("&nbsp;", "");
                rtb_remarks.Text = dataItem["REMARKS"].Text.Replace("&nbsp;", "");
                rtb_refno.Text = dataItem["OBJECTID"].Text.Replace("&nbsp;", "");
                rtb_refdesc.Text = dataItem["IDDESC"].Text.Replace("&nbsp;", "");
                rtb_addline1.Text = dataItem["ADDLINE1"].Text.Replace("&nbsp;", "");
                rtb_addline2.Text = dataItem["ADDLINE2"].Text.Replace("&nbsp;", "");
                rtb_city.Text = dataItem["CITY"].Text.Replace("&nbsp;", "");
                rcb_state.SelectedValue = dataItem["STATE"].Text;
                rtb_post.Text = dataItem["POSTCODE"].Text.Replace("&nbsp;", "");
                rcb_country.SelectedValue = dataItem["COUNTRY"].Text;
                string status = dataItem["STATUS"].Text.Trim().Replace("&nbsp;", "");
                rtb_balamt.Text = dataItem["BALAMT"].Text.Trim().Replace("&nbsp;", "");
                string trn_period = dataItem["TRN_PERIOD"].Text.Trim().Replace("&nbsp;", "");

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


                        cmd_inttrn = new SqlCommand("select * from T_TRANSACTION_MAP where refnum='" + dataItem["ref_no"].Text + "'", con);
                        DataTable dt_for = new DataTable();
                        SqlDataAdapter ad_for = new SqlDataAdapter();
                        ad_for.SelectCommand = cmd_inttrn;
                        ad_for.Fill(dt_for);
                        if (dt_for.Rows.Count > 0)
                        {
                            rdb_refholding.SelectedValue = dt_for.Rows[0][1].ToString();
                            rdb_trnfor.SelectedValue = dt_for.Rows[0][2].ToString();
                        }
                        if (rdb_trnfor.SelectedValue == "NEW DECLARATION" || rdb_trnfor.SelectedValue == "BUY")
                        {
                            rdb_refholding.Visible = false;
                            rdb_refholding.SelectedValue = "";
                            Label14.Visible = false;
                        }
                        else
                        {
                            rdb_refholding.Visible = true;
                            Label14.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }

                if (status == "SV")
                {
                    Session["action_t"] = "SAVED_TRANSACTION";
                    lbl_action_t.Text = "SAVED_TRANSACTION";
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
            //TRN_LIABILITY myremotepost = new TRN_LIABILITY();
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

            try
            {
                string error_tag;
                if (rcb_EMP.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Dependent");
                }
                else if (rcb_astcat.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Asset Category");
                }
                else if (rcb_asttype.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Asset Type");
                }
                else if (rcb_trntype.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Transaction Type");
                }
                else if (rdp_trndt.SelectedDate.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Transaction Date");
                }
                else if (rtb_amt.Text.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Liability Amount");
                }
                else if (obj_gl.FnValidateFloat(rtb_amt.Text.ToString().Trim()) == 0 && rtb_amt.Text.ToString().Trim() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Liability Amount should be in decimal/integer");
                }
                else if (obj_gl.FnValidateFloat(rtb_balamt.Text.ToString().Trim()) == 0 && rtb_balamt.Text.Trim() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Balance Amount should be in decimal");
                }
                else if (rtb_addline1.Text.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter Creditor Address");
                }
                else if (obj_gl.FnValidateInt(rtb_post.Text.ToString().Trim()) == 0 && rtb_post.Text.Trim() != "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Enter valid postcode");
                }

                else if (rcb_state.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Country/State");
                }
                else if (rcb_country.SelectedValue.ToString() == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Select Country");
                }
                else if (rdb_trnfor.SelectedValue == "" )
                {
                    error_tag = "E";
                    FnDisplayMessage("Transaction operation must be selected.");
                }
                else if (rdb_trnfor.SelectedValue != "BUY" && rdb_trnfor.SelectedValue != "NEW DECLARATION" && rdb_refholding.SelectedValue == "")
                {
                    error_tag = "E";
                    FnDisplayMessage("Holding Reference must be selected for this transaction operation");
                }
                else
                {
                    int p = 0;
                    error_tag = "";
                    if (lbl_action_t.Text == "SAVED_TRANSACTION")
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
                                cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "LI";
                                cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_amt.Text);
                                cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = rtb_addline1.Text;
                                cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = rtb_addline2.Text;
                                cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = rtb_city.Text;
                                cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = rtb_post.Text;
                                cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = rcb_state.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                                cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value; ;
                                cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                if (rtb_intrate.Text.Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_intrate.Text);
                                }
                                cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                if (rtb_balamt.Text.Trim() == "")
                                {
                                    cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_balamt.Text);
                                }
                                cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";
                                cmd_inttrn.ExecuteNonQuery();
                                //Response.Redirect(Request.RawUrl);                     
                                //con.Close();
                            }
                            catch (Exception ex)
                            {
                                //Handle exception, perhaps log it and do the needful
                                fndisplay(ex.Message);
                            }
                        }
                        if (p == 1)
                        {
                            if (rdb_trnfor.SelectedValue != "NEW TRANSACTION")
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

                                        SqlCommand cmd_inttrn = null;
                                        cmd_inttrn = new SqlCommand("SP_UPDATE_TRANSACTION_FOR", con);
                                        cmd_inttrn.CommandType = CommandType.StoredProcedure;
                                        //cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@REFNUM", SqlDbType.VarChar).Value = lbl_refno.Text;
                                        cmd_inttrn.Parameters.Add("@REFNUM_OF", SqlDbType.VarChar).Value = rdb_refholding.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@TYPE_OF_CHANGE", SqlDbType.VarChar).Value = rdb_trnfor.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@HOLDDT", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                        cmd_inttrn.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                                        //cmd_inttrn.Parameters.Add("@AEDTM", SqlDbType.VarChar).Value = rtb_city.Text;
                                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                        cmd_inttrn.Parameters.Add("@FLD1", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FLD2", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.ExecuteNonQuery();
                                        Response.Redirect(Request.RawUrl);
                                        //TRN_IMMOVABLE myremotepost = new TRN_IMMOVABLE();
                                        //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
                                        //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                        //myremotepost.Post();
                                    }
                                    catch (Exception ex)
                                    {
                                        //Handle exception, perhaps log it and do the needful
                                        fndisplay(ex.Message);
                                    }
                                }
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

                                        SqlCommand cmd_inttrn = null;
                                        cmd_inttrn = new SqlCommand("SP_UPDATE_TRANSACTION_FOR", con);
                                        cmd_inttrn.CommandType = CommandType.StoredProcedure;
                                        //cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@REFNUM", SqlDbType.VarChar).Value = lbl_refno.Text;
                                        cmd_inttrn.Parameters.Add("@REFNUM_OF", SqlDbType.VarChar).Value = rdb_refholding.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@TYPE_OF_CHANGE", SqlDbType.VarChar).Value = rdb_trnfor.SelectedValue;
                                        cmd_inttrn.Parameters.Add("@HOLDDT", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                        cmd_inttrn.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                                        //cmd_inttrn.Parameters.Add("@AEDTM", SqlDbType.VarChar).Value = rtb_city.Text;
                                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "RJ";
                                        cmd_inttrn.Parameters.Add("@FLD1", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.Parameters.Add("@FLD2", SqlDbType.VarChar).Value = "";
                                        cmd_inttrn.ExecuteNonQuery();
                                        Response.Redirect(Request.RawUrl);
                                        //TRN_IMMOVABLE myremotepost = new TRN_IMMOVABLE();
                                        //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
                                        //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                        //myremotepost.Post();
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
                    else if (lbl_action_t.Text == "SUBMITTED_TRANSACTION" || lbl_action_t.Text == "ADD_NEW_TRANSACTION")
                    {
                        int r = 0;
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
                                    cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "LI";
                                    cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_amt.Text);
                                    cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                    cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                    cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = rtb_addline1.Text;
                                    cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = rtb_addline2.Text;
                                    cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = rtb_city.Text;
                                    cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = rtb_post.Text;
                                    cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = rcb_state.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                    cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                    if (rtb_intrate.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_intrate.Text);
                                    }
                                    cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                    cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                    cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                    cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                    if (rtb_balamt.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_balamt.Text);
                                    }
                                    cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                    cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.ExecuteNonQuery();
                                    Response.Redirect(Request.RawUrl);
                                    //TRN_LIABILITY myremotepost = new TRN_LIABILITY();
                                    //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
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
                            if (r == 1)
                            {
                                if (rdb_trnfor.SelectedValue != "NEW TRANSACTION")
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

                                            SqlCommand cmd_inttrn = null;
                                            cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_FOR", con);
                                            cmd_inttrn.CommandType = CommandType.StoredProcedure;
                                            cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                                            //cmd_inttrn.Parameters.Add("@REFNUM", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_own.Text);
                                            cmd_inttrn.Parameters.Add("@REFNUM_OF", SqlDbType.VarChar).Value = rdb_refholding.SelectedValue;
                                            cmd_inttrn.Parameters.Add("@TYPE_OF_CHANGE", SqlDbType.VarChar).Value = rdb_trnfor.SelectedValue;
                                            cmd_inttrn.Parameters.Add("@HOLDDT", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_trndt.SelectedDate.ToString());
                                            cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                            cmd_inttrn.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                                            //cmd_inttrn.Parameters.Add("@AEDTM", SqlDbType.VarChar).Value = rtb_city.Text;
                                            cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                            cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                            cmd_inttrn.Parameters.Add("@FLD1", SqlDbType.VarChar).Value = "";
                                            cmd_inttrn.Parameters.Add("@FLD2", SqlDbType.VarChar).Value = "";
                                            cmd_inttrn.ExecuteNonQuery();
                                            Response.Redirect(Request.RawUrl);
                                            //TRN_IMMOVABLE myremotepost = new TRN_IMMOVABLE();
                                            //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
                                            //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
                                            //myremotepost.Post();
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
                                    cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "LI";
                                    cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = rcb_astcat.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = rcb_asttype.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = rcb_trntype.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@TRNAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_amt.Text);
                                    cmd_inttrn.Parameters.Add("@CURVAL", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@ANINCM", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@SHRPC", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@COOWNER", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@OBJECTID", SqlDbType.VarChar).Value = rtb_refno.Text;
                                    cmd_inttrn.Parameters.Add("@IDDESC", SqlDbType.VarChar).Value = rtb_refdesc.Text;
                                    cmd_inttrn.Parameters.Add("@ADDLINE1", SqlDbType.VarChar).Value = rtb_addline1.Text;
                                    cmd_inttrn.Parameters.Add("@ADDLINE2", SqlDbType.VarChar).Value = rtb_addline2.Text;
                                    cmd_inttrn.Parameters.Add("@CITY", SqlDbType.VarChar).Value = rtb_city.Text;
                                    cmd_inttrn.Parameters.Add("@POSTCODE", SqlDbType.VarChar).Value = rtb_post.Text;
                                    cmd_inttrn.Parameters.Add("@STATE", SqlDbType.VarChar).Value = rcb_state.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = rcb_country.SelectedValue.ToString();
                                    cmd_inttrn.Parameters.Add("@QTY", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@UNIT", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQSRC", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQDESC", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@ACQDT", SqlDbType.DateTime).Value = acqdt;
                                    cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                                    if (rtb_intrate.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_intrate.Text);
                                    }
                                    cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                    cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                                    cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                    cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = DBNull.Value;
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";
                                    if (rtb_balamt.Text.Trim() == "")
                                    {
                                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd_inttrn.Parameters.Add("@BALAMT", SqlDbType.VarChar).Value = Convert.ToDecimal(rtb_balamt.Text);
                                    }
                                    cmd_inttrn.Parameters.Add("@TRN_TO_HOLDING", SqlDbType.VarChar).Value = "Y";
                                    cmd_inttrn.Parameters.Add("@ACQFROM", SqlDbType.VarChar).Value = "";
                                    cmd_inttrn.ExecuteNonQuery();
                                    Response.Redirect(Request.RawUrl);
                                    //TRN_LIABILITY myremotepost = new TRN_LIABILITY();
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
                               where row.Field<string>("PRPTYPE").Trim() == "LI"
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
                               where row.Field<string>("PRPTYPE").Trim() == "LI"
                               && row.Field<string>("ASCAT").Trim() == rcb_astcat.SelectedValue.ToString()
                               && row.Field<string>("ASTYPE").Trim() == view_asttype[0][4].ToString()
                               && row.Field<string>("TRNTYP").Trim() != "03"
                               select row;
            DataView view_trntype = rows_trntype.AsDataView();
            DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

            rcb_trntype.DataSource = distinctValues_trntype;
            rcb_trntype.DataTextField = "TRNTYPDESC";
            rcb_trntype.DataValueField = "TRNTYP";
            rcb_trntype.DataBind();
            //rcb_trntype.SelectedValue = "03";

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
                               where row.Field<string>("PRPTYPE").Trim() == "LI"
                               && row.Field<string>("ASCAT").Trim() == rcb_astcat.SelectedValue.ToString()
                               && row.Field<string>("ASTYPE").Trim() == rcb_asttype.SelectedValue.ToString()
                               && row.Field<string>("TRNTYP").Trim() != "03"
                               select row;
            DataView view_trntype = rows_trntype.AsDataView();
            DataTable distinctValues_trntype = view_trntype.ToTable(true, "TRNTYP", "TRNTYPDESC");

            rcb_trntype.DataSource = distinctValues_trntype;
            rcb_trntype.DataTextField = "TRNTYPDESC";
            rcb_trntype.DataValueField = "TRNTYP";
            rcb_trntype.DataBind();
            //rcb_trntype.SelectedValue = "03";
        }
        protected void rcb_country_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
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

            var rows_state = from row in dt_ind.AsEnumerable()
                             where row.Field<string>("PARAMTYPE").Trim() == rcb_country.SelectedItem.Value.ToString()
                             select row;
            DataView view_state = rows_state.AsDataView();
            DataTable distinctValues_state = view_state.ToTable(true, "PARAMCD", "PARAMDESC");
            rcb_state.DataSource = distinctValues_state;
            rcb_state.DataTextField = "PARAMDESC";
            rcb_state.DataValueField = "PARAMCD";
            rcb_state.DataBind();
            rcb_state.SelectedValue = view_state[0][1].ToString();
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

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_TR_SA";
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

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_TR_SU_HO";
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

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG_P";
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

                    cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);
                    RG_TRN.DataSource = dt;
                    RG_TRN.DataBind();
                    // con.Close();
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
                    //TRN_LIABILITY myremotepost = new TRN_LIABILITY();
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

        protected void rdb_refholding_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            dt.Clear();
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
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            
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
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = rdp_hlddt.SelectedDate.ToString();
                    ad.SelectCommand = cmd_gettrn;
                    ad.Fill(dt);

                    DataRow[] rows;
                    rows = dt.Select("ref_no = '" + rdb_refholding.SelectedValue.ToString() + "'");  //'UserName' is ColumnName


                    rcb_EMP.SelectedValue = rows[0]["EMPNO"].ToString().Replace("&nbsp;", "");
                    rcb_astcat.SelectedValue = rows[0]["ASCAT"].ToString().Replace("&nbsp;", "");
                    rcb_asttype.SelectedValue = rows[0]["ASTYPE"].ToString().Replace("&nbsp;", "");
                    //rcb_trntype.SelectedValue = rows[0]["ASCAT"].ToString();
                   // rcb_acqsrc.SelectedValue = rows[0]["ACQSRC"].ToString().Replace("&nbsp;", "");
                    //rdp_trndt.SelectedDate = rows[0]["ASCAT"].ToString();
                   // rtb_othres.Text = rows[0]["Acq_Remarks"].ToString().Replace("&nbsp;", "");
                    rtb_amt.Text = rows[0]["TRNAMT"].ToString().Replace("&nbsp;", "");
                    rtb_balamt.Text = rows[0]["BALAMT"].ToString().Replace("&nbsp;", "");
                    rtb_intrate.Text = rows[0]["INTRATE"].ToString().Replace("&nbsp;", "");
                    rtb_addline1.Text = rows[0]["ADDLINE1"].ToString().Replace("&nbsp;", "");
                    rtb_remarks.Text = rows[0]["REMARKS"].ToString().Replace("&nbsp;", "");
                    rtb_addline2.Text = rows[0]["ADDLINE2"].ToString().Replace("&nbsp;", "");
                    rtb_city.Text = rows[0]["CITY"].ToString().Replace("&nbsp;", "");
                    
                    rtb_post.Text = rows[0]["POSTCODE"].ToString().Replace("&nbsp;", "");
                    rcb_country.SelectedValue = rows[0]["COUNTRY"].ToString().Replace("&nbsp;", "");
                    rtb_refno.Text = rows[0]["OBJECTID"].ToString().Replace("&nbsp;", "");
                    rtb_refdesc.Text = rows[0]["IDDESC"].ToString().Replace("&nbsp;", "");

                    var rows_state = from row in dt_ind.AsEnumerable()
                                     where row.Field<string>("PARAMTYPE").Trim() == rcb_country.SelectedItem.Value.ToString()
                                     select row;
                    DataView view_state = rows_state.AsDataView();
                    DataTable distinctValues_state = view_state.ToTable(true, "PARAMCD", "PARAMDESC");
                    rcb_state.DataSource = distinctValues_state;
                    rcb_state.DataTextField = "PARAMDESC";
                    rcb_state.DataValueField = "PARAMCD";
                    rcb_state.DataBind();
                    rcb_state.SelectedValue = view_state[0][1].ToString();

                    rcb_state.SelectedValue = rows[0]["STATE"].ToString().Replace("&nbsp;", "");
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }

        protected void rdb_trnfor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rdb_trnfor.SelectedValue == "NEW DECLARATION" || rdb_trnfor.SelectedValue == "BUY")
            {
                rdb_refholding.Visible = false;
                rdb_refholding.SelectedValue = "";
                Label14.Visible = false;
            }
            else
            {
                rdb_refholding.Visible = true;
                Label14.Visible = true;
            }
        }
    }
}