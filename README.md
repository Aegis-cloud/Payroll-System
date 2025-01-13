# Payroll-System
# Employee Payroll System

## Overview

The Employee Payroll System is a C# Console Application designed to calculate employee salaries based on their roles. The application demonstrates key Object-Oriented Programming (OOP) principles by implementing a base class and specialized derived classes.

## Features

- Store employee details including **Name**, **ID**, **Role**, **Basic Pay**, **Allowances**, **Deductions**.
- Calculate salaries using the formula:
```Salary = Basic Pay + Allowances - Deductions
```

- Specialized roles with additional attributes (Manager, Developer, Intern).
- Menu-driven interface for user interaction.

### Bonus Features

- Save and retrieve employee data using file storage.
- Calculate and display the total payroll for all employees.

## Prerequisites

- .NET SDK (version 5.0 or higher)

## How to Run

### Clone or Download the Project Files

1. Open the project in your preferred C# IDE (Visual Studio recommended).
2. Build the project to restore dependencies.
3. Run the application.

### Build and Run via Command Line

1. Navigate to the project folder.
2. Build the application:

 ```bash
 dotnet build
 ```
3. Run the application:
```
dotnet run
```
## Usage

### Menu Options

1. Add a new employee  
2. Display all employee details  
3. Calculate and display individual salaries  
4. Save employee data to a file  
5. Load employee data from a file  
6. Calculate and display total payroll  
7. Exit  

## Example Input

```plaintext
Enter Employee Name: John Doe  
Enter Employee ID: 101  
Enter Role (1 - Manager / 2 - Developer / 3 - Intern): 2  
Enter Basic Pay: 5000  
Enter Allowances: 1500  
```

## Implementation Details
Classes and OOP Concepts
### BaseEmployee Class
Properties: Name, ID, BasicPay, Allowances, and Deductions.
Methods: CalculateSalary().
### Derived Classes (Manager, Developer, Intern)
Additional attributes or role-specific behaviors.
## File I/O
Saving and loading employee data from a file.
employees.txt (Path: **EmployeePayrollSystem\bin\Debug\net9.0\** )


