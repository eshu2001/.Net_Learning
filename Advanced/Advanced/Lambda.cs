using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //static void Main()
    //{
    //    Func<int, int, int> add = (a, b) => a + b;

    //    int result = add(10, 20);

    //    Console.WriteLine("Addition Result: " + result);
    //}
    interface Ipractice
    {
        abstract void program(int a, int b);
    }
    class practice : Ipractice

    {
        
    private readonly Action<int,int> _alert;
        public practice(Action<int, int> _Alert){
            _alert = _Alert;
            }
        public void program(int a, int b)
        {
            //Console.WriteLine(a + b);
            _alert(a,b);
        }

        
    }
    class Practice
    {
        static void Main(string[] args)
        {
            Ipractice p = new practice((a, b) => Console.WriteLine(a + b));
            p.program(10, 20);
        }
    }
}
