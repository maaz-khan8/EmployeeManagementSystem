using System;
using System.Web.UI;

namespace EmployeeManagementSystem
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                string role = Session["EmployeeRole"]?.ToString();

                switch (role)
                {
                    case "Admin":
                        Response.Redirect("~/Admin/Dashboard.aspx");
                        break;
                    case "HR":
                        Response.Redirect("~/HR/Dashboard.aspx");
                        break;
                    case "Employee":
                        Response.Redirect("~/Employee/Dashboard.aspx");
                        break;
                }
            }
        }
    }
}
