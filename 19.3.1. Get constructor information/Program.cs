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

    public MyClass(int i, int j, int k)
    {
        Console.WriteLine("Constructing MyClass(int, int). ");
    }


    /*methods*/
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

        // Get constructor info. 
        ConstructorInfo[] ci = t.GetConstructors();

        Console.WriteLine("Available constructors: ");
        foreach (ConstructorInfo c in ci)
        {
            // Display return type and name. 
            Console.Write("   " + t.Name + "(");

            // Display parameters. 
            ParameterInfo[] pi = c.GetParameters();

            for (int i = 0; i < pi.Length; i++)
            {
                Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                if (i + 1 < pi.Length)
                    Console.Write(", ");
            }

            Console.WriteLine(")");
        }
        Console.WriteLine();
    }
}
/*
 * 
Available constructors:
MyClass(Int32 i)
MyClass(Int32 i, Int32 j)

 */