using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBonusSystem.Model;

namespace EmployeeBonusSystem.Utility
{
    /// <summary>
    /// Utility class for formatting display output
    /// Demonstrates static methods and string formatting
    /// </summary>
    public static class DisplayFormatter
    {
        /// <summary>
        /// Creates a formatted header for display
        /// </summary>
        public static string CreateHeader(string title)
        {
            var sb = new StringBuilder();
            string separator = new string('=', title.Length + 4);
            
            sb.AppendLine(separator);
            sb.AppendLine($"  {title}  ");
            sb.AppendLine(separator);
            
            return sb.ToString();
        }

        /// <summary>
        /// Formats employee information in a table-like format
        /// </summary>
        public static string FormatEmployeeTable(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                return "No employees to display.";

            var sb = new StringBuilder();
            
            // Header
            sb.AppendLine(CreateHeader("EMPLOYEE BONUS REPORT"));
            sb.AppendLine();
            
            // Table headers
            sb.AppendLine("┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            sb.AppendLine("│ ID   │ Name              │ Role      │ Salary      │ Bonus       │ Total       │ Details                                │");
            sb.AppendLine("├─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤");
            
            // Employee data
            foreach (var employee in employees)
            {
                string role = employee.GetType().Name;
                string details = GetEmployeeDetails(employee);
                
                sb.AppendLine($"│ {employee.EmployeeId,-4} │ {TruncateString(employee.Name, 17),-17} │ {role,-9} │ ${employee.Salary,-10:F2} │ ${employee.CalculateBonus(),-10:F2} │ ${employee.GetTotalCompensation(),-10:F2} │ {TruncateString(details, 38),-38} │");
            }
            
            sb.AppendLine("└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            
            return sb.ToString();
        }

        /// <summary>
        /// Gets specific details for different employee types
        /// </summary>
        private static string GetEmployeeDetails(Employee employee)
        {
            return employee switch
            {
                Developer dev => $"Lang: {dev.ProgrammingLanguage}, Exp: {dev.YearsOfExperience}y",
                Manager mgr => $"Dept: {mgr.Department}, Team: {mgr.TeamSize}",
                _ => "General Employee"
            };
        }

        /// <summary>
        /// Truncates string to specified length
        /// </summary>
        private static string TruncateString(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
                
            return input.Length <= maxLength ? input : input.Substring(0, maxLength - 3) + "...";
        }

        /// <summary>
        /// Formats currency with proper formatting
        /// </summary>
        public static string FormatCurrency(double amount)
        {
            return $"${amount:N2}";
        }

        /// <summary>
        /// Creates a summary report
        /// </summary>
        public static string CreateSummaryReport(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                return "No data available for summary.";

            var sb = new StringBuilder();
            double totalSalaries = 0;
            double totalBonuses = 0;
            int developerCount = 0;
            int managerCount = 0;

            foreach (var employee in employees)
            {
                totalSalaries += employee.Salary;
                totalBonuses += employee.CalculateBonus();
                
                if (employee is Developer) developerCount++;
                else if (employee is Manager) managerCount++;
            }

            sb.AppendLine(CreateHeader("SUMMARY REPORT"));
            sb.AppendLine($"Total Employees: {employees.Count}");
            sb.AppendLine($"Developers: {developerCount}");
            sb.AppendLine($"Managers: {managerCount}");
            sb.AppendLine();
            sb.AppendLine($"Total Salaries: {FormatCurrency(totalSalaries)}");
            sb.AppendLine($"Total Bonuses: {FormatCurrency(totalBonuses)}");
            sb.AppendLine($"Total Compensation: {FormatCurrency(totalSalaries + totalBonuses)}");
            sb.AppendLine($"Average Salary: {FormatCurrency(totalSalaries / employees.Count)}");
            sb.AppendLine($"Average Bonus: {FormatCurrency(totalBonuses / employees.Count)}");

            return sb.ToString();
        }
    }
}