using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace EmployeeManagementSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string userRole = Roles.GetRolesForUser(Context.User.Identity.Name)[0];

                AdminMenu.Visible = userRole == "Admin";
                HRMenu.Visible = userRole == "HR";
                EmployeeMenu.Visible = userRole == "Employee";
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
