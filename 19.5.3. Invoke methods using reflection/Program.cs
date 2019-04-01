using System;
using System.Reflection;

class MyClass
{


    public MyClass(int i, int j)
    {

        Console.WriteLine("MyClass(int i, int j)");
        Console.WriteLine(i);
        Console.WriteLine(j);
    }

    public int sum()
    {
        Console.WriteLine("sum");
        return 0;
    }

    public bool isBetween(int i)
    {
        Console.WriteLine("isBetween");
        return false;
    }

    public void set(int a, int b)
    {
        Console.Write("Inside set(int, int). ");
    }

    public void set(double a, double b)
    {
        Console.Write("Inside set(double, double). ");
    }

    public void show()
    {
        Console.WriteLine("show");
    }
}

class MainClass
{
    public static void Main()
    {
        Type t = typeof(MyClass);
        MyClass reflectOb = new MyClass(10, 20);
        int val;

        Console.WriteLine("Invoking methods in " + t.Name);
        Console.WriteLine();
        MethodInfo[] mi = t.GetMethods();

        // Invoke each method. 
        foreach (MethodInfo m in mi)
        {
            // Get the parameters. 
            ParameterInfo[] pi = m.GetParameters();

            if (m.Name.CompareTo("set") == 0 &&
               pi[0].ParameterType == typeof(int))
            {
                object[] args = new object[2];
                args[0] = 9;
                args[1] = 18;
                m.Invoke(reflectOb, args);
            }
            else if (m.Name.CompareTo("set") == 0 &&
               pi[0].ParameterType == typeof(double))
            {
                object[] args = new object[2];
                args[0] = 1.12;
                args[1] = 23.4;
                m.Invoke(reflectOb, args);
            }
            else if (m.Name.CompareTo("sum") == 0)
            {
                val = (int)m.Invoke(reflectOb, null);
                Console.WriteLine("sum is " + val);
            }
            else if (m.Name.CompareTo("isBetween") == 0)
            {
                object[] args = new object[1];
                args[0] = 14;
                if ((bool)m.Invoke(reflectOb, args))
                    Console.WriteLine("14 is between x and y");
            }
            else if (m.Name.CompareTo("show") == 0)
            {
                m.Invoke(reflectOb, null);
            }
        }
    }
}
//MyClass(int i, int j)
//10
//20
//Invoking methods in MyClass

//sum
//sum is 0
//isBetween
//Inside set(int, int). Inside set(double, double). show
