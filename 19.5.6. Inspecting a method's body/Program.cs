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
        MethodInfo m = typeof(object).GetMethod("ToString");
        MethodBody mb = m.GetMethodBody();
        byte[] ilb = mb.GetILAsByteArray();
        for (int i = 0; i < ilb.Length; i++)
            Console.Write("{0:X} ", ilb[i]);
    }
}
//2 28 9 0 0 6 6F 2 0 0 6 2A