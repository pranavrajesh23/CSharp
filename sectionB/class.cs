using System;

namespace SchoolApp
{
    public class Student
    {
        // Fields (private variables)
        private int studentId;
        private string name;
        private int age;
        private string course;
        private double grade;
        // Properties (to access fields safely)
        public int StudentId
        {
            get { return studentId; }
            set
            {
                if (value > 0)
                    studentId = value;
                else
                    throw new ArgumentException("Student ID must be positive.");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    throw new ArgumentException("Name cannot be empty.");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 5 && value <= 100)
                    age = value;
                else
                    throw new ArgumentException("Age must be between 5 and 100.");
            }
        }
        public string Course
        {
            get { return course; }
            set { course = value; }
        }
        public double Grade
        {
            get { return grade; }
            set
            {
                if (value >= 0 && value <= 100)
                    grade = value;
                else
                    throw new ArgumentException("Grade must be between 0 and 100.");
            }
        }
        // Constructors
        // Default Constructor
        public Student()
        {
            studentId = 0;
            name = "Unknown";
            age = 0;
            course = "Not Assigned";
            grade = 0.0;
        }
        // Parameterized Constructor
        public Student(int id, string name, int age, string course, double grade)
        {
            StudentId = id;
            Name = name;
            Age = age;
            Course = course;
            Grade = grade;
        }
        // Methods (behavior)
        // Display student details
        public void DisplayInfo()
        {
            Console.WriteLine("----- Student Information -----");
            Console.WriteLine($"ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Course: {Course}");
            Console.WriteLine($"Grade: {Grade}");
        }
        // Check if student passed (simple example)
        public bool HasPassed()
        {
            return Grade >= 50;
        }
        // Update grade
        public void UpdateGrade(double newGrade)
        {
            Grade = newGrade;
            Console.WriteLine($"Grade updated to: {Grade}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Create student using parameterized constructor
            Student s1 = new Student(101, "Alice Johnson", 20, "Computer Science", 85.5);
            s1.DisplayInfo();
            // Check pass status
            Console.WriteLine(s1.HasPassed() ? "Status: Passed" : "Status: Failed");
            // Update grade
            s1.UpdateGrade(92.3);
        }
    }
}