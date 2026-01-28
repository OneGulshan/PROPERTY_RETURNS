using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS
{
    public static class FunctionConnect
    {
        static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString;
        public static SqlConnection con = new SqlConnection(ConnectionString);

        public static void ConnectionOpen()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public static void ConnectionClose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}