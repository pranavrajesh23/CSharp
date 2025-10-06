using System;
public partial class Person{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    partial void OnNameChanged();
    partial void OnAgeChanged();
}
public partial class Person{
    public void ChangeName(string first, string last){
        FirstName = first;
        LastName = last;
        OnNameChanged();
    }
    public void ChangeAge(int age){
        Age = age;
        OnAgeChanged();
    }
    partial void OnNameChanged(){
        Console.WriteLine($"[Hook] Name changed to: {FirstName} {LastName}");
    }
    partial void OnAgeChanged(){
        Console.WriteLine($"[Hook] Age changed to: {Age}");
    }
}
class Program{
    static void Main(){
        Person p = new Person();
        p.ChangeName("John", "Doe");
        p.ChangeAge(25);
    }
}
