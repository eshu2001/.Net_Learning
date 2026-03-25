using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int result = await GetNumberAsync();
        Console.WriteLine(result);
    }

    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(2000);
        return 10;
    }
}