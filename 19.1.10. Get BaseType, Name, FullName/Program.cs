using System;
//19.1.10.	Get BaseType, Name, FullName and Namespace for a type



class MainClass
{
    static void Main(string[] args)
    {
        Object cls1 = new Object();
        System.String cls2 = "Test String";
        System.Int16 Cint = 1250;

        Type type1 = cls1.GetType();
        Type type2 = cls2.GetType();
        Type type3 = Cint.GetType();

        // Object class output
        Console.WriteLine(type1.BaseType);
        Console.WriteLine(type1.Name);
        Console.WriteLine(type1.FullName);
        Console.WriteLine(type1.Namespace);
        Console.WriteLine("...................");
        // string output
        Console.WriteLine(type2.BaseType);
        Console.WriteLine(type2.Name);
        Console.WriteLine(type2.FullName);
        Console.WriteLine(type2.Namespace);

        Console.WriteLine("...................");
        //int16 output
        Console.WriteLine(type3.BaseType);
        Console.WriteLine(type3.Name);
        Console.WriteLine(type3.FullName);
        Console.WriteLine(type3.Namespace);



        Console.WriteLine("...................");
    }
}

//Object
//System.Object
//System
//System.Object
//String
//System.String
//System