using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
//String Length
//namespace Practice
//{
//    class Practice
//    {
//        static void Main(string[] args)
//        {
//            string name;
//            Console.WriteLine("Enter any Name:");
//            name= Console.ReadLine();
//            Console.WriteLine(name.Length);
//        }
//    }
//}


//Convert to Upper & Lower case
//namespace Practice
//{
//    class Practice
//    {
//        static void Main(string[] args)
//        {
//            string? name;
//            Console.WriteLine("Enter any Name:");
//            name = Console.ReadLine();
//            Console.WriteLine(name.ToUpper());
//            Console.WriteLine(name.ToLower());
//        }
//    }
//}


//Check if string contains a word
//namespace Practice
//{
//    class Practice
//    {
//        static void Main(string[] args)
//        {
//            string? name;
//            Console.WriteLine("Enter any sentence:");
//            name = Console.ReadLine();
//            if (name.Contains("is"))
//            {
//                Console.WriteLine("It has 'is'");
//            }
//            else
//            {
//                Console.WriteLine("Nothing");
//            }
//        }
//    }
//}

//Reverse String
//namespace Practice
//{
//    class Practice
//    {
//        static void Main(string[] args)
//        {
//            string? name;
//            char[] name1;
//            Console.WriteLine("Enter any sentence:");
//            name = Console.ReadLine();
//            name1 = name.ToCharArray();
//            Array.Reverse(name1);
//            Console.WriteLine(name1);
//        }
//    }
//}


// Count vowels in a string
namespace Practice
{
    class Practice
    {
        static void Main(string[] args)
        {
            string? name;
            char[] vowels = { 'a','e','i','o','u'};
            int count = 0;
            Console.WriteLine("Enter any sentence:");
            name = Console.ReadLine().ToLower();
            if (name != null)
            {
                
                foreach (char c in vowels)
                {
                    
                    if (name.Contains(c))
                    {
                        count++;                      
                    }
                    
                }
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine("Nothing");
            }

        }
    }
}
