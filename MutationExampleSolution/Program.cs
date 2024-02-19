using System;

record Student
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string FavouriteFood { get; init; }
}

class Program
{
    static void Main()
    {
        // user has input student who should have access
        var student = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            FavouriteFood = "Pizza",
        };
        
        // we show the user who is attempting to access
        PrintName(student);

        if (PersonExistsQuery(student))
        {
            Console.WriteLine("Access Granted");
        }
        else
        {
            Console.WriteLine("Access Denied");
        }
    }
    
    
    
    
    static bool PersonExistsQuery(Student student)
    {
        var database = new List<Student>
        {
            new() { FirstName = "John", LastName = "Doe", FavouriteFood = "Pizza" },
            new() { FirstName = "Some", LastName = "Body", FavouriteFood = "Roast" }
        };
        
        return database.Exists(s
            => s.FirstName == student.FirstName && s.LastName == student.LastName);
    }

    
    
    
    
    
    
    // We need to output the users name in a bunch of different ways
    // so we decided to keep our code DRY and extract that logic here
    static string FormatStudentName(Student student)
    {
        return $"Student Name: {student.FirstName} {student.LastName}";
    }

    
    
    
    
    // note: Jira ticket CoolProduct-4821 a product manager
    // has requested we print the names a little nicer
    // for the demo on Tuesday
    static void PrintName(Student student)
    {
        // student.FirstName = student.FirstName.ToUpper();
        // student.LastName = student.LastName.ToUpper();
        var uppercaseStudent = student with
        {
            FirstName = student.FirstName.ToUpper(),
            LastName = student.LastName.ToUpper(),
        };

        Console.WriteLine(FormatStudentName(uppercaseStudent));
    }
}