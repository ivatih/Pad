Predicate<int> isEven = delegate(int x)
    { return x % 2 == 0; };

Console.WriteLine(isEven(1));
Console.WriteLine(isEven(4));
