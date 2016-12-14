WriteResult(delegate
{
    if (DateTime.Now.Hour < 12)
    {
        return 10;
    }
    else
    {
        return new object();
    }
});

delegate T MyFunc<T>();

static void WriteResult<T>(MyFunc<T> function)
{
    Console.WriteLine(function());
}
