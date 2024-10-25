-- Scaffold-DbContext "Server=.;Database=InfonetDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

USE master
GO

CREATE DATABASE FloraEmployeeDB
GO

USE FloraEmployeeDB
GO

CREATE TABLE Department
(
    DepartmentId INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    DepartmentName NVARCHAR(75) NOT NULL
)
GO

CREATE TABLE Designation
(
    DesignationId INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    DepartmentId INT REFERENCES Department(DepartmentId),
    DesignationName NVARCHAR(75) NOT NULL
)
GO



CREATE TABLE Employee
(
    EployeeId INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    EmployeeName NVARCHAR(75) NOT NULL,
    DepartmentId INT REFERENCES Department(DepartmentId),
    DesignationId INT REFERENCES Designation(DesignationId),
    Email NVARCHAR(30) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    JoinDate DATETIME NOT NULL
)
GO

-- Insert Employee SP

CREATE PROC SpInsertEmployee
            @EmployeeName NVARCHAR(75),
            @DepartmentId INT,
            @DesignationId INT,
            @Email NVARCHAR(30),
            @Phone NVARCHAR (15),
            @JoinDate DATETIME
AS
BEGIN
    INSERT INTO Employee(EmployeeName, DepartmentId, DesignationId, Email, Phone, JoinDate)
    VALUES(@EmployeeName, @DepartmentId, @DesignationId, @Email, @Phone, @JoinDate)
END
GO

-- Update Employee SP

CREATE PROC SpUpdateEmployee
            @EployeeId INT,
            @EmployeeName NVARCHAR(75),
            @DepartmentId INT,
            @DesignationId INT,
            @Email NVARCHAR(30),
            @Phone NVARCHAR (15),
            @JoinDate DATETIME
AS
BEGIN
    UPDATE Employee
    SET EmployeeName =@EmployeeName,
        DepartmentId =@DepartmentId,
        DesignationId =@DesignationId,
        Email =@Email,
        Phone =@Phone,
        JoinDate =@JoinDate
    WHERE EployeeId =@EployeeId
END
GO

-- Delete Employee SP

CREATE PROC SpDeleteEmployee
            @EployeeId INT
AS
BEGIN
    DELETE FROM Employee
    WHERE EployeeId =@EployeeId
END
GO


-- View All Employee

CREATE PROC SpViewAllEmployee
AS
BEGIN
    SELECT
    e.EmployeeName,
    dp.DepartmentName,
    ds.DesignationName,
    e.Email,
    e.Phone,
    e.JoinDate
    FROM Employee e
    INNER JOIN Department dp ON e.DepartmentId = dp.DepartmentId
    INNER JOIN Designation ds ON e.DesignationId = ds.DesignationId
END
GO
