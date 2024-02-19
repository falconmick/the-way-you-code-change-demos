namespace ResultReadFileExample;


public class ReadFileException : Exception
{
    public ReadFileException(string? message)
        : base(message){}
}

public static class Example
{
    // who's gonna write detailed documentation!!!
    public static int ReadFileAndCount()
    {
        var file = ReadFile(@"C:\dev\MutationExample\foo.bar.txt");
        return file.Length;
    }
    
    /// <summary>
    /// Reading files is hard, not any more!
    /// </summary>
    /// <param name="filePath">file location</param>
    /// <returns>file contents</returns>
    /// <exception cref="ReadFileException">Throws a domain level exception if something goes wrong</exception>
    public static string ReadFile(string filePath)
    {
        try
        {
            using StreamReader sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch (Exception)
        {
            // Handle the exception by throwing a new one with a custom message
            throw new ReadFileException("File not read");
        }
    }
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
        Console.WriteLine(Example.ReadFileAndCount());
    }
}

/*
enum class Result<T, E>
{
    Ok(T value),
    Error(E error)
}

public static Result<string, ReadFileException> ReadFileAndCount() {}


*/
