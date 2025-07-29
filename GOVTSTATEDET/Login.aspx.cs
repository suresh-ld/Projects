using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace GOVTSTATEDET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string regId = txtRegId.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["statedetail"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT registration_id, name FROM user_master WHERE registration_id = @regId AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@regId", regId);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Session["RegistrationID"] = reader["registration_id"].ToString();
                        Session["User"] = reader["name"].ToString();

                        Response.Redirect("DashBoard.aspx");
                    }
                    else
                    {
                        string script = "if(confirm('User not found. Do you want to register?')) { window.location='UserRegistration.aspx'; }";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registerPrompt", script, true);
                    }
                }
            }
        }

        protected void btnNewReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRegistration.aspx");
        }
    }
}
