namespace MutationExampleSolution;


public class Animal
{
    public int Age { get; set; }
    public void Eat(){ // ... }
}

public class Dog : Animal
{
    public void Bark(){ // ... }
}
    
public class Cat : Animal
{
    public void Meow(){ // ... }
}

public class Tests
{
    
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
        _   => "Unknown"
    };

