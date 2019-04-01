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
        ConstructorInfo ci = typeof(string).GetConstructor(new Type[] { typeof(char[]) });
        string s = (string)ci.Invoke(new object[] { new char[] { 'H', 'e', 'l', 'l', 'o' } });
        Console.WriteLine(s);
    }
}