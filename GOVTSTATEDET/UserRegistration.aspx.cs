using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace GOVTSTATEDET
{
    public partial class _Default : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["statedetail"].ConnectionString;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string gender = rbMale.Checked ? "M" : rbFemale.Checked ? "F" : "";
            string mobile = txtMobile.Text.Trim();

            if (!DateTime.TryParse(txtDOB.Text, out DateTime dob) || dob > DateTime.Today)
            {
                lblMessage.Text = "Invalid or future Date of Birth.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (mobile.Length != 10 || !long.TryParse(mobile, out _))
            {
                lblMessage.Text = "Enter a valid 10-digit Mobile Number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM user_master WHERE mobile = @mobile", con);
                checkCmd.Parameters.AddWithValue("@mobile", mobile);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Mobile number already registered.');", true);
                    return;
                }

                MySqlCommand getMaxCmd = new MySqlCommand("SELECT MAX(registration_id) FROM user_master", con);
                object maxIdObj = getMaxCmd.ExecuteScalar();

                int newSlno = 1;
                if (maxIdObj != DBNull.Value && maxIdObj != null)
                {
                    string maxRegnId = maxIdObj.ToString();
                    if (maxRegnId.StartsWith("REGN") && int.TryParse(maxRegnId.Substring(4), out int lastSlno))
                    {
                        newSlno = lastSlno + 1;
                    }
                }

                string regnId = "REGN" + newSlno.ToString("D6");

                MySqlCommand insertCmd = new MySqlCommand(@"INSERT INTO user_master 
                    (registration_id, name, dob, gender, mobile, regn_dt, password)
                    VALUES (@regn_id, @name, @dob, @gender, @mobile, @regn_dt, @password)", con);

                insertCmd.Parameters.AddWithValue("@regn_id", regnId);
                insertCmd.Parameters.AddWithValue("@name", name);
                insertCmd.Parameters.AddWithValue("@dob", dob);
                insertCmd.Parameters.AddWithValue("@gender", gender);
                insertCmd.Parameters.AddWithValue("@mobile", mobile);
                insertCmd.Parameters.AddWithValue("@regn_dt", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@password", regnId);

                insertCmd.ExecuteNonQuery();

                lblMessage.Text = $"Registration successful! Your Registration ID is {regnId}.";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                txtName.Text = "";
                txtDOB.Text = "";
                txtMobile.Text = "";
                rbMale.Checked = false;
                rbFemale.Checked = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
