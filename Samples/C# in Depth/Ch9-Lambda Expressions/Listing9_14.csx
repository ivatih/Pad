PrintType(1, new object());

static void PrintType<T>(T first, T second)
{
    Console.WriteLine(typeof(T));
}
