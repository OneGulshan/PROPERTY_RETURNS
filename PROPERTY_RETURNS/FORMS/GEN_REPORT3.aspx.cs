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
    public partial class GEN_REPORT3 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt_pa = new DataTable();
        DataTable dt_psa = new DataTable();
        DataTable dt_emp = new DataTable();
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (Session["role"].ToString() == "S")
                //{
                //    Session["authpa"] = "%" + Session["auth_pa"] + "%";
                //    Session["authpsa"] = "%" + Session["auth_psa"] + "%";
                //}
                //else
                //{
                //    Session["authpa"] = "%";
                //    Session["authpsa"] = "%";
                //}

                rcb_status.SelectedValue = "%";
                //  string authpa = Session["auth_pa"].ToString();
                //  string authpsa = Session["auth_psa"].ToString();
                dt_pa.Clear();
                dt_psa.Clear();
                dt_emp.Clear();
                SqlCommand cmd_getpa = null;


                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        if (Session["role"].ToString() == "S")
                            cmd_getpa = new SqlCommand("SELECT top 1 '%' as PA,'  All' as PROJECT FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all  SELECT distinct [PA], [PROJECT] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") and PA <>'' and PROJECT <> '' order by PROJECT ", con);
                        else
                            cmd_getpa = new SqlCommand("SELECT top 1 '%' as PA,'  All' as PROJECT FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all  SELECT distinct [PA], [PROJECT] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where  PA <>'' and PROJECT <> '' order by PROJECT  ", con);
                        //cmd_getpa.Parameters.Add("@auth_pa", SqlDbType.VarChar).Value = Session["auth_pa"].ToString(); 
                        SqlDataAdapter ad_pa = new SqlDataAdapter();
                        ad_pa.SelectCommand = cmd_getpa;
                        ad_pa.Fill(dt_pa);
                        rcb_pa.DataSource = dt_pa;
                        rcb_pa.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        con.Close();
                        fndisplay(ex.Message);
                    }
                    con.Close();
                }

            }
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
                    if (Session["role"].ToString() == "S")
                        cmd_getrep = new SqlCommand("SP_GENERAL_REPORT2", con);
                    else
                        cmd_getrep = new SqlCommand("SP_GENERAL_REPORT1", con);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    dt.Clear();
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
                        //if (Session["role"].ToString()=="A")
                        cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = "%";
                        // else
                        //      cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = Session["authpa"].ToString();
                    }
                    else
                    {
                        cmd_getrep.Parameters.Add("@PA", SqlDbType.VarChar).Value = rcb_pa.SelectedValue;
                    }
                    if (rcb_psa.SelectedValue == "" || rcb_psa.SelectedItem.Text == "  All")
                    {
                        //  if (Session["role"].ToString() == "A")
                        cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = "%";
                        //   else
                        //       cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = Session["authpsa"].ToString();
                    }
                    else
                    {
                        cmd_getrep.Parameters.Add("@PSA", SqlDbType.VarChar).Value = rcb_psa.SelectedValue;
                    }
                    cmd_getrep.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "" + rcb_status.SelectedValue;
                    cmd_getrep.Parameters.Add("@HOLDINGDT", SqlDbType.VarChar).Value = rcb_hlddt.SelectedValue.ToString();
                    cmd_getrep.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = Session["role"].ToString();
                    cmd_getrep.Parameters.Add("@EMP", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //}
                    //}

                    ad.SelectCommand = cmd_getrep;
                    ad.Fill(dt);


                    //       dt.Load(cmd_getrep.ExecuteReader());
                    RadGrid1.DataSource = dt;
                    //RadGrid1.DataBind();
                    con.Close();
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


                //  SqlDataSource_EMP.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                //  SqlDataSource_EMP.SelectParameters[1].DefaultValue = rcb_psa.SelectedValue.ToString();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        SqlCommand cmd_getemp = null;

                        if (rcb_pa.SelectedItem.Text == "  All" && rcb_psa.SelectedItem.Text == "  All")
                        {

                            if (Session["role"].ToString() == "S")
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") order by empname", con);
                            else
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  order by empname", con);
                        }
                        if (rcb_pa.SelectedItem.Text != "  All" && rcb_psa.SelectedItem.Text == "  All")
                        {
                            if (Session["role"].ToString() == "S")
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PA='" + rcb_pa.SelectedValue + "' order by empname", con);
                            else
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PA='" + rcb_pa.SelectedValue + "' order by empname", con);
                        }
                        if (rcb_pa.SelectedItem.Text == "  All" && rcb_psa.SelectedItem.Text != "  All")
                        {
                            if (Session["role"].ToString() == "S")
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PSA='" + rcb_psa.SelectedValue + "' order by empname", con);
                            else
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PSA='" + rcb_psa.SelectedValue + "' order by empname", con);
                        }
                        if (rcb_pa.SelectedItem.Text != "  All" && rcb_psa.SelectedItem.Text != "  All")
                        {
                            if (Session["role"].ToString() == "S")
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PA='" + rcb_pa.SelectedValue + "' and PSA='" + rcb_psa.SelectedValue + "' order by empname", con);
                            else
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PA='" + rcb_pa.SelectedValue + "' and PSA='" + rcb_psa.SelectedValue + "' order by empname", con);
                        }
                        SqlDataAdapter ad_emp = new SqlDataAdapter();
                        ad_emp.SelectCommand = cmd_getemp;
                        ad_emp.Fill(dt_emp);
                        rcb_empno.DataSource = dt_emp;
                        rcb_empno.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        con.Close();
                        fndisplay(ex.Message);
                    }
                    con.Close();
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
                //SqlDataSource_EMP.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                //SqlDataSource_EMP.SelectParameters[1].DefaultValue = "%";



                if (rcb_pa.SelectedItem.Text == "  All")
                {
                    //if (Session["role"].ToString()=="S")
                    //SqlDataSource_PSA.SelectCommand = "SELECT top 1 '%' as PSA,'  All' as Location FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where psa in (" + Session["auth_psa"] + ") union all SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where psa in (" + Session["auth_psa"] + ") and PSA <> '' and LOCATION <> '' order by location ";
                    //else
                    //    SqlDataSource_PSA.SelectCommand = "SELECT top 1 '%' as PSA,'  All' as Location FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where  PSA <> '' and LOCATION <> '' order by location ";


                    //SqlDataSource_PSA.DataBind();
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }
                            SqlCommand cmd_getpsa = null;
                            if (Session["role"].ToString() == "S")
                                cmd_getpsa = new SqlCommand("SELECT top 1 '%' as PSA,'  All' as Location FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") and PSA <> '' and LOCATION <> '' order by location ", con);
                            else
                                cmd_getpsa = new SqlCommand("SELECT top 1 '%' as PSA,'  All' as Location FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where  PSA <> '' and LOCATION <> '' order by location ", con);

                            SqlDataAdapter ad_psa = new SqlDataAdapter();
                            ad_psa.SelectCommand = cmd_getpsa;
                            ad_psa.Fill(dt_psa);
                            rcb_psa.DataSource = dt_psa;
                            rcb_psa.DataBind();
                        }
                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            con.Close();
                            fndisplay(ex.Message);
                        }
                        con.Close();
                    }

                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }
                            SqlCommand cmd_getemp = null;
                            if (Session["role"].ToString() == "S")
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") order by empname", con);
                            else
                                cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  order by empname", con);
                            SqlDataAdapter ad_emp = new SqlDataAdapter();
                            ad_emp.SelectCommand = cmd_getemp;
                            ad_emp.Fill(dt_emp);
                            rcb_empno.DataSource = dt_emp;
                            rcb_empno.DataBind();
                        }
                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            con.Close();
                            fndisplay(ex.Message);
                        }
                        con.Close();
                    }
                    rcb_psa.SelectedValue = "%";
                    rcb_empno.SelectedValue = "%";
                    rcb_psa.Focus();
                    // bind_grid();
                    TxtMultiEmp.Text = "";
                    // SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  order by empname";
                    //  else
                    //       SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where pa in (" + Session["auth_pa"] + ") order by empname";
                    // SqlDataSource_EMP.DataBind();
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
                            SqlCommand cmd_getpsa = null;
                            cmd_getpsa = new SqlCommand("SELECT top 1 '%' as PSA,'  All' as Location FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  union all SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where  PSA <> '' and LOCATION <> '' and PA='" + rcb_pa.SelectedValue + "' order by location ", con);
                            SqlDataAdapter ad_psa = new SqlDataAdapter();
                            ad_psa.SelectCommand = cmd_getpsa;
                            ad_psa.Fill(dt_psa);
                            rcb_psa.DataSource = dt_psa;
                            rcb_psa.DataBind();
                        }
                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            con.Close();
                            fndisplay(ex.Message);
                        }
                        con.Close();
                    }
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }
                            SqlCommand cmd_getemp = null;
                            cmd_getemp = new SqlCommand("SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  WHERE PA = '" + rcb_pa.SelectedValue + "' order by empname", con);
                            SqlDataAdapter ad_emp = new SqlDataAdapter();
                            ad_emp.SelectCommand = cmd_getemp;
                            ad_emp.Fill(dt_emp);
                            rcb_empno.DataSource = dt_emp;
                            rcb_empno.DataBind();
                        }
                        catch (Exception ex)
                        {
                            //Handle exception, perhaps log it and do the needful
                            con.Close();
                            fndisplay(ex.Message);
                        }
                        con.Close();
                    }
                    //SqlDataSource_EMP.SelectCommand = "SELECT top 1 '%' as PERNR,'   All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] union all SELECT [PERNR], RIGHT([PERNR],6)+' / '+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]  WHERE PA = @PA order by empname";
                    //SqlDataSource_EMP.DataBind();


                    // SqlDataSource_PSA.SelectParameters[0].DefaultValue = rcb_pa.SelectedValue.ToString();
                }

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
            RadGrid1.MasterTableView.FilterExpression = string.Empty;

            foreach (GridColumn column in RadGrid1.MasterTableView.RenderColumns)
            {
                if (column is GridBoundColumn)
                {
                    GridBoundColumn boundColumn = column as GridBoundColumn;
                    boundColumn.CurrentFilterValue = string.Empty;
                }
            }
            //this.
            //this.startDate = null;
            //this.endDate = null;

            //this.startSlider = 0;
            //this.endSlider = 1010;

            RadGrid1.MasterTableView.Rebind();

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
            if (l_status == "Saved")
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
            //Response.Redirect("~/REPORTS/REPORT_SAVED_HOLDINGS.aspx?pernr="+l_pernr+" target=_blank");
            else if (l_status == "Submitted")
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + "','_newtab');", true);
            //Response.Redirect("~/REPORTS/REPORT_SUBMITTED_HOLDINGS.aspx?pernr=" + l_pernr + " target=_blank");
            //}
        }

        protected void rcb_status_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid1.Rebind();
        }

        protected void TxtMultiEmp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}