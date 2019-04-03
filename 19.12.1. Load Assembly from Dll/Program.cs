using System;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;
using System.Text;


namespace AssemblyDemo1
{
    class Employee
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Assembly a = Assembly.GetExecutingAssembly();
        Console.WriteLine(a.GetName().Name, a.Location);
        Console.WriteLine(a.GlobalAssemblyCache);
        Console.WriteLine(a.ImageRuntimeVersion);

        Assembly otherAssembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "\\SampleAssembly.DLL");
        Console.WriteLine("Other Assembly: {0}", otherAssembly.GetName().Name);
        Console.WriteLine("Types contained in {0}", otherAssembly.GetName().Name);
        foreach (Type t in otherAssembly.GetTypes())
        {
            Console.WriteLine(t.Name);
        }
    }
}