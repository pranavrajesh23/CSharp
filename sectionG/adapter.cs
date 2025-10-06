//using System;
//using System.Collections.Generic;
//    //adaptee
//    public class Employee
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public Employee(int id, string name)
//        {
//            this.Id = id;
//            this.Name = name;
//        }
//    }
//    public class EmployeeManager
//    {
//        public List<Employee> employees;
//        public EmployeeManager()
//        {
//            employees = new List<Employee>();
//            this.employees.Add(new Employee(1, "John"));
//            this.employees.Add(new Employee(2, "Michael"));
//            this.employees.Add(new Employee(3, "Jason"));
//        }
//        public virtual string GetAllEmployees()
//        {
//            string result = "";
//            foreach (var emp in employees)
//            {
//                result += $"ID: {emp.Id}, Name: {emp.Name}\n";
//            }
//            return result;
//        }
//    }
//    //target
//    public interface IEmployee
//    {
//        string GetAllEmployees();
//    }
//    //adapter
//    public class EmployeeAdapter : EmployeeManager, IEmployee
//    {
//        //public override string GetAllEmployees()
//        //{
//        //    string allEmp = base.GetAllEmployees();
//        //    return "Employee List:\n" + allEmp;
//        //}
//        public override string GetAllEmployees()
//        { 
//            string table = "ID\tName\n";
//            table += "----------------\n";
//            string[] lines = base.GetAllEmployees().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
//            foreach (string line in lines)
//            {
//                string[] parts = line.Split(',');
//                string idPart = parts[0].Split(':')[1].Trim();
//                string namePart = parts[1].Split(':')[1].Trim();
//                table += $"{idPart}\t{namePart}\n";
//            }
//            return "Employee List (Table Format):\n" + table;
//        }

//    }
//    class prgm
//    {   
//        static void Main()
//        {
//            EmployeeManager manager = new EmployeeManager();
//            string before=manager.GetAllEmployees();
//            IEmployee emp = new EmployeeAdapter();
//            string value = emp.GetAllEmployees();
//            Console.WriteLine(before);
//            Console.WriteLine(value);
//        }
//    }

using System;
using System.Collections.Generic;

// ------------------- ADAPTEE -------------------
public class EmployeeManager
{
    public List<Employee> employees = new List<Employee>
    {
        new Employee(1, "John"),
        new Employee(2, "Michael"),
        new Employee(3, "Jason")
    };

    public string GetEmployeesInfo()
    {
        string result = "";
        foreach (var emp in employees)
        {
            result += $"ID: {emp.Id}, Name: {emp.Name}\n";
        }
        return result;
    }
}

// ------------------- EMPLOYEE CLASS -------------------
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

// ------------------- ADAPTER -------------------
// Target interface
public interface IEmployee
{
    string GetAllEmployees();
}

// Adapter converts EmployeeManager interface to IEmployee
public class EmployeeAdapter : EmployeeManager, IEmployee
{
    public string GetAllEmployees()
    {
        string table = "ID\tName\n----------------\n";
        foreach (var emp in employees)
        {
            table += $"{emp.Id}\t{emp.Name}\n";
        }
        return table;
    }
}

// ------------------- FACADE -------------------
public class EmployeeFacade
{
    private EmployeeManager manager = new EmployeeManager();
    private PayrollSystem payroll = new PayrollSystem();
    private LeaveSystem leave = new LeaveSystem();

    // Simplified method for the client
    public string GetEmployeeFullDetails()
    {
        string info = manager.GetEmployeesInfo();
        string salaries = payroll.GetPayrollInfo();
        string leaves = leave.GetLeaveInfo();

        return $"--- Employee Details ---\n{info}\n{salaries}\n{leaves}";
    }
}

// Subsystems for Facade
public class PayrollSystem
{
    public string GetPayrollInfo() => "Payroll: John-1000, Michael-1200, Jason-1100\n";
}

public class LeaveSystem
{
    public string GetLeaveInfo() => "Leaves: John-10, Michael-15, Jason-12\n";
}

// ------------------- CLIENT -------------------
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Adapter Example ===");
        IEmployee adapter = new EmployeeAdapter();
        Console.WriteLine(adapter.GetAllEmployees());

        Console.WriteLine("=== Facade Example ===");
        EmployeeFacade facade = new EmployeeFacade();
        Console.WriteLine(facade.GetEmployeeFullDetails());
    }
}
