using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace PROPERTY_RETURNS.FORMS
{
    public partial class IMMOVABLE_FORM_3 : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        void LoadReport()
        {
            ReportDocument cryrpt = new ReportDocument();
            SqlConnection con = null;
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd_gettrn = null;

            con.Open();
            cmd_gettrn = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
            SqlDataAdapter ad = new SqlDataAdapter();

            cmd_gettrn.CommandType = CommandType.StoredProcedure;
            cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
            cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_TR_SU";

            ad.SelectCommand = cmd_gettrn;
            ad.Fill(dt);
            con.Close();
            cryrpt.Load(Server.MapPath("~/REPORTS/IMMOVABLE_FORM_3.rpt"));
            cryrpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = cryrpt;
        }
    }
}