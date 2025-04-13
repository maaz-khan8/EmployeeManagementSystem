using System;
using System.Web.UI;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Employee
{
    public partial class Profile : Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeProfile();
            }
        }

        private void LoadEmployeeProfile()
        {
            string username = Context.User.Identity.Name;
            EmployeeInfo employee = dataAccess.GetEmployeeByUsername(username);

            if (employee != null)
            {
                litEmployeeID.Text = employee.EmployeeID.ToString();
                litName.Text = employee.Name;
                litEmail.Text = employee.Email;
                litDepartment.Text = employee.Department;
                litDesignation.Text = employee.Designation;
                litJoiningDate.Text = employee.JoiningDate.ToString("MMMM dd, yyyy");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = Context.User.Identity.Name;
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            // Verify current password
            EmployeeInfo employee = dataAccess.AuthenticateUser(username, currentPassword);

            if (employee != null)
            {
                // Update password
                employee.Password = newPassword;
                dataAccess.UpdateEmployee(employee);

                // Clear form fields
                txtCurrentPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;

                // Show success message
                lblPasswordMessage.CssClass = "text-success";
                lblPasswordMessage.Text = "Password changed successfully.";

                // Add client-side script to close the modal after a delay
                ScriptManager.RegisterStartupScript(this, GetType(), "closeModal",
                    "setTimeout(function() { $('#changePasswordModal').modal('hide'); }, 2000);", true);
            }
            else
            {
                lblPasswordMessage.CssClass = "text-danger";
                lblPasswordMessage.Text = "Current password is incorrect.";
            }
        }
    }
}
