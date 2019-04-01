using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Constructor |
                AttributeTargets.Field |
                AttributeTargets.Method |
                AttributeTargets.Property,
                AllowMultiple = true)]




public class BugFixAttribute : System.Attribute
{
    public BugFixAttribute(int bugID, string programmer, string date)
    {
        this.BugID = bugID;
        this.Programmer = programmer;
        this.Date = date;
    }
    public int BugID;
    public string Date;
    public string Programmer;
    public string Comment { get; set; }
}
[BugFixAttribute(1, "A", "01/04/05", Comment = "value")]





public class MyMath
{
    public double DoFunc1(double param1)
    {
        return param1 + DoFunc2(param1);
    }

    public double DoFunc2(double param1)
    {
        return param1 / 3;
    }
}






public class Tester
{
    public static void Main()
    {
        //MyMath mm = new MyMath();
        /*System.Reflection.*/ MemberInfo inf = typeof(MyMath);
        object[] attributes = inf.GetCustomAttributes(typeof(BugFixAttribute), false);

      

        foreach (Object attribute in attributes)
        {
            BugFixAttribute bfa = (BugFixAttribute)attribute;
            Console.WriteLine("\nBugID: {0}", bfa.BugID);
            Console.WriteLine("Programmer: {0}", bfa.Programmer);
            Console.WriteLine("Date: {0}", bfa.Date);
            Console.WriteLine("Comment: {0}", bfa.Comment);
        }
    }
}