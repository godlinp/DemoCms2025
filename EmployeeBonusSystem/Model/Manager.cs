using System;

namespace EmployeeBonusSystem.Model
{
    /// <summary>
    /// Manager class inheriting from Employee
    /// Managers get a 20% bonus by default
    /// </summary>
    public class Manager : Employee
    {
        public string Department { get; set; }
        public int TeamSize { get; set; }

        // Constructor
        public Manager(int employeeId, string name, double salary, string department, int teamSize) 
            : base(employeeId, name, salary)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            TeamSize = teamSize >= 0 ? teamSize : throw new ArgumentException("Team size cannot be negative");
        }

        // Override abstract method - Managers get 20% bonus
        public override double CalculateBonus()
        {
            double baseBonus = Salary * 0.20; // 20% base bonus
            
            // Additional bonus based on team size
            double teamBonus = TeamSize * 1000;
            
            return baseBonus + teamBonus;
        }

        // Override virtual method to include manager-specific information
        public override string GetEmployeeInfo()
        {
            return base.GetEmployeeInfo() + $", Role: Manager, Department: {Department}, Team Size: {TeamSize}";
        }
    }
}