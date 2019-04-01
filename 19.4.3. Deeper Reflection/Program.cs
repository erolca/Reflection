using System;
using System.Reflection;


//19.4.3.	Deeper Reflection: iterate through the fields of the class
class MyClass
{
    MyClass() { }
    static void Process()
    {
    }

    public int MyFunction(int i, Decimal d, string[] args)
    {
        return (0);
    }
    public int value = 0;
    public float log = 1.0f;
    public static int value2 = 44;
}

class MainClass
{
    public static void Main(String[] args)
    {
        // 
        Console.WriteLine("Fields of MyClass");
        Type t = typeof(MyClass);
        foreach (MemberInfo m in t.GetFields())
        {
            Console.WriteLine("{0}", m);
        }

    }
}
