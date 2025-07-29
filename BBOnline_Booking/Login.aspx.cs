using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace BBOnline_Booking
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_button(object sender,EventArgs e)
        {
            string userid = user.Text.Trim();
            string password_id = pass.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();


                string query = "SELECT user_id,name FROM mst_users WHERE user_id=@USER AND password=@PASSWORD";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@USER", userid);
                cmd.Parameters.AddWithValue("@PASSWORD", password_id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Session["USERID"] = reader["user_id"].ToString();
                        Session["NAME"] = reader["name"].ToString();

                        Response.Redirect("Dashboard.aspx");
                        conn.Close();
                    }
                    else
                    {
                        string script = "if(confirm('User Not Found! Do You Want To Register')) {window.location='UserRegister.aspx'} ";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registerPrompt", script, true);
                    }
                }

            }
            
        }

        protected void new_button(object sender,EventArgs e)
        {
            Response.Redirect("UserRegister.aspx");
        }

    }
}
