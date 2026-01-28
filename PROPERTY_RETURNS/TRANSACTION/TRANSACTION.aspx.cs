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

namespace PROPERTY_RETURNS
{
    public partial class TRANSACTION : System.Web.UI.Page
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
                Session["action_t"] = "ADD_NEW_TRANSACTION";
                lblhlddt.Text = "Enter Transaction Details for Holding Date : " + Convert.ToDateTime(Session["getDate"].ToString()).ToString("dd/MM/yyyy");
                lblhlddt_hidden.Text = Convert.ToDateTime(Session["getDate"].ToString()).ToString();
            }


            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);

            SqlCommand cmd_gettrn = null;
            SqlCommand chk_submit = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    //SqlDataAdapter ad = new SqlDataAdapter();

                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_FOR_REPORT", con);
                    //dt_check.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IM_HO_SG";
                    //ad.SelectCommand = chk_submit;
                    //ad.Fill(dt_check);
                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_LI_FOR_REPORT", con);
                    //dt_check_li.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "LI_HO_SG";
                    //ad.SelectCommand = chk_submit;
                    //ad.Fill(dt_check_li);
                    //chk_submit = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE_MO", con);
                    //dt_check_mo.Clear();
                    //chk_submit.CommandType = CommandType.StoredProcedure;
                    //chk_submit.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //chk_submit.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "MO_HO_SG";
                    //chk_submit.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = lblhlddt_hidden.Text;
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
                    //    hpr1.NavigateUrl = "/PROPERTY_RETURNS/HOME_PAGE.aspx";
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
        protected void fndisplay(string msg)
        {
            lblcatch.Text = msg;
        }
    }
}