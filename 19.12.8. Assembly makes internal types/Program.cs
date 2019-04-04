// compile with: /target:library
using System.Runtime.CompilerServices;
using System;


//19.12.8.	Assembly makes internal types and internal members visible to the assembly called your_assemblies.

[assembly: InternalsVisibleTo("your_assemblies")]
class Class1
{
    public void Test()
    {
        Console.WriteLine("Class1.Test");
    }
}
public class Class2
{
    internal void Test()
    {
        Console.WriteLine("Class2.Test");
    }
}

// cs_friend_assemblies_2.cs
// compile with: /reference:cs_friend_assemblies.dll /out:your_assemblies.exe
public class M
{
    static void Main()
    {
        Class1 a = new Class1();
        a.Test();

        Class2 b = new Class2();
        b.Test();
    }
}