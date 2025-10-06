using System;
namespace TypeConversionsDemo{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine("=== Implicit Conversion ===");
            int intVal = 100;
            float floatVal = intVal;  // Implicit conversion (int to float)
            Console.WriteLine($"int to float: {floatVal}"); //100

            Console.WriteLine("\n=== Explicit Conversion (Casting) ===");
            float originalFloat = 123.45f;
            int castedInt = (int)originalFloat;  // Explicit cast (possible data loss)
            Console.WriteLine($"float to int: {castedInt}"); //123

            Console.WriteLine("\n=== Using 'as' Operator ===");
            object obj1 = "hello world";
            string str1 = obj1 as string;
            Console.WriteLine($"obj1 as string: {str1}"); //hello world

            object obj2 = 42;
            string str2 = obj2 as string;  // Will be null
            Console.WriteLine($"obj2 as string: {str2 ?? "null"}"); //null

            Console.WriteLine("\n=== Using 'is' Operator ===");
            object obj3 = "C#";
            if (obj3 is string s){
                Console.WriteLine($"obj3 is a string: {s}"); //c#
            }
            else{
                Console.WriteLine("obj3 is not a string"); 
            }
            if (obj3 is int){
                Console.WriteLine("obj3 is an int");
            }
            else{
                Console.WriteLine("obj3 is not an int"); //this will be printed
            }

            Console.WriteLine("\n=== Using Convert Class ===");
            string strNumber = "123";
            int convertedInt = Convert.ToInt32(strNumber);
            Console.WriteLine($"Converted string to int: {convertedInt}");//123

            string strBool = "true";
            bool convertedBool = Convert.ToBoolean(strBool);
            Console.WriteLine($"Converted string to bool: {convertedBool}");//True

            string invalidStr = "abc";
            try
            {
                int invalidInt = Convert.ToInt32(invalidStr);
                Console.WriteLine($"Converted invalid string to int: {invalidInt}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Conversion failed: invalid format."); //this will be printed
            }

            Console.WriteLine("\n=== End of Demo ===");
        }
    }
}