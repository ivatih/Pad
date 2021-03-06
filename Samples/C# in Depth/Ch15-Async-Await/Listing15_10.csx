Task<int> task = ComputeLengthAsync(null);
// We never get this far, as the exception is thrown eagerly.
Console.WriteLine("Fetched the task");
int length = await task;
Console.WriteLine("Length: {0}", length);

static Task<int> ComputeLengthAsync(string text)
{
    if (text == null)
    {
        throw new ArgumentNullException("text");
    }
    Func<Task<int>> func = async () =>
    {
        await Task.Delay(500); // Simulate real asynchronous work
        return text.Length;
    };
    return func();
}
