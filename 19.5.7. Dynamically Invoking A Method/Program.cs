using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tester
{
    public static void Main()
    {
        Type theMathType = Type.GetType("System.Math");
        Type[] paramTypes = new Type[1];
       paramTypes[0] = Type.GetType("System.Double");
        MethodInfo CosineInfo = theMathType.GetMethod("Cos", paramTypes);
        Object[] parameters = new Object[1];
        parameters[0] = 45 * (Math.PI / 180);
        Object returnVal = CosineInfo.Invoke(theMathType, parameters);
        Console.WriteLine(returnVal);
    }
}

//0,707106781186548