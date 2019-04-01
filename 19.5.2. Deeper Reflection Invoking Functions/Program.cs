using System;
using System.Reflection;

class MainClass
{
    public static void Main(String[] args)
    {
        string aname = "_19._5._2.Deeper_Reflection_Invoking_Functions.exe"; //"MyClass";

        Console.WriteLine("Loading: {0}", aname);
        Assembly a = Assembly.LoadFrom(aname);

        foreach (Type t in a.GetTypes())
        {
            if (t.IsClass)
            {
                Console.WriteLine("  Found Class: {0}", t.FullName);

                if (t.GetInterface("MyInterface") == null)
                    continue;

                object o = Activator.CreateInstance(t);

                Console.WriteLine("    Calling Process() on {0}", t.FullName);
            }
        }
    }
}
//File: MyClass.cs
interface MyInterface
{
    void MyMethod(int i);
}

class MyClass : MyInterface
{
    public void MyMethod(int i)
    {
        Console.WriteLine("i:" + i);
    }
}


/*
 * 
 Loading: _19._5._2.Deeper_Reflection_Invoking_Functions.exe
  Found Class: MainClass
  Found Class: MyClass
    Calling Process() on MyClass

*/
