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
using System.Security.Principal;

namespace PROPERTY_RETURNS
{
    public partial class dateSelection : System.Web.UI.Page
    {
        string storeDate = "";
        string mail = "";
        string name = "";
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //string qry= "select '--Select Holding Date--' as showholdingdt,'1900-01-01' as HOLDINGDT ";
                //qry = qry + " union SELECT convert(varchar,HOLDINGDT,103) as showholdingdt ,HOLDINGDT FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt = '2014-08-01'";
                //if (Session["emp"].ToString() == "00009766" || Session["emp"].ToString() == "00087271" || Session["emp"].ToString() == "00008685")
                //{
                //    qry = qry + " union  SELECT convert(varchar,HOLDINGDT,103) as showholdingdt ,HOLDINGDT FROM [PROP_RETURNS].[dbo].[M_CUTOFFDATE] where holdingdt = '2015-03-31' ";
                //}
                //SqlDataSource1.SelectCommand = qry;
               
               // RadDatePicker1.SelectedDate = DateTime.Now;
            }
            //string storeDate = "";
            //DateTime sdate = (DateTime)RadDatePicker1.SelectedDate;
            //storeDate = Convert.ToString(sdate);
            //Session["getDate"] = storeDate;
            //string mail = "";
            //mail = Session["user"].ToString();
            //string name = "";
            //name = Session["name"].ToString();
            try
            {
                welcomeText.Text = "Welcome " + Session["name"].ToString();
            }
            catch (Exception ex)
            {

            }

            //if (IsYourLoginStillTrue(Session["uid"].ToString(), Session["sid"].ToString()))
            //{
            //    // check to see if your user ID is being used elsewhere under a different session ID
            //    if (!IsUserLoggedOnElsewhere(Session["uid"].ToString(), Session["sid"].ToString()))
            //    {
            //        welcomeText.Text = "Welcome " + Session["name"].ToString();
            //    }
            //    else
            //    {
            //        LogEveryoneElseOut(Session["uid"].ToString(), Session["sid"].ToString());
            //        welcomeText.Text = "Welcome " + Session["name"].ToString();
            //    }
            //}
            //else
            //{
            //    Session["user"] = "";
            //    Session["uid"] = "";
            //    Session["sid"] = "";
            //    Server.Transfer("../Account/login.aspx");
            //}
            
            //calendarM.Visible = false;
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Session["uid"] = "";
            Session["sid"] = "";
            Server.Transfer("../Account/login.aspx");

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            if (DDL_Date.SelectedValue != "1/1/1900 12:00:00 AM")
            {
                DateTime sdate = Convert.ToDateTime(DDL_Date.SelectedValue);
                storeDate = Convert.ToString(sdate);
                Session["getDate"] = sdate;
                //string location = rcb_location.SelectedValue.ToString();
                // Session["location"] = location;
                // mail = Session["user"].ToString();
                name = Session["name"].ToString();
                welcomeText.Text += "&nbsp;&nbsp;" + name;
                //if (location == "CC")
                //    Server.Transfer("../Available/availTimeSlot.aspx");
                //else if (location == "EOC")
                //    Server.Transfer("../Available/availTimeSloteoc.aspx");
                //else
                //    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=JavaScript>alert('Please select a Location')</SCRIPT>");
                Response.Redirect("HOME_PAGE_NEW.aspx");
            }
            else
                lblerr.Text = "Kindly select Holding Date";
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

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            //  Response.Write("SONI");
        }

        protected void chngForgetPass_Click(object sender, EventArgs e)
        {
            Server.Transfer("../Account/changepassword.aspx");
        }

        public bool IsYourLoginStillTrue(string userId, string sid)
        {
        //    CapWorxQuikCapContext context = new CapWorxQuikCapContext();

          //  IEnumerable<Logins> logins = (from i in context.Logins
            //                              where i.LoggedIn == true && i.UserId == userId && i.SessionId == sid
              //                            select i).AsEnumerable();
          //  return logins.Any();

            bool ret = false;
            int cnt=0;
           // string checkuser = "SELECT [UserId] ,[SessionId],[LoggedIn],[LoggedInDate] FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId +"' and SessionId='" + sid +"'";
            string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId='" + sid + "'";
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(checkuser, con);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cnt = reader.GetInt32(0);
                            
                        }
                    }
                    con.Close();
                    if (cnt > 0) ret = true;
                    return ret;
                }
                catch (Exception ex)
                {
                    // = ex.Message;
                    con.Close();
                    return false;
                }

            }
        }

        public  bool IsUserLoggedOnElsewhere(string userId, string sid)
        {
       //     CapWorxQuikCapContext context = new CapWorxQuikCapContext();

        //    IEnumerable<Logins> logins = (from i in context.Logins
          //                                where i.LoggedIn == true && i.UserId == userId && i.SessionId != sid
            //                              select i).AsEnumerable();
           // return logins.Any();

            bool ret = false;
            int cnt = 0;
            // string checkuser = "SELECT [UserId] ,[SessionId],[LoggedIn],[LoggedInDate] FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId +"' and SessionId='" + sid +"'";
            string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId<> '" + sid + "'";
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(checkuser, con);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cnt = reader.GetInt32(0);

                        }
                    }
                    con.Close();
                    if (cnt > 0) ret = true;
                    return ret;
                }
                catch (Exception ex)
                {
                    // = ex.Message;
                    con.Close();
                    return false;
                }

            }

        }

        public static void LogEveryoneElseOut(string userId, string sid)
        {
            //CapWorxQuikCapContext context = new CapWorxQuikCapContext();

            //IEnumerable<Logins> logins = (from i in context.Logins
            //                              where i.LoggedIn == true && i.UserId == userId && i.SessionId != sid // need to filter by user ID
            //                              select i).AsEnumerable();

            //foreach (Logins item in logins)
            //{
            //    item.LoggedIn = false;
            //}

            //context.SaveChanges();
            bool ret = false;
            int cnt = 0;
            // string checkuser = "SELECT [UserId] ,[SessionId],[LoggedIn],[LoggedInDate] FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId +"' and SessionId='" + sid +"'";
            string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId<> '" + sid + "'";
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(checkuser, con);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cnt = reader.GetInt32(0);

                        }
                    }
                    con.Close();
                    if (cnt > 0)
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


                                cmd_upd = new SqlCommand("SP_UPDATE_LOGINS", con);

                                cmd_upd.CommandType = CommandType.StoredProcedure;
                                cmd_upd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userId;
                                
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
                    }
                    //ret = true;
                   // return ret;
                }
                catch (Exception ex)
                {
                    // = ex.Message;
                    con.Close();
                    //return false;
                }

            }
        }
    }
}