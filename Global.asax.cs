using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace EmployeeManagementSystem
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Map jQuery manually
            ScriptResourceDefinition jqueryDef = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.6.0.min.js", // Adjust the path if you have a different version
                DebugPath = "~/Scripts/jquery-3.6.0.js",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.6.0.min.js",
                CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.6.0.js",
                CdnSupportsSecureConnection = true
            };

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jqueryDef);

            // Set up the database file
            string dbFileName = "EmployeeManagementDB.mdf";
            string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string dbFilePath = Path.Combine(dataDirectory, dbFileName);

            if (!File.Exists(dbFilePath))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EMSConnectionString"].ConnectionString;
                CreateDatabase(connectionString);
            }
        }

        private void CreateDatabase(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create Employees table
                    string createEmployeesTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE [dbo].[Employees] (
                            [EmployeeID] INT IDENTITY(1,1) PRIMARY KEY,
                            [Name] NVARCHAR(100) NOT NULL,
                            [Email] NVARCHAR(100) NOT NULL,
                            [Department] NVARCHAR(50) NOT NULL,
                            [Designation] NVARCHAR(100) NOT NULL,
                            [Salary] DECIMAL(18,2) NOT NULL,
                            [JoiningDate] DATE NOT NULL,
                            [Username] NVARCHAR(50) NOT NULL UNIQUE,
                            [Password] NVARCHAR(100) NOT NULL,
                            [Role] NVARCHAR(20) NOT NULL
                        )
                    END";

                    using (SqlCommand command = new SqlCommand(createEmployeesTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create Announcements table
                    string createAnnouncementsTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Announcements]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE [dbo].[Announcements] (
                            [AnnouncementID] INT IDENTITY(1,1) PRIMARY KEY,
                            [Title] NVARCHAR(200) NOT NULL,
                            [Content] NVARCHAR(MAX) NOT NULL,
                            [PostedDate] DATETIME NOT NULL,
                            [PostedBy] NVARCHAR(100) NOT NULL
                        )
                    END";

                    using (SqlCommand command = new SqlCommand(createAnnouncementsTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertAdmin = @"
                    IF NOT EXISTS (SELECT * FROM [dbo].[Employees] WHERE [Username] = 'admin')
                    BEGIN
                        INSERT INTO [dbo].[Employees] ([Name], [Email], [Department], [Designation], [Salary], [JoiningDate], [Username], [Password], [Role])
                        VALUES ('Admin User', 'admin@company.com', 'Administration', 'System Administrator', 100000.00, '2023-01-01', 'admin', 'admin123', 'Admin')
                    END";

                    using (SqlCommand command = new SqlCommand(insertAdmin, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertHR = @"
                    IF NOT EXISTS (SELECT * FROM [dbo].[Employees] WHERE [Username] = 'hrmanager')
                    BEGIN
                        INSERT INTO [dbo].[Employees] ([Name], [Email], [Department], [Designation], [Salary], [JoiningDate], [Username], [Password], [Role])
                        VALUES ('HR Manager', 'hr@company.com', 'HR', 'HR Manager', 80000.00, '2023-01-15', 'hrmanager', 'hr123', 'HR')
                    END";

                    using (SqlCommand command = new SqlCommand(insertHR, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertEmployee1 = @"
                    IF NOT EXISTS (SELECT * FROM [dbo].[Employees] WHERE [Username] = 'johndoe')
                    BEGIN
                        INSERT INTO [dbo].[Employees] ([Name], [Email], [Department], [Designation], [Salary], [JoiningDate], [Username], [Password], [Role])
                        VALUES ('John Doe', 'john@company.com', 'IT', 'Software Developer', 75000.00, '2023-02-01', 'johndoe', 'john123', 'Employee')
                    END";

                    using (SqlCommand command = new SqlCommand(insertEmployee1, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertAnnouncement = @"
                    IF NOT EXISTS (SELECT * FROM [dbo].[Announcements])
                    BEGIN
                        INSERT INTO [dbo].[Announcements] ([Title], [Content], [PostedDate], [PostedBy])
                        VALUES ('Welcome to the Employee Management System', 'We are excited to launch our new Employee Management System. This system will help us manage employee records more efficiently.', '2023-04-01 10:00:00', 'admin')
                    END";

                    using (SqlCommand command = new SqlCommand(insertAnnouncement, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating database: " + ex.Message);
            }
        }
    }
}
