using System;
using System.Reflection;
using System.Collections.Generic;

delegate void ComputeDelegate(Employee emp, Decimal percent);


public class Employee
{
    public Decimal Salary;

    public Employee(Decimal salary)
    {
        this.Salary = salary;
    }

    public void ApplyRaiseOf(Decimal percent)
    {
        Salary *= (1 + percent);
    }
}

public class MainClass
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new Employee(20));
        employees.Add(new Employee(50));

        MethodInfo mi = typeof(Employee).GetMethod("ApplyRaiseOf", BindingFlags.Public | BindingFlags.Instance);
        ComputeDelegate applyRaise = (ComputeDelegate)Delegate.CreateDelegate(typeof(ComputeDelegate), mi);

        foreach (Employee e in employees)
        {
            applyRaise(e, (Decimal)0.10);

            Console.WriteLine(e.Salary);
        }
    }
}

//22
