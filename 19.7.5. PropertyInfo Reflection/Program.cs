using System;
using System.Reflection;

public class Myproperty
{
    private string caption = "A Default caption";
    public string Caption
    {
        get { return caption; }
        set
        {
            if (caption != value) { caption = value; }
        }
    }
}

class Mypropertyinfo
{
    public static int Main()
    {
        Type MyTypea = Type.GetType("Myproperty");
        PropertyInfo Mypropertyinfoa = MyTypea.GetProperty("Caption");
        Type MyTypeb = Type.GetType("System.Reflection.MethodInfo");
        PropertyInfo Mypropertyinfob = MyTypeb.GetProperty("MemberType");

        MethodInfo Mygetmethodinfoa = Mypropertyinfoa.GetGetMethod();
        Console.WriteLine(Mypropertyinfoa.Name);
        Console.WriteLine(Mygetmethodinfoa.ReturnType);
        MethodInfo Mygetmethodinfob = Mypropertyinfob.GetGetMethod();
        Console.WriteLine(Mypropertyinfob.Name);
        Console.WriteLine(Mygetmethodinfob.ReturnType);

        Console.WriteLine(MyTypea.FullName + "." + Mypropertyinfoa.Name + " - " + Mypropertyinfoa.GetGetMethod());
        Console.WriteLine(MyTypeb.FullName + "." + Mypropertyinfob.Name + " - " + Mypropertyinfob.GetGetMethod());
        return 0;
    }
}