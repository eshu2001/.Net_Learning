//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CSharp_8._0
//{
//    class Program
//    {
//        public static async IAsyncEnumerable<int> GenerateSequence()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                await Task.Delay(2000);
//                yield return i;
//            }
//        }
//        public static async Task PrintSequence()
//        {
//            await foreach (var number in GenerateSequence())
//            {
//                Console.WriteLine(number);
//            }
//        }
//        static void Main(string[] args)
//        {
//            PrintSequence().Wait();
//        }

//    }
//}
