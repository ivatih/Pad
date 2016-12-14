#r ".\Chapter11.exe"

using Chapter11.Model;
using Chapter11.Queries;

var query = from left in Enumerable.Range(1, 4)
            from right in Enumerable.Range(11, left)
            select new { Left=left, Right=right };

foreach (var pair in query)
{
    Console.WriteLine("Left={0}; Right={1}", 
                      pair.Left, pair.Right); 
}