# 🧑‍💼 Employee Management System (ASP.NET Web Forms)

A role-based **Employee Management System** built using **ASP.NET Web Forms** and **SQL Server**, designed for HR and Admin users to manage employee records with secure access, personalized dashboards, and session control.

## 📚 Project Overview

This system demonstrates key web application concepts including:

- Role-based authentication & authorization
- CRUD operations with SQL Server
- Session management with timeout control
- Modular design using Master and Content pages

---

## 🚀 Features

### 🔐 User Authentication & Authorization

- **Login & Logout** functionality using **Forms Authentication**
- Role-based access:
  - **Admin**: Full access to all employee records
  - **HR Manager**: Can view and update employee details
  - **Employee**: Can view their own profile only
- Unauthorized access redirects to the login page

### 📄 Employee Management (CRUD)

- Create, Read, Update, Delete (CRUD) operations for employee records
- Stores fields: `Name`, `Email`, `Department`, `Designation`, `Salary`, `Joining Date`
- Uses `GridView` for interactive data display and management

### 🖥️ Dashboards

- **Employee Dashboard**: View personal profile and announcements
- **HR/Admin Dashboard**: Overview of total employees and department stats

### 🧭 Master & Content Pages

- Reusable **Master Page** with a consistent header, footer, and navigation
- Separate **Content Pages** for each module (e.g., Dashboard, Employee List)

### ⏲️ Session Management

- Session timeout after **20 minutes** of inactivity
- Optional: Warning message before auto-logout

---

## 🛠️ Tech Stack

- **ASP.NET Web Forms** (.NET Framework)
- **SQL Server** (Relational Database)
- **ADO.NET** (Database Access)
- **HTML/CSS** (Frontend)
- **Visual Studio** (Development Environment)

---

## 📂 Project Structure

EmployeeManagementSystem/ ├── App_Code/ │ └── DataAccess.cs # Handles DB operations ├── Models/ │ └── EmployeeInfo.cs # Employee model class ├── Pages/ │ ├── Login.aspx │ ├── Dashboard.aspx │ ├── EmployeeList.aspx │ └── ... ├── Database/ │ └── CreateDatabase.sql # SQL script to create and seed database ├── Site.Master # Master layout page └── Web.config # Configuration file

---
### Prerequisites
- Visual Studio (with ASP.NET support)
- SQL Server (Express or full version)
- .NET Framework

### Steps to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/employee-management-system.git
2. Open in Visual Studio

3. Run the SQL Script

    Open Database/CreateDatabase.sql in SQL Server Management Studio (SSMS)

    Execute to create the database and tables

4. Configure Connection String

    In Web.config, update your SQL Server instance:
      <connectionStrings>
        <add name="YourConnectionStringName"
           connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"
           providerName="System.Data.SqlClient" />
      </connectionStrings>

5. Run the project

    Press F5 in Visual Studio or use the "Start Debugging" button

🧪 Sample User Credentials
    Role	Username	Password
    Admin	admin	admin123
      HR	hr	hr123
  Employee	emp1	emp123
