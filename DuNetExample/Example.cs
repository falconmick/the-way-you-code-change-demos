using Dunet;

namespace DuNetExample;
using static Option<int>;

[Union]
partial record Option<T>
{
    partial record Some(T Value);
    partial record None();
}

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var result = ParseInt("2");
        result.Match(
            value => value.Value,
            none => 0);
        Console.WriteLine();
    }
    
    private Option<int> ParseInt(string? value) =>
        int.TryParse(value, out var number)
            ? new Some(number)
            : new None();
}