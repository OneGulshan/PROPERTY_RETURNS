using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Configuration;
using Telerik;
using Microsoft.VisualBasic;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Threading;
using System.IO;
namespace PROPERTY_RETURNS
{
    public partial class HOME_PAGE_NEW : System.Web.UI.Page
    {
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        public string Method = "post";
        public string FormName = "form1";
        public string Url = "";
        string period_from = "";
        string period_to = "";
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string newLine = System.Environment.NewLine;
            if (Session["getDate"] == null)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "helloFromCodeBehind()", true);
                //ScriptManager.RegisterStartupScript(Me, Me.GetType(), "strScript", "alert('Too large " + message + "files.\nFile size should be less than 500KB.\nPlease select file of appropriate size.');", True);
                Response.Redirect("~/dateSelection.aspx");
            }
            if (!IsPostBack)
            {

                //RadioButton10.Controls.Add(new LiteralControl("<br />"));
                
                RadioButton10.Text = RadioButton10.Text + "\n" + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                
               // RadioButton11.Text = RadioButton11.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton1.Text = RadioButton1.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton3.Text = RadioButton3.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                //RadioButton4.Text = RadioButton4.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                //RadioButton4.Text = RadioButton4.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton5.Text = RadioButton5.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton6.Text = RadioButton6.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton7.Text = RadioButton7.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton8.Text = RadioButton8.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                RadioButton9.Text = RadioButton9.Text + " as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                lblhld.Text = lblhld.Text + " for Property Return as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                lbltrn.Text = lbltrn.Text + " for Property Return as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");
                lblhldtrn.Text = lblhldtrn.Text + " for Property Return as on " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy");

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        DateTime hld_dt = Convert.ToDateTime(Session["getDate"].ToString());
                        SqlCommand cmd_getst = null;
                        cmd_getst = new SqlCommand("select * from M_CUTOFFDATE where  holdingdt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' ", con);
                        DataTable dt_for = new DataTable();
                        SqlDataAdapter ad_for = new SqlDataAdapter();
                        ad_for.SelectCommand = cmd_getst;
                        ad_for.Fill(dt_for);

                        if (dt_for.Rows.Count > 0)
                        {
                            period_from = dt_for.Rows[0]["TRNSTARTDT"].ToString();
                            period_to = dt_for.Rows[0]["TRNENDDT"].ToString();
                        }
                        Session["period_from"] = period_from;
                        Session["period_to"] = period_to;

                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }

                chk_holding();
            }
        }

        protected void RadioButton10_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/DEPENDENTFORM1/DEPENDENTFORM1_ENTRY.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                Response.Redirect("~/DEPENDENTFORM1/DEPENDENTFORM1_ENTRY.aspx");
            }
        }

        protected void ExtraIncome_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
               // Response.Redirect("~/TRANSACTION/TRANSACTION.aspx");
                Response.Redirect("~/REPORTS_ASPX/SELECTED_DATE_EXTRA_INCOME.aspx");
            }
        }
        protected void RadioButton5_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/TRANSACTION/TRANSACTION.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                Response.Redirect("~/TRANSACTION/TRANSACTION.aspx");
            }
        }

        protected void chk_holding()
        {
            string holdingdtnext = "";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    SqlCommand cmd_getst = null;
                    //cmd_getst = new SqlCommand("select status from T_PROPRETURNS where trndt='" + Session["getDate"].ToString() + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                    cmd_getst = new SqlCommand("select status from T_PROPRETURNS where status <> 'RJ' and trndt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                    DataTable dt_for = new DataTable();
                    SqlDataAdapter ad_for = new SqlDataAdapter();
                    ad_for.SelectCommand = cmd_getst;
                    ad_for.Fill(dt_for);

                    if (dt_for.Rows.Count > 0)
                    {
                        String Status_HV = "";
                        String Status_HG = "";
                        String Status_SV = "";

                        DataView view = new DataView(dt_for);
                        DataTable distinctValues = view.ToTable(true, "status");

                        foreach (DataRow row in distinctValues.Rows)
                        {
                            if (row["status"].ToString() == "HV")
                            {
                                Status_HV = "Y";
                            }
                            if (row["status"].ToString() == "HG")
                            {
                                Status_HG = "Y";
                            }
                            if (row["status"].ToString() == "SV")
                            {
                                Status_SV = "Y";
                            }
                            //if (row["status"].ToString() == "RJ")
                            //{
                            //    Status_HV = "Y";
                            //}
                        }

                        if (Status_HG == "Y")
                        {
                            //RadioButton10.Enabled = false;
                            //RadioButton11.Enabled = false;
                            //RadioButton1.Enabled = false;
                            ////RadioButton2.Enabled = false;
                            //RadioButton3.Enabled = false;
                            //RadioButton4.Enabled = true;
                            ////Commented By Manjeet
                            ////RadioButton5.Enabled = true;
                            ////RadioButton6.Enabled = true;
                            //// End Comment
                            //RadioButton7.Enabled = true;
                            //RadioButton8.Enabled = true;
                            //RadioButton9.Enabled = true;

                            cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been submitted.";
                        }
                        else if (Status_HV == "Y")
                        {
                            //RadioButton10.Enabled = true;
                            //RadioButton11.Enabled = true;
                            //RadioButton1.Enabled = true;
                            ////RadioButton2.Enabled = true;
                            //RadioButton3.Enabled = true;
                            //RadioButton4.Enabled = true;

                            //RadioButton5.Enabled = false;
                            //RadioButton6.Enabled = false;
                            //RadioButton7.Enabled = false;
                            //RadioButton8.Enabled = false;
                            //RadioButton9.Enabled = false;

                            cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been draft saved only.";
                        }
                        else if (Status_SV == "Y")
                        {
                            //RadioButton10.Enabled = false;
                            //RadioButton11.Enabled = false;
                            //RadioButton1.Enabled = false;
                            ////RadioButton2.Enabled = false;
                            //RadioButton3.Enabled = false;
                            //RadioButton4.Enabled = true;

                            //RadioButton5.Enabled = true;
                            //RadioButton6.Enabled = true;
                            //RadioButton7.Enabled = true;
                            //RadioButton8.Enabled = true;
                            //RadioButton9.Enabled = true;

                            cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " have been submitted. Some transactions also entered";
                        }
                    }
                    else
                    {

                        //RadioButton10.Enabled = true;
                        //RadioButton11.Enabled = true;
                        //RadioButton1.Enabled = true;
                        ////RadioButton2.Enabled = true;
                        //RadioButton3.Enabled = true;
                        //RadioButton4.Enabled = true;

                        //RadioButton5.Enabled = false;
                        //RadioButton6.Enabled = false;
                        //RadioButton7.Enabled = false;
                        //RadioButton8.Enabled = false;
                        //RadioButton9.Enabled = false;
                        cstatus.Text = "Holdings for holding date : " + Convert.ToDateTime(Session["getDate"]).ToString("dd/MM/yyyy") + " are not entered yet.";
                    }
                    RadioButton10.Enabled = true;
                    //RadioButton11.Enabled = true;
                    RadioButton1.Enabled = true;
                    //RadioButton2.Enabled = true;
                    RadioButton3.Enabled = true;
                    RadioButton4.Enabled = true;

                    RadioButton5.Enabled = false;
                    RadioButton6.Enabled = false;
                    RadioButton7.Enabled = false;
                    RadioButton8.Enabled = false;
                    RadioButton9.Enabled = false;

                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }

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

                    SqlCommand cmd_getst = null;
                    cmd_getst = new SqlCommand("SELECT Top 1 holdingdt FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt > '" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "' order by holdingdt", con);
                    DataTable dt_for1 = new DataTable();
                    SqlDataAdapter ad_for = new SqlDataAdapter();
                    ad_for.SelectCommand = cmd_getst;
                    ad_for.Fill(dt_for1);

                    if (dt_for1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt_for1.Rows)
                        {
                            holdingdtnext = row["holdingdt"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

            if (holdingdtnext != null && holdingdtnext != "")
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

                        SqlCommand cmd_getst = null;
                        //lblhld.Text = holdingdtnext;
                        cmd_getst = new SqlCommand("select status from T_PROPRETURNS where status <> 'RJ' and trndt='" + Convert.ToDateTime(holdingdtnext).ToString("MM-dd-yyyy") + "' and pernr='" + Session["emp"].ToString() + "' order by status", con);
                        DataTable dt_for2 = new DataTable();
                        SqlDataAdapter ad_for = new SqlDataAdapter();
                        ad_for.SelectCommand = cmd_getst;
                        ad_for.Fill(dt_for2);

                        if (dt_for2.Rows.Count > 0)
                        {

                            RadioButton5.Enabled = false;
                            RadioButton6.Enabled = false;
                            RadioButton7.Enabled = false;
                            RadioButton8.Enabled = false;
                            // RadioButton9.Enabled = true;
                            cstatus.Text = "Holdings for next holding date : " + Convert.ToDateTime(holdingdtnext).ToString("dd/MM/yyyy") + " had been entered, so no transactions can be entered.";
                        }
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
            }

        }
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }

        protected void RadioButton1_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                Response.Redirect("~/HOLDING/HOLDING.aspx");
            }
        }

        //protected void RadioButton11_Click(object sender, EventArgs e)
        //{
        //    if (Session["getDate"].ToString() == "")
        //    {
        //        lblerr.Text = "Kindly select Holding Date";
        //    }
        //    else
        //    {
        //        lblerr.Text = "";
        //        //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
        //        //myremotepost.Url = "/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SAVED_HOLDINGS.aspx";
        //        //myremotepost.Add("holdingdt", Session["getDate"].ToString());
        //        ////myremotepost.Post();
        //        Response.Redirect("~/REPORTS_ASPX/PRINTALL_SAVED_HOLDINGS.aspx");
        //    }
        //}

        protected void RadioButton3_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/REPORTS_ASPX/SUBMIT_SAVED_HOLDINGS.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                Response.Redirect("~/REPORTS_ASPX/SUBMIT_SAVED_HOLDINGS.aspx");
            }
        }

        protected void RadioButton4_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SUBMITTED_HOLDINGS.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                //Response.Redirect("~/REPORTS_ASPX/PRINTALL_SUBMITTED_HOLDINGS.aspx"); // Code commented by Saurabh Sangat on 21.03.2022 . Now this will redirect to date selection page
                Response.Redirect("~/REPORTS/MYRETURNS.aspx");
            }
        }

        protected void RadioButton6_Click(object sender, EventArgs e)
        {
            if (Session["getDate"].ToString() == "")
            {
                lblerr.Text = "Kindly select Holding Date";
            }
            else
            {
                lblerr.Text = "";
                //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
                //myremotepost.Url = "/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SAVED_TRNS.aspx";
                //myremotepost.Add("holdingdt", Session["getDate"].ToString());
                //myremotepost.Post();
                Response.Redirect("~/REPORTS_ASPX/PRINTALL_SAVED_TRNS.aspx");
            }
        }

        public void Post()
        {
            System.Web.HttpContext.Current.Response.Clear();

            System.Web.HttpContext.Current.Response.Write("<html><head>");

            System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));

            System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));

            for (int i = 0; i < Inputs.Keys.Count; i++)
            {

                System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\" size=\"0\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                string abc = Inputs[Inputs.Keys[i]];

            }
            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body></html>");
            System.Web.HttpContext.Current.Response.End();
        }
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
        }

        protected void RadioButton9_Click(object sender, EventArgs e)
        {
            lblerr.Text = "";
            //HOME_PAGE_NEW myremotepost = new HOME_PAGE_NEW();
            //myremotepost.Url = "/PROPERTY_RETURNS/REPORTS_ASPX/PRINTALL_SAVED_TRNS.aspx";
            //myremotepost.Add("holdingdt", Session["getDate"].ToString());
            //myremotepost.Post();
            Response.Redirect("~/REPORTS_ASPX/PRINTALL_HOLDINDS_TRNS_BOTH.aspx");
        }
        protected void Session_End(Object sender, EventArgs E)
        {
            using (SqlConnection con1 = new SqlConnection(conn))
            {
                try
                {
                    SqlCommand cmd_upd = null;

                    if (con1.State != ConnectionState.Open)
                    {
                        con1.Close();
                        con1.Open();
                    }


                    cmd_upd = new SqlCommand("SP_UPDATE_LOGINS", con1);

                    cmd_upd.CommandType = CommandType.StoredProcedure;
                    cmd_upd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = Session["uid"];

                    cmd_upd.ExecuteNonQuery();
                    //Response.Redirect(Request.RawUrl);

                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    //fndisplay(ex.Message);
                }
                con1.Close();
            }
            Session["user"] = "";
            Session["uid"] = "";
            Session["sid"] = "";
            Session.RemoveAll();
            Response.Redirect("~/Account/Login.aspx", false);
        }

    }
}