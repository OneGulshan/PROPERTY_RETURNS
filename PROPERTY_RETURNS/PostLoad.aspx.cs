using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Globalization;
//using System.Security.Claims;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;

using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;

namespace PROPERTY_RETURNS
{
    public partial class PostLoad : System.Web.UI.Page
    {
       
            static string conn = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(conn);
            clsIntranetApps.BL bl = new clsIntranetApps.BL();
            protected void Page_Load(object sender, EventArgs e)
            {


                PostLoad1();


            }

            public string PostLoad1()
            {
                string appsecret = "zC8KglvTDrf";
                // string appsecret = "msjS44LN!9Y";
                string EmpId = Decrypt(Request.Form["EmpId"].ToString(), appsecret);
                string EmpName = Decrypt(Request.Form["EmpName"].ToString(), appsecret);
                string Dept = Decrypt(Request.Form["Dept"].ToString(), appsecret);
                string Location = Decrypt(Request.Form["Location"].ToString(), appsecret);
                string Mobile = Decrypt(Request.Form["Mobile"].ToString(), appsecret);
                string EmailId = Decrypt(Request.Form["EmailId"].ToString(), appsecret);

                if (EmpId.Contains("@"))
                {
                    // ViewBag.Category = "Logged on as Non-NTPC User";
                    FormsAuthentication.SetAuthCookie(EmpId, false);
                    Session["UserId"] = EmpId;
                    Session["UserName"] = EmpName;
                    Session["Dept"] = Dept;
                    Session["Plant"] = Location;

                    // return RedirectToAction("Index", "Home");
                }
                else if (EmpId.Length == 6)
                {
                    //  ViewBag.Category = "Logged on as NTPC User";
                    clsIntranetApps.BL bl = new clsIntranetApps.BL();
                    var _user = bl.GetUserByEmpNoNew(EmpId).FirstOrDefault();
                    if (_user.UserStatus == "N")
                    {
                        // TempData["ErrorMessage"] = "User with this Id is 'Inactive'";
                        //ModelState.AddModelError("", "Invalid login attempt.");
                        //    return RedirectToAction("ErrorPage", "Home");


                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(EmpId, false);
                        //TempData["UserId"] = EmpId;
                        //TempData["UserName"] = EmpName;
                        //TempData["Dept"] = Dept;
                        //TempData["Location"] = Location;

                        Session["uid"] = EmpId;
                        string s_pernr = "00" + EmpId;
                        get_detail(s_pernr);

                        string url = "dateSelection.aspx";
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();
                        Response.Redirect(url, false);

                        // return RedirectToAction("Index", "Home");
                    }
                }

                //return RedirectToAction("Index", "Home");
                // return View();

                return "";
            }
            public static string Decrypt(string cipherText, string EncryptionKey)
            {
                //If System.Web.HttpRuntime.Cache("marks" & cipherText) Is Nothing Then

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
			0x49,
			0x76,
			0x61,
			0x6e,
			0x20,
			0x4d,
			0x65,
			0x64,
			0x76,
			0x65,
			0x64,
			0x65,
			0x76
		});
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                //  System.Web.HttpRuntime.Cache.Insert("marks" & cipherText, cipherText, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)

                //End If
                ///PHP Equivqlent
                //        $decryptedBytes = NULL;
                //$saltBytes = array(1,2,3,4,5,6,7,8);
                //$saltBytesstring = "";
                //For ($i= 0;$i<count($saltBytes);$i++){ echo $i;
                //    $saltBytesstring=$saltBytesstring.chr($saltBytes[$i]);
                //}

                //$AESKeyLength = 265/8;
                //$AESIVLength = 128/8;

                //$key = hash_pbkdf2("sha1", $passwordBytesstring, $saltBytesstring, 1000, $AESKeyLength + $AESIVLength, true); 

                //$aeskey = (  substr($key,0,$AESKeyLength) );
                //$aesiv =  (  substr($key,$AESKeyLength,$AESIVLength) );

                //$decrypted = mcrypt_decrypt
                //      (
                //          MCRYPT_RIJNDAEL_128,
                //          $aeskey,
                //          $bytesToBeDecryptedbinstring,
                //          MCRYPT_MODE_CBC,
                //          $aesiv
                //       );
                //$arr = str_split($decrypted);
                //For ($i= 0;$i<count($arr);$i++){
                //    $arr[$i] = ord($arr[$i]);
                //}
                //$decryptedBytes = $arr;
                return cipherText;
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

                uid = spernr;
                pernr = uid;

                //  pass = txtPassword.Text.ToUpper();
                //  if (authenticate_user(uid, pass) > 0)
                // {
                string checkuserpa = "select firstname+' '+lastname as uname,PAYAREA,project,psa,location,Cast(left(RIGHT(hiredt,7),2)+'/'+LEFT(hiredt,2)+'/'+RIGHT(hiredt,4) as datetime),DEPT,GRADE from [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] where PERNR='" + spernr + "'";
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
                            Response.Write("Invalid User ID / Password....");
                            // Response.Write("<script>alert('Invalid User id / Password...');</script>");
                            //msg.Text = "Invalid User ID / Password....";
                            //ClientScript.RegisterStartupScript(GetType(), "Error", "alert('" + msg.Text + "');", true);
                            //msg.Visible = true;
                            con.Close();
                            // Response.Write("Invalid User ID / Password....");
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
                        Response.Write(ex.Message);
                        //   fndisplay(ex.Message);
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
                        //  lblcatch.Text = ex.Message;
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
                        //  lblcatch.Text = ex.Message;
                        con.Close();
                        return "";
                    }

                }
            }


        
    }
}