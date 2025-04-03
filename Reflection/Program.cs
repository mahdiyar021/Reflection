// testing for reflection 

using Microsoft.Data.SqlClient;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
var intType = typeof(int);

var array = intType.MakeArrayType(3);

var list = typeof(List<>);

Console.WriteLine(list.Name);

Console.WriteLine(typeof(Func<,>).Name);

var type = list.MakeGenericType(intType);  // make List<int>

var listInt = (List<int>)Activator.CreateInstance(type)!; // create new object on runtime

foreach (var t in typeof(Environment).GetNestedTypes())
    Console.WriteLine(t.Name);

// write name , also type int and string
Console.WriteLine(typeof(Dictionary<int, string>).FullName);

// get interfaces
foreach (var t in typeof(string).GetInterfaces())
    Console.WriteLine(t.Name);

Console.WriteLine(MethodInfo.GetCurrentMethod().Name);

var paramName = string.Join(',', MethodInfo.GetCurrentMethod().GetParameters().Select(x => x.Name));

Console.WriteLine(paramName);

var one = 1;

methodref(ref one);

void methodref(ref int p)
{

    Console.WriteLine(MethodInfo.GetCurrentMethod().Name);

    var paramName = string.Join(',', MethodInfo.GetCurrentMethod().GetParameters().Select(x => x.Name));

    Console.WriteLine(paramName);
}

var cuntructInfo = typeof(string).GetConstructor([typeof(char[])]);

var cuntructInfo2 = typeof(string).GetConstructor(BindingFlags.NonPublic, []); // for getting not public constructor

char[] chars = ['c', 'b', 'a'];

var str = cuntructInfo.Invoke([chars]);

Console.WriteLine(str);

funcint a = Cube;

Console.WriteLine(a.DynamicInvoke(4));

//funcint Ssse = (funcint)Delegate.CreateDelegate(typeof(funcint),new Program(), "Cube"); // work on low level statement
//Console.WriteLine(Ssse(3));


var members = typeof(Program).GetMembers(); // its like get all prop , event , method , ctor ,nested type , type info

Console.WriteLine();
foreach (var member in members)
    Console.WriteLine(member.Name);

var info = typeof(Program).GetMethod(nameof(Program.ToString))!;
var info2 = typeof(object).GetMethod(nameof(object.ToString))!;

Console.WriteLine();
Console.WriteLine(info.MethodHandle);
Console.WriteLine(info);
Console.WriteLine(info2.MethodHandle);
Console.WriteLine(info2.MethodHandle == info.MethodHandle);
Console.WriteLine(info2.MetadataToken == info.MetadataToken); // unique in assembly
Console.WriteLine();
Console.WriteLine(info.Module.Name);  // assembly name
Console.WriteLine(info2.Module.Name); // assembly name
Console.WriteLine(info2 == info);
Console.WriteLine();
Console.WriteLine(info.DeclaringType);
Console.WriteLine(info.ReflectedType);
Console.WriteLine(info2.DeclaringType);
Console.WriteLine(info2.ReflectedType);
Console.WriteLine();

Console.WriteLine(typeof(SqlConnection).BaseType);
Console.WriteLine(typeof(SqlConnection).BaseType.BaseType);
Console.WriteLine(typeof(SqlConnection).BaseType.BaseType.BaseType);

var fields = typeof(Program).GetMembers();

foreach (var field in fields)
    Console.WriteLine(field.Name);

MemberInfo m = typeof(walnut).GetMember(nameof(walnut.Crack))[0];
MethodInfo f = typeof(walnut).GetMethod(nameof(walnut.Crack))!;

Console.WriteLine(((MethodInfo)m).ReturnType);

var name = f.GetCustomAttributes().ToArray()[0].GetType().Name;

Console.WriteLine(name);

Console.WriteLine(m == f);

foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
{
    WriteLine(ass.FullName);

    foreach (var module in ass.Modules)
        WriteLine("    " + module.Name);

}



Console.ReadKey();

int Cube(int number) => number * number;

delegate int funcint(int number);


[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class TestAttribute(int number = 10) : Attribute
{

    public required string Name { get; set; }

}

class walnut
{
    public int number;

    [Test(Name ="ali")]
    public void Crack() => number = 1;
}


