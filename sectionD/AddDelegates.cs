using System;
namespace MathWithDelegates
{
    public delegate double MathOperation(double x, double y);
    public class Calculator{
        public double Add(double a, double b){
            return a + b;
        }
        public double Subtract(double a, double b){
            return a - b;
        }
        public double Multiply(double a, double b){
            return a * b;
        }
        public double Divide(double a, double b){
            if (b == 0){
                Console.WriteLine("Cannot divide by zero.");
                return double.NaN;
            }
            return a / b;
        }
    }
    class Program{
        static void Main(string[] args){
            Calculator calc = new Calculator();
            MathOperation operation;
            double x=10,y=10;
            operation = calc.Add;
            Console.WriteLine($"Add: {x} + {y} = {operation(x, y)}");
            operation = calc.Subtract;
            Console.WriteLine($"Subtract: {x} - {y} = {operation(x, y)}");
            operation = calc.Multiply;
            Console.WriteLine($"Multiply: {x} * {y} = {operation(x, y)}");
            operation = calc.Divide;
            Console.WriteLine($"Divide: {x} / {y} = {operation(x, y)}");
        }
    }
}
