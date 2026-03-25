using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        Parallel.ForEach(numbers, num =>
        {
            Console.WriteLine($"Hello {num}");
        });
    }
}