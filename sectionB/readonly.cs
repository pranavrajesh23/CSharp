using System;
class Circle{
    public readonly double radius;
    public readonly double area;
    public Circle(double radius){
        this.radius = radius;
        area = radius * radius * 3.14159;
    }
}
class Program{
    static void Main(){
        Circle c1 = new Circle(5);
        Console.WriteLine(c1.radius); // 5
        Console.WriteLine(c1.area);   // 78.53975
        // c1.radius = 10; // ? Error: cannot modify readonly field
    }
}
