using System;
using System.Reflection;


//19.12.9.	Use the file name to load the assembly into the current application domain.


public class Asmload0
{
    public static void Main()
    {

        Assembly a = Assembly.Load("example");
        // Get the type to use.
        Type myType = a.GetType("Example");
        // Get the method to call.
        MethodInfo mymethod = myType.GetMethod("MethodA");

        Object obj = Activator.CreateInstance(myType);
        // Execute the method.
        mymethod.Invoke(obj, null);
    }
}