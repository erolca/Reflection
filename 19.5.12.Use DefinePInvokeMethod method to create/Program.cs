using System;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;


//19.5.12.	Use DefinePInvokeMethod method to create a PInvoke method.



public class Example
{
    public static void Main()
    {
        AssemblyName asmName = new AssemblyName("MyTest");
        AssemblyBuilder dynamicAsm = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);

        ModuleBuilder dynamicMod = dynamicAsm.DefineDynamicModule(asmName.Name, asmName.Name + ".dll");

        TypeBuilder tb = dynamicMod.DefineType("MyType", TypeAttributes.Public | TypeAttributes.UnicodeClass);

        MethodBuilder mb = tb.DefinePInvokeMethod(
            "MyCount",
            "Kernel32.dll",
            MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            typeof(int),
            Type.EmptyTypes,
            CallingConvention.Winapi,
            CharSet.Ansi);

        mb.SetImplementationFlags(mb.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);
        Type t = tb.CreateType();

        MethodInfo mi = t.GetMethod("MyCount");
        Console.WriteLine(mi.Invoke(null, null));

        Console.WriteLine(asmName.Name + ".dll");
        dynamicAsm.Save(asmName.Name + ".dll");
    }
}