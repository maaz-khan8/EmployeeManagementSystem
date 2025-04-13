🧑‍💼 Employee Management System (ASP.NET Web Forms)
An Employee Management System built using ASP.NET Web Forms with a SQL Server backend. This web-based application enables HR and Admin users to efficiently manage employee data while maintaining secure access based on user roles.

🔍 Overview
This project was developed as part of an academic assignment to demonstrate:

**Role-based user authentication and authorization
**
Session management with timeout handling

CRUD operations using SQL Server

Master-child page architecture for modular web design

🎯 Functional Features
✅ User Roles & Authentication
Admin: Full access to manage all employee records

HR Manager: Can view and edit employee details

Employee: Can view only their own profile

Session-based login/logout with Forms Authentication

Unauthorized users are redirected to the login page

✅ Employee Management (CRUD)
Add, update, view, and delete employee records

Details include: Name, Email, Department, Designation, Salary, Joining Date

Employee records displayed using GridView with inline Edit/Delete

✅ Personalized Dashboards
Employee Dashboard: Displays profile & company announcements

Admin/HR Dashboard: Shows total employees and department-wise stats

✅ Web Architecture
Master Page: Common header, footer, and navigation

Content Pages: Modular content for employee list, dashboard, reports

✅ Session Management
20-minute session timeout

Session expiry warning before auto-logout

🛠️ Technologies Used
ASP.NET Web Forms (.NET Framework)

SQL Server

ADO.NET

C#

Visual Studio

HTML/CSS

📂 Project Structure
arduino
Copy
Edit
├── App_Code/
│   └── DataAccess.cs           // Handles DB interactions
├── Models/
│   └── EmployeeInfo.cs        // Employee model
├── Pages/
│   └── Login.aspx
│   └── Dashboard.aspx
│   └── EmployeeList.aspx
│   └── ...
├── Database/
│   └── CreateDatabase.sql     // SQL script for DB schema & seed data
├── Site.Master                // Master Page
└── Web.config                 // Configurations & connection strings


🚀 How to Run
Clone this repository.

Open the project in Visual Studio.

Update the Web.config with your SQL Server instance and connection string.

Run the CreateDatabase.sql file to create the database and seed data.

Run the application (F5) and login using seeded credentials.

🧪 Sample Credentials
Role	Username	Password
Admin	admin	admin123
HR	hr	hr123
Employee	emp1	emp123
⚠️ Update credentials and roles in the database after setup if needed.

📌 Future Improvements

Switch to ASP.NET MVC or Blazor

Implement password hashing and encryption

Add search & filter for employee records

Implement responsive design with Bootstrap

