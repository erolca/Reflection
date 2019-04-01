using System;
using System.Reflection;


public class Class1
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);

        FieldInfo field = type.GetField("text", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(o, "www.domain.com");
        string text = (string)field.GetValue(o);

        Console.WriteLine(text);

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