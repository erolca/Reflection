using System;
using System.Reflection;


//19.5.13.	Get the method that matches the specified binding flags.



class Program
{
    // Method to get:
    public void MethodA() { }

    static void Main(string[] args)
    {
        // Get MethodA()
        MethodInfo mInfo = typeof(Program).GetMethod("MethodA", BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine("Found method: {0}", mInfo);

    }
}