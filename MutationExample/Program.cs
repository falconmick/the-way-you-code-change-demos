using System;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FavouriteFood { get; set; }
}

class Program
{
    static void Main()
    {
        // Student who should have access
        Student student = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            FavouriteFood = "Pizza"
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
            new Student { FirstName = "John", LastName = "Doe", FavouriteFood = "Pizza" },
            new Student { FirstName = "Some", LastName = "Body", FavouriteFood = "Roast" }
        };

        return database.Exists(s
            => s.FirstName == student.FirstName && 
               s.LastName == student.LastName);
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
        // Mutate the first and last name (this should be fine?)
        student.FirstName = student.FirstName.ToUpper();
        student.LastName = student.LastName.ToUpper();

        Console.WriteLine(FormatStudentName(student));
    }
}