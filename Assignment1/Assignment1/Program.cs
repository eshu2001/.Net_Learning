using System;
namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Name = new List<string>();
            List<int> Marks = new List<int>();

            Console.WriteLine("Enter number of Students");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Please enter your Name: ");
                string nameInput = Console.ReadLine();
                Name.Add(nameInput);
                Console.WriteLine("Please enter your Marks: ");
                int MarksInput = Convert.ToInt32(Console.ReadLine());
                Marks.Add(MarksInput);
            }
            Console.WriteLine("Student Details: ");

            for(int i=0; i<n; i++)
            {
                Console.WriteLine("Name: "+ Name[i]+ " Marks: "+ Marks[i]);
            }

            //Average Marks
            int sum=0;
            for (int z = 0; z < n; z++)
            {
                sum += Marks[z];
            }
            Console.WriteLine("Average Marks: " + sum / n);

            // Identify the Topper
            int t = 0;
            for(int z = 1; z < n;z++) {
                if (Marks[z] > Marks[t])
                {
                    t = z;
                }

            }
            Console.WriteLine("Topper of the class: " + Name[t]);
        }
    }
}
