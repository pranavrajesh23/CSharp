using System;
class Student{
    string name;
    int age;
    string course;
    // 1?? Default constructor
    public Student(){
        name = "Unknown";
        age = 18;
        course = "Not Assigned";
    }
    // 2?? Constructor that calls default one
    public Student(string n) : this()  // ?? Calls Student()
    {
        name = n;
    }
    // 3?? Constructor that calls second one
    public Student(string n, int a, string c) : this(n)  // ?? Calls Student(string n)
    {
        age = a;
        course = c;
    }
    public void Display(){
        Console.WriteLine($"Name: {name}, Age: {age}, Course: {course}");
    }
}
class Program{
    static void Main(){
        Student s1 = new Student();
        Student s2 = new Student("Alice");
        Student s3 = new Student("Bob", 21, "Computer Science");
        s1.Display();
        s2.Display();
        s3.Display();
    }
}
