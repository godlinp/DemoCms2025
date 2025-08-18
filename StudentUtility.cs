using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeAdmissionSystem
{
    /// <summary>
    /// Utility class for student operations and management
    /// </summary>
    public static class StudentUtility
    {
        // Method to validate student data
        public static bool ValidateStudentData(string fullName, double marks)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.WriteLine("Error: Full Name cannot be empty");
                    return false;
                }

                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("Error: Marks must be between 0 and 100");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
                return false;
            }
        }

        // Method to create a student with validation
        public static Student CreateStudent(string fullName, double marks)
        {
            if (ValidateStudentData(fullName, marks))
            {
                return new Student(fullName, marks);
            }
            return null;
        }

        // Method to display multiple students
        public static void DisplayStudents(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students to display.");
                return;
            }

            Console.WriteLine("\n=== STUDENT LIST ===");
            Console.WriteLine(new string('=', 50));
            
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine(new string('-', 30));
            }
        }

        // Method to get students by admission status
        public static List<Student> GetAdmittedStudents(List<Student> students)
        {
            return students?.Where(s => s.GetAdmissionStatus() == "Admitted").ToList() ?? new List<Student>();
        }

        // Method to get students eligible for scholarship
        public static List<Student> GetScholarshipEligibleStudents(List<Student> students)
        {
            return students?.Where(s => s.IsEligibleForScholarship()).ToList() ?? new List<Student>();
        }

        // Method to calculate average marks
        public static double CalculateAverageMarks(List<Student> students)
        {
            if (students == null || students.Count == 0)
                return 0.0;

            return students.Average(s => s.Marks);
        }

        // Method to find student with highest marks
        public static Student GetTopStudent(List<Student> students)
        {
            if (students == null || students.Count == 0)
                return null;

            return students.OrderByDescending(s => s.Marks).First();
        }

        // Method to get students by grade
        public static List<Student> GetStudentsByGrade(List<Student> students, string grade)
        {
            return students?.Where(s => s.GetGrade() == grade).ToList() ?? new List<Student>();
        }

        // Method to generate admission report
        public static void GenerateAdmissionReport(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students available for report generation.");
                return;
            }

            Console.WriteLine("\n=== ADMISSION REPORT ===");
            Console.WriteLine(new string('=', 60));
            
            var admittedStudents = GetAdmittedStudents(students);
            var scholarshipStudents = GetScholarshipEligibleStudents(students);
            var topStudent = GetTopStudent(students);
            var averageMarks = CalculateAverageMarks(students);

            Console.WriteLine($"Total Students: {students.Count}");
            Console.WriteLine($"Admitted Students: {admittedStudents.Count}");
            Console.WriteLine($"Scholarship Eligible: {scholarshipStudents.Count}");
            Console.WriteLine($"Average Marks: {averageMarks:F2}%");
            Console.WriteLine($"Top Student: {topStudent?.FullName} ({topStudent?.Marks:F2}%)");
            Console.WriteLine($"Admission Rate: {(double)admittedStudents.Count / students.Count * 100:F1}%");
            
            Console.WriteLine("\n--- Grade Distribution ---");
            var gradeGroups = students.GroupBy(s => s.GetGrade())
                                   .OrderByDescending(g => g.Key);
            
            foreach (var group in gradeGroups)
            {
                Console.WriteLine($"Grade {group.Key}: {group.Count()} students");
            }
        }

        // Method to search student by ID
        public static Student FindStudentById(List<Student> students, int studentId)
        {
            return students?.FirstOrDefault(s => s.StudentId == studentId);
        }

        // Method to search students by name (partial match)
        public static List<Student> SearchStudentsByName(List<Student> students, string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
                return new List<Student>();

            return students?.Where(s => s.FullName.ToLower().Contains(searchName.ToLower())).ToList() 
                   ?? new List<Student>();
        }
    }
}