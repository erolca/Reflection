using System;
using System.Reflection;

class MyClass
{
    String myMessage = "Hello World.";
    public string MyProperty1
    {
        get
        {
            return myMessage;
        }
        set
        {
            myMessage = value;
        }
    }
}
class TestClass
{
    static void Main()
    {
        try
        {
            Type myType = typeof(MyClass);
            PropertyInfo myStringProperties1 = myType.GetProperty("MyProperty1", typeof(string));
            Console.WriteLine("The name of the first property of MyClass is {0}.", myStringProperties1.Name);
            Console.WriteLine("The type of the first property of MyClass is {0}.", myStringProperties1.PropertyType);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException :" + e.Message);

        }
        catch (AmbiguousMatchException e)
        {
            Console.WriteLine("AmbiguousMatchException :" + e.Message);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Source : {0}", e.Source);
            Console.WriteLine("Message : {0}", e.Message);
        }
    }
}