//using System;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        try
//        {
//            await DoWorkAsync();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Caught Exception: {ex.Message}");
//        }
//    }

//    static async Task DoWorkAsync()
//    {
//        await Task.Delay(500);
//        throw new InvalidOperationException("Something went wrong in async code");
//    }
//}