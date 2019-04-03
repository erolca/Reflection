using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        Stack<int> s = new Stack<int>();

        Type t = s.GetType();

        foreach (Type types in t.GetGenericArguments())
        {
            System.Console.WriteLine(
                "Type parameter: " + types.FullName);
        }
        // ...
    }
}