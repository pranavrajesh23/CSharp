using System;
public abstract class Coffee
{
    public abstract string Prepare();
}
public class Espresso : Coffee
{
    public override string Prepare()
    {
        return "Preparing a strong espresso.";
    }
}
public class Latte : Coffee
{
    public override string Prepare()
    {
        return "Preparing a smooth latte.";
    }
}
public abstract class CoffeeFactory
{
    public abstract Coffee MakeCoffee();
    public string Serve()
    {
        Coffee coffee = MakeCoffee();
        return coffee.Prepare();
    }
}
public class ExpressoFactory:CoffeeFactory
{
    public override Coffee MakeCoffee()
    {
        return new Espresso();
    }
}
public class LatteFactory : CoffeeFactory
{
    public override Coffee MakeCoffee()
    {
        return new Latte();
    }
}
class program
{
    static void order(CoffeeFactory coffee)
    {
        Console.WriteLine(coffee.Serve());
    }
    //static void Main()
    //{
    //    order(new ExpressoFactory());
    //    order(new LatteFactory());
    //}
    static void Main()
    {
        Console.WriteLine("Welcome! Which coffee would you like?");
        Console.WriteLine("1. Espresso");
        Console.WriteLine("2. Latte");
        Console.WriteLine("3. Cappuccino");
        Console.Write("Enter your choice (1-3): ");
        string input = Console.ReadLine();
        CoffeeFactory factory = null;
        switch (input)
        {
            case "1":
                factory = new ExpressoFactory();
                break;
            case "2":
                factory = new LatteFactory();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }
        order(factory);
    }
}