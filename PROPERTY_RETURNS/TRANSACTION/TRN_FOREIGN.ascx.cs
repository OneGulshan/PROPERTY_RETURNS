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
    public partial class TRN_FOREIGN : System.Web.UI.UserControl
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        static DataTable dt_dep = new DataTable();
        static DataTable dt_ind = new DataTable();
        static DataTable dt_emp = new DataTable();
        static char action;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                action = 'A';
                bind_grid();
                lbl_action.Text = "Add New Transaction";
                SqlConnection con = null;
                con = new SqlConnection(ConnectionString);
                SqlCommand cmd_getdep = null;
                SqlCommand cmd_getind = null;
                con.Open();
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
                var rows_acqsrc = from row in dt_ind.AsEnumerable()
                                  where row.Field<string>("PARAMTYPE").Trim() == "ACQSRC"
                                  select row;
                DataView view_acqsrc = rows_acqsrc.AsDataView();
                DataTable distinctValues_acqsrc = view_acqsrc.ToTable(true, "PARAMCD", "PARAMDESC");
                rcb_acqsrc.DataSource = distinctValues_acqsrc;
                rcb_acqsrc.DataTextField = "PARAMDESC";
                rcb_acqsrc.DataValueField = "PARAMCD";
                rcb_acqsrc.DataBind();
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
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE1", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString(); 
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "FV_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            RG_TRN.DataSource = dt;
            RG_TRN.DataBind();
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
                //lbl_action.Text = "Update Transaction : " + dataItem["ref_no"].Text;
                
                //var name = dataItem["ProductName"].Text; 
                lbl_refno.Text = dataItem["ref_no"].Text;

                rcb_EMP.SelectedValue = dataItem["EMPNO"].Text;
                visited_countries.Text = dataItem["FV_COUNTRIES"].Text;
                duration.Text = dataItem["FV_DURATION"].Text;
                rcb_acqsrc.SelectedValue = dataItem["ACQSRC"].Text;
            // RadDatePicker1.SelectedDate =Convert.ToDateTime(( Convert.ToDateTime(dataItem["FV_START_DATE"].Text).ToString("MM/dd/yyyy")));                                   
            // 
                String dt=dataItem["FV_START_DATE"].Text.Substring(3, 2) + "/" + dataItem["FV_START_DATE"].Text.Substring(0, 2) + "/" + dataItem["FV_START_DATE"].Text.Substring(6, 4);
                RadDatePicker1.SelectedDate = Convert.ToDateTime(dt);
                string status = dataItem["STATUS"].Text.Trim().Replace("&nbsp;", "");
                if (status == "SG")
                {
                    lbl_action.Text = "Transaction is submitted : " + dataItem["ref_no"].Text;
                    rcb_EMP.Enabled = false;
                    visited_countries.Enabled = false;
                    RadDatePicker1.Enabled = false;
                    duration.Enabled = false;
                    rcb_acqsrc.Enabled = false;
                    rtb_othres.Enabled = false;
                    rtb_remarks.Enabled = false;
                    rb_save.Visible = false;
                }
                else if (status == "SV")
                {
                    lbl_action.Text = "Update Transaction : " + dataItem["ref_no"].Text;
                    action = 'U';
                    rcb_EMP.Enabled = true;
                    visited_countries.Enabled = true;
                    RadDatePicker1.Enabled = true;
                    duration.Enabled = true;
                    rcb_acqsrc.Enabled = true;
                    rtb_othres.Enabled = true;
                    rtb_remarks.Enabled = true;
                    rb_save.Visible = true;
                   
                }
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
                            cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = DateTime.Now.Date;
                            cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                            cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "04";
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
                            cmd_inttrn.Parameters.Add("@TRNNATURE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@INTRATE", SqlDbType.VarChar).Value = Convert.ToDecimal("0");
                            cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                            cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                            cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                            cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value ="";
                            cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value =visited_countries.Text;
                            cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;

                            cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";

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

                    else if (visited_countries.Text.ToString().Trim() == "")
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
                            cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = DateTime.Now.Date;
                            cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                            cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                            cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "04";
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
                            cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                            cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                            cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                            cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = visited_countries.Text;
                            cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;

                            cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text; 
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                            cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";

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
                    cmd_inttrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = lbl_refno.Text;
                    cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = rcb_EMP.SelectedValue;
                    cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = DateTime.Now.Date;
                    cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                    cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                    cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                    cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "04";
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
                    cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                    cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                    cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                    cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = visited_countries.Text;
                    cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;

                    cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                    cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";

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

                    else if (visited_countries.Text.ToString().Trim() == "")
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
                        cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = DateTime.Now.Date;
                        cmd_inttrn.Parameters.Add("@PRPTYPE", SqlDbType.VarChar).Value = "FV";
                        cmd_inttrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
                        cmd_inttrn.Parameters.Add("@ASTYPE", SqlDbType.VarChar).Value = "01";
                        cmd_inttrn.Parameters.Add("@TRNTYP", SqlDbType.VarChar).Value = "04";
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
                        cmd_inttrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                        cmd_inttrn.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = rtb_remarks.Text;
                        cmd_inttrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "LOCAL-changed";
                        cmd_inttrn.Parameters.Add("@FV_RELATION", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_COUNTRIES", SqlDbType.VarChar).Value = visited_countries.Text;
                        cmd_inttrn.Parameters.Add("@FV_START_DATE", SqlDbType.Date).Value = RadDatePicker1.SelectedDate;

                        cmd_inttrn.Parameters.Add("@FV_DURATION", SqlDbType.VarChar).Value = duration.Text;
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE", SqlDbType.VarChar).Value = "";
                        cmd_inttrn.Parameters.Add("@FV_FUND_SOURCE_OTHER", SqlDbType.VarChar).Value = "";

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

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            RG_TRN.DataSource = dt;
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

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            RG_TRN.DataSource = dt;
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
        //+++ Fn to display message
    }
}