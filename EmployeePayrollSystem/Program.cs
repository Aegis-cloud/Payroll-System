using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace EmployeePayrollSystem
{
    // Base class for common employee attributes and methods
    public class BaseEmployee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Role { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set;  }

        // Constructor to initialize basic properties
        public BaseEmployee(string name, int id, string role, decimal basicPay, decimal allowances,decimal deductions)
        {
            Name = name;
            ID = id;
            Role = role;
            BasicPay = basicPay;
            Allowances = allowances;
            Deductions = deductions;
        }

        // Virtual method to calculate salary (to be overridden in derived classes)
        public virtual decimal CalculateSalary()
        {
            return BasicPay + Allowances - Deductions;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Role: {Role}, Basic Pay: {BasicPay}, Allowances: {Allowances}, Deductions: {Deductions}";
        }
    }

    // Derived class for Manager
    public class Manager : BaseEmployee
    {
        public decimal Bonus { get; set; }

        public Manager(string name, int id, decimal basicPay, decimal allowances, decimal deductions)
            : base(name, id, "Manager", basicPay, allowances,deductions)
        {
            Bonus = 5000;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + Bonus; 
        }
    }

    // Derived class for Developer
    public class Developer : BaseEmployee
    {
        public Developer(string name, int id, decimal basicPay, decimal allowances, decimal deductions)
            : base(name, id, "Developer", basicPay, allowances, deductions)
        {
          
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary(); // Developer salary = Basic Pay + Allowances (no special bonuses)
        }
    }

    // Derived class for Intern
    public class Intern : BaseEmployee
    {
        public Intern(string name, int id, decimal basicPay)
            : base(name, id, "Intern", basicPay, 0, 0)
        {
          
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary(); // Interns get a stipend on top of basic pay + allowances
        }
    }

    class Program
    {
        static List<BaseEmployee> employees = new List<BaseEmployee>();

        static void Main(string[] args)
        {
            bool running = true;
            int x;
            while (running)
            {
              do
              {
                Console.WriteLine("Employee Payroll System");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Calculate and Display Individual Salary");
                Console.WriteLine("4. Calculate Total Payroll");
                Console.WriteLine("5. Save Employee Data");
                Console.WriteLine("6. Load Employee Data");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string? option = Console.ReadLine(); 
                int.TryParse(option, out x);
                switch (option)
                {

                    case "1":
                        AddNewEmployee();
                        break;
                    case "2":
                        DisplayAllEmployees();
                        break;
                    case "3":
                        DisplayIndividualSalary();
                        break;
                    case "4":
                        CalculateTotalPayroll();
                        break;
                    case "5":
                        SaveEmployeeData();
                        break;
                    case "6":
                        LoadEmployeeData();
                        break;
                    case "7":
                        Console.WriteLine("Exiting program!!...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
              }while(x > 0 && x < 7);  
            }
        }

        // Method to add a new employee
        static void AddNewEmployee()
        {
            Console.WriteLine("Add New Employee");
            Console.Write("Name: ");
            string? name = Console.ReadLine()?? throw new ArgumentNullException("Name cannot be null.");
            Console.Write("Employee ID: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("ID cannot be null."));
            Console.Write("Basic Pay: ");
            decimal basicPay = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("BasicPay cannot be null."));
            Console.WriteLine("Choose Role (1 - Manager, 2 - Developer, 3 - Intern): ");
            string? roleChoice = Console.ReadLine();

            BaseEmployee? employee = null;

            switch (roleChoice)
            {
                case "1":
                    Console.Write("Allowances: ");
                    decimal allowances = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Allowances cannot be null."));
                    Console.Write("Deductions: ");
                    decimal deductions = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Deductions cannot be null."));
                    employee = new Manager(name, id, basicPay, allowances, deductions);
                    break;
                case "2":
                    Console.Write("Allowances: ");
                    allowances = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Allowances cannot be null."));
                    Console.Write("Deductions: ");
                    deductions = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Deductions cannot be null."));
                    employee = new Developer(name, id, basicPay, allowances,deductions);
                    break;
                case "3":
                    employee = new Intern(name, id, basicPay);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            employees.Add(employee);
            Console.WriteLine("Employee added successfully!");
            Console.ReadLine();
        }

        // Method to display all employee details
        static void DisplayAllEmployees()
        {
            Console.WriteLine("All Employee Details");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.ReadLine();
        }

        // Method to calculate and display individual salary
        static void DisplayIndividualSalary()
        {
      
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("ID cannot be null."));
            var employee = employees.Find(e => e.ID == id);

            if (employee != null)
            {
                decimal salary = employee.CalculateSalary();
                Console.WriteLine($"Salary for {employee.Name} (ID: {employee.ID}): {salary}");
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
            Console.ReadLine();
        }

        // Method to calculate total payroll
        static void CalculateTotalPayroll()
        {
            decimal totalPayroll = 0;

            foreach (var employee in employees)
            {
                totalPayroll += employee.CalculateSalary();
            }

            Console.WriteLine($"Total Payroll for all employees: {totalPayroll}");
            Console.ReadLine();
        }

        // Method to save employee data to a file
        static void SaveEmployeeData()
        {
   
            using (StreamWriter writer = new StreamWriter("employees.txt"))
            {
                foreach (var employee in employees)
                {
                    writer.WriteLine($"{employee.ID},{employee.Name},{employee.Role},{employee.BasicPay},{employee.Allowances}");
                }
            }
            Console.WriteLine("Employee data saved successfully!");
            Console.ReadLine();
        }

        // Method to load employee data from a file
        static void LoadEmployeeData()
        {
            if (File.Exists("employees.txt"))
            {
                using (StreamReader reader = new StreamReader("employees.txt"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        string name = parts[1];
                        int id = int.Parse(parts[0]);
                        string role = parts[2];
                        decimal basicPay = decimal.Parse(parts[3]);
                        decimal allowances = decimal.Parse(parts[4]);
                        decimal deductions = decimal.Parse(parts[4]);

                        BaseEmployee? employee = null;

                        if (role == "Manager")
                        {
                            employee = new Manager(name, id, basicPay, allowances, deductions);
                        }
                        else if (role == "Developer")
                        {
                            employee = new Developer(name, id, basicPay, allowances, deductions);
                        }
                        else if (role == "Intern")
                        {
                            employee = new Intern(name, id, basicPay);
                        }
                        
                        if (employee != null)
                          employees.Add(employee);
                    }
                }
                Console.WriteLine("Employee data loaded successfully!");
            }
            else
            {
                Console.WriteLine("No employee data found.");
            }
            Console.ReadLine();
        }
    }
}