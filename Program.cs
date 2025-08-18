using System;
using System.Collections.Generic;

namespace CollegeAdmissionSystem
{
    /// <summary>
    /// Main program to demonstrate the College Admission System
    /// </summary>
    class Program
    {
        static void MainInteractive(string[] args)
        {
            Console.WriteLine("=== COLLEGE ADMISSION SYSTEM ===");
            Console.WriteLine("Welcome to the Student Management System\n");

            try
            {
                // Create a list to store students
                List<Student> students = new List<Student>();

                // Demonstrate different ways to create students
                Console.WriteLine("Creating students...\n");

                // Using default constructor
                Student student1 = new Student();
                student1.UpdateFullName("John Smith");
                student1.UpdateMarks(85.5);

                // Using parameterized constructor
                Student student2 = new Student("Emily Johnson", 92.0);
                Student student3 = new Student("Michael Brown", 78.5);
                Student student4 = new Student("Sarah Davis", 95.5);
                Student student5 = new Student("David Wilson", 45.0);

                // Add students to list
                students.Add(student1);
                students.Add(student2);
                students.Add(student3);
                students.Add(student4);
                students.Add(student5);

                // Display all students
                StudentUtility.DisplayStudents(students);

                // Demonstrate utility functions
                Console.WriteLine("\n=== UTILITY DEMONSTRATIONS ===");
                
                // Show admitted students
                var admittedStudents = StudentUtility.GetAdmittedStudents(students);
                Console.WriteLine($"\nAdmitted Students ({admittedStudents.Count}):");
                foreach (var student in admittedStudents)
                {
                    Console.WriteLine($"- {student.FullName} (ID: {student.StudentId}, Marks: {student.Marks}%)");
                }

                // Show scholarship eligible students
                var scholarshipStudents = StudentUtility.GetScholarshipEligibleStudents(students);
                Console.WriteLine($"\nScholarship Eligible Students ({scholarshipStudents.Count}):");
                foreach (var student in scholarshipStudents)
                {
                    Console.WriteLine($"- {student.FullName} (ID: {student.StudentId}, Marks: {student.Marks}%)");
                }

                // Generate comprehensive admission report
                StudentUtility.GenerateAdmissionReport(students);

                // Demonstrate search functionality
                Console.WriteLine("\n=== SEARCH DEMONSTRATIONS ===");
                
                // Search by name
                var searchResults = StudentUtility.SearchStudentsByName(students, "john");
                Console.WriteLine($"\nSearch results for 'john': {searchResults.Count} found");
                foreach (var student in searchResults)
                {
                    Console.WriteLine($"- {student.FullName} (ID: {student.StudentId})");
                }

                // Search by ID (using first student's ID)
                if (students.Count > 0)
                {
                    var foundStudent = StudentUtility.FindStudentById(students, students[0].StudentId);
                    Console.WriteLine($"\nStudent found by ID {students[0].StudentId}: {foundStudent?.FullName ?? "Not found"}");
                }

                // Demonstrate validation
                Console.WriteLine("\n=== VALIDATION DEMONSTRATIONS ===");
                
                // Try to create student with invalid data
                Console.WriteLine("\nTrying to create student with invalid marks (150):");
                try
                {
                    var invalidStudent = new Student("Invalid Student", 150);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Validation caught: {ex.Message}");
                }

                Console.WriteLine("\nTrying to create student with empty name:");
                try
                {
                    var invalidStudent2 = new Student("", 80);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Validation caught: {ex.Message}");
                }

                // Interactive menu
                Console.WriteLine("\n=== INTERACTIVE MENU ===");
                ShowMenu(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ShowMenu(List<Student> students)
        {
            while (true)
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Search Students by Name");
                Console.WriteLine("5. Show Admission Report");
                Console.WriteLine("6. Show Admitted Students");
                Console.WriteLine("7. Show Scholarship Eligible Students");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice (1-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewStudent(students);
                        break;
                    case "2":
                        StudentUtility.DisplayStudents(students);
                        break;
                    case "3":
                        SearchStudentById(students);
                        break;
                    case "4":
                        SearchStudentsByName(students);
                        break;
                    case "5":
                        StudentUtility.GenerateAdmissionReport(students);
                        break;
                    case "6":
                        var admitted = StudentUtility.GetAdmittedStudents(students);
                        Console.WriteLine($"\nAdmitted Students ({admitted.Count}):");
                        StudentUtility.DisplayStudents(admitted);
                        break;
                    case "7":
                        var scholarship = StudentUtility.GetScholarshipEligibleStudents(students);
                        Console.WriteLine($"\nScholarship Eligible Students ({scholarship.Count}):");
                        StudentUtility.DisplayStudents(scholarship);
                        break;
                    case "8":
                        Console.WriteLine("Thank you for using the College Admission System!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1-8.");
                        break;
                }
            }
        }

        static void AddNewStudent(List<Student> students)
        {
            try
            {
                Console.Write("Enter student's full name: ");
                string fullName = Console.ReadLine();

                Console.Write("Enter student's marks (0-100): ");
                if (double.TryParse(Console.ReadLine(), out double marks))
                {
                    var newStudent = StudentUtility.CreateStudent(fullName, marks);
                    if (newStudent != null)
                    {
                        students.Add(newStudent);
                        Console.WriteLine($"Student added successfully! ID: {newStudent.StudentId}");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create student due to validation errors.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid marks format. Please enter a valid number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        static void SearchStudentById(List<Student> students)
        {
            Console.Write("Enter Student ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var student = StudentUtility.FindStudentById(students, studentId);
                if (student != null)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine(student.ToString());
                }
                else
                {
                    Console.WriteLine($"No student found with ID: {studentId}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Student ID format. Please enter a valid number.");
            }
        }

        static void SearchStudentsByName(List<Student> students)
        {
            Console.Write("Enter name to search (partial match): ");
            string searchName = Console.ReadLine();
            
            var results = StudentUtility.SearchStudentsByName(students, searchName);
            
            if (results.Count > 0)
            {
                Console.WriteLine($"\nFound {results.Count} student(s):");
                StudentUtility.DisplayStudents(results);
            }
            else
            {
                Console.WriteLine($"No students found matching '{searchName}'");
            }
        }
    }
}