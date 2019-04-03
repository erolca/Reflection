using System;
using System.Reflection;


public class Class1
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);

        //get and set a property using a PropertyInfo
        PropertyInfo property = type.GetProperty("Text");
        property.SetValue(o, "www.softconcepts.com", null);
        string text = (string)property.GetValue(o, null);

        Console.WriteLine(text);

        EventInfo eventInfo = type.GetEvent("Changed");
        eventInfo.AddEventHandler(o, new EventHandler(Class1.OnChanged));
        ((MyClass)o).Text = "New Value";
    }
    private static void OnChanged(object sender, System.EventArgs e)
    {
        Console.WriteLine(((MyClass)sender).Text);
    }
}
public class MyClass
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            OnChanged();
        }
    }

    private void OnChanged()
    {
        if (Changed != null)
            Changed(this, System.EventArgs.Empty);
    }

    public event EventHandler Changed;
}