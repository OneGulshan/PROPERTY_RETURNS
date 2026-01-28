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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PROPERTY_RETURNS.FORMS
{
    public partial class MOVABLE_FORM2 : System.Web.UI.Page
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

            cryrpt.Load(Server.MapPath("~/REPORTS/MOVABLE_FORM_2.rpt"));
            cryrpt.SetParameterValue("pernr", Session["emp"].ToString());
            cryrpt.SetParameterValue("t_type", "MO_HO_SV");
            cryrpt.SetParameterValue("ascat1", "01");
            cryrpt.SetParameterValue("ascat2", "03");
            cryrpt.SetParameterValue("ascat3", "07");
            cryrpt.SetParameterValue("ascat4", "05");
            cryrpt.SetParameterValue("ascat5", "04");
            cryrpt.SetParameterValue("ascat6", "08");
            cryrpt.SetDatabaseLogon("sa", "ntpc@123", "10.0.0.205", "PROP_RETURNS");

            CrystalReportViewer1.ReportSource = cryrpt;
        }
    }
}