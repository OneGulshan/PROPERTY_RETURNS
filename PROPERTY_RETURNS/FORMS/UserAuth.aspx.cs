using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PROPERTY_RETURNS.FORMS
{
    public partial class UserAuth : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["PRConnectionString"].ConnectionString.ToString();
        static string ERPConnectionString = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeDropdown();
            }
        }

        private DataTable GetUserAuths()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetDistinctUserAuthList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void BindEmployeeDropdown()
        {
            ddlEmployee.Items.Clear();
            ddlEmployee.DataSource = GetEmployeeList();
            ddlEmployee.DataTextField = "EMPNAME";     // display name
            ddlEmployee.DataValueField = "PERNR";  // value returned
            ddlEmployee.DataBind();

            ddlEmployee.Items.Insert(0, new RadComboBoxItem("-- Select Employee --", ""));
        }

        private DataTable GetEmployeeList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT top 1 '%' as PERNR,'  All' as EMPNAME FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] " +
                    " union all SELECT [PERNR], RIGHT([PERNR],6)+'/'+[FIRSTNAME]+' '+[LASTNAME] as EMPNAME" +
                    " FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER] order by empname";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var selectedAuthPa = ddlAuthPa.CheckedItems.Select(i => i.Value).ToList();
                string AuthPa = string.Join(",", selectedAuthPa.Select(id => $"'{id}'"));
                var selectedAuthPsa = ddlAuthPsa.CheckedItems.Select(i => i.Value).ToList();

                string AuthPSa = string.Join(",", selectedAuthPsa.Select(id => $"'{id}'"));

                string selectedEmpId = ddlEmployee.SelectedValue;
                string query = string.Empty;
                if (string.IsNullOrEmpty(txtId.Value))
                {
                    query = @"INSERT INTO M_USERAUTH 
                         (PERNR, PLANTCD, AUTH_PA, AUTH_PSA, ROLE,AUTHPA,AUTHPSA,STATUS) 
                         VALUES (@PERNR, @PLANTCD, @PA, @PSA, @ROLE,@AUTHPA,@AUTHPSA,'A')";

                }
                else
                {
                    query = @"UPDATE M_USERAUTH 
                                SET 
                                PLANTCD = @PLANTCD,
                                AUTH_PA = @PA,
                                AUTH_PSA = @PSA,
                                ROLE = @ROLE,
                                AUTHPA = @AUTHPA,
                                AUTHPSA = @AUTHPSA,
                                STATUS='A'
                                WHERE ID = @ID;";

                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", txtId.Value);
                cmd.Parameters.AddWithValue("@PERNR", selectedEmpId);
                cmd.Parameters.AddWithValue("@PLANTCD", txtPlant.Text.Split('/')[0].Trim());
                cmd.Parameters.AddWithValue("@PA", txtPa.Text.Split('/')[0].Trim());
                cmd.Parameters.AddWithValue("@PSA", txtPsa.Text.Split('/')[0].Trim());
                cmd.Parameters.AddWithValue("@ROLE", "S");
                cmd.Parameters.AddWithValue("@AUTHPA", AuthPa);
                cmd.Parameters.AddWithValue("@AUTHPSA", AuthPSa);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Rebind grid and clear inputs
            RadGridUserAuth.Rebind();
            BindEmployeeDropdown();
            txtPlant.Text = txtPa.Text = txtPsa.Text = "";
            ddlAuthPa.Items.Clear();
            ddlAuthPsa.Items.Clear();
            ddlEmpRole.SelectedValue = "";
        }


        protected void RadGridUserAuth_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridUserAuth.DataSource = GetUserAuths();
        }

        protected void RadGridUserAuth_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Edit is handled automatically in InPlace mode
            }
            else if (e.CommandName == "Update")
            {
                GridEditableItem editedItem = (GridEditableItem)e.Item;
                int id = Convert.ToInt32(editedItem.GetDataKeyValue("ID"));

                string pernr = ((TextBox)editedItem["PERNR"].Controls[0]).Text;
                string plantcd = ((TextBox)editedItem["PLANTCD"].Controls[0]).Text;
                string authpa = ((TextBox)editedItem["AUTH_PA"].Controls[0]).Text;
                string authpsa = ((TextBox)editedItem["AUTH_PSA"].Controls[0]).Text;
                string role = ((TextBox)editedItem["ROLE"].Controls[0]).Text;
                string status = ((TextBox)editedItem["STATUS"].Controls[0]).Text;
                string authPA2 = ((TextBox)editedItem["AUTHPA"].Controls[0]).Text;
                string authPSA2 = ((TextBox)editedItem["AUTHPSA"].Controls[0]).Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE M_USERAUTH SET 
                            PERNR=@PERNR, PLANTCD=@PLANTCD, AUTH_PA=@AUTH_PA, AUTH_PSA=@AUTH_PSA,
                            ROLE=@ROLE, STATUS=@STATUS, AUTHPA=@AUTHPA, AUTHPSA=@AUTHPSA
                            WHERE ID=@ID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@PERNR", pernr);
                    cmd.Parameters.AddWithValue("@PLANTCD", plantcd);
                    cmd.Parameters.AddWithValue("@AUTH_PA", authpa);
                    cmd.Parameters.AddWithValue("@AUTH_PSA", authpsa);
                    cmd.Parameters.AddWithValue("@ROLE", role);
                    cmd.Parameters.AddWithValue("@STATUS", status);
                    cmd.Parameters.AddWithValue("@AUTHPA", authPA2);
                    cmd.Parameters.AddWithValue("@AUTHPSA", authPSA2);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(((GridDataItem)e.Item).GetDataKeyValue("ID"));

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM M_USERAUTH WHERE ID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else if (e.CommandName == "InitInsert")
            {
                // Optional: implement if using CommandItem to add new rows
            }
        }


        protected void RadGridUserAuth_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string selectedEmpId = ddlEmployee.SelectedValue;

            LoadFormDataForEdit(selectedEmpId);
        }

        private void BindAuthPaDropdown(string empId)
        {
            // Load cascading AuthPA options
            ddlAuthPa.Items.Clear();
            ddlAuthPa.DataSource = GetAuthPAOptions(empId);
            ddlAuthPa.DataTextField = "PROJECT";
            ddlAuthPa.DataValueField = "PA";
            ddlAuthPa.DataBind();
        }
        private void BindAuthPsaDropdown(List<string> selectedPAs, List<string> savedPsas)
        {
            if (selectedPAs == null || selectedPAs.Count == 0)
            {
                ddlAuthPsa.Items.Clear();
                return;
            }

            ddlAuthPsa.DataSource = GetAuthPsaOptions(selectedPAs);
            ddlAuthPsa.DataTextField = "LOCATION";
            ddlAuthPsa.DataValueField = "PSA";
            ddlAuthPsa.DataBind();

            // Preselect saved PSAs
            foreach (RadComboBoxItem item in ddlAuthPsa.Items)
            {
                if (savedPsas != null && savedPsas.Contains(item.Value))
                {
                    item.Checked = true;
                }
            }
        }

        protected void ddlAuthPa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var selectedAuthPa = ddlAuthPa.CheckedItems.Select(i => i.Value).ToList();
           
            // Step 1: Preserve already selected PSAs
            List<string> selectedPsasBefore = ddlAuthPsa.CheckedItems
                .Select(i => i.Value)
                .ToList();
           
            // Load PSA options based on selected AuthPA(s)
            BindAuthPsaDropdown(selectedAuthPa, selectedPsasBefore);
            
        }

        private DataTable GetUserAuthByEmpId(string empId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_GetUserAuthByEmpId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empId", empId);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private DataTable GetAuthPAOptions(string empId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(" SELECT distinct [PA], [PROJECT] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]" +
                    "where PA <> '' and PROJECT <> '' order by PROJECT", conn);
                cmd.Parameters.AddWithValue("@empId", empId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        private DataTable GetAuthPsaOptions(List<string> authPaIds)
        {
            string ids = string.Join(",", authPaIds.Select(id => $"'{id}'"));

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT distinct [PSA], [LOCATION] FROM [ERPHR.NTPCLAKSHYA.CO.IN].[ERPHRDB].[dbo].[EMPMASTER]" +
                    $" WHERE PA IN({ids}) and PSA <> '' and LOCATION <> '' order by LOCATION";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedChk = (CheckBox)sender;
            GridDataItem clickedItem = (GridDataItem)clickedChk.NamingContainer;
            foreach (GridDataItem item in RadGridUserAuth.MasterTableView.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkSelect");

                if (chk != null && chk != clickedChk)
                {
                    chk.Checked = false; // Uncheck all other checkboxes
                }
            }
            if (clickedChk.Checked)
            {
                string pernr = GetUserAuthPernr(clickedItem.GetDataKeyValue("ID").ToString());

                LoadFormDataForEdit(pernr);
            }
            else
            {
                ResetFormFields();
            }
        }

        private void LoadFormDataForEdit(string selectedEmpId)
        {
            var result = GetUserAuthByEmpId(selectedEmpId);
            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                string plant = row["BUSAREA"].ToString() + "/" + row["PROJECT"].ToString();
                string pa = row["PA"].ToString() + "/" + row["PROJECT"].ToString();
                string psa = row["PSA"].ToString() + "/" + row["LOCATION"].ToString();

                // Check columns existence before reading
                string authPaRaw = result.Columns.Contains("AUTHPA") ? row["AUTHPA"].ToString() : string.Empty;
                string authPsaRaw = result.Columns.Contains("AUTHPSA") ? row["AUTHPSA"].ToString() : string.Empty;
                //string role = result.Columns.Contains("ROLE") ? row["ROLE"].ToString() : string.Empty;
                string role = "S";
                // Assign to controls
                txtId.Value = result.Columns.Contains("ID") ? row["ID"].ToString() : string.Empty;
                txtPlant.Text = plant;
                txtPa.Text = pa;
                txtPsa.Text = psa;
                ddlEmpRole.SelectedValue = role;
                ddlEmployee.SelectedValue = selectedEmpId;

                // Bind PA dropdown and preselect
                BindAuthPaDropdown(selectedEmpId);

                var authPaList = authPaRaw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(p => p.Trim().Trim('\'')).ToList();

                foreach (RadComboBoxItem item in ddlAuthPa.Items)
                {
                    if (authPaList.Contains(item.Value))
                        item.Checked = true;
                }

                // Bind PSA dropdown based on selected PA and preselect
                var authPsaList = authPsaRaw.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(p => p.Trim().Trim('\'')).ToList();

                BindAuthPsaDropdown(authPaList, authPsaList);
            }
            else
            {
                // Clear controls if no data
                txtPlant.Text = string.Empty;
                txtPa.Text = string.Empty;
                txtPsa.Text = string.Empty;
                ddlEmpRole.SelectedValue = "";
                txtId.Value = string.Empty;
                ddlEmployee.SelectedValue = "";

                ddlAuthPa.ClearSelection();
                ddlAuthPa.Items.Clear();

                ddlAuthPsa.ClearSelection();
                ddlAuthPsa.Items.Clear();
            }
        }
        private void ResetFormFields()
        {
            txtId.Value = string.Empty;

            ddlEmployee.ClearSelection();
            ddlEmployee.Text = "";

            txtPlant.Text = "";
            txtPa.Text = "";
            txtPsa.Text = "";
            ddlEmpRole.SelectedValue = "";

            foreach (RadComboBoxItem item in ddlAuthPa.Items)
            {
                item.Checked = false;
            }

            ddlAuthPsa.Items.Clear(); // Clear PSA when PA is cleared
        }
        private string GetUserAuthPernr(string Id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select pernr from M_USERAUTH where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", Id);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }


        //private string GetPSAByEmployeeId(string empId)
        //{
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT PSA FROM Employees WHERE EmployeeID = @empId", conn);
        //        cmd.Parameters.AddWithValue("@empId", empId);
        //        conn.Open();
        //        object result = cmd.ExecuteScalar();
        //        return result != null ? result.ToString() : string.Empty;
        //    }
        //}
    }
}