using System;
using System.Reflection;

public class MyClass
{
    private int[,] myValue = new int[10, 10];

    public int this[int i, int j]
    {
        get
        {
            return myValue[i, j];
        }
        set
        {
            myValue[i, j] = value;
        }
    }
}
public class MyTypeClass
{
    public static void Main()
    {
        try
        {
            Type myType = typeof(MyClass);
            Type[] myTypeArray = new Type[2];
            myTypeArray.SetValue(typeof(int), 0);
            myTypeArray.SetValue(typeof(int), 1);
            PropertyInfo myPropertyInfo = myType.GetProperty("Item", typeof(int), myTypeArray, null);
            Console.WriteLine(myType.FullName);
            Console.WriteLine(myPropertyInfo.Name);
            Console.WriteLine(myPropertyInfo.PropertyType);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred " + ex.Message);
        }
    }
}