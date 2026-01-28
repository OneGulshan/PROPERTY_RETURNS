using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["getDate"] == null)
            {
                RadMenu1.Items[0].Visible = false;
                //Menu.Items(2).Visible = False
            }
            if (Session["emp"] == null)
            {
                Response.Redirect("/PROPERTY_RETURNS/Account/Login.aspx");
            }
            else
            {
                string role = Session["role"].ToString();
                string auth_psa = "";
                string auth_emp = Session["emp"].ToString();
                // if (Session["emp"].ToString() == "00087271")
                //if (Session["emp"].ToString() == "00061982" ||  Session["emp"].ToString() == "00004323" || Session["emp"].ToString() == "00080110" || Session["emp"].ToString() == "00004365" || Session["emp"].ToString() == "00003816" || Session["emp"].ToString() == "00008685" || Session["emp"].ToString() == "00009766" || Session["emp"].ToString() == "00010420" || Session["emp"].ToString() == "00087271")
                //   Session["role"] = "A";
                if (Session["role"].ToString() == "A" || Session["role"].ToString() == "S")
                {
                    if (RadMenu1.Items.Contains(RadMenu1.Items.FindItemByText("Reports")))
                    { }
                    else
                    {
                        RadMenuItem stateItem = new RadMenuItem();
                        stateItem.Text = "Reports";
                        stateItem.NavigateUrl = "#";
                        stateItem.Font.Bold = true;
                        RadMenu1.Items.Add(stateItem);
                    }

                    RadMenuItem stateItem_sub = new RadMenuItem();
                    stateItem_sub.Text = "Holdings (Active Employees)";
                    stateItem_sub.NavigateUrl = "~/FORMS/GEN_REPORT1.aspx";
                    stateItem_sub.Font.Bold = true;
                    int index = RadMenu1.Items.FindItemByText("Reports").Index;

                    RadMenuItem stateItem_sub1 = new RadMenuItem();
                    stateItem_sub1.Text = "Exception Report";
                    stateItem_sub1.NavigateUrl = "~/FORMS/EXP_REPORT1.aspx";
                    stateItem_sub1.Font.Bold = true;

                    //  RadMenu1.Items[index].Items.Add(stateItem_sub1)


                    RadMenuItem stateItem_sub2 = new RadMenuItem();
                    stateItem_sub2.Text = "Holdings (Separated Employees)";
                    stateItem_sub2.NavigateUrl = "~/FORMS/GEN_REPORT2.aspx";
                    stateItem_sub2.Font.Bold = true;

                   
                    if (RadMenu1.Items[index].Items.Contains(RadMenu1.Items[index].Items.FindItemByText("Holdings (Active Employees)")))
                    { }
                    else
                    {
                        RadMenu1.Items[index].Items.Add(stateItem_sub);
                    }
                    if (RadMenu1.Items[index].Items.Contains(RadMenu1.Items[index].Items.FindItemByText("Exception Report")))
                    { }
                    else
                    {

                        RadMenu1.Items[index].Items.Add(stateItem_sub1);
                    }
                    if (RadMenu1.Items[index].Items.Contains(RadMenu1.Items[index].Items.FindItemByText("Holdings (Separated Employees)")))
                    { }
                    else
                    {

                        RadMenu1.Items[index].Items.Add(stateItem_sub2);
                    }
                   
                }

                if (role == "A")
                {
                    if (RadMenu1.Items.Contains(RadMenu1.Items.FindItemByText("User Authorization")))
                    { }
                    else
                    {
                        RadMenuItem stateItem = new RadMenuItem();
                        stateItem.Text = "User Authorization";
                        stateItem.NavigateUrl = "~/FORMS/UserAuth.aspx";
                        stateItem.Font.Bold = true;
                        RadMenu1.Items.Add(stateItem);
                    }
                }
            }
        }


    }
}
