using System;
//19.1.24.	Get the type associated with the CLSID and specify whether to throw an exception if an error occurs while loading the type.

class MainClass
{
    public static void Main()
    {
        Guid myGuid1 = new Guid("1DCD0710-0B41-11D3-A565-00C04F8EF6E3");
        Type myType1 = Type.GetTypeFromCLSID(myGuid1, true);
        Console.WriteLine("The GUID associated with myType1 is {0}.", myType1.GUID);
        Console.WriteLine("The type of the GUID is {0}.", myType1.ToString());
    }
}