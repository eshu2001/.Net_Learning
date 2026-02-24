using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace Assignment2
{
    public class Employee
    {
        private int id;
        private string name;
        private double monthlySalary;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }



        public virtual void SalaryCalculation()
        {
            Console.WriteLine("No Salary");
        }
    }
    public class FullTimeEmployee : Employee
    {

        public override void SalaryCalculation()
        {
            Console.WriteLine("------------------------------Full Time Employee----------------------------------------------");
            Console.WriteLine("Enter ID: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Salary for full time employee: ");
            MonthlySalary = Convert.ToDouble(Console.ReadLine());
            if (MonthlySalary > 0)
            {
                Console.WriteLine("Salary for " + Name + " is: " + MonthlySalary);
            }
            else
            {
                Console.WriteLine("Salary is in negative");
            }
        }
    }
    public class ContractEmployee : Employee
    {
        public override void SalaryCalculation()
        {
            Console.WriteLine("------------------------------Contract Employee----------------------------------------------");
            Console.WriteLine("Enter ID: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter no of hrs employee worked: ");
            int hrs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter hourly rate for the employee: ");
            double rate = Convert.ToDouble(Console.ReadLine());
            MonthlySalary = hrs * rate;
            Console.WriteLine("Salary for " + Name + " is: " + MonthlySalary);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new FullTimeEmployee();
            Employee employee1 = new ContractEmployee();

            employee.SalaryCalculation();
            employee1.SalaryCalculation();

        }
    }

}