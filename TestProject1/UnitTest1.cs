namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // DoAnimalThing(null);
        DoAnimalThing(new Dog());
        DoAnimalThing(new Dog { Age = 12});
        DoAnimalThing(new Cat());
    }
    
public abstract class Animal
{
    public int Age { get; set; }
    public void Eat(){ /* ... */ }
}

public class Dog : Animal
{
    public void Bark(){ /* ... */ }
}

public class Cat : Animal
{
    public void Meow(){ /* ... */ }
}

public static void DoAnimalThing(Animal? animal)
{
    if (animal is null)
    {
        throw new ArgumentNullException(nameof(animal), "Sequence can't be null.");
    }
    else if (animal is Dog dog)
    {
        dog.Bark();
    }
    else
    {
        animal.Eat();
    }
}
    
public static string GetAnimalFavouriteTreat(Animal? animal) =>
    animal switch
    {
        Dog { Age: > 10 } => "Beef",
        Dog => "Sausages",
        Cat => "Milk",
        null => "Pancake Stacks",
        _   => "Unknown"
    };

public static string GetAnimalFavouriteTreatYeOlden(Animal? animal)
{
    if (animal == null)
    {
        return "Pancake Stacks";
    }

    switch (animal.GetType().Name)
    {
        case "Dog": // cannot infer type so cannot use Dog methods!!
            return animal.Age > 10 ? "Beef" : "Sausages";
        case "Cat":
            return "Milk";
        default:
            return "Unknown";
    }
}
}


enum class Animal 
{
    Dog(string BallColor),
    Cat,
    Bird(int WingSpan, string OwnerName)
}

record Dog
{
    public required string BallColor { get; init; }
}

enum class Option<T> 
{
    Some(T value),
    None
}

class Person
{
    public int Age { get; set; }
    public int Height { get; set; }
    public Option<Person> Partner { get; set; }

public static Option<int> GetPartnerAge(Person person)
{
    return person.Partner?.Age;
}
}