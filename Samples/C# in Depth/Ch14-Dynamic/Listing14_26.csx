using System.Dynamic;

dynamic expando = new ExpandoObject();
expando.AddOne = (Func<int, int>)(x => x + 1);
Console.Write(expando.AddOne(10));