using System;

namespace CollegeAdmissionSystem
{
    /// <summary>
    /// Student model class representing a student in the college admission system
    /// </summary>
    public class Student
    {
        private static Random random = new Random();
        
        // Properties
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public double Marks { get; set; }

        // Default constructor
        public Student()
        {
            StudentId = GenerateStudentId();
            FullName = string.Empty;
            Marks = 0.0;
        }

        // Parameterized constructor
        public Student(string fullName, double marks)
        {
            StudentId = GenerateStudentId();
            SetFullName(fullName);
            SetMarks(marks);
        }

        // Parameterized constructor with StudentId
        public Student(int studentId, string fullName, double marks)
        {
            SetStudentId(studentId);
            SetFullName(fullName);
            SetMarks(marks);
        }

        // Private method to generate 4-digit random StudentId
        private int GenerateStudentId()
        {
            return random.Next(1000, 10000); // Generates 4-digit number (1000-9999)
        }

        // Validation methods
        private void SetStudentId(int studentId)
        {
            if (studentId < 1000 || studentId > 9999)
            {
                throw new ArgumentException("StudentId must be a 4-digit number (1000-9999)");
            }
            StudentId = studentId;
        }

        private void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("FullName cannot be empty or null");
            }
            FullName = fullName.Trim();
        }

        private void SetMarks(double marks)
        {
            if (marks < 0 || marks > 100)
            {
                throw new ArgumentException("Marks must be between 0 and 100");
            }
            Marks = marks;
        }

        // Public methods for updating properties with validation
        public void UpdateFullName(string fullName)
        {
            SetFullName(fullName);
        }

        public void UpdateMarks(double marks)
        {
            SetMarks(marks);
        }

        // ToString method to display student details
        public override string ToString()
        {
            return $"Student Details:\n" +
                   $"Student ID: {StudentId}\n" +
                   $"Full Name: {FullName}\n" +
                   $"Marks: {Marks:F2}%\n" +
                   $"Grade: {GetGrade()}\n" +
                   $"Status: {GetAdmissionStatus()}";
        }

        // Utility method to get grade based on marks
        public string GetGrade()
        {
            if (Marks >= 90) return "A+";
            if (Marks >= 80) return "A";
            if (Marks >= 70) return "B";
            if (Marks >= 60) return "C";
            if (Marks >= 50) return "D";
            return "F";
        }

        // Utility method to determine admission status
        public string GetAdmissionStatus()
        {
            return Marks >= 60 ? "Admitted" : "Not Admitted";
        }

        // Method to check if student is eligible for scholarship
        public bool IsEligibleForScholarship()
        {
            return Marks >= 85;
        }
    }
}