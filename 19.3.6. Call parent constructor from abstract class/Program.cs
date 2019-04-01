using System;
public class HelloWorld
{
    public static void Main()
    {
        Person hs = new Person("Hitesh", "Seth");
        Console.WriteLine(hs.GetFullName());
    }
}
abstract public class Abstract
{
    protected string FirstName, LastName;
    public Abstract(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
    abstract public string GetFullName();
}
public class Person : Abstract
{
    public Person(string FirstName, string LastName) : base(FirstName, LastName)
    {
    }
    public override string GetFullName()
    {
        return FirstName + "." + LastName;
    }
}