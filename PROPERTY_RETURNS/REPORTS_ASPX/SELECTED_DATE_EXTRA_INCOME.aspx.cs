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
            RG_TRN.DataSource = null;
         
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
                    DateTime sdate = Convert.ToDateTime(DDL_Date.SelectedValue);
                    string DD = DateString[2] + "-" + DateString[1] + "-" + DateString[0];
                    dt.Clear();
                    cmd_gettrn = new SqlCommand("SP_MY_RETURN123", con);
                    cmd_gettrn.CommandType = CommandType.StoredProcedure;
                    cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //  cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(DD).ToString("yyyy");
                    // cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "EX_HO_SV";
                    cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = sdate.ToString("MM-dd-yyyy");
                    cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "EX_HO_SG";
                    //cmd_gettrn.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                    //cmd_gettrn.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = l_type;
                    // cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("MM-dd-yyyy");
                    // cmd_gettrn.Parameters.Add("@holdingdt", SqlDbType.VarChar).Value = Convert.ToDateTime(rdp_hlddt.SelectedDate).ToString("yyyy");
                    //cmd_gettrn.Parameters.Add("@Dt", SqlDbType.VarChar).Value = DDL_Date.SelectedValue.ToString() ;
                    ad.SelectCommand = cmd_gettrn;

                    ad.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        RG_TRN.DataSource = dt;
                        RG_TRN.DataBind();
                        fd_print.Visible = true;
                    }
                    else
                    {
                        RG_TRN.DataSource = null;
                        RG_TRN.DataBind();
                        // no_records_now = check_records();
                        //no_records_now = "Y";
                    }



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

        protected void RG_TRN_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string itemText = string.Empty;
            decimal itemValue = 0;
            decimal itemSumm = 0;
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                itemText = dataItem["TRNAMT"].Text;
                Decimal.TryParse(itemText, out itemValue);
                itemSumm += itemValue;
                lbltotinc1.Text = Convert.ToString(itemSumm);
            }
            else if (e.Item is GridEditFormItem)
            {
                GridEditFormItem editItem = e.Item as GridEditFormItem;
            }
        }
    }
}