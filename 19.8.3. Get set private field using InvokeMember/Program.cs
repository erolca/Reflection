using System;
using System.Reflection;




public class Class1
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);

        type.InvokeMember("text", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance, null, o, new object[] { "C#" });
        string text = (string)type.InvokeMember("text", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, o, new object[] { });

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