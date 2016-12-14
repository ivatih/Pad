using System.Linq.Expressions;

Expression<Func<string, string, bool>> expression = (x, y) => x.StartsWith(y);

var compiled = expression.Compile();

Console.WriteLine(compiled("First", "Second"));
Console.WriteLine(compiled("First", "Fir"));

