using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBOnline_Booking
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["USERID"] != null && Session["NAME"] != null)
                {
                   Labelusr.Text = "Welcome, " + Session["NAME"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }

        }

        protected void new_book(object sender, EventArgs e)
        {
            Response.Redirect("Booking.aspx");
        }

        protected void view_book(object sender, EventArgs e)
        {
            Response.Redirect("viewbooking.aspx");
        }

        protected void report_sec(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}