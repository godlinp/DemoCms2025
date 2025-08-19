using System;
using System.Text.RegularExpressions;

namespace EmployeeBonusSystem.Utility
{
    /// <summary>
    /// Utility class for input validation
    /// Demonstrates static methods and validation patterns
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates if a string is not null or empty
        /// </summary>
        public static bool IsValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Validates if a number is positive
        /// </summary>
        public static bool IsPositiveNumber(double number)
        {
            return number > 0;
        }

        /// <summary>
        /// Validates if an integer is non-negative
        /// </summary>
        public static bool IsNonNegativeInteger(int number)
        {
            return number >= 0;
        }

        /// <summary>
        /// Validates employee name format
        /// </summary>
        public static bool IsValidEmployeeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            // Name should contain only letters, spaces, and common punctuation
            var namePattern = @"^[a-zA-Z\s\.\-']+$";
            return Regex.IsMatch(name, namePattern) && name.Trim().Length >= 2;
        }

        /// <summary>
        /// Validates salary range
        /// </summary>
        public static bool IsValidSalary(double salary)
        {
            return salary >= 20000 && salary <= 1000000; // Reasonable salary range
        }

        /// <summary>
        /// Validates employee ID format
        /// </summary>
        public static bool IsValidEmployeeId(int employeeId)
        {
            return employeeId > 0 && employeeId <= 999999; // 6-digit max employee ID
        }
    }
}