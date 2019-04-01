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
        MyClass f = new MyClass();

        Type t = f.GetType();
        FieldInfo[] fi = t.GetFields();
        foreach (FieldInfo field in fi)
            Console.WriteLine("Field: {0}", field.Name);
    }
}