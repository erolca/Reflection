using System;
using System.Reflection;
using System.Security;


public class MyClass
{
    public MyClass(int i) { }

    public static void Main()
    {
        try
        {
            Type myType = typeof(MyClass);
            Type[] types = new Type[1];
            types[0] = typeof(int);
            ConstructorInfo constructorInfoObj = myType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);
            Console.WriteLine(constructorInfoObj.ToString());
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: " + e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("ArgumentException: " + e.Message);
        }
        catch (SecurityException e)
        {
            Console.WriteLine("SecurityException: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}