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
        Console.WriteLine(typeof(List<>).Equals(typeof(List<int>).GetGenericTypeDefinition()));
    }
}
//True