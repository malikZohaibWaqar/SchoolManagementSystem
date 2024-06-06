
# School Management System (WinForm C#)

This repository contains the source code for a School Management System application developed in WinForms using C#.

Includes functionalities related to managing the overall school operations. Allows adding, editing, and managing student, HR, Inventory and Transport information.Generates reports on the school's financial performance and Leverages Crystal Reports for generating various reports

## Technology Stack

  - Front-End: WinForms C#
  - ORM : Entity Framework : Data Access Layer (DAL)
  - Database: Microsoft SQL Server
  - Reporting : Crystal Reports

## Code Structure:

  -  DAL: Contains classes for interacting with the database using Entity Framework.
  -  Models: Contains classes representing data entities (e.g., Student, HR, Inventory..).
  -  Forms: Contains WinForms classes for the user interface.
  -  Reports: Crystal Reports, Crystal reports viewer.

## Features

  **1. School Management:** Includes functionalities related to managing the overall school operations.

  -  Class 
  -  Department
  -  Fees
  -  Institute Expense
  -  License 
  -  Time Table (Simple & Advance)

**2. Student Management:** Allows adding, editing, and managing student information.

  - Register
  - Fee Collection
  - Promotion

**3. HR Management:** Provides functionalities for managing staff data.

  - Employee Type
  - Registration
  - Salary

**4. Access Control Management:** Handles access control tasks.

  - Access Control
  - Account Settings
  - Sign In

**5. Inventory Management:** Tracks school supplies and other inventory items.

  - Inventory Type
  - Add Inventory 

**6. Transport Management:** Manages Student and HR transportation services.

  - Add Driver
  - Driver Salary
  - Add Transport
  - Allocate Transport

**7. Profit and Loss Statement:** Generates reports on the school's financial performance.

  - PLS Statement

**8. Crystal Reports Integration:** Leverages Crystal Reports for generating various reports.

  - Student Reports
  - HR Reports
  - Inventory Reports
  - Transport Reports
  - PLS Reports


## Snapshots
### Dashboard

![image](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/56fe89b8-f967-4590-ad4c-e817ad53592f)

### Student Management

![Stu_Reg_1](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/41efe724-9515-4e74-89ca-58182b3dd732)

### Time Table

![TimeTable](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/1f667daa-8559-4817-ab6f-2121082dcc96)

### PLS

![PLS](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/8986698c-0d41-4439-8e74-84e453453cf0)

### Access Control

![accessControl](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/41d20a44-f2fd-4c12-826b-667c93c0cdcd)

### License

![License](https://github.com/malikZohaibWaqar/SchoolManagementSystem/assets/157108544/b4975838-f953-4437-870b-524c3a434d68)

## Getting Started 

### Prerequisites
  -  Microsoft Visual Studio
  -  Entity Framework 4.5 and above
  -  Microsoft SQL Server
  -  SAP Crystal Reports

### Instructions
  -  Clone this repository.
  -  Open the solution file (SchoolManagementSystem.sln) in Visual Studio.
  -  Configure the connection string in the appropriate configuration file to connect to your local SQL Server instance.
  -  (Optional) Install Crystal Reports for Visual Studio if you want to use the report generation functionality.
  -  Build and run the application.

## Contributing

I welcome contributions and suggestions to this project!.
