using System;

record Student(string FirstName, string LastName, string FavouriteFood);

class Program
{
    static void Main()
    {
        // Student who should have access
        var student = new Student("John", "Doe", "Pizza");
        
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
            new Student("John", "Doe", "Pizza"),
            new Student("Some", "Body", "Roast")
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
        var uppercaseStudent = student with
        {
            FirstName = student.FirstName.ToUpper(),
            LastName = student.LastName.ToUpper(),
        };

        Console.WriteLine(FormatStudentName(uppercaseStudent));
    }
}