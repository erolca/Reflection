﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;


//19.5.9.	Call string method with reflection and Expression

class MainClass
{
    static void Main()
    {
        MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        var target = Expression.Parameter(typeof(string), "x");
        var methodArg = Expression.Parameter(typeof(string), "y");
        Expression[] methodArgs = new[] { methodArg };

        Expression call = Expression.Call(target, method, methodArgs);

        var lambdaParameters = new[] { target, methodArg };
        var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);

        var compiled = lambda.Compile();

        Console.WriteLine(compiled("First", "S"));
    }
}