-- Create the database
CREATE DATABASE EmployeeManagementDB;
GO

USE EmployeeManagementDB;
GO

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Department NVARCHAR(50) NOT NULL,
    Designation NVARCHAR(100) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    JoiningDate DATE NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);
GO

-- Create Announcements table
CREATE TABLE Announcements (
    AnnouncementID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    PostedDate DATETIME NOT NULL,
    PostedBy NVARCHAR(100) NOT NULL
);
GO

-- Insert initial admin user
INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role)
VALUES ('Admin User', 'admin@company.com', 'Administration', 'System Administrator', 100000.00, '2023-01-01', 'admin', 'admin123', 'Admin');

-- Insert HR user
INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role)
VALUES ('HR Manager', 'hr@company.com', 'HR', 'HR Manager', 80000.00, '2023-01-15', 'hrmanager', 'hr123', 'HR');

-- Insert sample employees
INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role)
VALUES ('Maaz Khan', 'maaz@company.com', 'IT', 'Software Developer', 75000.00, '2023-02-01', 'maazkhan', 'maaz123', 'Employee');

INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role)
VALUES ('Saad Khan', 'saad@company.com', 'Marketing', 'Marketing Specialist', 65000.00, '2023-02-15', 'saadkhan', 'saad123', 'Employee');

INSERT INTO Employees (Name, Email, Department, Designation, Salary, JoiningDate, Username, Password, Role)
VALUES ('Ahmed Ali', 'ahmed@company.com', 'Finance', 'Financial Analyst', 70000.00, '2023-03-01', 'ahmedali', 'ahmed123', 'Employee');

-- Insert sample announcements
INSERT INTO Announcements (Title, Content, PostedDate, PostedBy)
VALUES ('Welcome to the Employee Management System', 'We are excited to launch our new Employee Management System. This system will help us manage employee records more efficiently.', '2023-04-01 10:00:00', 'admin');

INSERT INTO Announcements (Title, Content, PostedDate, PostedBy)
VALUES ('Company Picnic', 'We are organizing a company picnic next month. Please mark your calendars for the last Saturday of the month.', '2023-04-15 14:30:00', 'hrmanager');

INSERT INTO Announcements (Title, Content, PostedDate, PostedBy)
VALUES ('New Health Insurance Policy', 'We have updated our health insurance policy. Please check your email for details.', '2023-04-20 09:15:00', 'hrmanager');
GO
