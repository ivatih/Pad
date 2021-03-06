#r ".\Chapter11.exe"

using Chapter11.Model;
using Chapter11.Queries;

var dates = new DateTimeRange(SampleData.Start, SampleData.End);

var query = from date in dates
            join defect in SampleData.AllDefects 
                 on date equals defect.Created.Date 
                 into joined
            select new { Date=date, Count=joined.Count() };

foreach (var grouped in query)
{
    Console.WriteLine("{0:d}: {1}", grouped.Date, grouped.Count);
}