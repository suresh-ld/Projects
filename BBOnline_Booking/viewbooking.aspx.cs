using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace BBOnline_Booking
{
    public partial class viewbooking : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewReceipt.Visible = false;
                lblStatus.Text = "";
            }
        }

        protected void viewbookbut_Click(object sender, EventArgs e)
        {
            string bookingID = viewbookidtext.Text.Trim();

            if (string.IsNullOrEmpty(bookingID))
            {
                lblStatus.Text = "Please enter a Booking ID.";
                GridViewReceipt.Visible = false;
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"SELECT 
                                    b.booking_id,
                                    a.activity_name,
                                    DATE_FORMAT(b.booking_date, '%d-%m-%Y') AS booking_date,
                                    b.booking_name,
                                    p.proof_description,
                                    b.proof_number,
                                    a.activity_amount
                                FROM t_booking b
                                INNER JOIN mst_activity a ON b.activity_code = a.activity_code
                                INNER JOIN mst_id_proof p ON b.proof_code = p.proof_code
                                WHERE b.booking_id = @bookingID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookingID", bookingID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridViewReceipt.DataSource = dt;
                        GridViewReceipt.DataBind();
                        GridViewReceipt.Visible = true;
                        lblStatus.Text = "";
                    }
                    else
                    {
                        GridViewReceipt.Visible = false;
                        lblStatus.Text = "No record found for the given Booking ID.";
                    }
                }
            }
        }

        protected void viewbackbut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void printbut_Click(object sender, EventArgs e)
        {
            string bookingID = viewbookidtext.Text.Trim();
            if (!string.IsNullOrEmpty(bookingID))
            {
                Response.Redirect("PrintReceipt.aspx?bookingID=" + bookingID);
            }
            else
            {
                lblStatus.Text = "Please enter a Booking ID before printing.";
            }
        }
    }
}
