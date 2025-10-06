using System;

class AgeException : Exception
{
    public AgeException(string message) : base(message) { }
}

class Program
{
    static void AgeCheck(int age)
    {
        if(age>18)
        {
            Console.WriteLine($"You can vote with the age : {age}");
        }
        else
        {
            throw new AgeException("You are a minor and could be arrested for this act");
        }
    }
    static void Main(string[] args)
    {
        try
        {
            AgeCheck(15);
        }
        catch(AgeException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Successfully executed");
        }
    }
}
