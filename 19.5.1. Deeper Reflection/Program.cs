using System;
using System.Reflection;


// önemli!!! Sınıf altındaki tum Methodların değişken parametrelerini getirir.....
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

        Console.WriteLine("Fields of MyClass");
        Type t = typeof(MyClass);

        Console.WriteLine("Methods of MyClass");
        foreach (MethodInfo m in t.GetMethods())
        {
            Console.WriteLine("{0}", m);
            foreach (ParameterInfo p in m.GetParameters())
            {
                Console.WriteLine("  Param: {0} {1}",
                p.ParameterType, p.Name);
            }
        }

    }
}


/*      Fields of MyClass
        Methods of MyClass
        Int32 MyFunction(Int32, System.Decimal, System.String[])
        Param: System.Int32 i
        Param: System.Decimal d
        Param: System.String[] args
        System.Type GetType()
        System.String ToString()
        Boolean Equals(System.Object)
        Param: System.Object obj
        Int32 GetHashCode()


    */