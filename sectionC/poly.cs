using System;
namespace PolymorphismDemo{
    class Shape{
        public virtual void Draw(){
            Console.WriteLine("Drawing a generic shape.");
        }
        public void Area(int side){
            Console.WriteLine("Area of Square: " + (side * side));
        }
        public void Area(int length, int breadth){
            Console.WriteLine("Area of Rectangle: " + (length * breadth));
        }
        public void Area(double radius){
            Console.WriteLine("Area of Circle: " + (3.14 * radius * radius));
        }
    }
    class Circle : Shape{
        public override void Draw(){
            Console.WriteLine("Drawing a Circle.");
        }
    }
    class Rectangle : Shape{
        public override void Draw(){
            Console.WriteLine("Drawing a Rectangle.");
        }
    }
    class Program{
        static void Main(string[] args){
            Console.WriteLine("=== Compile-time Polymorphism (Method Overloading) ===");
            Shape s = new Shape();
            s.Area(5);           // Calls Area(int) ? Square
            s.Area(4, 6);        // Calls Area(int, int) ? Rectangle
            s.Area(3.5);         // Calls Area(double) ? Circle
            Console.WriteLine("\n=== Runtime Polymorphism (Method Overriding) ===");
            Shape shape;          // Base class reference
            shape = new Circle(); // Derived class object
            shape.Draw();         // Calls Circle's Draw()
            shape = new Rectangle();
            shape.Draw();         // Calls Rectangle's Draw()
        }
    }
}
