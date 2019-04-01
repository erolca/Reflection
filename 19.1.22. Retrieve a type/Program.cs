using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//19.1.22.	Retrieve a type by passing a ProgID, specifying whether to throw an exception if the ProgID is invalid.

class MainApp
{
    public static void Main()
    {
        try
        {
            string myString1 = "DIRECT.ddPalette.3";
            string myString2 = "WrongProgramID";
            Type myType1 = Type.GetTypeFromProgID(myString1, true);
            Console.WriteLine("GUID for ProgramID DirControl.DirList.1 is {0}.", myType1.GUID);
            Type myType2 = Type.GetTypeFromProgID(myString2, true);
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Source: {0}", e.Source);
            Console.WriteLine("Message: {0}", e.Message);
        }
    }
}