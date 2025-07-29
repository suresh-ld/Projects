using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace GOVTSTATEDET
{
    public partial class ViewBeneficiary : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["statedetail"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null || Session["RegistrationID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                lblMessage.Text = "Please enter a valid User Registration ID.";
                GridViewEnrolments.DataSource = null;
                GridViewEnrolments.DataBind();
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            child_id, 
                            child_name, 
                            CONCAT('Father: ', father_name, ', Mother: ', mother_name, ', Address: ', address) AS ParentsDetails,
                            status 
                        FROM t_children_details 
                        WHERE registration_id  = @RegistrationID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RegistrationID", userId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridViewEnrolments.DataSource = dt;
                        GridViewEnrolments.DataBind();
                        lblMessage.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "No enrolments found for this Registration ID.";
                        GridViewEnrolments.DataSource = null;
                        GridViewEnrolments.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }

            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashBoard.aspx");
        }

    }
}
