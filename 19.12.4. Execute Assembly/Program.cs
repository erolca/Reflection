using System;
class Test
{
    public static void Main()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");
        currentDomain.ExecuteAssembly("MyExecutable.exe");
        otherDomain.ExecuteAssembly("MyExecutable.exe");
    }
}