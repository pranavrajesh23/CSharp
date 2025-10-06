using System;
class BaseClass{
    public void InstanceMethod()    {
        Console.WriteLine("Base class instance method");
    }
    public static void StaticMethod()    {
        Console.WriteLine("Base class static method");
    }
}
class DerivedClass : BaseClass{
    public new void InstanceMethod(){
        Console.WriteLine("Derived class instance method");
    }
    public new static void StaticMethod()    {
        Console.WriteLine("Derived class static method");
    }
}
class Program{
    static void Main(){
        BaseClass baseObj = new BaseClass();
        DerivedClass derivedObj = new DerivedClass();
        BaseClass baseRefDerivedObj = new DerivedClass();
        baseObj.InstanceMethod();             // Base class instance method
        derivedObj.InstanceMethod();          // Derived class instance method
        baseRefDerivedObj.InstanceMethod();   // Base class instance method (hiding!)
        BaseClass.StaticMethod();             // Base class static method
        DerivedClass.StaticMethod();          // Derived class static method
    }
}
