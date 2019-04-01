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
        Type typeInfo = typeof(object);
        MethodInfo methInfo = typeInfo.GetMethod("ToString");

        ModuleHandle moduleHandle = methInfo.Module.ModuleHandle;
        int typeToken = typeInfo.MetadataToken;
        int methToken = methInfo.MetadataToken;
        Console.WriteLine("Token: {0}", methToken);
    }
}
//Token: 100663845
