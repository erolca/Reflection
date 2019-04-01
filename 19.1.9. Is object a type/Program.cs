using System;
using System.IO;

class MainClass
{
    public static void Main()
    {
        Object someObject = new StringReader("This is a StringReader");


        if (IsType(someObject, "System.IO.TextReader"))
        {
            Console.WriteLine("GetType: someObject is a TextReader");
        }
    }
    public static bool IsType(object obj, string type)
    {
        Type t = Type.GetType(type, true, true);

        return t == obj.GetType() || obj.GetType().IsSubclassOf(t);
    }

}