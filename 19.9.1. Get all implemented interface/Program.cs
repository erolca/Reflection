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

        Type[] iFaces = t.GetInterfaces();

        for (int i = 0; i < iFaces.Length; i++)
        {
            Console.WriteLine("Info on Interface named: {0}", iFaces[i]);

            MethodInfo[] classMethodNames = t.GetInterfaceMap(iFaces[i]).TargetMethods;
            MethodInfo[] interfaceMethodNames = t.GetInterfaceMap(iFaces[i]).InterfaceMethods;

        }
    }
}
//Info on Interface named: IFaceOne
//Info on Interface named: IFaceTwo