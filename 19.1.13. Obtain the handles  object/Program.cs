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
        Type typeInfo                   = typeof(object);
        MethodInfo methInfo             = typeInfo.GetMethod("ToString");
        RuntimeTypeHandle typeHandle    = typeInfo.TypeHandle;
        RuntimeMethodHandle methHandle  = methInfo.MethodHandle;
        Console.WriteLine("Handle: {0}", methHandle);
    }
}
// Handle: System.RuntimeMethodHandle