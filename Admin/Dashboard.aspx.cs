using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Admin
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
           
            int totalEmployees = dataAccess.GetTotalEmployees();
            litTotalEmployees.Text = totalEmployees.ToString();

           
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

           
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;

            // Reload dashboard data
            LoadDashboardData();

            // Add client-side script to close the modal
            ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "$('#announcementModal').modal('hide');", true);
        }
    }
}
