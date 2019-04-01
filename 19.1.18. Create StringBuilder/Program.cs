using System;
using System.Text;
using System.Reflection;

class MainClass
{
    public static void Main()
    {
        Type type = typeof(StringBuilder);

        Type[] argTypes = new Type[] { typeof(System.String), typeof(System.Int32) };

        ConstructorInfo cInfo = type.GetConstructor(argTypes);

        object[] argVals = new object[] { "Some string", 30 };

        // Create the object and cast it to StringBuilder.
        StringBuilder sb = (StringBuilder)cInfo.Invoke(argVals);

        Console.WriteLine(sb);
    }
}
//Some string