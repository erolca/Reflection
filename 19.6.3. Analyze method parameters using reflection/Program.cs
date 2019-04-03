using System;
using System.Reflection;

class MyClass
{
    public MyClass(int i, int j)
    {
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
    }

    public void set(double a, double b)
    {
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

        Console.WriteLine("Analyzing methods in " + t.Name);
        Console.WriteLine();

        Console.WriteLine("Methods supported: ");

        MethodInfo[] mi = t.GetMethods();

        // Display methods supported by MyClass. 
        foreach (MethodInfo m in mi)
        {
            // Display return type and name. 
            Console.Write("   " + m.ReturnType.Name +
                            " " + m.Name + "(");

            // Display parameters. 
            ParameterInfo[] pi = m.GetParameters();

            for (int i = 0; i < pi.Length; i++)
            {
                Console.Write(pi[i].ParameterType.Name +
                              " " + pi[i].Name);
                if (i + 1 < pi.Length) Console.Write(", ");
            }

            Console.WriteLine(")");

            Console.WriteLine();
        }
    }
}

/*
 
    Analyzing methods in MyClass

    Methods supported:
    Int32 sum()

    Boolean isBetween(Int32 i)

    Void set(Int32 a, Int32 b)

    Void set(Double a, Double b)

    Void show()

    Type GetType()

    String ToString()

    Boolean Equals(Object obj)

    Int32 GetHashCode()
     
     
     
     */































