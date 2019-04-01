using System;
using System.Collections;
using System.Linq;
using System.ComponentModel;

class MainClass
{
    static void Main()
    {
        ArrayList list = new ArrayList { "First", "Second", "Third" };
        var strings = list.Cast<string>();
        foreach (string item in strings)
        {
            Console.WriteLine(item);
        }
        list = new ArrayList { 1, "not an int", 2, 3 };
        var ints = list.OfType<int>();
        foreach (int item in ints)
        {
            Console.WriteLine(item);
        }


        ints = list.Cast<int>();
        foreach (int item in ints)
        {
            Console.WriteLine(item);
        }
    

    }
}