using System;
using System.Reflection;

public class MainClass
{
    public static void Main()
    {
        Type typeInfo           = typeof(object);
        MethodInfo methInfo     = typeInfo.GetMethod("ToString");
        Console.WriteLine("Info: {0}", methInfo);

    }
}
//Info: System.String ToString()