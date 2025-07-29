using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace BBOnline_Booking
{
    public partial class Booking : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] != null && Session["NAME"] != null)
                {
                    name_label.Text = "User Name: " + Session["NAME"].ToString();
                    reg_label.Text = "Registration ID: " + Session["USERID"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                LoadDropDown(sel_drop, "SELECT activity_code, activity_name FROM mst_activity", "activity_name", "activity_code");
                LoadDropDown(dist_drop, "SELECT district_code, district_name FROM mst_district", "district_name", "district_code");
                LoadDropDown(id_drop, "SELECT proof_code, proof_description FROM mst_id_proof", "proof_description", "proof_code");
            }
        }

        protected void sel_drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT activity_amount FROM mst_activity WHERE activity_code = @code";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", sel_drop.SelectedValue);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            amount_text.Text = reader["activity_amount"].ToString();
                        }
                    }
                }
            }
        }

        protected void check_avail(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(date_txt.Text.Trim(), out DateTime DTE))
            {
                lblMsg.Text = "Please enter a valid date!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (DTE < DateTime.Today)
            {
                lblMsg.Text = "Invalid Date! Please select a future date.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (sel_drop.SelectedIndex == 0 || sel_drop.SelectedValue == "0")
            {
                lblMsg.Text = "Please select an activity!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM t_booking WHERE activity_code = @code AND booking_date = @date";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", sel_drop.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", DTE);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        lblMsg.Text = "Activity Already Booked.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        EnableControls(false);
                    }
                    else
                    {
                        lblMsg.Text = "Activity Available!";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        EnableControls(true);
                    }
                }
            }
        }

        protected void save_book(object sender, EventArgs e)
        {
            string booking_id = GeneratebookingID();
            string activityCode = sel_drop.SelectedValue;
            string bookingDate = date_txt.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM t_booking WHERE activity_code = @code AND booking_date = @date";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@code", activityCode);
                    checkCmd.Parameters.AddWithValue("@date", bookingDate);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        lblMsg.Text = "Activity already booked for selected date.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                string insert_query = @"INSERT INTO t_booking 
                    (activity_code, booking_date, booking_id, user_id, booking_name, proof_code, proof_number, gender, age, address, entered_on, updated_on)
                    VALUES 
                    (@activity_code, @booking_date, @booking_id, @user_id, @booking_name, @proof_code, @proof_number, @gender, @age, @address, NOW(), NOW())";

                using (MySqlCommand cmd = new MySqlCommand(insert_query, conn))
                {
                    cmd.Parameters.AddWithValue("@activity_code", activityCode);
                    cmd.Parameters.AddWithValue("@booking_date", bookingDate);
                    cmd.Parameters.AddWithValue("@booking_id", booking_id);
                    cmd.Parameters.AddWithValue("@user_id", Session["USERID"].ToString());
                    cmd.Parameters.AddWithValue("@booking_name", per_text.Text.Trim());
                    cmd.Parameters.AddWithValue("@proof_code", id_drop.SelectedValue);
                    cmd.Parameters.AddWithValue("@proof_number", idnum_text.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", RadioButton1.Checked ? "M" : "F");
                    cmd.Parameters.AddWithValue("@age", age_text.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", add_text.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        lblMsg.Text = "Booking successful! Booking ID: " + booking_id;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        EnableControls(false);
                        ClearFields();
                    }
                    else
                    {
                        lblMsg.Text = "Booking failed!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        

        private string GeneratebookingID()
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                string query = "SELECT IFNULL(MAX(CAST(SUBSTRING(booking_id, 4) AS UNSIGNED)), 0) + 1 FROM t_booking";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int nextID = Convert.ToInt32(cmd.ExecuteScalar());
                return "BBO" + nextID.ToString("D4");
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

        private void EnableControls(bool enable)
        {
            dist_label.Enabled = enable;
            dist_drop.Enabled = enable;
            per_label.Enabled = enable;
            per_text.Enabled = enable;
            id_label.Enabled = enable;
            id_drop.Enabled = enable;
            idnum_label.Enabled = enable;
            idnum_text.Enabled = enable;
            gend_label.Enabled = enable;
            RadioButton1.Enabled = enable;
            RadioButton2.Enabled = enable;
            age_label.Enabled = enable;
            age_text.Enabled = enable;
            add_label.Enabled = enable;
            add_text.Enabled = enable;
            amount_label.Enabled = enable;
            amount_text.Enabled = enable;
            save_but.Enabled = enable;
        }
        private void ClearFields()
        {
            idnum_text.Text = string.Empty;
            per_text.Text = string.Empty;
            age_text.Text = string.Empty;
            amount_text.Text = string.Empty;
            add_text.Text = string.Empty;
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;

            if (dist_drop.Items.Count > 0)
                dist_drop.SelectedIndex = 0;

            if (id_drop.Items.Count > 0)
                id_drop.SelectedIndex = 0;
        }
        protected void back_but_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}
