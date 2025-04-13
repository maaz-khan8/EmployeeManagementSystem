using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace EmployeeManagementSystem.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EMSConnectionString"].ConnectionString;

        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrEmpty(username))
                return new string[] { };

            string[] roles = new string[1];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Role FROM Employees WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                string role = command.ExecuteScalar() as string;

                if (!string.IsNullOrEmpty(role))
                {
                    roles[0] = role;
                }
            }

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE Username = @Username AND Role = @Role", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Role", roleName);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
