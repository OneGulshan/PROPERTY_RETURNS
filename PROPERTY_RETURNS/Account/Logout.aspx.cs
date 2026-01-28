using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Linq;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS
{
    public partial class Logout : System.Web.UI.Page
    {
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
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
