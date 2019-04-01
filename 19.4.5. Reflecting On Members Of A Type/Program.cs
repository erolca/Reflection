using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tester
{
    public static void Main()
    {
        Type theType = Type.GetType("System.Reflection.Assembly");
        Console.WriteLine("\nSingle Type is {0}\n", theType);
        MemberInfo[] mbrInfoArray = theType.GetMembers();
        foreach (MemberInfo mbrInfo in mbrInfoArray)
        {
            Console.WriteLine("{0} is a {1}", mbrInfo, mbrInfo.MemberType);
        }
    }
}