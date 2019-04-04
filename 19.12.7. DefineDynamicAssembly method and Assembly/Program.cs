using System;
using System.Reflection;
using System.Reflection.Emit;

class Test
{
    public static void Main()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;

        currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

        InstantiateMyDynamicType(currentDomain);
    }

    static void InstantiateMyDynamicType(AppDomain domain)
    {
        try
        {
            domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyDynamicType");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        AppDomain domain = (AppDomain)sender;
        AssemblyName assemblyName = new AssemblyName();
        assemblyName.Name = "MyDynamicAssembly";

        AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyDynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public);
        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
        ILGenerator ilGenerator = constructorBuilder.GetILGenerator();

        ilGenerator.EmitWriteLine("MyDynamicType instantiated!");
        ilGenerator.Emit(OpCodes.Ret);

        typeBuilder.CreateType();

        return assemblyBuilder;
    }
}