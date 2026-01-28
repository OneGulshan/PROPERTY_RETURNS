using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace PROPERTY_RETURNS
{
    public partial class Login : System.Web.UI.Page
    {
        static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        SqlConnection con = new SqlConnection(conn);
        static string connerp = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString.ToString();
        SqlConnection conerp = new SqlConnection(connerp);
        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //loginPanelFooter.Visible = false; } else { loginPanelFooter.Visible = true;
                txtUserName.Focus();
            }           
        }
        #endregion

        #region Events
        /// <summary>
        /// Login Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uid="";
            string pwd="";
            uid=txtUserName.Text.Trim();
            pwd=txtPassword.Text.Trim();

            if (uid == "" || pwd == "")
            {
                if (uid == "")
                { 
                    failureText.Text = "User Id Can not be Empty";
                    txtUserName.Focus();
                 }
                if (pwd == "")
                {
                    failureText.Text = "Password Can not be Empty";
                    txtPassword.Focus();
                }
            }
                else
                {
                    Boolean authentication = AuthenticateUser(uid, pwd);
                    if (authentication == true)
                        Response.Redirect("../HOME_PAGE.aspx");
                    else
                    {
                        failureText.Text = "User does not Exist";
                        txtUserName.Focus();
                    }
                }
            }
            //if (Configurations.isValidEmail(txtUserName.Text.Trim()))
            //{
            //    Boolean authentication = userManager.AuthenticationByEmail(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            //    if (authentication)
            //    {
            //        loginPanelBody.Visible = false;
            //        // Get user's information based on email id
            //        userProfile = userManager.ProfileByEmail(txtUserName.Text.Trim());
                    
            //        // Save User's information to the Session
            //        Session[Sessions.UserInfo] = userProfile;

            //        if ((userProfile.userPasswordResetCode == null) || (userProfile.userPasswordResetCode == string.Empty))
            //            BindProjectsDropDown();
            //        else
            //            Response.Redirect("~/" + RedirectionPage.ChangePassword);
            //    }
            //    else
            //    {
            //        failureText.Text = Language.LoginFailed;
            //        loginPanelFooter.Visible = false;
            //    }
            //}
            //else
            //{
            //    Boolean authentication = userManager.AuthenticationByMobile(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            //    if (authentication)
            //    {
            //        loginPanelBody.Visible = false;
            //        // Get user's information based on email id
            //        userProfile = userManager.ProfileByMobile(txtUserName.Text.Trim());

            //        // Save User's information to the Session
            //        Session[Sessions.UserInfo] = userProfile;

            //        if ((userProfile.userPasswordResetCode == null) || (userProfile.userPasswordResetCode == string.Empty))
            //            BindProjectsDropDown();
            //        else
            //            Response.Redirect("~/" + RedirectionPage.ChangePassword);
            //    }
            //    else
            //    {
            //        failureText.Text = Language.LoginFailed;
            //        loginPanelFooter.Visible = false;
            //    }
            //}
        
        protected Boolean AuthenticateUser(string uid, string pwd)
        {
            string fname="";
            string lname="";
            string uname="";
            string ugrade="";
            string udept="";
            string upayarea="";
            string pernr = "";
            pernr = "00" + uid;
            string getuser = "select * from M_USER where PERNR='" + uid + "' and PWD='" + pwd + "'";
                if (con.State != ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(getuser, con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string checkuser = "select FIRSTNAME,LASTNAME,GRADE,DEPT,PAYAREA from EMPMASTER where PERNR='" + pernr + "'";
                        if (conerp.State != ConnectionState.Open)
                        {
                            conerp.Close();
                            conerp.Open();
                        }
                        SqlCommand cmderp = new SqlCommand(checkuser, conerp);
                        SqlDataReader reader1;
                        reader1 = cmderp.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                fname = reader1.GetString(0);
                                lname = reader1.GetString(1);
                                ugrade = reader1.GetString(2);
                                udept = reader1.GetString(3);
                                upayarea = reader1.GetString(4);
                                uname = fname + " " + lname;
                                Session["id"] = uid;
                                string empno = "00000000" + uid;
                                Session["emp"] = empno.Substring(empno.Length - 8);
                                Session["name"] = uname;
                                Session["grade"] = ugrade;
                                Session["dept"] = udept;
                                Session["plantcd"] = upayarea;
                            }
                            return true;
                        }
                       
                    }
            }
                return false;
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //// get selected project details
            //Project project = projectManager.Project(Convert.ToInt32(ddlProjects.SelectedValue));

            //ProjectLOA projectLOA = projectManager.GetProjectLOA(project.projectID);

            //Session[Sessions.ProjectSupplyLOA] = projectLOA;
            //// project.projectLOAID = projectLOA.projectLOAID;
            //// Save project details to the session
            //Session[Sessions.Project] = project;

            //failureText.Text = Language.ProjectInfoSaved;
            //Response.Redirect(RedirectionPage.Default);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect(RedirectionPage.LogOut);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Function to bind the projects drop down based on the user
        /// </summary>
        private void BindProjectsDropDown()
        {
            ////Clear projects dropdown list
            //ddlProjects.Items.Clear();

            //// Get list of authorised projects
            //List<Project> projects = projectManager.GetProjectsForUser(userProfile.user_id);
            //if (projects.Count > 0)
            //{
            //    // Bind each project to dropdown list
            //    foreach (Project project in projects)
            //    {
            //        ListItem item = new ListItem();
            //        item.Text = project.projectName;
            //        item.Value = project.projectID.ToString();
            //        ddlProjects.Items.Add(item);
            //    }
            //}
            //else
            //{
            //    failureText.Text = Language.NoProjectAssigned;
            //    btnProceed.Enabled = false;
            //}
        }
        #endregion
    }
}