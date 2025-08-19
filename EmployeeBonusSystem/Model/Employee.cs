using System;

namespace EmployeeBonusSystem.Model
{
    /// <summary>
    /// Base abstract class representing an Employee
    /// Demonstrates inheritance, encapsulation, and polymorphism
    /// </summary>
    public abstract class Employee
    {
        // Private fields for encapsulation
        private string _name = string.Empty;
        private double _salary;
        private int _employeeId;

        // Public properties with validation
        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty");
        }

        public double Salary
        {
            get => _salary;
            set => _salary = value > 0 ? value : throw new ArgumentException("Salary must be positive");
        }

        public int EmployeeId
        {
            get => _employeeId;
            set => _employeeId = value > 0 ? value : throw new ArgumentException("Employee ID must be positive");
        }

        // Constructor
        protected Employee(int employeeId, string name, double salary)
        {
            EmployeeId = employeeId;
            Name = name;
            Salary = salary;
        }

        // Abstract method to be implemented by derived classes (Polymorphism)
        public abstract double CalculateBonus();

        // Virtual method that can be overridden
        public virtual string GetEmployeeInfo()
        {
            return $"ID: {EmployeeId}, Name: {Name}, Salary: ${Salary:F2}";
        }

        // Method to get total compensation
        public double GetTotalCompensation()
        {
            return Salary + CalculateBonus();
        }
    }
}