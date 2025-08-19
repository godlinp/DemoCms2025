using System;
using System.Collections.Generic;
using EmployeeBonusSystem.Model;
using EmployeeBonusSystem.Utility;

namespace EmployeeBonusSystem.Main
{
    /// <summary>
    /// Main program demonstrating Object-Oriented Programming concepts:
    /// - Inheritance (Employee -> Developer, Manager)
    /// - Polymorphism (CalculateBonus method overrides)
    /// - Encapsulation (Private fields with public properties)
    /// - Abstraction (Abstract Employee class)
    /// </summary>
    class Program
    {
        private static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Bonus Calculation System!");
            Console.WriteLine("This program demonstrates Object-Oriented Programming concepts in C#");
            Console.WriteLine();

            // Initialize with sample data
            InitializeSampleData();

            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice.ToLower())
                {
                    case "1":
                        DisplayAllEmployees();
                        break;
                    case "2":
                        AddNewEmployee();
                        break;
                    case "3":
                        DisplaySummaryReport();
                        break;
                    case "4":
                        DemonstratePolymorphism();
                        break;
                    case "5":
                        SearchEmployee();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using the Employee Bonus System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Displays the main menu
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine(DisplayFormatter.CreateHeader("MAIN MENU"));
            Console.WriteLine("1. Display All Employees");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Display Summary Report");
            Console.WriteLine("4. Demonstrate Polymorphism");
            Console.WriteLine("5. Search Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice (1-6): ");
        }

        /// <summary>
        /// Initializes the system with sample data
        /// </summary>
        private static void InitializeSampleData()
        {
            try
            {
                // Add sample developers
                employees.Add(new Developer(101, "Alice Johnson", 75000, "C#", 5));
                employees.Add(new Developer(102, "Bob Smith", 85000, "Java", 8));
                employees.Add(new Developer(103, "Carol Davis", 65000, "Python", 3));

                // Add sample managers
                employees.Add(new Manager(201, "David Wilson", 95000, "Engineering", 10));
                employees.Add(new Manager(202, "Emma Brown", 110000, "Marketing", 8));
                employees.Add(new Manager(203, "Frank Miller", 120000, "Sales", 15));

                Console.WriteLine("Sample data initialized successfully!");
                Console.WriteLine($"Loaded {employees.Count} employees into the system.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing sample data: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays all employees in a formatted table
        /// </summary>
        private static void DisplayAllEmployees()
        {
            Console.Clear();
            Console.WriteLine(DisplayFormatter.FormatEmployeeTable(employees));
        }

        /// <summary>
        /// Adds a new employee to the system
        /// </summary>
        private static void AddNewEmployee()
        {
            Console.Clear();
            Console.WriteLine(DisplayFormatter.CreateHeader("ADD NEW EMPLOYEE"));

            try
            {
                // Get employee type
                Console.WriteLine("Select employee type:");
                Console.WriteLine("1. Developer");
                Console.WriteLine("2. Manager");
                Console.Write("Enter choice (1-2): ");
                string typeChoice = Console.ReadLine()?.Trim() ?? "";

                // Get common employee information
                int employeeId = GetValidEmployeeId();
                string name = GetValidEmployeeName();
                double salary = GetValidSalary();

                Employee newEmployee = typeChoice switch
                {
                    "1" => CreateDeveloper(employeeId, name, salary),
                    "2" => CreateManager(employeeId, name, salary),
                    _ => throw new InvalidOperationException("Invalid employee type selected.")
                };

                employees.Add(newEmployee);
                Console.WriteLine($"\n✓ Employee {newEmployee.Name} added successfully!");
                Console.WriteLine($"Employee ID: {newEmployee.EmployeeId}");
                Console.WriteLine($"Calculated Bonus: {DisplayFormatter.FormatCurrency(newEmployee.CalculateBonus())}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new Developer with specific information
        /// </summary>
        private static Developer CreateDeveloper(int employeeId, string name, double salary)
        {
            Console.Write("Programming Language: ");
            string language = Console.ReadLine()?.Trim() ?? "";
            if (!InputValidator.IsValidString(language))
                throw new ArgumentException("Programming language cannot be empty.");

            Console.Write("Years of Experience: ");
            if (!int.TryParse(Console.ReadLine(), out int experience) || !InputValidator.IsNonNegativeInteger(experience))
                throw new ArgumentException("Years of experience must be a non-negative number.");

            return new Developer(employeeId, name, salary, language, experience);
        }

        /// <summary>
        /// Creates a new Manager with specific information
        /// </summary>
        private static Manager CreateManager(int employeeId, string name, double salary)
        {
            Console.Write("Department: ");
            string department = Console.ReadLine()?.Trim() ?? "";
            if (!InputValidator.IsValidString(department))
                throw new ArgumentException("Department cannot be empty.");

            Console.Write("Team Size: ");
            if (!int.TryParse(Console.ReadLine(), out int teamSize) || !InputValidator.IsNonNegativeInteger(teamSize))
                throw new ArgumentException("Team size must be a non-negative number.");

            return new Manager(employeeId, name, salary, department, teamSize);
        }

        /// <summary>
        /// Gets a valid employee ID from user input
        /// </summary>
        private static int GetValidEmployeeId()
        {
            while (true)
            {
                Console.Write("Employee ID: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (InputValidator.IsValidEmployeeId(id))
                    {
                        // Check if ID already exists
                        if (employees.Exists(e => e.EmployeeId == id))
                        {
                            Console.WriteLine("Employee ID already exists. Please enter a different ID.");
                            continue;
                        }
                        return id;
                    }
                    Console.WriteLine("Employee ID must be between 1 and 999999.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid numeric Employee ID.");
                }
            }
        }

        /// <summary>
        /// Gets a valid employee name from user input
        /// </summary>
        private static string GetValidEmployeeName()
        {
            while (true)
            {
                Console.Write("Employee Name: ");
                string name = Console.ReadLine()?.Trim() ?? "";
                if (InputValidator.IsValidEmployeeName(name))
                {
                    return name;
                }
                Console.WriteLine("Please enter a valid name (letters, spaces, and common punctuation only, minimum 2 characters).");
            }
        }

        /// <summary>
        /// Gets a valid salary from user input
        /// </summary>
        private static double GetValidSalary()
        {
            while (true)
            {
                Console.Write("Salary: $");
                if (double.TryParse(Console.ReadLine(), out double salary))
                {
                    if (InputValidator.IsValidSalary(salary))
                    {
                        return salary;
                    }
                    Console.WriteLine("Salary must be between $20,000 and $1,000,000.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid numeric salary.");
                }
            }
        }

        /// <summary>
        /// Displays summary report
        /// </summary>
        private static void DisplaySummaryReport()
        {
            Console.Clear();
            Console.WriteLine(DisplayFormatter.CreateSummaryReport(employees));
        }

        /// <summary>
        /// Demonstrates polymorphism by calling CalculateBonus on different employee types
        /// </summary>
        private static void DemonstratePolymorphism()
        {
            Console.Clear();
            Console.WriteLine(DisplayFormatter.CreateHeader("POLYMORPHISM DEMONSTRATION"));
            Console.WriteLine("This demonstrates how the same method call (CalculateBonus) behaves");
            Console.WriteLine("differently for different employee types (Developer vs Manager):");
            Console.WriteLine();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.Name} ({employee.GetType().Name})");
                Console.WriteLine($"  Base Salary: {DisplayFormatter.FormatCurrency(employee.Salary)}");
                Console.WriteLine($"  Calculated Bonus: {DisplayFormatter.FormatCurrency(employee.CalculateBonus())}");
                Console.WriteLine($"  Bonus Calculation Method: {GetBonusCalculationDescription(employee)}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets description of how bonus is calculated for different employee types
        /// </summary>
        private static string GetBonusCalculationDescription(Employee employee)
        {
            return employee switch
            {
                Developer dev => $"10% base + ${500 * dev.YearsOfExperience} experience bonus",
                Manager mgr => $"20% base + ${1000 * mgr.TeamSize} team management bonus",
                _ => "Standard calculation"
            };
        }

        /// <summary>
        /// Searches for an employee by ID or name
        /// </summary>
        private static void SearchEmployee()
        {
            Console.Clear();
            Console.WriteLine(DisplayFormatter.CreateHeader("SEARCH EMPLOYEE"));
            Console.Write("Enter Employee ID or Name to search: ");
            string searchTerm = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return;
            }

            List<Employee> foundEmployees = new List<Employee>();

            // Search by ID if numeric
            if (int.TryParse(searchTerm, out int searchId))
            {
                var employee = employees.Find(e => e.EmployeeId == searchId);
                if (employee != null)
                    foundEmployees.Add(employee);
            }

            // Search by name (partial match, case insensitive)
            var nameMatches = employees.FindAll(e => 
                e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            
            foreach (var match in nameMatches)
            {
                if (!foundEmployees.Contains(match))
                    foundEmployees.Add(match);
            }

            if (foundEmployees.Count > 0)
            {
                Console.WriteLine($"\nFound {foundEmployees.Count} employee(s):");
                Console.WriteLine(DisplayFormatter.FormatEmployeeTable(foundEmployees));
            }
            else
            {
                Console.WriteLine("No employees found matching the search criteria.");
            }
        }
    }
}