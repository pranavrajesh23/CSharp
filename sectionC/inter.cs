using System;
interface IShape{
    double GetArea();
}
class Circle : IShape{
    public double Radius;
    public Circle(double r) => Radius = r;
    public double GetArea() => Math.PI * Radius * Radius;
}
class Rectangle : IShape{
    public double Length, Width;
    public Rectangle(double l, double w) { Length = l; Width = w; }
    public double GetArea() => Length * Width;
}
class Program{
    static void Main(){
        IShape c = new Circle(5);
        IShape r = new Rectangle(4, 6);
        Console.WriteLine("Circle Area: " + c.GetArea());
        Console.WriteLine("Rectangle Area: " + r.GetArea());
    }
}
