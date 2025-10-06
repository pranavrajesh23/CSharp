using System;
class Animal{
    // Virtual method in base class
    public virtual void MakeSound(){
        Console.WriteLine("Animal makes a sound");
    }
}
class Dog : Animal{
    // Override virtual method
    public override void MakeSound(){
        Console.WriteLine("Dog barks");
    }
}
class Bulldog : Dog {
    // Sealed override prevents further overriding
    public sealed override void MakeSound(){
        Console.WriteLine("Bulldog growls");
    }
}
//class TinyBulldog : Bulldog
//{
//    public override void MakeSound() // Error: cannot override sealed method
//    {
//        Console.WriteLine("Tiny bulldog squeaks");
//    }
//}
class Program{
    static void Main(){
        Animal myAnimal = new Animal();
        myAnimal.MakeSound();   // Output: Animal makes a sound
        Dog myDog = new Dog();
        myDog.MakeSound();      // Output: Dog barks
        //Bulldog myBulldog = new Bulldog();
        //myBulldog.MakeSound();  // Output: Bulldog growls
    }
}
