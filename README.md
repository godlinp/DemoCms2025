# College Admission System

A comprehensive C# program implementing a Student model with utility functions for college admission management.

## Features

### Student Model (`Student.cs`)
- **Properties**: StudentId (auto-generated 4-digit), FullName, Marks
- **Constructors**: 
  - Default constructor
  - Parameterized constructor (FullName, Marks)
  - Parameterized constructor with StudentId
- **Validation**:
  - StudentId: 4-digit number (1000-9999)
  - FullName: Cannot be empty or null
  - Marks: Must be between 0 and 100
- **Methods**:
  - `ToString()`: Display student details
  - `GetGrade()`: Calculate grade (A+, A, B, C, D, F)
  - `GetAdmissionStatus()`: Determine admission status (60% threshold)
  - `IsEligibleForScholarship()`: Check scholarship eligibility (85% threshold)

### Utility Class (`StudentUtility.cs`)
- **Validation**: `ValidateStudentData()`, `CreateStudent()`
- **Display**: `DisplayStudents()` for multiple students
- **Filtering**: 
  - `GetAdmittedStudents()`: Students with marks ≥ 60%
  - `GetScholarshipEligibleStudents()`: Students with marks ≥ 85%
  - `GetStudentsByGrade()`: Filter by specific grade
- **Analytics**:
  - `CalculateAverageMarks()`: Class average calculation
  - `GetTopStudent()`: Find highest scoring student
  - `GenerateAdmissionReport()`: Comprehensive statistics
- **Search**:
  - `FindStudentById()`: Search by StudentId
  - `SearchStudentsByName()`: Partial name matching

### Main Programs
- **`DemoProgram.cs`**: Automated demonstration of all features
- **`Program.cs`**: Interactive menu system (renamed to `MainInteractive`)

## How to Run

### Prerequisites
- .NET 6.0 SDK or later

### Compilation and Execution
```bash
# Build the project
dotnet build

# Run the demo (automated)
dotnet run

# To run interactive version (if needed)
# Uncomment and rename MainInteractive back to Main in Program.cs
```

## Sample Output

```
=== COLLEGE ADMISSION SYSTEM DEMO ===
Automated demonstration of all features

1. Creating students with different constructors...

✓ Created student using default constructor: John Smith (ID: 1721)
✓ Created students using parameterized constructor:
  - Emily Johnson (ID: 8550, Marks: 92%)
  - Michael Brown (ID: 7667, Marks: 78.5%)
  - Sarah Davis (ID: 7506, Marks: 95.5%)
  - David Wilson (ID: 4532, Marks: 45%)
  - Lisa Anderson (ID: 9786, Marks: 88%)

...

✓ Top Student: Sarah Davis with 95.5% marks
✓ Average Class Marks: 80.75%

=== ADMISSION REPORT ===
Total Students: 6
Admitted Students: 5
Scholarship Eligible: 4
Average Marks: 80.75%
Top Student: Sarah Davis (95.50%)
Admission Rate: 83.3%
```

## Project Structure

```
CollegeAdmissionSystem/
├── Student.cs              # Student model class
├── StudentUtility.cs       # Utility functions
├── DemoProgram.cs         # Automated demo
├── Program.cs             # Interactive version
├── CollegeAdmissionSystem.csproj
└── README.md
```

## Key Requirements Met

✅ **Student Model**: StudentId, FullName, Marks properties  
✅ **Auto-generated ID**: 4-digit random number (1000-9999)  
✅ **Constructors**: Default and parameterized  
✅ **Validation**: All input validation implemented  
✅ **ToString()**: Comprehensive student details display  
✅ **Utility Functions**: Complete set of helper methods  
✅ **Grade System**: A+ to F grade calculation  
✅ **Admission Logic**: 60% pass threshold  
✅ **Scholarship Logic**: 85% scholarship threshold  

## Additional Features

- Comprehensive error handling and validation
- Search functionality (by ID and name)
- Statistical reporting and analytics
- Grade distribution analysis
- Interactive menu system
- Automated demo for testing

## Grade Scale

- A+: 90-100%
- A: 80-89%
- B: 70-79%
- C: 60-69%
- D: 50-59%
- F: Below 50%

## Admission Criteria

- **Admitted**: Marks ≥ 60%
- **Scholarship Eligible**: Marks ≥ 85%