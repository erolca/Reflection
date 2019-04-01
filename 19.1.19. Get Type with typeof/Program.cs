using System;
using System.Reflection;
using System.Globalization;
class Class1
{
    DateTime[] dateTimes = new DateTime[10];
    public DateTime this[int index]
    {
        get { return dateTimes[index]; }
        set { dateTimes[index] = value; }
    }


    private DateTime dateOfBirth;
    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public void Test()
    {
        Console.WriteLine("Test method called");
    }


    private string field;

    public string Property
    {
        get { return field; }
        set { field = value; }
    }

}


class MainClass
{

    static void Main(string[] args)
    {


        DateTime date;
        DateTime[] dates     = { new DateTime(2014, 6, 14, 6, 32, 0),
                                 new DateTime(2014, 7, 10, 23, 49, 0),
                                 new DateTime(2015, 1, 10, 1, 16, 0),
                                 new DateTime(2014, 12, 20, 21, 45, 0),
                                 new DateTime(2014, 6, 2, 15, 14, 0) };

        Class1 sinif    = new Class1();
        sinif[1]        = DateTime.Now;
        sinif[0]        = new DateTime(2014, 7, 10, 23, 49, 0);
        date            = sinif[0];
        

        Type type = typeof(Class1);
        Console.WriteLine(type.FullName);

        type = Type.GetType("Class1");
        Console.WriteLine(type.Namespace);



    }
}