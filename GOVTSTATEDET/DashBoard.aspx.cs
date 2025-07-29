using System;
using System.Web.UI;

namespace GOVTSTATEDET
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["RegistrationID"] != null)
                {
                    lblUser.Text = "Welcome, " + Session["User"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("BeneficiaryEnrolment.aspx");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBeneficiary.aspx");
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportViewer.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
