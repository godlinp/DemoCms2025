using System;
using System.Collections.Generic;

namespace CollegeAdmissionSystem
{
    /// <summary>
    /// Demo program to showcase the College Admission System functionality without user interaction
    /// </summary>
    class DemoProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== COLLEGE ADMISSION SYSTEM DEMO ===");
            Console.WriteLine("Automated demonstration of all features\n");

            try
            {
                // Create a list to store students
                List<Student> students = new List<Student>();

                Console.WriteLine("1. Creating students with different constructors...\n");

                // Using default constructor
                Student student1 = new Student();
                student1.UpdateFullName("John Smith");
                student1.UpdateMarks(85.5);
                Console.WriteLine($"✓ Created student using default constructor: {student1.FullName} (ID: {student1.StudentId})");

                // Using parameterized constructors
                Student student2 = new Student("Emily Johnson", 92.0);
                Student student3 = new Student("Michael Brown", 78.5);
                Student student4 = new Student("Sarah Davis", 95.5);
                Student student5 = new Student("David Wilson", 45.0);
                Student student6 = new Student("Lisa Anderson", 88.0);

                Console.WriteLine($"✓ Created students using parameterized constructor:");
                Console.WriteLine($"  - {student2.FullName} (ID: {student2.StudentId}, Marks: {student2.Marks}%)");
                Console.WriteLine($"  - {student3.FullName} (ID: {student3.StudentId}, Marks: {student3.Marks}%)");
                Console.WriteLine($"  - {student4.FullName} (ID: {student4.StudentId}, Marks: {student4.Marks}%)");
                Console.WriteLine($"  - {student5.FullName} (ID: {student5.StudentId}, Marks: {student5.Marks}%)");
                Console.WriteLine($"  - {student6.FullName} (ID: {student6.StudentId}, Marks: {student6.Marks}%)");

                // Add students to list
                students.AddRange(new[] { student1, student2, student3, student4, student5, student6 });

                Console.WriteLine("\n2. Displaying all students using ToString() method...\n");
                StudentUtility.DisplayStudents(students);

                Console.WriteLine("\n3. Testing validation features...\n");
                
                // Test validation - invalid marks
                try
                {
                    Console.WriteLine("Attempting to create student with marks > 100:");
                    var invalidStudent = new Student("Invalid Student", 150);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"✓ Validation working: {ex.Message}");
                }

                // Test validation - empty name
                try
                {
                    Console.WriteLine("Attempting to create student with empty name:");
                    var invalidStudent2 = new Student("", 80);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"✓ Validation working: {ex.Message}");
                }

                Console.WriteLine("\n4. Demonstrating utility functions...\n");

                // Show admitted students
                var admittedStudents = StudentUtility.GetAdmittedStudents(students);
                Console.WriteLine($"✓ Admitted Students ({admittedStudents.Count} out of {students.Count}):");
                foreach (var student in admittedStudents)
                {
                    Console.WriteLine($"  - {student.FullName} (Marks: {student.Marks}%, Grade: {student.GetGrade()})");
                }

                // Show scholarship eligible students
                var scholarshipStudents = StudentUtility.GetScholarshipEligibleStudents(students);
                Console.WriteLine($"\n✓ Scholarship Eligible Students ({scholarshipStudents.Count}):");
                foreach (var student in scholarshipStudents)
                {
                    Console.WriteLine($"  - {student.FullName} (Marks: {student.Marks}%, Grade: {student.GetGrade()})");
                }

                // Show top student
                var topStudent = StudentUtility.GetTopStudent(students);
                Console.WriteLine($"\n✓ Top Student: {topStudent.FullName} with {topStudent.Marks}% marks");

                // Show average marks
                var avgMarks = StudentUtility.CalculateAverageMarks(students);
                Console.WriteLine($"✓ Average Class Marks: {avgMarks:F2}%");

                Console.WriteLine("\n5. Testing search functionality...\n");

                // Search by name
                var searchResults = StudentUtility.SearchStudentsByName(students, "john");
                Console.WriteLine($"✓ Search for 'john': Found {searchResults.Count} student(s)");
                foreach (var student in searchResults)
                {
                    Console.WriteLine($"  - {student.FullName} (ID: {student.StudentId})");
                }

                // Search by ID
                if (students.Count > 0)
                {
                    var foundStudent = StudentUtility.FindStudentById(students, students[0].StudentId);
                    Console.WriteLine($"✓ Search by ID {students[0].StudentId}: Found {foundStudent?.FullName ?? "Not found"}");
                }

                Console.WriteLine("\n6. Generating comprehensive admission report...\n");
                StudentUtility.GenerateAdmissionReport(students);

                Console.WriteLine("\n7. Testing grade distribution...\n");
                Console.WriteLine("Grade breakdown:");
                foreach (var student in students)
                {
                    Console.WriteLine($"  {student.FullName}: {student.Marks}% = Grade {student.GetGrade()} ({student.GetAdmissionStatus()})");
                }

                Console.WriteLine("\n=== DEMO COMPLETED SUCCESSFULLY ===");
                Console.WriteLine("All features of the College Admission System have been demonstrated:");
                Console.WriteLine("✓ Student model with auto-generated 4-digit ID");
                Console.WriteLine("✓ Default and parameterized constructors");
                Console.WriteLine("✓ Input validation for StudentId, FullName, and Marks");
                Console.WriteLine("✓ ToString() method for displaying student details");
                Console.WriteLine("✓ Utility class with comprehensive helper methods");
                Console.WriteLine("✓ Grade calculation and admission status determination");
                Console.WriteLine("✓ Search and reporting functionality");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during demo: {ex.Message}");
            }
        }
    }
}