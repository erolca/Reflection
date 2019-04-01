using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string assemblyName = "Your";
      

        try
        {
            Assembly a = Assembly.LoadFrom(assemblyName);
            object[] attributes = a.GetCustomAttributes(true);
            if (attributes.Length > 0)
            {
                Console.WriteLine("Assembly attributes for '{0}'...", assemblyName);

                foreach (object o in attributes)
                    Console.WriteLine("  {0}", o.ToString());
            }
            else
                Console.WriteLine("Assembly {0} contains no Attributes.", assemblyName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}