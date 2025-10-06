using System;
class Circle
{
    public const double Pi = 3.14159;
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Circle.Pi); // 3.14159
        //Circle.Pi = 3.14; // ? Error: cannot modify a const
    }
}
