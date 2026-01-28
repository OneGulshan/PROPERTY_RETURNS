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

using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;
using System.Globalization;
namespace PROPERTY_RETURNS.HOLDING
{
    public partial class HOLDING : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        DataTable dt_dep = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt_check = new DataTable();
        DataTable dt_check_li = new DataTable();
        DataTable dt_check_mo = new DataTable();
        public DataTable dt_hdt = new DataTable();
        DateTime holddt = System.DateTime.Now;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["action_t"] = "ADD_NEW_HOLDING";
                    lblhlddt.Text = "Enter Holding Details for Holding Date : " + Convert.ToDateTime(Session["getDate"].ToString()).ToString("dd/MM/yyyy");
                    lblhlddt_hidden.Text = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
                    //Response.Redirect("~/Account/Login.aspx", false); 

                }
                catch{
                    Response.Redirect("~/Account/Login.aspx", false); 
                }
            }


            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);

            SqlCommand cmd_gettrn = null;
            SqlCommand chk_submit = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    carryforward_rev();
               //     populatesapdata();
                    //if (con.State != ConnectionState.Open)
                    //{
                    //    con.Close();
                    //    con.Open();
                    //}
                    //SqlDataAdapter ad = new SqlDataAdapter();

                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FOR_REPORT", con);
                    //dt_check.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_HO_SG";
                    //chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"].ToString()).ToString("MM-dd-yyyy");
                    //ad.SelectCommand = chk_submit;
                    //ad.Fill(dt_check);
                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI_FOR_REPORT", con);
                    //dt_check_li.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    //chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"].ToString()).ToString("MM-dd-yyyy");
                    //ad.SelectCommand = chk_submit;
                    //ad.Fill(dt_check_li);
                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
                    //dt_check_mo.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
                    //chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(Session["getDate"].ToString()).ToString("MM-dd-yyyy");
                    //ad.SelectCommand = chk_submit;
                    //ad.Fill(dt_check_mo);

                    //if (dt_check.Rows.Count > 0 || dt_check_li.Rows.Count > 0 || dt_check_mo.Rows.Count > 0)
                    //{
                    //    RadTabStrip1.Visible = false;
                    //    RadMultiPage1.Visible = false;
                    //    Label lb_info = new Label();
                    //    lb_info.ForeColor = System.Drawing.Color.Red;
                    //    HyperLink hpr1 = new HyperLink();
                    //    hpr1.Text = "Go back to home page";
                    //    hpr1.NavigateUrl = "/PROPERTY_RETURNS/HOME_PAGE_NEW.aspx";
                    //    lb_info.Text = "Holdings are already submitted. You can not submit further for this period.";
                    //    print_panel.Controls.Add(new LiteralControl("<br><br><br>"));
                    //    print_panel.Controls.Add(lb_info);
                    //    print_panel.Controls.Add(new LiteralControl("<br><br><br>"));
                    //    print_panel.Controls.Add(hpr1);
                    //}

                    if (Session["tab"] == null)
                    {
                        RadTabStrip1.MultiPage.SelectedIndex = 0;
                        RadTabStrip1.SelectedIndex = 0;
                    }
                    else
                    {
                        RadTabStrip1.MultiPage.SelectedIndex = Convert.ToInt32(Session["tab"].ToString());
                        RadTabStrip1.SelectedIndex = Convert.ToInt32(Session["tab"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            //con.Close();
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            Session["tab"] = RadTabStrip1.MultiPage.SelectedIndex.ToString();

            RadTabStrip1.MultiPage.SelectedIndex = Convert.ToInt32(Session["tab"].ToString());
            RadTabStrip1.SelectedIndex = Convert.ToInt32(Session["tab"].ToString());

        }
        protected void carryforward_rev()
        {
            int p = 0;
            //foreach (GridDataItem dataItem in RG_TRN.Items)
            //{
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_inttrn = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }


                    cmd_inttrn = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE_CARRY", con);

                    cmd_inttrn.CommandType = CommandType.StoredProcedure;
                    cmd_inttrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value =  Convert.ToDateTime(holdingdtpre).ToString("yyyy-MM-dd");
                  //  cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.VarChar).Value = Convert.ToDateTime(holdingdtpre).ToString("MM-dd-yyyy");
                    cmd_inttrn.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Session["getDate"];
                    p = cmd_inttrn.ExecuteNonQuery();
                    //Response.Redirect(Request.RawUrl);

                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            //  }

            //HLD_IMMOVABLE myremotepost = new HLD_IMMOVABLE();
            //myremotepost.Url = "/PROPERTY_RETURNS/HOLDING/HOLDING.aspx";
            //myremotepost.Add("holdingdt", rdp_hlddt.SelectedDate.ToString());
            //myremotepost.Post();
            //con.Close();
            //if (p == 1)
            //{
            // bind_grid();
            //}
        }
        protected void populatesapdata()
        {
            int sap = 0;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd_inssap = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }


                    cmd_inssap = new SqlCommand("SP_INSERT_TRANSACTION_EMPLOYEE_SAP", con);

                    cmd_inssap.CommandType = CommandType.StoredProcedure;


                    cmd_inssap.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //    cmd_inssap.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = l_type;
                    //cmd_inssap.Parameters.Add("@TRNDT", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("yyyy-MM-dd");

                    //  cmd_inssap.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["empno"];
                      cmd_inssap.Parameters.Add("@TRNDT", SqlDbType.DateTime).Value = Session["getDate"];

                    //-----------------Code Ends----------------------------


                    sap = cmd_inssap.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }

        }
        protected void Session_End(Object sender, EventArgs E)
        {
            using (SqlConnection con1 = new SqlConnection(ConnectionString))
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
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }
    }
}