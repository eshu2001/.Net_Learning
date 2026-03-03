using System;

class Program
{
    static void Main()
    {
        (int Id, string Message, bool IsActive) tuple = (123, "Hello", true);

        Console.WriteLine(tuple.Id);
        Console.WriteLine(tuple.Message);
        Console.WriteLine(tuple.IsActive);
    }
}