using System;
using System.Reflection;
using System.IO;
using System.Collections;

class Class1
{
    [STAThread]
    static int Main(string[] args)
    {
        ArrayList filterStrings = new ArrayList();
        filterStrings.Add("your value");
        Assembly asm = Assembly.LoadFile("assembly file");
        MemberFilter filter = new MemberFilter(OnCustomSearch);

        foreach (Module module in asm.GetModules())
        {
            foreach (Type t in module.GetTypes())
            {
                if (filterStrings.Contains(t.Name))
                    Console.WriteLine("Found type {0}", t.Name);

                MemberInfo[] foundMembers = t.FindMembers(MemberTypes.All, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly,
                    filter, filterStrings);

                foreach (MemberInfo member in foundMembers)
                {
                    Console.WriteLine("Found member {0} which is a {1} defined in {2}.", member.Name, member.MemberType, t.Name);
                }
            }
        }
        return 0;
    }

    public static bool OnCustomSearch(MemberInfo member, object filter)
    {
        ArrayList al = (ArrayList)filter;
        if (al.Contains(member.Name))
            return true;

        if (al.Contains(member.MemberType))
            return true;

        return false;
    }
}