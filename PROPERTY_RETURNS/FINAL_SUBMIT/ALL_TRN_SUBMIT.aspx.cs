using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;


namespace PROPERTY_RETURNS.FINAL_SUBMIT
{
    public partial class ALL_TRN_SUBMIT : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_grid();
                bind_grid_mo();
            }
        }
        protected void bind_grid()
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            RG_TRN.DataSource = dt;
            RG_TRN.DataBind();
            con.Close();

        }
        protected void bind_grid_mo()
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            RG_TRN_MO.DataSource = dt;
            RG_TRN_MO.DataBind();
            con.Close();

        }

        protected void rbt_submit_Click(object sender, EventArgs e)
        {
            DataTable dt_submit = new DataTable();
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt_submit);

            con.Close();

            SqlCommand cmd_uptrn = null;
            con.Open();

            
            foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
            {
                cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                cmd_uptrn.CommandType = CommandType.StoredProcedure;
                cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd_uptrn.ExecuteNonQuery();
            }
            con.Close();

            submit_MO();
            submit_LI();
        }
        protected void submit_MO()
        {
            DataTable dt_submit = new DataTable();
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt_submit);

            con.Close();

            SqlCommand cmd_uptrn = null;
            con.Open();


            foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
            {
                cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                cmd_uptrn.CommandType = CommandType.StoredProcedure;
                cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd_uptrn.ExecuteNonQuery();
            }
            con.Close();
        }
        protected void submit_LI()
        {
            DataTable dt_submit = new DataTable();
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();

            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_TR_SA";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt_submit);

            con.Close();

            SqlCommand cmd_uptrn = null;
            con.Open();


            foreach (DataRow row in dt_submit.Rows) // Loop over the rows.
            {
                cmd_uptrn = new SqlCommand("SP_UPDATE_TRN_STATUS_EMPLOYEE", con);
                cmd_uptrn.CommandType = CommandType.StoredProcedure;
                cmd_uptrn.Parameters.Add("@REFNO", SqlDbType.VarChar).Value = row["Ref_No"].ToString();
                cmd_uptrn.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                cmd_uptrn.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                cmd_uptrn.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}