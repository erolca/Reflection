using System;
using System.Reflection;

class MyClass
{
    public int Field1;
    public int Field2;
    public void Method1() { }
    public int Method2() { return 1; }
}

class MainClass
{
    static void Main()
    {
        Type t = typeof(MyClass);
        FieldInfo[] fi = t.GetFields();

        foreach (FieldInfo f in fi)
            Console.WriteLine("Field : {0}", f.Name);

    }
}