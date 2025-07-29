using System;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GOVTSTATEDET
{
    public partial class EnrolmentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEnrolmentData();
            }
        }

        private void LoadEnrolmentData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["statedetail"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        d.district_name AS `District Name`,
                        t.taluk_name AS `Taluk Name`,
                        c.child_id AS `Child ID`,
                        c.child_name AS `Child Name`,
                        CONCAT(c.father_name, ' & ', c.mother_name, ', ', c.address) AS `Parents Name and Address`,
                        CASE WHEN c.status = 'A' THEN 'Enrolled' ELSE 'Not Enrolled' END AS `Enrolment Status`
                    FROM 
                        t_children_details c
                    INNER JOIN mst_district d ON c.district_code = d.district_code
                    INNER JOIN mst_taluk t ON c.district_code = t.district_code AND c.taluk_code = t.taluk_code";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx"); 
        }
    }
}
