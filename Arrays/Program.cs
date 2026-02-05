
//// sum of array elements
//using System;
//namespace ControlFlowDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 1, 2, 3, 4, 5 };
//            int sum = 0;

//            for (int i = 0; i < arr.Length; i++)
//            {
//                sum += arr[i];
//            }

//            Console.WriteLine("Sum = " + sum);

//        }
//    }
//}

//// maximum element in array
//using System;
//namespace ControlFlowDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 45, 23, 89, 5 };
//            int max = arr[0];

//            for (int i = 1; i < arr.Length; i++)
//            {
//                if (arr[i] > max)
//                    max = arr[i];
//            }

//            Console.WriteLine("Max = " + max);


//        }
//    }
//}

//// Reverse an array
//using System;
//namespace ControlFlowDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 1, 2, 3, 4, 5 };

//            for (int i = arr.Length - 1; i >= 0; i--)
//            {
//                Console.Write(arr[i] + " ");
//            }


//        }
//    }
//}

//// Search an element in array

//using System;
//namespace ControlFlowDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 20, 30, 40 };
//            int search = 30;
//            bool found = false;

//            for (int i = 0; i < arr.Length; i++)
//            {
//                if (arr[i] == search)
//                {
//                    found = true;
//                    break;
//                }
//            }

//            if (found)
//                Console.WriteLine("Element found");
//            else
//                Console.WriteLine("Element not found");



//        }
//    }
//}


// duplicate elements
using System;
namespace ControlFlowDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 2, 4, 1 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        Console.WriteLine("Duplicate: " + arr[i]);
                        break;
                    }
                }
            }


        }
    }
}
