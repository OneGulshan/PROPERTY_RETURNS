using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace PROPERTY_RETURNS.DEPENDENTFORM1
{
    public partial class DEPENDENTFORM1_ENTRY : System.Web.UI.Page
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        public DataTable dt_dep = new DataTable();
        public DataTable dt_hdt = new DataTable();
        public DateTime hld_dt;
        GLB_FNS obj_gl = new GLB_FNS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                dt_dep.Clear();
                dt_hdt.Clear();

                //SqlConnection con = null;
                //con = new SqlConnection(ConnectionString);
                //FunctionConnect.ConnectionOpen();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }

                        //SqlCommand cmd_gethdt = null;
                        //cmd_gethdt = new SqlCommand("SP_GET_TRANSACTION_EMPLOYEE", con);
                        //cmd_gethdt.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        //cmd_gethdt.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "DT_HO";
                        //SqlDataAdapter ad_hdt = new SqlDataAdapter();
                        //cmd_gethdt.CommandType = CommandType.StoredProcedure;
                        //ad_hdt.SelectCommand = cmd_gethdt;
                        //ad_hdt.Fill(dt_hdt);

                        //if (dt_hdt.Rows.Count > 0)
                        //{
                        //    hld_dt = Convert.ToDateTime(dt_hdt.Rows[0].Field<DateTime>("HOLDINGDT").ToString());
                        //}

                        hld_dt = Convert.ToDateTime(Session["getDate"].ToString());
                        Label2.Text = "Enter Form1 Details for Holding Date : " + hld_dt.ToString("dd/MM/yyyy");
                        lblhlddt_hidden.Text = hld_dt.ToString();
                        SqlCommand cmd_getdep = null;
                        cmd_getdep = new SqlCommand("SP_GET_DEPENDENTS", con);
                        cmd_getdep.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = Session["emp"].ToString();
                        SqlDataAdapter ad_dep = new SqlDataAdapter();
                        cmd_getdep.CommandType = CommandType.StoredProcedure;
                        ad_dep.SelectCommand = cmd_getdep;
                        ad_dep.Fill(dt_dep);

                        //FunctionConnect.ConnectionClose();
                        //con.Close();

                        RadGrid1.DataSource = dt_dep;
                        RadGrid1.DataBind();
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
                        //FunctionConnect.ConnectionOpen();
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                            dt.Clear();
                            string PERNR = item["PERNR"].Text.Replace("&nbsp;", "");
                            string SUBTY = item["SUBTY"].Text.Replace("&nbsp;", "");
                            string OBJPS = item["OBJPS"].Text.Replace("&nbsp;", "");
                            //Response.Write(hld_dt);

                            SqlCommand chk_form1 = null;
                            chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and subty='" + SUBTY + "' and objps='" + OBJPS + "' and holdingdt='" + Convert.ToDateTime(Session["getDate"]).ToString("MM-dd-yyyy") + "'", con);
                            //chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and subty='" + SUBTY + "' and objps='" + OBJPS + "' and holdingdt= '" + hld_dt + "' ", con);

                            SqlDataAdapter ad = new SqlDataAdapter();
                            ad.SelectCommand = chk_form1;
                            ad.Fill(dt);

                            // CheckBox chk = (CheckBox)item["DEP"].Controls[0];
                            //((RadComboBox)item["DEP"].FindControl("dd_DEP")).SelectedValue = dt.Rows[0][6].ToString();
                            DropDownList dd_dep = (DropDownList)item["DEP"].FindControl("dd_DEP");
                            dd_dep.SelectedItem.Text = "YES";
                           

                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0][6].ToString() == "RJ")
                                {
                                    //chk.Checked = false;
                                 //   ((DropDownList)item["DEP"].FindControl("dd_DEP")).Enabled = false;
                                    dd_dep.SelectedItem.Text = "NO";
                                    // ((RadComboBox)item["DEP"].FindControl("dd_DEP")).SelectedItem.Text = "NO";
                                }
                                else
                                {
                                    // chk.Checked = true;
                                    ((DropDownList)item["DEP"].FindControl("dd_DEP")).Enabled = true;
                                    //((RadComboBox)item["DEP"].FindControl("dd_DEP")).SelectedItem. = "YES";
                                }
                                ((TextBox)item["PPOSITION"].FindControl("tb_pp")).Text = dt.Rows[0][4].ToString();
                                ((DropDownList )item["RETURN"].FindControl("DropDownList1")).SelectedValue = dt.Rows[0][5].ToString();

                                //((DropDownList)item["DEP"].FindControl("dd_DEP")).SelectedValue = dt.Rows[0][6].ToString();

                                string status = dt.Rows[0][6].ToString();
                                if (status == "SG") //if (status == "SG")
                                {
                                    Button1.Enabled = false;
                                    //Button2.Visible = false;
                                    foreach (GridDataItem item1 in RadGrid1.Items)
                                    {
                                        ((TextBox)item1["PPOSITION"].FindControl("tb_pp")).Enabled = false;
                                        ((DropDownList)item1["RETURN"].FindControl("DropDownList1")).Enabled = false;

                                        ((DropDownList)item["DEP"].FindControl("dd_DEP")).Enabled = false;

                                        //CheckBox cb_dep = (CheckBox)item1["DEP"].Controls[0];
                                        //cb_dep.Enabled = false;
                                    }

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Handle exception, perhaps log it and do the needful
                        fndisplay(ex.Message);
                    }
                }
                //FunctionConnect.ConnectionClose();
                //con.Close();
            }
        }

        protected void RadGridPrescriber_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                GridDataItem ditem = (GridDataItem)e.Item;


                //CheckBox cb_dep = (CheckBox)ditem["DEP"].Controls[0];
                // RadComboBox cb_dep = (RadComboBox)ditem["DEP"].Controls[0];

                //((RadComboBox)ditem["DEP"].FindControl("dd_DEP")).SelectedValue = dt.Rows[0][6].ToString();



                ////cb_dep.Checked = true;
                string rel = ditem["RELATION"].Text;

                if (rel == "SELF") // if (rel == "SELF" || rel == "SPOUSE")
                {

                    ((DropDownList)ditem["RETURN"].FindControl("DropDownList1")).Enabled = false;
                    ((DropDownList)ditem["RETURN"].FindControl("DropDownList1")).SelectedItem.Text = "YES";
                    
                    ((DropDownList)ditem["DEP"].FindControl("dd_DEP")).Enabled = false;
                    ((DropDownList)ditem["DEP"].FindControl("dd_DEP")).Visible = false;

                    ((DropDownList)ditem["DEP"].FindControl("dd_DEP")).SelectedItem.Text  = "YES";
                    


                }
                else
                {
                    ((DropDownList)ditem["DEP"].FindControl("dd_DEP")).Enabled = true;
                    ((DropDownList)ditem["DEP"].FindControl("dd_DEP")).Visible = true;
                    //((DropDownList)ditem["DEP"].FindControl("dd_DEP")).SelectedItem.Text = "NO";
                    //   cb_dep.Checked ; 
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            hld_dt = Convert.ToDateTime(Session["getDate"].ToString());
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            String ErrorTag = "";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    //FunctionConnect.ConnectionOpen();
                    SqlCommand chk_form1 = null;
                    chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and holdingdt='" + Convert.ToDateTime(Session["getDate"]).ToString("yyy-MM-dd") + "' ", con);
                    //chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and CONVERT(VARCHAR(10),holdingdt,105) = left('" + hld_dt + "',10) ", con);
                    //chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and holdingdt='" + hld_dt + "' ", con);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = chk_form1;
                    ad.Fill(dt);
                    //chk_form1.Dispose();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                            string PERNR = item["PERNR"].Text.Replace("&nbsp;", "");
                            string SUBTY = item["SUBTY"].Text.Replace("&nbsp;", "");
                            string OBJPS = item["OBJPS"].Text.Replace("&nbsp;", "");

                            string ppheld = ((TextBox)item["PPOSITION"].FindControl("tb_pp")).Text.Replace("&nbsp;", "");

                            DropDownList dd_return = (DropDownList)item["RETURN"].FindControl("DropDownList1");
                            DropDownList dd_dep = (DropDownList)item["DEP"].FindControl("dd_DEP");
                         //   dd_dep.SelectedItem.Text = "YES";
                            string return1 = dd_return.SelectedItem.Text;

                            //string return1 = ((DropDownList)item["RETURN"].FindControl("DropDownList1")).SelectedValue.Replace("&nbsp;", "");

                            string status = ((DropDownList)item["DEP"].FindControl("dd_DEP")).SelectedItem.Text;//string status = ((DropDownList)item["DEP"].FindControl("dd_DEP")).SelectedValue.Replace("&nbsp;", "");
                           
                            // CheckBox chk = (CheckBox)item["DEP"].Controls[0];
                            //Boolean chkd = chk.Checked;
                            if (ppheld == "")
                            {
                                ErrorTag = "E";
                                fndisplay("Public Position cannot be blank.Mention NA if not applicable");
                            }
                            else if (return1.Contains("Select"))
                            {
                                ErrorTag = "E";
                                fndisplay("Select return filed status");
                            }
                            else if (status.Contains("Select"))
                            {
                                ErrorTag = "E";
                                fndisplay("Select financially dependent status");
                            }
                            else
                            {
                                SqlCommand in_form1 = null;
                                in_form1 = new SqlCommand("SP_INSERT_FORM1", con);
                                in_form1.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = PERNR;
                                in_form1.Parameters.Add("@SUBTY", SqlDbType.VarChar).Value = SUBTY;
                                in_form1.Parameters.Add("@OBJPS", SqlDbType.VarChar).Value = OBJPS;
                                in_form1.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = hld_dt;
                                in_form1.Parameters.Add("@PPHELD", SqlDbType.VarChar).Value = ppheld;
                                in_form1.Parameters.Add("@RERUNFILED", SqlDbType.VarChar).Value = return1;

                                if (status == "YES")
                                {
                                    in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                }
                                else
                                {
                                    in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "RJ";
                                }


                                //if (chkd == true)
                                //{
                                //    in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                                //}
                                //else
                                //{
                                //    in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "RJ";
                                //}
                                in_form1.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                                in_form1.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                                in_form1.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "UP";
                                in_form1.CommandType = CommandType.StoredProcedure;

                                in_form1.ExecuteNonQuery();
                                ErrorTag = "S";
                               
                            }

                           

                        }
                        
                    }
                    else
                    {
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                            string PERNR = item["PERNR"].Text.Replace("&nbsp;", "");
                            string SUBTY = item["SUBTY"].Text.Replace("&nbsp;", "");
                            string OBJPS = item["OBJPS"].Text.Replace("&nbsp;", "");

                            TextBox tb_ppheld = (TextBox)item["PPOSITION"].FindControl("tb_pp");
                            string ppheld = tb_ppheld.Text.Replace("&nbsp;", "");

                            DropDownList dd_return = (DropDownList)item["RETURN"].FindControl("DropDownList1");
                            string return1 = dd_return.SelectedItem.Text;
                            //string return1 = dd_return.SelectedItem.Value.ToString().Replace("&nbsp;", "");
                            //
                            DropDownList dd_dep = (DropDownList)item["DEP"].FindControl("dd_DEP"); 
                            //DropDownList dd_DEP = (DropDownList)item["DEP"].FindControl("DropDownList1");
                           // string status = dd_DEP.SelectedItem.Value.ToString().Replace("&nbsp;", "");
                            string status = dd_dep.SelectedItem.Text;
                            // CheckBox chk = (CheckBox)item["DEP"].Controls[0];
                            // Boolean chkd = chk.Checked;

                            SqlCommand in_form1 = null;
                            in_form1 = new SqlCommand("SP_INSERT_FORM1", con);
                            in_form1.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = PERNR;
                            in_form1.Parameters.Add("@SUBTY", SqlDbType.VarChar).Value = SUBTY;
                            in_form1.Parameters.Add("@OBJPS", SqlDbType.VarChar).Value = OBJPS;
                            in_form1.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = hld_dt;
                            in_form1.Parameters.Add("@PPHELD", SqlDbType.VarChar).Value = ppheld;
                            in_form1.Parameters.Add("@RERUNFILED", SqlDbType.VarChar).Value = return1;



                            if (status == "YES")
                            {
                                in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                            }
                            else
                            {
                                in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "RJ";
                            }
                            in_form1.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                            in_form1.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                            in_form1.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IN";
                            in_form1.CommandType = CommandType.StoredProcedure;

                            in_form1.ExecuteNonQuery();
                            ErrorTag = "S";
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Successmessage", "ShowCallSuccessMessage();", true);
            //con.Close();
            //FunctionConnect.ConnectionClose();
            
            //Response.Redirect(Request.RawUrl);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = null;
            //con = new SqlConnection(ConnectionString);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    //FunctionConnect.ConnectionOpen();
                    SqlCommand chk_form1 = null;
                    chk_form1 = new SqlCommand("Select * from T_FORM1 where pernr='" + Session["emp"].ToString() + "' and holdingdt ='" + hld_dt + "' ", con);
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = chk_form1;
                    ad.Fill(dt);
                    //chk_form1.Dispose();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                            string PERNR = item["PERNR"].Text.Replace("&nbsp;", "");
                            string SUBTY = item["SUBTY"].Text.Replace("&nbsp;", "");
                            string OBJPS = item["OBJPS"].Text.Replace("&nbsp;", "");

                            TextBox tb_ppheld = (TextBox)item["PPOSITION"].FindControl("tb_pp");
                            string ppheld = tb_ppheld.Text.Replace("&nbsp;", "");

                            DropDownList dd_return = (DropDownList)item["RETURN"].FindControl("DropDownList1");
                            string return1 = dd_return.SelectedItem.Value.ToString().Replace("&nbsp;", "");

                            SqlCommand in_form1 = null;
                            in_form1 = new SqlCommand("SP_INSERT_FORM1", con);
                            in_form1.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = PERNR;
                            in_form1.Parameters.Add("@SUBTY", SqlDbType.VarChar).Value = SUBTY;
                            in_form1.Parameters.Add("@OBJPS", SqlDbType.VarChar).Value = OBJPS;
                            in_form1.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = hld_dt;
                            in_form1.Parameters.Add("@PPHELD", SqlDbType.VarChar).Value = ppheld;
                            in_form1.Parameters.Add("@RERUNFILED", SqlDbType.VarChar).Value = return1;
                            in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SV";
                            in_form1.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                            in_form1.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                            in_form1.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "UP";
                            in_form1.CommandType = CommandType.StoredProcedure;
                            in_form1.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        foreach (GridDataItem item in RadGrid1.Items)
                        {
                            string PERNR = item["PERNR"].Text.Replace("&nbsp;", "");
                            string SUBTY = item["SUBTY"].Text.Replace("&nbsp;", "");
                            string OBJPS = item["OBJPS"].Text.Replace("&nbsp;", "");

                            TextBox tb_ppheld = (TextBox)item["PPOSITION"].FindControl("tb_pp");
                            string ppheld = tb_ppheld.Text.Replace("&nbsp;", "");

                            DropDownList dd_return = (DropDownList)item["RETURN"].FindControl("DropDownList1");
                            string return1 = dd_return.SelectedItem.Value.ToString().Replace("&nbsp;", "");

                            SqlCommand in_form1 = null;
                            in_form1 = new SqlCommand("SP_INSERT_FORM1", con);
                            in_form1.Parameters.Add("@PERNR", SqlDbType.VarChar).Value = PERNR;
                            in_form1.Parameters.Add("@SUBTY", SqlDbType.VarChar).Value = SUBTY;
                            in_form1.Parameters.Add("@OBJPS", SqlDbType.VarChar).Value = OBJPS;
                            in_form1.Parameters.Add("@HOLDINGDT", SqlDbType.DateTime).Value = hld_dt;
                            in_form1.Parameters.Add("@PPHELD", SqlDbType.VarChar).Value = ppheld;
                            in_form1.Parameters.Add("@RERUNFILED", SqlDbType.VarChar).Value = return1;
                            in_form1.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "SG";
                            in_form1.Parameters.Add("@AENAM", SqlDbType.VarChar).Value = Session["emp"].ToString();
                            in_form1.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = Request.ServerVariables["REMOTE_ADDR"];
                            in_form1.Parameters.Add("@T_TYPE", SqlDbType.VarChar).Value = "IN";
                            in_form1.CommandType = CommandType.StoredProcedure;
                            in_form1.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
            //con.Close();
            // FunctionConnect.ConnectionClose();
            Response.Redirect(Request.RawUrl);
        }

        private void fndisplay(string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg + "');", true);
            //lblcatch.Text = msg;
        }
    }
}