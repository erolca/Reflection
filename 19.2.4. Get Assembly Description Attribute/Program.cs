using System;
using System.Reflection;

[assembly: AssemblyDescription("A sample description")]
public class DemoClass
{
    static void Main(string[] args)
    {
        Type clsType = typeof(DemoClass);
        Assembly assy = clsType.Assembly;
        String assyName = assy.GetName().Name;
        bool isdef = Attribute.IsDefined(assy, typeof(AssemblyDescriptionAttribute));
        if (isdef)
        {
            Console.WriteLine(assyName);
            AssemblyDescriptionAttribute adAttr = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(
                assy, typeof(AssemblyDescriptionAttribute));
            if (adAttr != null)
                Console.WriteLine("The description is \"{0}\".", adAttr.Description);
        }
    }
}