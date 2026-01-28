using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using Telerik.Web.UI;
using System.Data.SqlClient;

namespace PROPERTY_RETURNS.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(conn);
        SqlConnection con1 = new SqlConnection(conn);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oldP.Text = "";
                newP.Text = "";
                repP.Text = "";
                uid.Focus();
            }
        }
        protected void submit_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    string userid = "";
                    //userid = Session["userid"].ToString();
                    userid = uid.Text;
                    //string email = "";
                    //email = mail.Text;
                    string opass = "";
                    opass = oldP.Text;
                    string newpass = "";
                    newpass = newP.Text;
                    string reppass = "";
                    reppass = repP.Text;
                    Int32 c = 0;
                    Int32 count = 0;
                    string availCount = "";
                    if (newpass == reppass)
                    {
                        availCount = "select count(*) as c from M_USER where PERNR='" + userid + "' and PWD='" + opass + "' ";
                        if (con.State != ConnectionState.Open)
                        {
                            con.Close();
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand(availCount, con);
                        SqlDataReader reader;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                        if (count >= 1)
                        {
                            reader.Close();
                            string UpdateRecord = "";
                            UpdateRecord = "update M_USER set PWD='" + newpass + "' where PERNR='" + userid + "'";
                            if (con1.State != ConnectionState.Open)
                            {
                                con1.Close();
                                con1.Open();
                            }
                            SqlCommand cmd1 = new SqlCommand(UpdateRecord, con1);
                            cmd1.ExecuteNonQuery();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Sucess! Your Password has been Changed, Please Login with new password');", true);
                            //  Response.Write("<script>alert('Your Password has been Changed to:'+ newpass +'.Please Login with new Password');</script>");
                            con.Close();
                            con1.Close();
                            //   Server.Transfer("~/ChangePasswordNew.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Error! Existing Password is Not Correct');", true);
                            //Response.Write("<script>alert('Old Password Incorrect!');</script>");
                            // Server.Transfer("~/ChangePasswordNew.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Error! New Password Mismatch');", true);
                        // Server.Transfer("~/ChangePasswordNew.aspx");
                    }
                }
                catch (Exception ex)
                {
                    //    if (ex.Message == "Invalid attempt to read when no data is present. ")
                    Response.Write(ex.Message);
                }
            }
        }
    }
}