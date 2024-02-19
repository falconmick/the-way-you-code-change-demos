using OneOf;
namespace OneOfExample;

record Success(int value);

record Failure(string? cause = "");

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        ParseInt("2");
    }
    
    private OneOf<Success, Failure> ParseInt(string? value) =>
        int.TryParse(value, out var number)
            ? new Success(number) : new Failure();
}