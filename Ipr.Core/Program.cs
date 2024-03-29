
using Ipr.Core;
using System.Text.Json;

IClass classq = new MyClass
{
    Name = "aa", LastName = "as"
};

IBigClass bC = new MyBigClass();

bC.LastModified = DateTime.Now; 
bC.SomeString = string.Empty;

Pr(bC);


void Pr(IClass cl)
{
    var json = JsonSerializer.Serialize(cl);
    Console.WriteLine(cl.GetType());
}