using System;

class MainClass
{
    static void Main()
    {
        DateTime dateTime = new DateTime();

        Type type = dateTime.GetType();
        foreach (
            System.Reflection.PropertyInfo property in
                type.GetProperties())
        {
            System.Console.WriteLine(property.Name);
        }
    }
}