using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.HR
{
    public partial class Dashboard : Page
    {
        private DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardData();
            }
        }

        private void LoadDashboardData()
        {
            // Load total employees
            int totalEmployees = dataAccess.GetTotalEmployees();
            litTotalEmployees.Text = totalEmployees.ToString();

            // Load department distribution
            Dictionary<string, int> departmentCounts = dataAccess.GetDepartmentCounts();
            DataTable dtDepartments = new DataTable();
            dtDepartments.Columns.Add("Department", typeof(string));
            dtDepartments.Columns.Add("Count", typeof(int));

            foreach (var dept in departmentCounts)
            {
                dtDepartments.Rows.Add(dept.Key, dept.Value);
            }

            gvDepartments.DataSource = dtDepartments;
            gvDepartments.DataBind();

            // Load announcements
            rptAnnouncements.DataSource = dataAccess.GetAnnouncements();
            rptAnnouncements.DataBind();
        }

        protected void btnAddAnnouncement_Click(object sender, EventArgs e)
        {
            Announcement announcement = new Announcement
            {
                Title = txtTitle.Text.Trim(),
                Content = txtContent.Text.Trim(),
                PostedDate = DateTime.Now,
                PostedBy = Context.User.Identity.Name
            };

            dataAccess.AddAnnouncement(announcement);

            // Clear form fields
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;

            // Reload dashboard data
            LoadDashboardData();

            // Add client-side script to close the modal
            ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "$('#announcementModal').modal('hide');", true);
        }
    }
}
