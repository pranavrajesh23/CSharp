// public class Animal {
//     public void Basic(){
//         Console.WriteLine("We are going to see the sounds of the animals");
//     }
//     public virtual void Speak() {
//         Console.WriteLine("The animal makes a sound.");
//     }
// }

// public class Dog : Animal {
//     public override void Speak() {
//         Console.WriteLine("The dog barks.");
//     }
// }
// public class Cat : Animal {
//     public override void Speak() {
//         Console.WriteLine("The Cat Meows.");
//     }
// }

// class Program{
//     public static void Main()
//     {
//         Animal dog=new Dog();
//         dog.Speak();
//         dog.Basic();
//         Animal cat=new Cat();
//         cat.Speak();
//         Animal ani=new Animal();
//         ani.Speak();
//     }
// }

using System;
using Start;
using Stop;
namespace Start{
    class Program{
        public string name;
        public void pgrm(){
            Console.WriteLine("The Programming Language is " + name);
        }
    }
}
namespace Stop{
    class Language{
        public void lng(string name){
            Console.Write(name + " it is the great language of all");
        }
    }
}
class Pranav{
    public static void Main(){
        Program prog = new Program();
        prog.name = "Java";
        prog.pgrm();
        Language lang = new Language();
        lang.lng(prog.name);
    }
}

// Simple C# program to illustrate identifiers
using System;

class Geeks
{
    // Main Method
    static public void Main()
    {
        // variable
        int a = 10;
        int b = 39;
        int c;

        // basic operation
        c = a + b;

        Console.WriteLine("The sum of two number is: {0}", c);
    }
}




