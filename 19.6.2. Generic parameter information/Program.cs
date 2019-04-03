using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        PrintTypeParams(typeof(List<>));
        PrintTypeParams(typeof(List<int>));
        PrintTypeParams(typeof(Nullable<>));
    }
    private static void PrintTypeParams(Type t)
    {
        Console.WriteLine(t.FullName);
        foreach (Type ty in t.GetGenericArguments())
        {
            Console.WriteLine(ty.FullName);
            Console.WriteLine(ty.IsGenericParameter);
            if (ty.IsGenericParameter)
            {
                Type[] constraints = ty.GetGenericParameterConstraints();
                foreach (Type c in constraints)
                    Console.WriteLine(c.FullName);
            }
        }
    }
}