using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS.FORMS
{
    public partial class excep_dtl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Property Returns Detail";
            string pernr = Request.QueryString["pernr"].ToString();
            string year = Request.QueryString["year"].ToString();
            lblemp.Text = pernr;
            SqlDataSource1.SelectParameters[0].DefaultValue = pernr;
            SqlDataSource1.SelectParameters[1].DefaultValue = year;
            RadGrid1.DataBind();
        }
    }
}