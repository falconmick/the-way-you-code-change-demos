using System.Text.Json;
using FluentAssertions;

namespace OpenEnumExample;

public enum Animal // v1
{
    Dog = 0,
    Cat = 1,
    // Bird = 2, v2
}

public static class Demo
{
    public static int GetMaxAge(Animal animal) =>
        animal switch                                               // TreatWarningsAsErrors
        {
            Animal.Dog => 13,
            Animal.Cat => 15,
        };
}

public class Cool
{
    public Animal Animal { get; set; }
}

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Dog()
    {
        var animal = JsonSerializer.Deserialize<Cool>("{\"Animal\": 0}")!.Animal;
        Demo.GetMaxAge(animal).Should().Be(13);
    }

    [Test]
    public void Cat()
    {
        var animal = JsonSerializer.Deserialize<Cool>("{\"Animal\": 1}")!.Animal;
        Demo.GetMaxAge(animal).Should().Be(15);
    }

    [Test]
    public void Bird()
    {
        var animal = JsonSerializer.Deserialize<Cool>("{\"Animal\": 2}")!.Animal;
        Demo.GetMaxAge(animal).Should().Be(22);
    }
}