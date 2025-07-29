using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Web.UI;

namespace BBOnline_Booking
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void new_register(object sender, EventArgs e)
        {
            string UserID = useridtxt.Text.Trim();
            string Name = nametxt.Text.Trim();
            string Gender = male.Checked ? "M" : female.Checked ? "F" : "";
            string Phone = phnotxt.Text.Trim();
            string Address = addtxt.Text.Trim();
            string Email = emailtxt.Text.Trim();
            string Password = passwordtxt.Text;
            string ConfirmPassword = confirmpasswordtext.Text;
            DateTime DOB = DateTime.Parse(dobtxt.Text.Trim());
        

            string connectionString = ConfigurationManager.ConnectionStrings["BBOnline"].ConnectionString;

            if (DOB > DateTime.Today)
            {
                lblMessage.Text = "Invalid or future Date of Birth.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (Phone.Length != 10)
            {
                lblMessage.Text = "Enter a valid 10-digit phone number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            
            if (string.IsNullOrWhiteSpace(Password))
            {
                lblMessage.Text = "Password cannot be empty.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (Password != ConfirmPassword)
            {
                lblMessage.Text = "Password and Confirm Password do not match.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM mst_users WHERE user_id = @UserID", conn);
                    checkCmd.Parameters.AddWithValue("@UserID", UserID);
                    int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        lblMessage.Text = "User ID already exists. Please choose a different one.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    MySqlCommand insertCmd = new MySqlCommand(@"INSERT INTO mst_users 
                        (user_id, name, dob, gender, phone_no, address, email, password)
                        VALUES (@UserID, @Name, @DOB, @Gender, @Phone, @Address, @Email, @Password)", conn);

                    insertCmd.Parameters.AddWithValue("@UserID", UserID);
                    insertCmd.Parameters.AddWithValue("@Name", Name);
                    insertCmd.Parameters.AddWithValue("@DOB", DOB);
                    insertCmd.Parameters.AddWithValue("@Gender", Gender);
                    insertCmd.Parameters.AddWithValue("@Phone", Phone);
                    insertCmd.Parameters.AddWithValue("@Address", Address);
                    insertCmd.Parameters.AddWithValue("@Email", Email);
                    insertCmd.Parameters.AddWithValue("@Password", Password); 

                    int rowsInserted = insertCmd.ExecuteNonQuery();

                    if (rowsInserted > 0)
                    {
                        lblMessage.Text = "User registered successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Registration failed. Please try again.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
           
        }

        private void ClearForm()
        {
            nametxt.Text = "";
            dobtxt.Text = "";
            phnotxt.Text = "";
            addtxt.Text = "";
            emailtxt.Text = "";
            useridtxt.Text = "";
            passwordtxt.Text = "";
            confirmpasswordtext.Text = "";
            male.Checked = false;
            female.Checked = false;
        }

      
    }
}


