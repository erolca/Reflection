using System;
using System.Reflection;

public interface IFaceOne
{
    void MethodA();
}

public interface IFaceTwo
{
    void MethodB();
}

public class MyClass : IFaceOne, IFaceTwo
{
    public enum MyNestedEnum { }

    public int myIntField;
    public string myStringField;

    public void myMethod(int p1, string p2)
    {
    }

    public int MyProp
    {
        get { return myIntField; }
        set { myIntField = value; }
    }

    void IFaceOne.MethodA() { }
    void IFaceTwo.MethodB() { }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        MyClass theMyClass = new MyClass();

        Type t = Type.GetType("MyClass");
        Console.WriteLine("Enum name? {0}", t.Name);
        Console.WriteLine("Is enum nested private? {0}", t.IsNestedPrivate);
        Console.WriteLine("Is enum nested public? {0}", t.IsNestedPublic);


    }
}
//Enum name? MyClass
//Is enum nested private? False
//Is enum nested public? False