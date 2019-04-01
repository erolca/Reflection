using System;
using System.Reflection;
public class MyClass
{
    public class NestClass
    {
        public static int myPublicInt = 0;
    }
    public struct NestStruct
    {
        public static int myPublicInt = 0;
    }
}

public class MyMainClass
{
    public static void Main()
    {
        Type myType = typeof(MyClass);
        Type[] nestType = myType.GetNestedTypes();
        Console.WriteLine("The number of nested types is {0}.", nestType.Length);
        foreach (Type t in nestType)
            Console.WriteLine("Nested type is {0}.", t.ToString());
    }
}