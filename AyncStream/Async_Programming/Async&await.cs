using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Program p = new Program();
        string m = await p.GetMessageAsync();
        Console.WriteLine(m);
    }

    public async Task<string> GetMessageAsync()
    {
        await Task.Delay(2000);
        return "Hello Async";
    }
}