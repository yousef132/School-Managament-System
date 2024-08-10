# School Management Project Using Clean Architecture

## Endpoints

You can access the API endpoints through the following link:

- **[Swagger Documentation](http://schoolmanagmentsystem.runasp.net/swagger/index.html)**

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Project Structure](#project-structure)
- [Database Components](#database-components)
  - [Functions](#functions)
  - [Stored Procedures](#stored-procedures)
  - [Views](#views)

## Introduction
This project is a full-featured school management system designed with Clean Architecture principles. It is built to be scalable, maintainable, and efficient for managing various school tasks.

## Features

- [CQRS Pattern](#cqrs-pattern): Separates write and query operations, making the system more scalable and easier to maintain.
- [Mediator Pattern](#mediator-pattern): Facilitates communication between classes without direct references, improving code flexibility.
- [Fluent Validation](#fluent-validation): Provides an easy way to set up validations with custom error handling.
- [Localization](#localization): Supports both Arabic and English languages, with responses tailored to the selected environment.
- [Logging with Serilog](#logging-with-serilog): Logs errors to the database for easy tracking and debugging.
- [Database Techniques](#database-techniques): Uses views, stored procedures, and functions for optimized database operations.
- [Pagination Schema](#pagination-schema): Efficiently organizes large responses.
- [Confirmation Email System](#confirmation-email-system): Sends confirmation emails with account activation links.
- [Reset Password System](#reset-password-system): Encrypts and decrypts reset password codes sent via email.
- [Identity Management](#identity-management): Includes functionalities for user and role management.
- [Role and Claims Manipulation](#role-and-claims-manipulation): Allows modification of user roles and claims for access control.
- [JWT Token Authentication](#jwt-token-authentication): Implements token-based authentication with refresh tokens.
- [Routing Schema](#routing-schema): Uses organized routing classes for flexibility.
- [Readable Response Schema](#readable-response-schema): Provides detailed response structures with status codes, operation status, data, and metadata.
- [Dependency Injection](#dependency-injection): Manages dependencies efficiently.
- [SOLID Principles](#solid-principles): Follows SOLID principles for robust and maintainable code.

## Project Structure

- [Core](#core): Contains core business logic and entities.
- [Infrastructure](#infrastructure): Handles data access and integration with external services.
- [Application](#application): Implements application services and use cases.
- [API](#api): Provides API endpoints for interacting with the system.
- [Services](#services): Includes various application services.

---

## Database Components

This section provides an overview of the stored procedures, functions, and views utilized in our program. These components are essential for various data operations, such as data retrieval and aggregation.

### Functions

#### `GetTop3InstructorSalariesByDept`

- **Purpose:** Retrieves the top 3 instructor salaries for each department.

- **Definition:**
  ```sql
  CREATE FUNCTION [dbo].[GetTop3InstructorSalariesByDept]()
  RETURNS @ResultTable TABLE
  (
      DepartmentId INT,
      DepartmentNameEn VARCHAR(200),
      DepartmentNameAr NVARCHAR(200),
      InstructorId INT,
      InstructorNameEn VARCHAR(200),
      InstructorNameAr NVARCHAR(200),
      Salary DECIMAL(18,2),
      rn INT
  )
  AS
  BEGIN
      INSERT INTO @ResultTable
      SELECT 
          DepartmentId,
          DepartmentNameEn,
          DepartmentNameAr,
          InstructorId,
          InstructorNameEn,
          InstructorNameAr,
          Salary,
          rn
      FROM (
          SELECT 
              d.DeptId AS DepartmentId,
              d.NameEn AS DepartmentNameEn,
              d.NameAr AS DepartmentNameAr,
              i.InstId AS InstructorId,
              i.NameEn AS InstructorNameEn,
              i.NameAr AS InstructorNameAr,
              i.Salary,
              ROW_NUMBER() OVER (PARTITION BY d.DeptId ORDER BY i.Salary DESC) AS rn
          FROM Instructor i
          JOIN Departments d ON i.DeptId = d.DeptId
      ) AS Result
      WHERE rn <= 3;

      RETURN;
  END
### Stored Procedures

#### `DepartmentTotalStudentsProc`

- **Purpose:** Returns the total number of students in a specified department.

- **Definition:**
  ```sql
  CREATE PROC [dbo].[DepartmentTotalStudentsProc](@DepartmentId INT)
  AS
  BEGIN
      CREATE TABLE #temp (
          DepartmentId INT,
          DepartmentNameAr NVARCHAR(200),
          DepartmentNameEn VARCHAR(200),
          StudentsCount INT
      );

      INSERT INTO #temp
      SELECT 
          d.DeptId AS DepartmentId,
          d.NameAr AS DepartmentNameAr,
          d.NameEn AS DepartmentNameEn,
          COUNT(s.StudId) AS StudentsCount
      FROM Departments d 
      LEFT JOIN Students s ON d.DeptId = s.DeptId
      WHERE d.DeptId = @DepartmentId
      GROUP BY d.DeptId, d.NameAr, d.NameEn;

      SELECT * FROM #temp;
  END
### Views

#### `DepartmentStudentsCount`

- **Purpose:** Provides a summary of the number of students in each department.

- **Definition:**
  ```sql
  SELECT 
      d.DeptId AS DepartmentId, 
      d.NameAr AS DepartmentNameAr, 
      d.NameEn AS DepartmentNameEn, 
      COUNT(s.StudId) AS Students
  FROM dbo.Departments AS d 
  LEFT OUTER JOIN dbo.Students AS s ON d.DeptId = s.DeptId
  GROUP BY d.DeptId, d.NameAr, d.NameEn;

  
