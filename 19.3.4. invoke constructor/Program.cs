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

    public MyClass(int i, int j, string k)
    {
        Console.WriteLine("Constructing MyClass(int, int,string). ");
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
        Assembly asm = Assembly.LoadFrom("_19._3._4.invoke_constructor.exe"/*"main.exe"*/);

        Type[] alltypes = asm.GetTypes();

        Type t = alltypes[0]; // use first class found 

        Console.WriteLine("Using: " + t.Name);

        ConstructorInfo[] ci = t.GetConstructors();

        // Use first constructor found. 
        ParameterInfo[] cpi = ci[0].GetParameters();
        object reflectOb;

        if (cpi.Length > 0)
        {
            object[] consargs = new object[cpi.Length];

            // initialize args 
            for (int n = 0; n < cpi.Length; n++)
                consargs[n] = 10 + n * 20;

            // construct the object 
            reflectOb = ci[0].Invoke(consargs);
        }
        else
            reflectOb = ci[0].Invoke(null);

    }
}