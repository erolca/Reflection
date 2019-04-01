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
        Type listType = typeof(List<>);
        Type listOfIntType = listType.MakeGenericType(typeof(int));
        Console.WriteLine(listOfIntType.FullName);
    }
}
//System.Collections.Generic.List`1[[System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicK
//eyToken=b77a5c561934e089]]