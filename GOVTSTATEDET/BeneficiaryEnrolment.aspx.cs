using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace GOVTSTATEDET
{
    public partial class BeneficiaryEnrolment : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["statedetail"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["RegistrationID"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                string regId = Session["RegistrationID"].ToString();
                lblRegID.Text = regId;

                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    string query = "SELECT name FROM user_master WHERE registration_id = @regid";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@regid", regId);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    lblUserName.Text = result != null ? result.ToString() : "(User not found)";
                }

                LoadDropDown(ddlDistrict, "SELECT district_code, district_name FROM mst_district", "district_name", "district_code");
                LoadDropDown(ddlTaluk, "SELECT taluk_code, taluk_name FROM mst_taluk", "taluk_name", "taluk_code");
                LoadDropDown(ddlCategory, "SELECT category_code, category_name FROM mst_category", "category_name", "category_code");
            }
        }

        private void LoadDropDown(System.Web.UI.WebControls.DropDownList ddl, string query, string textField, string valueField)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                con.Open();
                ddl.DataSource = cmd.ExecuteReader();
                ddl.DataTextField = textField;
                ddl.DataValueField = valueField;
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }

        protected void btnSubmit_Click_save(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            if (BPLExists(txtBPLCard.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Already Enrolled!');", true);
                return;
            }

            if (!int.TryParse(txtIncome.Text, out int income) || income < 0 || income > 12000)
            {
                lblMsg.Text = "Invalid Income! Should be between 0 and 12000.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!DateTime.TryParse(txtDOB.Text, out DateTime dob) || dob > DateTime.Now)
            {
                lblMsg.Text = "Invalid DOB! Cannot be a future date.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string childID = GenerateChildID();

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                string query = @"INSERT INTO t_children_details
                (registration_id, child_id, district_code, taluk_code, child_name, child_dob, bpl_card_number,
                 father_name, family_income, mother_name, category, address, status, entered_on, updated_on)
                VALUES
                (@regid, @childid, @dist, @taluk, @name, @dob, @bpl, @father, @income, @mother, @cat, @addr, 'A', NOW(), NOW())";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@regid", lblRegID.Text);
                cmd.Parameters.AddWithValue("@childid", childID);
                cmd.Parameters.AddWithValue("@dist", ddlDistrict.SelectedValue);
                cmd.Parameters.AddWithValue("@taluk", ddlTaluk.SelectedValue);
                cmd.Parameters.AddWithValue("@name", txtChildName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@bpl", txtBPLCard.Text.Trim());
                cmd.Parameters.AddWithValue("@father", txtFatherName.Text.Trim());
                cmd.Parameters.AddWithValue("@income", income);
                cmd.Parameters.AddWithValue("@mother", txtMotherName.Text.Trim());
                cmd.Parameters.AddWithValue("@cat", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = $"Successfully Registered! Child ID: {childID}";
                ClearForm();
            }
        }

        private bool BPLExists(string bplCard)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM t_children_details WHERE bpl_card_number = @bpl";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bpl", bplCard);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private string GenerateChildID()
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                string query = "SELECT IFNULL(MAX(CAST(SUBSTRING(child_id, 4) AS UNSIGNED)), 0) + 1 FROM t_children_details";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int nextID = Convert.ToInt32(cmd.ExecuteScalar());
                return "BEN" + nextID.ToString("D6");
            }
        }

        private void ClearForm()
        {
            txtChildName.Text = "";
            txtDOB.Text = "";
            txtBPLCard.Text = "";
            txtFatherName.Text = "";
            txtIncome.Text = "";
            txtMotherName.Text = "";
            txtAddress.Text = "";

            ddlDistrict.SelectedIndex = 0;
            ddlTaluk.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}
