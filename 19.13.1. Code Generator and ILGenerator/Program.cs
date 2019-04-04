using System;
using System.Reflection;
using System.Reflection.Emit;

class CodeGenerator
{
    public static void Main()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        AssemblyName assemName = new AssemblyName();
        assemName.Name = "MyAssembly";

        AssemblyBuilder assemBuilder = currentDomain.DefineDynamicAssembly(assemName, AssemblyBuilderAccess.Run);

        ModuleBuilder moduleBuilder = assemBuilder.DefineDynamicModule("MyModule");

        TypeBuilder typeBuilder = moduleBuilder.DefineType("MyClass", TypeAttributes.Public);
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("HelloWorld", MethodAttributes.Public, null, null);
        ILGenerator msilG = methodBuilder.GetILGenerator();
        msilG.EmitWriteLine("Hello from C# My");
        msilG.Emit(OpCodes.Ret);
        Type t = typeBuilder.CreateType();
        if (t != null)
        {
            object o = Activator.CreateInstance(t);
            MethodInfo helloWorld = t.GetMethod("HelloWorld");
            if (helloWorld != null)
            {
                helloWorld.Invoke(o, null);
            }
        }
    }
}