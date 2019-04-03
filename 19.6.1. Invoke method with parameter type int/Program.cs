using System;
using System.Reflection;

class MyClass
{
    public MyClass(int i)
    {
        Console.WriteLine("Constructing MyClass(int). ");
    }

    public MyClass(int i, int j)
    {
        Console.WriteLine("Constructing MyClass(int, int). ");
    }

    public int sum()
    {
        return 0;
    }

    public bool isBetween(int i)
    {
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
        Console.WriteLine("Values");
    }
}

class MainClass
{
    public static void Main()
    {
        Type t = typeof(MyClass);
        int x;

        // Find matching constructor. 
        ConstructorInfo[] ci = t.GetConstructors();

        for (x = 0; x < ci.Length; x++)
        {
            ParameterInfo[] pi = ci[x].GetParameters();
            if (pi.Length == 2) break;
        }

        if (x == ci.Length)
        {
            Console.WriteLine("No matching constructor found.");
            return;
        }
        else
            Console.WriteLine("Two-parameter constructor found.\n");



        // Construct the object.   
        object[] consargs = new object[2];
        consargs[0] = 10;
        consargs[1] = 20;
        object reflectOb = ci[x].Invoke(consargs);
    }
}


//Two-parameter constructor found.
//Constructing MyClass(int, int).