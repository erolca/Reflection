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

            for (int j = 0; j < classMethodNames.Length; j++)
            {
                Console.WriteLine("Interface method: {0}", interfaceMethodNames[j].Name);
                Console.WriteLine("is implemented by class method: {0}", classMethodNames[j].Name);
            }
            Console.WriteLine();
        }
    }
}



//Info on Interface named: IFaceOne
//Interface method: MethodA
//is implemented by class method : IFaceOne.MethodA

//Info on Interface named: IFaceTwo
//Interface method: MethodB
//is implemented by class method : IFaceTwo.MethodB