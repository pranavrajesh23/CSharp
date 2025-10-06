using System;
using System.Collections.Generic;
using System.Linq;
public class Employee{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}
class prgm {
    static void Main() {
        List<Employee> employees = new List<Employee> {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 55000 },
            new Employee { Id = 4, Name = "David", Department = "IT", Salary = 70000 },
            new Employee { Id = 5, Name = "Eve", Department = "Finance", Salary = 65000 }
        };
        var results = from e in employees
                      where e.Salary > 40000
                      group e by e.Department into DeptInfo
                      orderby DeptInfo.Key descending
                      select new
                      {
                          Department = DeptInfo.Key,
                          Empl = DeptInfo.OrderBy(e => e.Name)
                      };
        foreach (var d in results){
            Console.WriteLine($"{d.Department}");
            foreach(var emp in d.Empl){
                Console.WriteLine($"{emp.Name},{emp.Salary}");
            }
        }
    }
}