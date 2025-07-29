using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace BBOnline_Booking
{
    public partial class PrintReceipt : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bookingID = Request.QueryString["bookingID"];
                if (!string.IsNullOrEmpty(bookingID))
                {
                    LoadBookingDetails(bookingID);
                }
            }
        }

        private void LoadBookingDetails(string bookingID)
        {
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
                        GridViewPrint.DataSource = dt;
                        GridViewPrint.DataBind();
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooking.aspx");
        }
    }
}
