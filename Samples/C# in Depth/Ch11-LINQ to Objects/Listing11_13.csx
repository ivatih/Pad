#r ".\Chapter11.exe"

using Chapter11.Model;

var query = from defect in SampleData.AllDefects 
            join subscription in SampleData.AllSubscriptions
                 on defect.Project equals subscription.Project
                 into groupedSubscriptions
            select new { Defect=defect, Subscriptions=groupedSubscriptions };

foreach (var entry in query)
{
    Console.WriteLine(entry.Defect.Summary);
    foreach (var subscription in entry.Subscriptions)
    {
        Console.WriteLine ("  {0}", subscription.EmailAddress);
    }
}