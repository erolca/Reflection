using System;
using System.Reflection;

//19.1.11.	Type: FullName, BaseType, IsAbstract, IsCOMObject, IsSealed, IsClass



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
        MyClass f = new MyClass();

        Type t = f.GetType();

        Console.WriteLine("Full name is         : {0}",          t.FullName);
        Console.WriteLine("Base is              : {0}",               t.BaseType);
        Console.WriteLine("Is it abstract?      : {0}",        t.IsAbstract);
        Console.WriteLine("Is it a COM object?  : {0}",    t.IsCOMObject);
        Console.WriteLine("Is it sealed?        : {0}",           t.IsSealed);
        Console.WriteLine("Is it a class?       : {0}",         t.IsClass);
  

    }
}
//Full name is: MyClass
//Base is: System.Object
//Is it abstract? False
//Is it a COM object? False
//Is it sealed? False
//Is it a class? True