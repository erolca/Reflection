using System;
using System.Reflection;

class MyClass
{
    public int Field1;
    public int Field2;
    public void Method1() { }
    public int Method2() { return 1; }
    public void Method3() { }
}

class MainClass
{
    static void Main()
    {
        Type t = typeof(MyClass);
        MethodInfo[] mi = t.GetMethods();

        foreach (MethodInfo m in mi)
            Console.WriteLine("Method: {0}", m.Name);

    }
}
//Method: Method1
//Method: Method2
//Method: ToString
//Method: Equals
//Method: GetHashCode
//Method: GetType