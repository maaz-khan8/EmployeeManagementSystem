using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EmployeeManagementSystem.Models
{
    public class DataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EMSConnectionString"].ConnectionString;

        // User Authentication Methods
        public EmployeeInfo AuthenticateUser(string username, string password)
        {
            EmployeeInfo employee = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new EmployeeInfo
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Department = reader["Department"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in AuthenticateUser: " + ex.Message);
                }
            }

            return employee;
        }

        public string GetUserRole(string username)
        {
            string role = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Role FROM Employees WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        role = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetUserRole: " + ex.Message);
                }
            }

            return role;
        }

        // Employee CRUD Operations
        public List<EmployeeInfo> GetAllEmployees()
        {
            List<EmployeeInfo> employees = new List<EmployeeInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new EmployeeInfo
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Department = reader["Department"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetAllEmployees: " + ex.Message);
                }
            }

            return employees;
        }

        public EmployeeInfo GetEmployeeByID(int employeeID)
        {
            EmployeeInfo employee = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new EmployeeInfo
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Department = reader["Department"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetEmployeeByID: " + ex.Message);
                }
            }

            return employee;
        }

        public EmployeeInfo GetEmployeeByUsername(string username)
        {
            EmployeeInfo employee = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new EmployeeInfo
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Department = reader["Department"].ToString(),
                            Designation = reader["Designation"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetEmployeeByUsername: " + ex.Message);
                }
            }

            return employee;
        }

        public void AddEmployee(EmployeeInfo employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role) " +
                    "VALUES (@Name, @Email, @Department, @Designation, @Salary, @JoiningDate, @Username, @Password, @Role)", connection);

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@Role", employee.Role);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in AddEmployee: " + ex.Message);
                }
            }
        }

        public void UpdateEmployee(EmployeeInfo employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql;

                if (!string.IsNullOrEmpty(employee.Password))
                {
                    // Update including password
                    sql = "UPDATE Employees SET Name = @Name, Email = @Email, Department = @Department, " +
                          "Designation = @Designation, Salary = @Salary, JoiningDate = @JoiningDate, " +
                          "Username = @Username, Password = @Password, Role = @Role WHERE EmployeeID = @EmployeeID";
                }
                else
                {
                    // Update without changing password
                    sql = "UPDATE Employees SET Name = @Name, Email = @Email, Department = @Department, " +
                          "Designation = @Designation, Salary = @Salary, JoiningDate = @JoiningDate, " +
                          "Username = @Username, Role = @Role WHERE EmployeeID = @EmployeeID";
                }

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@Role", employee.Role);

                if (!string.IsNullOrEmpty(employee.Password))
                {
                    command.Parameters.AddWithValue("@Password", employee.Password);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in UpdateEmployee: " + ex.Message);
                    Debug.WriteLine("SQL: " + sql);
                    Debug.WriteLine("EmployeeID: " + employee.EmployeeID);
                }
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in DeleteEmployee: " + ex.Message);
                }
            }
        }

        // Dashboard Statistics
        public int GetTotalEmployees()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);

                try
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetTotalEmployees: " + ex.Message);
                }
            }

            return count;
        }

        public Dictionary<string, int> GetDepartmentCounts()
        {
            Dictionary<string, int> departmentCounts = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Department, COUNT(*) as Count FROM Employees GROUP BY Department", connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string department = reader["Department"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);
                        departmentCounts.Add(department, count);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetDepartmentCounts: " + ex.Message);
                }
            }

            return departmentCounts;
        }

        // Announcements
        public List<Announcement> GetAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Announcements ORDER BY PostedDate DESC", connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        announcements.Add(new Announcement
                        {
                            AnnouncementID = Convert.ToInt32(reader["AnnouncementID"]),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            PostedDate = Convert.ToDateTime(reader["PostedDate"]),
                            PostedBy = reader["PostedBy"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in GetAnnouncements: " + ex.Message);
                }
            }

            return announcements;
        }

        public void AddAnnouncement(Announcement announcement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Announcements (Title, Content, PostedDate, PostedBy) " +
                    "VALUES (@Title, @Content, @PostedDate, @PostedBy)", connection);

                command.Parameters.AddWithValue("@Title", announcement.Title);
                command.Parameters.AddWithValue("@Content", announcement.Content);
                command.Parameters.AddWithValue("@PostedDate", announcement.PostedDate);
                command.Parameters.AddWithValue("@PostedBy", announcement.PostedBy);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in AddAnnouncement: " + ex.Message);
                }
            }
        }
    }
}
