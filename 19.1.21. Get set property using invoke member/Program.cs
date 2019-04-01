using System;
using System.Reflection;


public class Class1
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);

         type.InvokeMember("Text", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public, null, o, new object[] { "Windows Developer Magazine" });
        
        string text = (string)type.InvokeMember("Text", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, null, o, new object[] { });
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