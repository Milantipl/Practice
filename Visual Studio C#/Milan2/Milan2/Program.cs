using System;
namespace MyApplication
{
    class Milan
    {
        static void Main(string[] args)
        {
            string name = "Milan";

            DateTime c = new DateTime(1, 1, 1);
            DateTime a = new DateTime(1999, 05, 23);
            DateTime b = DateTime.UtcNow.AddMinutes(330);          
            TimeSpan z = b - a;
            int age = (c + z).Year - 1;

            DateTime dateOnly = a.Date;         
            Console.WriteLine("My Name Is "+name);
            Console.WriteLine("My Age Is " + age);
            Console.WriteLine("My Birth Date Is " + dateOnly.ToString("d"));
        }
    }
}