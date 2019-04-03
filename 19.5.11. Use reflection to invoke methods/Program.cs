using System;
using System.Reflection;
public class MainClass
{
    public static void Main()
    {
        Type ct = Type.GetType("HelloWorld");
        Object obj = Activator.CreateInstance(ct);
        MethodInfo mi = ct.GetMethod("SayHello");
        mi.Invoke(obj, new Object[] { "Hitesh" });
    }
}
class HelloWorld
{
    public void SayHello(String name)
    {
        Console.WriteLine("Hello " + name + " to a Dynamic World!");
    }
}