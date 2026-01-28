using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS.FORMS
{
    public partial class GEN_REPORT1 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string l_pernr = "0";
                bind_grid(l_pernr);

                rcb_pa.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "All PA", Value = "%" });
                rcb_pa.SelectedIndex = 0;
            }
        }
        protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = dt;
            //RG_TRN.Rebind();
        }
        protected void bind_grid(string pernr)
        {
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_getrep = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    cmd_getrep = new SqlCommand("SP_GENERAL_REPORT1", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_getrep.CommandType = CommandType.StoredProcedure;
                    cmd_getrep.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = ""+pernr;
                    cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = "" + rcb_pa.SelectedValue;
                    cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = "" + rcb_psa.SelectedValue;
                    //cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SV";

                    ad.SelectCommand = cmd_getrep;
                    ad.Fill(dt);
                    RadGrid1.DataSource = dt;
                    RadGrid1.DataBind();
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                switch (item["status"].Text.Trim())
                {
                    case "HV":
                        item["status"].Text = "Saved";
                        break;
                    case "HG":
                        item["status"].Text = "Submitted";
                        break;
                    case "RJ":
                        item["status"].Text = "Rejected";
                        break;
                }
            }
        }
        
        protected void rcb_psa_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcb_psa.SelectedIndex >= 0)
            {
                SqlDataSource_EMP.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                SqlDataSource_EMP.SelectParameters[1].DefaultValue = rcb_psa.SelectedValue.ToString();
                rcb_empno.Focus();
            }
        }

        protected void rcb_emp_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)

        {
            string l_pernr = "0";
            if (rcb_empno.SelectedIndex >= 0)
                l_pernr = rcb_empno.SelectedValue.ToString();
            bind_grid(l_pernr);
            
            //Sqd_empdtl.SelectCommand = Sqd_empdtl.SelectCommand + HttpContext.Current.Session("sPraCd") + "')))"
        }

        protected void rcb_pa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcb_pa.SelectedIndex >= 0)
            {
                SqlDataSource_PSA.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                rcb_psa.Focus();
            }
        }
        private void FnDisplayMessage(string text)
        {
            epanel.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }



        protected void ImageButton1_Click(object sender, CommandEventArgs e)
        {
            string l_pernr = "";
            string l_status = "";
            
            GridDataItem item = RadGrid1.Items[Convert.ToInt32(e.CommandArgument)];
            l_pernr = item.GetDataKeyValue("pernr").ToString();
            //foreach (GridDataItem item in RadGrid1.SelectedItems)
            //{
            //   // Response.Write(item["pernr"].Text.ToString()); // CustomerID is the uniquename of column 
            //     l_pernr = item.GetDataKeyValue("pernr").ToString();
                 l_status = item["STATUS"].Text.Replace("&nbsp;", ""); 
                if (l_status=="Saved")
                    Response.Redirect("~/REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr="+l_pernr);
                else if(l_status=="Submitted")
                    Response.Redirect("~/REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr);
            //}
        }
    }
}