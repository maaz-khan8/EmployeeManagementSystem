using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Admin
{
    public partial class EmployeeList : Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeData();
            }
        }

        private void BindEmployeeData()
        {
            gvEmployees.DataSource = dataAccess.GetAllEmployees();
            gvEmployees.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Show the form for adding a new employee
            pnlEmployeeList.Visible = false;
            pnlEmployeeForm.Visible = true;
            litFormTitle.Text = "Add New Employee";

            // Clear form fields
            hdnEmployeeID.Value = "0";
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
            txtDesignation.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtJoiningDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ddlRole.SelectedIndex = 0;
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                int employeeID = Convert.ToInt32(e.CommandArgument);
                EmployeeInfo employee = dataAccess.GetEmployeeByID(employeeID);

                if (employee != null)
                {
                    // Show the form for editing an employee
                    pnlEmployeeList.Visible = false;
                    pnlEmployeeForm.Visible = true;
                    litFormTitle.Text = "Edit Employee";

                    // Populate form fields
                    hdnEmployeeID.Value = employee.EmployeeID.ToString();
                    txtName.Text = employee.Name;
                    txtEmail.Text = employee.Email;
                    ddlDepartment.SelectedValue = employee.Department;
                    txtDesignation.Text = employee.Designation;
                    txtSalary.Text = employee.Salary.ToString();
                    txtJoiningDate.Text = employee.JoiningDate.ToString("yyyy-MM-dd");
                    txtUsername.Text = employee.Username;
                    txtPassword.Text = string.Empty; 
                    ddlRole.SelectedValue = employee.Role;
                }
            }
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            dataAccess.DeleteEmployee(employeeID);
            BindEmployeeData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(hdnEmployeeID.Value);

            EmployeeInfo employee = new EmployeeInfo
            {
                EmployeeID = employeeID,
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Department = ddlDepartment.SelectedValue,
                Designation = txtDesignation.Text.Trim(),
                Salary = Convert.ToDecimal(txtSalary.Text.Trim()),
                JoiningDate = Convert.ToDateTime(txtJoiningDate.Text),
                Username = txtUsername.Text.Trim(),
                Role = ddlRole.SelectedValue
            };

            if (employeeID == 0) // New employee
            {
                employee.Password = txtPassword.Text.Trim();
                dataAccess.AddEmployee(employee);
            }
            else // Existing employee
            {
                // Only update password if a new one is provided
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    employee.Password = txtPassword.Text.Trim();
                }
                else
                {
                    // Get the current password if no new one is provided
                    EmployeeInfo existingEmployee = dataAccess.GetEmployeeByID(employeeID);
                    if (existingEmployee != null)
                    {
                        employee.Password = existingEmployee.Password;
                    }
                }

                dataAccess.UpdateEmployee(employee);
            }

            // Return to the employee list
            pnlEmployeeForm.Visible = false;
            pnlEmployeeList.Visible = true;
            BindEmployeeData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Return to the employee list without saving
            pnlEmployeeForm.Visible = false;
            pnlEmployeeList.Visible = true;
        }
    }
}
