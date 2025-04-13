using System;
using System.Collections.Generic;
using System.Web.UI;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Employee
{
    public partial class Dashboard : Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeData();
                LoadAnnouncements();
            }
        }

        private void LoadEmployeeData()
        {
            string username = Context.User.Identity.Name;
            EmployeeInfo employee = dataAccess.GetEmployeeByUsername(username);

            if (employee != null)
            {
                litEmployeeName.Text = employee.Name;
                litName.Text = employee.Name;
                litEmail.Text = employee.Email;
                litDepartment.Text = employee.Department;
                litDesignation.Text = employee.Designation;
                litJoiningDate.Text = employee.JoiningDate.ToString("MMMM dd, yyyy");
            }
        }

        private void LoadAnnouncements()
        {
            List<Announcement> announcements = dataAccess.GetAnnouncements();

            if (announcements != null && announcements.Count > 0)
            {
                rptAnnouncements.DataSource = announcements;
                rptAnnouncements.DataBind();
                pnlNoAnnouncements.Visible = false;
            }
            else
            {
                rptAnnouncements.DataSource = null;
                rptAnnouncements.DataBind();
                pnlNoAnnouncements.Visible = true;
            }
        }
    }
}
