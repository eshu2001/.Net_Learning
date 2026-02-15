//using System;

////class and object
//namespace Assignment
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Calculator calculator = new Calculator();
//            int Result = calculator.Sum(10, 20);
//            Console.WriteLine(Result);


//        }

//    }

//    class Calculator { 
//     public int Sum(int x, int y)
//        {
//            return x + y;
//        }
//    }
//}
//----------------------------------------------------------------------------------------------------------------------------------------
//using System;
//// Constructor and deconstructor
//class Person
//{
//    private string name;
//    public Person(string personName)
//    {
//        name = personName;
//        Console.WriteLine($"Constructor: {name} object is created.");
//    }

//    ~Person()
//    {
//        Console.WriteLine($"Destructor: {name} object is destroyed.");
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Program started.");
//        Person person1 = new Person("Eshita");
//        Console.WriteLine("Working with the object...");
//        person1 = null;
//        GC.Collect();
//        GC.WaitForPendingFinalizers();

//        Console.WriteLine("Program ended.");
//    }
//}

//-----------------------------------------------------------------------------------------------------------------------------------
//using System;

//// Abstract class
//abstract class Vehicle
//{
//    public abstract void StartEngine();
//    public void Honk()
//    {
//        Console.WriteLine("Vehicle is honking");
//    }
//}
//class Car : Vehicle
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Car engine started.");
//    }
//}
//class Bike : Vehicle
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Bike engine started.");
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Vehicle myCar = new Car(); 
//        Vehicle myBike = new Bike();  

//        myCar.StartEngine();  
//        myCar.Honk();        

//        myBike.StartEngine(); 
//        myBike.Honk();
//    }
//}
//-----------------------------------------------------------------------------------------------------------------------------------
//using System;
//// Encapsulation
//class BankAccount
//{
//    private double balance;
//    public BankAccount(double initialBalance)
//    {
//        if (initialBalance >= 0)
//            balance = initialBalance;
//        else
//            balance = 0;
//    }
//    public void Deposit(double amount)
//    {
//        if (amount > 0)
//            balance += amount;
//        else
//            Console.WriteLine("Deposit amount must be positive.");
//    }
//    public void Withdraw(double amount)
//    {
//        if (amount > 0 && amount <= balance)
//            balance -= amount;
//        else
//            Console.WriteLine("Invalid withdraw amount.");
//    }
//    public double GetBalance()
//    {
//        return balance;
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        BankAccount account = new BankAccount(500);

//        account.Deposit(200);
//        account.Withdraw(100);

//        Console.WriteLine("Current Balance: " + account.GetBalance());
//    }
//}
//------------------------------------------------------------------------------------------------------------------------
//using System;

////abstraction
//abstract class Vehicle
//{
//    public abstract void StartEngine();
//    public void Honk()
//    {
//        Console.WriteLine("Vehicle is honking!");
//    }
//}
//class Car : Vehicle
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Car engine started.");
//    }
//}
//class Bike : Vehicle
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("Bike engine started.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Vehicle myCar = new Car();
//        Vehicle myBike = new Bike();

//        myCar.StartEngine();  
//        myCar.Honk();         

//        myBike.StartEngine(); 
//        myBike.Honk();        
//    }
//}
//---------------------------------------------------------------------------------------------------------------------------------------------

//using System;

//// Inheritance
//class Vehicle
//{
//    public string Brand = "Generic Vehicle";

//    public void Honk()
//    {
//        Console.WriteLine("Vehicle is honking!");
//    }
//}
//class Car : Vehicle
//{
//    public string Model = "Sedan";

//    public void DisplayInfo()
//    {
//        Console.WriteLine($"Brand: {Brand}, Model: {Model}");
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        Car myCar = new Car();

//        myCar.Honk();      
//        myCar.DisplayInfo();   
//    }
//}

//---------------------------------------------------------------------------------------------------------------------------------------
//using System;
//// Polymorphism
//class Calculator
//{
//    public int Add(int a, int b)
//    {
//        return a + b;
//    }

//    public double Add(double a, double b)
//    {
//        return a + b;
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        Calculator calc = new Calculator();

//        Console.WriteLine(calc.Add(5, 10));     
//        Console.WriteLine(calc.Add(3.5, 2.5));   
//    }
//}
//--------------------------------------------------------------------------------------------------------------------------------------------


