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
    public partial class FORM1 : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();


            SqlDataAdapter ad = new SqlDataAdapter();

            ad.SelectCommand = cmd_gettrn;

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "01";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_cash.DataSource = dt;
            gv_cash.DataBind();

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "03";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_insu.DataSource = dt;
            gv_insu.DataBind();

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "07";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_loan.DataSource = dt;
            gv_loan.DataBind();

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "05";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_motor.DataSource = dt;
            gv_motor.DataBind();

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "04";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_jewel.DataSource = dt;
            gv_jewel.DataBind();

            dt.Clear();
            cmd_gettrn = new SqlCommand("SP_GET_EMPLOYEE_RECORDS_MO", con);
            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";
            cmd_gettrn.Parameters.Add("@ASCAT", SqlDbType.VarChar).Value = "08";
            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            gv_other.DataSource = dt;
            gv_other.DataBind();



        }
    }
}