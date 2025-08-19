# Employee Bonus System - C# OOP Demonstration

This project demonstrates Object-Oriented Programming (OOP) concepts in C# through an Employee Bonus Calculation System.

## 🏗️ Project Structure

```
EmployeeBonusSystem/
├── Main/
│   └── Program.cs              # Main program with user interface
├── Model/
│   ├── Employee.cs             # Abstract base class
│   ├── Developer.cs            # Developer class (inherits from Employee)
│   └── Manager.cs              # Manager class (inherits from Employee)
├── Utility/
│   ├── InputValidator.cs       # Input validation utilities
│   └── DisplayFormatter.cs     # Display formatting utilities
├── EmployeeBonusSystem.csproj  # Project file
└── README.md                   # This file
```

## 🎯 OOP Concepts Demonstrated

### 1. **Inheritance**
- `Employee` is the base abstract class
- `Developer` and `Manager` inherit from `Employee`
- Common properties and methods are inherited from the base class

### 2. **Polymorphism**
- `CalculateBonus()` method is overridden in each derived class
- Different employee types calculate bonuses differently:
  - **Developers**: 10% base bonus + experience bonus
  - **Managers**: 20% base bonus + team management bonus

### 3. **Encapsulation**
- Private fields with public properties
- Input validation in property setters
- Data hiding and controlled access

### 4. **Abstraction**
- `Employee` is an abstract class that cannot be instantiated
- Abstract `CalculateBonus()` method must be implemented by derived classes
- Virtual methods that can be overridden

## 🚀 Features

- **Employee Management**: Add, view, and search employees
- **Bonus Calculation**: Automatic bonus calculation based on employee type
- **Interactive Menu**: User-friendly console interface
- **Data Validation**: Input validation using utility classes
- **Formatted Output**: Professional table formatting for reports
- **Polymorphism Demo**: Shows how same method behaves differently for different types

## 🏃‍♂️ How to Run

### Prerequisites
- .NET 8.0 SDK or later

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd EmployeeBonusSystem
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run --project .
   ```

## 📋 Menu Options

1. **Display All Employees** - Shows all employees in a formatted table
2. **Add New Employee** - Add a new Developer or Manager
3. **Display Summary Report** - Shows statistics and totals
4. **Demonstrate Polymorphism** - Shows how bonus calculation varies by type
5. **Search Employee** - Search by ID or name
6. **Exit** - Close the application

## 💰 Bonus Calculation Logic

### Developers
- **Base Bonus**: 10% of salary
- **Experience Bonus**: $500 per year of experience
- **Total**: Base + Experience bonus

### Managers
- **Base Bonus**: 20% of salary
- **Team Bonus**: $1,000 per team member
- **Total**: Base + Team bonus

## 🛠️ Technical Features

- **Exception Handling**: Comprehensive error handling throughout the application
- **Input Validation**: Robust validation for all user inputs
- **Modular Design**: Separated concerns with different folders/namespaces
- **Static Utility Methods**: Reusable validation and formatting functions
- **Type Safety**: Strong typing with proper data types
- **Memory Management**: Proper resource management and disposal

## 📚 Learning Objectives

This project helps understand:
- How to design class hierarchies
- When and how to use abstract classes
- Method overriding and virtual methods
- Property encapsulation and validation
- Static utility classes
- Exception handling
- Console application development
- Project organization and structure

## 🔧 Extending the System

You can extend this system by:
- Adding new employee types (e.g., Intern, Contractor)
- Implementing different bonus calculation strategies
- Adding persistence (database or file storage)
- Creating a web interface
- Adding unit tests
- Implementing reporting features