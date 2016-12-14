Task<string> task = ReadFileAsync("garbage file");
try
{
	string text = await task;
	Console.WriteLine("File contents: {0}", text);
}
catch (IOException e)
{
	Console.WriteLine("Caught IOException: {0}", e.Message);
}

static async Task<string> ReadFileAsync(string filename)
{
    using (var reader = File.OpenText(filename))
    {
        return await reader.ReadToEndAsync();
    }
}
