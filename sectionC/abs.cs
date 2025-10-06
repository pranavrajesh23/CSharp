using System;
abstract class Shape{
    public abstract double CalculateArea();
}
class Circle : Shape{
    private double radius;
    public Circle(double radius){
        this.radius = radius;
    }
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}
class Rectangle : Shape{
    private double length;
    private double width;
    public Rectangle(double length, double width){
        this.length = length;
        this.width = width;
    }
    public override double CalculateArea(){
        return length * width;
    }
}
class Program{
    static void Main(){
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);
        Console.WriteLine("Circle Area: " + circle.CalculateArea());
        Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
    }
}
