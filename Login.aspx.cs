using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["timeout"] == "true")
                {
                    lblMessage.Text = "Your session has expired. Please log in again.";
                }

                if (Request.IsAuthenticated)
                {
                    RedirectBasedOnRole();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            DataAccess dataAccess = new DataAccess();
            EmployeeInfo employee = dataAccess.AuthenticateUser(username, password);

            if (employee != null)
            {
                FormsAuthentication.SetAuthCookie(username, chkRememberMe.Checked);

                // Store user info in session
                Session["EmployeeID"] = employee.EmployeeID;
                Session["EmployeeName"] = employee.Name;
                Session["EmployeeRole"] = employee.Role;

                RedirectBasedOnRole();
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }

        private void RedirectBasedOnRole()
        {
            string role = Session["EmployeeRole"].ToString();

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
                default:
                    Response.Redirect("~/Login.aspx");
                    break;
            }
        }
    }
}
