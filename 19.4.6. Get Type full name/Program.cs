using System;
using System.Reflection;

//19.4.6.	Get Type full name and base type and its members

public class TypeInfo
{
    public static void Main(String[] args)
    {
        Type ct = Type.GetType(args[0]);
        Console.WriteLine(ct.FullName + " : " + ct.BaseType);
        MemberInfo[] members = ct.GetMembers();
        foreach (MemberInfo member in members)
        {
            Console.WriteLine("-->" + member);
        }
    }
}