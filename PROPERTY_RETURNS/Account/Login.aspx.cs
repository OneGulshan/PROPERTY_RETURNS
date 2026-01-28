using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.DirectoryServices.AccountManagement;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using System.Net;

namespace PROPERTY_RETURNS.Account
{
    public partial class Login : Page
    {
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(conn);
        clsIntranetApps.BL bl = new clsIntranetApps.BL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnLogout.Visible = false;
        }

        private void RefreshCaptcha()
        {
            Session["CaptchaCode"] = null;
            imgCaptcha.ImageUrl = "~/Account/CaptchaImage.aspx?" + DateTime.Now.Ticks; // Force reload
        }
        //protected void LoginButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string enteredCode = txtCaptcha.Text.Trim();
        //        string actualCode = Session["CaptchaCode"] as string;

        //        if (enteredCode.Equals(actualCode, StringComparison.OrdinalIgnoreCase))
        //        {
        //            // var user = bl.GetUserByEmpNo(txtUserName.Text).FirstOrDefault();
        //            Session["role"] = "";
        //            // string username = user.UserID;
        //            // string passWord = user.Password;
        //            string username = txtUserName.Text + "@ntpc.orgn";
        //            string passWord = txtPassword.Text;
        //            if (auth(username, passWord) == true)
        //            //if ((username != null) && (passWord == txtPassword.Text))
        //            {
        //                //  fndisplay("Autehnticated");

        //                FormsAuthentication.SetAuthCookie(txtUserName.Text, false);
        //                string SessionId = System.Web.HttpContext.Current.Session.SessionID;
        //                // Insert_Login(txtUserName.Text,SessionId);
        //                //SessionId = System.Web.HttpContext.Current.Session.SessionID; ;
        //                Session["uid"] = txtUserName.Text;
        //                Session["sid"] = SessionId;

        //                //if (IsYourLoginStillTrue(Session["uid"].ToString(), Session["sid"].ToString()) || IsUserLoggedOnElsewhere(Session["uid"].ToString(), Session["sid"].ToString()))
        //                //{
        //                //    // check to see if your user ID is being used elsewhere under a different session ID
        //                //    //if (IsUserLoggedOnElsewhere(Session["uid"].ToString(), Session["sid"].ToString()))
        //                //   // {
        //                //        Session["user"] = "";
        //                //        Session["uid"] = "";
        //                //        Session["sid"] = "";
        //                //        msg.Text = "User already Logged In....";
        //                //        msg.Visible = true;
        //                //        btnLogout.Visible = true;
        //                //    }
        //                //    else
        //                //    {
        //                string s_pernr = "00" + txtUserName.Text;
        //                get_detail(s_pernr);
        //                Insert_Login(txtUserName.Text, SessionId);
        //                string url = "../dateSelection.aspx";
        //                //HttpContext.Current.ApplicationInstance.CompleteRequest();
        //                Response.Redirect(url, false);
        //                //Insert_Login(txtUserName.Text, SessionId);





        //                // LogEveryoneElseOut(Session["uid"].ToString(), Session["sid"].ToString());
        //                //welcomeText.Text = "Welcome " + Session["name"].ToString();
        //                // Insert_Login(txtUserName.Text, SessionId);
        //                //  }
        //                //}
        //                // else
        //                // {
        //                //     LogEveryoneElseOut(Session["uid"].ToString(), Session["sid"].ToString());
        //                //Session["user"] = "";
        //                //Session["uid"] = "";
        //                //Session["sid"] = "";
        //                //msg.Text = "User already Logged In....";
        //                //msg.Visible = true;
        //                // ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
        //                //Server.Transfer("../Account/login.aspx");
        //                //}


        //                //string s_pernr = "00" + txtUserName.Text;
        //                //get_detail(s_pernr);

        //                //string url = "../dateSelection.aspx";
        //                ////HttpContext.Current.ApplicationInstance.CompleteRequest();
        //                //Response.Redirect(url, false);
        //            }
        //            else
        //            {

        //                //  Response.Write("<script>alert('Invalid User id / Password...');</script>");
        //                msg.Text = "Invalid User ID / Password....";
        //                msg.Visible = true;
        //                ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
        //            }
        //        }
        //        else
        //        {
        //            lblMessage.Text = "Invalid CAPTCHA code.";
        //            RefreshCaptcha();
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        fndisplay("Error:" + ex.Message);
        //        //       TempData["Error"] = "Invalid Login Attempt";
        //        //       return RedirectToAction("Login", "Authenticate");
        //    }
        //}

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string enteredCode = txtCaptcha.Text.Trim();
                string actualCode = Session["CaptchaCode"] as string;
                if (enteredCode.Equals(actualCode, StringComparison.OrdinalIgnoreCase))
                {
                    Session["role"] = "";
                    string username = txtUserName.Text + "@ntpc.orgn";
                    string passWord = txtPassword.Text;
                    if (auth(username, passWord) == true)
                    {
                        string otp = GenerateOTP(6);
                        Session["LoginOTP"] = otp;
                        Session["OtpUser"] = txtUserName.Text;

                        SendOtpToUser(txtUserName.Text, otp);  // Implement this to send OTP via email/SMS

                        // Show message and display OTP panel, hide login panel
                        lblMessage.ForeColor = System.Drawing.Color.Blue;
                        lblMessage.Text = "OTP has been sent to your registered email/phone. Please enter the OTP below.";

                        pnlLoginInputs.Visible = false;    // Hide login inputs
                        pnlOtpVerification.Visible = true; // Show OTP input panel
                    }
                    else
                    {
                        //msg.Text = "Invalid User ID / Password....";
                        //msg.Visible = true;
                        //ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid CAPTCHA code.";
                    RefreshCaptcha();
                }


            }
            catch (Exception ex)
            {
                fndisplay("Error:" + ex.Message);
                //       TempData["Error"] = "Invalid Login Attempt";
                //       return RedirectToAction("Login", "Authenticate");
            }
        }

        private string GenerateOTP(int length)
        {
            var random = new Random();
            var otp = new char[length];
            for (int i = 0; i < length; i++)
                otp[i] = (char)('0' + random.Next(0, 10));
            return new string(otp);
        }

        private void SendOtpToUser(string userId, string otp)
        {
            getUserEmail("00" + userId);
            string mobile = Session["Mobile"].ToString();
            string email = Session["Email"].ToString();
            // Implement sending OTP via email or SMS here
            // Example: Use SMTP email or SMS gateway API
            if (mobile!= "")
                sendOtpToMobile(mobile, otp);
            if (email != "")
                sendOtpToemail(email, otp);
            // For now, just for testing, you could log it or display it somewhere (not in production!)
            System.Diagnostics.Debug.WriteLine($"OTP for user {userId}: {otp}");
        }

        private void sendOtpToemail(string email, string otp)
        {
            try
            {
              //  email = "04thakurmukesh@gmail.com";
                MailMessage mm = new MailMessage();
                string mailbod = "<br>Respected Sir/Madam,<br><br>This is an urgent message regarding Otp at<br><br>" +
                    "<b>Otp : " + otp + "</b> " +
                "<br><br><br><b style='color:red;'>*</b> This is a system generated mail.Please do not reply.<br>";
                HtmlString msg = new HtmlString(mailbod);
                mm.From = new MailAddress("NTPCIT@ntpc.co.in");
                mm.To.Add(email);
                mm.Subject = "Otp";
                mm.Body = mailbod;
                mm.BodyEncoding = Encoding.UTF8;
                mm.IsBodyHtml = true;
                
                SmtpClient client = new SmtpClient("10.0.14.112");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential("iterpapps@ntpc.co.in", "Ntpc@2021y");

                ContentType mimeType = new ContentType("text/html");

                AlternateView alternate = AlternateView.CreateAlternateViewFromString(mailbod, mimeType);
                mm.AlternateViews.Add(alternate);
                client.Send(mm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void sendOtpToMobile(string MobilePhone, string otp)
        {
            try
            {
               // MobilePhone = "9690783898";
                string MessageTemplateID = "1307161579157706923";
                string number = MobilePhone;
                string str1 = number.Substring(0, 1);
                string str4 = number.Substring(4, 1);
                string str3 = number.Substring(7, 3);
                string concatnumber = str1 + "XXX" + str4 + "XX" + str3;
                string msg = "Message from: NTPC-IT Message To:" + concatnumber + " Message: OTP is " + otp + ".NTPC Ltd.";
                string testurl = "https://api.onex-aura.com/api/sms?key=0f8AbyKW&to=" + MobilePhone + "&from=NTPCIT&body=" + msg + "&templateid=" + MessageTemplateID;

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                WebProxy myproxy = new WebProxy();

                string proxyAddress = "http://10.0.8.8:8080";
                Uri newuri = new Uri(proxyAddress);
                myproxy.Address = newuri;
                WebRequest.DefaultWebProxy = myproxy;
                WebRequest request1 = WebRequest.Create(testurl);
                request1.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request1.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getUserEmail(string spernr)
        {
            string mobile = "";
            string email = "";

            string checkuserpa = "select Email,Phone from [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PERNR='" + spernr + "'";
            using (SqlConnection conerp = new SqlConnection(conn))
            {
                try
                {
                    if (conerp.State != ConnectionState.Open)
                    {
                        conerp.Close();
                        conerp.Open();
                    }
                    SqlCommand cmderp = new SqlCommand(checkuserpa, conerp);
                    SqlDataReader reader;
                    reader = cmderp.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            mobile = reader.GetString(1);
                            email = reader.GetString(0);
                            Session["Email"] = email;
                            Session["Mobile"] = mobile;
                        }
                    }
                    else
                    {
                        //msg.Text = "Invalid User ID / Password....";
                        //ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
                       // msg.Visible = true;
                        con.Close();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                    fndisplay(ex.Message);
                }
            }
        }

        private void get_detail(string spernr)
        {

            string uid = "";
            string uname = "";
            string pass = "";
            string pernr = "";
            string upa = "";
            string upsa = "";
            string uproject = "";
            string ulocation = "";
            string udept = "";
            string udesig = "";
            DateTime hdate = System.DateTime.Now;

            uid = txtUserName.Text;
            pernr = "00" + uid;

            //  pass = txtPassword.Text.ToUpper();
            //  if (authenticate_user(uid, pass) > 0)
            // {
            string checkuserpa = "select firstname+' '+lastname as uname,PAYAREA,project,psa,location,Cast(left(RIGHT(hiredt,7),2)+'/'+LEFT(hiredt,2)+'/'+RIGHT(hiredt,4) as datetime),DEPT,GRADE,Email,Phone from [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PERNR='" + spernr + "'";
            using (SqlConnection conerp = new SqlConnection(conn))
            {
                try
                {
                    if (conerp.State != ConnectionState.Open)
                    {
                        conerp.Close();
                        conerp.Open();
                    }
                    SqlCommand cmderp = new SqlCommand(checkuserpa, conerp);
                    SqlDataReader reader;
                    reader = cmderp.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string empno = "00000000" + uid;
                            Session["emp"] = empno.Substring(empno.Length - 8);
                            uname = reader.GetString(0);
                            upa = reader.GetString(1);
                            uproject = reader.GetString(2);
                            upsa = reader.GetString(3);
                            ulocation = reader.GetString(4);
                            hdate = reader.GetDateTime(5);
                            udept = reader.GetString(6);
                            udesig = reader.GetString(7);
                            Session["uid"] = uid;
                            //Session["uname"] = uname;
                            //Session["upa"] = upa;
                            //Session["upsa"] = upsa;
                            //Session["uproject"] = uproject;
                            //Session["ulocation"] = ulocation;
                            //Session["hdate"] = hdate.ToString("dd/MM/yyyy");
                            //Session["udept"] = udept;
                            //Session["udesig"] = udesig;
                            Session["id"] = uid;
                            empno = "00000000" + uid;
                            //   Session["emp"] = empno.Substring(empno.Length - 8);
                            Session["name"] = uname;
                            Session["grade"] = udesig;
                            Session["dept"] = udept;
                            Session["plantcd"] = upa;
                            Session["Email"] = reader.GetString(8);
                            Session["Mobile"] = reader.GetString(9);
                            Session["auth_pa"] = get_auth_pa(Session["emp"].ToString());
                            Session["auth_psa"] = get_auth_psa(Session["emp"].ToString());
                        }
                        //string url="../dateSelection.aspx";
                        ////HttpContext.Current.ApplicationInstance.CompleteRequest();
                        //Response.Redirect(url,false);
                        ////Server.Transfer("../dateSelection.aspx");
                    }
                    else
                    {
                        // Response.Write("<script>alert('Invalid User id / Password...');</script>");
                        //msg.Text = "Invalid User ID / Password....";
                        //ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
                        //msg.Visible = true;
                        con.Close();

                        //Server.Transfer("Login.aspx");
                    }

                    con.Close();
                    //  Response.Redirect("../dateSelection.aspx");
                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    // msg.Text = "Catch";
                    // msg.Visible = true;
                    fndisplay(ex.Message);
                }
            }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Invalid User id / Password...');</script>");
            //    msg.Text = "Invalid User ID / Password....";
            //    msg.Visible = true;
            //    con.Close();
            ////    Server.Transfer("../Account/Login.aspx");
            ////    con.Close();
            //}

        }
        //private int authenticate_user(string uid, string pass)
        //{
        //    int l_count=0;
        //   string checkuser = "select count(*) from employee_master where emp_no='" + uid + "' and pan='"+ pass +"'";
        //   using (SqlConnection con = new SqlConnection(conn))
        //   {
        //       try
        //       {
        //           if (con.State != ConnectionState.Open)
        //           {
        //               con.Close();
        //               con.Open();
        //           }
        //           SqlCommand cmd = new SqlCommand(checkuser, con);
        //           SqlDataReader reader1;
        //           reader1 = cmd.ExecuteReader();
        //           if (reader1.HasRows)
        //           {
        //               while (reader1.Read())
        //               {
        //                   l_count = reader1.GetInt32(0);
        //               }


        //           }
        //           con.Close();
        //           return l_count;
        //       }
        //       catch (Exception ex)
        //       {
        //           lblcatch.Text = ex.Message;
        //           con.Close();
        //           return 0;
        //       }

        //   }
        //}
        private string get_auth_pa(string pernr)
        {
            string auth_pa = "";
            string role = "";
            string checkuser = "SELECT IsNull(AUTHPA,'') AUTHPA,ROLE,STATUS FROM [PROP_RETURNS].[dbo].[M_USERAUTH] where pernr='" + pernr + "' and status='A'";
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
                    SqlDataReader reader1;
                    reader1 = cmd.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            auth_pa = reader1.GetString(0);
                            role = reader1.GetString(1);
                        }


                    }
                    con.Close();
                    Session["role"] = role;
                    return auth_pa;
                }
                catch (Exception ex)
                {
                    //lblcatch.Text = ex.Message;
                    con.Close();
                    return "";
                }

            }
        }
        private string get_auth_psa(string pernr)
        {
            string auth_psa = "";
            string role = "";
            string checkuser = "SELECT IsNull(AUTHPSA,'') AUTHPSA,ROLE FROM [PROP_RETURNS].[dbo].[M_USERAUTH] where pernr='" + pernr + "' and status='A'";
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
                    SqlDataReader reader2;
                    reader2 = cmd.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            auth_psa = reader2.GetString(0);
                            role = reader2.GetString(1);
                        }


                    }
                    con.Close();
                    Session["role"] = role;
                    return auth_psa;
                }
                catch (Exception ex)
                {
                    //lblcatch.Text = ex.Message;
                    con.Close();
                    return "";
                }

            }
        }
        public bool auth(string username, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "10.0.12.2", "mapp.admin", "P0werSt@t10n!!"))
            //using (var context = new PrincipalContext(ContextType.Domain, "ntpc", "ntpc'" + "\"mapp.admin", "P0werSt@t10n!!"))
            {
                return context.ValidateCredentials(username, password);
            }
        }
        private void Insert_Login(string userID, string SessionID)
        {
            DateTime curdate = System.DateTime.Now;
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    SqlCommand cmd_ins = null;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }


                    cmd_ins = new SqlCommand("SP_INSERT_LOGINS", con);

                    cmd_ins.CommandType = CommandType.StoredProcedure;
                    cmd_ins.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userID;
                    cmd_ins.Parameters.Add("@SessionId", SqlDbType.VarChar).Value = SessionID;
                    cmd_ins.Parameters.Add("@LoggedIn", SqlDbType.Bit).Value = true;
                    cmd_ins.Parameters.Add("@LoggedInDate", SqlDbType.DateTime).Value = curdate;
                    cmd_ins.ExecuteNonQuery();
                    //Response.Redirect(Request.RawUrl);

                }
                catch (Exception ex)
                {
                    //Handle exception, perhaps log it and do the needful
                    fndisplay(ex.Message);
                }
            }
        }
        public bool IsYourLoginStillTrue(string userId, string sid)
        {
            //    CapWorxQuikCapContext context = new CapWorxQuikCapContext();

            //  IEnumerable<Logins> logins = (from i in context.Logins
            //                              where i.LoggedIn == true && i.UserId == userId && i.SessionId == sid
            //                            select i).AsEnumerable();
            //  return logins.Any();

            bool ret = false;
            int cnt = 0;
            // string checkuser = "SELECT [UserId] ,[SessionId],[LoggedIn],[LoggedInDate] FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId +"' and SessionId='" + sid +"'";
            string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId='" + sid + "' and LoggedIn=1";
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

        public bool IsUserLoggedOnElsewhere(string userId, string sid)
        {
            //     CapWorxQuikCapContext context = new CapWorxQuikCapContext();

            //    IEnumerable<Logins> logins = (from i in context.Logins
            //                                where i.LoggedIn == true && i.UserId == userId && i.SessionId != sid
            //                              select i).AsEnumerable();
            // return logins.Any();

            bool ret = false;
            int cnt = 0;
            // string checkuser = "SELECT [UserId] ,[SessionId],[LoggedIn],[LoggedInDate] FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId +"' and SessionId='" + sid +"'";
            string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId<> '" + sid + "' and LoggedIn=1";
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
            //string checkuser = "SELECT count(*) FROM [PROP_RETURNS].[dbo].[T_Logins] where UserId='" + userId + "' and SessionId<> '" + sid + "' and LoggedIn=1";
            //using (SqlConnection con = new SqlConnection(conn))
            //{
            //    try
            //    {
            //        if (con.State != ConnectionState.Open)
            //        {
            //            con.Close();
            //            con.Open();
            //        }
            //        SqlCommand cmd = new SqlCommand(checkuser, con);
            //        SqlDataReader reader;
            //        reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                cnt = reader.GetInt32(0);

            //            }
            //        }
            //        con.Close();
            //        if (cnt > 0)
            //        {
            try
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
                // }
                //ret = true;
                // return ret;
            }
            catch (Exception ex)
            {
                // = ex.Message;
                //  con1.Close();
                //return false;
            }


        }
        protected void fndisplay(string msg)
        {
            //lblcatch.Text = msg;
            ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg + "');", true);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
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
                    cmd_upd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = txtUserName.Text;

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

        protected void lnkRefreshCaptcha_Click(object sender, EventArgs e)
        {
            Session["CaptchaCode"] = null;
            RefreshCaptcha();
        }

        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOtp.Text.Trim();
            string sessionOtp = Session["LoginOTP"] as string;
            string userId = Session["OtpUser"] as string;

            if (enteredOtp == sessionOtp && !string.IsNullOrEmpty(userId))
            {
                // OTP correct, complete login process here
                FormsAuthentication.SetAuthCookie(userId, false);

                string sessionId = System.Web.HttpContext.Current.Session.SessionID;
                Session["uid"] = userId;
                Session["sid"] = sessionId;

                // Optionally call your other post-login methods
                string s_pernr = "00" + userId;
                get_detail(s_pernr);
                Insert_Login(userId, sessionId);

                // Clear OTP session data
                Session["LoginOTP"] = null;
                Session["OtpUser"] = null;

                // Redirect to main page
                string url = "../dateSelection.aspx";
                Response.Redirect(url, false);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid OTP. Please try again.";
            }
        }
    }
}
