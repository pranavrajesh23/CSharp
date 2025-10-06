using System;

class program
{   
    public void print()
    {
        Console.WriteLine("Print");
    }
    public static void display(program p)
    {
        p.print();
    }
}
class pro
{
    public static void Main()
    {
        program.display(new program());
    }
}

