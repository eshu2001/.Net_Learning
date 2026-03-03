using System;
namespace BinaryOverload
{

    class Calculator
    {

        public int number = 0;

        public Calculator() { }
       
        public Calculator(int n)
        {
            number = n;
        }

        
        public static Calculator operator +(Calculator Calc1,
                                             Calculator Calc2)
        {
            Calculator Calc3 = new Calculator(0);
            Calc3.number = Calc2.number + Calc1.number;
            return Calc3;
        }

        
        public void display()
        {
            Console.WriteLine("{0}", number);
        }
    }


    class CalNum
    {

        
        static void Main(string[] args)
        {

            Calculator num1 = new Calculator(200);
            Calculator num2 = new Calculator(40);
            Calculator num3 = new Calculator();


            num3 = num1 + num2;

            num1.display(); 

            num2.display();

            num3.display(); 

        }
    }
}