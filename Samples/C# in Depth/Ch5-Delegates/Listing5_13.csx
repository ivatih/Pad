#r "System.Windows.Forms"

using System.Windows.Forms;

List<MethodInvoker> list = new List<MethodInvoker>();

for (int index = 0; index < 5; index++)
{
    int counter = index * 10;
    list.Add(delegate
    {
        Console.WriteLine(counter);
        counter++;
    });
}

foreach (MethodInvoker t in list)
{
    t();
}

list[0]();
list[0]();
list[0]();

list[1]();