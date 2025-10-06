using System;
class Program{
    static void Main(){
        // Using var (type inferred at compile time)
        var a = 10;                         // a is int
        // a = "hello";                    // Compile-time error
        Console.WriteLine($"var a + 5 = {a + 5}");
        // Using dynamic (type resolved at runtime)
        dynamic b = 10;
        Console.WriteLine($"dynamic b + 5 = {b + 5}");
        b = "hello";
        Console.WriteLine($"dynamic b + ' world' = {b + " world"}");
    }
}
