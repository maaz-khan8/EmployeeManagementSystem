using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.HR
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            List<EmployeeInfo> allEmployees = dataAccess.GetAllEmployees();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var filteredEmployees = allEmployees.Where(emp =>
                    emp.Name.ToLower().Contains(searchTerm) ||
                    emp.Department.ToLower().Contains(searchTerm)).ToList();

                gvEmployees.DataSource = filteredEmployees;
            }
            else
            {
                gvEmployees.DataSource = allEmployees;
            }

            gvEmployees.DataBind();
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
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(hdnEmployeeID.Value);
            EmployeeInfo existingEmployee = dataAccess.GetEmployeeByID(employeeID);

            if (existingEmployee != null)
            {
                existingEmployee.Name = txtName.Text.Trim();
                existingEmployee.Email = txtEmail.Text.Trim();
                existingEmployee.Department = ddlDepartment.SelectedValue;
                existingEmployee.Designation = txtDesignation.Text.Trim();
                existingEmployee.Salary = Convert.ToDecimal(txtSalary.Text.Trim());
                existingEmployee.JoiningDate = Convert.ToDateTime(txtJoiningDate.Text);

                dataAccess.UpdateEmployee(existingEmployee);

                // Return to the employee list
                pnlEmployeeForm.Visible = false;
                BindEmployeeData();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Return to the employee list without saving
            pnlEmployeeForm.Visible = false;
        }
    }
}
