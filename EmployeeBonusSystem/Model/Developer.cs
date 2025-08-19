using System;

namespace EmployeeBonusSystem.Model
{
    /// <summary>
    /// Developer class inheriting from Employee
    /// Developers get a 10% bonus by default
    /// </summary>
    public class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public int YearsOfExperience { get; set; }

        // Constructor
        public Developer(int employeeId, string name, double salary, string programmingLanguage, int yearsOfExperience) 
            : base(employeeId, name, salary)
        {
            ProgrammingLanguage = programmingLanguage ?? throw new ArgumentNullException(nameof(programmingLanguage));
            YearsOfExperience = yearsOfExperience >= 0 ? yearsOfExperience : throw new ArgumentException("Years of experience cannot be negative");
        }

        // Override abstract method - Developers get 10% bonus
        public override double CalculateBonus()
        {
            double baseBonus = Salary * 0.10; // 10% base bonus
            
            // Additional bonus based on experience
            double experienceBonus = YearsOfExperience * 500;
            
            return baseBonus + experienceBonus;
        }

        // Override virtual method to include developer-specific information
        public override string GetEmployeeInfo()
        {
            return base.GetEmployeeInfo() + $", Role: Developer, Language: {ProgrammingLanguage}, Experience: {YearsOfExperience} years";
        }
    }
}