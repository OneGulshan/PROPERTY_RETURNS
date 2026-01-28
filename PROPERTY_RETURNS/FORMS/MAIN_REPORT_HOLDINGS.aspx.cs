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
    public partial class MAIN_REPORT_HOLDINGS : System.Web.UI.Page
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
            
            cryrpt.Load(Server.MapPath("~/REPORTS/MAIN_REPORT.rpt"));
            cryrpt.SetParameterValue("@PERNR", Session["emp"].ToString());
            cryrpt.SetParameterValue("@T_TYPE", "IM_HO_SV");
            cryrpt.SetParameterValue("@T_TYPE1", "LI_HO_SV");
            cryrpt.SetDatabaseLogon("sa", "ntpc@123", "10.0.0.205", "PROP_RETURNS"); 
           
            CrystalReportViewer1.ReportSource = cryrpt;
        }
    }
}