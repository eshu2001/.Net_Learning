using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        var task = DoWorkAsync(token);

        await Task.Delay(2000);
        cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was cancelled");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Working... {i}");
            await Task.Delay(1000, token);
        }
    }
}