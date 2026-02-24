using System;
namespace Assignment1
{
    class Calculator
    {

        public void Cal(String[] args)
        {
            Console.WriteLine("Enter a number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Operator: ");
            string Op = Console.ReadLine();

            switch (Op)
            {
                case ("+"):
                    Console.WriteLine(x + y);
                    break;
                case ("-"):
                    Console.WriteLine(x - y);
                    break;
                case ("*"):
                    Console.WriteLine(x * y);
                    break;
                case ("/"):
                    Console.WriteLine(x / y);
                    break;
                case ("%"):
                    Console.WriteLine(x % y);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            c.Cal(args);
            bool a = true;
            while (a)
            {
                Console.WriteLine("Do you want to continue Claculation: ");
                bool z = Convert.ToBoolean(Console.ReadLine());
                if (z)
                {
                    c.Cal(args);
                    a = true;
                }
                else
                {
                    a = false;
                }

            }
        }

    }
}

