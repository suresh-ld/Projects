using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace BBOnline_Booking
{
    public partial class Report : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDistricts();
            }
        }

        private void LoadDistricts()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT district_code, district_name FROM mst_district", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                district_drop.DataSource = reader;
                district_drop.DataTextField = "district_name";
                district_drop.DataValueField = "district_code";
                district_drop.DataBind();
                district_drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            string districtCode = district_drop.SelectedValue;

            if (districtCode != "0")
            {
                BindReportGrid(districtCode);
            }
        }

        private void BindReportGrid(string districtCode)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        d.district_name,
                        u.name,
                        a.activity_name,
                        b.booking_date,
                        a.activity_amount
                    FROM
                        t_booking b
                    JOIN mst_users u ON b.user_id = u.user_id
                    JOIN mst_activity a ON b.activity_code = a.activity_code
                    JOIN mst_district d ON u.address LIKE CONCAT('%', d.district_name, '%')
                    WHERE d.district_code = @DistrictCode";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DistrictCode", districtCode);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewReport.DataSource = dt;
                GridViewReport.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

    }
}
