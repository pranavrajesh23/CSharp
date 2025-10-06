using System;
namespace DelegateOverrideDemo
{
    public delegate void GreetDelegate(string name);
    public class Greeter{
        public virtual void Greet(string name){
            Console.WriteLine($"Hello, {name}!");
        }
    }
    public class FancyGreeter : Greeter{
        public override void Greet(string name){
            Console.WriteLine($"Welcome, {name}! Have a magical day! ?");
        }
    }
    public class CasualGreeter : Greeter
    {
        public override void Greet(string name)
        {
            Console.WriteLine($"Hey {name}, what's up?");
        }
    }
    class Program{
        static void Main(string[] args){
            Greeter normal = new Greeter();
            Greeter fancy = new FancyGreeter();
            Greeter casual = new CasualGreeter();
            GreetDelegate greet;
            greet = normal.Greet;
            greet("Alice");
            greet = fancy.Greet;
            greet("Bob");
            greet = casual.Greet;
            greet("Charlie");
        }
    }
}
