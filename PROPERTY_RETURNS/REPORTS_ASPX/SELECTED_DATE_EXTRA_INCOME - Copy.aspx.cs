using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;



using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;


namespace PROPERTY_RETURNS.REPORTS_ASPX
{
    public partial class SELECTED_DATE_EXTRA_INCOME : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void fndisplay(string msg)
        {
            lblerr.Text = msg;
        }
        protected void submit_Click(object sender, EventArgs e)
        {

            BindGrid();
        }
        protected void BindGrid()
        {
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd_gettrn = new SqlCommand();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    string str = DDL_Date.SelectedItem.Text;
                    string[] DateString = str.Split('/');

                    string DD = DateString[2] + "-" + DateString[1] + "-" + DateString[0];

                    cmd_gettrn = new SqlCommand("SP_MY_RETURNS11", con);
                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    cmd_gettrn.Parameters.Add("@holding_dt", SqlDbType.VarChar).Value = Convert.ToDateTime(DD).ToString("yyyy-MM-dd");
                    cmd_gettrn.Parameters.Add("@year", SqlDbType.VarChar).Value = DateString[2];
                    //cmd_gettrn.Parameters.Add("@Dt", SqlDbType.VarChar).Value = DDL_Date.SelectedValue.ToString() ;
                    ad.SelectCommand = cmd_gettrn;

                    ad.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    //}
                    //con.Close();
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }
    }
}