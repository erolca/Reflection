using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Parameter)]

public class ArgumentUsageAttribute : Attribute
{
    public ArgumentUsageAttribute(string UsageMsg)
    {
        this.usageMsg = UsageMsg;
    }
    protected string usageMsg;
    public override string ToString()
    {
        return base.ToString() + ":" + usageMsg;
    }
}

[AttributeUsage(AttributeTargets.Parameter)]

public class ArgumentIDAttribute : Attribute
{
    public ArgumentIDAttribute()
    {
        this.instanceGUID = Guid.NewGuid();
    }
    protected Guid instanceGUID;
    public override string ToString()
    {
        return base.ToString() + "." + instanceGUID.ToString();
    }
}

public class TestClass
{
    public void TestMethod(
        [ArgumentID]
            [ArgumentUsage("message.")]
            String[] strArray,
        [ArgumentID]
            [ArgumentUsage("a test.")]
            params String[] strList)
    { }
}

class AttributeEqualsDemo
{
    static void Main()
    {
        Type clsType = typeof(TestClass);
        MethodInfo mInfo = clsType.GetMethod("TestMethod");

        ParameterInfo[] pInfoArray = mInfo.GetParameters();
        if (pInfoArray != null)
        {
            ArgumentUsageAttribute arrayUsageAttr1 = (ArgumentUsageAttribute)
                Attribute.GetCustomAttribute(pInfoArray[0],
                    typeof(ArgumentUsageAttribute));

            ArgumentUsageAttribute arrayUsageAttr2 = (ArgumentUsageAttribute)
                Attribute.GetCustomAttribute(pInfoArray[0],
                    typeof(ArgumentUsageAttribute));

            Console.WriteLine("   \"{0}\" == \n   \"{1}\" ? {2}",
                arrayUsageAttr1.ToString(), arrayUsageAttr2.ToString(),
                arrayUsageAttr1.Equals(arrayUsageAttr2));

        }
    }
}