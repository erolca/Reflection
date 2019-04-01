using System;
using System.Reflection;
using System.Globalization;
class MyClass
{

    public void MethodMyclass()
    {
        Console.WriteLine("MethodMyclass method called");
    }


}

class Class1
{
    DateTime[] dateTimes = new DateTime[10];
    public DateTime this[int index]
    {
        get { return dateTimes[index]; }
        set { dateTimes[index] = value; }
    }


    private DateTime dateOfBirth;
    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public void Test()
    {
        Console.WriteLine("Test method called");
    }


    private string field;

    public string Property
    {
        get { return field; }
        set { field = value; }
    }

}


class MainClass
{

    static void Main(string[] args)
    {

        Type typex = Type.GetType("MyClass");
        object OO = Activator.CreateInstance(typex);
        typex.InvokeMember("MethodMyclass", BindingFlags.InvokeMethod, null, OO, new object[] { });

        Type type = Type.GetType("Class1");
        object o = Activator.CreateInstance(type);

        type.InvokeMember("Test", BindingFlags.InvokeMethod, null, o, new object[] { });

        // Using a ConstructorInfo
        ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { });

        o = constructorInfo.Invoke(new object[] { });

        type.InvokeMember("Test", BindingFlags.InvokeMethod, null, o, new object[] { });

        // Type.InvokeMember
        o = type.InvokeMember("Class1", BindingFlags.CreateInstance, null, null, new object[] { });

        type.InvokeMember("Test", BindingFlags.InvokeMethod, null, o, new object[] { });

    }
}