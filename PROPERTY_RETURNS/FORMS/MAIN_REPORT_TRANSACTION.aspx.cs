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
    public partial class MAIN_REPORT_TRANSACTION : System.Web.UI.Page
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

            cryrpt.Load(Server.MapPath("~/REPORTS/MAIN_REPORT_REVIEW.rpt"));
            cryrpt.SetParameterValue("@PERNR", Session["emp"].ToString());
            cryrpt.SetParameterValue("@T_TYPE", "IM_TR_SU");
            cryrpt.SetParameterValue("@T_TYPE2", "LI_TR_SU");
            cryrpt.SetDatabaseLogon("sa", "ntpc@123", "10.0.0.205", "PROP_RETURNS");

            CrystalReportViewer1.ReportSource = cryrpt;
        }
    }
}