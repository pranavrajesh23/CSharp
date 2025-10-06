using System;
using System.Collections.Generic;

// Define a class with a property and implement IComparable<T>
public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Implement CompareTo to sort by Age
    public int CompareTo(Person other)
    {
        if (other == null) return 1; // Handle null objects
        return this.Age.CompareTo(other.Age);
    }

    // Override ToString for easy display
    public override string ToString()
    {
        return $"{Name}, {Age} years old";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list of Person objects
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Charlie", Age = 35 },
            new Person { Name = "Diana", Age = 28 }
        };

        // Sort the list using CompareTo
        people.Sort();

        // Display the sorted list
        Console.WriteLine("People sorted by Age:");
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}
