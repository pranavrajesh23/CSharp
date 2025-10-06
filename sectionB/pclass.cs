using System;
public partial class Person{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public partial class Person{
    public void PrintName(){
        Console.WriteLine($"{FirstName} {LastName}");
    }
}
class program{
    static void Main(string[] args){
        Person p = new Person();
        p.FirstName = "John";
        p.LastName = "Doe";
        p.PrintName();  
    }
}