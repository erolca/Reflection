using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

/*
 * 
 * Reflection objects are used for obtaining type information at runtime. 
 * The classes that give access to the metadata of a running program are in the System.Reflection namespace.
 * 
 * The System.Reflection namespace contains classes that allow you to obtain
 * information about  the application and to dynamically add types, values, and
 * objects to the application.
 * 
 * 
 * Applications of Reflection
 * 
 * 
 * Reflection has the following applications −
 * 
 * 
 * It allows view attribute information at runtime.
 * It allows examining various types in an assembly and instantiate these types.
 * It allows late binding to methods and properties
 * It allows creating new types at runtime and then performs some tasks using those types.
 * 
 
  System.Type is derived from an abstract class called System.Reflection.MemberInfo.

    MemberInfo defines the following abstract, read-only properties:   
     
    Return Type	Method Name	Meanings
    Type	DeclaringType	    The type of the class or interface in which the member is declared.
    MemberTypes	MemberType	    The type of the member.
    string	Name	            The name of the type.
    Type	ReflectedType	    The type of the object being reflected. 

    MemberTypes is an enumeration:

    MemberTypes.Constructor
    MemberTypes.Method
    MemberTypes.Field
    MemberTypes.Event
    MemberTypes.Property
     
     
     
  */
public class MainClass
{
    public static void Main()
    {
        string s = "A string";
        Type t = s.GetType();
        Console.WriteLine(t.Name);
        Console.WriteLine(t.Namespace);
        Console.WriteLine(t.IsPublic);
        Console.WriteLine(t == typeof(string));

        Type t2 = Type.GetType("System.String");// tipini alabilirim
        Type t4 = Type.GetType("system.string", true, true);


        StringBuilder sb = new StringBuilder();
        Type t6 = sb.GetType();

    }

}

/*
 
   output:

   String
   System
   True
   True
     
     
     
*/
