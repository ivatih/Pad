#r ".\Chapter11.exe"

using Chapter11.Model;

User tim = SampleData.Users.TesterTim;

var query = from bug in SampleData.AllDefects 
            where bug.Status != Status.Closed
            where bug.AssignedTo == tim
            orderby bug.Severity descending, bug.LastModified
            select bug;

foreach (var bug in query)
{
    Console.WriteLine("{0}: {1} ({2:d})", 
                      bug.Severity, bug.Summary, bug.LastModified);
}