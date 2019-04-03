using System;
using System.Collections.Generic;

public class MainClass
{
    static void Main()
    {
        IList<int> intList = (IList<int>)CreateClosedType<int>(typeof(List<>));

        IList<double> doubleList = (IList<double>)CreateClosedType<double>(typeof(List<>));

        Console.WriteLine(intList);
        Console.WriteLine(doubleList);
    }

    static object CreateClosedType<T>(Type genericType)
    {
        Type[] typeArguments = {
            typeof( T )
        };

        Type closedType = genericType.MakeGenericType(typeArguments);

        return Activator.CreateInstance(closedType);
    }
}

//System.Collections.Generic.List`1[System.Int32]
//System.Collections.Generic.List`1[System.Double] 