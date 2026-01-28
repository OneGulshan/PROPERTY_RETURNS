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
    public partial class EXP_REPORT1 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = dt;
            bind_grid();
            //RG_TRN.Rebind();
        }
        protected void bind_grid()
        {

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

                    cmd_getrep = new SqlCommand("SP_EXCEPTION_REPORT", con);
                    SqlDataAdapter ad = new SqlDataAdapter();

                    cmd_getrep.CommandType = CommandType.StoredProcedure;
                    //if (rcb_empno.SelectedValue.ToString() != "")
                    //{
                    //    cmd_getrep.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = "" + rcb_empno.SelectedValue;
                    //    cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = "" + rcb_pa.SelectedValue;
                    //    cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = "" + rcb_psa.SelectedValue;
                    //    cmd_getrep.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "" + rcb_status.SelectedValue;
                    //}
                    //else
                    //{
                    string txt = TxtMultiEmp.Text;
                    string l_pernr = "";
                    //if (txt != "")
                    //{
                    string[] lst = txt.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lst.Length; i++)
                        l_pernr += lst[i] + ",";

                    l_pernr = l_pernr + "," + rcb_empno.SelectedValue.ToString();
                    cmd_getrep.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = "" + l_pernr;

                    if (rcb_pa.SelectedValue == "" || rcb_pa.SelectedItem.Text == "  All")
                    {
                        cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = "%";
                    }
                    else
                    {
                        cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = rcb_pa.SelectedValue;
                    }
                    if (rcb_psa.SelectedValue == "" || rcb_psa.SelectedItem.Text == "  All")
                    {
                        cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = "%";
                    }
                    else
                    {
                        cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = rcb_psa.SelectedValue;
                    }
                    //cmd_getrep.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "" + rcb_status.SelectedValue;
                    cmd_getrep.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "A";
                    cmd_getrep.Parameters.Add("@HOLDINGDT", SqlDbType.VarChar).Value = rcb_hlddt.SelectedValue.ToString();
                    //}
                    //}

                    //ad.SelectCommand = cmd_getrep;
                    //ad.Fill(dt);
                    dt.Load(cmd_getrep.ExecuteReader());
                    RadGrid1.DataSource = dt;
                    //RadGrid1.DataBind();
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
                TxtMultiEmp.Text = "";
                SqlDataSource_EMP.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                SqlDataSource_EMP.SelectParameters[1].DefaultValue = rcb_psa.SelectedValue.ToString();

                if (rcb_pa.SelectedItem.Text == "  All" && rcb_psa.SelectedItem.Text == "  All")
                {
                    SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER] order by empname";
                    SqlDataSource_EMP.DataBind();
                }
                if (rcb_pa.SelectedItem.Text != "  All" && rcb_psa.SelectedItem.Text == "  All")
                {
                    SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER] where PA=@PA order by empname";
                    SqlDataSource_EMP.DataBind();
                }
                if (rcb_pa.SelectedItem.Text == "  All" && rcb_psa.SelectedItem.Text != "  All")
                {
                    SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER] where PSA=@PSA order by empname";
                    SqlDataSource_EMP.DataBind();
                }

                rcb_empno.SelectedValue = "%";
                rcb_empno.Focus();
                // bind_grid();
            }
        }

        protected void rcb_emp_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            string l_pernr = "0";
            if (rcb_empno.SelectedIndex >= 0)
            {
                TxtMultiEmp.Text = "";
                l_pernr = rcb_empno.SelectedValue.ToString();
            }

            //bind_grid();
        }

        protected void rcb_pa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcb_pa.SelectedIndex >= 0)
            {
                SqlDataSource_EMP.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                SqlDataSource_EMP.SelectParameters[1].DefaultValue = "%";
                if (rcb_pa.SelectedItem.Text == "  All")
                {
                    SqlDataSource_PSA.SelectCommand = "SELECT top 1 '%' as PSA,'  All' as Location FROM [EMPMASTER] union all SELECT distinct [PSA], [LOCATION] FROM [EMPMASTER] WHERE PSA <> '' and LOCATION <> '' order by location ";
                    SqlDataSource_PSA.DataBind();
                    SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER]  order by empname";
                    SqlDataSource_EMP.DataBind();
                }
                else
                {
                    SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [EMPMASTER]  WHERE PA = @PA order by empname";
                    SqlDataSource_EMP.DataBind();

                }
                SqlDataSource_PSA.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();

                rcb_psa.SelectedValue = "%";
                rcb_empno.SelectedValue = "%";
                rcb_psa.Focus();
                // bind_grid();
                TxtMultiEmp.Text = "";
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
        protected void btnShowAll_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, CommandEventArgs e)
        {
            string l_pernr = "";
            string l_status = "";
            DateTime sdate = Convert.ToDateTime(rcb_hlddt.SelectedValue);
            string storeDate = Convert.ToString(sdate);
            Session["getDate"] = sdate;
            GridDataItem item = RadGrid1.Items[Convert.ToInt32(e.CommandArgument)];
            l_pernr = item.GetDataKeyValue("pernr").ToString();
            //foreach (GridDataItem item in RadGrid1.SelectedItems)
            //{
            //   // Response.Write(item["pernr"].Text.ToString()); // CustomerID is the uniquename of column 
            //     l_pernr = item.GetDataKeyValue("pernr").ToString();
            l_status = item["STATUS"].Text.Replace("&nbsp;", "");
           // if (l_status == "Saved")
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
            ////Response.Redirect("~/REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr="+l_pernr+" target=_blank");
            //else if (l_status == "Submitted")
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
            //Response.Redirect("~/REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + " target=_blank");
            //}
        }
        //protected void ImageButton1_Click(object sender, CommandEventArgs e)
        //{
        //    string l_pernr = "";
        //    string l_status = "";
        //    DateTime sdate = Convert.ToDateTime(rcb_hlddt.SelectedValue);
        //    string storeDate = Convert.ToString(sdate);
        //    Session["getDate"] = sdate;
        //    GridDataItem item = RadGrid1.Items[Convert.ToInt32(e.CommandArgument)];
        //    l_pernr = item.GetDataKeyValue("pernr").ToString();
        //    //foreach (GridDataItem item in RadGrid1.SelectedItems)
        //    //{
        //    //   // Response.Write(item["pernr"].Text.ToString()); // CustomerID is the uniquename of column 
        //    //     l_pernr = item.GetDataKeyValue("pernr").ToString();
        //    l_status = item["STATUS"].Text.Replace("&nbsp;", "");
        //    if (l_status == "Saved")
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
        //    //Response.Redirect("~/REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr="+l_pernr+" target=_blank");
        //    else if (l_status == "Submitted")
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
        //    //Response.Redirect("~/REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + " target=_blank");
        //    //}
        //}

        protected void rcb_status_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Session["year"] = Convert.ToDateTime(rcb_hlddt.SelectedValue).Year;
            RadGrid1.Rebind();
        }

        protected void TxtMultiEmp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}